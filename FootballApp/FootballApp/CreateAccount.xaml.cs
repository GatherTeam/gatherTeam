using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;


namespace FootballApp
{
    public partial class CreateAccount : PhoneApplicationPage
    {
        public CreateAccount()
        {
            InitializeComponent();
        }

        //Занести данные в Базу данных всех аккаунтов, а также сообщения об ошибках
        private void EnterAccountData_Click(object sender, RoutedEventArgs e)
        {
            if (PhoneTextBox.Text == "" && EmailBox.Text == "")
            {
                MessageBox.Show("Необходимо ввести либо номер телефона либо указать почту для связи с Вами");
            }

            if (PasswordTextBox.Password != ConfirmPasswordTextBox.Password)
            {
                MessageBox.Show("Пароль не совпадает");
            }
        }
        //Воврат к предыдущей странице
        private void BackToMain_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}