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

public partial class admin_banner_other : System.Web.UI.Page
{
    string _path = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        _path = Server.MapPath("/XmlData/banner.xml");
        BindData();
    }

    private void BindData()
    {
        rptList.DataSource = Com.Mxm.ReadXml.ReadToDt(_path);
        rptList.DataBind();
    }

    protected void btnOK_Click(object sender, EventArgs e)
    {
        DataTable dt = new DataTable();
        dt.Columns.Add("img");
        dt.Columns.Add("key");
        string upPath = Server.MapPath(ConfigurationManager.AppSettings["imgPath"].ToString());
        foreach (RepeaterItem item in rptList.Items)
        {
            string key = ((TextBox)item.FindControl("txtUrl")).Text;
            FileUpload up = ((FileUpload)item.FindControl("upload"));
            string img = ((HtmlImage)item.FindControl("img_banner")).Src;
            if (up.HasFile)
            {                
                up.SaveAs(upPath + up.FileName);
                img = ConfigurationManager.AppSettings["imgPath"] + up.FileName;
            }
            dt.Rows.Add(img, key);
        }
        if (dt != null && dt.Rows.Count > 0)
        {
            Banner.WriteXml(_path, dt);
        }
        Mxm.Common.MessageBox.Show(this, "保存成功");
        Response.AddHeader("Refresh", "0");
    }
}
