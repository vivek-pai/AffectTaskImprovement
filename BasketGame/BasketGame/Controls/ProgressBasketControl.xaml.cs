﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace BasketGame
{
    /// <summary>
    /// Interaction logic for ProgressBasketControl.xaml
    /// </summary>
    public partial class ProgressBasketControl : UserControl
    {
        private DispatcherTimer hoverFlashTimer;
        public ProgressBasketControl()
        {
            InitializeComponent();

            hoverFlashTimer = new DispatcherTimer();
            hoverFlashTimer.Interval = TimeSpan.FromSeconds(1);
            hoverFlashTimer.Tick += new EventHandler(hoverFlashTimer_Tick);

            this.Loaded += new RoutedEventHandler(ProgressBasketControl_Loaded);
        }

        void ProgressBasketControl_Loaded(object sender, RoutedEventArgs e)
        {
            ((ViewModel)DataContext).ItemCaught += new EventHandler(FallingItemControl_ItemCaught);
        }

        void hoverFlashTimer_Tick(object sender, EventArgs e)
        {
            hoverFlashTimer.Stop();
            BasketFlash.Visibility = System.Windows.Visibility.Hidden;
        }

        void FallingItemControl_ItemCaught(object sender, EventArgs e)
        {
            BasketFlash.Visibility = System.Windows.Visibility.Visible;

            if(!hoverFlashTimer.IsEnabled)
                hoverFlashTimer.Start();
        }
    }
}
