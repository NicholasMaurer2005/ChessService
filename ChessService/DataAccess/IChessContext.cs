using ChessService.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;



namespace ChessService.DataAccess
{
    public interface IChessContext
    {
        //public methods
        Task SaveAsync();



        //tables
        DbSet<Subscriber> Subscribers { get; set; }
    }
}
