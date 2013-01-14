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

public partial class admin_product_edit : System.Web.UI.Page
{
    private int pid = 0;
    Mxm.DAL.production mgr = new Mxm.DAL.production();
    protected string _video = string.Empty;
    private int _picSize = int.Parse(ConfigurationManager.AppSettings["picSize"]);

    protected void Page_Load(object sender, EventArgs e)
    {
        InitArgs();
        InitType();
        if (!IsPostBack)
        {
            ShowProduct();
        }
    }

    private void InitArgs()
    {
        if (Request.QueryString["pid"] != null)
        {
            pid = int.Parse(Request.QueryString["pid"].ToString());
        }
    }

    private void InitType()
    {
        System.Collections.Generic.List<Mxm.Model.product_type> lst =
            new Mxm.DAL.product_type().GetListArray("parent_id<>0");
        ddlType.DataSource = lst;
        ddlType.DataTextField = "type_name";
        ddlType.DataValueField = "type_id";
        ddlType.DataBind();
    }

    private void ShowProduct()
    {
        Mxm.Model.production mo;
        try
        {
            mo = mgr.GetModel(pid);
            if (mo != null)
            {
                txtName.Text = mo.product_name;
                txtSummary.Value = mo.product_synopsis;
                txtContent.Value = mo.product_desc;
                if (mo.status > 0)
                {
                    chkStatus.Checked = true;
                }
                if (!string.IsNullOrEmpty(mo.picture_small))
                {
                    img.Src = ConfigurationManager.AppSettings["imgPath"] + mo.picture_small;
                }                
                if (!string.IsNullOrEmpty(mo.vidio))
                {
                    _video = ConfigurationManager.AppSettings["vidioPath"] + mo.vidio;
                }
                ListItem item = ddlType.Items.FindByValue(mo.product_type.ToString());
                if (item != null)
                {
                    ddlType.Items.FindByValue(mo.product_type.ToString()).Selected = true;
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
        //判断上传视频格式
        string type = vidioUp.FileName.Substring(vidioUp.FileName.LastIndexOf(".") + 1);
        if (vidioUp.HasFile && type != "flv" &&(!chk_video.Checked))
        {
            Mxm.Common.MessageBox.Show(this.Page, "视频格式不对");
            return;
        }
        
        Mxm.Model.production mo = mgr.GetModel(pid);
        mo.product_synopsis = CompanyCom.ChangeTagP(txtSummary.Value);
        mo.product_desc = txtContent.Value;
        mo.product_name = txtName.Text;
        mo.update_time = DateTime.Now;
        if (chkStatus.Checked)
        {
            mo.status = 1;
        }
        else
        {
            mo.status = 0;
        }
        if (Request.Form["ddlType"] != null)
        {
            mo.product_type = int.Parse(Request.Form["ddlType"]);
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
                mo.picture_small = tmp + fileUp1.FileName;
            }
            else
            {
                System.IO.File.Delete(path);
                Mxm.Common.MessageBox.Show(this, "上传图片不符合规格，请重新选择");
                return;
            }
        }
        if (fileUp.HasFile)
        {
            string tmp = DateTime.Now.Ticks.ToString();
            string path = Server.MapPath(
                ConfigurationManager.AppSettings["imgPath"].ToString()) +
                tmp + fileUp.FileName;
            fileUp.SaveAs(path);
            mo.picture = tmp + fileUp.FileName;
        }        
        if (!chk_video.Checked && vidioUp.HasFile)
        {
            string fName = DateTime.Now.Ticks.ToString() + vidioUp.FileName;
            string path = Server.MapPath(
                ConfigurationManager.AppSettings["vidioPath"].ToString()) + fName;
            vidioUp.SaveAs(path);
            mo.vidio = fName;
        }
        if (chk_video.Checked)
        {
            mo.vidio = "";
        }

        try
        {
            mgr.Update(mo);
            Mxm.Common.MessageBox.Show(this, "修改已保存");
        }
        catch (Exception ex)
        {
            Com.Mxm.TxtHelper.WriteTxt(DateTime.Now.ToString() + " " + ex.Message + ex.StackTrace);
            //throw ex;
        }
    }
}
