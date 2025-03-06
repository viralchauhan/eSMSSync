using eSMSSync.Models;
using eSMSSync.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.Sqlite;
using Newtonsoft.Json;
using Serilog;
using System.Text;
using System.Text.Json;
using System.Xml;
using Utils.Extension;

namespace eSMSSync.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SmsController : ControllerBase
    {
        private readonly SmsService _smsService;
        private readonly IBudgetService _budgetService;

        public SmsController(SmsService smsService, IBudgetService budgetService)
        {
            _smsService = smsService;
            _budgetService = budgetService;
        }

        // POST method that accepts a string parameter and returns the same string
        [HttpPost("GetPushSms")]
        public async Task<IActionResult> GetPushSms([FromBody] SmsMessage smsMessage)
        {
            // Log the incoming SMS details
            //Log.Information("Received SMS from {Sender}: {SmsBody} at {SmsDateTime}  {Pan} <=> {EmailId}", smsMessage.Sender, smsMessage.SmsBody, smsMessage.SmsDateTime,smsMessage.Pan,smsMessage.EmailId);

            // Insert the SMS record into the database
            await _smsService.InsertSmsAsync(smsMessage);

            // Return the same SMS details as the response
            return Ok(new { smsMessage.Sender, smsMessage.SmsBody, smsMessage.SmsDateTime });
        }

        [HttpPost("GetSyncData")]
        public async Task<IActionResult> GetSyncDataAsync([FromForm] ServerData serverData)
        {
            if(serverData == null || serverData.File == null)
            {
                return BadRequest("Invalid request data.");
            }
            // Validate that it's an SQLite file
            string fileExtension = Path.GetExtension(serverData.File.FileName).ToLower();
            if (fileExtension != ".sqlite" && fileExtension != ".db")
            {
                return BadRequest("Only SQLite (.sqlite or .db) files are allowed.");
            }
            // Define the path where the file will be stored
            string uploadFolder = Path.Combine(Directory.GetCurrentDirectory(), "UploadedDatabases");
            if (!Directory.Exists(uploadFolder))
            {
                Directory.CreateDirectory(uploadFolder);
            }

            // Generate a unique file name
            string filePath = Path.Combine(uploadFolder, $"{Guid.NewGuid()}{fileExtension}");

            // Save the file
            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await serverData.File.CopyToAsync(stream);
            }

            // Log the incoming SMS details
            Log.Information("Received SMS from {DeviceId}: {Pan} : {file}", serverData.DeviceId, serverData.Pan, serverData.File.FileName);

            // Read SQLite database and convert to structured JSON
            var _data = ReadSQLiteDatabase(filePath);


            //Save MobileDataBackup
            await _budgetService.MobileDataBackupSaveAsync(filePath, serverData.Pan, serverData.EmailId, CancellationToken.None);

            //Save AppSettings 
            await _budgetService.AppSettingsSaveAsync(_data.AppSettings!,serverData.Pan,serverData.EmailId, CancellationToken.None);

            //Save Categories  Need To Add EmailId and Pan
            await _budgetService.CategoriesSaveAsync(_data.Categories!, CancellationToken.None);

            //Save associated titles
            await _budgetService.AssociatedTitlesSaveAsync(_data.AssociatedTitles!, serverData.Pan, serverData.EmailId, CancellationToken.None);

            //Save wallets
            await _budgetService.WalletsSaveAsync(_data.Wallets!, serverData.Pan, serverData.EmailId, CancellationToken.None);

            //Save budgets
            await _budgetService.BudgetsSaveAsync(_data.Budgets!, serverData.Pan, serverData.EmailId, CancellationToken.None);

            //Save objectives
            await _budgetService.ObjectivesSaveAsync(_data.Objectives!, serverData.Pan, serverData.EmailId, CancellationToken.None);


            //Save transactions
            await _budgetService.TransactionsSaveAsync(_data.Transactions!, serverData.Pan, serverData.EmailId, CancellationToken.None);

            //Save category_budget_limits
            await _budgetService.CategoryBudgetLimitsSaveAsync(_data.CategoryBudgetLimits!, serverData.Pan, serverData.EmailId, CancellationToken.None);

            //Save delete_logs
            await _budgetService.DeleteLogsSaveAsync(_data.DeleteLogs!, serverData.Pan, serverData.EmailId, CancellationToken.None);

            //Save scanner_templates
            await _budgetService.ScannerTemplatesSaveAsync(_data.ScannerTemplates!, serverData.Pan, serverData.EmailId, CancellationToken.None);



            return Ok(new
            {
                Message = "File uploaded and read successfully",
                DeviceId = serverData.DeviceId,
                FileName = serverData.File.FileName,
                Data = _data
            });
        }

        [HttpGet("SendSyncData")]
        public async Task<IActionResult> SendSyncDataAsync([FromQuery] string pan, [FromQuery] string emailId)
        {
            if (string.IsNullOrEmpty(pan) || string.IsNullOrEmpty(emailId))
            {
                return BadRequest("Invalid request data.");
            }

            // Fetch Data from Services
            var reply = await _budgetService.GetMobileDataBackupAsync(pan, emailId, CancellationToken.None);

            if (reply?.BackupFileName != null)
            {
                if (!System.IO.File.Exists(reply?.BackupFileName))
                {
                    return StatusCode(500, "Error generating SQLite file.");
                }

                // Return the file for download
                var fileBytes = await System.IO.File.ReadAllBytesAsync(reply?.BackupFileName!);
                var fileName = $"SyncData_{DateTime.UtcNow:yyyyMMddHHmmss}.sqlite";

                return File(fileBytes, "application/x-sqlite3", fileName);
            }

            return NotFound();
        }



        // Function to read SQLite database and return structured JSON
        private Data ReadSQLiteDatabase(string dbFilePath)
        {
            var databaseJson = new Dictionary<string, object>();

            SQLitePCL.Batteries.Init(); // Ensure SQLite is initialized

            using (var connection = new SqliteConnection($"Data Source={dbFilePath}"))
            {
                connection.Open();

                // Get all table names
                var tableNames = new List<string>();
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = "SELECT name FROM sqlite_master WHERE type='table' AND name NOT LIKE 'sqlite_%'";
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            tableNames.Add(reader.GetString(0));
                        }
                    }
                }

                // Read data from each table
                foreach (var tableName in tableNames)
                {
                    var tableData = new Dictionary<string, object>();
                    var records = new List<Dictionary<string, object>>();

                    using (var command = connection.CreateCommand())
                    {
                        command.CommandText = $"SELECT * FROM {tableName}";
                        using (var reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                var row = new Dictionary<string, object>();
                                for (int i = 0; i < reader.FieldCount; i++)
                                {
                                    row[reader.GetName(i)] = reader.IsDBNull(i) ? null : reader.GetValue(i);
                                }
                                records.Add(row);
                            }
                        }
                    }

                    // Add table metadata and records
                    tableData["RecordCount"] = records.Count;
                    tableData["Records"] = records;
                    databaseJson[tableName] = tableData;
                }
            }

            var data = System.Text.Json.JsonSerializer.Serialize(databaseJson, new JsonSerializerOptions { WriteIndented = true });
            var ruleData = data.FromJson<Data>();

            return ruleData; // Return object instead of string
        }
    }
}
