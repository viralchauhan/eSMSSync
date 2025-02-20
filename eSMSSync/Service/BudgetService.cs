
using eSMSSync.Infrastructure;
using eSMSSync.Models;
using System.Dynamic;

namespace eSMSSync.Service
{
    public class BudgetService(IBudgetTranscation budgetTranscation) : IBudgetService
    {

        private readonly IBudgetTranscation _budgetTranscation = budgetTranscation;

        public async Task<bool> AppSettingsSaveAsync(AppSettingData appSettingData, string Pan, string EmailId, CancellationToken cancellationToken)
        {
            var requests = new List<dynamic>();
            dynamic expando = new ExpandoObject();
            if (appSettingData.RecordCount > 0)
            {
                foreach (var appsettings in appSettingData.Records)
                {
                    expando.settings_pk = appsettings.SettingsPk;
                    expando.settings_json = appsettings.SettingsJson;
                    expando.date_updated = appsettings.DateUpdated;
                    expando.pan = Pan;
                    expando.email = EmailId;

                    requests.Add(expando);
                }

                await _budgetTranscation.SaveAppSettingsAsync(requests, cancellationToken);
            }
            return true;
        }

        public async Task<bool> CategoriesSaveAsync(CategoryData categoryData, CancellationToken cancellationToken)
        {
            var requests = new List<dynamic>();
            

            if (categoryData.RecordCount > 0)
            {
                foreach (var category in categoryData.Records)
                {
                    dynamic expando = new ExpandoObject();

                    expando.category_pk = category.CategoryPk;
                    expando.name = category.Name;
                    expando.colour = category.Colour;
                    expando.icon_name = category.IconName;
                    expando.emoji_icon_name = category.EmojiIconName ?? "";
                    expando.date_created = category.DateCreated;
                    expando.date_time_modified = category.DateTimeModified;
                    expando.order = category.Order;
                    expando.income = category.Income;
                    expando.method_added = category.MethodAdded ?? 0;
                    expando.main_category_pk = category.MainCategoryPk ?? "";

                    requests.Add(expando);
                }

                await _budgetTranscation.SaveCategoriesAsync(requests, cancellationToken);
            }

            return true;
        }

        public async Task<bool> AssociatedTitlesSaveAsync(AssociatedTitleData associatedTitleData, string Pan, string EmailId, CancellationToken cancellationToken)
        {
            var requests = new List<dynamic>();
            if(associatedTitleData.RecordCount > 0)
            {
                foreach (var associatedTitle in associatedTitleData.Records)
                {
                    dynamic expando = new ExpandoObject();
                    expando.associated_title_pk = associatedTitle.AssociatedTitlePk;
                    expando.category_fk = associatedTitle.CategoryFk;
                    expando.title = associatedTitle.Title;
                    expando.date_created = associatedTitle.DateCreated;
                    expando.date_time_modified = associatedTitle.DateTimeModified;
                    expando.order = associatedTitle.Order;
                    expando.is_exact_match = associatedTitle.IsExactMatch;
                    expando.pan = Pan;
                    expando.email = EmailId;
                }

                await _budgetTranscation.SaveAssociatedTitlesAsync(requests, cancellationToken);
            }


            return true;
        }
    }
}
