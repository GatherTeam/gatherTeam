using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GatherTeam.ViewModels
{
    class SettingsViewModel : BaseViewModel
    {
        public DelegateCommand SettingsCommand
        {
            get
            {
                if (_createCommand == null)
                {
                    _createCommand = new DelegateCommand(o => Create());
                }

                return _createCommand;
            }
        }

        private void Create()
        {
            if (CreateEvent != null) CreateEvent();
        }
    }
}
