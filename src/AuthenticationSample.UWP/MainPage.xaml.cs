using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;
using AuthenticationSample.ViewModels;

namespace AuthenticationSample.UWP
{
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            InitializeComponent();
        }

        public MainViewModel ViewModel { get; } = new MainViewModel();

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            ViewModel.Load();
        }
    }
}
