   M S B A M L   `   `   `  ����R  NNarakaWidescreenSupport, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullA%clr-namespace:NarakaWidescreenSupportNarakaWidescreenSupport  5   	   (    "NarakaWidescreenSupport.MainWindow   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   7local%clr-namespace:NarakaWidescreenSupport     5   	   _ [Hardcodet.NotifyIcon.Wpf, Version=2.0.0.0, Culture=neutral, PublicKeyToken=682384a853a08aad)tb http://www.hardcodet.net/taskbar  5   	     � Icon$  Resource/Red.ico��5	   	    � 
ResizeMode$ NoResize=�5
   	    � WindowStartupLocation$ CenterScreen=�5   	    � Title$0 *永劫无间去黑边宽屏自适应工具��5   	   $	��200��6    $	��400��6-   .��5      � $��15q�6    � RowDefinitions 5      �� 5   
   $
��Auto �6   5      �� 5   
   $
��Auto �6   5      �� 5   
   $
��Auto �6   5      .+�5   
   �� $��Center=�6    �� Orientation$ 
Horizontal=�61   .+�5   
   �� $'��!切换分辨率间隔时间(秒):��6   �� 5   
   $	��200��6   $��8,0,0,0q�6   ��6/   �� *ChangeDelayTime+6R   5      �� 5   
   $��Center=�6   $ 
Horizontal=�61   $��0,15,0,0q�6J   $��1��6\   .+�5      �� $��是否开机自启:��6   �� 5      $��8,0,0,0q�6    d� 	IsChecked 6(   �� *IsAutoStartup+5      �� 5!   
   $��Center=�6   $��Center=�60   $��0,15,0,0q�6N   $��2��6`   .+�5#      �� -   5        $��80��5#      .��6:   保存设置6@   5$      5%      5&      