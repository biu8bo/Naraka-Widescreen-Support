using System.Diagnostics;
using NarakaWidescreenSupport.Enums;
using NarakaWidescreenSupport.Structs;

namespace NarakaWidescreenSupport.Util;

using System;
using System.Runtime.InteropServices;

public static class FullScreenUtil
{
    [DllImport("user32.dll")]
    private static extern IntPtr GetForegroundWindow();

    [DllImport("user32.dll")]
    private static extern bool GetWindowRect(IntPtr hWnd, out Rect rect);


    [DllImport("user32.dll")]
    private static extern bool GetWindowRect(IntPtr hWnd, out RECT lpRect);

    [DllImport("user32.dll")]
    private static extern bool GetClientRect(IntPtr hWnd, out RECT lpRect);


    public static WindowMode GetWindowMode(Process process)
    {
        IntPtr hWnd = process.MainWindowHandle;

        RECT windowRect;
        GetWindowRect(hWnd, out windowRect);

        RECT clientRect;
        GetClientRect(hWnd, out clientRect);

        int windowWidth = windowRect.right - windowRect.left;
        int windowHeight = windowRect.bottom - windowRect.top;

        int clientWidth = clientRect.right - clientRect.left;
        int clientHeight = clientRect.bottom - clientRect.top;

        if (windowWidth == clientWidth && windowHeight == clientHeight)
        {
            return WindowMode.Fullscreen;
        }
        else if (windowWidth != clientWidth || windowHeight != clientHeight)
        {
            return WindowMode.Windowed;
        }
        else
        {
            return WindowMode.Unknown;
        }
    }
}