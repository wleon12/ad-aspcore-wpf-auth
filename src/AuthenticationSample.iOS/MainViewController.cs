using System;
using AuthenticationSample.ViewModels;
using GalaSoft.MvvmLight.Helpers;
using Microsoft.IdentityModel.Clients.ActiveDirectory;
using UIKit;

namespace AuthenticationSample.iOS
{
    public partial class MainViewController : UIViewController
    {
        #region Bindings

        private Binding<bool, string> _isConnectedBinding;
        private Binding<string, string> _firstNameBinding;
        private Binding<string, string> _lastNameBinding;
        private Binding<string, string> _emailBinding;
        private Binding<string, string> _apiResponseBinding;

        #endregion

        public MainViewModel ViewModel { get; } = new MainViewModel();

        public MainViewController (IntPtr handle) : base (handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            AuthenticationManager.SetParameters(new PlatformParameters(this));

            ViewModel.Load();

            LoginButton.TouchUpInside += (s, e) => ViewModel.LoginAsync();
            LogoutButton.TouchUpInside += (s, e) => ViewModel.LogoutAsync();
            QueryApiButton.TouchUpInside += (s, e) => ViewModel.QueryApiAsync();

            _isConnectedBinding = this.SetBinding(() => ViewModel.IsConnected, () => IsConnectedLabel.Text).ConvertSourceToTarget(value => $"Is connected : {value}");
            _firstNameBinding = this.SetBinding(() => ViewModel.FirstName, () => FirstNameLabel.Text).ConvertSourceToTarget(value => $"First name : {value}");
            _lastNameBinding = this.SetBinding(() => ViewModel.LastName, () => LastNameLabel.Text).ConvertSourceToTarget(value => $"Last name : {value}");
            _emailBinding = this.SetBinding(() => ViewModel.Email, () => EmailLabel.Text).ConvertSourceToTarget(value => $"Email : {value}");
            _apiResponseBinding = this.SetBinding(() => ViewModel.ApiResponse, () => ApiResponseLabel.Text).ConvertSourceToTarget(value => $"API response : {value}");
        }
    }
}