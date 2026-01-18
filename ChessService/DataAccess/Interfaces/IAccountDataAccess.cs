using ChessService.Shared.Models;



namespace ChessService.DataAccess.Interfaces
{
    public interface IAccountDataAccess
    {
        Task PostAccountAsync(PostAccountRequest request);

        Task DeleteAccountAsync(int subscriberId);
    }
}
