using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using DtCms.BLL;

namespace DtCms.Web.Admin.Activity
{
    public partial class ActivityAudit : System.Web.UI.Page
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
                string AuditStatus = ((DataRowView)e.Row.DataItem).Row.ItemArray[7].ToString();

                Button buttonaudit = e.Row.FindControl("ButtonAudit") as Button;
                Button buttonback = e.Row.FindControl("ButtonBack") as Button;
                Button buttonuncheck = e.Row.FindControl("ButtonUncheck") as Button;
                Button buttonissue = e.Row.FindControl("ButtonIssue") as Button;
                Button buttonissuecancel = e.Row.FindControl("ButtonIssueCancel") as Button;
               
                Label LabelApplicant = e.Row.FindControl("LabelApplicant") as Label;
                string applicant = DataBinder.Eval(e.Row.DataItem, "Applicant").ToString();
                DtCms.BLL.TeamLeader teamleader = new TeamLeader();
                LabelApplicant.Text = teamleader.GetAppName(applicant);
                DtCms.BLL.Activity activity= new DtCms.BLL.Activity();
                string activityid = ((DataRowView)e.Row.DataItem).Row.ItemArray[0].ToString();
                string ticketstatus = activity.QueryActivity(activityid).TicketStatus.ToString();
                if (ticketstatus == "发布中")
                {
                    buttonissue.Enabled = false;
                    buttonissuecancel.Enabled = true;
                }
                else if (ticketstatus == "未发布")
                {
                    buttonissue.Enabled = true;
                    buttonissuecancel.Enabled = false;
                }
                else if (ticketstatus == "")
                {
                    buttonissue.Enabled = true;
                    buttonissuecancel.Enabled = false;
                }
                if (AuditStatus == "未审核")
                {
                    e.Row.BackColor = System.Drawing.Color.Beige;
                    buttonaudit.Enabled = true;
                    buttonissue.Enabled = false;
                    buttonissuecancel.Enabled = false;
                }
                if (AuditStatus == "审核通过")
                {
                    buttonaudit.Enabled = false;
                    buttonback.Enabled = false;
                    buttonuncheck.Enabled = false;
                   
                }
                else if (AuditStatus == "退回修改")
                {
                    e.Row.BackColor = System.Drawing.Color.AliceBlue;
                    buttonissue.Enabled = false;
                    buttonissuecancel.Enabled = false;
                    buttonaudit.Enabled = true;
                }

