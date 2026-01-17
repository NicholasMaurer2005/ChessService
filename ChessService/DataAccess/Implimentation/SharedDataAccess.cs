using Backend.DataAccess.Interfaces;
using Microsoft.EntityFrameworkCore;



namespace Backend.DataAccess.Implimentation
{
    public sealed class SharedDataAccess(IChessContext context) : ISharedDataAccess
    {
        //private members
        private readonly IChessContext _context = context;



        //public methods
        public async Task<bool> SubsriberExistsAsync(string userId)
        {
            return await _context.Subscribers.AsNoTracking().AnyAsync(x => x.UserId == userId).ConfigureAwait(false);
        }

        public async Task<int> SubsriberIdAsync(string userId)
        {
            return await (from s in _context.Subscribers.AsNoTracking()
                          where s.UserId == userId
                          select s.SubscriberId).FirstOrDefaultAsync().ConfigureAwait(false);
        }
    }
}
