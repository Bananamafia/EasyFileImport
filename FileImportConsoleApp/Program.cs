using FileImportConsoleApp.Classes;
using System;
using System.IO;
using System.Threading;

namespace FileImportConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            //ImportDirectory importDirectory = new ImportDirectory();
            //importDirectory.CreateImportDirectory();

            //DeviceChecker.CheckForNewDevices();
            //Thread.Sleep(Timeout.Infinite);

            DeviceChecker.PrintOutDeviceContent();
        }
    }
}
