using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Management;
using System.Windows;

namespace FileImportDesktopApp.Models.Services
{
    public class DeviceCheckerService
    {
        public DeviceCheckerService()
        {
            ManagementEventWatcher watcher = new ManagementEventWatcher();
            WqlEventQuery query = new WqlEventQuery("SELECT * FROM Win32_VolumeChangeEvent WHERE EventType = 2");
            watcher.EventArrived += new EventArrivedEventHandler(watcher_EventArrived);
            watcher.Query = query;
            watcher.Start();
        }

        public string DevicePath { get; set; } = "Hallo, ich bin nur ein Beispiel";


        public void watcher_EventArrived(object sender, EventArrivedEventArgs e)
        {
            Application.Current.Dispatcher.Invoke((Action)delegate
            {
                DevicePath = e.NewEvent.Properties["DriveName"].Value.ToString();
                Views.DeviceDialogView deviceDialogView = new Views.DeviceDialogView(DevicePath);
                deviceDialogView.Show();
            });
        }

    }
}
