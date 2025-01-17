using System.IO;
using System.Threading.Tasks;

namespace NarakaWidescreenSupport.Util;

public static class FileUtil
{
 public static void CreateHiddenFile(string filePath, string content)
    {
        if (File.Exists(filePath))
        {
            File.Delete(filePath);
        }
        // 创建文件并写入内容
        File.WriteAllText(filePath, content);
        // 获取文件信息
        FileInfo fileInfo = new FileInfo(filePath);
        // 设置文件为隐藏
        fileInfo.Attributes |= FileAttributes.Hidden;
 
    }
    
    public static async Task  CreateHiddenFileAsync(string filePath, string content)
    {
        if (File.Exists(filePath))
        {
            File.Delete(filePath);
        }
        // 创建文件并写入内容
        await   File.WriteAllTextAsync(filePath, content);
        // 获取文件信息
        FileInfo fileInfo = new FileInfo(filePath);
        // 设置文件为隐藏
        fileInfo.Attributes |= FileAttributes.Hidden;
 
    }
}