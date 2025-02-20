namespace eSMSSync.Models
{
    using System;
    using System.Collections.Generic;
    using System.Security.AccessControl;
    using Newtonsoft.Json;

    public partial class Rules
    {
        [JsonProperty("message")]
        public string? Message { get; set; }

        [JsonProperty("deviceId")]
        public string? DeviceId { get; set; }

        [JsonProperty("fileName")]
        public string? FileName { get; set; }

        [JsonProperty("data")]
        public Data? Data { get; set; }
    }

    public partial class Data
    {
        [JsonProperty("wallets")]
        public WalletData? Wallets { get; set; }

        [JsonProperty("categories")]
        public CategoryData? Categories { get; set; }

        [JsonProperty("objectives")]
        public ObjectiveData? Objectives { get; set; }

        [JsonProperty("transactions")]
        public TransactionData? Transactions { get; set; }

        [JsonProperty("budgets")]
        public BudgetData? Budgets { get; set; }

        [JsonProperty("category_budget_limits")]
        public CategoryBudgetLimitData? CategoryBudgetLimits { get; set; }

        [JsonProperty("associated_titles")]
        public AssociatedTitleData? AssociatedTitles { get; set; }

        [JsonProperty("app_settings")]
        public AppSettingData? AppSettings { get; set; }

        [JsonProperty("scanner_templates")]
        public ScannerTemplateData? ScannerTemplates { get; set; }

        [JsonProperty("delete_logs")]
        public DeleteLogData? DeleteLogs { get; set; }
    }

    public class BaseData<T>
    {
        [JsonProperty("RecordCount")]
        public long? RecordCount { get; set; }

        [JsonProperty("Records")]
        public List<T> Records { get; set; }
    }

    public class WalletData : BaseData<Wallet> { }
    public class CategoryData : BaseData<Category> { }
    public class ObjectiveData : BaseData<Objective> { }
    public class TransactionData : BaseData<Transaction> { }
    public class BudgetData : BaseData<Budget> { }
    public class CategoryBudgetLimitData : BaseData<CategoryBudgetLimit> { }
    public class AssociatedTitleData : BaseData<AssociatedTitle> { }
    public class AppSettingData : BaseData<AppSetting> { }
    public class ScannerTemplateData : BaseData<ScannerTemplate> { }
    public class DeleteLogData : BaseData<DeleteLog> { }

    public class Wallet
    {
        [JsonProperty("wallet_pk")]
        public string WalletPk { get; set; }

        [JsonProperty("name")]
        public string? Name { get; set; }

        [JsonProperty("colour")]
        public string? Colour { get; set; }

        [JsonProperty("icon_name")]
        public string? IconName { get; set; }

        [JsonProperty("date_created")]
        public long DateCreated { get; set; }

        [JsonProperty("date_time_modified")]
        public long DateTimeModified { get; set; }

        [JsonProperty("order")]
        public int Order { get; set; }

        [JsonProperty("currency")]
        public string? Currency { get; set; }

        [JsonProperty("currency_format")]
        public string? CurrencyFormat { get; set; }

        [JsonProperty("decimals")]
        public int Decimals { get; set; }

        [JsonProperty("home_page_widget_display")]
        public string? HomePageWidgetDisplay { get; set; }
    }

    public class Category
    {
        [JsonProperty("category_pk")]
        public string CategoryPk { get; set; }

        [JsonProperty("name")]
        public string? Name { get; set; }

        [JsonProperty("colour")]
        public string? Colour { get; set; }

        [JsonProperty("icon_name")]
        public string? IconName { get; set; }

        [JsonProperty("emoji_icon_name")]
        public string? EmojiIconName { get; set; }

        [JsonProperty("date_created")]
        public long? DateCreated { get; set; }

        [JsonProperty("date_time_modified")]
        public long? DateTimeModified { get; set; }

        [JsonProperty("order")]
        public int? Order { get; set; }

        [JsonProperty("income")]
        public bool? Income { get; set; }

        [JsonProperty("method_added")]
        public int? MethodAdded { get; set; }

        [JsonProperty("main_category_pk")]
        public string? MainCategoryPk { get; set; }
    }

    public class Transaction
    {
        [JsonProperty("transaction_pk")]
        public string TransactionPk { get; set; }

        [JsonProperty("paired_transaction_fk")]
        public string? PairedTransactionFk { get; set; }

        [JsonProperty("name")]
        public string? Name { get; set; }

        [JsonProperty("amount")]
        public decimal? Amount { get; set; }

        [JsonProperty("note")]
        public string? Note { get; set; }

        [JsonProperty("category_fk")]
        public string? CategoryFk { get; set; }

        [JsonProperty("sub_category_fk")]
        public string? SubCategoryFk { get; set; }

        [JsonProperty("wallet_fk")]
        public string? WalletFk { get; set; }

        [JsonProperty("date_created")]
        public long? DateCreated { get; set; }

        [JsonProperty("date_time_modified")]
        public long? DateTimeModified { get; set; }

        [JsonProperty("original_date_due")]
        public long? OriginalDateDue { get; set; }

        [JsonProperty("income")]
        public int? Income { get; set; }

        [JsonProperty("period_length")]
        public int? PeriodLength { get; set; }

        [JsonProperty("reoccurrence")]
        public int? Reoccurrence { get; set; }

        [JsonProperty("end_date")]
        public long? EndDate { get; set; }

        [JsonProperty("upcoming_transaction_notification")]
        public int? UpcomingTransactionNotification { get; set; }

        [JsonProperty("type")]
        public int? Type { get; set; }

        [JsonProperty("paid")]
        public int? Paid { get; set; }

        [JsonProperty("created_another_future_transaction")]
        public int? CreatedAnotherFutureTransaction { get; set; }


        [JsonProperty("skip_paid")]
        public int? SkipPaid { get; set; }

        [JsonProperty("method_added")]
        public int? MethodAdded { get; set; }

        [JsonProperty("transaction_owner_email")]
        public string? TransactionOwnerEmail { get; set; }

        [JsonProperty("transaction_original_owner_email")]
        public string? TransactionOriginalOwnerEmail { get; set; }

        [JsonProperty("shared_key")]
        public string? SharedKey { get; set; }

        [JsonProperty("shared_old_key")]
        public string? SharedOldKey { get; set; }

        [JsonProperty("shared_status")]
        public int? SharedStatus { get; set; }

        [JsonProperty("shared_date_updated")]
        public long? SharedDateUpdated { get; set; }

        [JsonProperty("shared_reference_budget_pk")]
        public string? SharedReferenceBudgetPk { get; set; }

        [JsonProperty("objective_fk")]
        public string? ObjectiveFk { get; set; }

        [JsonProperty("objective_loan_fk")]
        public string? ObjectiveLoanFk { get; set; }

        [JsonProperty("budget_fks_exclude")]
        public string? BudgetFksExclude { get; set; }
    }

    public class AppSetting
    {
        [JsonProperty("settings_pk")]
        public int SettingsPk { get; set; }

        [JsonProperty("settings_j_s_o_n")]
        public string? SettingsJson { get; set; }

        [JsonProperty("date_updated")]
        public long? DateUpdated { get; set; }
    }


    public class Objective
    {
        [JsonProperty("objective_pk")]
        public string ObjectivePk { get; set; }

        [JsonProperty("type")]
        public int Type { get; set; }

        [JsonProperty("name")]
        public string? Name { get; set; }

        [JsonProperty("amount")]
        public decimal? Amount { get; set; }

        [JsonProperty("order")]
        public int? Order { get; set; }

        [JsonProperty("colour")]
        public string? Colour { get; set; }

        [JsonProperty("date_created")]
        public long DateCreated { get; set; }

        [JsonProperty("end_date")]
        public long? EndDate { get; set; }

        [JsonProperty("date_time_modified")]
        public long DateTimeModified { get; set; }

        [JsonProperty("icon_name")]
        public string? IconName { get; set; }

        [JsonProperty("emoji_icon_name")]
        public string? EmojiIconName { get; set; }

        [JsonProperty("income")]
        public bool Income { get; set; }

        [JsonProperty("pinned")]
        public bool Pinned { get; set; }

        [JsonProperty("archived")]
        public bool Archived { get; set; }

        [JsonProperty("wallet_fk")]
        public string? WalletFk { get; set; }
    }

    public class Budget
    {
        [JsonProperty("budget_pk")]
        public string BudgetPk { get; set; }

        [JsonProperty("name")]
        public string? Name { get; set; }

        [JsonProperty("amount")]
        public decimal Amount { get; set; }

        [JsonProperty("colour")]
        public string? Colour { get; set; }

        [JsonProperty("start_date")]
        public long StartDate { get; set; }

        [JsonProperty("end_date")]
        public long EndDate { get; set; }

        [JsonProperty("wallet_fks")]
        public string? WalletFks { get; set; }

        [JsonProperty("category_fks")]
        public string? CategoryFks { get; set; }

        [JsonProperty("category_fks_exclude")]
        public string? CategoryFksExclude { get; set; }

        [JsonProperty("income")]
        public bool Income { get; set; }

        [JsonProperty("archived")]
        public bool Archived { get; set; }

        [JsonProperty("added_transactions_only")]
        public bool AddedTransactionsOnly { get; set; }

        [JsonProperty("period_length")]
        public int PeriodLength { get; set; }

        [JsonProperty("reoccurrence")]
        public int? Reoccurrence { get; set; }

        [JsonProperty("date_created")]
        public long DateCreated { get; set; }

        [JsonProperty("date_time_modified")]
        public long DateTimeModified { get; set; }

        [JsonProperty("pinned")]
        public bool Pinned { get; set; }

        [JsonProperty("order")]
        public int Order { get; set; }

        [JsonProperty("wallet_fk")]
        public string? WalletFk { get; set; }

        [JsonProperty("budget_transaction_filters")]
        public string? BudgetTransactionFilters { get; set; }

        [JsonProperty("member_transaction_filters")]
        public string? MemberTransactionFilters { get; set; }

        [JsonProperty("shared_key")]
        public string? SharedKey { get; set; }

        [JsonProperty("shared_owner_member")]
        public int? SharedOwnerMember { get; set; }

        [JsonProperty("shared_date_updated")]
        public long? SharedDateUpdated { get; set; }

        [JsonProperty("shared_members")]
        public string? SharedMembers { get; set; }

        [JsonProperty("shared_all_members_ever")]
        public string? SharedAllMembersEver { get; set; }

        [JsonProperty("is_absolute_spending_limit")]
        public bool IsAbsoluteSpendingLimit { get; set; }
    }

    public class CategoryBudgetLimit
    {
        [JsonProperty("category_limit_pk")]
        public string CategoryLimitPk { get; set; }

        [JsonProperty("category_fk")]
        public string? CategoryFk { get; set; }

        [JsonProperty("budget_fk")]
        public string BudgetFk { get; set; }

        [JsonProperty("amount")]
        public decimal Amount { get; set; }

        [JsonProperty("date_time_modified")]
        public long DateTimeModified { get; set; }

        [JsonProperty("wallet_fk")]
        public string? WalletFk { get; set; }
    }

    public class AssociatedTitle
    {
        [JsonProperty("associated_title_pk")]
        public string AssociatedTitlePk { get; set; }

        [JsonProperty("category_fk")]
        public string CategoryFk { get; set; }

        [JsonProperty("title")]
        public string? Title { get; set; }

        [JsonProperty("date_created")]
        public long DateCreated { get; set; }

        [JsonProperty("date_time_modified")]
        public long DateTimeModified { get; set; }

        [JsonProperty("order")]
        public int Order { get; set; }

        [JsonProperty("is_exact_match")]
        public bool IsExactMatch { get; set; }
    }

    public class ScannerTemplate
    {
        [JsonProperty("scanner_template_pk")]
        public string ScannerTemplatePk { get; set; }

        [JsonProperty("date_created")]
        public long DateCreated { get; set; }

        [JsonProperty("date_time_modified")]
        public long DateTimeModified { get; set; }

        [JsonProperty("template_name")]
        public string? TemplateName { get; set; }

        [JsonProperty("contains")]
        public string Contains { get; set; }

        [JsonProperty("title_transaction_before")]
        public string? TitleTransactionBefore { get; set; }

        [JsonProperty("title_transaction_after")]
        public string? TitleTransactionAfter { get; set; }

        [JsonProperty("amount_transaction_before")]
        public string? AmountTransactionBefore { get; set; }

        [JsonProperty("amount_transaction_after")]
        public string? AmountTransactionAfter { get; set; }

        [JsonProperty("default_category_fk")]
        public string? DefaultCategoryFk { get; set; }

        [JsonProperty("wallet_fk")]
        public string? WalletFk { get; set; }

        [JsonProperty("ignore")]
        public bool Ignore { get; set; }
    }

    public class DeleteLog
    {
        [JsonProperty("delete_log_pk")]
        public string DeleteLogPk { get; set; }

        [JsonProperty("entry_pk")]
        public string? EntryPk { get; set; }

        [JsonProperty("type")]
        public int Type { get; set; }

        [JsonProperty("date_time_modified")]
        public long DateTimeModified { get; set; }
    }
}
