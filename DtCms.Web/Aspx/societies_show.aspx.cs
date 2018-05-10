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
    public partial class societies_show : DtCms.Web.UI.BasePage
    {
        public int Id;
        public DtCms.Model.Societies model = new DtCms.Model.Societies();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!int.TryParse(Request.Params["Id"] as string, out Id))
            {
                Server.Transfer("error.aspx");
                return;
            }
            if (!IsPostBack)
            {
                ArrayList al = new ArrayList();
                for (int i = 1; i <= 100; i++)
                {
                    al.Add(i.ToString());
                }
                DropDownList1.DataSource = al;
                DropDownList1.DataBind();
                DropDownList2.DataSource = al;
                DropDownList2.DataBind();
                DropDownList3.DataSource = al;
                DropDownList3.DataBind();
                DropDownList4.DataSource = al;
                DropDownList4.DataBind();
            }
            DtCms.BLL.Societies bll = new DtCms.BLL.Societies();
            model = bll.GetModel(Id);
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            int Quality = Convert.ToInt32(DropDownList1.SelectedValue);
            int Number = Convert.ToInt32(DropDownList2.SelectedValue);
            int Atmosphere = Convert.ToInt32(DropDownList3.SelectedValue);
            int Activities = Convert.ToInt32(DropDownList4.SelectedValue);
            DtCms.BLL.Societies societies = new DtCms.BLL.Societies();
            DtCms.Model.Societies Societiesmodel = new DtCms.Model.Societies();
            Societiesmodel = societies.GetModel(Id);
            DtCms.Model.Score score = new DtCms.Model.Score();
            score.Quality = Quality;
            score.Number = Number;
            score.Atmosphere = Atmosphere;
            score.SocietiesName = Societiesmodel.SocietiesName;
            score.Activities = Activities;

            DtCms.BLL.Score bll = new DtCms.BLL.Score();
            bll.Add(score);
            Response.Write("<script>alert('艺术团活动评分成功啦！');</script>");
        }
    }
}
