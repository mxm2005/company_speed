<%@ WebHandler Language="C#" Class="edit_product_type" %>

using System;
using System.Web;

public class edit_product_type : IHttpHandler {
    
    public void ProcessRequest (HttpContext context) {
        string resVal = "False";
        try
        {
            int type_id = 0;
            string type_name = "";
            if (context.Request.QueryString["type_id"] != null)
            {
                type_id = int.Parse((string)context.Request.QueryString["type_id"]);
            }
            if (context.Request.QueryString["type_name"] != null)
            {
                type_name = context.Request.QueryString["type_name"].ToString();
            }
            Mxm.DAL.product_type mgr = new Mxm.DAL.product_type();
            Mxm.Model.product_type mo = mgr.GetModel(type_id);
            mo.type_name = type_name;
            mgr.Update(mo);
            resVal = "True";
        }
        catch (Exception ex)
        {
            Mxm.Common.WriteError.WriteTxt(DateTime.Now.ToString() + ex.Message + ex.StackTrace);
        }
        context.Response.ContentType = "text/plain";
        context.Response.Write(resVal);
    }
 
    public bool IsReusable {
        get {
            return false;
        }
    }

}