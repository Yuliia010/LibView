﻿using LibView.DAL.Models;
using LibView.Domain.UseCases;
using LibView.Navigator;
using LibView.Pages;
using LibView.UI.Pages;
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

namespace LibView
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        
        public MainWindow()
        {
            InitializeComponent();
            BooksLibScreen.bookList = TextUseCase._texts;

            this.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            NavigatorObject.pageSwitcher = this;
            NavigatorObject.Switch(new AuthorizationScreen());
        }

        public void Navigate(UserControl nextPage)
        {
            this.Content = nextPage;
        }
    }
}
