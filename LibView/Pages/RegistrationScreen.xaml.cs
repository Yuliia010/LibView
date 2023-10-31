using LibView.Navigator;
using LibView.Pages;
using LibView.Domain.UseCases;
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
using System.Xml.Linq;
using LibView.DAL.Models;

namespace LibView.UI.Pages
{
    /// <summary>
    /// Interaction logic for RegistrationScreen.xaml
    /// </summary>
    public partial class RegistrationScreen : UserControl
    {
        public RegistrationScreen()
        {
            InitializeComponent();
            LottieLogin.FileName = "Sources/LottieImages/Login.json";
            ImageBrush imageBrush = new ImageBrush();
            imageBrush.ImageSource = new BitmapImage(new Uri(AuthorizationScreen.backgroundURI));
            this.Background = imageBrush;
        }

        private void Btn_SignUp_Click(object sender, RoutedEventArgs e)
        {
            if(TxtBox_UserFullName.Text != string.Empty && TxtBox_UserName.Text != string.Empty && PassBox_Password.Password != string.Empty)
            {
                User newUser = new User();
                newUser.Name = TxtBox_UserFullName.Text;
                newUser.login = TxtBox_UserName.Text;
                newUser.password = PassBox_Password.Password;
                newUser.IsAdmin = CheckB_isAdmin.IsChecked == true;

                UserUseCase.Add(newUser);

                NavigatorObject.Switch(new AuthorizationStateScreen("registration success"));

            }
            else
            {
                NavigatorObject.Switch(new AuthorizationStateScreen("registration failed"));
            }
           
        }

        private void Btn_Cancel_Click(object sender, RoutedEventArgs e)
        {
            NavigatorObject.Switch(new AuthorizationScreen());
        }
    }
}
