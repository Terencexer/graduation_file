using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace DtCms.Web.UI
{
    /// <summary>
    /// 栏目标签类
    /// </summary>
    public partial class BasePage
    {
        /// <summary>
        /// 取得栏目导航面包屑
        /// </summary>
        protected string GetChannel_Menu(string _urlKey, int _classId)
        {
            StringBuilder strTxt = new StringBuilder();
            if (_classId > 0)
            {
                LoopChannelMenu(strTxt, _urlKey, _classId);
            }
            return strTxt.ToString();
        }

        /// <summary>
        /// 递归找到父节点
        /// </summary>
        private void LoopChannelMenu(StringBuilder _strTxt, string _urlKey, int _classId)
        {
            DtCms.BLL.Channel bll = new DtCms.BLL.Channel(); ;
            int _parentId = bll.GetChannelParentId(_classId);
            if (_parentId > 0)
            {
                this.LoopChannelMenu(_strTxt, _urlKey, _parentId);
            }
            _strTxt.Append("&nbsp;&gt;&nbsp;<a href=\"" + URLRewrite(_urlKey, _classId) + "\">" + bll.GetChannelTitle(_classId) + "</a>");
        }

        /// <summary>
        /// 返回栏目名称
        /// </summary>
        protected string GetChannel_Title(int _classId)
        {
            DtCms.BLL.Channel bll = new DtCms.BLL.Channel();
            if (bll.Exists(_classId))
            {
                DtCms.Model.Channel model = bll.GetModel(_classId);
                return model.Title;
            }
            return "";
        }

        /// <summary>
        /// 返回栏目列表
        /// </summary>
        protected string GetChannel_List(int _kindId, int _classId, string _urlKey)
        {
            DtCms.BLL.Channel bll = new DtCms.BLL.Channel();
            StringBuilder strTxt = new StringBuilder();
            DataTable dt = bll.GetList(_classId, _kindId);
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    string LitStyle = "<span style=\"width:{0}px;text-align:right;display:inline-block;\"></span>";
                    DataRow dr = dt.Rows[i];
                    strTxt.Append("<li>");
                    strTxt.Append(string.Format(LitStyle, (Convert.ToInt32(dr["ClassLayer"]) * 18) - 18));
                    strTxt.Append("<a href=\"" + URLRewrite(_urlKey, dr["Id"]) + "\">" + dr["Title"] + "</a>");
                    strTxt.Append("</li>\n");
                }
            }
            return strTxt.ToString();
        }

    }
}
