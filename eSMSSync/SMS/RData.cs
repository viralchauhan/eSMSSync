namespace QuickType
{
    using System;
    using System.Collections.Generic;

    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    public partial class RData
    {
        [JsonProperty("blacklist_regex")]
        public string BlacklistRegex { get; set; }

        [JsonProperty("min_app_version")]
        [JsonConverter(typeof(ParseStringConverter))]
        public long MinAppVersion { get; set; }

        [JsonProperty("rules")]
        public RuleRule[] Rules { get; set; }

        [JsonProperty("version")]
        [JsonConverter(typeof(ParseStringConverter))]
        public long Version { get; set; }
    }

    public partial class RuleRule
    {
        [JsonProperty("full_name")]
        public string FullName { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("patterns")]
        public Pattern[] Patterns { get; set; }

        [JsonProperty("sender_UID")]
        [JsonConverter(typeof(ParseStringConverter))]
        public long SenderUid { get; set; }

        [JsonProperty("senders")]
        public string[] Senders { get; set; }

        [JsonProperty("set_account_as_expense", NullValueHandling = NullValueHandling.Ignore)]
        public bool? SetAccountAsExpense { get; set; }

        [JsonProperty("misc_information", NullValueHandling = NullValueHandling.Ignore)]
        public MiscInformation MiscInformation { get; set; }

        [JsonProperty("sender_regexes", NullValueHandling = NullValueHandling.Ignore)]
        public string[] SenderRegexes { get; set; }
    }

    public partial class MiscInformation
    {
        [JsonProperty("get_balance")]
        public GetBalance[] GetBalance { get; set; }
    }

    public partial class GetBalance
    {
        [JsonProperty("account_type")]
        [JsonConverter(typeof(AccConverter))]
        public Acc AccountType { get; set; }

        [JsonProperty("contact_info")]
        public ContactInfo[] ContactInfo { get; set; }
    }

    public partial class ContactInfo
    {
        [JsonProperty("type")]
        public TypeEnum Type { get; set; }

        [JsonProperty("numbers")]
        public string[] Numbers { get; set; }

        [JsonProperty("format", NullValueHandling = NullValueHandling.Ignore)]
        public string Format { get; set; }
    }

    public partial class Pattern
    {
        [JsonProperty("regex")]
        public string Regex { get; set; }

        [JsonProperty("account_type")]
        [JsonConverter(typeof(AccConverter))]
        public Acc AccountType { get; set; }

        [JsonProperty("pattern_UID")]
        [JsonConverter(typeof(ParseStringConverter))]
        public long PatternUid { get; set; }

        [JsonProperty("sort_UID")]
        [JsonConverter(typeof(ParseStringConverter))]
        public long SortUid { get; set; }

        [JsonProperty("sms_type")]
        public SmsType SmsType { get; set; }

        [JsonProperty("data_fields", NullValueHandling = NullValueHandling.Ignore)]
        public DataFields DataFields { get; set; }

        [JsonProperty("obsolete", NullValueHandling = NullValueHandling.Ignore)]
        public bool? Obsolete { get; set; }

        [JsonProperty("reparse", NullValueHandling = NullValueHandling.Ignore)]
        public bool? Reparse { get; set; }

        [JsonProperty("account_name_override", NullValueHandling = NullValueHandling.Ignore)]
        public string AccountNameOverride { get; set; }

        [JsonProperty("set_account_as_expense", NullValueHandling = NullValueHandling.Ignore)]
        public bool? SetAccountAsExpense { get; set; }
    }

    public partial class DataFields
    {
        [JsonProperty("statement_type", NullValueHandling = NullValueHandling.Ignore)]
        [JsonConverter(typeof(StatementTypeConverter))]
        public StatementType? StatementType { get; set; }

        [JsonProperty("pan", NullValueHandling = NullValueHandling.Ignore)]
        public EventInfo Pan { get; set; }

        [JsonProperty("amount", NullValueHandling = NullValueHandling.Ignore)]
        public Amount Amount { get; set; }

        [JsonProperty("date", NullValueHandling = NullValueHandling.Ignore)]
        public Date Date { get; set; }

        [JsonProperty("create_txn", NullValueHandling = NullValueHandling.Ignore)]
        public CreateTxn CreateTxn { get; set; }

        [JsonProperty("enable_chaining", NullValueHandling = NullValueHandling.Ignore)]
        public bool? EnableChaining { get; set; }

        [JsonProperty("chaining_rule", NullValueHandling = NullValueHandling.Ignore)]
        public ChainingRule ChainingRule { get; set; }

        [JsonProperty("transaction_type_rule", NullValueHandling = NullValueHandling.Ignore)]
        public TransactionTypeRule TransactionTypeRule { get; set; }

        [JsonProperty("pos", NullValueHandling = NullValueHandling.Ignore)]
        public Pos Pos { get; set; }

        [JsonProperty("account_balance", NullValueHandling = NullValueHandling.Ignore)]
        public AccountBalance AccountBalance { get; set; }

        [JsonProperty("transaction_type", NullValueHandling = NullValueHandling.Ignore)]
        [JsonConverter(typeof(NTypeConverter))]
        public NType? TransactionType { get; set; }

        [JsonProperty("note", NullValueHandling = NullValueHandling.Ignore)]
        public Contact Note { get; set; }

        [JsonProperty("network_reference_id", NullValueHandling = NullValueHandling.Ignore)]
        public NetworkReferenceId NetworkReferenceId { get; set; }

        [JsonProperty("transaction_category", NullValueHandling = NullValueHandling.Ignore)]
        [JsonConverter(typeof(CategoryConverter))]
        public Category? TransactionCategory { get; set; }

        [JsonProperty("currency", NullValueHandling = NullValueHandling.Ignore)]
        public AccountBalance Currency { get; set; }

        [JsonProperty("min_due_amount", NullValueHandling = NullValueHandling.Ignore)]
        public AccountBalance MinDueAmount { get; set; }

        [JsonProperty("pos_type_rules", NullValueHandling = NullValueHandling.Ignore)]
        public PosTypeRules PosTypeRules { get; set; }

        [JsonProperty("location", NullValueHandling = NullValueHandling.Ignore)]
        public AccountBalance Location { get; set; }

        [JsonProperty("outstanding_balance", NullValueHandling = NullValueHandling.Ignore)]
        public AccountBalance OutstandingBalance { get; set; }

        [JsonProperty("event_type", NullValueHandling = NullValueHandling.Ignore)]
        public EventType? EventType { get; set; }

        [JsonProperty("pnr", NullValueHandling = NullValueHandling.Ignore)]
        public EventLocation Pnr { get; set; }

        [JsonProperty("event_info", NullValueHandling = NullValueHandling.Ignore)]
        public EventInfo EventInfo { get; set; }

        [JsonProperty("name", NullValueHandling = NullValueHandling.Ignore)]
        public EventInfo Name { get; set; }

        [JsonProperty("event_location", NullValueHandling = NullValueHandling.Ignore)]
        public EventLocation EventLocation { get; set; }

        [JsonProperty("event_reminder_span", NullValueHandling = NullValueHandling.Ignore)]
        public EventReminderSpan EventReminderSpan { get; set; }

        [JsonProperty("deleted", NullValueHandling = NullValueHandling.Ignore)]
        public bool? Deleted { get; set; }

        [JsonProperty("incomplete", NullValueHandling = NullValueHandling.Ignore)]
        public bool? Incomplete { get; set; }

        [JsonProperty("time", NullValueHandling = NullValueHandling.Ignore)]
        public AccountBalance Time { get; set; }

        [JsonProperty("contact", NullValueHandling = NullValueHandling.Ignore)]
        public Contact Contact { get; set; }

        [JsonProperty("show_notification", NullValueHandling = NullValueHandling.Ignore)]
        public bool? ShowNotification { get; set; }

        [JsonProperty("otp", NullValueHandling = NullValueHandling.Ignore)]
        public AccountBalance Otp { get; set; }

        [JsonProperty("pos_info", NullValueHandling = NullValueHandling.Ignore)]
        public AccountBalance PosInfo { get; set; }
    }

    public partial class AccountBalance
    {
        [JsonProperty("group_id")]
        public long GroupId { get; set; }
    }

    public partial class Amount
    {
        [JsonProperty("group_id", NullValueHandling = NullValueHandling.Ignore)]
        public long? GroupId { get; set; }

        [JsonProperty("value", NullValueHandling = NullValueHandling.Ignore)]
        public long? Value { get; set; }

        [JsonProperty("create_txn", NullValueHandling = NullValueHandling.Ignore)]
        public bool? CreateTxn { get; set; }

        [JsonProperty("group_ids", NullValueHandling = NullValueHandling.Ignore)]
        public long[] GroupIds { get; set; }

        [JsonProperty("txn_direction", NullValueHandling = NullValueHandling.Ignore)]
        public string TxnDirection { get; set; }
    }

    public partial class ChainingRule
    {
        [JsonProperty("parent_match")]
        public ParentMatch ParentMatch { get; set; }

        [JsonProperty("parent_nomatch", NullValueHandling = NullValueHandling.Ignore)]
        public ParentNomatch ParentNomatch { get; set; }

        [JsonProperty("parent_selection")]
        public ParentSelection[] ParentSelection { get; set; }
    }

    public partial class ParentMatch
    {
        [JsonProperty("parent_override")]
        public ParentOverride[] ParentOverride { get; set; }

        [JsonProperty("child_override", NullValueHandling = NullValueHandling.Ignore)]
        public ParentMatchChildOverride[] ChildOverride { get; set; }
    }

    public partial class ParentMatchChildOverride
    {
        [JsonProperty("parent_field", NullValueHandling = NullValueHandling.Ignore)]
        public string ParentField { get; set; }

        [JsonProperty("child_field", NullValueHandling = NullValueHandling.Ignore)]
        public string ChildField { get; set; }

        [JsonProperty("deleted", NullValueHandling = NullValueHandling.Ignore)]
        public bool? Deleted { get; set; }

        [JsonProperty("incomplete", NullValueHandling = NullValueHandling.Ignore)]
        public bool? Incomplete { get; set; }
    }

    public partial class ParentOverride
    {
        [JsonProperty("deleted")]
        public bool Deleted { get; set; }

        [JsonProperty("incomplete", NullValueHandling = NullValueHandling.Ignore)]
        public bool? Incomplete { get; set; }
    }

    public partial class ParentNomatch
    {
        [JsonProperty("child_override")]
        public ParentNomatchChildOverride[] ChildOverride { get; set; }
    }

    public partial class ParentNomatchChildOverride
    {
        [JsonProperty("deleted")]
        public bool Deleted { get; set; }
    }

    public partial class ParentSelection
    {
        [JsonProperty("parent_field")]
        [JsonConverter(typeof(FieldConverter))]
        public Field ParentField { get; set; }

        [JsonProperty("child_field", NullValueHandling = NullValueHandling.Ignore)]
        public ChildField ChildField { get; set; }

        [JsonProperty("match_type")]
        public MatchType MatchType { get; set; }

        [JsonProperty("match_value", NullValueHandling = NullValueHandling.Ignore)]
        public long? MatchValue { get; set; }
    }

    public partial class ChildField
    {
        [JsonProperty("field", NullValueHandling = NullValueHandling.Ignore)]
        [JsonConverter(typeof(FieldConverter))]
        public Field? Field { get; set; }

        [JsonProperty("group_id", NullValueHandling = NullValueHandling.Ignore)]
        public long? GroupId { get; set; }

        [JsonProperty("value", NullValueHandling = NullValueHandling.Ignore)]
        public string Value { get; set; }
    }

    public partial class Contact
    {
        [JsonProperty("group_id")]
        public long GroupId { get; set; }

        [JsonProperty("prefix", NullValueHandling = NullValueHandling.Ignore)]
        public string Prefix { get; set; }
    }

    public partial class CreateTxn
    {
        [JsonProperty("amount")]
        public AccountBalance Amount { get; set; }
    }

    public partial class Date
    {
        [JsonProperty("group_id", NullValueHandling = NullValueHandling.Ignore)]
        public long? GroupId { get; set; }

        [JsonProperty("formats", NullValueHandling = NullValueHandling.Ignore)]
        public Format[] Formats { get; set; }

        [JsonProperty("use_sms_time", NullValueHandling = NullValueHandling.Ignore)]
        public bool? UseSmsTime { get; set; }

        [JsonProperty("group_ids", NullValueHandling = NullValueHandling.Ignore)]
        public long[] GroupIds { get; set; }
    }

    public partial class Format
    {
        [JsonProperty("use_sms_time", NullValueHandling = NullValueHandling.Ignore)]
        public bool? UseSmsTime { get; set; }

        [JsonProperty("format")]
        public string FormatFormat { get; set; }
    }

    public partial class EventInfo
    {
        [JsonProperty("group_id", NullValueHandling = NullValueHandling.Ignore)]
        public long? GroupId { get; set; }

        [JsonProperty("value", NullValueHandling = NullValueHandling.Ignore)]
        public string Value { get; set; }
    }

    public partial class EventLocation
    {
        [JsonProperty("group_id", NullValueHandling = NullValueHandling.Ignore)]
        public long? GroupId { get; set; }

        [JsonProperty("group_ids", NullValueHandling = NullValueHandling.Ignore)]
        public long[] GroupIds { get; set; }
    }

    public partial class EventReminderSpan
    {
        [JsonProperty("value")]
        public long Value { get; set; }
    }

    public partial class NetworkReferenceId
    {
        [JsonProperty("group_id")]
        public long GroupId { get; set; }

        [JsonProperty("type_group_id", NullValueHandling = NullValueHandling.Ignore)]
        public long? TypeGroupId { get; set; }

        [JsonProperty("type_rules", NullValueHandling = NullValueHandling.Ignore)]
        public NetworkReferenceTypeRule[] TypeRules { get; set; }

        [JsonProperty("is_upi", NullValueHandling = NullValueHandling.Ignore)]
        public bool? IsUpi { get; set; }

        [JsonProperty("is_imps", NullValueHandling = NullValueHandling.Ignore)]
        public bool? IsImps { get; set; }

        [JsonProperty("is_neft", NullValueHandling = NullValueHandling.Ignore)]
        public bool? IsNeft { get; set; }

        [JsonProperty("is_rtgs", NullValueHandling = NullValueHandling.Ignore)]
        public bool? IsRtgs { get; set; }
    }

    public partial class NetworkReferenceTypeRule
    {
        [JsonProperty("value")]
        public string Value { get; set; }

        [JsonProperty("is_upi", NullValueHandling = NullValueHandling.Ignore)]
        public bool? IsUpi { get; set; }

        [JsonProperty("is_imps", NullValueHandling = NullValueHandling.Ignore)]
        public bool? IsImps { get; set; }

        [JsonProperty("is_neft", NullValueHandling = NullValueHandling.Ignore)]
        public bool? IsNeft { get; set; }

        [JsonProperty("is_rtgs", NullValueHandling = NullValueHandling.Ignore)]
        public bool? IsRtgs { get; set; }
    }

    public partial class Pos
    {
        [JsonProperty("group_id", NullValueHandling = NullValueHandling.Ignore)]
        public long? GroupId { get; set; }

        [JsonProperty("value", NullValueHandling = NullValueHandling.Ignore)]
        public string Value { get; set; }

        [JsonProperty("set_no_pos", NullValueHandling = NullValueHandling.Ignore)]
        public bool? SetNoPos { get; set; }

        [JsonProperty("group_ids", NullValueHandling = NullValueHandling.Ignore)]
        public long[] GroupIds { get; set; }
    }

    public partial class PosTypeRules
    {
        [JsonProperty("rules")]
        public PosTypeRulesRule[] Rules { get; set; }

        [JsonProperty("group_id")]
        public long GroupId { get; set; }
    }

    public partial class PosTypeRulesRule
    {
        [JsonProperty("value")]
        public string Value { get; set; }

        [JsonProperty("category")]
        [JsonConverter(typeof(CategoryConverter))]
        public Category Category { get; set; }

        [JsonProperty("income_flag_override", NullValueHandling = NullValueHandling.Ignore)]
        public bool? IncomeFlagOverride { get; set; }
    }

    public partial class TransactionTypeRule
    {
        [JsonProperty("rules")]
        public TransactionTypeRuleRule[] Rules { get; set; }

        [JsonProperty("group_id")]
        public long GroupId { get; set; }
    }

    public partial class TransactionTypeRuleRule
    {
        [JsonProperty("txn_type")]
        [JsonConverter(typeof(NTypeConverter))]
        public NType? TxnType { get; set; }

        [JsonProperty("value")]
        public string? Value { get; set; }

        [JsonProperty("pos_override", NullValueHandling = NullValueHandling.Ignore)]
        [JsonConverter(typeof(PosOverrideConverter))]
        public PosOverride? PosOverride { get; set; }

        [JsonProperty("acc_type_override", NullValueHandling = NullValueHandling.Ignore)]
        [JsonConverter(typeof(AccConverter))]
        public Acc? AccTypeOverride { get; set; }

        [JsonProperty("set_no_pos", NullValueHandling = NullValueHandling.Ignore)]
        public bool? SetNoPos { get; set; }
    }

    public enum Acc { Bank, BillPay, CreditCard, DebitCard, Electricity, Gas, Generic, Ignore, Insurance, Loan, PayLater, Phone, Prepaid, PrepaidDth, Sip };

    public enum TypeEnum { Sms, Voice };

    public enum Field { Amount, Date, Deleted, EventLocation, Name, Note, Pan, PatternUid, Pnr, SmsTime };

    public enum MatchType { Contains, Delta, Exact, None };

    public enum EventType { Flight, Movie, Taxi, Train };
    public enum Category
    {
        WalnutBankDeposit,
        WalnutBillPayment,
        WalnutCredit,
        WalnutInterest,
        WalnutRecharge,
        WalnutRefund,
        WalnutReimbursement,
        WalnutRewards,
        WalnutSalary
    }
    
    public enum StatementType { CreditCardBill, DthRecharge, ElectricityBill, GasBill, InsurancePremium, InternetBill, LoanEmi, MobileBill, PayLaterBill, Sip };

    public enum NType { Balance, BillPay, Cash, Cheque, Credit, CreditAtm, CreditCard, DebitAtm, DebitCard, DebitPrepaid, Default, Ecs, NetBanking, Upi };

    public enum PosOverride { Atm, AtmReversal, Cash, Cheque, Credit, Debit, DebitCardPurchase, DebitCardReversal, Ecs, Emi, NetBanking, Paytm, Recharge, RevUpi, Reversal, StandingInstruction, UpiFundsTransfer };

    public enum SmsType { Axio, Event, Generic, Statement, Transaction, Walnut };

    internal static class Converter
    {
        public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.None,
            Converters =
            {
                AccConverter.Singleton,
                TypeEnumConverter.Singleton,
                FieldConverter.Singleton,
                MatchTypeConverter.Singleton,
                EventTypeConverter.Singleton,
                CategoryConverter.Singleton,
                StatementTypeConverter.Singleton,
                NTypeConverter.Singleton,
                PosOverrideConverter.Singleton,
                SmsTypeConverter.Singleton,
                new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
            },
        };
    }

    internal class ParseStringConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(long) || t == typeof(long?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            //Console.WriteLine($"Attempting to convert value: '{value}'");
            long l;
            if (Int64.TryParse(value, out l))
            {
                return l;
            }
            throw new Exception("Cannot unmarshal type long");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (long)untypedValue;
            serializer.Serialize(writer, value.ToString());
            return;
        }

        public static readonly ParseStringConverter Singleton = new ParseStringConverter();
    }

    internal class AccConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(Acc) || t == typeof(Acc?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            //Console.WriteLine($"Attempting to convert value: '{value}'");
            switch (value)
            {
                case "bank":
                    return Acc.Bank;
                case "bill_pay":
                    return Acc.BillPay;
                case "credit_card":
                    return Acc.CreditCard;
                case "debit_card":
                    return Acc.DebitCard;
                case "electricity":
                    return Acc.Electricity;
                case "gas":
                    return Acc.Gas;
                case "generic":
                    return Acc.Generic;
                case "ignore":
                    return Acc.Ignore;
                case "insurance":
                    return Acc.Insurance;
                case "loan":
                    return Acc.Loan;
                case "pay_later":
                    return Acc.PayLater;
                case "phone":
                    return Acc.Phone;
                case "prepaid":
                    return Acc.Prepaid;
                case "prepaid_dth":
                    return Acc.PrepaidDth;
                case "sip":
                    return Acc.Sip;
                default:
                    Console.WriteLine($"Unknown value: {value}"); // Log unknown values
                    throw new Exception($"Cannot unmarshal type AccConverter: {value}");
            }
            throw new Exception("Cannot unmarshal type Acc");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (Acc)untypedValue;
            switch (value)
            {
                case Acc.Bank:
                    serializer.Serialize(writer, "bank");
                    return;
                case Acc.BillPay:
                    serializer.Serialize(writer, "bill_pay");
                    return;
                case Acc.CreditCard:
                    serializer.Serialize(writer, "credit_card");
                    return;
                case Acc.DebitCard:
                    serializer.Serialize(writer, "debit_card");
                    return;
                case Acc.Electricity:
                    serializer.Serialize(writer, "electricity");
                    return;
                case Acc.Gas:
                    serializer.Serialize(writer, "gas");
                    return;
                case Acc.Generic:
                    serializer.Serialize(writer, "generic");
                    return;
                case Acc.Ignore:
                    serializer.Serialize(writer, "ignore");
                    return;
                case Acc.Insurance:
                    serializer.Serialize(writer, "insurance");
                    return;
                case Acc.Loan:
                    serializer.Serialize(writer, "loan");
                    return;
                case Acc.PayLater:
                    serializer.Serialize(writer, "pay_later");
                    return;
                case Acc.Phone:
                    serializer.Serialize(writer, "phone");
                    return;
                case Acc.Prepaid:
                    serializer.Serialize(writer, "prepaid");
                    return;
                case Acc.PrepaidDth:
                    serializer.Serialize(writer, "prepaid_dth");
                    return;
                case Acc.Sip:
                    serializer.Serialize(writer, "sip");
                    return;
            }
            throw new Exception("Cannot marshal type Acc");
        }

        public static readonly AccConverter Singleton = new AccConverter();
    }

    internal class TypeEnumConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(TypeEnum) || t == typeof(TypeEnum?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            //Console.WriteLine($"Attempting to convert value: '{value}'");
            switch (value)
            {
                case "sms":
                    return TypeEnum.Sms;
                case "voice":
                    return TypeEnum.Voice;
            }
            throw new Exception("Cannot unmarshal type TypeEnum");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (TypeEnum)untypedValue;
            switch (value)
            {
                case TypeEnum.Sms:
                    serializer.Serialize(writer, "sms");
                    return;
                case TypeEnum.Voice:
                    serializer.Serialize(writer, "voice");
                    return;
            }
            throw new Exception("Cannot marshal type TypeEnum");
        }

        public static readonly TypeEnumConverter Singleton = new TypeEnumConverter();
    }

    internal class FieldConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(Field) || t == typeof(Field?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            //Console.WriteLine($"Attempting to convert value: '{value}'");
            switch (value)
            {
                case "amount":
                    return Field.Amount;
                case "date":
                    return Field.Date;
                case "deleted":
                    return Field.Deleted;
                case "event_location":
                    return Field.EventLocation;
                case "name":
                    return Field.Name;
                case "note":
                    return Field.Note;
                case "pan":
                    return Field.Pan;
                case "pattern_UID":
                    return Field.PatternUid;
                case "pnr":
                    return Field.Pnr;
                case "sms_time":
                    return Field.SmsTime;
                default:
                    Console.WriteLine($"Unknown value: {value}"); // Log unknown values
                    throw new Exception($"Cannot unmarshal type FieldConverter: {value}");
            }
            throw new Exception("Cannot unmarshal type Field");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (Field)untypedValue;
            switch (value)
            {
                case Field.Amount:
                    serializer.Serialize(writer, "amount");
                    return;
                case Field.Date:
                    serializer.Serialize(writer, "date");
                    return;
                case Field.Deleted:
                    serializer.Serialize(writer, "deleted");
                    return;
                case Field.EventLocation:
                    serializer.Serialize(writer, "event_location");
                    return;
                case Field.Name:
                    serializer.Serialize(writer, "name");
                    return;
                case Field.Note:
                    serializer.Serialize(writer, "note");
                    return;
                case Field.Pan:
                    serializer.Serialize(writer, "pan");
                    return;
                case Field.PatternUid:
                    serializer.Serialize(writer, "pattern_UID");
                    return;
                case Field.Pnr:
                    serializer.Serialize(writer, "pnr");
                    return;
                case Field.SmsTime:
                    serializer.Serialize(writer, "sms_time");
                    return;
            }
            throw new Exception("Cannot marshal type Field");
        }

        public static readonly FieldConverter Singleton = new FieldConverter();
    }

    internal class MatchTypeConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(MatchType) || t == typeof(MatchType?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            //Console.WriteLine($"Attempting to convert value: '{value}'");
            switch (value)
            {
                case "contains":
                    return MatchType.Contains;
                case "delta":
                    return MatchType.Delta;
                case "exact":
                    return MatchType.Exact;
                case "none":
                    return MatchType.None;
            }
            throw new Exception("Cannot unmarshal type MatchType");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (MatchType)untypedValue;
            switch (value)
            {
                case MatchType.Contains:
                    serializer.Serialize(writer, "contains");
                    return;
                case MatchType.Delta:
                    serializer.Serialize(writer, "delta");
                    return;
                case MatchType.Exact:
                    serializer.Serialize(writer, "exact");
                    return;
                case MatchType.None:
                    serializer.Serialize(writer, "none");
                    return;
            }
            throw new Exception("Cannot marshal type MatchType");
        }

        public static readonly MatchTypeConverter Singleton = new MatchTypeConverter();
    }

    internal class EventTypeConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(EventType) || t == typeof(EventType?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            //Console.WriteLine($"Attempting to convert value: '{value}'");
            switch (value)
            {
                case "flight":
                    return EventType.Flight;
                case "movie":
                    return EventType.Movie;
                case "taxi":
                    return EventType.Taxi;
                case "train":
                    return EventType.Train;
            }
            throw new Exception("Cannot unmarshal type EventType");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (EventType)untypedValue;
            switch (value)
            {
                case EventType.Flight:
                    serializer.Serialize(writer, "flight");
                    return;
                case EventType.Movie:
                    serializer.Serialize(writer, "movie");
                    return;
                case EventType.Taxi:
                    serializer.Serialize(writer, "taxi");
                    return;
                case EventType.Train:
                    serializer.Serialize(writer, "train");
                    return;
            }
            throw new Exception("Cannot marshal type EventType");
        }

        public static readonly EventTypeConverter Singleton = new EventTypeConverter();
    }

    internal class CategoryConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(Category) || t == typeof(Category?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            // Console.WriteLine($"Attempting to convert value: '{value}'");
            switch (value)
            {
                case "walnut_bank_deposit":
                    return Category.WalnutBankDeposit;
                case "walnut_bill_payment":
                    return Category.WalnutBillPayment;
                case "walnut_credit":
                    return Category.WalnutCredit;
                case "walnut_interest":
                    return Category.WalnutInterest;
                case "walnut_recharge":
                    return Category.WalnutRecharge;
                case "walnut_refund":
                    return Category.WalnutRefund;
                case "walnut_reimbursement":
                    return Category.WalnutReimbursement;
                case "walnut_rewards":
                    return Category.WalnutRewards;
                case "walnut_salary":
                    return Category.WalnutSalary;
                default:
                    Console.WriteLine($"Unknown value: {value}"); // Log unknown values
                    throw new ArgumentException($"Cannot map value '{value}' to Category enum.");
            }
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (Category)untypedValue;
            switch (value)
            {
                case Category.WalnutBankDeposit:
                    serializer.Serialize(writer, "walnut_bank_deposit");
                    return;
                case Category.WalnutBillPayment:
                    serializer.Serialize(writer, "walnut_bill_payment");
                    return;
                case Category.WalnutCredit:
                    serializer.Serialize(writer, "walnut_credit");
                    return;
                case Category.WalnutInterest:
                    serializer.Serialize(writer, "walnut_interest");
                    return;
                case Category.WalnutRecharge:
                    serializer.Serialize(writer, "walnut_recharge");
                    return;
                case Category.WalnutRefund:
                    serializer.Serialize(writer, "walnut_refund");
                    return;
                case Category.WalnutReimbursement:
                    serializer.Serialize(writer, "walnut_reimbursement");
                    return;
                case Category.WalnutRewards:
                    serializer.Serialize(writer, "walnut_rewards");
                    return;
                case Category.WalnutSalary:
                    serializer.Serialize(writer, "walnut_salary");
                    return;
                default:
                    throw new ArgumentException($"Cannot map value '{value}' to Category enum.");
            }
        }

        public static readonly CategoryConverter Singleton = new CategoryConverter();
    }

    internal class StatementTypeConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(StatementType) || t == typeof(StatementType?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            //Console.WriteLine($"Attempting to convert value: '{value}'");
            switch (value)
            {
                case "credit_card_bill":
                    return StatementType.CreditCardBill;
                case "dth_recharge":
                    return StatementType.DthRecharge;
                case "electricity_bill":
                    return StatementType.ElectricityBill;
                case "gas_bill":
                    return StatementType.GasBill;
                case "insurance_premium":
                    return StatementType.InsurancePremium;
                case "internet_bill":
                    return StatementType.InternetBill;
                case "loan_emi":
                    return StatementType.LoanEmi;
                case "mobile_bill":
                    return StatementType.MobileBill;
                case "pay_later_bill":
                    return StatementType.PayLaterBill;
                case "sip":
                    return StatementType.Sip;
                default:
                    Console.WriteLine($"Unknown value: {value}"); // Log unknown values
                    throw new Exception($"Cannot unmarshal type StatementType: {value}");
            }
            throw new Exception("Cannot unmarshal type StatementType");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (StatementType)untypedValue;
            switch (value)
            {
                case StatementType.CreditCardBill:
                    serializer.Serialize(writer, "credit_card_bill");
                    return;
                case StatementType.DthRecharge:
                    serializer.Serialize(writer, "dth_recharge");
                    return;
                case StatementType.ElectricityBill:
                    serializer.Serialize(writer, "electricity_bill");
                    return;
                case StatementType.GasBill:
                    serializer.Serialize(writer, "gas_bill");
                    return;
                case StatementType.InsurancePremium:
                    serializer.Serialize(writer, "insurance_premium");
                    return;
                case StatementType.InternetBill:
                    serializer.Serialize(writer, "internet_bill");
                    return;
                case StatementType.LoanEmi:
                    serializer.Serialize(writer, "loan_emi");
                    return;
                case StatementType.MobileBill:
                    serializer.Serialize(writer, "mobile_bill");
                    return;
                case StatementType.PayLaterBill:
                    serializer.Serialize(writer, "pay_later_bill");
                    return;
                case StatementType.Sip:
                    serializer.Serialize(writer, "sip");
                    return;

            }
            throw new Exception("Cannot marshal type StatementType");
        }

        public static readonly StatementTypeConverter Singleton = new StatementTypeConverter();
    }

    internal class NTypeConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(NType) || t == typeof(NType?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            //Console.WriteLine($"Attempting to convert value: '{value}'");
            switch (value)
            {
                case "balance":
                    return NType.Balance;
                case "bill_pay":
                    return NType.BillPay;
                case "cash":
                    return NType.Cash;
                case "cheque":
                    return NType.Cheque;
                case "credit":
                    return NType.Credit;
                case "credit_atm":
                    return NType.CreditAtm;
                case "credit_card":
                    return NType.CreditCard;
                case "debit_atm":
                    return NType.DebitAtm;
                case "debit_card":
                    return NType.DebitCard;
                case "debit_prepaid":
                    return NType.DebitPrepaid;
                case "default":
                    return NType.Default;
                case "ecs":
                    return NType.Ecs;
                case "net_banking":
                    return NType.NetBanking;
                case "upi":
                    return NType.Upi;
                default:
                    return NType.Default;
            }
            throw new Exception("Cannot unmarshal type NType");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (NType)untypedValue;
            switch (value)
            {
                case NType.Balance:
                    serializer.Serialize(writer, "balance");
                    return;
                case NType.BillPay:
                    serializer.Serialize(writer, "bill_pay");
                    return;
                case NType.Cash:
                    serializer.Serialize(writer, "cash");
                    return;
                case NType.Cheque:
                    serializer.Serialize(writer, "cheque");
                    return;
                case NType.Credit:
                    serializer.Serialize(writer, "credit");
                    return;
                case NType.CreditAtm:
                    serializer.Serialize(writer, "credit_atm");
                    return;
                case NType.CreditCard:
                    serializer.Serialize(writer, "credit_card");
                    return;
                case NType.DebitAtm:
                    serializer.Serialize(writer, "debit_atm");
                    return;
                case NType.DebitCard:
                    serializer.Serialize(writer, "debit_card");
                    return;
                case NType.DebitPrepaid:
                    serializer.Serialize(writer, "debit_prepaid");
                    return;
                case NType.Default:
                    serializer.Serialize(writer, "default");
                    return;
                case NType.Ecs:
                    serializer.Serialize(writer, "ecs");
                    return;
                case NType.NetBanking:
                    serializer.Serialize(writer, "net_banking");
                    return;
                case NType.Upi:
                    serializer.Serialize(writer, "upi");
                    return;
            }
            throw new Exception("Cannot marshal type NType");
        }

        public static readonly NTypeConverter Singleton = new NTypeConverter();
    }

    internal class PosOverrideConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(PosOverride) || t == typeof(PosOverride?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            //Console.WriteLine($"Attempting to convert value: '{value}'");
            switch (value)
            {
                case "ATM":
                    return PosOverride.Atm;
                case "ATM Reversal":
                    return PosOverride.AtmReversal;
                case "Cash":
                    return PosOverride.Cash;
                case "Cheque":
                    return PosOverride.Cheque;
                case "Credit":
                    return PosOverride.Credit;
                case "Debit":
                    return PosOverride.Debit;
                case "Debit Card Purchase":
                    return PosOverride.DebitCardPurchase;
                case "Debit Card Reversal":
                    return PosOverride.DebitCardReversal;
                case "ECS":
                    return PosOverride.Ecs;
                case "EMI":
                    return PosOverride.Emi;
                case "Net Banking":
                    return PosOverride.NetBanking;
                case "Paytm":
                    return PosOverride.Paytm;
                case "Recharge":
                    return PosOverride.Recharge;
                case "Rev-Upi":
                    return PosOverride.RevUpi;
                case "Reversal":
                    return PosOverride.Reversal;
                case "Standing Instruction":
                    return PosOverride.StandingInstruction;
                case "UPI Funds Transfer":
                    return PosOverride.UpiFundsTransfer;
            }
            throw new Exception("Cannot unmarshal type PosOverride");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (PosOverride)untypedValue;
            switch (value)
            {
                case PosOverride.Atm:
                    serializer.Serialize(writer, "ATM");
                    return;
                case PosOverride.AtmReversal:
                    serializer.Serialize(writer, "ATM Reversal");
                    return;
                case PosOverride.Cash:
                    serializer.Serialize(writer, "Cash");
                    return;
                case PosOverride.Cheque:
                    serializer.Serialize(writer, "Cheque");
                    return;
                case PosOverride.Credit:
                    serializer.Serialize(writer, "Credit");
                    return;
                case PosOverride.Debit:
                    serializer.Serialize(writer, "Debit");
                    return;
                case PosOverride.DebitCardPurchase:
                    serializer.Serialize(writer, "Debit Card Purchase");
                    return;
                case PosOverride.DebitCardReversal:
                    serializer.Serialize(writer, "Debit Card Reversal");
                    return;
                case PosOverride.Ecs:
                    serializer.Serialize(writer, "ECS");
                    return;
                case PosOverride.Emi:
                    serializer.Serialize(writer, "EMI");
                    return;
                case PosOverride.NetBanking:
                    serializer.Serialize(writer, "Net Banking");
                    return;
                case PosOverride.Paytm:
                    serializer.Serialize(writer, "Paytm");
                    return;
                case PosOverride.Recharge:
                    serializer.Serialize(writer, "Recharge");
                    return;
                case PosOverride.RevUpi:
                    serializer.Serialize(writer, "Rev-Upi");
                    return;
                case PosOverride.Reversal:
                    serializer.Serialize(writer, "Reversal");
                    return;
                case PosOverride.StandingInstruction:
                    serializer.Serialize(writer, "Standing Instruction");
                    return;
                case PosOverride.UpiFundsTransfer:
                    serializer.Serialize(writer, "UPI Funds Transfer");
                    return;
            }
            throw new Exception("Cannot marshal type PosOverride");
        }

        public static readonly PosOverrideConverter Singleton = new PosOverrideConverter();
    }

    internal class SmsTypeConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(SmsType) || t == typeof(SmsType?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            //Console.WriteLine($"Attempting to convert value: '{value}'");
            switch (value)
            {
                case "axio":
                    return SmsType.Axio;
                case "event":
                    return SmsType.Event;
                case "generic":
                    return SmsType.Generic;
                case "statement":
                    return SmsType.Statement;
                case "transaction":
                    return SmsType.Transaction;
                case "walnut":
                    return SmsType.Walnut;
            }
            throw new Exception("Cannot unmarshal type SmsType");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (SmsType)untypedValue;
            switch (value)
            {
                case SmsType.Axio:
                    serializer.Serialize(writer, "axio");
                    return;
                case SmsType.Event:
                    serializer.Serialize(writer, "event");
                    return;
                case SmsType.Generic:
                    serializer.Serialize(writer, "generic");
                    return;
                case SmsType.Statement:
                    serializer.Serialize(writer, "statement");
                    return;
                case SmsType.Transaction:
                    serializer.Serialize(writer, "transaction");
                    return;
                case SmsType.Walnut:
                    serializer.Serialize(writer, "walnut");
                    return;
            }
            throw new Exception("Cannot marshal type SmsType");
        }

        public static readonly SmsTypeConverter Singleton = new SmsTypeConverter();
    }
}
