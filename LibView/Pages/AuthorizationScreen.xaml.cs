using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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
using LibView.Navigator;
using LibView.Pages;
using LibView.Domain.UseCases;
using LibView.UI.Pages;

namespace LibView.Pages
{
    /// <summary>
    /// Interaction logic for AuthorizationPage.xaml
    /// </summary>
    public partial class AuthorizationScreen : UserControl
    {
        public static string backgroundURI = "pack://siteoforigin:,,,/Sources/Backgrounds/purple-and-blue-background.jpg";
        public AuthorizationScreen()
        {
            InitializeComponent();
            LottieLogin.FileName = "Sources/LottieImages/Login.json";
            ImageBrush imageBrush = new ImageBrush();
            imageBrush.ImageSource = new BitmapImage(new Uri(backgroundURI));
            this.Background = imageBrush;
        }

        private void Btn_LogIn_Click(object sender, RoutedEventArgs e)
        {
            string login = TxtBox_UserName.Text.Trim();
            string password = PassBox_Password.Password;
            var user = UserUseCase.GetUser(login);

            
            if (user != null && UserUseCase.CheckPassword(user, password))
            {
                NavigatorObject.Switch(new HomeScreen(user));
            }
            else
            {
                NavigatorObject.Switch(new AuthorizationStateScreen("login failed"));
            }

            
        }

        private void Btn_Registration_Click(object sender, RoutedEventArgs e)
        {
            NavigatorObject.Switch(new RegistrationScreen());
        }

        private void TxtBox_UserName_GotFocus(object sender, RoutedEventArgs e)
        {
            TxtBlock_LoginState.Text = "";
        }
    }
}
