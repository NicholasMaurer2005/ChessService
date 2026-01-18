using Backend.DataAccess.Entities;
using ChessService.DataAccess.Interfaces;
using ChessService.Shared.Models;
using Microsoft.EntityFrameworkCore;
using System.Data;
using System.Runtime.CompilerServices;



namespace ChessService.DataAccess.Implimentation
{
    public sealed class AccountDataAccess(IChessContext context) : IAccountDataAccess
    {
        //private members
        private readonly IChessContext _context = context;



        //public methods
        public async Task PostAccountAsync(PostAccountRequest request)
        {
            var record = new Subscriber
            {
                SubscriberId = 0,
                UserId = request.UserId,
                Email = request.Email,
                FirstName = request.FirstName,
                LastName = request.LastName,
                SignupDate = DateTimeOffset.Now
            };

            _context.Subscribers.Add(record);
            await _context.SaveAsync().ConfigureAwait(false);
        }

        public async Task DeleteAccountAsync(int subscriberId)
        {
            var record = await (from s in _context.Subscribers
                                where s.SubscriberId == subscriberId
                                select s).FirstOrDefaultAsync().ConfigureAwait(false);

            _context.Subscribers.Remove(record!);
            await _context.SaveAsync().ConfigureAwait(false);
        }
    }
}
