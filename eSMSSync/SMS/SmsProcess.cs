using Newtonsoft.Json;
using QuickType;
using testanalysis;

namespace eSMSSync.SMS
{
    public class SmsProcess
    {
        public SmsProcess() { }


        public bool IsValidSms(string sender,string sms)
        {
            var filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Rules", "rules.json");

            var rulesJson = File.ReadAllText(filePath);
            var rules = JsonConvert.DeserializeObject<RData>(rulesJson);
            // Create SMS parser
            var smsParser = new SmsParser(rules);

            var result = smsParser.IsValid(sender, sms);

            return result;
        }

    }
}
