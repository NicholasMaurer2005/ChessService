using RestSharp;

namespace ChessService.Shared.Helpers
{
    public sealed class DescopeHelper(RestClient _client, IOptions<DescopeHelper.AuthOptions> _options): IAuthHelper
    {
        //helpers
        public sealed record AuthOptions(string ClientId, string ClientSecret);

        #pragma warning disable IDE1006 //specific names for deserialization, disable name violation warning.
        private sealed record TokenResponse(
            string access_token,
            string token_type,
            string expires_in,
            string refresh_token,
            string scope
            );
        #pragma warning restore IDE1006



        //public methods
        public async Task<string> ExchangeTokenAsync(string refreshToken)
        {
            var request = new RestRequest("oauth2/v1/token", Method.Post);

            request.AddParameter("grant_type", "refresh_token");
            request.AddParameter("client_id", _options.ClientId);
            request.AddParameter("refresh_token", refreshToken);

            var response = await _client.ExecuteAsync<TokenResponse>(request).ConfigureAwait(false);
            return response.Data?.access_token ?? string.Empty;
        }

        public async Task<string> AuthorizeAsync(string code)
        {
            var request = new RestRequest("/oauth2/v1/authorize");

            request.AddParameter("grant_type", "authorization_code");
            request.AddParameter("code", code);
            request.AddParameter("client_id", _options.ClientId);
            request.AddParameter("client_secret", _options.ClientSecret);
            request.AddParameter("redirect_uri", "uknown");

            var response = await _client.ExecuteAsync<TokenResponse>(request);
            return response.Data?.refresh_token ?? string.Empty; 
        }
    }
}
