using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using NarakaWidescreenSupport.Structs;

namespace NarakaWidescreenSupport.Util;

public static class ResolutionUtil
{
    // 常量定义
    private const int EnumCurrentSettings = -1;
    /// <summary>
    /// 枚举系统所有分辨率大小
    /// </summary>
    /// <param name="deviceName"></param>
    /// <param name="modeNum"></param>
    /// <param name="devMode"></param>
    /// <returns></returns>
    [DllImport("user32.dll")]
    private static extern int EnumDisplaySettings(string deviceName, int modeNum, ref DevMode devMode);

    /// <summary>
    /// 改变分辨率
    /// </summary>
    /// <param name="devMode"></param>
    /// <param name="flags"></param>
    /// <returns></returns>
    [DllImport("user32.dll")]
    private static extern int ChangeDisplaySettings(ref DevMode devMode, int flags);

    public static bool SetDisplay(ResolutionSize size)
    {
        // 设置新的分辨率
        DevMode newMode = CurrentResolution;
        newMode.dmSize = (short)Marshal.SizeOf(typeof(DevMode));
        newMode.dmPelsWidth = size.Width; // 新宽度
        newMode.dmPelsHeight = size.Height; // 新高度
        // 更改显示设置
        int result = ChangeDisplaySettings(ref newMode, 0);
        return result == 0;
    }
    public static bool SetDisplay(DevMode devMode)
    {
        // 设置新的分辨率
 
        // 更改显示设置
        int result = ChangeDisplaySettings(ref devMode, 0);
        return result == 0;
    }
    /// <summary>
    /// 获取当前系统分辨率
    /// </summary>
    /// <returns></returns>
    private static DevMode CurrentResolution
    {
        get
        {
            // 获取当前显示设置
            DevMode currentMode = new DevMode();
            currentMode.dmSize = (short)Marshal.SizeOf(typeof(DevMode));
            EnumDisplaySettings(null, EnumCurrentSettings, ref currentMode); // -1 获取当前设置
            return currentMode;
        }
    }

    /// <summary>
    /// 获取当前系统分辨率
    /// </summary>
    /// <returns></returns>
    public static ResolutionSize GetCurrentResolution()
    {
        var currentMode = CurrentResolution;
        var size = new ResolutionSize
                   {
                       Width = currentMode.dmPelsWidth,
                       Height = currentMode.dmPelsHeight
                   };
        return size;
    }
    /// <summary>
    /// 获取当前系统分辨率
    /// </summary>
    /// <returns></returns>
    public static DevMode GetCurrentResolutionDevMode()
    {
        var currentMode = CurrentResolution;
        
        return currentMode;
    }
    /// <summary>
    /// 获取分辨率集合
    /// </summary>
    /// <returns></returns>
    public static List<ResolutionSize> GetResolutionSet()
    {
        List<ResolutionSize> sizes = new List<ResolutionSize>();

        int modeNum = 0;
        DevMode devMode = new DevMode
                          {
                              dmSize = (short)Marshal.SizeOf(typeof(DevMode))
                          };
        while (EnumDisplaySettings(null, modeNum, ref devMode) != 0)
        {
            var size = new ResolutionSize()
                       {
                           Height = devMode.dmPelsHeight,
                           Width = devMode.dmPelsWidth
                       };
            sizes.Add(size);
            modeNum++;
        }
        //去重后通过宽和高排序
        return sizes.Distinct().OrderByDescending(p => p.Width).ThenByDescending(p => p.Height).ToList();
    }
}