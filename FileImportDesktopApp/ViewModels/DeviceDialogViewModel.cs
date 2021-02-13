using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FileImportDesktopApp.Models;
using FileImportDesktopApp.ViewModels.Commands;

namespace FileImportDesktopApp.ViewModels
{
    class DeviceDialogViewModel : INotifyPropertyChanged
    {
        public DeviceDialogViewModel(string devicePath)
        {
            DevicePath = devicePath;
        }

        private string _devicePath;
        public string DevicePath
        {
            get
            { return _devicePath; }
            set
            {
                _devicePath = value;
                OnPropertyChanged("DevicePath");
                OnPropertyChanged("SelectedFilesCount");
            }
        }

        public int SelectedFilesCount { get; set; }


        private TimePeriod _selectedTimePeriod;

        public TimePeriod SelectedTimePeriod
        {
            get { return _selectedTimePeriod; }
            set
            {
                _selectedTimePeriod = value;
                OnPropertyChanged("SelectedTimePeriod");
                OnPropertyChanged("SelectedFilesCount");
            }
        }


        //---Commands---
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


        //---INotifyPropertyChanged---
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string property)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(property));
            }
        }
    }
}
