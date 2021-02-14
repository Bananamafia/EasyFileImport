using FileImportDesktopApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace FileImportDesktopApp.ViewModels.Commands
{
    class ImportFilesCommand : ICommand
    {
        public ImportFilesCommand(ImportConfigSettings configSettings)
        {
            ConfigSettings = configSettings;
        }

        private ImportConfigSettings ConfigSettings { get; set; }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
            //throw new NotImplementedException();
        }

        public void Execute(object parameter)
        {
            MessageBox.Show(ConfigSettings.BeginningDate.ToString());
            //throw new NotImplementedException();
        }
    }
}
