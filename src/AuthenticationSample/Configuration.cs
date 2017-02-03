namespace AuthenticationSample
{
    public class Configuration
    {
        public const string ClientId = ""; // Put your mobile app ClientId
        public const string Authority = "https://login.windows.net/common"; // Default authority for Azure AD
        public const string Resource = "https://woodenmoose-webapi-appid.com"; // Put your API AppId
        public const string RedirectUri = "https://woodenmoose-authenticationsample.com"; // Put your mobile app Redirect Uri (declared in Azure AD Apps)
        public const string ApiUri = "https://woodenmoose-authenticationsample.azurewebsites.net"; // Put you API actual URL
    }
}
