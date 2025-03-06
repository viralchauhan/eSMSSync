using eSMSSync.Models;

namespace eSMSSync.Infrastructure
{
    public interface IBudgetTranscation
    {
        Task<dynamic> SaveAppSettingsAsync(IEnumerable<dynamic> appsettings, CancellationToken token);

        Task<dynamic> SaveCategoriesAsync(IEnumerable<dynamic> appsettings, CancellationToken token);

        Task<dynamic> SaveAssociatedTitlesAsync(IEnumerable<dynamic> associatedTitle, CancellationToken token);

        Task<dynamic> SaveWalletsAsync(IEnumerable<dynamic> wallet, CancellationToken token);

        Task<dynamic> SaveBudgetsAsync(IEnumerable<dynamic> budget, CancellationToken token);

        Task<dynamic> SaveObjectivesAsync(IEnumerable<dynamic> objective, CancellationToken token);

        Task<dynamic> SaveTransactionsAsync(IEnumerable<dynamic> transaction, CancellationToken token);

        Task<dynamic> SaveCategoryBudgetLimitsAsync(IEnumerable<dynamic> categoryBudgetLimit, CancellationToken token);

        Task<dynamic> SaveDeleteLogsAsync(IEnumerable<dynamic> deleteLog, CancellationToken token);

        Task<dynamic> SaveScannerTemplatesAsync(IEnumerable<dynamic> scannerTemplate, CancellationToken token);

        Task<dynamic> SaveMobileDataBackupAsync(dynamic mobileDataBackup, CancellationToken token);

        Task<UserReply> VerifyUserAsync(VerifyAuthDetails verifyAuthDetails, CancellationToken token);

        Task<MobileDataBackup> GetMobileDataBackupAsync(string Pan, string EmailId, CancellationToken token);
    }
}
