using System;
using System.IO;

namespace FileImportConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Directory.CreateDirectory(fullDirectoryPath);
            Console.WriteLine("Ordner wurde erstellt.");
        }


        private static string directoryPath = $@"{Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory)}";
        private static string directoryName = $"{DateTime.Today.ToString("yyyy-MM-dd")}_import";
        private static string fullDirectoryPath
        {
            get { return $@"{directoryPath}\{directoryName}"; }
        }
    }
}
