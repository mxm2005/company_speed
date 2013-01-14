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

public partial class admin_download_manager : System.Web.UI.Page
{
    private int mPageIndex = 1;
    private readonly int mPageSize = 10;
    protected void Page_Load(object sender, EventArgs e)
    {
        InitArgs();
        ShowList();
        if (!IsPostBack)
        {
            SetPager();
        }
    }

    private void InitArgs()
    {
        if (Request.QueryString["page"] != null)
        {
            mPageIndex = int.Parse(Request.QueryString["page"].ToString());
        }
    }

    private void SetPager()
    {
        int count = new Mxm.DAL.download().GetCount("");
        pager1.RecordCount = count;
        pager1.PageSize = mPageSize;
    }

    private void ShowList()
    {
        Mxm.DAL.download mgr = new Mxm.DAL.download();
        DataSet ds = mgr.GetList(mPageSize, mPageIndex, "", "down_id", 1);
        if (ds.Tables.Count > 0)
        {
            rptList.DataSource = ds.Tables[0];
            rptList.DataBind();
        }
    }

    protected void rpt_OnItemCommand(object sender, RepeaterCommandEventArgs e)
    {
        int id = int.Parse(e.CommandArgument.ToString().Trim());
        (new Mxm.DAL.download()).Delete(id);
        Response.Redirect(Request.Url.ToString());
    }

    protected string GetPic(string url)
    {
        return ConfigurationManager.AppSettings["imgPath"] + url;
    }
}
