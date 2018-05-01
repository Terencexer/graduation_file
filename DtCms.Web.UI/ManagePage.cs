using System;
using System.IO;
using System.Xml;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Web;
using System.Web.UI.WebControls;
using DtCms.Common;

namespace DtCms.Web.UI
{
    public class ManagePage : System.Web.UI.Page
    {
        protected internal DtCms.Model.WebSet webset;
        public ManagePage()
        {
            this.Load += new EventHandler(ManagePage_Load);
            webset = new DtCms.BLL.WebSet().loadConfig(Utils.GetXmlMapPath("Configpath"));
        }

        void ManagePage_Load(object sender, EventArgs e)
        {
            if (!IsAdminLogin())
            {
                Response.Write("<script>parent.location.href='" + webset.WebPath + webset.WebManagePath + "/login.aspx'</script>");
                Response.End();
            }
        }

        /// <summary>
        /// 判断管理员是否已经登录(解决Session超时问题)
        /// </summary>
        public bool IsAdminLogin()
        {
            //如果Session为Null
            if (Session["AdminNo"] != null && Session["AdminName"] != null && Session["AdminLevel"] != null && Session["AdminType"] != null)
            {
                return true;
            }
            else
            {
                //检查Cookies
                string adminname = Utils.GetCookie("AdminName", "DtCms"); //解密用户名
                string adminpwd = Utils.GetCookie("AdminPwd", "DtCms");
                if (adminname != "" && adminpwd != "")
                {
                    adminname = DESEncrypt.Decrypt(adminname); //解密用户名
                    DtCms.BLL.Administrator bll = new DtCms.BLL.Administrator();
                    if (bll.chkAdminLogin(adminname, adminpwd))
                    {
                        DtCms.Model.Administrator model = new DtCms.Model.Administrator();
                        model = bll.GetModel(adminname);
                        Session["AdminNo"] = model.Id;
                        Session["AdminName"] = model.UserName;
                        Session["AdminType"] = model.UserType;
                        Session["AdminLevel"] = model.UserLevel;
                        return true;
                    }
                }
            }
            return false;
        }

        /// <summary>
        /// 判断用户权限
        /// </summary>
        protected void chkLoginLevel(string pagestr)
        {
            string msbox = "";
            int utype = int.Parse(Session["AdminType"].ToString());
            string ulevel = Session["AdminLevel"].ToString();
            if (utype > 1)
            {
                pagestr += ",";
                if (ulevel.IndexOf(pagestr) == -1)
                {
                    msbox += "<script type=\"text/javascript\">\n";
                    msbox += "parent.jsmsg(350,230,\"警告提示\",\"<b>没有管理权限</b>您没有权限管理该功能，请勿非法进入。\",\"back\")\n";
                    msbox += "</script>\n";
                    //ClientScript.RegisterClientScriptBlock(Page.GetType(), "JsMsg", msbox);
                    Response.Write(msbox);
                    Response.End();
                }
            }
        }

        /// <summary>
        /// 遮罩提示窗口
        /// </summary>
        /// <param name="w">宽度</param>
        /// <param name="h">高度</param>
        /// <param name="msgtitle">窗口标题</param>
        /// <param name="msgbox">提示文字</param>
        /// <param name="url">返回地址</param>
        /// <param name="msgcss">CSS样式</param>
        protected void JscriptMsg(int w, int h, string msgtitle, string msgbox, string url, string msgcss)
        {
            string msbox = "";
            msbox += "<script type=\"text/javascript\">\n";
            msbox += "parent.jsmsg(" + w + "," + h + ",\"" + msgtitle + "\",\"" + msgbox + "\",\"" + url + "\",\"" + msgcss + "\")\n";
            msbox += "</script>\n";
            ClientScript.RegisterClientScriptBlock(Page.GetType(), "JsMsg", msbox);
        }

        /// <summary>
        /// 添加编辑删除提示
        /// </summary>
        /// <param name="msgtitle">提示文字</param>
        /// <param name="url">返回地址</param>
        /// <param name="msgcss">CSS样式</param>
        protected void JscriptPrint(string msgtitle, string url, string msgcss)
        {
            string msbox = "";
            msbox += "<script type=\"text/javascript\">\n";
            msbox += "parent.jsprint(\"" + msgtitle + "\",\"" + url + "\",\"" + msgcss + "\")\n";
            msbox += "</script>\n";
            ClientScript.RegisterClientScriptBlock(Page.GetType(), "JsPrint", msbox);
        }

