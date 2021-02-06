using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FileImportDesktopApp.Models;

namespace FileImportDesktopApp.ViewModels
{
    class StartupViewModel
    {
        public StartupViewModel()
        {
            Models.Services.DeviceCheckerService deviceCheckerService = new Models.Services.DeviceCheckerService();
        }
    }
}
