using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileImportDesktopApp.Models.Services
{
    public class FileService
    {
        public FileService(ImportConfigSettings configSettings)
        {
            _configSettings = configSettings;
        }

        private ImportConfigSettings _configSettings;

        public List<string> SelectedFilePaths()
        {
            List<string> files = Directory.GetFiles(_configSettings.DevicePath, "*.*", _configSettings.DirectoryDepth).ToList();

            return files;
        }

        public int NumberOfFiles
        {
            get
            {
                return SelectedFilePaths().Count();
            }
        }
    }
}
