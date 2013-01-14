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

public partial class admin_art_type : System.Web.UI.Page
{
    Mxm.DAL.art_type mgr = new Mxm.DAL.art_type();
    protected void Page_Load(object sender, EventArgs e)
    {     
        BindProductType();
    }

    private void BindProductType()
    {
        IList<Mxm.Model.art_type> list = mgr.GetListArray("");
        rptList.DataSource = list;
        rptList.DataBind();
    }

    protected void btnAdd_Click(object sender, EventArgs e)
    {
        if (string.IsNullOrEmpty(txtTypeName.Text.Trim()))
        {
            Mxm.Common.MessageBox.Show(this, "分类名称不允许为空");
            return;
        }
        Mxm.Model.art_type mo = new Mxm.Model.art_type();
        mo.type_name = txtTypeName.Text.Trim();
        try
        {
            mgr.Add(mo);
            Mxm.Common.MessageBox.Show(this, "添加成功");
        }
        catch (Exception ex)
        {
            Mxm.Common.WriteError.WriteTxt(DateTime.Now.ToString() + " " + ex.StackTrace);
        }
        Response.AddHeader("Refresh", "0");
    }

    protected void delete_type(object sender, CommandEventArgs e)
    {
        mgr.Delete(int.Parse(e.CommandArgument.ToString()));
        Mxm.Common.MessageBox.Show(this, "删除成功");
        Response.AddHeader("Refresh", "0");
    }
}
