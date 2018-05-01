using System;
using System.Collections.Generic;
using System.Text;

namespace DtCms.Web.UI
{
    /// <summary>
    /// 留言标签类
    /// </summary>
    public partial class BasePage
    {
        /// <summary>
        /// 绑定Repeater控件数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Feedback_List_DataBind(object sender, EventArgs e)
        {
            Repeater _rpt = sender as Repeater;
            if (_rpt == null)
                return;
            DtCms.BLL.Feedback bll = new DtCms.BLL.Feedback();
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

    }
}
