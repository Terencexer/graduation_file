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
    public partial class ActivityProcess : DtCms.Web.UI.BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack == false)
            {
                PanelPre.Visible = false;
                PanelMiddle.Visible = false;
                PanelEve.Visible=false;
            }

        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow & (e.Row.RowState == DataControlRowState.Normal | e.Row.RowState == DataControlRowState.Alternate))
            {
                Button buttonpre = e.Row.FindControl("ButtonPreSub") as Button;
                Button buttonmid = e.Row.FindControl("ButtonMidSub") as Button;
                Button buttoneve = e.Row.FindControl("ButtonEveSub") as Button;
                string activityId = ((DataRowView)e.Row.DataItem).Row.ItemArray[0].ToString();
                DtCms.BLL.Activity activity = new DtCms.BLL.Activity();
                if (DateTime.Now.AddDays(1) < activity.QueryActivity(activityId).ATime)
                {
                    buttoneve.Enabled = false;
                   
                }
            }
        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "ButtonPreSub")
            {

                int dataItemIndex = Convert.ToInt32(e.CommandArgument);
                int papeSize = GridView1.PageSize;
                int pageIndex = GridView1.PageIndex;
                int rowIndex = dataItemIndex - papeSize * pageIndex;
                string activityId = GridView1.Rows[rowIndex].Cells[0].Text;
                PanelPre.Visible = true;
                HiddenFieldSub.Value = activityId;
                DtCms.BLL.Activity activity = new DtCms.BLL.Activity();
                TextBoxPre.Text = activity.QueryActivity(activityId).Preparation.ToString();

            }
            if (e.CommandName == "ButtonMidSub")
            {

                int dataItemIndex = Convert.ToInt32(e.CommandArgument);
                int papeSize = GridView1.PageSize;
                int pageIndex = GridView1.PageIndex;
                int rowIndex = dataItemIndex - papeSize * pageIndex;
                string activityId = GridView1.Rows[rowIndex].Cells[0].Text;
                PanelMiddle.Visible = true;

                HiddenFieldSub.Value = activityId;
                DtCms.BLL.Activity activity = new DtCms.BLL.Activity();
                TextBoxMiddle.Text = activity.QueryActivity(activityId).Middle.ToString();

            }
            if (e.CommandName == "ButtonEveSub")
            {

                int dataItemIndex = Convert.ToInt32(e.CommandArgument);
                int papeSize = GridView1.PageSize;
                int pageIndex = GridView1.PageIndex;
                int rowIndex = dataItemIndex - papeSize * pageIndex;
                string activityId = GridView1.Rows[rowIndex].Cells[0].Text;
                HiddenFieldSub.Value = activityId;
                PanelEve.Visible = true;
               
                DtCms.BLL.Activity activity = new DtCms.BLL.Activity();
                TextBoxEve.Text = activity.QueryActivity(activityId).LastPre.ToString();

            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {

            DtCms.BLL.Activity activityBLL = new DtCms.BLL.Activity();
            string activityid = HiddenFieldSub.Value;
           
           
           activityBLL.UpdateFieldPreparation(activityid, TextBoxPre.Text.Trim());
            Response.Write("<script>alert('提交成功。')</script>");
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            PanelPre.Visible = false;
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            
            DtCms.BLL.Activity activityBLL = new DtCms.BLL.Activity();
            string activityid = HiddenFieldSub.Value;
            string Middle = TextBoxMiddle.Text.Trim();
            activityBLL.UpdateFieldMid(activityid, Middle);
            Response.Write("<script>alert('提交成功。')</script>");
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            PanelMiddle.Visible = false;
        }

        protected void Button5_Click(object sender, EventArgs e)
        {
            DtCms.BLL.Activity activityBLL = new DtCms.BLL.Activity();
            string activityid = HiddenFieldSub.Value;
            string LastPre = TextBoxEve.Text.Trim();
            activityBLL.UpdateFieldLastPre(activityid, LastPre);
            Response.Write("<script>alert('提交成功。')</script>");

        }

        protected void Button6_Click(object sender, EventArgs e)
        {
            PanelEve.Visible = false;
        }           
    }
}