using FileImportConsoleApp.Classes;
using System;
using System.IO;

namespace FileImportConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            //ImportDirectory importDirectory = new ImportDirectory();
            //importDirectory.CreateImportDirectory();
            DeviceChecker.CheckDevices();
        }
    }
}
