using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace FileImportConsoleApp.Classes
{
    class ImportDirectory
    {
        public static string directory;
        
        private static string directoryPath = $@"{Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory)}";
        private static string directoryName = $"{DateTime.Today.ToString("yyyy-MM-dd")}_import";
        private static string fullDirectoryPath
        {
            get { return $@"{directoryPath}\{directoryName}"; }
        }


        public static void CreateImportDirectory()
        {
            Directory.CreateDirectory(fullDirectoryPath);
            directory = fullDirectoryPath;
            Console.WriteLine("Ordner wurde erfolgreich erstellt");
        }
    }
}
