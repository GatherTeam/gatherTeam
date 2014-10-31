// Документацию по шаблону элемента пустой страницы см. по адресу http://go.microsoft.com/fwlink/?LinkID=390556
//using GatherTeam.DataBase;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;
using gatherteamproject.ViewModels;

namespace gatherteamproject.Views
{
    /// <summary>
    /// Пустая страница, которую можно использовать саму по себе или для перехода внутри фрейма.
    /// </summary>
    sealed partial class EntrancePage : Page
    {
        public EntrancePage()
        {
            this.InitializeComponent();
            var entranceViewModel = new EntranceViewModel();
            entranceViewModel.EnterEvent += EnterHandler;
            //            LocalDB.Push();
            this.DataContext = entranceViewModel;
        }

        /// <summary>
        /// Вызывается перед отображением этой страницы во фрейме.
        /// </summary>
        /// <param name="e">Данные события, описывающие, каким образом была достигнута эта страница.
        /// Этот параметр обычно используется для настройки страницы.</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
        }

        private void EnterHandler()
        {
            Frame.Navigate(typeof(UserPage));
        }
    }
}
