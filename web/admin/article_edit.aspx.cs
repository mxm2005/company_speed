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

public partial class admin_article_edit : System.Web.UI.Page
{
    private int aid = 0;
    Mxm.DAL.article mgr = new Mxm.DAL.article();
    private int _picSize = int.Parse(ConfigurationManager.AppSettings["picSize"]);

    protected void Page_Load(object sender, EventArgs e)
    {
        InitArgs();        
        if (!IsPostBack)
        {
            InitType();
            ShowArticle();
        }
    }

    private void InitArgs()
    {
        if (Request.QueryString["aid"] != null)
        {
            aid = int.Parse(Request.QueryString["aid"].ToString());
        }
    }

    private void InitType()
    {
        System.Collections.Generic.List<Mxm.Model.art_type> lst = new Mxm.DAL.art_type().GetListArray("");
        ddlType.DataSource = lst;
        ddlType.DataTextField = "type_name";
        ddlType.DataValueField = "type_id";
        ddlType.DataBind();
    }

    private void ShowArticle()
    {        
        Mxm.Model.article mo;
        try
        {
            mo = mgr.GetModel(aid);
            if (mo != null)
            {
                txtAuthor.Text = mo.author;
                txtContent.Value = mo.content;
                txtEditor.Text = mo.Editor;
                txtSubTitle.Text = mo.Sub_title;
                txtTitle.Text = mo.title;
                ddlType.Items.FindByValue(mo.Type_id.ToString()).Selected = true;
                if (!string.IsNullOrEmpty(mo.Picture_small.Trim()))
                {
                    img.Src = ConfigurationManager.AppSettings["imgPath"].ToString() + mo.Picture_small;
                }
            }
        }
        catch (Exception ex)
        {            
            throw ex;
        }
    }

    protected void btnSubmit_OnClick(object sender, EventArgs e)
    {
        Mxm.Model.article mo = mgr.GetModel(aid);
        mo.author = txtAuthor.Text;
        mo.content = txtContent.Value;
        mo.title = txtTitle.Text;
        mo.Sub_title = txtSubTitle.Text;
        mo.update_time = DateTime.Now;
        mo.Editor = txtEditor.Text;
        if (!string.IsNullOrEmpty(Request.Form["ddlType"]))
        {
            mo.Type_id = int.Parse(Request.Form["ddlType"]);
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
            mgr.Update(mo);
            Mxm.Common.MessageBox.Show(this, "修改已保存");
        }
        catch (Exception ex)
        {
            throw ex;
        }        
    }
}
