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

public partial class download : System.Web.UI.Page
{
    private int mPageSize = 5;
    private int mPageIndex = 1;
    private Mxm.DAL.download _mgr = new Mxm.DAL.download();
    protected void Page_Load(object sender, EventArgs e)
    {
        InitArgs();
        SetNavTitle();
        SetBanner();
        ShowList();
    }

    private void InitArgs()
    {
        if (Request.QueryString["page"] != null)
        {
            mPageIndex = int.Parse(Request.QueryString["page"].ToString());
        }
    }

    private void ShowList()
    {
        DataSet ds = _mgr.GetList("", "sort");
        if (ds.Tables.Count > 0)
        {
            rptLst.DataSource = ds.Tables[0];
            rptLst.DataBind();
        }
    }

    private void SetBanner()
    {
        string path = Server.MapPath("/XmlData/banner.xml");
        topBanner.Src = Banner.GetBannerImg("download", path);
    }

    private void SetNavTitle()
    {
        this.Title += ConfigurationManager.AppSettings["title"].ToString();        
    }

    protected string GetPic(string name)
    {
        if (string.IsNullOrEmpty(name))
        {
            return ConfigurationManager.AppSettings["nopic"].ToString();
        }
        return ConfigurationManager.AppSettings["imgPath"] + name;
    }
}
