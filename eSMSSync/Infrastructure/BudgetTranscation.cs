
using BuildingBlocks.Common.DBHelper.Interface;
using BuildingBlocks.Common.DBHelper.Model;
using eSMSSync.Models;
using System.Security.AccessControl;

namespace eSMSSync.Infrastructure
{
    public class BudgetTranscation(IDataDbConfigurationService dataDbConfigurationService) : IBudgetTranscation
    {
        private readonly IDataDbConfigurationService _dataDbConfigurationService = dataDbConfigurationService;

        public async Task<dynamic> SaveAppSettingsAsync(IEnumerable<dynamic> appsettings, CancellationToken token)
        {
            var dbSettings = new DataDbConfigSettings<IEnumerable<dynamic>>
            {
                PlainQuery = "SP_SAVE_MOBILE_BUDGET_APPSETTINGS", // Stored procedure for inserting investment type
                Request = appsettings
            };

            return await _dataDbConfigurationService.BulkInsertAsyncAsync<dynamic, dynamic>(dbSettings, "AppSettingsTableMobileBudget");
        }



        public async Task<dynamic> SaveCategoriesAsync(IEnumerable<dynamic> categories, CancellationToken token)
        {
            var dbSettings = new DataDbConfigSettings<IEnumerable<dynamic>>
            {
                PlainQuery = "SP_SAVE_MOBILE_BUDGET_CATEGORIES", // Stored procedure for inserting investment type
                Request = categories
            };

            return await _dataDbConfigurationService.BulkInsertAsyncAsync<dynamic, dynamic>(dbSettings, "AppCategoriesTableMobileBudget");
        }

        
        public async Task<dynamic> SaveAssociatedTitlesAsync(IEnumerable<dynamic> associatedTitle, CancellationToken token)
        {
            var dbSettings = new DataDbConfigSettings<IEnumerable<dynamic>>
            {
                PlainQuery = "SP_SAVE_MOBILE_BUDGET_ASSOCIATED_TITLE", // Stored procedure for inserting associatedTitle
                Request = associatedTitle
            };

            return await _dataDbConfigurationService.BulkInsertAsyncAsync<dynamic, dynamic>(dbSettings, "AppAssociatedTitleTableMobileBudget");
        }

       
        public async Task<dynamic> SaveWalletsAsync(IEnumerable<dynamic> wallet, CancellationToken token)
        {
            var dbSettings = new DataDbConfigSettings<IEnumerable<dynamic>>
            {
                PlainQuery = "SP_SAVE_MOBILE_BUDGET_WALLET", // Stored procedure for inserting wallet
                Request = wallet
            };

            return await _dataDbConfigurationService.BulkInsertAsyncAsync<dynamic, dynamic>(dbSettings, "AppWalletTableMobileBudget");
        }

       
        public async Task<dynamic> SaveBudgetsAsync(IEnumerable<dynamic> budget, CancellationToken token)
        {
            var dbSettings = new DataDbConfigSettings<IEnumerable<dynamic>>
            {
                PlainQuery = "SP_SAVE_MOBILE_BUDGET_BUDGET", // Stored procedure for inserting wallet
                Request = budget
            };

            return await _dataDbConfigurationService.BulkInsertAsyncAsync<dynamic, dynamic>(dbSettings, "AppBudgetTableMobileBudget");
        }

        
        public async Task<dynamic> SaveObjectivesAsync(IEnumerable<dynamic> objective, CancellationToken token)
        {
            var dbSettings = new DataDbConfigSettings<IEnumerable<dynamic>>
            {
                PlainQuery = "SP_SAVE_MOBILE_BUDGET_OBJECTIVE", // Stored procedure for inserting objective
                Request = objective
            };

            return await _dataDbConfigurationService.BulkInsertAsyncAsync<dynamic, dynamic>(dbSettings, "AppObjectiveTableMobileBudget");
        }

        
        public async Task<dynamic> SaveTransactionsAsync(IEnumerable<dynamic> transaction, CancellationToken token)
        {
            var dbSettings = new DataDbConfigSettings<IEnumerable<dynamic>>
            {
                PlainQuery = "SP_SAVE_MOBILE_BUDGET_TRANSACTION", // Stored procedure for inserting objective
                Request = transaction
            };

            return await _dataDbConfigurationService.BulkInsertAsyncAsync<dynamic, dynamic>(dbSettings, "AppTransactionTableMobileBudget");
        }

       
        public async Task<dynamic> SaveCategoryBudgetLimitsAsync(IEnumerable<dynamic> categoryBudgetLimit, CancellationToken token)
        {
            var dbSettings = new DataDbConfigSettings<IEnumerable<dynamic>>
            {
                PlainQuery = "SP_SAVE_MOBILE_BUDGET_CATEGORY_BUDGET_LIMIT", // Stored procedure for inserting budgetLimit
                Request = categoryBudgetLimit
            };

            return await _dataDbConfigurationService.BulkInsertAsyncAsync<dynamic, dynamic>(dbSettings, "AppCategoryBudgetLimitTableMobileBudget");
        }

       
        public async Task<dynamic> SaveDeleteLogsAsync(IEnumerable<dynamic> logs, CancellationToken token)
        {
            var dbSettings = new DataDbConfigSettings<IEnumerable<dynamic>>
            {
                PlainQuery = "SP_SAVE_MOBILE_BUDGET_DELETE_LOGS", // Stored procedure for inserting logs
                Request = logs
            };

            return await _dataDbConfigurationService.BulkInsertAsyncAsync<dynamic, dynamic>(dbSettings, "AppDeleteLogsTableMobileBudget");
        }

       
        public async Task<dynamic> SaveScannerTemplatesAsync(IEnumerable<dynamic> scannerTemplate, CancellationToken token)
        {
            var dbSettings = new DataDbConfigSettings<IEnumerable<dynamic>>
            {
                PlainQuery = "SP_SAVE_MOBILE_BUDGET_SCANNER_TEMPLATE", // Stored procedure for inserting scannerTemplate
                Request = scannerTemplate
            };

            return await _dataDbConfigurationService.BulkInsertAsyncAsync<dynamic, dynamic>(dbSettings, "AppScannerTemplateTableMobileBudget");
        }

