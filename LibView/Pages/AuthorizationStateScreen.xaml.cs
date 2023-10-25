using LibView.Navigator;
using LibView.Pages;
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

namespace LibView.UI.Pages
{
    /// <summary>
    /// Interaction logic for AuthorizationStateScreen.xaml
    /// </summary>
    public partial class AuthorizationStateScreen : UserControl
    {
        private string _state;
        public AuthorizationStateScreen(string state)
        {
            InitializeComponent();
            _state = state;
            ImageBrush imageBrush = new ImageBrush();
            imageBrush.ImageSource = new BitmapImage(new Uri(AuthorizationScreen.backgroundURI));
            this.Background = imageBrush;
            SetLottie();
        }

        private void SetLottie()
        {
            switch(_state)
            {
                case "login failed":
                    LottieState.FileName = "Sources/LottieImages/error.json";
                    Btn_Go.Content = "_TRY AGAIN!";
                    break;
                case "registration success":
                    LottieState.FileName = "Sources/LottieImages/success1.json";
                    Btn_Go.Content = "_GO TO LOGIN";
                    break;
                case "registration failed":
                    LottieState.FileName = "Sources/LottieImages/error.json";
                    Btn_Go.Content = "_TRY AGAIN!";
                    break;
            }
        }

        private void Btn_Go_Click(object sender, RoutedEventArgs e)
        {
            
            if(_state == "login failed" || _state == "registration success")
            {
                NavigatorObject.Switch(new AuthorizationScreen());
            }
            else if (_state == "registration failed")
            {
                NavigatorObject.Switch(new RegistrationScreen());
            }
        }
    }
}
