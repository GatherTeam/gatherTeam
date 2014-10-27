using gatherteamproject.Views;

namespace gatherteamproject.ViewModels
{
    class EntranceViewModel : BaseViewModel
    {
        public event OpenPageDelegate EnterEvent;
        private DelegateCommand _enterCommand;

        public DelegateCommand EnterCommand
        {
            get
            {
                if (_enterCommand == null)
                {
                    _enterCommand = new DelegateCommand(o => Enter());
                }

                return _enterCommand;
            }
        }

        private void Enter()
        {
            if (EnterEvent != null) EnterEvent();
            //LocalDB.InitSQLiteStore();
        }
    }
}
