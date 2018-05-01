using System;
using System.IO;
using System.Text.RegularExpressions;
using System.Threading;
using System.Web;
using System.Configuration;
using System.Xml;
using DtCms.Common;

namespace DtCms.Web.UI
{
    /// <summary>
    /// DTCMS的HttpModule类
    /// </summary>
    public class HttpModule : System.Web.IHttpModule
    {
        /// <summary>
        /// 实现接口的Init方法
        /// </summary>
        /// <param name="context"></param>
        public void Init(HttpApplication context)
        {
            context.BeginRequest += new EventHandler(KillSqlFilter);
            context.BeginRequest += new EventHandler(ReUrl_BeginRequest);
        }

        /// <summary>
        /// 实现接口的Dispose方法
        /// </summary>
        public void Dispose()
        {

        }

        #region 过滤SQL注入危险字符
        /// <summary>
        /// 过滤SQL注入危险字符
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void KillSqlFilter(object sender, EventArgs e)
        {
            HttpContext context = ((HttpApplication)sender).Context;
            DtCms.Model.WebSet SiteConfig = new DtCms.BLL.WebSet().loadConfig(Utils.GetXmlMapPath("Configpath"));
            string killSqlFilter = SiteConfig.WebKillKeywords; //获取需要过滤的危险字符集
            //排除不需要过滤的目录
            bool isKill = true;
            string notKillPath = SiteConfig.WebManagePath + "|KindEditor"; //排除的目录列表
            string[] arrNotKillPath = notKillPath.Split('|');
            //取得发出请求的页面
            if (context.Request.UrlReferrer != null)
            {
                foreach (string str in arrNotKillPath)
                {
                    if (context.Request.UrlReferrer.ToString().ToLower().IndexOf(SiteConfig.WebPath + str.ToLower() + "/") > 0)
                    {
                        isKill = false;
                    }
                }
            }

            //遍历参数，管理目录和隐藏域除外
            if (isKill)
            {
                //遍历Post参数
                foreach (string i in context.Request.Form)
                {
                    if (i == "__VIEWSTATE") continue;
                    if (DtCms.Common.Utils.SqlFilter(killSqlFilter, context.Request.Form[i].ToString()))
                    {
                        context.Response.Write("<script>window.alert('您提交的参数中含有非法字符!');history.back();" + " </" + "script>");
                        context.Response.End();
                    }

                }
                //遍历Get参数。
                foreach (string i in context.Request.QueryString)
                {
                    if (DtCms.Common.Utils.SqlFilter(killSqlFilter, context.Request.QueryString[i].ToString()))
                    {
                        context.Response.Write("<script>window.alert('您提交的参数中含有非法字符!');history.back();" + " </" + "script>");
                        context.Response.End();
                    }
                }
            }
        }
        #endregion

        #region 重写Url
        /// <summary>
        /// 重写Url
        /// </summary>
        /// <param name="sender">事件的源</param>
        /// <param name="e">包含事件数据的 EventArgs</param>
        private void ReUrl_BeginRequest(object sender, EventArgs e)
        {
            HttpContext context = ((HttpApplication)sender).Context;
            string aspxPath = "aspx"; //站点aspx文件目录
            string requestPath = context.Request.Path.ToLower(); //获得当前页面，包含目录
            string requestPage = requestPath.Substring(requestPath.LastIndexOf("/")); //获得当前页面，不包含目录
            DtCms.Model.WebSet SiteConfig = new DtCms.BLL.WebSet().loadConfig(Utils.GetXmlMapPath("Configpath")); //获得站点配置信息
            //排除不需要URL重写的目录
            bool isRewritePath = true;
            string notRewritePath = SiteConfig.WebManagePath + "|Aspx|Css|Images|Js|KindEditor|Templates|Tools|UpLoadFiles|XmlConfig"; //排除的目录列表
            string[] arrNotRewritePath = notRewritePath.Split('|');
            foreach (string str in arrNotRewritePath)
            {
                if (requestPath.StartsWith(SiteConfig.WebPath + str.ToLower() + "/"))
                {
                    isRewritePath = false;
                }
            }

            //================当启用伪地址时==================
            if (SiteConfig.IsUrlRewrite == 1 && isRewritePath)
            {
                foreach (SiteUrls.URLRewrite url in SiteUrls.GetSiteUrls().Urls)
                {
                    if (Regex.IsMatch(requestPath, SiteConfig.WebPath.TrimEnd('/') + url.Pattern, RegexOptions.None | RegexOptions.IgnoreCase))
                    {
                        string newUrl = Regex.Replace(requestPath, SiteConfig.WebPath.TrimEnd('/') + url.Pattern, url.QueryString, RegexOptions.None | RegexOptions.IgnoreCase);
                        context.RewritePath(SiteConfig.WebPath + aspxPath + url.Page, string.Empty, newUrl);
                        return;
                    }
                }
            }

            //==============当不启用伪地址重写时==============
            //验证是否是aspx文件
            bool isAspxFile = false;
            if (requestPath.LastIndexOf(".") >= 0)
            {
                if (requestPath.Substring(requestPath.LastIndexOf(".")) == ".aspx")
                {
                    isAspxFile = true;
                }
            }
            //以下将前台页面映射到Aspx目录下
            if (isRewritePath && isAspxFile)
            {
                context.RewritePath(SiteConfig.WebPath + aspxPath + requestPage);
                return;
            }
        }
        #endregion

    }

