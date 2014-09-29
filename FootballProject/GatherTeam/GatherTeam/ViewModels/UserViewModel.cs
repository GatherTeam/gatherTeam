using GatherTeam.Views;

namespace GatherTeam.ViewModels
{
    class UserViewModel : BaseViewModel
    {
        public event OpenPageDelegate OpenCreateGamePage;
        public event OpenPageDelegate OpenCreateTournamentPage;
        private DelegateCommand _createGame;
        private DelegateCommand _createTournament;

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

        private void CreateTournament()
        {
            if (OpenCreateTournamentPage != null) OpenCreateTournamentPage();
        }
    }
}
