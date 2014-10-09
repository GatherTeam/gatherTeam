﻿using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;
using GatherTeam.Models;
using Microsoft.WindowsAzure.MobileServices.SQLiteStore;
using Microsoft.WindowsAzure.MobileServices.Sync;
using Newtonsoft.Json.Linq;
using GatherTeam.DataBase;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkID=390556
using GatherTeam.ViewModels;

namespace GatherTeam.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class StartPage : Page
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
            Frame.Navigate(typeof (EntrancePage));
        }

        private void RegistrateHandler()
        {
            Frame.Navigate(typeof (RegisterPage));
        }
    }
}