        //============================================================================================

        /// <summary>
        /// 系统功能枚举，要与BasePage.cs同步
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
        /// 返回系统该模块的管理URI地址
        /// </summary>
        public string ChannelUrl(Channel channel)
        {
            switch (channel)
            {
                case Channel.Article:
                    return "/Admin/Article/List.aspx";
                    break;
                case Channel.Pictures:
                    return "/Admin/Pictures/List.aspx";
                    break;
                case Channel.Downloads:
                    return "/Admin/Downloads/List.aspx";
                    break;
                case Channel.Contents:
                    return "/Admin/Contents/List.aspx";
                    break;
            }
            return null;
        }

        /// <summary>
        /// 绑定类别DropDownList控制
        /// </summary>
        /// <param name="parentId">父类ID</param>
        /// /// <param name="firstItemTxt">第一项显示的文字</param>
        /// <param name="kindId">大类ID</param>
        /// <param name="ddl">要绑定的DropDownList控件</param>
        protected void ChannelTreeBind(int parentId, string firstItemTxt, int kindId, DropDownList ddl)
        {
            DtCms.BLL.Channel cbll = new DtCms.BLL.Channel();
            DataTable dt = cbll.GetList(parentId, kindId);

            ddl.Items.Clear();
            ddl.Items.Add(new ListItem(firstItemTxt, ""));
            foreach (DataRow dr in dt.Rows)
            {
                string Id = dr["Id"].ToString();
                int ClassLayer = int.Parse(dr["ClassLayer"].ToString());
                string Title = dr["Title"].ToString().Trim();

                if (ClassLayer == 1)
                {
                    ddl.Items.Add(new ListItem(Title, Id));
                }
                else
                {
                    Title = "├ " + Title;
                    Title = Utils.StringOfChar(ClassLayer - 1, "　") + Title;
                    ddl.Items.Add(new ListItem(Title, Id));
                }
            }
        }

        //==================================以下为组合URL语句的函数===================================
        /// <summary>
        /// 组合URL语句
        /// </summary>
        /// <param name="_classId">类别ID</param>
        /// <param name="_keywords">关健字</param>
        /// <returns></returns>
        protected string CombUrlTxt(int _classId, string _keywords)
        {
            StringBuilder strTemp = new StringBuilder();
            if (_classId > 0)
            {
                strTemp.Append("classId=" + _classId.ToString() + "&");
            }
            if (!string.IsNullOrEmpty(_keywords))
            {
                strTemp.Append("keywords=" + HttpContext.Current.Server.UrlEncode(_keywords) + "&");
            }

            return strTemp.ToString();
        }

        /// <summary>
        /// 组合URL语句
        /// </summary>
        /// <param name="_keywords">关健字</param>
        /// <param name="_property">属性</param>
        /// <returns></returns>
        protected string CombUrlTxt(string _keywords, string _property)
        {
            StringBuilder strTemp = new StringBuilder();
            _keywords = _keywords.Replace("'", "");
            if (!string.IsNullOrEmpty(_keywords))
            {
                strTemp.Append("keywords=" + HttpUtility.UrlEncode(_keywords) + "&");
            }
            if (!string.IsNullOrEmpty(_property))
            {
                strTemp.Append("property=" + _property + "&");
            }

            return strTemp.ToString();
        }

        /// <summary>
        /// 组合URL语句
        /// </summary>
        /// <param name="_classId">类别ID</param>
        /// <param name="_keywords">关健字</param>
        /// <param name="_property">属性</param>
        /// <returns></returns>
        protected string CombUrlTxt(int _classId, string _keywords, string _property)
        {
            StringBuilder strTemp = new StringBuilder();
            _keywords = _keywords.Replace("'", "");
            if (_classId > 0)
            {
                strTemp.Append("classId=" + _classId.ToString() + "&");
            }
            if (!string.IsNullOrEmpty(_keywords))
            {
                strTemp.Append("keywords=" + HttpContext.Current.Server.UrlEncode(_keywords) + "&");
            }
            if (!string.IsNullOrEmpty(_property))
            {
                strTemp.Append("property=" + _property + "&");
            }

            return strTemp.ToString();
        }

