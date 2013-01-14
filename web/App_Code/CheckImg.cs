using System;
using System.Data;
using System.Configuration;
using System.IO;
using System.Drawing;

/// <summary>
/// CheckImg 的摘要说明
/// </summary>
public class CheckImg
{
    /// <summary>
    /// 检查图片尺寸
    /// </summary>
    /// <param name="path">图片物理路径</param>
    /// <param name="width">图片宽</param>
    /// <param name="height">图片高</param>
    /// <returns></returns>
    public static bool CheckImgSize(string path,int width,int height)
    {
        bool reVal = false;
        if (File.Exists(path))
        {
            Image img = Image.FromFile(path);
            if (img.Width == width && img.Height == height)
            {
                reVal = true;
            }
            img.Dispose();
        }
        return reVal;
    }
}
