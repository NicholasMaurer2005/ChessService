using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;



namespace Backend.Api.Controllers
{
    [Authorize]
    public class SecureController : ControllerBase
    {
        //private members
        protected string? _userId { get; }

        public SecureController()
        {
            _userId = User.FindFirstValue("sub");
        }
    }
}
