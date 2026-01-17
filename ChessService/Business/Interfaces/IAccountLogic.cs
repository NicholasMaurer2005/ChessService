using Backend.Shared.Models;



namespace Backend.Business.Interfaces
{
    public interface IAccountLogic
    {
        Task PostAccountAsync(PostAccountRequest request);

        Task DeleteAccountAsync(string userId);
    }
}
