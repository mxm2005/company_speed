<%@ WebHandler Language="C#" Class="download" %>

using System;
using System.Web;

public class download : IHttpHandler {
    
    public void ProcessRequest (HttpContext context) {
        string fName = context.Request.QueryString["path"].ToString();
        context.Response.TransmitFile(fName);        
    }
 
    public bool IsReusable {
        get {
            return false;
        }
    }

}