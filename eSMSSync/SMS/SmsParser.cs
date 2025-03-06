using System;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using QuickType;

namespace testanalysis
{
    public class SmsTransactionResult
    {   public string Sms { get; set; }
        public string FullName { get; set; }
        public string SmsType { get; set; }
        public string CRDR { get; set; }


        public string Expense { get; set; }

        public string Income { get; set; }

        public string Pos { get; set; }

        public bool IsValid { get; set; }
        public string SenderName { get; set; }
        public string AccountType { get; set; }

        public decimal? Amount { get; set; }
        public DateTime? Date { get; set; }
        public string ReferenceNumber { get; set; }
        public decimal? Balance { get; set; }

        public decimal? MinDueAmount { get; set; }
        public string Description { get; set; }
        public string PatternId { get; set; }
        public string StatementType { get; set; }
        public SmsTransactionResult CreateTransaction { get; set; }
        public string Note { get; set; }
        public string TxnType { get; set; }

        public string TranscationType { get; set; }
        public string TranscationTypeValue { get; set; }
        public string PosOverride { get; set; }
        public string AccountTypeOverride { get; set; }
        public bool SetAccountAsExpense { get; set; }

        public string Pan { get; set; }

        public bool IsBillSms { get; set; }
        public bool IsSalarySms { get; set; }

    }

    public class SmsParser
    {
        private readonly RData rules;

        public SmsParser(RData rules)
        {
            this.rules = rules ?? throw new ArgumentNullException(nameof(rules));
        }

        private string GetGroupValue(Match match, long? groupId)
        {
            // Group 0 is the entire match, actual capturing groups start from 1
            if (!groupId.HasValue || groupId.Value <= 0 || groupId.Value >= match.Groups.Count)
                return null;

            return match.Groups[(int)groupId.Value].Value;
        }

        private decimal? ExtractAmount(Match match, long? groupId)
        {
            var value = GetGroupValue(match, groupId);
            if (string.IsNullOrEmpty(value))
                return null;

            var amountStr = value.Replace(",", "");
            return decimal.TryParse(amountStr, out decimal amount) ? amount : null;
        }

        private DateTime? ExtractDate(Match match, Date dateField)
        {
            if (dateField?.UseSmsTime == true)
            {
                return DateTime.Now;
            }

            if (dateField?.GroupId == null || dateField.GroupId <= 0 || dateField.GroupId >= match.Groups.Count)
            {
                return null;
            }

            var dateStr = GetGroupValue(match, dateField.GroupId);
            if (string.IsNullOrEmpty(dateStr))
                return null;

            if (dateField.Formats != null)
            {
                foreach (var format in dateField.Formats)
                {
                    if (format.UseSmsTime ?? false)
                        return DateTime.Now;

                    try
                    {
                        return DateTime.ParseExact(dateStr, format.FormatFormat,
                            System.Globalization.CultureInfo.InvariantCulture);
                    }
                    catch
                    {
                        if (dateStr != string.Empty)
                        {
                            // Default formats if none are provided
                            var defaultFormats = new[]
                            {
                                    "dd-MM-yyyy HH:mm:ss",
                                    "yyyy-MM-dd HH:mm:ss",
                                    "MM/dd/yyyy HH:mm:ss",
                                    "dd/MM/yyyy HH:mm:ss",
                                    "dd-MM-yyyy",
                                    "yyyy-MM-dd",
                                    "MM/dd/yyyy",
                                    "dd/MM/yyyy"
                            };

                            // Try parsing with the provided or default formats
                            foreach (var fomt in defaultFormats)
                            {
                                try
                                {
                                    if (DateTime.TryParseExact(
                                            dateStr,
                                            fomt,
                                            System.Globalization.CultureInfo.InvariantCulture,
                                            System.Globalization.DateTimeStyles.None,
                                            out var parsedDate))
                                    {
                                        return parsedDate;
                                    }
                                }
                                catch
                                {

                                }
                            }

                            return null;
                        }

                    }
                }
            }
            return null;
        }

