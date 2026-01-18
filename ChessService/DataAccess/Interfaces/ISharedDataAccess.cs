namespace ChessService.DataAccess.Interfaces
{
    public interface ISharedDataAccess
    {
        Task<bool> SubsriberExistsAsync(string userId);

        Task<int> SubsriberIdAsync(string userId); 
    }
}
