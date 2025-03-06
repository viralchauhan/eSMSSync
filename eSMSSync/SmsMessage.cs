using Microsoft.AspNetCore.Http;

namespace eSMSSync
{
    public class SmsMessage
    {
        public string Sender { get; set; }
        public string SmsBody { get; set; }

        public string SmsDateTime { get; set; }
        
        public string Pan { get; set; }

        public string EmailId { get; set; }
    }

    public class ServerData
    {
        public string EmailId { get; set; }
        public string DeviceId { get; set; }

        public string Pan { get; set; }

        public IFormFile File { get;set; }
    }

    public class VerifyAuthDetails
    {
        public string EmailId { get; set; }

        public string Pan { get; set; }
    }


    public class UserReply
    {
        public string? Name { get; set; }
        public bool IsVerified { get; set; }
    }
}
