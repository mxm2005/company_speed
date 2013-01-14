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

public partial class news_detail : System.Web.UI.Page
{
    int _aid = 0;
    Mxm.DAL.article artMgr = new Mxm.DAL.article();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString["id"] != null)
        {
            _aid = int.Parse(Request.QueryString["id"].ToString());
        }
        ShowNews();
        ShowPreNext();
        SetTitle();
        SetBanner();
    }

    private void SetTitle()
    {
        this.Title += ConfigurationManager.AppSettings["title"].ToString();
    }

    private void SetBanner()
    {
        string path = Server.MapPath("/XmlData/banner.xml");
        topBanner.Src = Banner.GetBannerImg("news", path);
    }

    private void ShowNews()
    {
        if (_aid<=0)
        {
            return;
        }

        Mxm.Model.article mo = new Mxm.Model.article();
        mo = artMgr.GetModel(_aid);
        if (mo != null)
        {
            lbl_title.Text = mo.title;
            lbl_time.Text = mo.update_time.ToString();
            if (!string.IsNullOrEmpty(mo.Editor))
            {
                lbl_editor.Text = " <strong>新闻编辑：</strong>" + mo.Editor;
            }
            tdContent.InnerHtml = mo.content;
        }
    }

    /// <summary>
    /// 展示上一篇、下一篇
    /// </summary>
    private void ShowPreNext()
    {        
        //上一篇
        Mxm.Model.article mo = null;
        try
        {
            mo = artMgr.GetNextModel(_aid, 1, "type_id=1");
        }
        catch (Exception ex)
        {
            Session["ex"] = ex; 
            Response.Redirect("exception.aspx", true);
        }
        if (mo != null)
        {
            tdLink.InnerHtml = "上一篇：<a class='a-link' href=\"news_detail.aspx?id=" + mo.aid + "\">" +
                mo.title + "</a>";
        }
        else
        {
            tdLink.InnerHtml = "上一篇：暂无";
        }
        //下一篇
        mo = null;
        try
        {
            mo = artMgr.GetNextModel(_aid, 0, "type_id=1");
        }
        catch (Exception ex)
        {
            Session["ex"] = ex;
            Response.Redirect("exception.aspx", true);
        }
        if (mo != null)
        {
            tdLink.InnerHtml += "<br />下一篇：<a class='a-link' href=\"news_detail.aspx?id=" + mo.aid + "\">" +
                mo.title + "</a>";
        }
        else
        {
            tdLink.InnerHtml += "<br />下一篇：暂无";
        }
    }
}
