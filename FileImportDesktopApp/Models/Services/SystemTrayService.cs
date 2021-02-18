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
        private static System.Windows.Forms.NotifyIcon notificationIcon;

        public static void SetUpSystemTray()
        {
            Stream iconStream = System.Windows.Application.GetResourceStream(new Uri("pack://application:,,,/Resources/Icons/appIcon.ico")).Stream;

            notificationIcon = new System.Windows.Forms.NotifyIcon()
            {
                Text = "Rechtsklick, um Gerät für Easy File Import auszuwählen.",
                Visible = true,
                Icon = new System.Drawing.Icon(iconStream)
            };

            System.Windows.Forms.ContextMenuStrip contextMenuStrip = new System.Windows.Forms.ContextMenuStrip();

            foreach (var device in DeviceCheckerService.GetConnectedDevices())
            {
                contextMenuStrip.Items.Add(device, null, ContextMenuClicked_Event);
            }

            contextMenuStrip.Items.Add("-");
            contextMenuStrip.Items.Add("Beenden", null, CloseAppClicked_Event);

            notificationIcon.ContextMenuStrip = contextMenuStrip;
        }

        private static void CloseAppClicked_Event(object sender, EventArgs e)
        {
            notificationIcon.Visible = false;
            System.Windows.Application.Current.Shutdown();
        }

        private static void ContextMenuClicked_Event(object sender, EventArgs e)
        {
            Views.DeviceDialogView view = new Views.DeviceDialogView(sender.ToString());
            view.Show();
        }
    }
}
