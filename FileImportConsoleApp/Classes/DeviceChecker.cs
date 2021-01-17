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
            Console.WriteLine("Angeschlossene Geräte werden beobachtet.");
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
            StartImportDialog();
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

        private static List<string> GetFilesOnDevice()
        {
            return Directory.GetFiles(devicePath, "*.*", SearchOption.AllDirectories).ToList();
        }

        public static void CopyFilesOfDeviceToImportDirectory()
        {
            if (String.IsNullOrEmpty(devicePath))
            {
                Console.WriteLine("Kein gültiges Gerät angeschlossen.");
            }
            else
            {
                foreach (var file in GetFilesOnDevice())
                {
                    File.Copy(file, $@"{ImportDirectory.directory}\{Path.GetFileName(file)}");
                }
            }
        }

        public static void StartImportDialog()
        {
            Console.WriteLine($"Wollen Sie die Datein von {devicePath} Importieren? (j/n)");

            switch (Console.ReadKey().KeyChar)
            {
                case 'j':
                    Console.WriteLine();
                    Console.WriteLine("Import wird gestartet.");
                    ImportDirectory.CreateImportDirectory();
                    CopyFilesOfDeviceToImportDirectory();
                    Console.WriteLine("Import abgeschlossen.");
                    break;
                case 'n':
                    Console.WriteLine();
                    Console.WriteLine("Import abgebrochen.");
                    break;
                default:
                    Console.WriteLine();
                    Console.WriteLine("Ungültige Anweisung, bitte versuchen Sie es erneut.");
                    StartImportDialog();
                    break;

            }
        }
    }
}
