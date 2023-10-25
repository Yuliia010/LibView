using LibView.DAL.Models;
using LibView.Navigator;
using LibView.UI.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace LibView.Pages
{
    /// <summary>
    /// Interaction logic for HomePage.xaml
    /// </summary>
    public partial class HomeScreen : UserControl
    {
        public User CurrentUser { get; set; }
        public HomeScreen(User currentUser)
        {
            InitializeComponent();
            CurrentUser = currentUser;
            this.DataContext = CurrentUser;
            DefaultSet();
        }

        private void DefaultSet()
        {
            HelloStr.Text = $"Hello {CurrentUser.Name}!  ";
            BitmapImage bitmapImage = new BitmapImage(new Uri("pack://siteoforigin:,,,/Sources/Images/user.png"));

            Image image = new Image
            {
                Source = bitmapImage
            };

            UserIcon.Content = image;

            if (!CurrentUser.IsAdmin)
            {
                AddUserItem.Visibility = Visibility.Hidden;
                AddUserItem.Height = 0;
            }

            MenuVisabil(btn_MenuShow);
        }
        private void MenuVisabil(ToggleButton btn)
        {
            if (btn.IsChecked == true)
            {
                card_navigation.Width = double.NaN;

            }
            else
            {
                card_navigation.Width = 0;
            }
        }
        private void btn_MenuShow_Click(object sender, RoutedEventArgs e)
        {
            ToggleButton btn = (ToggleButton)sender;
            MenuVisabil(btn);
        }

        private void ListBoxItem_Exit(object sender, RoutedEventArgs e)
        {
            NavigatorObject.Switch(new AuthorizationScreen());
        }

        private void TabItemHome_GotFocus(object sender, RoutedEventArgs e)
        {

        }

        private void ListBoxItem_ResetPass(object sender, RoutedEventArgs e)
        {

        }

    }
}
