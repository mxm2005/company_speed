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

public partial class admin_recommend_manager : System.Web.UI.Page
{
    Mxm.DAL.recommend_group mgr = new Mxm.DAL.recommend_group();
    protected void Page_Load(object sender, EventArgs e)
    {
        BindRecommendList();
    }

    private void BindRecommendList()
    {
        try
        {
            IList<Mxm.Model.recommend_group> lst = mgr.GetListArray("");
            rptList.DataSource = lst;
            rptList.DataBind();
        }
        catch (Exception ex)
        {
            Mxm.Common.WriteError.WriteTxt(DateTime.Now.ToString() + " " + ex.Message);
        }
    }
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        if (string.IsNullOrEmpty(txtGroupName.Text.Trim()))
        {
            Mxm.Common.MessageBox.Show(this, "分组名称不能为空");
            return;
        }
        try
        {
            bool isExits = mgr.Exists(txtGroupName.Text.Trim());
            if (isExits)
            {
                Mxm.Common.MessageBox.Show(this, "添加失败，已经存在同样的分组");
                return;
            }

            Mxm.Model.recommend_group mo = new Mxm.Model.recommend_group();
            mo.group_name = txtGroupName.Text.Trim();
            mgr.Add(mo);
            Mxm.Common.MessageBox.Show(this, "添加成功");
        }
        catch (Exception ex)
        {
            Mxm.Common.MessageBox.Show(this, "添加失败，发生了异常");
            Mxm.Common.WriteError.WriteTxt(DateTime.Now.ToString() + " " + ex.Message);
        }
        BindRecommendList();
    }

    protected void delete_type(object sender, CommandEventArgs e)
    {
        mgr.Delete(int.Parse(e.CommandArgument.ToString()));
        Response.AddHeader("Refresh", "0");
    }
}
