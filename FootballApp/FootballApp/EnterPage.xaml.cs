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
    public partial class EnterPage : PhoneApplicationPage
    {
        public EnterPage()
        {
            InitializeComponent();
        }

        //Возврат к предыдущей странице 
        private void BackToMain_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void EnterAccount_Ok_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/Account.xaml", UriKind.Relative));
        }
    }
}