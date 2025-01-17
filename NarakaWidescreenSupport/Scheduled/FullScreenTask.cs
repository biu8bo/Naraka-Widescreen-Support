using System;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using NarakaWidescreenSupport.Enums;
using NarakaWidescreenSupport.Structs;
using NarakaWidescreenSupport.Util;
using NarakaWidescreenSupport.ViewModel;
using Timer = System.Timers.Timer;

namespace NarakaWidescreenSupport.Scheduled;

public static class FullScreenTask
{
    private static readonly Timer _timer = new();
    private static bool _isTimerRunning; //防止定时器重复执行
     
    private const string AppName = "NarakaBladepoint";
    
    private static bool isGameWasSetted;
    public static void Start()
    {
        SettingOptions settingOptions = SettingOptions.GetSettingOptions();
        _timer.Elapsed +=async (_, _) =>
        {
            if (_isTimerRunning)
            {
                return;
            }
            try
            {
                _isTimerRunning = true;
                Process? process = Process.GetProcessesByName(AppName).FirstOrDefault();
                //程序没有运行时还原
                if (process is null)
                {
                    isGameWasSetted = false;
                    return;
                }
                //游戏已经设置过 -- 跳过
                if (isGameWasSetted)
                {
                    return;
                }
                WindowMode windowMode = FullScreenUtil.GetWindowMode(process);
                if (windowMode == WindowMode.Fullscreen)
                {
                    //检测到游戏全屏 -- 开始自适应分辨率
                    ResolutionSize originalRes = ResolutionUtil.GetCurrentResolution();
                    //设置到1k
                    bool isSet = ResolutionUtil.SetDisplay(ResolutionSize.R1K());
                    if (!isSet)
                    {
                        throw new Exception("设置分辨率失败,请尝试切换成管理员模式运行本应用");
                    }
                    await Task.Delay(TimeSpan.FromSeconds(settingOptions.ChangeDelayTime));
                    //还原分辨率
                    ResolutionUtil.SetDisplay(originalRes);
                    isGameWasSetted = true;
                }
            }
            finally
            {
                _isTimerRunning = false;
            }
        };
        _timer.Interval = 3000;
        _timer.Start();
    }
    
    public static void Stop()
    {
        _timer.Stop();
    }
}