using GatherTeam.Models;
using GatherTeam.Views;

namespace GatherTeam.ViewModels
{
    class UserViewModel : BaseViewModel
    {
        private string _login;
        private string _email;
        private string _password;
        private string _confirmPassword;
        private string _phone;
        public event OpenPageDelegate OpenProfileEvent;
        public event OpenPageDelegate OpenRegistrateEvent;
        public string Login
        {
            get { return _login; }
            set
            {
                _login = value;
                NotifyPropertyChanged("Login");
            } 
        }

        public string Email
        {
            get
            {
                return _email;
            }
            set
            {
                _email = value;
                NotifyPropertyChanged("Email");
            }
        }

        public string Password
        {
            get
            {
                return _password;
            }
            set
            {
                _password = value;
                NotifyPropertyChanged("Password");
            }
        }
        public string ConfirmPassword
        {
            get
            {
                return _confirmPassword;
            }
            set
            {
                _confirmPassword = value;
                NotifyPropertyChanged("ConfirmPassword");
            }
        }

        public string Phone
        {
            get
            {
                return _phone;
            }
            set
            {
                _phone = value;
                NotifyPropertyChanged("Phone");
            }
        }

        private DelegateCommand _createProfile;

        public DelegateCommand CreateProfile
        {
            get
            {
                if (_createProfile == null)
                {
                    _createProfile = new DelegateCommand(o => Registrate());
                }

                return _createProfile;
            }
        }

        // отсюда можно записывать данные о пользователе в БД
        private void Registrate()
        {
            if (CheckData())
            {
                var newUser = new UserModel {Email = Email, Login = Login, Password = Password, Phone = Phone};
                if (OpenProfileEvent != null) OpenProfileEvent();
            }
            else
            {
                if (OpenRegistrateEvent != null) OpenRegistrateEvent();
            }
        }

        private bool CheckData()
        {
            return string.IsNullOrWhiteSpace(Login) && 
                string.IsNullOrWhiteSpace(Email) && 
                string.IsNullOrWhiteSpace(Password) && 
                string.IsNullOrWhiteSpace(ConfirmPassword) && 
                (Password == ConfirmPassword);
        }
    }
}
