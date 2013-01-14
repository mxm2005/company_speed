using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.IO;
using System.Xml;
using System.Text;
using System.Text.RegularExpressions;
using System.Collections.Generic;

namespace Mxm.Common
{
    /// <summary>
    /// Comm 的摘要说明
    /// </summary>
    public static class Comm
    {
        /// <summary>
        /// 限制字符长度，超出的，截掉，加…
        /// </summary>
        /// <param name="strIn">输入原字符串</param>
        /// <param name="length">要求限制的长度</param>
        /// <returns></returns>
        public static string GetShortString(string strIn, int length)
        {
            if (strIn.Length > length)
            {
                return strIn.Substring(0, length);
            }
            else
            {
                return strIn;
            }
        }

        /// <summary>
        /// 获取当前网站的根目录物理路径
        /// </summary>
        /// <returns></returns>
        public static string GetServerPath()
        {
            return System.AppDomain.CurrentDomain.BaseDirectory;
        }

        /// <summary>
        ///MD5 加密
        /// </summary>
        public static string EncodeMD5(string str)
        {
            string resVal = "";
            resVal = System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(str, "MD5");
            return resVal;
        }

        /// <summary>
        /// 返回单个图片路径
        /// </summary>
        /// <param name="HTMLStr">HTML代码</param>
        /// <returns></returns>
        public static string GetImgUrl(string HTMLStr)
        {
            string str = string.Empty;
            //string sPattern = @"^<img\s+[^>]*>";
            Regex r = new Regex(@"<img\s+[^>]*\s*src\s*=\s*([']?)(?<url>\S+)'?[^>]*>",
            RegexOptions.Compiled);
            Match m = r.Match(HTMLStr.ToLower());
            if (m.Success)
                str = m.Result("${url}");
            return str;
        }
    }

    /// <summary>
    /// XmlAction XML 操作基类
    /// </summary>
    public class XmlAction : IDisposable
    {
        void IDisposable.Dispose() { }
        public XmlAction()
        {
            //
            // TODO: 在此处添加构造函数逻辑
            //
        }

        //以下为单一功能的静态类

        #region 读取XML到DataSet
        /**************************************************
         * 函数名称:GetXml(string XmlPath)
         * 功能说明:读取XML到DataSet
         * 参    数:XmlPath:xml文档路径
         * 使用示列:
         *          using EC; //引用命名空间
         *          string xmlPath = Server.MapPath("/EBDnsConfig/DnsConfig.xml"); //获取xml路径
         *          DataSet ds = EC.XmlObject.GetXml(xmlPath); //读取xml到DataSet中
         ************************************************/
        /// <summary>
        /// 功能:读取XML到DataSet中
        /// </summary>
        /// <param name="XmlPath">xml路径</param>
        /// <returns>DataSet</returns>
        public static DataSet GetXml(string XmlPath)
        {
            DataSet ds = new DataSet();
            ds.ReadXml(@XmlPath);
            return ds;
        }
        #endregion

        #region 读取xml文档并返回一个节点
        /**************************************************
         * 函数名称:ReadXmlReturnNode(string XmlPath,string Node)
         * 功能说明:读取xml文档并返回一个节点:适用于一级节点
         * 参    数: XmlPath:xml文档路径;Node 返回的节点名称
         * 适应用Xml:<?xml version="1.0" encoding="utf-8" ?>
         *           <root>
         *               <dns1>ns1.everdns.com</dns1>
         *          </root>
         * 使用示列:
         *          using EC; //引用命名空间
         *          string xmlPath = Server.MapPath("/EBDnsConfig/DnsConfig.xml"); //获取xml路径
         *          Response.Write(XmlObject.ReadXmlReturnNode(xmlPath, "mailmanager"));
         ************************************************/
        /// <summary>
        /// 读取xml文档并返回一个节点:适用于一级节点
        /// </summary>
        /// <param name="XmlPath">xml路径</param>
        /// <param name="NodeName">节点</param>
        /// <returns></returns>
        public static string ReadXmlReturnNode(string XmlPath, string Node)
        {
            XmlDocument docXml = new XmlDocument();
            docXml.Load(@XmlPath);
            XmlNodeList xn = docXml.GetElementsByTagName(Node);
            return xn.Item(0).InnerText.ToString();
        }
        #endregion

