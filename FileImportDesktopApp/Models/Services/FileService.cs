using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileImportDesktopApp.Models.Services
{
    public static class FileService
    {
        public static List<string> GetSelectedFilePaths(ImportConfigSettings configSettings)
        {
            List<string> unfilteredFiles = Directory.GetFiles(configSettings.DevicePath, "*.*", configSettings.DirectoryDepth).ToList();

            List<string> filteredFiles = new List<string>();

            foreach (var file in unfilteredFiles)
            {
                if (File.GetCreationTime(file) >= configSettings.BeginningDate
                    && File.GetCreationTime(file) <= configSettings.EndingDate.AddDays(1))
                {
                    filteredFiles.Add(file);
                }
            }

            return filteredFiles;
        }
    }
}
