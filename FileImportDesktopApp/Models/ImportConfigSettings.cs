using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileImportDesktopApp.Models
{
    public class ImportConfigSettings
    {
        public ImportConfigSettings(string devicePath)
        {
            _devicePath = devicePath;
        }

        private string _devicePath;
        public string DevicePath
        {
            get { return _devicePath; }
        }

        public TimePeriod TimePeriod { get; set; } = TimePeriod.allTime;

        public DateTime BeginningDate { get; set; } = DateTime.Today;
        public DateTime EndingDate { get; set; } = DateTime.Today;
        public SearchOption DirectoryDepth { get; set; } = SearchOption.AllDirectories;
    }
}
