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
using DtCms.Common;

namespace DtCms.Web
{
    public partial class article : DtCms.Web.UI.BasePage
    {
        public int kindId = (int)Channel.Article;
        public int pcount = 0; //总条数
        public int page; //当前页
        public int pagesize; //设置每页显示的大小

        public int classId;
        public string pwhere = "IsLock=0"; //查询条件

        protected void Page_Load(object sender, EventArgs e)
        {
            this.pagesize = SiteConfig.ArticlePageNum_Client; //取得配置文件的显示条数
            if (!int.TryParse(Request.Params["classId"] as string, out classId))
            {
                //Server.Transfer("error.aspx");
                //return;
                classId = 0;
            }
            //取得当前页
            if (!int.TryParse(Request.Params["page"] as string, out page))
            {
                page = 0;
            }
            //查询条件,查找该类别及下面的所有记录
            if (classId > 0)
            {
                pwhere += " and ClassId in(select Id from dt_Channel where KindId=" + kindId + " and ClassList like '%," + classId + ",%')";
            }
            //获得总条数
            pcount = new DtCms.BLL.Article().GetCount(pwhere);
            //切记绑定一下页面，Repeater属性的变量才会生效，如果你Repeater属性没有变量，下面这句可以忽略
            this.DataBind();
        }

    }
}
