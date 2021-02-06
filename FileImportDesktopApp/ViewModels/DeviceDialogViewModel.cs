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

        private string _deviceName;
        public string DeviceName
        {
            get
            { return _deviceName; }
            set
            {
                _deviceName = value;
                OnPropertyChanged("DeviceName");
                OnPropertyChanged("SelectedFilesCount");
            }
        }

        public int SelectedFilesCount { get; set; }

        public enum TimePeriod
        {
            allTime,
            today,
            pastThreeDays,
            pastWeek,
            custom
        }

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
