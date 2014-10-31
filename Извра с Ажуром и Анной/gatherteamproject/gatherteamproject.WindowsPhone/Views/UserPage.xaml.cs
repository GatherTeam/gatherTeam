// Документацию по шаблону элемента пустой страницы см. по адресу http://go.microsoft.com/fwlink/?LinkID=390556
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;
using gatherteamproject.ViewModels;

namespace gatherteamproject.Views
{
    /// <summary>
    /// Пустая страница, которую можно использовать саму по себе или для перехода внутри фрейма.
    /// </summary>
    sealed partial class UserPage : Page
    {
        public UserPage()
        {
            this.InitializeComponent();
            var userProgileViewModel = new UserViewModel();
            userProgileViewModel.OpenCreateGamePage += OpenProfilePageHandler;
            userProgileViewModel.OpenCreateTournamentPage += OpenProfilePageHandler;
            userProgileViewModel.OpenSettingsPage += OpenSettingsPageHandler;
            userProgileViewModel.OpenSelectGamePage += OpenSelectGamePageHandler;
            this.DataContext = userProgileViewModel;
        }

        /// <summary>
        /// Вызывается перед отображением этой страницы во фрейме.
        /// </summary>
        /// <param name="e">Данные события, описывающие, каким образом была достигнута эта страница.
        /// Этот параметр обычно используется для настройки страницы.</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
        }

        private void OpenProfilePageHandler()
        {
            Frame.Navigate(typeof(CreateGamePage));
        }

        private void OpenSelectGamePageHandler()
        {
            Frame.Navigate(typeof(SelectGamePage));
        }

        private void OpenSettingsPageHandler()
        {
            Frame.Navigate(typeof(SettingsPage));
        }
    }
}
