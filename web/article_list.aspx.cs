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

public partial class article_list : System.Web.UI.Page
{
    private int _type_id = 0;
    private int mPageSize = 10;
    private int mPageIndex = 1;
    private Mxm.DAL.article artMgr = new Mxm.DAL.article();

    protected void Page_Load(object sender, EventArgs e)
    {
        InitArgs();
        SetPager();
        ShowList();
        SetTitleNav();
        SetBanner();
    }

    private void InitArgs()
    {
        if (Request.QueryString["page"] != null)
        {
            mPageIndex = int.Parse(Request.QueryString["page"].ToString());
        }
        if (Request.QueryString["type"] != null)
        {
            _type_id = int.Parse(Request.QueryString["type"].ToString());
        }
    }

    private void SetTitleNav()
    {
        Mxm.Model.art_type mo = new Mxm.DAL.art_type().GetModel(_type_id);
        if (mo != null)
        {
            this.Title = mo.type_name + ConfigurationManager.AppSettings["title"];
            lbl_nav.Text = " - " + mo.type_name;
        }
    }

    private void SetBanner()
    {
        string path = Server.MapPath("/XmlData/banner.xml");
        topBanner.Src = Banner.GetBannerImg("article", path);
    }

    private void SetPager()
    {
        pager1.RecordCount = artMgr.GetCount("type_id=" + _type_id);
        pager1.PageSize = mPageSize;
        pager1.CurrentPageIndex = mPageIndex;
    }

    private void ShowList()
    {
        DataSet ds = artMgr.GetList(mPageSize, mPageIndex, "type_id=" + _type_id);
        if (ds.Tables.Count > 0)
        {
            rptLst.DataSource = ds.Tables[0];
            rptLst.DataBind();
        }
    }
}
