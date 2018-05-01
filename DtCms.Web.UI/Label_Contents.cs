using System;
using System.Collections.Generic;
using System.Text;

namespace DtCms.Web.UI
{
    /// <summary>
    /// 内容标签类
    /// </summary>
    public partial class BasePage
    {
        /// <summary>
        /// 根据标签取得内容页内容
        /// </summary>
        protected string GetContent(string callIndex)
        {
            if (string.IsNullOrEmpty(callIndex))
                return "";
            DtCms.BLL.Contents bll = new DtCms.BLL.Contents();
            if (bll.Exists(callIndex))
            {
                return bll.GetModel(callIndex).Content;
            }
            return "";
        }

        /// <summary>
        /// 绑定Repeater控件数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Content_List_DataBind(object sender, EventArgs e)
        {
            Repeater _rpt = sender as Repeater;
            if (_rpt == null)
                return;
            DtCms.BLL.Contents bll = new DtCms.BLL.Contents();
            //绑定数据
            if (_rpt.PageSize > 0)
            {
                _rpt.DataSource = bll.GetPageList(_rpt.PageSize, _rpt.PageIndex, _rpt.Where, "SortId asc,Id desc");
            }
            else
            {
                _rpt.DataSource = bll.GetList(_rpt.Top, _rpt.Where, "SortId asc,Id desc");
            }
            _rpt.DataBind();
        }

    }
}
