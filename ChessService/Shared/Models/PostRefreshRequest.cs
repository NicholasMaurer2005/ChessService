namespace ChessService.Shared.Models
{
    public sealed class PostRefreshRequest
    {
        public required string RefreshToken { get; set; }
    }
}
