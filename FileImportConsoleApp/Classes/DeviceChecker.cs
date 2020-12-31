using System;
using System.Collections.Generic;
using System.Text;
using System.Management;

namespace FileImportConsoleApp.Classes
{
    class DeviceChecker
    {
        public static void CheckDevices()
        {
            ManagementObjectSearcher objectSearcher = new ManagementObjectSearcher("SELECT * FROM Win32_USBHub");
            ManagementObjectCollection objects = objectSearcher.Get();

            Console.WriteLine($"Devices: {objects.Count}");

            foreach (var item in objects)
            {
                Console.WriteLine(item.ToString());
            }
        }
    }
}
