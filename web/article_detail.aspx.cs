using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;

public partial class article_detail : System.Web.UI.Page
{
    int _aid = 0;
    Mxm.DAL.article artMgr = new Mxm.DAL.article();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString["id"] != null)
        {
            _aid = int.Parse(Request.QueryString["id"].ToString());
        }
        ShowArticle();        
        SetBanner();
    }

    private void SetBanner()
    {
        string path = Server.MapPath("/XmlData/banner.xml");
        topBanner.Src = Banner.GetBannerImg("article", path);
    }

    private void SetNavBar(int type)
    {
        //Mxm.Model.art_type mo = new Mxm.DAL.art_type().GetModel(type);
        //if (mo != null)
        //{
        //    lbl_nav.Text = " - <a href='/article_list.aspx?type=" + type + "' class='agray'>" + mo.type_name + "</a> - 详情";
        //}
        lbl_nav.Text = " - 文章详情";
        Title = "文章详情" + ConfigurationManager.AppSettings["title"];
    }

    private void ShowArticle()
    {
        if (_aid <= 0)
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
                lbl_editor.Text = " <strong>编辑：</strong>" + mo.Editor;
            }
            tdContent.InnerHtml = mo.content;
            SetNavBar(mo.Type_id);
            ShowPreNext(mo.Type_id);
        }
    }

    /// <summary>
    /// 展示上一篇、下一篇
    /// </summary>
    private void ShowPreNext(int type)
    {
        //上一篇
        Mxm.Model.article mo = null;
        try
        {
            mo = artMgr.GetNextModel(_aid, 1, "type_id=" + type);
        }
        catch (Exception ex)
        {
            Session["ex"] = ex;
            Response.Redirect("exception.aspx", true);
        }
        if (mo != null)
        {
            tdLink.InnerHtml = "上一篇：<a class='a-link' href=\"article_detail.aspx?id=" + mo.aid + "\">" +
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
            mo = artMgr.GetNextModel(_aid, 0, "type_id=" + type);
        }
        catch (Exception ex)
        {
            Session["ex"] = ex;
            Response.Redirect("exception.aspx", true);
        }
        if (mo != null)
        {
            tdLink.InnerHtml += "<br />下一篇：<a class='a-link' href=\"article_detail.aspx?id=" + mo.aid + "\">" +
                mo.title + "</a>";
        }
        else
        {
            tdLink.InnerHtml += "<br />下一篇：暂无";
        }
    }
}
