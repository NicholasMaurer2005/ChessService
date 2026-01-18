using Backend.Business.Implimentation;
using ChessService.Business.Interfaces;
using ChessService.Shared.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;



namespace ChessService.Api.Controllers
{
    [ApiController]
    [Route("api/accounts")]
    public sealed class AccountController(IAccountLogic logic) : SecureController
    {
        //private members
        private readonly IAccountLogic _logic = logic;

         

        //endpoints
        [HttpPost]
        //[LogParameters]
        public async Task<IActionResult> PostAccount(PostAccountRequest request)
        {
            try
            {
                await _logic.PostAccountAsync(request).ConfigureAwait(false);

                return Ok();
            }
            catch (Exception exception)
            {
               //capture with telemetry
               return StatusCode(500, exception.Message);
            }
        }

        [HttpDelete]
        [AllowAnonymous]
        //[LogParameters]
        public async Task<IActionResult> DeleteAccount()
        {
            try
            {
                await _logic.DeleteAccountAsync(UserId).ConfigureAwait(false);

                return Ok();
            }
            catch (Exception exception)
            {
                //capture with telemetry
                return StatusCode(500, exception.Message);
            }
        }

        [HttpPost]
        [AllowAnonymous]
        //[LogParameters]
        public async Task<IActionResult> PostRefresh(PostRefreshRequest request)
        {
            try
            {
                var response = await _logic.PostRefreshAsync(UserId, request).ConfigureAwait(false);

                return Ok(response);
            }
            catch (Exception exception)
            {
                //capture with telemetry
                return StatusCode(500, exception.Message);
            }
        }
    }
}
