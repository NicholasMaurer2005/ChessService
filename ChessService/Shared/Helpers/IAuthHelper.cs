namespace ChessService.Shared.Helpers
{
    public interface IAuthHelper
    {
        Task<string> ExchangeTokenAsync(string refreshToken);

        Task<string> AuthorizeAsync(string code);
    }
}
