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
            //ManagementObjectSearcher objectSearcher = new ManagementObjectSearcher("SELECT * FROM Win32_USBHub");
            //ManagementObjectCollection objects = objectSearcher.Get();

            //Console.WriteLine($"Devices: {objects.Count}");

            //foreach (var item in objects)
            //{
            //    Console.WriteLine(item.ToString());
            //}

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
        }

        private static string devicePath = @"D:\";

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

        public static void CopyFilesOfDeviceInImportDirectory()
        {

        }
    }
}
