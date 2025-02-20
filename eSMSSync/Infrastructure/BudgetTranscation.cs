
using BuildingBlocks.Common.DBHelper.Interface;
using BuildingBlocks.Common.DBHelper.Model;

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
                PlainQuery = "SP_SAVE_MOBILE_BUDGET_ASSOCIATED_TITLE", // Stored procedure for inserting investment type
                Request = associatedTitle
            };

            return await _dataDbConfigurationService.BulkInsertAsyncAsync<dynamic, dynamic>(dbSettings, "AppAssociatedTitleTableMobileBudget");
        }



    }
}
