using Microsoft.Win32;
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
    /// Interaction logic for AddTextScreen.xaml
    /// </summary>
    public partial class AddTextScreen : UserControl
    {
        public AddTextScreen()
        {
            InitializeComponent();
        }


        private void AddPic_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Зображення|*.jpg;*.png;*.gif;*.bmp|Всі файли|*.*";

            if (openFileDialog.ShowDialog() == true)
            {
                string filePath = openFileDialog.FileName;
                BitmapImage bitmapImage = new BitmapImage(new Uri(filePath));
                Image.Source = bitmapImage;
            }
        }
    }
}
