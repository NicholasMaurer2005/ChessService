using Backend.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;



namespace Backend.DataAccess
{
    public interface IChessContext
    {
        //public methods
        Task SaveAsync();



        //tables
        DbSet<Subscriber> Subscribers { get; set; }
    }
}
