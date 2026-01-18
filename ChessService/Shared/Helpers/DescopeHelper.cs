using RestSharp;

namespace ChessService.Shared.Helpers
{
    public sealed class DescopeHelper(RestClient client): IDescopeHelper
    {
        //helpers
        #pragma warning disable IDE1006 //specific names for deserialization, disable name violation warning.
        private sealed record TokenResponse(
            string access_token,
            string token_type,
            string expires_in,
            string refresh_token,
            string scope
            );
        #pragma warning restore IDE1006



        //private members
        private readonly RestClient _client = client;



        //public methods
        public async Task<string> ExchangeTokenAsync(string refreshToken)
        {
            var request = new RestRequest("oauth2/v1/token", Method.Post);

            request.AddParameter("grant_type", "refresh_token");
            request.AddParameter("client_id", "YOUR_CLIENT_ID");
            request.AddParameter("refresh_token", refreshToken);

            var response = await _client.ExecuteAsync<TokenResponse>(request).ConfigureAwait(false);
            return response.Data?.access_token ?? string.Empty;
        }
    }
}
