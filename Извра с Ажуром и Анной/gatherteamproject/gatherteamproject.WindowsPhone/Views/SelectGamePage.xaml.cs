using System.Linq;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Navigation;

// Документацию по шаблону элемента пустой страницы см. по адресу http://go.microsoft.com/fwlink/?LinkID=390556

namespace gatherteamproject.Views
{
    /// <summary>
    /// Пустая страница, которую можно использовать саму по себе или для перехода внутри фрейма.
    /// </summary>
    sealed partial class SelectGamePage : Page
    {
        public SelectGamePage()
        {
            this.InitializeComponent();
            var groups = new ViewModels.UserViewModel();
            var gr = groups.OpenSelectGame();
            this.NavigationCacheMode = NavigationCacheMode.Required;
            var cvs = (CollectionViewSource)Resources["src"];
            cvs.Source = gr.ToList();
        }

        /// <summary>
        /// Вызывается перед отображением этой страницы во фрейме.
        /// </summary>
        /// <param name="e">Данные события, описывающие, каким образом была достигнута эта страница.
        /// Этот параметр обычно используется для настройки страницы.</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
        }
    }
}
