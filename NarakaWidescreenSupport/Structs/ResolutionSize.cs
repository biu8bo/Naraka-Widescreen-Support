namespace NarakaWidescreenSupport.Structs;


/// <summary>
/// 分辨率结构体
/// </summary>
public record struct ResolutionSize
{
   
    private int width;
    private int height;

    public int Width
    {
        get => width;
        set => width = value;
    }

    public int Height
    {
        get => height;
        set => height = value;
    }

    public ResolutionSize()
    {
        width = 0;
        height = 0;
    }

    public ResolutionSize(int width, int height)
    {
        this.width = width;
        this.height = height;
    }

    /// <summary>
    /// 1k分辨率
    /// </summary>
    /// <returns></returns>
    public static ResolutionSize R1K()
    {
        return new ResolutionSize(1920, 1080);
    }

    /// <summary>
    /// 2k分辨率
    /// </summary>
    /// <returns></returns>
    public static ResolutionSize R2K()
    {
        return new ResolutionSize(2560, 1440);
    }

    /// <summary>
    /// 3.5k(准4k)分辨率
    /// </summary>
    /// <returns></returns>
    public static ResolutionSize R3d5K()
    {
        return new ResolutionSize(3440, 1440);
    }

    /// <summary>
    /// 4k分辨率
    /// </summary>
    /// <returns></returns>
    public static ResolutionSize R4K()
    {
        return new ResolutionSize(3840, 2160);
    }

    public override string ToString()
    {
        return $"{width}*{height}";
    }
}
