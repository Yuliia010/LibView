using Azure;
using LibView.DAL.Remote.OpenLibraryApiCore.Models;
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
        JsonBookUseCase searchList;
        List<Book> books;
        private int currentPage = 1;
        private int maxPages;
        public FindBookScreen()
        {
            InitializeComponent();
           
            DefaultSet();
        }

        private void Update()
        {
            books = searchList.GetPage(currentPage);
            maxPages = searchList.GetMaxPages();
            tb_maxPages.Text = maxPages.ToString();
            if (books != null)
            {
                lv_Books.ItemsSource = books;
                tb_curPage.Text = currentPage.ToString();

                if (currentPage == 1)
                {
                    btn_NextPage.IsEnabled = true;
                    btn_PrevPage.IsEnabled = false;
                }
                else if (currentPage == maxPages)
                {
                    btn_NextPage.IsEnabled = false;
                    btn_PrevPage.IsEnabled = true;

                }
                else
                {
                    btn_PrevPage.IsEnabled = true;
                    btn_NextPage.IsEnabled = true;
                }
            }
           
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

            MenuVisabil(btn_Navigation);
        }
        private void lv_Books_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Book selectedBook = (Book)lv_Books.SelectedItem;
            NavigatorObject.Switch(new ViewBookScreen(selectedBook));
          
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
                    NavigatorObject.Switch(new BooksLibScreen());
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

        private void btn_Search_Click(object sender, RoutedEventArgs e)
        {
            searchList = new JsonBookUseCase(tb_searchSrt.Text);
           
            Update();
            
        }

        private void btn_NextPage_Click(object sender, RoutedEventArgs e)
        {
            currentPage++;
            Update();
        }

        private void btn_PrevPage_Click(object sender, RoutedEventArgs e)
        {
            currentPage--;
            Update();
        }
    }
}
