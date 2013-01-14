<%@ WebHandler Language="C#" Class="UpdateProductSort" %>

using System;
using System.Web;
using System.Text;

public class UpdateProductSort : IHttpHandler {
    
    public void ProcessRequest (HttpContext context) {
        bool resVal = false;
        string[] lst ={ "1" };
        if (context.Request.QueryString["ids"] != null)
        {
            lst = context.Request.QueryString["ids"].ToString().Split('#');
        }
        if (lst != null)
        {
            StringBuilder sb = new StringBuilder();
            string temp = "update product_type set sort={0} where type_id={1};";
            for (int i = 1; i <= lst.Length; i++)
            {
                sb.Append(string.Format(temp, i.ToString(), lst[i - 1].Trim()));
            }
            try
            {
                int count = Mxm.Common.DbHelperSQL.ExecuteSql(sb.ToString());
                if (count > 0)
                {
                    resVal = true;
                }
            }
            catch (Exception ex)
            {
                Mxm.Common.WriteError.WriteTxt(DateTime.Now.ToString() + ex.Message + ex.StackTrace);
            }
        }
        context.Response.ContentType = "text/plain";
        context.Response.Write(resVal.ToString());
    }
 
    public bool IsReusable {
        get {
            return false;
        }
    }

}