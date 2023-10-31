using LibView.Domain.UseCases;
using LibView.Navigator;
using LibView.Pages;
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

namespace LibView.UI.Pages
{
    /// <summary>
    /// Interaction logic for FindBookScreen.xaml
    /// </summary>
    public partial class FindBookScreen : UserControl
    {
        public FindBookScreen()
        {
            InitializeComponent();
            DefaultSet();
        }

        private void Update()
        {
            lv_Books.ItemsSource = TextUseCase.GetAllTexts();
        }

        private void DefaultSet()
        {

            HelloStr.Text = $"Hello {HomeScreen.CurrentUser.Name}!  ";
            BitmapImage bitmapImage = new BitmapImage(new Uri("pack://siteoforigin:,,,/Sources/Images/user.png"));

            Image image = new Image
            {
                Source = bitmapImage
            };

            UserIcon.Content = image;

            if (!HomeScreen.CurrentUser.IsAdmin)
            {
                AddUserItem.Visibility = Visibility.Hidden;
                AddUserItem.Height = 0;
            }


            Update();
            MenuVisabil(btn_Navigation);
        }
        private void lv_Books_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int selectedIndex = lv_Books.SelectedIndex + 1;

            if (selectedIndex >= 0)
            {
               // var selectedText = TextUseCase.GetText(selectedIndex);
               // NavigatorObject.Switch(new TextView(selectedText));
            }
        }
        private void ListBoxItem_Exit(object sender, RoutedEventArgs e)
        {
            NavigatorObject.Switch(new AuthorizationScreen());
        }

        private void ListBoxItem_ResetPass(object sender, RoutedEventArgs e)
        {

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

        private void btn_Navigation_Checked(object sender, RoutedEventArgs e)
        {
            ToggleButton btn = (ToggleButton)sender;
            MenuVisabil(btn);
        }


        private void TabControl_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            TabControl tabControl = (TabControl)sender;
            TabItem selectedTabItem = (TabItem)tabControl.SelectedItem;
            string selectedTabName = selectedTabItem.Name;
            switch (selectedTabName)
            {
                case "homeItem":
                    NavigatorObject.Switch(new HomeScreen(HomeScreen.CurrentUser));
                    break;
                case "bookItem":
                    break;
                case "poetryItem":
                    break;
                case "songsItem":
                    break;
                case "findItem":
                    break;
            }
        }
        private void btn_Navigation_Unchecked(object sender, RoutedEventArgs e)
        {
            ToggleButton btn = (ToggleButton)sender;
            MenuVisabil(btn);
        }
    }
}
