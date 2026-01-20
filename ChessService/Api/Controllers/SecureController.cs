using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;



namespace ChessService.Api.Controllers
{
    [Authorize]
    [ApiController]
    public class SecureController : ControllerBase
    {
        //private members
        protected string UserId => User?.FindFirstValue("sub") ?? string.Empty;

        [HttpGet]
        [Route("api/hello")]
        [AllowAnonymous]
        public async Task<IActionResult> Hello()
        {
            return await Task.Run(() => { return Ok("healthy"); });
        }
    }
}
