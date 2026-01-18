using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;



namespace ChessService.Api.Controllers
{
    [Authorize]
    public class SecureController : ControllerBase
    {
        //private members
        protected string UserId => User?.FindFirstValue("sub") ?? string.Empty;
    }
}
