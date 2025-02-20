
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

                    requests.Add(expando);
                }

                await _budgetTranscation.SaveAssociatedTitlesAsync(requests, cancellationToken);
            }


            return true;
        }

        public async Task<bool> WalletsSaveAsync(WalletData walletData, string Pan, string EmailId, CancellationToken cancellationToken)
        {
            var requests = new List<dynamic>();
            if(walletData.RecordCount > 0)
            {
                foreach (var wallet in walletData.Records)
                {
                    dynamic expando = new ExpandoObject();
                    expando.wallet_pk = wallet.WalletPk;
                    expando.name = wallet.Name;
                    expando.colour = wallet.Colour;
                    expando.icon_name = wallet.IconName;
                    expando.date_created = wallet.DateCreated;
                    expando.date_time_modified = wallet.DateTimeModified;
                    expando.order = wallet.Order;
                    expando.currency = wallet.Currency;
                    expando.currency_format = wallet.CurrencyFormat;
                    expando.decimals = wallet.Decimals;
                    expando.home_page_widget_display = wallet.HomePageWidgetDisplay;
                    expando.pan = Pan;
                    expando.email = EmailId;

                    requests.Add(expando);
                }

                await _budgetTranscation.SaveWalletsAsync(requests, cancellationToken);
            }

            return true;
        }

        public async Task<bool> BudgetsSaveAsync(BudgetData budgetData, string Pan, string EmailId, CancellationToken cancellationToken)
        {
            var requests = new List<dynamic>();
            if (budgetData.RecordCount > 0)
            {
                foreach (var budget in budgetData.Records)
                {
                    dynamic expando = new ExpandoObject();
                    expando.budget_pk = budget.BudgetPk;
                    expando.name = budget.Name;
                    expando.amount = budget.Amount;
                    expando.colour = budget.Colour;
                    expando.start_date = budget.StartDate;
                    expando.end_date = budget.EndDate;
                    expando.wallet_fk = budget.WalletFk;
                    expando.category_fk = budget.CategoryFks;
                    expando.category_fks_exclude = budget.CategoryFksExclude;
                    expando.income = budget.Income;
                    expando.archived = budget.Archived;
                    expando.added_transactions_only = budget.AddedTransactionsOnly;
                    expando.period_length = budget.PeriodLength;
                    expando.reoccurrence = budget.Reoccurrence;
                    expando.date_created = budget.DateCreated;
                    expando.date_time_modified = budget.DateTimeModified;
                    expando.pinned = budget.Pinned;
                    expando.order = budget.Order;   
                    expando.wallet_fk = budget.WalletFk;
                    expando.budget_transaction_filters = budget.BudgetTransactionFilters;
                    expando.member_transaction_filters = budget.MemberTransactionFilters;
                    expando.shared_key = budget.SharedKey;
                    expando.shared_owner_member = budget.SharedOwnerMember;
                    expando.shared_date_updated = budget.SharedDateUpdated;
                    expando.shared_members = budget.SharedMembers;
                    expando.shared_all_members_ever = budget.SharedAllMembersEver;
                    expando.is_absolute_spending_limit = budget.IsAbsoluteSpendingLimit;
                    expando.pan = Pan;
                    expando.email = EmailId;

                    requests.Add(expando);
                }

                await _budgetTranscation.SaveBudgetsAsync(requests, cancellationToken);
            }
            return true;
        }

        public async Task<bool> ObjectivesSaveAsync(ObjectiveData objectiveData, string Pan, string EmailId, CancellationToken cancellationToken)
        {
            var requests = new List<dynamic>();
            if (objectiveData.RecordCount > 0)
            {
                foreach (var objective in objectiveData.Records)
                {
                    dynamic expando = new ExpandoObject();
                    expando.objective_pk = objective.ObjectivePk;
                    expando.type = objective.Type;
                    expando.name = objective.Name;
                    expando.amount = objective.Amount;
                    expando.order = objective.Order;
                    expando.colour = objective.Colour;
                    expando.date_created = objective.DateCreated;
                    expando.end_date = objective.EndDate;
                    expando.date_time_modified = objective.DateTimeModified;
                    expando.icon_name = objective.IconName;
                    expando.emoji_icon_name = objective.EmojiIconName;
                    expando.income = objective.Income;
                    expando.pinned = objective.Pinned;
                    expando.archived = objective.Archived;
                    expando.wallet_fk = objective.WalletFk;
                    expando.pan = Pan;
                    expando.email = EmailId;

                    requests.Add(expando);
                }

                await _budgetTranscation.SaveObjectivesAsync(requests, cancellationToken);
            }
            return true;
        }

        public async Task<bool> TransactionsSaveAsync(TransactionData transactionData, string Pan, string EmailId, CancellationToken cancellationToken)
        {
            var requests = new List<dynamic>();
            if(transactionData.RecordCount > 0)
            {
                foreach (var transaction in transactionData.Records)
                {
                    dynamic expando = new ExpandoObject();
                    expando.transaction_pk = transaction.TransactionPk;
                    expando.paired_transaction_fk = transaction.PairedTransactionFk;
                    expando.name= transaction.Name;
                    expando.amount = transaction.Amount;
                    expando.note = transaction.Note;
                    expando.category_fk = transaction.CategoryFk;
                    expando.sub_category_fk = transaction.SubCategoryFk;
                    expando.wallet_fk = transaction.WalletFk;
                    expando.date_created = transaction.DateCreated;
                    expando.date_time_modified = transaction.DateTimeModified;
                    expando.original_date_due = transaction.OriginalDateDue;
                    expando.income = transaction.Income;
                    expando.period_length = transaction.PeriodLength;
                    expando.reoccurrence = transaction.Reoccurrence;
                    expando.end_date = transaction.EndDate;
                    expando.upcoming_transaction_notification = transaction.UpcomingTransactionNotification;
                    expando.type = transaction.Type;
                    expando.paid = transaction.Paid;
                    expando.created_another_future_transaction = transaction.CreatedAnotherFutureTransaction;
                    expando.skip_paid = transaction.SkipPaid;
                    expando.method_added = transaction.MethodAdded;
                    expando.transaction_owner_email = transaction.TransactionOwnerEmail;
                    expando.transaction_original_owner_email = transaction.TransactionOriginalOwnerEmail;
                    expando.shared_key = transaction.SharedKey;
                    expando.shared_old_key = transaction.SharedOldKey;
                    expando.shared_status = transaction.SharedStatus;
                    expando.shared_date_updated = transaction.SharedDateUpdated;
                    expando.shared_reference_budget_pk = transaction.SharedReferenceBudgetPk;
                    expando.objective_fk = transaction.ObjectiveFk;
                    expando.objective_loan_fk = transaction.ObjectiveLoanFk;
                    expando.budget_fks_exclude = transaction.BudgetFksExclude;
                    expando.pan = Pan;
                    expando.email = EmailId;

                    requests.Add(expando);
                }

                await _budgetTranscation.SaveTransactionsAsync(requests, cancellationToken);
            }

            return true;
        }
    }
}
