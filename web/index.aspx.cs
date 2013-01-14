using System;
using System.Data;
using System.Configuration;
using System.Collections.Generic;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

public partial class index : System.Web.UI.Page
{
    Mxm.DAL.article artMgr = new Mxm.DAL.article();
    Mxm.DAL.production prodMgr = new Mxm.DAL.production();
    Mxm.DAL.product_type typeMgr = new Mxm.DAL.product_type();
    protected string _banner = "";
    protected string _vidio = string.Empty;

    protected void Page_Load(object sender, EventArgs e)
    {        
        ShowProductType();
        ShowRecommendProd();
        ShowCompanyPic();
        ShowTextNews();
        SetTitle();
        SetBanner();
    }

    private void SetTitle()
    {
        this.Title += ConfigurationManager.AppSettings["title"].ToString();
    }

    private void SetBanner()
    {
       _banner = Banner.GetBannerImg("index", Server.MapPath("/XmlData/index.xml"));
       _vidio = ConfigurationManager.AppSettings["indexVidio"].ToString();
    }

    /// <summary>
    /// 显示产品分类展示块
    /// </summary>
    private void ShowProductType()
    {
        System.Text.StringBuilder sb = new System.Text.StringBuilder();
        List<Mxm.Model.product_type> lst = typeMgr.GetListArray("parent_id=0", 4);
        foreach (Mxm.Model.product_type mo in lst)
        {
            sb.Append("<div class='prod_index_list'>");
            sb.Append("<p class='kidtitle'>");
            sb.Append(Mxm.Common.Comm.GetShortString(mo.type_name, 8) + "</p>");
            sb.Append(GetListStr(mo.type_id));
            sb.Append("</div>");
        }
        sb.Append("<div class='clear'></div>");
        divProduct.InnerHtml = sb.ToString();
    }

    private string GetListStr(int type_id)
    {
        string resVal = "";
        //DataSet ds = prodMgr.GetList(5, 1, " product_type in(select type_id from product_type where parent_id=" + type_id +")");
        //if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        //{
        //    resVal += "<ul>";
        //    foreach (DataRow row in ds.Tables[0].Rows)
        //    {
        //        resVal += string.Format("<li class='li2' title='{0}'><a href='/productview.aspx?pid={2}'>{1}</a></li>",
        //            row["product_name"].ToString(),
        //            row["product_name"].ToString(),
        //            row["product_type"].ToString());
        //    }
        //    resVal += "</ul>";
        //}
        IList<Mxm.Model.product_type> lst = typeMgr.GetListArray("parent_id=" + type_id, 5);
        resVal += "<ul>";
        foreach (Mxm.Model.product_type row in lst)
        {
            resVal += string.Format("<li class='li2' title='{0}'><a href='/productlist.aspx?type={2}'>{1}</a></li>",
                row.type_name,
                row.type_name,
                row.type_id);
        }
        resVal += "</ul>";
        return resVal;
    }

    /// <summary>
    /// 显示推荐产品块，分组名称：首页走马灯产品
    /// </summary>
    private void ShowRecommendProd()
    {
        System.Text.StringBuilder sb = new System.Text.StringBuilder();
        string strTemp = @"<td>
            <div>
                <a href='{0}'>
                    <img alt='' border='0' height='126' src='{1}'
                        style='padding: 3px; width: 150px; margin-right: 20px; width: 126px;' /></a></div>
            <div>
                <a href='{2}' title='{3}'>{4}</a></div>
            </td>";
        string path = ConfigurationManager.AppSettings["imgPath"];
        IList<Mxm.Model.recommend_content> lst = new Mxm.DAL.recommend_content().GetListByGroupName("首页走马灯产品");
        if (lst.Count > 0)
        {
            foreach (Mxm.Model.recommend_content mo in lst)
            {
                sb.Append(string.Format(strTemp,
                    mo.url,
                    path + mo.picture,
                    mo.url,
                    mo.title,
                    Mxm.Common.Comm.GetShortString(mo.title, 12)
                    ));
            }
            tdRecProduct.InnerHtml = "<table cellpadding='0' cellspacing='0' align='center'><tr>" + sb.ToString() + "</tr></table>";            
        }
    }

    /// <summary>
    /// 显示公司环境
    /// </summary>
    private void ShowCompanyPic()
    {
        string resVal = "";
        string strTemp = @"<div class='company'>
            <div class='company-pic'>
                <a href='article_detail.aspx?id={0}' target='_blank'>
                    <img src='{1}' alt='{2}' width='120' height='120' border='0' /></a></div>
            <div class='company-name'>
                <a href='article_detail.aspx?id={3}'  title='{4}'>
                    <font color=''>{5}</font></a>
            </div>
        </div>";
        DataSet ds = artMgr.GetList(3, 1, "type_id=3");
        if (ds.Tables.Count > 0)
        {
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                int aid = (int)ds.Tables[0].Rows[i]["aid"];
                string title = ds.Tables[0].Rows[i]["title"].ToString();
                string content = ds.Tables[0].Rows[i]["content"].ToString();
                string img = ConfigurationManager.AppSettings["imgPath"].ToString()
                    + ds.Tables[0].Rows[i]["picture_small"].ToString();
                if (string.IsNullOrEmpty(ds.Tables[0].Rows[i]["picture_small"].ToString().Trim()))
                {
                    img = ConfigurationManager.AppSettings["nopic"].ToString();
                }

                resVal += string.Format(strTemp,
                    aid, img, title, aid, title, Mxm.Common.Comm.GetShortString(title, 15));
            }
        }
        divCompany.InnerHtml = resVal;
    }

    /// <summary>
    /// 显示新闻块
    /// </summary>
    private void ShowTextNews()
    {
        System.Text.StringBuilder sb = new System.Text.StringBuilder();
        string strTemp="<li><a href='news_detail.aspx?id={0}' title='{1}'>{2}</a></li>";
        string fName = "aid,title,content,picture_small";
        string where = "type_id=1";
        string order = "update_time";
        DataSet ds = artMgr.GetList(4, 1, fName, where, order, 1);
        if (ds.Tables.Count > 0&&ds.Tables[0].Rows.Count>0)
        {
            spanLink.InnerHtml = "<a href='news_detail.aspx?id=" + (int)ds.Tables[0].Rows[0]["aid"] + "'>" +
                Mxm.Common.Comm.GetShortString( ds.Tables[0].Rows[0]["title"].ToString(),20) + "</a>";
            string content = ds.Tables[0].Rows[0]["content"].ToString();
            string img = ds.Tables[0].Rows[0]["picture_small"].ToString().Trim();
            if (!string.IsNullOrEmpty(img))
            {
                imgNews.Src =ConfigurationManager.AppSettings["imgPath"]+ img;
            }
            else
            {
                imgNews.Src = ConfigurationManager.AppSettings["nopic"].ToString();
            }
            content = Mxm.Common.FiterHtml.ParseTags(content);
            spanContent.InnerHtml = Mxm.Common.Comm.GetShortString(content, 120);

            for (int i = 1; i <= ds.Tables[0].Rows.Count - 1; i++)
            {
                sb.Append(string.Format(strTemp,
                    (int)ds.Tables[0].Rows[i]["aid"],
                    (string)ds.Tables[0].Rows[i]["title"],
                    (string)ds.Tables[0].Rows[i]["title"]));
            }
        }
        ulTextNews.InnerHtml = sb.ToString();        
    }
}
