using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileImportDesktopApp.Models
{
    class TimePeriodPicker
    {
        public TimePeriodPicker(TimePeriod selectedTimePeriod, DateTime customBeginningDate, DateTime customEndingDate)
        {
            switch (selectedTimePeriod)
            {
                case TimePeriod.allTime:
                    BeginningDate = DateTime.MinValue;
                    break;
                case TimePeriod.today:
                    BeginningDate = DateTime.Today;
                    break;
                case TimePeriod.pastThreeDays:
                    BeginningDate = DateTime.Today.AddDays(-3);
                    break;
                case TimePeriod.pastWeek:
                    BeginningDate = DateTime.Today.AddDays(-7);
                    break;
                case TimePeriod.custom:
                    BeginningDate = customBeginningDate;
                    EndingDate = customEndingDate;
                    break;
            }
        }

        public enum TimePeriod
        {
            allTime,
            today,
            pastThreeDays,
            pastWeek,
            custom
        }

        public DateTime BeginningDate { get; set; }
        public DateTime EndingDate { get; set; } = DateTime.Today;
    }
}
