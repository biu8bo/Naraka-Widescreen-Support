// hardcodet.net NotifyIcon for WPF
// Copyright (c) 2009 - 2022 Philipp Sumi. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// Contact and Information: http://www.hardcodet.net

using System.Windows;
using System.Windows.Input;

namespace NarakaWidescreenSupport.ViewModel
{
    /// <summary>
    /// Provides bindable properties and commands for the NotifyIcon. In this sample, the
    /// view model is assigned to the NotifyIcon in XAML. Alternatively, the startup routing
    /// in App.xaml.cs could have created this view model, and assigned it to the NotifyIcon.
    /// </summary>
    public class NotifyIconViewModel
    {
        private MainWindow GetMainWindow()
        {
            return Application.Current.MainWindow as MainWindow;
        }

        /// <summary>
        ///退出程序
        /// </summary>
        public ICommand ExitApplicationCommand
        {
            get { return new DelegateCommand { CommandAction = () => Application.Current.Shutdown() }; }
        }
    }
}