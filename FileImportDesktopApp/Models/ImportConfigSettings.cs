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

        private DateTime _beginningDate;
        public DateTime BeginningDate
        {
            get
            {
                switch (TimePeriod)
                {
                    case TimePeriod.allTime:
                        _beginningDate = DateTime.MinValue;
                        break;
                    case TimePeriod.today:
                        _beginningDate = DateTime.Today;
                        break;
                    case TimePeriod.pastThreeDays:
                        _beginningDate = DateTime.Today.AddDays(-3);
                        break;
                    case TimePeriod.pastWeek:
                        _beginningDate = DateTime.Today.AddDays(-7);
                        break;
                    case TimePeriod.custom:
                        break;
                }

                return _beginningDate;
            }
            set
            {
                _beginningDate = value;
                TimePeriod = TimePeriod.custom;
            }
        }

        private DateTime _endingDate;
        public DateTime EndingDate
        {
            get
            {
                switch (TimePeriod)
                {
                    case TimePeriod.custom:
                        break;
                    default:
                        _endingDate = DateTime.Today;
                        break;
                }
                return _endingDate;
            }
            set
            {
                _endingDate = value;
                TimePeriod = TimePeriod.custom;
            }
        }

        public SearchOption DirectoryDepth { get; set; } = SearchOption.AllDirectories;
    }
}
