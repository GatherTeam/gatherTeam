using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;
using gatherteamproject.ViewModels;

namespace gatherteamproject.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class CreateGamePage : Page
    {
        
        public CreateGamePage()
        {
            InitializeComponent();
            var createGameVm = new CreateGameVM();
            createGameVm.OpenMapEvent += EnterHandler;
            DataContext = createGameVm;

        }

        /// <summary>
        /// Invoked when this page is about to be displayed in a Frame.
        /// </summary>
        /// <param name="e">Event data that describes how this page was reached.
        /// This parameter is typically used to configure the page.</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            
        }

        private void EnterHandler()
        {
            Frame.Navigate(typeof(MapPage));
        }

    }
}
