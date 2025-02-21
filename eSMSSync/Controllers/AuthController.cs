using eSMSSync.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace eSMSSync.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IBudgetService _budgetService;

        public AuthController(IBudgetService budgetService) 
        {
            _budgetService = budgetService;
        }

        // POST method that accepts a string parameter and returns the same string
        [HttpPost("Verify")]
        public async Task<IActionResult> VerifyAuthDetails([FromBody] VerifyAuthDetails verifyAuthDetails)
        {

            if (verifyAuthDetails == null || verifyAuthDetails.EmailId == null || verifyAuthDetails.Pan == null)
            {
                return BadRequest("Invalid request data.");
            }

            var reply = await _budgetService.VerifyUser(verifyAuthDetails, CancellationToken.None);

            if(reply.IsVerified == false)
            {
                return Unauthorized("Invalid User.");
            }

            // Return the same SMS details as the response
            return Ok(reply);
        }

    }
}
