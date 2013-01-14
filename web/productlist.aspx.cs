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

public partial class productlist : System.Web.UI.Page
{
    private int mPageSize = 10;
    private int mPageIndex = 1;
    int _type_id = 0;
    private Mxm.DAL.production prodMgr = new Mxm.DAL.production();
    protected void Page_Load(object sender, EventArgs e)
    {
        InitArgs();
        if (!IsPostBack)
        {         
            SetPager();
            ShowList();
            SetNavTitle();
            SetBanner();
        }
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

    private void SetNavTitle()
    {
        Mxm.Model.product_type mo = new Mxm.DAL.product_type().GetModel(_type_id);
        if (mo != null)
        {
            lbl_nav.Text = " - " + mo.type_name;
            Title = mo.type_name + ConfigurationManager.AppSettings["title"];
            type_remark.InnerHtml = mo.remark;
            if (!string.IsNullOrEmpty(mo.banner))
            {
                topBanner.Src =ConfigurationManager.AppSettings["imgPath"]+ mo.banner;
            }
            else
            {
                topBanner.Style.Add("display", "none");
            }
        }
    }

    private void SetBanner()
    {
        string path = Server.MapPath("/XmlData/banner.xml");
        topBanner.Src = Banner.GetBannerImg("productlist", path);
        if (string.IsNullOrEmpty(topBanner.Src))
        {
            topBanner.Style.Add("display", "none");
        }
    }

    private void SetPager()
    {
        pager1.RecordCount = prodMgr.GetCount("product_type=" + _type_id);
        pager1.PageSize = mPageSize;
        pager1.CurrentPageIndex = mPageIndex;
    }

    private void ShowList()
    {
        string fldList = "pid, product_name, product_desc, create_time, update_time, picture, status, product_type, balance, product_synopsis, market_price, buy_price, sort, vidio, picture_small,model";
        DataSet ds = prodMgr.GetList(mPageSize, mPageIndex,fldList, "product_type=" + _type_id,"update_time");
        if (ds.Tables.Count > 0)
        {
            rptLst.DataSource = ds.Tables[0];
            rptLst.DataBind();
        }
    }

    protected string GetPic(string name)
    {
        string path = string.Empty;
        if (string.IsNullOrEmpty(name))
        {
            path = ConfigurationManager.AppSettings["nopic"].ToString();
        }
        else
        {
            path = ConfigurationManager.AppSettings["imgPath"] + name;
        }
        return path;
    }

}
