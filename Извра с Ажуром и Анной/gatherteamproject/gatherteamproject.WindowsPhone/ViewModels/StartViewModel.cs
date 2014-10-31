

using gatherteamproject.Views;

namespace gatherteamproject.ViewModels
{
    class StartViewModel : BaseViewModel
    {
        public event OpenPageDelegate EnterEvent;
        public event OpenPageDelegate RegistrateEvent;

        private DelegateCommand _enterCommand;
        private DelegateCommand _registrateCommand;

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

        public DelegateCommand RegistrateCommand
        {
            get
            {
                if (_registrateCommand == null)
                {
                    _registrateCommand = new DelegateCommand(o => Registrate());
                }

                return _registrateCommand;
            }
        }

        private void Enter()
        {
            if (EnterEvent != null) EnterEvent();
        }

        private void Registrate()
        {
            if (RegistrateEvent != null) RegistrateEvent();
        }
    }
}
