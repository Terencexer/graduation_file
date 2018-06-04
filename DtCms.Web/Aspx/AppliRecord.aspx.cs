using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using DtCms.BLL;
using System.Configuration;

namespace DtCms.Web.Aspx
{
    public partial class AppliRecord : DtCms.Web.UI.BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack == false)
            {
                PanelEdit.Visible = false;
            }
        }
        
        
        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow & (e.Row.RowState == DataControlRowState.Normal | e.Row.RowState == DataControlRowState.Alternate))
            {
                string AuditStatus = ((DataRowView)e.Row.DataItem).Row.ItemArray[8].ToString();
                Button buttonedit = e.Row.FindControl("ButtonEdit") as Button;
               
                    if (AuditStatus == "未审核")
                    {
                        e.Row.BackColor = System.Drawing.Color.Beige;
                        buttonedit.Enabled = true;
                    }
                    else if (AuditStatus == "再次提交")
                    {
                        e.Row.BackColor = System.Drawing.Color.Beige;
                        buttonedit.Enabled = true;
                    }
                    else if (AuditStatus == "审核通过")
                    {
                        buttonedit.Enabled = false;

                    }
                    else if (AuditStatus == "退回修改")
                    {
                        e.Row.BackColor = System.Drawing.Color.AliceBlue;

                        buttonedit.Enabled = true;
                    }

                    else if (AuditStatus == "不批准")
                    {
                        buttonedit.Enabled = false;

                    }

                }
            

        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "ButtonEdit")
            {

                int dataItemIndex = Convert.ToInt32(e.CommandArgument);
                int papeSize = GridView1.PageSize;
                int pageIndex = GridView1.PageIndex;
                int rowIndex = dataItemIndex - papeSize * pageIndex;
                string activityId = GridView1.Rows[rowIndex].Cells[0].Text;
                string AuditStatus = ((Label)GridView1.Rows[rowIndex].FindControl("LabelAudit")).Text;
                PanelEdit.Visible = true;
                HiddenFieldEdit.Value = activityId;
                DtCms.BLL.Activity activity = new DtCms.BLL.Activity();
                TextBoxActivityId.Text = activityId;
                TextBoxApplicant.Text = activity.QueryActivity(activityId).Applicant;
                test5.Value= activity.QueryActivity(activityId).ATime.ToString();
                TextBoxBudget.Text = activity.QueryActivity(activityId).Budget.ToString();
                TextBoxCheckStatus.Text = activity.QueryActivity(activityId).CheckStatus.ToString();
                DropDownAPlace.Text = activity.QueryActivity(activityId).Place.ToString();
                TextBoxASuggestion.Text = activity.QueryActivity(activityId).ASuggestion.ToString();
                // DropDownListTicketType.Text = activity.QueryActivity(activityId).TicketType.ToString();   
                TextBoxTitle.Text = activity.QueryActivity(activityId).Title;
                TextBoxAcontent.Text = activity.QueryActivity(activityId).AConten.ToString();
               
                TextBoxTicketIssue.Text = activity.QueryActivity(activityId).TicketStatus.ToString();

            }
        }

        protected void ButtonEditSub_Click(object sender, EventArgs e)
        {
            DtCms.BLL.Activity activityBLL = new DtCms.BLL.Activity();
            DtCms.Model.Activity activity = new DtCms.Model.Activity();
            activity.ActivityId = TextBoxActivityId.Text.Trim();
            activity.Applicant = TextBoxApplicant.Text.Trim();
            activity.Title = TextBoxTitle.Text.Trim();
            activity.Budget = Convert.ToInt32(TextBoxBudget.Text.Trim());
            activity.ATime = Convert.ToDateTime(Request.Form["test5"]);
            activity.Place = DropDownAPlace.SelectedValue.Trim();
            activity.AConten = TextBoxAcontent.Text.Trim();
            activity.CheckStatus = TextBoxCheckStatus.Text.Trim();
            activity.ASuggestion = "无建议";
            activityBLL.Update(activity);
            Response.Write("<script>alert('提交成功。')</script>");
            activityBLL.ReupdateOneRecordAuditStatus(TextBoxActivityId.Text.Trim());
            GridView1.DataBind();
        }

        protected void ButtonReturn_Click(object sender, EventArgs e)
        {
            PanelEdit.Visible = false;
            GridView1.DataBind();
        }
    }
}