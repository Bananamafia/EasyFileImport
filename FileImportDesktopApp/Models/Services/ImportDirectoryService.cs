using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileImportDesktopApp.Models.Services
{
    class ImportDirectoryService
    {
        private static string directoryPath = $@"{Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory)}";

        private static string directoryName = $"{DateTime.Today.ToString("yyyy-MM-dd")}_import";

        public static string fullDirectoryPath
        {
            get { return $@"{directoryPath}\{directoryName}"; }
        }

        public static void CreateImportDirectory()
        {
            Directory.CreateDirectory(fullDirectoryPath);
        }
    }
}
