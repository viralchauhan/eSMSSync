using eSMSSync.Models;

namespace eSMSSync.Service
{
    public interface IBudgetService
    {
        Task<bool> AppSettingsSaveAsync(AppSettingData appSettingData, string Pan, string EmailId, CancellationToken cancellationToken);

        Task<bool> CategoriesSaveAsync(CategoryData categoryData,CancellationToken cancellationToken);

        Task<bool> AssociatedTitlesSaveAsync(AssociatedTitleData associatedTitleData, string Pan, string EmailId, CancellationToken cancellationToken);
    }
}
