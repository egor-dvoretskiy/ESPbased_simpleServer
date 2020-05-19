using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Drawing;

namespace ESP_pairing_PC
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        System.Windows.Forms.NotifyIcon nIcon = new System.Windows.Forms.NotifyIcon();

        public App()
        {
            nIcon.Icon = new Icon(@"../../cat.ico");
            nIcon.Visible = true;
            nIcon.ShowBalloonTip(1000, "ergo", "ESP_pairing_PC", System.Windows.Forms.ToolTipIcon.Info);
            nIcon.DoubleClick += nIcon_Click;
            Application.Current.Exit += Current_Exit;
        }

        private void Current_Exit(object sender, ExitEventArgs e)
        {
            nIcon.Icon.Dispose();
            nIcon.Dispose();
        }

        private void nIcon_Click(object sender, EventArgs e)
        {
            MainWindow.Visibility = Visibility.Visible;
            MainWindow.WindowState = WindowState.Normal;
        }
        
    }
}

