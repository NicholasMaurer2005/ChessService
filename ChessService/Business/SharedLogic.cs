using ChessService.Shared.Exceptions;
using ChessService.DataAccess.Interfaces;



namespace ChessService.Business
{
    public class SharedLogic(ISharedDataAccess _dataAccess)
    {
        
        //public methods
        public async Task<bool> SubscriberExistsAsync(string userId)
        {
            return await _dataAccess.SubsriberExistsAsync(userId).ConfigureAwait(false);
        }

        public async Task SubscriberExistsOrThrowAsync(string userId)
        {
            if (!await _dataAccess.SubsriberExistsAsync(userId).ConfigureAwait(false)) throw new SubscriberNotFoundException(userId);
        }

        public async Task<int> SubscriberIdOrThrowAsync(string userId)
        {
            var subscriberId = await _dataAccess.SubsriberIdAsync(userId).ConfigureAwait(false);

            if (subscriberId != 0)
            {
                return subscriberId;
            }
            else
            {
                throw new SubscriberNotFoundException(userId);
            }

        }
    }
}
