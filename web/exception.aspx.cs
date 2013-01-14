﻿using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

public partial class exception : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.UrlReferrer != null)
        {
            lbl_url.Text = Request.UrlReferrer.ToString();
        }
        if (Session["ex"] != null)
        {
            Exception ex =(Exception) Session["ex"];
            divInfo.InnerHtml = ex.Message + "<br />" + ex.StackTrace;
            Session.Remove("ex");
        }
    }
}
