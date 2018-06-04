using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using DtCms.BLL;

namespace DtCms.Web.Aspx
{
    public partial class JoinAT : DtCms.Web.UI.BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            PanelApp.Visible = false;

        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "ButtonJoinAT")
            {
                PanelApp.Visible = true;
                int dataItemIndex = Convert.ToInt32(e.CommandArgument);
                int papeSize = GridView1.PageSize;
                int pageIndex = GridView1.PageIndex;
                int rowIndex = dataItemIndex - papeSize * pageIndex;
                string team = GridView1.Rows[rowIndex].Cells[0].Text;
                HiddenField1.Value = team;

            }
        }

        protected void Buttonsub_Click(object sender, EventArgs e)
        {
            DtCms.Model.JoinAT joinAT = new DtCms.Model.JoinAT();
            DtCms.BLL.JoinAT joinATBll = new DtCms.BLL.JoinAT();

            joinAT.UserName = Session["Member"].ToString();
            joinAT.SelfIntro = TextBox1.Text.Trim();
            joinAT.Reward = TextBox2.Text.Trim();
            joinAT.JoinReason = TextBox3.Text.Trim();
            joinAT.TLCheckMode = "未审核";
            joinAT.TLAdvice = "无";
            joinAT.AdminCheckMode = "未审核";
            joinAT.AdminAdvice = "无";
            joinAT.Team = HiddenField1.Value;
            joinATBll.Add(joinAT);
            PanelApp.Visible = false;
        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow & (e.Row.RowState == DataControlRowState.Normal | e.Row.RowState == DataControlRowState.Alternate))
            {
                string UserName = Session["Member"].ToString();
                string team = ((DataRowView)e.Row.DataItem).Row.ItemArray[0].ToString();
                Label LabelMode = e.Row.FindControl("LabelMode") as Label;
                DtCms.Model.JoinAT joinAT = new DtCms.Model.JoinAT();
                DtCms.BLL.JoinAT joinATBll = new DtCms.BLL.JoinAT();

                /*if (joinATBll.QueryOneRecord(UserName, team).AdminCheckMode == "未审核")
                {
                    LabelMode.Text = "未审核";
                }
                Button buttonJoinAT = e.Row.FindControl("ButtonJoinAT") as Button;
                if (LabelMode.Text == "未审核")
                    buttonJoinAT.Enabled = false;**/
            }

        }
    }
}