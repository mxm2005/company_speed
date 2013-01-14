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

public partial class admin_recommend_content : System.Web.UI.Page
{
    private int _gid = 0; 
    Mxm.DAL.recommend_content rcMgr = new Mxm.DAL.recommend_content();

    protected void Page_Load(object sender, EventArgs e)
    {
        InitArgs();
        BindData();
    }

    private void InitArgs()
    {
        if (Request.QueryString["gid"] != null)
        {
            _gid = int.Parse(Request.QueryString["gid"].ToString());
        }
    }

    private void BindData()
    {
        try
        {
            Mxm.DAL.recommend_group rgMgr = new Mxm.DAL.recommend_group();
            Mxm.Model.recommend_group mGroup = rgMgr.GetModel(_gid);
            if (mGroup != null)
            {
                lblGroup.Text = mGroup.group_name;
            }
            
            IList<Mxm.Model.recommend_content> lst = rcMgr.GetListArray("group_id=" + _gid);
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
        try
        {
            Mxm.Model.recommend_content mo = new Mxm.Model.recommend_content();
            mo.content = txtContent.Text;
            mo.group_id = _gid;
            mo.title = txtTitle.Text;
            mo.url = txtURL.Text;
            if (fileUp1.HasFile)
            {
                string fileName = fileUp1.FileName;
                fileUp1.SaveAs(Mxm.Common.Comm.GetServerPath()
                    + ConfigurationManager.AppSettings["imgPath"] + fileName);
                mo.picture = fileName;
            }
            rcMgr.Add(mo);
            BindData();
            Mxm.Common.MessageBox.Show(this, "保存成功");
        }
        catch (Exception ex)
        {
            Mxm.Common.WriteError.WriteTxt(DateTime.Now.ToString() + " " + ex.Message);
            Mxm.Common.MessageBox.Show(this, "保存失败，发生了异常，请查看日志");
        }
    }

    protected string GetImgPath(string fileName)
    {
        string path = ConfigurationManager.AppSettings["imgPath"].ToString();
        path += fileName;
        return path;
    }

    protected void delete_type(object sender, CommandEventArgs e)
    {
        rcMgr.Delete(int.Parse(e.CommandArgument.ToString()));
        Response.AddHeader("Refresh", "0");
    }
}
