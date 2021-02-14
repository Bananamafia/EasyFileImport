using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
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
            _configSettings = new ImportConfigSettings(devicePath);
        }

        private ImportConfigSettings _configSettings;

        public string DevicePath
        {
            get { return _configSettings.DevicePath; }
        }

        public int SelectedFilesCount
        {
            get { return Directory.GetFiles(_configSettings.DevicePath).Length; }
        }


        public TimePeriod SelectedTimePeriod
        {
            get { return _configSettings.TimePeriod; }
            set
            {
                _configSettings.TimePeriod = value;
                OnPropertyChanged("SelectedTimePeriod");
                OnPropertyChanged("SelectedFilesCount");
            }
        }

        public DateTime BeginningDate
        {
            get { return _configSettings.BeginningDate; }
            set
            {
                _configSettings.BeginningDate = value;
                OnPropertyChanged("BeginningDate");
                OnPropertyChanged("SelectedFilesCount");
            }
        }

        public DateTime EndingDate
        {
            get { return _configSettings.EndingDate; }
            set
            {
                _configSettings.EndingDate = value;
                OnPropertyChanged("EndingDate");
                OnPropertyChanged("SelectedFilesCount");
            }
        }

        //---Commands---
        private ImportFilesCommand importFilesCommand;
        public ImportFilesCommand ImportFilesCommand
        {
            get
            {
                importFilesCommand = new ImportFilesCommand(_configSettings);
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
