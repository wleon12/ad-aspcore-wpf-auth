using System;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Microsoft.IdentityModel.Clients.ActiveDirectory;

namespace AuthenticationSample
{
    public class AuthenticationManager
    {
        private static string _authority;
        private static string _resource;
        private static string _clientId;
        private static string _returnUri;
        private static IPlatformParameters _parameters;
        private string _accessToken;

        public static UserInfo UserInfo { get; private set; }

        public static void SetConfiguration(string authority, string resource, string clientId, string returnUri)
        {
            _authority = authority;
            _resource = resource;
            _clientId = clientId;
            _returnUri = returnUri;

            var authContext = new AuthenticationContext(_authority);
            authContext.TokenCache.Clear();
        }

        public static void SetParameters(IPlatformParameters parameters)
        {
            _parameters = parameters;
        }

        public async Task<bool> LoginAsync()
        {
            _accessToken = await GetAccessTokenAsync();
            return true;
        }

        public Task LogoutAsync()
        {
            var authContext = new AuthenticationContext(_authority);
            var cachedToken = authContext.TokenCache.ReadItems().FirstOrDefault(t => t.Authority == _authority && t.ClientId == _clientId && t.Resource == _resource);

            if (cachedToken != null)
            {
                authContext.TokenCache.DeleteItem(cachedToken);
            }

            UserInfo = null;
            _accessToken = null;

            return Task.CompletedTask;
        }

        public HttpClient CreateHttpClient()
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri(Configuration.ApiUri);

            if (!string.IsNullOrEmpty(_accessToken))
            {
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _accessToken);
            }

            return client;
        }

        private async Task<string> GetAccessTokenAsync()
        {
            var authContext = new AuthenticationContext(_authority);
            var tokens = authContext.TokenCache.ReadItems();//.FirstOrDefault(t => t.Authority == _authority && t.ClientId == _clientId && t.Resource == _resource);
            foreach (var t in tokens)
            {
                if (t.Authority == _authority && t.ClientId == _clientId && t.Resource == _resource)
                {
                    return t.AccessToken;
                }
            }
            var uri = new Uri(_returnUri);
            var authResult = await authContext.AcquireTokenAsync(_resource, _clientId, uri, _parameters);

            UserInfo = authResult.UserInfo;

            return authResult.AccessToken;
        }
    }
}
