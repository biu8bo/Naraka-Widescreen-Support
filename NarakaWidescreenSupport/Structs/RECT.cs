using System.Runtime.InteropServices;

namespace NarakaWidescreenSupport.Structs;


[StructLayout(LayoutKind.Sequential)]
public struct RECT
{
    public int left;
    public int top;
    public int right;
    public int bottom;
}


[StructLayout(LayoutKind.Sequential)]
public struct Rect
{
    public int Left, Top, Right, Bottom;
}