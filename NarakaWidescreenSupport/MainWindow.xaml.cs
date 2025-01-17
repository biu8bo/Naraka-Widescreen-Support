using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using AutostartManagement;
using Microsoft.VisualBasic.Logging;
using NarakaWidescreenSupport.Enums;
using NarakaWidescreenSupport.Structs;
using NarakaWidescreenSupport.Util;
using NarakaWidescreenSupport.ViewModel;

namespace NarakaWidescreenSupport
{
 
    public partial class MainWindow
    { 
        private readonly SettingOptions _settingOptions;
        public MainWindow()
        {
            InitializeComponent();
 
            DataContext = _settingOptions = SettingOptions.GetSettingOptions();
        }
 

        protected override void OnClosing(CancelEventArgs e)
        {
            e.Cancel = true;
            Hide();
        }

        private async void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            try
            {
               await SettingOptions.SaveConfigAsync();
               MessageBox.Show("保存成功，重新启动应用后生效！","", MessageBoxButton.OK, MessageBoxImage.Information);
               var autostartManager = new AutostartManager(Assembly.GetEntryAssembly()!.Location);
               if (_settingOptions.IsAutoStartup&&!autostartManager.IsAutostartEnabled())
               {
                   autostartManager.EnableAutostart();
               }else if(!_settingOptions.IsAutoStartup){
                   autostartManager.DisableAutostart();
               }
            }
            catch (Exception exception)
            {
                MessageBox.Show($"错误: {exception.Message}\n堆栈: {exception.StackTrace}","", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}