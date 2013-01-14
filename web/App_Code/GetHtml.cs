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
/// GetHtml 的摘要说明
/// </summary>
public class GetHtml
{
    public GetHtml()
    {
        //
        // TODO: 在此处添加构造函数逻辑
        //
    }

    /// <summary>
    /// 获取xml数据
    /// </summary>
    /// <param name="key">键</param>
    /// <param name="path">数据文件物理路径</param>
    /// <returns></returns>
    public static string GetHtmlStr(string key, string path)
    {
        string resVal = "";
        DataTable dt = Com.Mxm.ReadXml.ReadToDt(path);
        resVal = dt.Select("key='" + key + "'")[0]["file"].ToString();
        return resVal;
    }
}
