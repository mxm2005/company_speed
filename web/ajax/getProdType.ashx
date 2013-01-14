<%@ WebHandler Language="C#" Class="getProdType" %>

using System;
using System.Web;
using System.Collections.Generic;

public class getProdType : IHttpHandler {
    
    public void ProcessRequest (HttpContext context) {
        string resVal = "";

        int pare_id = 0;
        if (context.Request.QueryString["pare_id"] != null)
        {
            pare_id = int.Parse((string)context.Request.QueryString["pare_id"]);
        }
        List<Mxm.Model.product_type> lst = new Mxm.DAL.product_type().GetListArray("parent_id=" + pare_id);
        resVal = Com.Mxm.JsonHelper.ToJson(lst);
        
        context.Response.ContentType = "text/plain";
        context.Response.Write(resVal);
    }
 
    public bool IsReusable {
        get {
            return false;
        }
    }

}