        private string ExtractDescription(Match match, Pattern pattern)
        {
            // If POS override is set by transaction type rule, skip regular POS extraction
            var _posValue = ExtractTransactionTypeRules(match, pattern)?.PosOverride.ToString();
            if (!string.IsNullOrEmpty(_posValue))
                return _posValue;

            var posGroupId = pattern.DataFields?.Pos?.GroupId;
            var value = GetGroupValue(match, posGroupId);
            if (!string.IsNullOrEmpty(value))
            {
                return value;
            }
            return null;
        }

        private string ExtractNote(Match match, Pattern pattern)
        {
            var note = pattern.DataFields?.Note;
            if (note == null)
                return null;

            var value = GetGroupValue(match, note.GroupId);
            if (string.IsNullOrEmpty(value))
                return null;

            if (!string.IsNullOrEmpty(note.Prefix))
            {
                return $"{note.Prefix} {value}";
            }

            return value;
        }

        private string ExtractPan(Match match, Pattern pattern)
        {
            var pan = pattern.DataFields?.Pan;
            if (pan == null)
                return null;

            return GetGroupValue(match, pan.GroupId);
        }

        //private (string TxnType, string PosOverride, string Value) ExtractTransactionTypeRule(Match match, Pattern pattern)
        //{
        //    var txnRule = pattern.DataFields?.TransactionTypeRule;
        //    if (txnRule == null)
        //        return (null, null, null);

        //    var value = GetGroupValue(match, txnRule.GroupId);
        //    if (string.IsNullOrEmpty(value))
        //        return (null, null, null);

        //    if (txnRule.Rules != null)
        //    {
        //        foreach (var rule in txnRule.Rules)
        //        {
        //            // Generic condition for all transaction types
        //            if (value.Contains(rule.Value ?? "", StringComparison.OrdinalIgnoreCase))
        //            {
        //                return (rule.TxnType.ToString().ToLower(), rule.PosOverride?.ToString(), $"{rule.Value} {value}");
        //            }
        //        }
        //    }

        //    return (null, null, null);
        //}

        private TransactionTypeRuleRule ExtractTransactionTypeRules(Match match, Pattern pattern)
        {
            var txnRule = pattern.DataFields?.TransactionTypeRule;
            if (txnRule == null || txnRule.Rules == null)
            {
                if (pattern.DataFields?.TransactionType != null)
                {
                    var _type = new TransactionTypeRuleRule
                    {
                        TxnType = (NType)pattern.DataFields.TransactionType
                    };
                    return _type;
                }
                return new TransactionTypeRuleRule();
            }

            var groupValue = GetGroupValue(match, txnRule.GroupId);
            if (string.IsNullOrEmpty(groupValue))
                return new TransactionTypeRuleRule();

            var matchingRules = new TransactionTypeRuleRule { AccTypeOverride = null, PosOverride = null, SetNoPos = null, TxnType = null, Value = null };

            foreach (var rule in txnRule.Rules)
            {
                if (groupValue.Contains(rule.Value ?? "", StringComparison.OrdinalIgnoreCase))
                {
                    var _value = $"{rule.Value} {groupValue}".Trim(); // Concatenation
                    matchingRules = new TransactionTypeRuleRule { AccTypeOverride = rule.AccTypeOverride, PosOverride = rule.PosOverride, SetNoPos = rule.SetNoPos, TxnType = rule.TxnType, Value = _value };
                    break; // Exit the loop immediately after the first match
                }
            }

            return matchingRules;
        }

        private string StatementType(Pattern pattern)
        {
            return pattern.DataFields.StatementType?.ToString()!;
        }


