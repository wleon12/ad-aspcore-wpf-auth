namespace AuthenticationSample
{
    public class Configuration
    {
        public const string ClientId = "150526ad-75ee-44d5-a6e1-091ef0900d77"; // Put your mobile app ClientId
        public const string Authority = "https://login.windows.net/mcnext.com/"; // Default authority for Azure AD
        public const string Resource = "https://woodenmoose-authsample-api.azurewebsites.net"; // Put your API AppId
        public const string RedirectUri = "https://mcnext.com/woodenmoose-authsample-mobileapp"; // Put your mobile app Redirect Uri (declared in Azure AD Apps)
        public const string ApiUri = "https://woodenmoose-authsample-api.azurewebsites.net/api/"; // Put you API actual URL
    }
}