        /// <summary>
        /// 组合URL语句(用于评论)
        /// </summary>
        /// <param name="_kindId">大类ID</param>
        /// <param name="_parentId">信息ID</param>
        /// <param name="_keywords">关健字</param>
        /// <param name="_property">属性</param>
        /// <returns></returns>
        protected string CombUrlTxt(int _kindId, int _parentId, string _keywords, string _property)
        {
            StringBuilder strTemp = new StringBuilder();
            _keywords = _keywords.Replace("'", "");
            if (_kindId >= 0)
            {
                strTemp.Append("kindId=" + _kindId.ToString() + "&");
            }
            if (_parentId > 0)
            {
                strTemp.Append("parentId=" + _parentId.ToString() + "&");
            }
            if (!string.IsNullOrEmpty(_keywords))
            {
                strTemp.Append("keywords=" + HttpContext.Current.Server.UrlEncode(_keywords) + "&");
            }
            if (!string.IsNullOrEmpty(_property))
            {
                strTemp.Append("property=" + _property + "&");
            }

            return strTemp.ToString();
        }

        /// <summary>
        /// 组合URL语句(用于广告)
        /// </summary>
        /// <param name="_pid">广告位ID</param>
        /// <param name="_keywords">关健字</param>
        /// <returns></returns>
        protected string CombAdUrlTxt(int _pid, string _keywords)
        {
            StringBuilder strTemp = new StringBuilder();
            _keywords = _keywords.Replace("'", "");
            if (!string.IsNullOrEmpty(_keywords))
            {
                strTemp.Append("keywords=" + HttpUtility.UrlEncode(_keywords) + "&");
            }
            if (_pid > 0)
            {
                strTemp.Append("Pid=" + _pid + "&");
            }

            return strTemp.ToString();
        }

        //==================================以下为组合SQL语句的函数===================================
        /// <summary>
        /// 组合SQL查询语句
        /// </summary>
        /// <param name="_keywords">关健字</param>
        /// <param name="_property">属性</param>
        /// <returns></returns>
        protected string CombSqlTxt(string _keywords, string _property)
        {
            StringBuilder strTemp = new StringBuilder();
            _keywords = _keywords.Replace("'", "");
            if (!string.IsNullOrEmpty(_keywords))
            {
                strTemp.Append(" and Title like '%" + _keywords + "%'");
            }

            if (!string.IsNullOrEmpty(_property))
            {
                switch (_property)
                {
                    case "isLock":
                        strTemp.Append(" and IsLock=1");
                        break;
                    case "unIsLock":
                        strTemp.Append(" and IsLock=0");
                        break;
                    case "isMsg":
                        strTemp.Append(" and IsMsg=1");
                        break;
                    case "isTop":
                        strTemp.Append(" and IsTop=1");
                        break;
                    case "isRed":
                        strTemp.Append(" and IsRed=1");
                        break;
                    case "isHot":
                        strTemp.Append(" and IsHot=1");
                        break;
                    case "isSlide":
                        strTemp.Append(" and IsSlide=1");
                        break;
                }
            }

            return strTemp.ToString();
        }

        /// <summary>
        /// 组合SQL查询语句
        /// </summary>
        /// <param name="_kindId">栏目ID</param>
        /// <param name="_classId">类别ID</param>
        /// <param name="_keywords">关健字</param>
        /// <returns></returns>
        protected string CombSqlTxt(int _kindId, int _classId, string _keywords)
        {
            StringBuilder strTemp = new StringBuilder();
            _keywords = _keywords.Replace("'", "");
            if (_classId > 0)
            {
                strTemp.Append(" and ClassId in(select Id from dt_Channel where KindId=" + _kindId + " and ClassList like '%," + _classId + ",%')");
            }
            if (!string.IsNullOrEmpty(_keywords))
            {
                strTemp.Append(" and Title like '%" + _keywords + "%'");
            }

            return strTemp.ToString();
        }
        