        private (string ReferenceNumber, string TransactionType) ExtractReferenceNumber(Match match, Pattern pattern)
        {
            var refField = pattern.DataFields?.NetworkReferenceId;
            if (refField == null)
                return (null, null);

            var refValue = GetGroupValue(match, refField.GroupId);
            if (string.IsNullOrEmpty(refValue))
                return (null, null);

            // Check direct flags first
            if (refField.IsUpi == true) return (refValue, "upi");
            if (refField.IsImps == true) return (refValue, "imps");
            if (refField.IsNeft == true) return (refValue, "neft");
            if (refField.IsRtgs == true) return (refValue, "rtgs");

            // If type rules exist, check them
            if (refField.TypeRules != null && refField.TypeGroupId.HasValue)
            {
                var typeValue = GetGroupValue(match, refField.TypeGroupId.Value);
                if (!string.IsNullOrEmpty(typeValue))
                {
                    foreach (var rule in refField.TypeRules)
                    {
                        if (typeValue.Contains(rule.Value ?? "", StringComparison.OrdinalIgnoreCase))
                        {
                            if (rule.IsUpi == true) return (refValue, "upi");
                            if (rule.IsImps == true) return (refValue, "imps");
                            if (rule.IsNeft == true) return (refValue, "neft");
                            if (rule.IsRtgs == true) return (refValue, "rtgs");
                        }
                    }
                }
            }

            return (refValue, null);
        }

        private SmsTransactionResult ExtractCreateTransaction(Match match, Pattern pattern)
        {
            var createTxn = pattern.DataFields?.CreateTxn;
            if (createTxn == null)
                return null;

            return new SmsTransactionResult
            {
                Amount = ExtractAmount(match, createTxn.Amount?.GroupId),
                // Add other fields as needed for nested transaction
            };
        }

        private string ExtractPosValue(Match match, Pattern pattern)
        {
            if (pattern.DataFields?.Pos?.GroupId != null)
            {
                var posGroupId = pattern.DataFields?.Pos?.GroupId;
                var value = GetGroupValue(match, posGroupId);
                if (!string.IsNullOrEmpty(value))
                {
                    return value;
                }
                return string.Empty;
            }
            else
            {
                return pattern.DataFields?.Pos?.Value!;
            }
        }


