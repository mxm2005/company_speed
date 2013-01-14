using System;
using System.Data;
using System.Configuration;
using System.Collections.Generic;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

public partial class product : System.Web.UI.Page
{
    private int mPageSize = 10;
    private int mPageIndex = 1;
    Mxm.DAL.product_type typeMgr = new Mxm.DAL.product_type();
    Mxm.DAL.production prodMgr = new Mxm.DAL.production();
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

    private void InitArgs()
    {
        if (Request.QueryString["page"] != null)
        {
            mPageIndex = int.Parse(Request.QueryString["page"].ToString());
        }
        mPageSize = pager1.PageSize;
    }

    private void SetTitle()
    {
        this.Title += ConfigurationManager.AppSettings["title"].ToString();
    }

    private void SetBanner()
    {
        string path = Server.MapPath("/XmlData/banner.xml");
        topBanner.Src = Banner.GetBannerImg("product", path);
        if (string.IsNullOrEmpty(topBanner.Src))
        {
            topBanner.Style.Add("display", "none");
        }
    }

    private void SetPager()
    {
        pager1.RecordCount = typeMgr.GetCount("parent_id<>0");
        pager1.CurrentPageIndex = mPageIndex;
    }

    private void ShowList()
    {
        List<Mxm.Model.product_type> lst = typeMgr.GetListArray(mPageSize, mPageIndex, "parent_id<>0");
        dataLst.DataSource = lst;
        dataLst.DataBind();
    }

    protected string GetTypePic(string type_id)
    {
        string resVal = "";
        DataSet ds = prodMgr.GetList(1,1," picture is not null and product_type=" + type_id);
        if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            resVal = ds.Tables[0].Rows[0]["picture_small"].ToString();
        }
        if (string.IsNullOrEmpty(resVal))
        {
            resVal = ConfigurationManager.AppSettings["nopic"].ToString();
        }
        else
        {
            resVal = ConfigurationManager.AppSettings["imgPath"] + resVal;
        }
        return resVal;
    }

    protected string GetListStr(string type_id)
    {
        string resVal = "";
        DataSet ds = prodMgr.GetList(5, 1, " product_type=" + type_id);
        if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            foreach (DataRow row in ds.Tables[0].Rows)
            {
                resVal += string.Format("<li><a href='productview.aspx?pid={0}' title='{1}'>{2}</a></li>",
                    row["pid"].ToString(),
                    row["product_name"].ToString(),
                    Mxm.Common.Comm.GetShortString(row["product_name"].ToString(), 12)
                    );
            }
        }
        return resVal;
    }
}
