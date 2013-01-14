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

public partial class newslist : System.Web.UI.Page
{
    private int mPageSize = 10;
    private int mPageIndex = 1;
    private Mxm.DAL.article artMgr = new Mxm.DAL.article();
    private int mTypeId = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        InitArgs();
        if (!IsPostBack)
        {
            SetPager();
            ShowList();
            SetTitle();
            SetBanner();
        }
    }

    private void SetTitle()
    {
        this.Title += ConfigurationManager.AppSettings["title"].ToString();
    }

    private void SetBanner()
    {
        string path = Server.MapPath("/XmlData/banner.xml");
        topBanner.Src = Banner.GetBannerImg("news", path);
    }
    private void InitArgs()
    {
        if (Request.QueryString["page"] != null)
        {
            mPageIndex = int.Parse(Request.QueryString["page"].ToString());
        }
        mTypeId = int.Parse(ConfigurationManager.AppSettings["news"]);
    }

    private void SetPager()
    {
        pager1.RecordCount = artMgr.GetCount("type_id=" + mTypeId);
        pager1.PageSize = mPageSize;
        pager1.CurrentPageIndex = mPageIndex;
    }

    private void ShowList()
    {
        string fldName = "aid,title,type_id,update_time";
        DataSet ds = artMgr.GetList(mPageSize, mPageIndex,fldName, " type_id=" + mTypeId, "update_time", 1);
        if (ds.Tables.Count > 0)
        {
            rptLst.DataSource = ds.Tables[0];
            rptLst.DataBind();
        }
    }
}
