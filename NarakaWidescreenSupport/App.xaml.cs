using System;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Windows;
using Hardcodet.Wpf.TaskbarNotification;
using NarakaWidescreenSupport.Enums;
using NarakaWidescreenSupport.Scheduled;
using NarakaWidescreenSupport.Structs;
using NarakaWidescreenSupport.Util;
using NarakaWidescreenSupport.ViewModel;
using Timer = System.Timers.Timer;

namespace NarakaWidescreenSupport
{
    public partial class App : Application
    {

        private TaskbarIcon? notifyIcon;

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            notifyIcon = (TaskbarIcon)FindResource("NotifyIcon");
            FullScreenTask.Start();
        }

        protected override void OnExit(ExitEventArgs e)
        {
            notifyIcon?.Dispose();
            FullScreenTask.Stop();
            base.OnExit(e);
        }
    }
}