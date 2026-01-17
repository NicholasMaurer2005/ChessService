using Backend.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;



namespace Backend.DataAccess
{
    public sealed class ChessContext(DbContextOptions<ChessContext> options) : DbContext(options), IChessContext
    {
        //public methods
        public async Task SaveAsync()
        {
            await SaveChangesAsync().ConfigureAwait(false);
        }



        //tables
        public DbSet<Subscriber> Subscribers { get; set; } = null!;
    }
}
