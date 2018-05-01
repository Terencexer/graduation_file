using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;

namespace DtCms.Web.Aspx
{
    public partial class Societies : DtCms.Web.UI.BasePage
    {
        public int pcount = 0; //总条数
        public int page; //当前页
        public int pagesize; //设置每页显示的大小

        public string pwhere = "";

        public string Id;

        protected void Page_Load(object sender, EventArgs e)
        {
            this.pagesize = SiteConfig.ArticlePageNum_Client; //取得配置文件的显示条数
            //取得当前页
            if (!int.TryParse(Request.Params["page"] as string, out page))
            {
                page = 0;
            }
            //获得总条数
            pcount = new DtCms.BLL.Societies().GetCount("");
            //切记绑定一下页面，Repeater属性的变量才会生效，如果你Repeater属性没有变量，下面这句可以忽略
            this.DataBind();
        }
    }
}
