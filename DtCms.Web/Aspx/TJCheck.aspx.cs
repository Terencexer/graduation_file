using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DtCms.Web.Aspx
{
    public partial class TJCheck : DtCms.Web.UI.BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Panel1.Visible = false;
            Panel2.Visible = false;
            DtCms.BLL.TeamLeader teamLeader = new DtCms.BLL.TeamLeader();
                string username=Session["TeamLeader"].ToString();
               DropDownList1.SelectedValue=teamLeader.QueryTeacher(username).Team.ToString();
        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "ButtonAllow")
            {
                
                Panel1.Visible = true;
                
            }
            if (e.CommandName == "ButtonReject")
            {
                
                Panel2.Visible = true;
               

            }
        }

        protected void ButtonSub1_Click(object sender, EventArgs e)
        {
            DtCms.BLL.TeamLeader teamLeader = new DtCms.BLL.TeamLeader();
            string username = Session["TeamLeader"].ToString();
            string team = teamLeader.QueryTeacher(username).Team.ToString();
            DtCms.Model.JoinAT joinAT = new DtCms.Model.JoinAT();
            DtCms.BLL.JoinAT joinATBll = new DtCms.BLL.JoinAT();
            joinATBll.UpdateFieldTL(username, team, TextBoxTL1.Text.Trim());
            joinATBll.UpdateFieldTLMode(username, team, "审核通过");
            Panel1.Visible = false;
        }

        protected void ButtonSub2_Click(object sender, EventArgs e)
        {
            DtCms.BLL.TeamLeader teamLeader = new DtCms.BLL.TeamLeader();
            string username = Session["TeamLeader"].ToString();
            string team = teamLeader.QueryTeacher(username).Team.ToString();
            DtCms.Model.JoinAT joinAT = new DtCms.Model.JoinAT();
            DtCms.BLL.JoinAT joinATBll = new DtCms.BLL.JoinAT();
            joinATBll.UpdateFieldTL(username, team, TextBoxTL2.Text.Trim());
            joinATBll.UpdateFieldTLMode(username, team, "不通过");
            Panel2.Visible = false;
        }
    }
}