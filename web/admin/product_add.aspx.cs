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

public partial class admin_product_add : System.Web.UI.Page
{
    private int _picSize = int.Parse(ConfigurationManager.AppSettings["picSize"]);
    protected void Page_Load(object sender, EventArgs e)
    {
        InitType();
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

    protected void btnSubmit_OnClick(object sender, EventArgs e)
    {
        if (vidioUp.HasFile)
        {
            //判断上传视频格式
            string type = vidioUp.FileName.Substring(vidioUp.FileName.LastIndexOf(".") + 1);
            if (type != "flv")
            {
                Mxm.Common.MessageBox.Show(this.Page, "视频格式不对");
                return;
            }
        }

        Mxm.DAL.production mgr = new Mxm.DAL.production();
        Mxm.Model.production mo = new Mxm.Model.production();
        mo.product_name = txtName.Text.Trim();
        mo.product_desc = txtContent.Value.Trim();
        mo.product_synopsis = CompanyCom.ChangeTagP(txtSummary.Value);
        mo.create_time = DateTime.Now;
        mo.update_time = DateTime.Now;
        if (chkStatus.Checked)
        {
            mo.status = 1;
        }
        else
        {
            mo.status = 0;
        }
        if (Request.Form["ddlType"]!=null)
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
            string fName = DateTime.Now.Ticks.ToString() + fileUp.FileName;
            string path = Server.MapPath(
                ConfigurationManager.AppSettings["imgPath"].ToString()) + fName;
            fileUp.SaveAs(path);
            mo.picture = fName;
        }
        if (vidioUp.HasFile)
        {            
            string fName = DateTime.Now.Ticks.ToString() + vidioUp.FileName;
            string path = Server.MapPath(
                ConfigurationManager.AppSettings["vidioPath"].ToString()) + fName;
            vidioUp.SaveAs(path); 
            mo.vidio = fName;
        }
        try
        {
            mgr.Add(mo);
            Mxm.Common.MessageBox.Show(this, "添加成功");
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
}
