namespace ChessService.Shared.Helpers
{
    public interface IDescopeHelper
    {
        Task<string> ExchangeTokenAsync(string refreshToken);
    }
}
