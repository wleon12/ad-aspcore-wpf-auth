using Android.App;
using Android.Content;
using Android.OS;
using Android.Widget;
using AuthenticationSample.ViewModels;
using GalaSoft.MvvmLight.Helpers;
using Microsoft.IdentityModel.Clients.ActiveDirectory;

namespace AuthenticationSample.Droid
{
    [Activity(Label = "AuthenticationSample.Droid", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        #region Bindings

        private Binding<bool, string> _isConnectedBinding;
        private Binding<string, string> _firstNameBinding;
        private Binding<string, string> _lastNameBinding;
        private Binding<string, string> _emailBinding;
        private Binding<string, string> _apiResponseBinding;

        #endregion

        #region Controls

        public Button LoginButton => FindViewById<Button>(Resource.Id.LoginButton);
        public Button LogoutButton => FindViewById<Button>(Resource.Id.LogoutButton);
        public Button QueryApiButton => FindViewById<Button>(Resource.Id.QueryApiButton);
        public TextView IsConnectedTextView => FindViewById<TextView>(Resource.Id.IsConnectedTextView);
        public TextView FirstNameTextView => FindViewById<TextView>(Resource.Id.FirstNameTextView);
        public TextView LastNameTextView => FindViewById<TextView>(Resource.Id.LastNameTextView);
        public TextView EmailTextView => FindViewById<TextView>(Resource.Id.EmailTextView);
        public TextView ApiResponseTextView => FindViewById<TextView>(Resource.Id.ApiResponseTextView);

        #endregion

        public MainViewModel ViewModel { get; } = new MainViewModel();

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            AuthenticationManager.SetParameters(new PlatformParameters(this));

            ViewModel.Load();

            LoginButton.Click += (s, e) => ViewModel.LoginAsync();
            LogoutButton.Click += (s, e) => ViewModel.LogoutAsync();
            QueryApiButton.Click += (s, e) => ViewModel.QueryApiAsync();

            _isConnectedBinding = this.SetBinding(() => ViewModel.IsConnected, () => IsConnectedTextView.Text).ConvertSourceToTarget(value => $"Is connected : {value}");
            _firstNameBinding = this.SetBinding(() => ViewModel.FirstName, () => FirstNameTextView.Text).ConvertSourceToTarget(value => $"First name : {value}");
            _lastNameBinding = this.SetBinding(() => ViewModel.LastName, () => LastNameTextView.Text).ConvertSourceToTarget(value => $"Last name : {value}");
            _emailBinding = this.SetBinding(() => ViewModel.Email, () => EmailTextView.Text).ConvertSourceToTarget(value => $"Email : {value}");
            _apiResponseBinding = this.SetBinding(() => ViewModel.ApiResponse, () => ApiResponseTextView.Text).ConvertSourceToTarget(value => $"API response : {value}");
        }

        protected override void OnActivityResult(int requestCode, Result resultCode, Intent data)
        {
            base.OnActivityResult(requestCode, resultCode, data);
            AuthenticationAgentContinuationHelper.SetAuthenticationAgentContinuationEventArgs(requestCode, resultCode, data);
        }
    }
}

