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
using System.Windows.Shapes;
using FileImportDesktopApp.ViewModels;

namespace FileImportDesktopApp.Views
{
    public partial class DeviceDialogView : Window
    {
        private DeviceDialogViewModel _viewModel;

        public DeviceDialogView(string deviceName)
        {
            InitializeComponent();
            _viewModel = new DeviceDialogViewModel(deviceName);
            this.DataContext = _viewModel;
        }

        private void CancleButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
