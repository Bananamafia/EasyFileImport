using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using FileImportDesktopApp.ViewModels;

namespace FileImportDesktopApp.Views
{
    /// <summary>
    /// Interaktionslogik für StartupView.xaml
    /// </summary>
    public partial class StartupView : Window
    {
        private StartupViewModel _viewModel;

        public StartupView()
        {
            InitializeComponent();
            _viewModel = new StartupViewModel();
            this.DataContext = _viewModel;

            DeviceDialogView deviceDialogView = new DeviceDialogView(@"C:\Users\maxim\Desktop\Auswahl");
            deviceDialogView.Show();

            Thread thread = new Thread(LoadApp);
            thread.Start();
        }

        private void LoadApp()
        {
            Thread.Sleep(2500);
            Dispatcher.Invoke(HideStartupWindow);
        }

        private void HideStartupWindow()
        {
            this.Hide();

            System.Windows.Forms.NotifyIcon notificationIcon = new System.Windows.Forms.NotifyIcon();
            notificationIcon.Icon = new System.Drawing.Icon("../../../Resources/Icons/appIcon.ico");
            notificationIcon.Visible = true;

            notificationIcon.DoubleClick +=
                delegate (object sender, EventArgs args)
                {
                    System.Windows.MessageBox.Show("Zeige die angeschlossenen Geräte an");
                };
        }
    }
}