                else if (AuditStatus == "不批准")
                {
                    buttonaudit.Enabled = false;
                    buttonback.Enabled = false;
                    buttonuncheck.Enabled = false;
                    buttonissue.Enabled = false;
                    buttonissuecancel.Enabled = false;
                }

            }
        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            
            if (e.CommandName == "ButtonAudit")
            {

                int dataItemIndex = Convert.ToInt32(e.CommandArgument);
                int papeSize = GridView1.PageSize;
                int pageIndex = GridView1.PageIndex;
                int rowIndex = dataItemIndex - papeSize * pageIndex;
                string activityId = GridView1.Rows[rowIndex].Cells[0].Text;
                string AuditStatus = ((Label)GridView1.Rows[rowIndex].FindControl("LabelAudit")).Text;
                if (AuditStatus == "未审核" )
                {
                    DtCms.BLL.Activity activity = new DtCms.BLL.Activity();

                    activity.UpdateOneRecordAuditStatus(activityId);

                }
                else if (AuditStatus == "退回修改")
                {
                    DtCms.BLL.Activity activity = new DtCms.BLL.Activity();

                    activity.UpdateOneRecordAuditStatus(activityId);

                }

                GridView1.DataBind();
            }
            if (e.CommandName == "ButtonBack")
            {

                int dataItemIndex = Convert.ToInt32(e.CommandArgument);
                int papeSize = GridView1.PageSize;
                int pageIndex = GridView1.PageIndex;
                int rowIndex = dataItemIndex - papeSize * pageIndex;
                string activityId = GridView1.Rows[rowIndex].Cells[0].Text;
                string AuditStatus = ((Label)GridView1.Rows[rowIndex].FindControl("LabelAudit")).Text;
                if (AuditStatus == "未审核")
                {
                    DtCms.BLL.Activity activity = new DtCms.BLL.Activity();

                    activity.UpdateOneRecordAuditStatusBack(activityId);

                }
                else if (AuditStatus == "退回修改")
                {
                    DtCms.BLL.Activity activity = new DtCms.BLL.Activity();

                    activity.UpdateOneRecordAuditStatusBack(activityId);

                }
                GridView1.DataBind();
            }
                if (e.CommandName == "ButtonIssue")
            {
                    
                int dataItemIndex = Convert.ToInt32(e.CommandArgument);
                int papeSize = GridView1.PageSize;
                int pageIndex = GridView1.PageIndex;
                int rowIndex = dataItemIndex - papeSize * pageIndex;
                string activityId = GridView1.Rows[rowIndex].Cells[0].Text;
                string AuditStatus = ((Label)GridView1.Rows[rowIndex].FindControl("LabelAudit")).Text;
                DateTime Atime = Convert.ToDateTime(((Label)GridView1.Rows[rowIndex].FindControl("LabelTime")).Text);
                if (DateTime.Now < Atime)
                {
                    DtCms.BLL.Activity activity = new DtCms.BLL.Activity();

                    activity.UpdateOneRecordTicketStatus(activityId);
                    Response.Write("<script>alert('发布成功。')</script>");
                }
                else Response.Write("<script>alert('发布失败,已过期。')</script>");
                    GridView1.DataBind();}

                if (e.CommandName == "ButtonIssueCancel"){

                    int dataItemIndex = Convert.ToInt32(e.CommandArgument);
                    int papeSize = GridView1.PageSize;
                    int pageIndex = GridView1.PageIndex;
                    int rowIndex = dataItemIndex - papeSize * pageIndex;
                    string activityId = GridView1.Rows[rowIndex].Cells[0].Text;
                    DtCms.BLL.Activity activity = new DtCms.BLL.Activity();

                    activity.UpdateOneRecordTicketStatusCancel(activityId);
                    Response.Write("<script>alert('取消成功。')</script>");
                   
                GridView1.DataBind();
            }
            if (e.CommandName == "ButtonUncheck")
            {

                int dataItemIndex = Convert.ToInt32(e.CommandArgument);
                int papeSize = GridView1.PageSize;
                int pageIndex = GridView1.PageIndex;
                int rowIndex = dataItemIndex - papeSize * pageIndex;
                string activityId = GridView1.Rows[rowIndex].Cells[0].Text;
                string AuditStatus = ((Label)GridView1.Rows[rowIndex].FindControl("LabelAudit")).Text;
                if (AuditStatus == "未审核")
                {
                    DtCms.BLL.Activity activity = new DtCms.BLL.Activity();

                    activity.UpdateOneRecordAuditStatusUncheck(activityId);

                }
                else if (AuditStatus == "退回修改")
                {
                    DtCms.BLL.Activity activity = new DtCms.BLL.Activity();

                    activity.UpdateOneRecordAuditStatusUncheck(activityId);

                }

                GridView1.DataBind();
            }
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
                TextBoxATime.Text = activity.QueryActivity(activityId).ATime.ToString();
                TextBoxBudget.Text = activity.QueryActivity(activityId).Budget.ToString();
                TextBoxCheckStatus.Text = activity.QueryActivity(activityId).CheckStatus.ToString();
                TextBoxPlace.Text = activity.QueryActivity(activityId).Place.ToString();

                // DropDownListTicketType.Text = activity.QueryActivity(activityId).TicketType.ToString();   
                TextBoxTitle.Text = activity.QueryActivity(activityId).Title;
                TextBoxAcontent.Text = activity.QueryActivity(activityId).AConten.ToString();
                TextBoxTicketNum.Text = activity.QueryActivity(activityId).TicketType.ToString();
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
            activity.ATime = Convert.ToDateTime(TextBoxATime.Text);
            activity.Place = TextBoxPlace.Text.Trim();
            activity.AConten = TextBoxAcontent.Text.Trim();
            activity.CheckStatus = TextBoxCheckStatus.Text.Trim();
            activityBLL.Update(activity);
            Response.Write("<script>alert('提交成功。')</script>");

        }

        protected void ButtonReturn_Click(object sender, EventArgs e)
        {
            PanelEdit.Visible = false;
        }


        // protected string GetAppName(String UserName)
        // {
        //    DtCms.BLL.TeamLeader teamleader = new DtCms.BLL.TeamLeader();
        //    return teamleader.GetAppName(UserName);

        // }


    }
}