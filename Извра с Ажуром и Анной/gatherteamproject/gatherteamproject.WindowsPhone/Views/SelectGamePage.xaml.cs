using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
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
        
            this.NavigationCacheMode = NavigationCacheMode.Required;
            var dateGroups =
                        from item in FakeSourceData.GetData()
                        group item by item.Date into dateGroup
                        select new DateGroup(FlattenedTownGroupsForCountry(dateGroup))
                        {
                            Date = dateGroup.Key
                        };

            var cvs = (CollectionViewSource)Resources["src"];
            cvs.Source = dateGroups.ToList();

            /*var groups = new ViewModels.UserViewModel();
            var gr = groups.OpenSelectGame();
            this.NavigationCacheMode = NavigationCacheMode.Required;
            var cvs = (CollectionViewSource)Resources["src"];
            cvs.Source = gr.ToList();*/
        }
        public static IEnumerable<object> ItemsForTimeGroup(IGrouping<string, FakeSourceData> timeGroup)
        {
            object[] groupItemAsList = { new TimeGroup { Time = timeGroup.Key } };
            return groupItemAsList.Concat(timeGroup);
        }

        public static IEnumerable<object> FlattenedTownGroupsForCountry(IEnumerable<FakeSourceData> dateGroup)
        {
            return dateGroup.GroupBy(item => item.Time).SelectMany(ItemsForTimeGroup);
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
