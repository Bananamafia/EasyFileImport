using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace FileImportDesktopApp.Models.Services
{
    class SystemTrayService
    {
        public static void SetUpSystemTray()
        {
            System.Windows.Forms.NotifyIcon notificationIcon = new System.Windows.Forms.NotifyIcon();
            Stream iconStream = System.Windows.Application.GetResourceStream(new Uri("pack://application:,,,/Resources/Icons/appIcon.ico")).Stream;
            notificationIcon.Icon = new System.Drawing.Icon(iconStream);

            notificationIcon.Visible = true;
            notificationIcon.Text = "Gerät für Easy File Import auswählen.";

            notificationIcon.Click +=
                    delegate (object sender, EventArgs args)
                    {
                        ContextMenu contextMenu = new ContextMenu();

                        foreach (var device in DeviceCheckerService.GetConnectedDevices())
                        {
                            contextMenu.Items.Add(new MenuItem() { Header = device });
                        }
                        contextMenu.Items.Cast<MenuItem>().ToList();//.ForEach(x => x.Click += X_Click);
                        contextMenu.IsOpen = true;
                    };
        }
    }
}
