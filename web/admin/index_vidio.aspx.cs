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

public partial class admin_index_vidio : System.Web.UI.Page
{
    protected string _vidio = string.Empty;
    protected void Page_Load(object sender, EventArgs e)
    {
        _vidio = ConfigurationManager.AppSettings["indexVidio"].ToString();
    }
    protected void btnOK_Click(object sender, EventArgs e)
    {
        if (up1.HasFile)
        {
            up1.SaveAs(Server.MapPath(_vidio));
            Mxm.Common.MessageBox.Show(this, "更新成功");
        }
    }
}
