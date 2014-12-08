
using Windows.Foundation;
using Windows.Foundation.Collections;
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
using gatherteamproject.Views;


namespace gatherteamproject.ViewModels
{
    class UserViewModel : BaseViewModel
    {
        public event OpenPageDelegate OpenCreateGamePage;
        public event OpenPageDelegate OpenSettingsPage;
        public event OpenPageDelegate OpenCreateTournamentPage;
        private DelegateCommand _createGame;
        private DelegateCommand _openSettings;
        private DelegateCommand _createTournament;

        public event OpenPageDelegate OpenSelectGamePage;
        private DelegateCommand _openSelectGamePage;


        public DelegateCommand CreateGameCommand
        {
            get
            {
                if (_createGame == null)
                {
                    _createGame = new DelegateCommand(o => CreateGame());
                }

                return _createGame;
            }
        }

        public DelegateCommand SelectGameCommand
        {
            get
            {
                if (_openSelectGamePage == null)
                {
                    _openSelectGamePage = new DelegateCommand(o => OpenSelectGame());
                }

                return _openSelectGamePage;
            }

        }

        public DelegateCommand SettingsCommand
        {
            get
            {
                if (_openSettings == null)
                {
                    _openSettings = new DelegateCommand(o => OpenSettings());
                }

                return _openSettings;
            }
        }

        public DelegateCommand CreateTournamentCommand
        {
            get
            {
                if (_createTournament == null)
                {
                    _createTournament = new DelegateCommand(o => CreateTournament());
                }

                return _createTournament;
            }
        }

        private void CreateGame()
        {
            if (OpenCreateGamePage != null) OpenCreateGamePage();
        }

        private void OpenSettings()
        {
            if (OpenSettingsPage != null) OpenSettingsPage();
        }


        public void OpenSelectGame() {
            if (OpenSelectGamePage != null) OpenSelectGamePage();
        }
        /*public IEnumerable<DataGroup> OpenSelectGame()
        {
            IEnumerable<DataGroup> groups =
                from item in FakeSourceData.GetData()
                group item by item.Data
                    into dataGroup
                    let dataGroupItems =
                        from item2 in dataGroup
                        group item2 by item2.Time
                            into timeGroup
                            select new TimeGroup(timeGroup)
                            {
                                Time = timeGroup.Key
                            }
                    select new DataGroup(dataGroupItems)
                    {
                        Data = dataGroup.Key
                    };

            return groups;
        }*/

        private void CreateTournament()
        {
            //if (OpenCreateTournamentPage != null) OpenCreateTournamentPage();
        }
    }
}
