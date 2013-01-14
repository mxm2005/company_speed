using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

/// <summary>
/// Banner图片显示类
/// </summary>
public class Banner
{
    /// <summary>
    /// 获取Banner图片
    /// </summary>
    /// <param name="key">键</param>
    /// <param name="path">数据文件物理路径</param>
    /// <returns></returns>
    public static string GetBannerImg(string key,string path)
    {
        string resVal = "";
        if (key == "index")
        {//'bcastr_file=<%= _imgs %>&bcastr_link=#|#|#'
            string imgs = "", urls = "";
            DataTable dt = Com.Mxm.ReadXml.ReadToDt(path);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                imgs += dt.Rows[i]["img"].ToString();
                urls += dt.Rows[i]["url"].ToString();
                if (i < dt.Rows.Count - 1)
                {
                    imgs += "|";
                    urls += "|";
                }
            }
            resVal = "'bcastr_file=" + imgs + "&bcastr_link=" + urls + "'";
        }
        else
        {
            DataTable dt = Com.Mxm.ReadXml.ReadToDt(path);
            resVal = dt.Select("key='" + key + "'")[0]["img"].ToString();
        }
        return resVal;
    }

    /// <summary>
    /// 写入XML数据
    /// </summary>
    /// <param name="path"></param>
    /// <param name="dt"></param>
    public static void WriteXml(string path, DataTable dt)
    {
        DataSet ds = new DataSet();
        ds.Tables.Add(dt);
        ds.WriteXml(path);
    }
}