        #region 查找数据,返回一个DataSet
        /**************************************************
         * 函数名称:GetXmlData(string xmlPath, string XmlPathNode)
         * 功能说明:查找数据,返回当前节点的所有下级节点,填充到一个DataSet中
         * 参    数:xmlPath:xml文档路径;XmlPathNode:当前节点的路径
         * 使用示列:
         *          using EC; //引用命名空间
         *          string xmlPath = Server.MapPath("/EBDomainConfig/DomainConfig.xml"); //获取xml路径
         *          DataSet ds = new DataSet();
         *          ds = XmlObject.GetXmlData(xmlPath, "root/items");//读取当前路径
         *          this.GridView1.DataSource = ds;
         *          this.GridView1.DataBind();
         *          ds.Clear();
         *          ds.Dispose();
         * Xml示例:
         *         <?xml version="1.0" encoding="utf-8" ?>
         *            <root>
         *              <items name="xinnet">
         *                <url>http://www.paycenter.com.cn/cgi-bin/</url>
         *                <port>80</port>
         *              </items>
         *            </root>
         ************************************************/
        /// <summary>
        /// 查找数据,返回当前节点的所有下级节点,填充到一个DataSet中
        /// </summary>
        /// <param name="xmlPath">xml文档路径</param>
        /// <param name="XmlPathNode">节点的路径:根节点/父节点/当前节点</param>
        /// <returns></returns>
        public static DataSet GetXmlData(string xmlPath, string XmlPathNode)
        {
            XmlDocument objXmlDoc = new XmlDocument();
            objXmlDoc.Load(xmlPath);
            DataSet ds = new DataSet();
            StringReader read = new StringReader(objXmlDoc.SelectSingleNode(XmlPathNode).OuterXml);
            ds.ReadXml(read);
            return ds;
        }


        #endregion

        #region 更新Xml节点内容
        /**************************************************
         * 函数名称:XmlNodeReplace(string xmlPath,string Node,string Content)
         * 功能说明:更新Xml节点内容
         * 参    数:xmlPath:xml文档路径;Node:当前节点的路径;Content:内容
         * 使用示列:
         *          using EC; //引用命名空间
         *          string xmlPath = Server.MapPath("/EBDomainConfig/DomainConfig.xml"); //获取xml路径
         *          XmlObject.XmlNodeReplace(xmlPath, "root/test", "56789"); //更新节点内容
         ************************************************/
        /// <summary>
        /// 更新Xml节点内容
        /// </summary>
        /// <param name="xmlPath">xml路径</param>
        /// <param name="Node">要更换内容的节点:节点路径根节点/父节点/当前节点</param>
        /// <param name="Content">新的内容</param>
        public static void XmlNodeReplace(string xmlPath, string Node, string Content)
        {
            XmlDocument objXmlDoc = new XmlDocument();
            objXmlDoc.Load(xmlPath);
            objXmlDoc.SelectSingleNode(Node).InnerText = Content;
            objXmlDoc.Save(xmlPath);

        }

        #endregion

        #region 删除XML节点和此节点下的子节点
        /**************************************************
         * 函数名称:XmlNodeDelete(string xmlPath,string Node)
         * 功能说明:删除XML节点和此节点下的子节点
         * 参    数:xmlPath:xml文档路径;Node:当前节点的路径;
         * 使用示列:
         *          using EC; //引用命名空间
         *          string xmlPath = Server.MapPath("/EBDomainConfig/DomainConfig.xml"); //获取xml路径
         *          XmlObject.XmlNodeDelete(xmlPath, "root/test"); //删除当前节点
         ************************************************/
        /// <summary>
        /// 删除XML节点和此节点下的子节点
        /// </summary>
        /// <param name="xmlPath">xml文档路径</param>
        /// <param name="Node">节点路径</param>
        public static void XmlNodeDelete(string xmlPath, string Node)
        {
            XmlDocument objXmlDoc = new XmlDocument();
            objXmlDoc.Load(xmlPath);
            string mainNode = Node.Substring(0, Node.LastIndexOf("/"));
            objXmlDoc.SelectSingleNode(mainNode).RemoveChild(objXmlDoc.SelectSingleNode(Node));
            objXmlDoc.Save(xmlPath);
        }

