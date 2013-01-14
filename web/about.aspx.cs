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

public partial class about : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        SetTitleNav();
        SetBanner();
        LoadContent();
    }

    private void SetTitleNav()
    {
        this.Title += ConfigurationManager.AppSettings["title"];
    }

    private void SetBanner()
    {
        string path = Server.MapPath("/XmlData/banner.xml");
        topBanner.Src = Banner.GetBannerImg("about", path);
    }

    private void LoadContent()
    {
        string path = Server.MapPath("/XmlData/html.xml");
        string htmlF =Server.MapPath( GetHtml.GetHtmlStr("about", path));
        if (File.Exists(htmlF))
        {
            divContent.InnerHtml = File.ReadAllText(htmlF);
        }
    }
}
