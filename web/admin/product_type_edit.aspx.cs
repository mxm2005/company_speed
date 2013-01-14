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

public partial class admin_product_type_edit : System.Web.UI.Page
{
    int _type_id = 0;
    Mxm.DAL.product_type prodMgr = new Mxm.DAL.product_type();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString["type_id"] != null)
        {
            _type_id = int.Parse(Request.QueryString["type_id"].ToString());
        }
        if (!IsPostBack)
        {
            BindType();
        }
    }

    private void BindType()
    {
        if (_type_id > 0)
        {
            Mxm.Model.product_type mo = prodMgr.GetModel(_type_id);
            if (mo != null)
            {
                txtTypeName.Text = mo.type_name;
                txtTypeRemark.Text = mo.remark;
                if (!string.IsNullOrEmpty(mo.banner))
                {
                    imgOld.ImageUrl = ConfigurationManager.AppSettings["imgPath"].ToString() + mo.banner;
                }
            }
        }
    }

    protected void btnOK_Click(object sender, EventArgs e)
    {
        if (string.IsNullOrEmpty(txtTypeName.Text.Trim()))
        {
            Mxm.Common.MessageBox.Show(this, "分类名称不允许为空");
            return;
        }
        Mxm.Model.product_type mo = prodMgr.GetModel(_type_id);
        mo.type_name = txtTypeName.Text.Trim();
        mo.remark = txtTypeRemark.Text.Trim();
        if (upload.HasFile)
        {
            string filePath = Server.MapPath(ConfigurationManager.AppSettings["imgPath"].ToString() +
                upload.FileName);
            upload.SaveAs(filePath);
            mo.banner = upload.FileName;
        }
        try
        {
            prodMgr.Update(mo);
            Mxm.Common.MessageBox.Show(this, "保存成功");
        }
        catch (Exception ex)
        {
            Mxm.Common.WriteError.WriteTxt(DateTime.Now.ToString() + " " + ex.StackTrace);
        }
        Response.AddHeader("Refresh", "0");
    }
}
