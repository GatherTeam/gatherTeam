using System;
using System.Windows;
using Microsoft.Phone.Controls;

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
            NavigationService.Navigate(new Uri("/../Views/Account.xaml", UriKind.Relative));
        }
    }
}