        /// <summary>
        /// 组合SQL查询语句
        /// </summary>
        /// <param name="_kindId">栏目ID</param>
        /// <param name="_classId">类别ID</param>
        /// <param name="_keywords">关健字</param>
        /// <param name="_property">属性</param>
        /// <returns></returns>
        protected string CombSqlTxt(int _kindId, int _classId, string _keywords, string _property)
        {
            StringBuilder strTemp = new StringBuilder();
            _keywords = _keywords.Replace("'", "");
            if (_classId > 0)
            {
                strTemp.Append(" and ClassId in(select Id from dt_Channel where KindId=" + _kindId + " and ClassList like '%," + _classId + ",%')");
            }
            if (!string.IsNullOrEmpty(_keywords))
            {
                strTemp.Append(" and Title like '%" + _keywords + "%'");
            }
            if (!string.IsNullOrEmpty(_property))
            {
                switch (_property)
                {
                    case "isLock":
                        strTemp.Append(" and IsLock=1");
                        break;
                    case "unIsLock":
                        strTemp.Append(" and IsLock=0");
                        break;
                    case "isMsg":
                        strTemp.Append(" and IsMsg=1");
                        break;
                    case "isTop":
                        strTemp.Append(" and IsTop=1");
                        break;
                    case "isRed":
                        strTemp.Append(" and IsRed=1");
                        break;
                    case "isHot":
                        strTemp.Append(" and IsHot=1");
                        break;
                    case "isSlide":
                        strTemp.Append(" and IsSlide=1");
                        break;
                }
            }

            return strTemp.ToString();
        }

        /// <summary>
        /// 组合SQL查询语句(用于评论)
        /// </summary>
        /// <param name="_kindId">栏目ID</param>
        /// <param name="_parentId">信息ID</param>
        /// <param name="_keywords">关健字</param>
        /// <param name="_property">属性</param>
        /// <returns></returns>
        protected string CombPlSqlTxt(int _kindId, int _parentId, string _keywords, string _property)
        {
            StringBuilder strTemp = new StringBuilder();
            _keywords = _keywords.Replace("'", "");
            if (_kindId >= 0)
            {
                strTemp.Append(" and KindId=" + _kindId);
            }
            if (_parentId > 0)
            {
                strTemp.Append(" and ParentId=" + _parentId);
            }
            if (!string.IsNullOrEmpty(_keywords))
            {
                strTemp.Append(" and (UserName like '%" + _keywords + "%' or Content like '%" + _keywords + "%')");
            }
            if (!string.IsNullOrEmpty(_property))
            {
                switch (_property)
                {
                    case "isLock":
                        strTemp.Append(" and IsLock=1");
                        break;
                    case "unIsLock":
                        strTemp.Append(" and IsLock=0");
                        break;
                }
            }

            return strTemp.ToString();
        }

        /// <summary>
        ///  组合SQL查询语句(用于广告)
        /// </summary>
        /// <param name="_keywords">关健字</param>
        /// <param name="_property">属性</param>
        /// <returns></returns>
        protected string CombAdSqlTxt(string _keywords, string _property)
        {
            StringBuilder strTemp = new StringBuilder();
            _keywords = _keywords.Replace("'", "");
            if (!string.IsNullOrEmpty(_keywords))
            {
                strTemp.Append(" and Title like '%" + _keywords + "%'");
            }
            if (!string.IsNullOrEmpty(_property))
            {
                strTemp.Append(" and AdType=" + _property);
            }

            return strTemp.ToString();
        }

        /// <summary>
        /// 组合SQL查询语句(用于广告)
        /// </summary>
        /// <param name="_pid">广告位ID</param>
        /// <param name="_keywords">关健字</param>
        /// <returns></returns>
        protected string CombAdSqlTxt(int _pid, string _keywords)
        {
            StringBuilder strTemp = new StringBuilder();
            _keywords = _keywords.Replace("'", "");
            if (!string.IsNullOrEmpty(_keywords))
            {
                strTemp.Append(" and Title like '%" + _keywords + "%'");
            }
            if (_pid > 0)
            {
                strTemp.Append(" and Aid=" + _pid);
            }

            return strTemp.ToString();
        }

        //==================================以下为文件操作函数===================================
        /// <summary>
        /// 删除单个文件
        /// </summary>
        /// <param name="_filepath">文件相对路径</param>
        protected void DeleteFile(string _filepath)
        {
            if (string.IsNullOrEmpty(_filepath))
            {
                return;
            }
            string fullpath = Utils.GetMapPath(_filepath);
            if (File.Exists(fullpath))
            {
                File.Delete(fullpath);
            }
        }