        public SmsTransactionResult ParseSms(string sender, string message)
        {
            if (string.IsNullOrWhiteSpace(sender) || string.IsNullOrWhiteSpace(message))
                return new SmsTransactionResult { IsValid = false };

            // Check blacklist
            if (!string.IsNullOrEmpty(rules.BlacklistRegex))
            {
                var blacklistRegex = new Regex(rules.BlacklistRegex, RegexOptions.Compiled | RegexOptions.IgnoreCase);
                if (blacklistRegex.IsMatch(message))
                    return new SmsTransactionResult { IsValid = false };
            }

            foreach (var rule in rules.Rules)
            {
                // Check if sender matches
                bool senderMatches = rule.Senders?.Contains(sender.Trim(), StringComparer.OrdinalIgnoreCase) ?? false;
                if (!senderMatches && rule.SenderRegexes != null)
                {
                    senderMatches = Array.Exists(rule.SenderRegexes, regex =>
                        Regex.IsMatch(sender, regex, RegexOptions.IgnoreCase));
                }

                if (!senderMatches)
                    continue;

                foreach (var pattern in rule.Patterns)
                {
                    // Skip obsolete patterns
                    if (pattern.Obsolete ?? false)
                        continue;

                    var regex = new Regex(pattern.Regex, RegexOptions.IgnoreCase);
                    var match = regex.Match(message);

                    if (!match.Success)
                        continue;

                    var result = new SmsTransactionResult
                    {
                        Sms = message,
                        IsValid = true,
                        FullName = rule.FullName,
                        SenderName = rule.Name,
                        SmsType = pattern.SmsType.ToString(),
                        AccountType = pattern.AccountType.ToString(),
                        PatternId = pattern.PatternUid.ToString(),
                        StatementType = pattern.DataFields?.StatementType?.ToString()!,
                        IsSalarySms = message.Contains("salary", StringComparison.OrdinalIgnoreCase) || message.Contains("reimbursement", StringComparison.OrdinalIgnoreCase),
                    };
                    if (pattern.DataFields != null)
                    {

                        //Set is Bill Or not 
                        if (pattern.DataFields?.StatementType != null)
                        {
                            if (pattern.DataFields?.StatementType?.ToString() != string.Empty && pattern.DataFields?.StatementType != QuickType.StatementType.Sip)
                            {
                                result.IsBillSms = true;
                            }
                            
                        }
                        string[] billkeywords = { "bill","infobil" };

                        if (billkeywords.Any(k => message.Contains(k, StringComparison.OrdinalIgnoreCase)))
                        {
                            result.IsBillSms = true;
                        }

                        // Extract transaction type and POS override
                        var ruletxn = ExtractTransactionTypeRules(match, pattern);
                        result.TranscationType = ruletxn?.TxnType?.ToString()!;
                        result.TranscationTypeValue = ruletxn!.Value?.ToString()!;
                        result.PosOverride = ruletxn!.PosOverride?.ToString()!;
                        result.AccountTypeOverride = ruletxn!.AccTypeOverride?.ToString()!;

                        if (rule.SetAccountAsExpense != null)
                            result.SetAccountAsExpense = (bool)rule.SetAccountAsExpense!;
                        // If POS override exists, use it as description

                        //extract pos details
                        result.Pos = ExtractPosValue(match, pattern)?.ToUpper()!;

                        result.CRDR = result?.TranscationType?.Equals("credit", StringComparison.OrdinalIgnoreCase) == true ? "CR" : "DR";

                        // Extract main transaction amount
                        result.Amount = ExtractAmount(match, pattern.DataFields.Amount?.GroupId);

                        // Extract date
                        result.Date = ExtractDate(match, pattern.DataFields.Date);

                        // Extract balance
                        result.Balance = ExtractAmount(match, pattern.DataFields.AccountBalance?.GroupId);

                        result.MinDueAmount = ExtractAmount(match, pattern.DataFields.MinDueAmount?.GroupId);

                        // Extract reference number and its type
                        var (refNumber, refType) = ExtractReferenceNumber(match, pattern);
                        result.ReferenceNumber = refNumber;
                        if (string.IsNullOrEmpty(result.TxnType) && !string.IsNullOrEmpty(refType))
                        {
                            result.TxnType = refType;
                        }

                        // Extract description (only if no POS override)
                        if (string.IsNullOrEmpty(result.Description))
                        {
                            result.Description = ExtractDescription(match, pattern)?.ToUpper()!;
                        }

                        // Extract note with prefix
                        result.Note = ExtractNote(match, pattern);

                        // Extract PAN
                        result.Pan = ExtractPan(match, pattern);

                        // Handle nested transaction if present
                        result.CreateTransaction = ExtractCreateTransaction(match, pattern);

                        result.Income = result?.TranscationType?.Equals("credit", StringComparison.OrdinalIgnoreCase) == true ? "Yes" : "-";
                        result.Expense = result?.TranscationType?.Equals("credit", StringComparison.OrdinalIgnoreCase) == false ? "Yes" : "-";


                    }

                    return result;
                }
            }

            return new SmsTransactionResult { IsValid = false };
        }
    
        public bool IsValid(string sender, string message)
        {
            if (string.IsNullOrWhiteSpace(sender) || string.IsNullOrWhiteSpace(message))
                return false;

            if (!string.IsNullOrEmpty(rules.BlacklistRegex))
            {
                var blacklistRegex = new Regex(rules.BlacklistRegex, RegexOptions.Compiled | RegexOptions.IgnoreCase);
                if (blacklistRegex.IsMatch(message))
                    return false;
            }

            foreach (var rule in rules.Rules)
            {
                // Check if sender matches
                bool senderMatches = rule.Senders?.Contains(sender.Trim(), StringComparer.OrdinalIgnoreCase) ?? false;
                if (!senderMatches && rule.SenderRegexes != null)
                {
                    senderMatches = Array.Exists(rule.SenderRegexes, regex =>
                        Regex.IsMatch(sender, regex, RegexOptions.IgnoreCase));
                }

                if (!senderMatches)
                    continue;

                foreach (var pattern in rule.Patterns)
                {
                    // Skip obsolete patterns
                    if (pattern.Obsolete ?? false)
                        continue;

                    var regex = new Regex(pattern.Regex, RegexOptions.IgnoreCase);
                    var match = regex.Match(message);

                    if (!match.Success)
                        continue;

                    return true;
                }

                    
            }
        
            return false;
        }
    }
}
