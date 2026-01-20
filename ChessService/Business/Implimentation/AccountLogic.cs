using Azure.Core;
using ChessService.Business;
using ChessService.Business.Interfaces;
using ChessService.DataAccess.Interfaces;
using ChessService.Shared.Helpers;
using ChessService.Shared.Models;
using RestSharp;



namespace ChessService.Business.Implimentation
{
    public sealed class AccountLogic(IAccountDataAccess accountDataAccess, IAuthHelper descopeHelper, ISharedDataAccess sharedDataAccess) : SharedLogic(sharedDataAccess), IAccountLogic
    {
        //private members
        private readonly IAccountDataAccess _dataAccess = accountDataAccess;
        private readonly IAuthHelper _descope = descopeHelper;


        //public methods
        public async Task PostAccountAsync(PostAccountRequest request)
        {
            if (await SubscriberExistsAsync(request.UserId).ConfigureAwait(false)) throw new Exception($"Subscriber with userId {request}");

            await _dataAccess.PostAccountAsync(request).ConfigureAwait(false);
        }

        public async Task DeleteAccountAsync(string userId)
        {
            var subscriberId = await SubscriberIdOrThrowAsync(userId).ConfigureAwait(false);

            await _dataAccess.DeleteAccountAsync(subscriberId).ConfigureAwait(false);
        }

        public async Task<PostRefreshResponse> PostRefreshAsync(PostRefreshRequest request)
        {
            var token = await _descope.ExchangeTokenAsync(request.RefreshToken).ConfigureAwait(false);

            return new PostRefreshResponse 
            { 
                AccessToken = token 
            };
        }

        public async Task<PostAuthorizeResponse> PostAuthorizeAsync(PostAuthorizeRequest request)
        {
            
        }
    }
}
