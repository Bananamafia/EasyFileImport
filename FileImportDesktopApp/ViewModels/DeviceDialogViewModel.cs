using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FileImportDesktopApp.ViewModels.Commands;

namespace FileImportDesktopApp.ViewModels
{
    class DeviceDialogViewModel : INotifyPropertyChanged
    {
        public DeviceDialogViewModel(string deviceName)
        {
            DeviceName = deviceName;
        }

        public string DeviceName { get; private set; }

        public int SelectedFilesCount { get; } //Todo: return FileList.Length


        private Models.TimePeriodPicker.TimePeriod _selectedTimePeriod;
        public Models.TimePeriodPicker.TimePeriod SelectedTimePeriod
        {
            get { return _selectedTimePeriod; }
            set
            {
                _selectedTimePeriod = value;
                OnPropertyChanged("SelectedTimePeriod");
                OnPropertyChanged("SelectedFilesCount");
            }
        }


        #region ---Commands---
        private ImportFilesCommand importFilesCommand;
        public ImportFilesCommand ImportFilesCommand
        {
            get
            {
                importFilesCommand = new ImportFilesCommand();
                return importFilesCommand;
            }
            set { importFilesCommand = value; }
        }
        #endregion

        #region---INotifyPropertyChanged---
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string property)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(property));
            }
        }
        #endregion
    }
}
