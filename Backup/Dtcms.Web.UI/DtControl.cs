using System;
using System.IO;
using System.Collections.Generic;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DtCms.Common;

namespace DtCms.Web.UI
{
    /// <summary>
    /// 加载用户控件(自定义控件)
    /// </summary>
    public class LoadControl : WebControl, INamingContainer
    {
        private string _src;
        /// <summary>
        /// 用户控件路径
        /// </summary>
        public string Src
        {
            get { return _src; }
            set { _src = value; }
        }
        private System.Web.UI.Control _innerWebControl;
        protected override void Render(HtmlTextWriter output)
        {
            if (!File.Exists(Utils.GetMapPath(Src)))
            {
                output.Write(Src + "用户控件不存在！");
            }
            this.EnsureChildControls();
            _innerWebControl.RenderControl(output);
        }
        protected override void CreateChildControls()
        {
            _innerWebControl = this.Page.LoadControl(Src);
            this.Controls.Add(_innerWebControl);
            base.CreateChildControls();
        }
    }

    /// <summary>
    /// Repeater扩展控件
    /// </summary>
    public class Repeater : System.Web.UI.WebControls.Repeater
    {
        private int _top = 0;
        private int _pageindex = 0;
        private int _pagesize = 0;
        private string _where = "";

        /// <summary>
        /// 显示条数
        /// </summary>
        public int Top
        {
            get { return _top; }
            set { _top = value; }
        }

        /// <summary>
        /// 当前页
        /// </summary>
        public int PageIndex
        {
            get { return _pageindex; }
            set { _pageindex = value; }
        }

        /// <summary>
        /// 每页大小
        /// </summary>
        public int PageSize
        {
            get { return _pagesize; }
            set { _pagesize = value; }
        }

        /// <summary>
        /// 查询条件
        /// </summary>
        public string Where
        {
            get { return _where; }
            set { _where = value; }
        }

    }

}
