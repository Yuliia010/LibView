﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace LibView.Navigator
{
    public class NavigatorObject
    {

        public static MainWindow? pageSwitcher;
        public static void Switch(UserControl newPage)
        {
            pageSwitcher?.Navigate(newPage);
        }

    }
}
