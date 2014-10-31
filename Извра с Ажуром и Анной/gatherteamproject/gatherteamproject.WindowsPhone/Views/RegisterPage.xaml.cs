// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=391641

using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;
using gatherteamproject.ViewModels;

namespace gatherteamproject.Views
{
    public delegate void OpenPageDelegate();
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    sealed partial class RegisterPage : Page
    {
        public RegisterPage()
        {
            this.InitializeComponent();
            var registerViewModel = new RegisterViewModel();
            registerViewModel.OpenProfileEvent += OpenProfilePageHandler;
            registerViewModel.OpenRegistrateEvent += OpenRegistrateHandler;
            this.DataContext = registerViewModel;
            this.NavigationCacheMode = NavigationCacheMode.Required;
        }

        private void OpenProfilePageHandler()
        {
            Frame.Navigate(typeof(UserPage));
        }

        private void OpenRegistrateHandler()
        {
            Frame.Navigate(typeof(RegisterPage));
        }

        /// <summary>
        /// Invoked when this page is about to be displayed in a Frame.
        /// </summary>
        /// <param name="e">Event data that describes how this page was reached.
        /// This parameter is typically used to configure the page.</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            // TODO: Prepare page for display here.

            // TODO: If your application contains multiple pages, ensure that you are
            // handling the hardware Back button by registering for the
            // Windows.Phone.UI.Input.HardwareButtons.BackPressed event.
            // If you are using the NavigationHelper provided by some templates,
            // this event is handled for you.
        }



    }
}
