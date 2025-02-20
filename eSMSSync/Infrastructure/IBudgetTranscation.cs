namespace eSMSSync.Infrastructure
{
    public interface IBudgetTranscation
    {
        Task<dynamic> SaveAppSettingsAsync(IEnumerable<dynamic> appsettings, CancellationToken token);

        Task<dynamic> SaveCategoriesAsync(IEnumerable<dynamic> appsettings, CancellationToken token);

        Task<dynamic> SaveAssociatedTitlesAsync(IEnumerable<dynamic> associatedTitle, CancellationToken token);
    }
}
