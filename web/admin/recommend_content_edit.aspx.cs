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

public partial class admin_recommend_content_edit : System.Web.UI.Page
{
    int _id = 0;
    protected int _gid = 0;
    Mxm.DAL.recommend_content _mgr = new Mxm.DAL.recommend_content();

    protected void Page_Load(object sender, EventArgs e)
    {
        InitArgs();
        if (!IsPostBack)
        {
            Bind();
        }
    }
    private void InitArgs()
    {
        if (Request.QueryString["id"] != null)
        {
            _id = int.Parse(Request.QueryString["id"]);
        }
    }
    private void Bind()
    {
        if (_id > 0)
        {
            Mxm.Model.recommend_content mo = _mgr.GetModel(_id);
            txtID.Text = _id.ToString();
            txtTitle.Text = mo.title;
            txtURL.Text = mo.url;
            txtContent.Text = mo.content;
            _gid = mo.group_id;
            if (!string.IsNullOrEmpty(mo.picture))
            {
                img.Src = ConfigurationManager.AppSettings["imgPath"] + mo.picture;
            }
        }
    }
    protected void btnOK_Click(object sender, EventArgs e)
    {
        try
        {
            Mxm.Model.recommend_content mo = _mgr.GetModel(_id);
            mo.content = txtContent.Text;
            mo.title = txtTitle.Text;
            mo.url = txtURL.Text;
            if (fileUp1.HasFile)
            {
                string fileName = fileUp1.FileName;
                fileUp1.SaveAs(Mxm.Common.Comm.GetServerPath()
                    + ConfigurationManager.AppSettings["imgPath"] + fileName);
                mo.picture = fileName;
            }
            _mgr.Update(mo);
            Bind();
            Mxm.Common.MessageBox.Show(this, "保存成功");
        }
        catch (Exception ex)
        {
            Mxm.Common.WriteError.WriteTxt(DateTime.Now.ToString() + " " + ex.Message);
            Mxm.Common.MessageBox.Show(this, "保存失败，发生了异常，请查看日志");
        }
    }
}
