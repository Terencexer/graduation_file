using System;
using System.Collections;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Configuration;
using DtCms.Common;

namespace DtCms.Web.UI
{
    public partial class BasePage : System.Web.UI.Page
    {
        protected internal DtCms.Model.WebSet SiteConfig = new DtCms.BLL.WebSet().loadConfig(Utils.GetXmlMapPath("Configpath"));
        public BasePage()
        {
            
        }

        /// <summary>
        /// 系统功能枚举，要与ManagePage.cs同步
        /// </summary>
        public enum Channel
        {
            //文章模块
            Article,
            //图文模块
            Pictures,
            //下载模块
            Downloads,
            //单页模块
            Contents
        }

        /// <summary>
        /// 返回当前模板全路径
        /// </summary>
        protected string SiteTemplatePath(string _skinname)
        {
            return SiteConfig.WebPath + "Templates/" + _skinname + "/";
        }

        /// <summary>
        /// 返回页面Meta信息
        /// </summary>
        protected string AddMetaInfo(string _keywords, string _description)
        {
            StringBuilder strTxt = new StringBuilder();
            strTxt.Append("<meta name=\"keywords\" content=\"" + Utils.DropHTML(_keywords, 250).Replace("\"", " ") + "\" />\n");
            strTxt.Append("<meta name=\"description\" content=\"" + Utils.DropHTML(_description, 250).Replace("\"", " ") + "\" />");
            return strTxt.ToString();
        }

        /// <summary>
        /// 返回分页字符串
        /// </summary>
        protected string PagerText(int _pcount, int _pagesize, int _page, string _link, string _divid, string _style)
        {
            StringBuilder strTxt = new StringBuilder();
            strTxt.Append("<link type=\"text/css\" rel=\"stylesheet\" href=\"" + SiteConfig.WebPath + "css/pagination.css\" />\n");
            strTxt.Append("<script type=\"text/javascript\" src=\"" + SiteConfig.WebPath + "js/jquery.pagination.js\"></script>\n");
            strTxt.Append("<script type=\"text/javascript\">\n");
            strTxt.Append("$(function(){\n");
            strTxt.Append("\t$(\"#" + _divid + "\").pagination(" + _pcount + ",{\n");
            strTxt.Append("\t\t callback:pageselectCallback,\n");
            strTxt.Append("\t\t prev_text:\"« 上一页\",\n");
            strTxt.Append("\t\t next_text:\"下一页 »\",\n");
            strTxt.Append("\t\t items_per_page:" + _pagesize + ",\n");
            strTxt.Append("\t\t num_display_entries:3,\n");
            strTxt.Append("\t\t current_page:" + _page + ",\n");
            strTxt.Append("\t\t num_edge_entries:2,\n");
            strTxt.Append("\t\t link_to:\"" + _link + "\"\n");
            strTxt.Append("\t});\n");
            strTxt.Append("});\n");
            strTxt.Append("function pageselectCallback(page_id, jq){\n");
            strTxt.Append("\t //alert(page_id); 回调函数，进一步使用请参阅说明文档\n");
            strTxt.Append("}\n");
            strTxt.Append("</script>\n");
            strTxt.Append("<div id=\"" + _divid + "\" class=\"" + _style + "\"></div>\n");
            return strTxt.ToString();
        }

        //===================================================================================================

        /// <summary>
        /// 返回伪静态统一链接地址
        /// </summary>
        protected string URLRewrite(string _key, params object[] _params)
        {
            Hashtable _siteurls = new DtCms.BLL.SiteUrl().loadConfig(Utils.GetXmlMapPath("Urlspath"));
            DtCms.Model.SiteUrl model = _siteurls[_key] as DtCms.Model.SiteUrl;
            if (model == null)
            {
                return "";
            }
            try
            {
                string _rewriteurl = string.Format(model.Path, _params);
                if (SiteConfig.IsUrlRewrite == 1)
                {
                    return SiteConfig.WebPath.TrimEnd('/') + _rewriteurl;
                }
                string _originalurl = model.Page;
                if (!string.IsNullOrEmpty(model.QueryString))
                {
                    _originalurl = model.Page + "?" + Regex.Replace(_rewriteurl, model.Pattern, model.QueryString, RegexOptions.None | RegexOptions.IgnoreCase);
                }
                return SiteConfig.WebPath.TrimEnd('/') + _originalurl;
            }
            catch
            {
                return "";
            }
        }

    }
}
