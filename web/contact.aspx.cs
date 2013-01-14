using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.IO;

public partial class contact : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Title = "联系我们" + ConfigurationManager.AppSettings["title"];
        SetBanner();
        LoadContent();
    }

    private void SetBanner()
    {
        string path = Server.MapPath("/XmlData/banner.xml");
        topBanner.Src = Banner.GetBannerImg("contact", path);
    }
    private void LoadContent()
    {
        string path = Server.MapPath("/XmlData/html.xml");
        string htmlF = Server.MapPath(GetHtml.GetHtmlStr("contact", path));
        if (File.Exists(htmlF))
        {
            divContent.InnerHtml = File.ReadAllText(htmlF);
        }
    }
}
