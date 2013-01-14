using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;

public partial class admin_article_add : System.Web.UI.Page
{
    private int _picSize = int.Parse(ConfigurationManager.AppSettings["picSize"]);
    protected void Page_Load(object sender, EventArgs e)
    {
        InitType();
    }

    private void InitType()
    {
        System.Collections.Generic.List<Mxm.Model.art_type> lst = new Mxm.DAL.art_type().GetListArray("");
        ddlType.DataSource = lst;
        ddlType.DataTextField = "type_name";
        ddlType.DataValueField = "type_id";
        ddlType.DataBind();
    }

    protected void btnSubmit_OnClick(object sender, EventArgs e)
    {
        Mxm.Model.article mo = new Mxm.Model.article();
        mo.author = txtAuthor.Text;
        mo.content = txtContent.Value;
        mo.create_time = DateTime.Now;
        mo.title = txtTitle.Text;
        mo.update_time = DateTime.Now;
        if(Request.Form["ddlType"]!=null)
        {
            mo.Type_id = int.Parse(Request.Form["ddlType"].ToString());
        }
        if (fileUp1.HasFile)
        {
            string tmp = DateTime.Now.Ticks.ToString();
            string path = Server.MapPath(
                ConfigurationManager.AppSettings["imgPath"].ToString()) +
                tmp + fileUp1.FileName;
            fileUp1.SaveAs(path);
            if (CheckImg.CheckImgSize(path, _picSize, _picSize))
            {
                mo.Picture_small = tmp + fileUp1.FileName;
            }
            else
            {
                System.IO.File.Delete(path);
                Mxm.Common.MessageBox.Show(this, "上传图片不符合规格，请重新选择");
                return;
            }
        }
        try
        {
            Mxm.DAL.article mgr = new Mxm.DAL.article();
            mgr.Add(mo);
            Mxm.Common.MessageBox.Show(this, "提交完成");
        }
        catch (Exception ex)
        {
            throw ex;
        }        
    }
}
