using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using DtCms.Common;

namespace DtCms.Web.UI
{
    /// <summary>
    /// 资讯标签类
    /// </summary>
    public partial class BasePage
    {
        /// <summary>
        /// 绑定Repeater控件数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Article_List_DataBind(object sender, EventArgs e)
        {
            Repeater _rpt = sender as Repeater;
            if (_rpt == null)
                return;
            DtCms.BLL.Article bll = new DtCms.BLL.Article();
            //绑定数据
            if (_rpt.PageSize > 0)
            {
                _rpt.DataSource = bll.GetPageList(_rpt.PageSize, _rpt.PageIndex, _rpt.Where, "AddTime desc");
            }
            else
            {
                _rpt.DataSource = bll.GetList(_rpt.Top, _rpt.Where, "AddTime desc");
            }
            _rpt.DataBind();
        }

        protected void Societies_List_DataBind(object sender, EventArgs e)
        {
            Repeater _rpt = sender as Repeater;
            if (_rpt == null)
                return;
            DtCms.BLL.Societies bll = new DtCms.BLL.Societies();
            //绑定数据
            if (_rpt.PageSize > 0)
            {
                _rpt.DataSource = bll.GetPageList(_rpt.PageSize, _rpt.PageIndex, _rpt.Where, "AddTime desc");
            }
            else
            {
                _rpt.DataSource = bll.GetList(_rpt.Top, _rpt.Where, "AddTime desc");
            }
            _rpt.DataBind();
        }

        /// <summary>
        /// 返回资讯的ID，用于上一条或下一条链接
        /// </summary>
        protected int GetArticleId(string _where)
        {
            DtCms.BLL.Article bll = new DtCms.BLL.Article();
            DataSet ds = bll.GetList(1, _where, "AddTime desc");
            if (ds.Tables[0].Rows.Count > 0)
            {
                return Convert.ToInt32(ds.Tables[0].Rows[0]["Id"]);
            }
            return -1;
        }
    }
}
