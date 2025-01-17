using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using NarakaWidescreenSupport.Util;
using Newtonsoft.Json;

namespace NarakaWidescreenSupport.ViewModel;

public class SettingOptions : INotifyPropertyChanged
{
    [JsonIgnore] private static SettingOptions settingOptions;
    [JsonIgnore] private static string configFilePath =   Path.Combine(AppDomain.CurrentDomain.BaseDirectory,"NarakaWidescreenSupport-Settings.json");


    private int changeDelayTime = 6;
    private SettingOptions(){}
    /// <summary>
    /// 切换延迟时间
    /// </summary>
    public int ChangeDelayTime
    {
        get => changeDelayTime;
        set
        {
            changeDelayTime = value;
            OnPropertyChanged();
        }
    }

    private bool isAutoStartup;

    /// <summary>
    /// 是否应用自启动
    /// </summary>
    public bool IsAutoStartup
    {
        get => isAutoStartup;
        set
        {
            isAutoStartup = value;
            OnPropertyChanged();
        }
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    /// <summary>
    /// 获取设置选项对象
    /// </summary>
    /// <returns></returns>
    public static SettingOptions GetSettingOptions()
    {
        if (settingOptions is null)
        {
               settingOptions = new SettingOptions();
            try
            {
                if (!File.Exists(configFilePath))
                {
                    FileUtil.CreateHiddenFile(configFilePath, JsonConvert.SerializeObject(settingOptions));
                }
                else
                {
                    string readAllText = File.ReadAllText(configFilePath);
                    settingOptions = JsonConvert.DeserializeObject<SettingOptions>(readAllText);
                }
            }
            catch (Exception e)
            {
                FileUtil.CreateHiddenFile(configFilePath, JsonConvert.SerializeObject(settingOptions));
            }
        }
        return settingOptions;
    }

    public static async Task SaveConfigAsync()
    {
        string settingfile = Path.Combine(AppDomain.CurrentDomain.BaseDirectory,        "NarakaWidescreenSupport-Settings.json");

       await FileUtil.CreateHiddenFileAsync(settingfile, JsonConvert.SerializeObject(settingOptions));
    }
}