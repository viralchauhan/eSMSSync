using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Serilog;

namespace eSMSSync.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SmsController : ControllerBase
    {
        private readonly SmsService _smsService;

        public SmsController(SmsService smsService)
        {
            _smsService = smsService;
        }

        // POST method that accepts a string parameter and returns the same string
        [HttpPost("GetPushSms")]
        public async Task<IActionResult> GetPushSms([FromBody] SmsMessage smsMessage)
        {
            // Log the incoming SMS details
            Log.Information("Received SMS from {Sender}: {SmsBody} at {SmsDateTime}", smsMessage.Sender, smsMessage.SmsBody, smsMessage.SmsDateTime);

            // Insert the SMS record into the database
            await _smsService.InsertSmsAsync(smsMessage);

            // Return the same SMS details as the response
            return Ok(new { smsMessage.Sender, smsMessage.SmsBody, smsMessage.SmsDateTime });
        }
    }
}
