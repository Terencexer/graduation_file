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
    public partial class ActivityPublish : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
         protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow & (e.Row.RowState == DataControlRowState.Normal | e.Row.RowState == DataControlRowState.Alternate))
            {
               
                 Button buttonissue = e.Row.FindControl("ButtonIssue") as Button;
                 Button buttonissuecancel = e.Row.FindControl("ButtonIssueCancel") as Button;
                string activityid = ((DataRowView)e.Row.DataItem).Row.ItemArray[0].ToString();
                 string ticketstatus = ((DataRowView)e.Row.DataItem).Row.ItemArray[9].ToString();
                 
                  DateTime atime =Convert.ToDateTime(((DataRowView)e.Row.DataItem).Row.ItemArray[2]);

                  
                      if (ticketstatus == "发布中")
                      {
                          if (DateTime.Now < atime)
                          {
                              buttonissue.Enabled = false;
                              buttonissuecancel.Enabled = true;
                          }
                          else
                          {
                              DtCms.BLL.Activity activity = new DtCms.BLL.Activity();
                              activity.UpdateOneRecordTicketStatusCancel(activityid);
                          }
                      }
                      else if (ticketstatus == "未发布")
                      {
                          buttonissue.Enabled = true;
                          buttonissuecancel.Enabled = false;
                      }
                  }
                 
                       
                  }
          
        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "ButtonIssue")
            {
               
                int dataItemIndex = Convert.ToInt32(e.CommandArgument);
                int papeSize = GridView1.PageSize;
                int pageIndex = GridView1.PageIndex;
                int rowIndex = dataItemIndex - papeSize * pageIndex;
                string activityId = GridView1.Rows[rowIndex].Cells[0].Text;
              //  string AuditStatus = ((Label)GridView1.Rows[rowIndex].FindControl("LabelAudit")).Text;
                DateTime Atime = Convert.ToDateTime(GridView1.Rows[rowIndex].Cells[2].Text);
                if (DateTime.Now < Atime && DateTime.Now>Atime.AddDays(-10))
                {
                    DtCms.BLL.Activity activity = new DtCms.BLL.Activity();
                    if (activity.QueryActivity(activityId).Middle != "未提交")
                    {
                        activity.UpdateOneRecordTicketStatus(activityId);
                        Response.Write("<script>alert('发布成功。')</script>");
                    }
                    else if (activity.QueryActivity(activityId).Middle == "未提交")
                        Response.Write("<script>alert('发布失败，进度未达可发布状态。')</script>");
                }
              else Response.Write("<script>alert('发布失败,已过期或者还未到发布时间。')</script>");
                GridView1.DataBind();
            }

            if (e.CommandName == "ButtonIssueCancel")
            {

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
      

       
            
          
        }

       

      

        

       

    
    }
}