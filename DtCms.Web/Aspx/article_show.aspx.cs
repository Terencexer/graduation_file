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

namespace DtCms.Web
{
    public partial class article_show : DtCms.Web.UI.BasePage
    {
        public int kindId = (int)Channel.Article;
        public int Id;
        public DtCms.Model.Article model = new DtCms.Model.Article();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!int.TryParse(Request.Params["id"] as string, out Id))
            {
                Server.Transfer("error.aspx");
                return;
            }
            DtCms.BLL.Article bll = new DtCms.BLL.Article();
            if (!bll.Exists(Id))
            {
                Server.Transfer("error.aspx");
                return;
            }
            model = bll.GetModel(Id);
            //浏览数+1
            bll.UpdateField(this.Id, "Click=Click+1");
        }

    }
}