    //////////////////////////////////////////////////////////////////////
    
    #region 站点伪Url信息类
    /// <summary>
    /// 站点伪Url信息类
    /// </summary>
    public class SiteUrls
    {
        #region 内部属性和方法
        private static object lockHelper = new object();
        private static volatile SiteUrls instance = null;

        string SiteUrlsFile = Utils.GetXmlMapPath("Urlspath");
        private System.Collections.ArrayList _Urls;
        public System.Collections.ArrayList Urls
        {
            get { return _Urls; }
            set { _Urls = value; }
        }

        private System.Collections.Specialized.NameValueCollection _Paths;
        public System.Collections.Specialized.NameValueCollection Paths
        {
            get { return _Paths; }
            set { _Paths = value; }
        }

        private SiteUrls()
        {
            Urls = new System.Collections.ArrayList();
            Paths = new System.Collections.Specialized.NameValueCollection();

            XmlDocument xml = new XmlDocument();

            xml.Load(SiteUrlsFile);

            XmlNode root = xml.SelectSingleNode("urls");
            foreach (XmlNode n in root.ChildNodes)
            {
                if (n.NodeType != XmlNodeType.Comment && n.Name.ToLower() == "rewrite")
                {
                    XmlAttribute name = n.Attributes["name"];
                    XmlAttribute path = n.Attributes["path"];
                    XmlAttribute page = n.Attributes["page"];
                    XmlAttribute querystring = n.Attributes["querystring"];
                    XmlAttribute pattern = n.Attributes["pattern"];

                    if (name != null && path != null && page != null && querystring != null && pattern != null)
                    {
                        Paths.Add(name.Value, path.Value);
                        Urls.Add(new URLRewrite(name.Value, pattern.Value, page.Value.Replace("^", "&"), querystring.Value.Replace("^", "&")));
                    }
                }
            }
        }
        #endregion

        public static SiteUrls GetSiteUrls()
        {
            if (instance == null)
            {
                lock (lockHelper)
                {
                    if (instance == null)
                    {
                        instance = new SiteUrls();
                    }
                }
            }
            return instance;

        }

        public static void SetInstance(SiteUrls anInstance)
        {
            if (anInstance != null)
                instance = anInstance;
        }

        public static void SetInstance()
        {
            SetInstance(new SiteUrls());
        }


        /// <summary>
        /// 重写伪地址
        /// </summary>
        public class URLRewrite
        {
            #region 成员变量
            private string _Name;
            public string Name
            {
                get { return _Name; }
                set { _Name = value; }
            }

            private string _Pattern;
            public string Pattern
            {
                get { return _Pattern; }
                set { _Pattern = value; }
            }

            private string _Page;
            public string Page
            {
                get { return _Page; }
                set { _Page = value; }
            }

            private string _QueryString;
            public string QueryString
            {
                get { return _QueryString; }
                set { _QueryString = value; }
            }
            #endregion

            #region 构造函数
            public URLRewrite(string name, string pattern, string page, string querystring)
            {
                _Name = name;
                _Pattern = pattern;
                _Page = page;
                _QueryString = querystring;
            }
            #endregion
        }
    }
    #endregion

}