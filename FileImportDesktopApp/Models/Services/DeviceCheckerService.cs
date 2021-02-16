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

        public string DevicePath { get; set; }

        public void watcher_EventArrived(object sender, EventArrivedEventArgs e)
        {
            Application.Current.Dispatcher.Invoke((Action)delegate
            {
                DevicePath = e.NewEvent.Properties["DriveName"].Value.ToString();
                Views.DeviceDialogView deviceDialogView = new Views.DeviceDialogView(DevicePath);
                deviceDialogView.Show();
            });
        }

        public static List<string> GetConnectedDevices()
        {
            List<string> devices = new List<string>();

            ManagementObjectCollection collection;
            using (var searcher = new ManagementObjectSearcher(@"SELECT * FROM Win32_LogicalDisk "))
            {
                collection = searcher.Get();
            }

            foreach (var item in collection)
            {
                devices.Add(item.GetPropertyValue("DeviceId").ToString());
            }

            return devices;
        }

    }
}
