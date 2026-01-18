using Backend.Shared.Models;
using ChessService.Shared.Models;



namespace Backend.Business.Interfaces
{
    public interface IAccountLogic
    {
        Task PostAccountAsync(PostAccountRequest request);

        Task DeleteAccountAsync(string userId);

        Task<PostRefreshResponse> PostRefreshAsync(string userId, PostRefreshRequest request);
    }
}
