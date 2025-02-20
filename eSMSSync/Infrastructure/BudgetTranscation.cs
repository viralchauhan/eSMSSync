
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

        //Pending SP
        public async Task<dynamic> SaveAssociatedTitlesAsync(IEnumerable<dynamic> associatedTitle, CancellationToken token)
        {
            var dbSettings = new DataDbConfigSettings<IEnumerable<dynamic>>
            {
                PlainQuery = "SP_SAVE_MOBILE_BUDGET_ASSOCIATED_TITLE", // Stored procedure for inserting associatedTitle
                Request = associatedTitle
            };

            return await _dataDbConfigurationService.BulkInsertAsyncAsync<dynamic, dynamic>(dbSettings, "AppAssociatedTitleTableMobileBudget");
        }

        //Pending SP
        public async Task<dynamic> SaveWalletsAsync(IEnumerable<dynamic> wallet, CancellationToken token)
        {
            var dbSettings = new DataDbConfigSettings<IEnumerable<dynamic>>
            {
                PlainQuery = "SP_SAVE_MOBILE_BUDGET_WALLET", // Stored procedure for inserting wallet
                Request = wallet
            };

            return await _dataDbConfigurationService.BulkInsertAsyncAsync<dynamic, dynamic>(dbSettings, "AppWalletTableMobileBudget");
        }

        //Pending SP
        public async Task<dynamic> SaveBudgetsAsync(IEnumerable<dynamic> budget, CancellationToken token)
        {
            var dbSettings = new DataDbConfigSettings<IEnumerable<dynamic>>
            {
                PlainQuery = "SP_SAVE_MOBILE_BUDGET_BUDGET", // Stored procedure for inserting wallet
                Request = budget
            };

            return await _dataDbConfigurationService.BulkInsertAsyncAsync<dynamic, dynamic>(dbSettings, "AppBudgetTableMobileBudget");
        }

        //Pending SP
        public async Task<dynamic> SaveObjectivesAsync(IEnumerable<dynamic> objective, CancellationToken token)
        {
            var dbSettings = new DataDbConfigSettings<IEnumerable<dynamic>>
            {
                PlainQuery = "SP_SAVE_MOBILE_BUDGET_OBJECTIVE", // Stored procedure for inserting objective
                Request = objective
            };

            return await _dataDbConfigurationService.BulkInsertAsyncAsync<dynamic, dynamic>(dbSettings, "AppObjectiveTableMobileBudget");
        }

        //Pending SP
        public async Task<dynamic> SaveTransactionsAsync(IEnumerable<dynamic> transaction, CancellationToken token)
        {
            var dbSettings = new DataDbConfigSettings<IEnumerable<dynamic>>
            {
                PlainQuery = "SP_SAVE_MOBILE_BUDGET_TRANSACTION", // Stored procedure for inserting objective
                Request = transaction
            };

            return await _dataDbConfigurationService.BulkInsertAsyncAsync<dynamic, dynamic>(dbSettings, "AppTransactionTableMobileBudget");
        }


    }
}
