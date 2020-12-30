using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace FileImportConsoleApp.Classes
{
    class ImportDirectory
    {
        private string directoryPath = $@"{Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory)}";
        private string directoryName = $"{DateTime.Today.ToString("yyyy-MM-dd")}_import";
        private string fullDirectoryPath
        {
            get { return $@"{directoryPath}\{directoryName}"; }
        }


        public void CreateImportDirectory()
        {
            Directory.CreateDirectory(fullDirectoryPath);
            Console.WriteLine("Ordner wurde erfolgreich erstellt");
        }
    }
}