        /// <summary>
        /// 生成缩略图的方法
        /// </summary>
        /// <param name="_filepath">文件相对路径</param>
        /// <returns></returns>
        protected string MakeThumbnail(string _filepath)
        {
            if (!string.IsNullOrEmpty(_filepath) && webset.IsThumbnail == 1)
            {
                string _filename = _filepath.Substring(_filepath.LastIndexOf("/") + 1);
                string _newpath = webset.WebFilePath;
                //检查保存的路径 是否有/开头结尾
                if (_newpath.StartsWith("/") == false)
                {
                    _newpath = "/" + _newpath;
                }
                if (_newpath.EndsWith("/") == false)
                {
                    _newpath = _newpath + "/";
                }
                _newpath = _newpath + "Thumbnail/";

                //检查是否有该路径没有就创建
                if (!Directory.Exists(Utils.GetMapPath(_newpath)))
                {
                    Directory.CreateDirectory(Utils.GetMapPath(_newpath));
                }
                //调用生成类方法
                ImageThumbnailMake.MakeThumbnail(_filepath, _newpath + _filename, webset.ProWidth, webset.ProHight, "Cut");

                return _newpath + _filename;
            }

            return _filepath;
        }

        /// <summary>
        /// 日志写入方法
        /// </summary>
        /// <param name="str"></param>
        protected void SaveLogs(string str)
        {
            if (webset.WebLogStatus == 0)
            {
                return;
            }
            DtCms.BLL.SystemLog bll = new DtCms.BLL.SystemLog();
            DtCms.Model.SystemLog model = new DtCms.Model.SystemLog();
            if (Session["AdminName"] != null)
            {
                model.UserName = Session["AdminName"].ToString();
            }
            model.Title = str;
            model.AddTime = DateTime.Now;
            bll.Add(model);
        }

        /// <summary>
        /// 日志写入方法
        /// </summary>
        /// <param name="str"></param>
        public void SaveLogs(string username, string str)
        {
            if (webset.WebLogStatus == 0)
            {
                return;
            }
            DtCms.BLL.SystemLog bll = new DtCms.BLL.SystemLog();
            DtCms.Model.SystemLog model = new DtCms.Model.SystemLog();
            model.UserName = username;
            model.Title = str;
            model.AddTime = DateTime.Now;
            bll.Add(model);
        }

        /// <summary>
        /// 从模板说明文件中获得模板说明信息
        /// </summary>
        /// <param name="xmlPath">模板路径(不包含文件名)</param>
        /// <returns>模板说明信息</returns>
        protected DtCms.Model.Templates GetTemplateAboutInfo(string xmlPath)
        {
            DtCms.Model.Templates aboutInfo = new DtCms.Model.Templates();

            ///存放关于信息的文件 about.xml是否存在,不存在返回空串
            if (!System.IO.File.Exists(xmlPath + @"\about.xml"))
                return aboutInfo;

            XmlDocument xml = new XmlDocument();

            xml.Load(xmlPath + @"\about.xml");

            try
            {
                XmlNode root = xml.SelectSingleNode("about");
                foreach (XmlNode n in root.ChildNodes)
                {
                    if (n.NodeType != XmlNodeType.Comment && n.Name.ToLower() == "template")
                    {
                        aboutInfo.name = n.Attributes["name"] != null ? n.Attributes["name"].Value.ToString() : "";
                        aboutInfo.author = n.Attributes["author"] != null ? n.Attributes["author"].Value.ToString() : "";
                        aboutInfo.createdate = n.Attributes["createdate"] != null ? n.Attributes["createdate"].Value.ToString() : "";
                        aboutInfo.ver = n.Attributes["ver"] != null ? n.Attributes["ver"].Value.ToString() : "";
                        aboutInfo.fordntver = n.Attributes["fordntver"] != null ? n.Attributes["fordntver"].Value.ToString() : "";
                    }
                }
            }
            catch
            {
                aboutInfo = new DtCms.Model.Templates();
            }
            return aboutInfo;
        }

        /// <summary>
        /// 生成全部模板
        /// </summary>
        /// <param name="skinName"></param>
        protected void MarkTemplates(string skinName)
        {
            //遍历站点目录的Aspx文件夹下的aspx文件
            DirectoryInfo dirInfo = new DirectoryInfo(Utils.GetMapPath(webset.WebPath + "Aspx/"));
            foreach (FileInfo file in dirInfo.GetFiles())
            {
                if (file.Name.EndsWith(".aspx"))
                {
                    //生成模板文件
                    PageTemplate.GetTemplate(webset.WebPath, skinName, file.Name.Substring(0, file.Name.LastIndexOf(".")) + ".htm", 1);
                }
            }
        }

    }
}