        public async Task<dynamic> SaveMobileDataBackupAsync(dynamic mobileDataBackup, CancellationToken token)
        {
            var dbSettings = new DataDbConfigSettings<dynamic>
            {
                PlainQuery = "SP_INSERT_MOBILE_DATA_BACKUP", // Stored procedure for inserting mobileDataBackup
                Request = mobileDataBackup
            };

            return await _dataDbConfigurationService.AddDataIdentityAsync<dynamic, Guid>(dbSettings);
        }

        public async Task<UserReply> VerifyUserAsync(VerifyAuthDetails verifyAuthDetails, CancellationToken token)
        {
            var dbSettings = new DataDbConfigSettings<object>
            {
                PlainQuery = "SP_AUTH_USER", // Stored procedure for fetching Cams settings by emailid
                Request = new { Pan = verifyAuthDetails.Pan, EmailId = verifyAuthDetails.EmailId }
            };

            return await _dataDbConfigurationService.GetDataAsync<object, UserReply>(dbSettings);
            
        }

        public async Task<MobileDataBackup> GetMobileDataBackupAsync(string Pan, string EmailId, CancellationToken token)
        {
            var dbSettings = new DataDbConfigSettings<object>
            {
                PlainQuery = "SP_GET_LATEST_MOBILE_DATA_BACKUP", // Stored procedure for fetching Cams settings by emailid
                Request = new { Pan = Pan }
            };

            return await _dataDbConfigurationService.GetDataAsync<object, MobileDataBackup>(dbSettings);

        }
    }
}
