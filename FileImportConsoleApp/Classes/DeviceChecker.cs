using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Management;
using System.IO;

namespace FileImportConsoleApp.Classes
{
    class DeviceChecker
    {
        public static void CheckForNewDevices()
        {
            ManagementEventWatcher watcher = new ManagementEventWatcher();
            WqlEventQuery query = new WqlEventQuery("SELECT * FROM Win32_VolumeChangeEvent WHERE EventType = 2");
            watcher.EventArrived += new EventArrivedEventHandler(watcher_EventArrived);
            watcher.Query = query;
            watcher.Start();
            watcher.WaitForNextEvent();
        }

        private static void watcher_EventArrived(object sender, EventArrivedEventArgs e)
        {
            Console.WriteLine("Neues Gerät angeschlossen.");
            devicePath = e.NewEvent.Properties["DriveName"].Value.ToString();
            CopyFilesOfDeviceToImportDirectory();
        }

        private static string devicePath;

        public static void PrintOutDeviceContent()
        {
            List<string> filesOnDevice = Directory.GetFiles(devicePath, "*.*", SearchOption.AllDirectories).ToList();

            foreach (var file in filesOnDevice)
            {
                Console.WriteLine(file);
            }
        }

        private List<string> GetFilesOnDevice()
        {
            return Directory.GetFiles(devicePath, "*.*", SearchOption.AllDirectories).ToList();
        }

        public static void CopyFilesOfDeviceToImportDirectory()
        {

        }
    }
}
