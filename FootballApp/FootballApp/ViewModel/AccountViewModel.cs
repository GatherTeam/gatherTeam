using System.ComponentModel;
using FootballApp.Model;

namespace FootballApp.ViewModel
{
    public class AccountViewModel : INotifyPropertyChanged
    {
        public CreateAccountModel CreateAccountModel;

        public AccountViewModel(CreateAccountModel createAccountModel)
        {
            CreateAccountModel = createAccountModel;
        }

        public string Name
        {
            get { return CreateAccountModel.Name; }
            set
            {
                CreateAccountModel.Name = value;
                RaisePropertyChanged("Name");
            }
        }

        public string Password
        {
            get { return CreateAccountModel.Password; }
            set
            {
                CreateAccountModel.Password = value;
                RaisePropertyChanged("Password");
            }
        }

        public string Phone
        {
            get { return CreateAccountModel.Phone; }
            set
            {
                CreateAccountModel.Phone = value;
                RaisePropertyChanged("Phone");
            }
        }

        public string Address
        {
            get { return CreateAccountModel.Address; }
            set
            {
                CreateAccountModel.Address = value;
                RaisePropertyChanged("Address");
            }
        }


        public string Email
        {
            get { return CreateAccountModel.Email; }
            set
            {
                CreateAccountModel.Email = value;
                RaisePropertyChanged("Email");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void RaisePropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
