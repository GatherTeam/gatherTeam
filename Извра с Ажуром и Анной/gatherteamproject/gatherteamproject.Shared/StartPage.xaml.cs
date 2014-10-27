using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.MobileServices;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;
using gatherteamproject.ViewModels;
using gatherteamproject.Views;
using gatherteamproject;

namespace gatherteamproject.Views
{
    sealed partial class StartPage: Page
    {
        public StartPage()
        {
            this.InitializeComponent();
            var startViewModel = new StartViewModel();
            startViewModel.EnterEvent += EnterHandler;
            startViewModel.RegistrateEvent += RegistrateHandler;
            this.DataContext = startViewModel;

            // LocalDB.InitSQLiteStore();

            /*LocalDB.InsertItem(new GameModel
            {
                Format = GameModel.GameFormat.FiveToFive, 
                GameAddress = new GameAddress(), 
                GameName = "", 
                Id = "1", 
                Time = "", 
                Version = ""
            });*/
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
            Frame.Navigate(typeof(EntrancePage));
        }

        private void RegistrateHandler()
        {
            Frame.Navigate(typeof(RegisterPage));
        }
    }
}
