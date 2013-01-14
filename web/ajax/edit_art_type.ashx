<%@ WebHandler Language="C#" Class="edit_art_type" %>

using System;
using System.Web;

public class edit_art_type : IHttpHandler {
    
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
            Mxm.DAL.art_type mgr = new Mxm.DAL.art_type();
            Mxm.Model.art_type mo = mgr.GetModel(type_id);
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