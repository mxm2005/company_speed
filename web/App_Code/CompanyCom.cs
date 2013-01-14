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
/// CompanyCom 的摘要说明
/// </summary>
public class CompanyCom
{
    /// <summary>
    /// 把P标签转换成换行标签
    /// </summary>
    /// <param name="strIn"></param>
    /// <returns></returns>
    public static string ChangeTagP(string strIn)
    {
        string reVal = string.Empty;
        reVal = strIn.Replace("<p>", "");
        reVal = reVal.Replace("</p>", "<br />");
        return reVal;
    }
}
