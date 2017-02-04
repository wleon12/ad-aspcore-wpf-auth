namespace AuthenticationSample
{
    public class Configuration
    {
        public const string ClientId = "e9d8e4f7-9aa8-4fd7-81d3-cba38b22398c"; // Put your mobile app ClientId
        public const string Authority = "https://login.windows.net/tlarivieremcnext1.onmicrosoft.com"; // Default authority for Azure AD
        public const string Resource = "https://tlarivieremcnext1.onmicrosoft.com/woodenmoose-webapi-appid"; // Put your API AppId
        public const string RedirectUri = "http://promethee.infeeny.com"; // Put your mobile app Redirect Uri (declared in Azure AD Apps)
        public const string ApiUri = "https://woodenmoose-authenticationsample.azurewebsites.net/api"; // Put you API actual URL
    }
}
