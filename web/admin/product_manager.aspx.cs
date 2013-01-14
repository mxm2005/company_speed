using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;

public partial class admin_product_manager : System.Web.UI.Page
{
    private int mPageIndex = 1;
    private int mPageSize = 10;
    Mxm.DAL.production productMgr = new Mxm.DAL.production();
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
        mPageSize = pager1.PageSize;
    }
        

    private void SetPager()
    {
        int count = productMgr.GetCount("");
        pager1.RecordCount = count;
    }

    private void ShowList()
    {
        DataSet ds= productMgr.GetList(mPageSize,mPageIndex,"");
        if (ds.Tables.Count > 0)
        {
            rptList.DataSource = ds.Tables[0];
            rptList.DataBind();
        }
    }

    protected void rpt_OnItemCommand(object sender, RepeaterCommandEventArgs e)
    {
        string[] arry = e.CommandArgument.ToString().Split(',');
        int pid = int.Parse(arry[0]);
        if (e.CommandName == "OpenStop")
        {
            int status = int.Parse(arry[1]);
            if (status == 0)
            {
                status = 1;
            }
            else
            {
                status = 0;
            }
            productMgr.UpdateStatus(pid, status);
        }
        if (e.CommandName == "delete")
        {
            productMgr.Delete(pid);
        }
        Response.AddHeader("Refresh", "0");
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

    protected void btnFilter_Click(object sender, EventArgs e)
    {
        string where = "";
        if (!string.IsNullOrEmpty(txtKeyWord.Text.Trim()))
        {
            where += " product_name like '%" + txtKeyWord.Text.Trim() + "%'";
            DataSet ds = productMgr.GetList(where);
            if (ds.Tables.Count > 0)
            {
                rptList.DataSource = ds.Tables[0];
                rptList.DataBind();
            }
        }
        else
        {
            Response.AddHeader("Refresh", "0");
        }        
    }
}
