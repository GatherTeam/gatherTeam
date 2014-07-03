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
    public partial class Account : PhoneApplicationPage
    {
        public Account()
        {
            InitializeComponent();
        }

        private void EnterAccountData_Click(object sender, RoutedEventArgs e)
        {
            if (PhoneTextBox.Text == "" && EmailBox.Text == "")
            {
                MessageBox.Show("Необходимо ввести либо номер телефона либо указать почту для связи с Вами");
            }

            if (PasswordTextBox.Text != ConfirmPasswordTextBox.Text)
            {
                MessageBox.Show("Пароль не совпадает");
            }
        }
    }
}