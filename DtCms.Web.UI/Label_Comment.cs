using System;
using System.Collections.Generic;
using System.Text;

namespace DtCms.Web.UI
{
    /// <summary>
    /// 评论标签类
    /// </summary>
    public partial class BasePage
    {
        /// <summary>
        /// 绑定Repeater控件数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Comment_List_DataBind(object sender, EventArgs e)
        {
            Repeater _rpt = sender as Repeater;
            if (_rpt == null)
                return;
            DtCms.BLL.AllReviews bll = new DtCms.BLL.AllReviews();
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
        /// 评论数量
        /// </summary>
        protected int Comment_Count(int _kindId, int _parentId)
        {
            DtCms.BLL.AllReviews bll = new DtCms.BLL.AllReviews();
            int _num = bll.GetCount("KindId=" + _kindId + " and ParentId=" + _parentId);
            return _num;
        }

    }
}