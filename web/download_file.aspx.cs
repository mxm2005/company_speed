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
using System.IO;

public partial class download_file : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString["fileid"] != null)
        {
            string filePath = new Mxm.DAL.download().GetModel(
                int.Parse(Request.QueryString["fileid"].ToString())).path;
            filePath = Server.MapPath(ConfigurationManager.AppSettings["downPath"].ToString() + filePath);

            FileInfo fi = new FileInfo(filePath);
            Response.ClearHeaders();
            Response.AppendHeader("Content-Disposition", "attachment;filename="
                + string.Format("{0:n}{1}", System.Guid.NewGuid(), fi.Extension));
            Response.AddHeader("Content-Length", fi.Length.ToString());
            Response.AppendHeader("Last-Modified", fi.LastWriteTime.ToFileTime().ToString());
            Response.AppendHeader("Location", Request.Url.AbsoluteUri);
            Response.ContentType = "application/unknown";
            Response.WriteFile(filePath);            
        }
    }
}
