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

public partial class admin_download_add : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnSubmit_OnClick(object sender, EventArgs e)
    {
        Mxm.Model.download mo = new Mxm.Model.download();
        mo.create_time = DateTime.Now;
        mo.name = txtName.Text.Trim();        
        mo.remark = txtContent.InnerHtml;
        mo.sort = 0;
        if (fileUp.HasFile)
        {
            string fName = DateTime.Now.Ticks.ToString() + fileUp.FileName;
            string path = Server.MapPath(
                ConfigurationManager.AppSettings["downPath"].ToString()) + fName;
            fileUp.SaveAs(path);
            mo.path = fName;
        }
        if (picUp.HasFile)
        {
            string fName = DateTime.Now.Ticks.ToString() + picUp.FileName;
            string path = Server.MapPath(
                ConfigurationManager.AppSettings["imgPath"].ToString()) + fName;
            picUp.SaveAs(path);
            mo.picture = fName;
        }
        (new Mxm.DAL.download()).Add(mo);
        Mxm.Common.MessageBox.Show(this, "添加成功");
    }
}
