using LibView.DAL.Remote.OpenLibraryApiCore.Models;
using LibView.Domain.UseCases;
using LibView.Navigator;
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
    /// Interaction logic for ViewBookScreen.xaml
    /// </summary>
    public partial class ViewBookScreen : UserControl
    {
        public ViewBookScreen(Book book)
        {
            InitializeComponent();
            this.DataContext = BookInfoUseCase.GetBookInfo(book);
        }
        private void Back_Click(object sender, RoutedEventArgs e)
        {
            NavigatorObject.Switch(new FindBookScreen());
        }
    }
}
