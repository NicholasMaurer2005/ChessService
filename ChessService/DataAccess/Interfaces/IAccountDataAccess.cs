using Backend.Shared.Models;



namespace Backend.DataAccess.Interfaces
{
    public interface IAccountDataAccess
    {
        Task PostAccountAsync(PostAccountRequest request);

        Task DeleteAccountAsync(int subscriberId);
    }
}
