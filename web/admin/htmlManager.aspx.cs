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

public partial class admin_htmlManager : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            ShowList();
        }
    }

    private void ShowList()
    {
        string path = Server.MapPath("/XmlData/html.xml");
        if (System.IO.File.Exists(path))
        {
            DataTable dt = Com.Mxm.ReadXml.ReadToDt(path);
            rptList.DataSource = dt;
            rptList.DataBind();
        }
    }
}
