using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;

public partial class admin_article_manager : System.Web.UI.Page
{
    private int mPageIndex = 1;
    private readonly int mPageSize = 20;
    Mxm.DAL.article _artMgr = new Mxm.DAL.article();

    protected void Page_Load(object sender, EventArgs e)
    {
        InitArgs();
        ShowList();
        InitType();
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

    private void InitType()
    {
        IList<Mxm.Model.art_type> lst= new Mxm.DAL.art_type().GetListArray("");
        ddlType.DataSource = lst;
        ddlType.DataTextField = "type_name";
        ddlType.DataValueField = "type_id";
        ddlType.DataBind();
        ddlType.Items.Insert(0,new ListItem("全部", "0"));

        if (Request.Form["ddlType"] != null)
        {
            ddlType.Items.FindByValue(Request.Form["ddlType"]).Selected = true;
        }
    }

    private void SetPager()
    {
        int count = new Mxm.DAL.article().GetCount("");
        pager1.RecordCount = count;
        pager1.PageSize = mPageSize;
    }

    private void ShowList()
    {        
        DataSet ds = _artMgr.GetList(mPageSize,mPageIndex,"");
        if (ds.Tables.Count > 0)
        {
            rptList.DataSource = ds.Tables[0];
            rptList.DataBind();
        }
    }
    protected void btnFilter_Click(object sender, EventArgs e)
    {
        string where = "";
        if (Request.Form["ddlType"] != null && Request.Form["ddlType"] != "0")
        {
            where += " type_id=" + ddlType.SelectedValue;
        }
        if (!string.IsNullOrEmpty(txtKeyWord.Text.Trim()))
        {
            if (where.Length > 0)
            {
                where += " and ";
            }
            where += " title like '%" + txtKeyWord.Text.Trim() + "%'";
        }
        DataSet ds = _artMgr.GetList(where);
        if (ds.Tables.Count > 0)
        {
            rptList.DataSource = ds.Tables[0];
            rptList.DataBind();
        }
    }
    protected void delete_type(object sender, CommandEventArgs e)
    {
        _artMgr.Delete(int.Parse(e.CommandArgument.ToString()));
        Response.AddHeader("Refresh", "0");
    }
}
