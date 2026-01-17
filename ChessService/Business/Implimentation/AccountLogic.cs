using Backend.Business.Interfaces;
using Backend.DataAccess.Interfaces;
using Backend.Shared.Models;



namespace Backend.Business.Implimentation
{
    public sealed class AccountLogic(IAccountDataAccess accountDataAccess, ISharedDataAccess sharedDataAccess) : SharedLogic(sharedDataAccess), IAccountLogic
    {
        //private members
        private readonly IAccountDataAccess _dataAccess = accountDataAccess;



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
    }
}
