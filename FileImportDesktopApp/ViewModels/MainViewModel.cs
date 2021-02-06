using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileImportDesktopApp.ViewModels
{
    class MainViewModel : INotifyPropertyChanged
    {
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
