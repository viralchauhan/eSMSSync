using Microsoft.Data.SqlClient; // Or Microsoft.Data.SqlClient;
using Dapper;
using System.Threading.Tasks;
using eSMSSync;

public class SmsService
{
    // Updated connection string
    private readonly string _connectionString = "Data Source=VEER;Initial Catalog=eWealthTracker;Integrated Security=False;Persist Security Info=False;User ID=sa;Password=viral;TrustServerCertificate=True;";


    // Insert SMS details into the database, avoiding duplicates
    public async Task InsertSmsAsync(SmsMessage smsMessage)
    {
        using (var connection = new SqlConnection(_connectionString)) // SqlConnection
        {
            // Open the database connection
            await connection.OpenAsync();

            // SQL query to check if the record already exists
            var checkQuery = @"
                SELECT COUNT(1)
                FROM SmsRow
                WHERE Sender = @Sender AND SmsDateTime = @SmsDateTime";

            // Execute the check query
            var existingCount = await connection.ExecuteScalarAsync<int>(checkQuery, new
            {
                Sender = smsMessage.Sender,
                SmsDateTime = smsMessage.SmsDateTime
            });

            // If the record doesn't exist, insert the new record
            if (existingCount == 0)
            {
                var insertQuery = @"
                    INSERT INTO SmsRow (Sender, SmsBody, SmsDateTime)
                    VALUES (@Sender, @SmsBody, @SmsDateTime)";

                // Execute the insert query
                await connection.ExecuteAsync(insertQuery, new
                {
                    Sender = smsMessage.Sender,
                    SmsBody = smsMessage.SmsBody,
                    SmsDateTime = smsMessage.SmsDateTime
                });
            }
        }
    }
}
