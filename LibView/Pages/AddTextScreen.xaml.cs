using LibView.Domain.UseCases;
using LibView.Navigator;
using LibView.Pages;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Automation.Provider;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using static System.Net.Mime.MediaTypeNames;
using Text = LibView.DAL.Models.Text;

namespace LibView.UI.Pages
{
    /// <summary>
    /// Interaction logic for AddTextScreen.xaml
    /// </summary>
    public partial class AddTextScreen : UserControl
    {
        string imagePath;
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
                imagePath = openFileDialog.FileName;
                BitmapImage bitmapImage = new BitmapImage(new Uri(imagePath));
                Image.Source = bitmapImage;
            }
        }

        private void Cencel_Click(object sender, RoutedEventArgs e)
        {
            NavigatorObject.Switch(new BooksLibScreen());
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            if (TxtBox_TextName.Text != string.Empty || TxtBox_Text.Text != string.Empty)
            {
                Text text = new Text();
                text.Name = TxtBox_TextName.Text;
                text.Description = TxtBox_Description.Text;
                text.TranslText = TxtBox_TranslText.Text;
                text.EngText = TxtBox_Text.Text;
                byte[] byteImage;
                if (imagePath != string.Empty && imagePath != null)
                {
                    byteImage = File.ReadAllBytes(imagePath);
                   
                }
                else
                {
                    byteImage = File.ReadAllBytes("Sources/Images/default_translate_icon.png");
                }

                text.Image = byteImage;

                TextUseCase.Add(text);

                NavigatorObject.Switch(new BooksLibScreen());
            }
            else
            {
                MessageBox.Show("Invalid inputs");
            }
            

            
        }
    }
}
