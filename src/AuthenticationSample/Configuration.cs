namespace AuthenticationSample
{
    public class Configuration
    {
        public const string ClientId = "6e866400-cc01-4815-a1bc-1b9c4ae9999b"; // Put your mobile app ClientId
        public const string Authority = "https://login.windows.net/wleonjordangmail.onmicrosoft.com/"; // Default authority for Azure AD
        public const string Resource = "https://mosad.azurewebsites.net"; // Put your API ID URI 
        public const string RedirectUri = "https://mosadClient"; // Put your mobile app Redirect Uri (declared in Azure AD Apps)
        public const string ApiUri = "https://mosad.azurewebsites.net/api/"; // Put you API actual URL
    }
}
