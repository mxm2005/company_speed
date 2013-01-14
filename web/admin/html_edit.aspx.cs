using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.IO;

public partial class admin_html_edit : System.Web.UI.Page
{
    string _key = string.Empty;
    protected void Page_Load(object sender, EventArgs e)
    {
        InitArgs();
        if (!IsPostBack)
        {
            ShowInfo();
        }
    }

    private void InitArgs()
    {
        if (Request.QueryString["key"] != null)
        {
            _key = Request.QueryString["key"].ToString();
        }
    }

    private void ShowInfo()
    {
        try
        {
            string path = Server.MapPath("/XmlData/html.xml");
            string htmlF = Server.MapPath(GetHtml.GetHtmlStr(_key, path));
            if (File.Exists(htmlF))
            {
                txtContent.Value = File.ReadAllText(htmlF);
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    protected void btnSubmit_OnClick(object sender, EventArgs e)
    {
        try
        {
            string path = Server.MapPath("/XmlData/html.xml");
            string htmlF = Server.MapPath(GetHtml.GetHtmlStr(_key, path));
            File.WriteAllText(htmlF, txtContent.Value);
            Mxm.Common.MessageBox.ShowAndRedirect(this, "保存成功", "htmlManager.aspx");
            return;
        }
        catch (Exception ex)
        {
            throw ex;
        }
        Mxm.Common.MessageBox.Show(this, "保存失败");
    }
}