        #endregion


    }

    /// <summary>
    /// FiterHtml 的摘要说明
    /// </summary>
    public class FiterHtml
    {
        public FiterHtml() { }
        ///   <summary>
        ///   去除HTML标记
        ///   </summary>
        public static string NoHTML(string Htmlstring)
        {
            //删除脚本
            Htmlstring = Regex.Replace(Htmlstring, @"<script[^>]*?>.*?</script>", "",
              RegexOptions.IgnoreCase);
            //删除HTML
            Htmlstring = Regex.Replace(Htmlstring, @"<(.[^>]*)>", "",
              RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"([\r\n])[\s]+", "",
              RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"-->", "", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"<!--.*", "", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(quot|#34);", "\"",
              RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(amp|#38);", "&",
              RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(lt|#60);", "<",
              RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(gt|#62);", ">",
              RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(nbsp|#160);", "   ",
              RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(iexcl|#161);", "\xa1",
              RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(cent|#162);", "\xa2",
              RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(pound|#163);", "\xa3",
              RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(copy|#169);", "\xa9",
              RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&#(\d+);", "",
              RegexOptions.IgnoreCase);
            Htmlstring.Replace("<", "");
            Htmlstring.Replace(">", "");
            Htmlstring.Replace("\r\n", "");
            Htmlstring = HttpContext.Current.Server.HtmlEncode(Htmlstring).Trim();

            return Htmlstring;
        }

        public static string StripHTML(string strHtml)
        {
            string[] aryReg =
            {
              @"<script[^>]*?>.*?</script>",
              @"<(\/\s*)?!?((\w+:)?\w+)(\w+(\s*=?\s*(([""'])(\\[",
               @"'tbnr]|[^\7])*?\7|\w+)|.{0})|\s)*?(\/\s*)?>", @"([\r\n])[\s]+",
                @"&(quot|#34);", @"&(amp|#38);", @"&(lt|#60);", @"&(gt|#62);",
                @"&(nbsp|#160);", @"&(iexcl|#161);", @"&(cent|#162);", @"&(pound|#163);",
                @"&(copy|#169);", @"&#(\d+);", @"-->", @"<!--.*\n"
            };

            string[] aryRep =
            {
              "", "", "", "\"", "&", "<", ">", "   ", "\xa1",  //chr(161),
              "\xa2",  //chr(162),
              "\xa3",  //chr(163),
              "\xa9",  //chr(169),
              "", "\r\n", ""
            };

            string newReg = aryReg[0];
            string strOutput = strHtml;
            for (int i = 0; i < aryReg.Length; i++)
            {
                Regex regex = new Regex(aryReg[i], RegexOptions.IgnoreCase);
                strOutput = regex.Replace(strOutput, aryRep[i]);
            }
            strOutput.Replace("<", "");
            strOutput.Replace(">", "");
            strOutput.Replace("\r\n", "");
            return strOutput;
        }

        ///   <summary>
        ///   移除HTML标签
        ///   </summary>
        ///   <param   name="HTMLStr">HTMLStr</param>
        public static string ParseTags(string HTMLStr)
        {
            return System.Text.RegularExpressions.Regex.Replace(HTMLStr, "<[^>]*>", "");
        }

        ///   <summary>
        ///   取出文本中的图片地址
        ///   </summary>
        ///   <param   name="HTMLStr">HTMLStr</param>
        public static string GetImgUrl(string HTMLStr)
        {
            string str = string.Empty;
            string sPattern = @"^<img\s+[^>]*>";
            Regex r = new Regex(@"<img\s+[^>]*\s*src\s*=\s*([']?)(?<url>\S+)'?[^>]*>",
              RegexOptions.Compiled);
            Match m = r.Match(HTMLStr.ToLower());
            if (m.Success)
                str = m.Result("${url}");
            return str;
        }

    }
}