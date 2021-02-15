using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

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

        public static void CopyFilesToImportDirectory(ImportConfigSettings configSettings)
        {
            if (GetSelectedFilePaths(configSettings).Any())
            {
                ImportDirectoryService.CreateImportDirectory();
                foreach (var file in GetSelectedFilePaths(configSettings))
                {
                    File.Copy(file, $@"{ImportDirectoryService.fullDirectoryPath}\{Path.GetFileName(file)}");
                }
                MessageBox.Show("Import erfolgreich abgeschlossen.");
            }
            else if(configSettings.EndingDate < configSettings.BeginningDate)
            {
                MessageBox.Show("Das Enddatum darf nicht vor dem Anfangsdatum liegen.");
            }
            else
            {
                MessageBox.Show("Es wurden keine Datein ausgewählt.\nBitte prüfen Sie, ob sich Dateien auf dem Gerät befinden oder wählen Sie einen andern Zeitraum aus.");
            }
        }
    }
}
