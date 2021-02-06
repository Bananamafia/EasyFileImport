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
        }
    }
}
