using System;
using System.Collections.Generic;
using System.Text;

namespace DtCms.Web.UI
{
    /// <summary>
    /// 相册标签类
    /// </summary>
    public partial class BasePage
    {
        /// <summary>
        /// 绑定Repeater控件数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Albums_List_DataBind(object sender, EventArgs e)
        {
            Repeater _rpt = sender as Repeater;
            if (_rpt == null)
                return;
            DtCms.BLL.PicturesAlbum bll = new DtCms.BLL.PicturesAlbum();
            //绑定数据
            _rpt.DataSource = bll.GetList(_rpt.Top, _rpt.Where, "Id asc");
            _rpt.DataBind();
        }
    }
}
