using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace DtCms.Web.UI
{
    /// <summary>
    /// 图文标签类
    /// </summary>
    public partial class BasePage
    {
        /// <summary>
        /// 绑定图文Repeater控件数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Picture_List_DataBind(object sender, EventArgs e)
        {
            Repeater _rpt = sender as Repeater;
            if (_rpt == null)
                return;
            DtCms.BLL.Pictures bll = new DtCms.BLL.Pictures();
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
        /// 返回图文的ID，用于上一条或下一条链接
        /// </summary>
        protected int GetPictureId(string _where)
        {
            DtCms.BLL.Pictures bll = new DtCms.BLL.Pictures();
            DataSet ds = bll.GetList(1, _where, "SortId asc,AddTime desc");
            if (ds.Tables[0].Rows.Count > 0)
            {
                return Convert.ToInt32(ds.Tables[0].Rows[0]["Id"]);
            }
            return -1;
        }

    }
}
