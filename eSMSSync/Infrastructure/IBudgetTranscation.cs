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
    }
}
