using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using LibView.Pages;
using LibView.Services.Services;

namespace LibView.Pages
{
    /// <summary>
    /// Interaction logic for AuthorizationPage.xaml
    /// </summary>
    public partial class AuthorizationScreen : UserControl
    {
        public AuthorizationScreen()
        {
            InitializeComponent(); 

        }

        private void Btn_LogIn_Click(object sender, RoutedEventArgs e)
        {
            string login = TxtBox_UserName.Text.Trim();
            string password = PassBox_Password.Password;

            //MessageBox.Show($"Its user {login}, {password}");
            var user = UserService.GetUser(login);

            if (user != null)
            {
                if (UserService.CheckPassword(user, password))
                {
                    MessageBox.Show("Login success!");

                }
                else
                {
                    MessageBox.Show("Incorrect input!");
                }

            }

        }

        private void Btn_Cancel_Click(object sender, RoutedEventArgs e)
        {
            return;
        }
    }
}
