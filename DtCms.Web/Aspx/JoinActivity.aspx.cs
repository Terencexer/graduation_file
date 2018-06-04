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
    public partial class JoinActivity : DtCms.Web.UI.BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "ButtonSV")
            {
                int dataItemIndex = Convert.ToInt32(e.CommandArgument);
                int papeSize = GridView1.PageSize;
                int pageIndex = GridView1.PageIndex;
                int rowIndex = dataItemIndex - papeSize * pageIndex;
                string activityId = GridView1.DataKeys[rowIndex].Value.ToString();
                DtCms.BLL.JoinActivity joinActivityBLL = new DtCms.BLL.JoinActivity();
                string username = Session["Member"].ToString();
                if (joinActivityBLL.GetCount(activityId) < Convert.ToInt32(GridView1.Rows[rowIndex].Cells[5].Text))
                {
                    if (joinActivityBLL.AcExists(activityId,username) == false)
                    {

                        DtCms.BLL.Member memberBLL = new DtCms.BLL.Member();
                        DtCms.Model.JoinActivity joinActivity = new DtCms.Model.JoinActivity();

                        string UserTel = memberBLL.QueryOneRecord(username).Usertel.ToString();
                        joinActivity.ActivityId = activityId;
                        joinActivity.UserName = username;
                        joinActivity.UserTel = UserTel;
                        joinActivity.TicketType = "SuperVIP";
                         
                        joinActivityBLL.Add(joinActivity);
                        Response.Write("<script>alert('抢票成功。')</script>");
                    }
                    else  Response.Write("<script>alert('抢票失败。')</script>");
                }
                    else Response.Write("<script>alert('抢票失败。')</script>");
                }
            if (e.CommandName == "ButtonV")
            {
                int dataItemIndex = Convert.ToInt32(e.CommandArgument);
                int papeSize = GridView1.PageSize;
                int pageIndex = GridView1.PageIndex;
                int rowIndex = dataItemIndex - papeSize * pageIndex;
                string activityId = GridView1.DataKeys[rowIndex].Value.ToString();
                DtCms.BLL.JoinActivity joinActivityBLL = new DtCms.BLL.JoinActivity();
                string username = Session["Member"].ToString();
                if (joinActivityBLL.GetCount(activityId) < Convert.ToInt32(GridView1.Rows[rowIndex].Cells[7].Text))
                {
                    if (joinActivityBLL.AcExists(activityId, username) == false)
                    {

                        DtCms.BLL.Member memberBLL = new DtCms.BLL.Member();
                        DtCms.Model.JoinActivity joinActivity = new DtCms.Model.JoinActivity();

                        string UserTel = memberBLL.QueryOneRecord(username).Usertel.ToString();
                        joinActivity.ActivityId = activityId;
                        joinActivity.UserName = username;
                        joinActivity.UserTel = UserTel;
                        joinActivity.TicketType = "VIP";

                        joinActivityBLL.Add(joinActivity);
                        Response.Write("<script>alert('抢票成功。')</script>");
                    }
                    else Response.Write("<script>alert('抢票失败。')</script>");
                }
                else Response.Write("<script>alert('抢票失败。')</script>");
            }
            if (e.CommandName == "ButtonC")
            {
                int dataItemIndex = Convert.ToInt32(e.CommandArgument);
                int papeSize = GridView1.PageSize;
                int pageIndex = GridView1.PageIndex;
                int rowIndex = dataItemIndex - papeSize * pageIndex;
                string activityId = GridView1.DataKeys[rowIndex].Value.ToString();
                DtCms.BLL.JoinActivity joinActivityBLL = new DtCms.BLL.JoinActivity();
                string username = Session["Member"].ToString();
                if (joinActivityBLL.GetCount(activityId) < Convert.ToInt32(GridView1.Rows[rowIndex].Cells[9].Text))
                {
                    if (joinActivityBLL.AcExists(activityId, username) == false)
                    {

                        DtCms.BLL.Member memberBLL = new DtCms.BLL.Member();
                        DtCms.Model.JoinActivity joinActivity = new DtCms.Model.JoinActivity();

                        string UserTel = memberBLL.QueryOneRecord(username).Usertel.ToString();
                        joinActivity.ActivityId = activityId;
                        joinActivity.UserName = username;
                        joinActivity.UserTel = UserTel;
                        joinActivity.TicketType = "Common";

                        joinActivityBLL.Add(joinActivity);
                        Response.Write("<script>alert('抢票成功。')</script>");
                    }
                    else Response.Write("<script>alert('抢票失败。')</script>");
                }
                else Response.Write("<script>alert('抢票失败。')</script>");
            }
            if (e.CommandName == "ButtonS")
            {
                int dataItemIndex = Convert.ToInt32(e.CommandArgument);
                int papeSize = GridView1.PageSize;
                int pageIndex = GridView1.PageIndex;
                int rowIndex = dataItemIndex - papeSize * pageIndex;
                string activityId = GridView1.DataKeys[rowIndex].Value.ToString();
                DtCms.BLL.JoinActivity joinActivityBLL = new DtCms.BLL.JoinActivity();
                string username = Session["Member"].ToString();
                if (joinActivityBLL.GetCount(activityId) < Convert.ToInt32(GridView1.Rows[rowIndex].Cells[11].Text))
                {
                    if (joinActivityBLL.AcExists(activityId, username) == false)
                    {

                        DtCms.BLL.Member memberBLL = new DtCms.BLL.Member();
                        DtCms.Model.JoinActivity joinActivity = new DtCms.Model.JoinActivity();

                        string UserTel = memberBLL.QueryOneRecord(username).Usertel.ToString();
                        joinActivity.ActivityId = activityId;
                        joinActivity.UserName = username;
                        joinActivity.UserTel = UserTel;
                        joinActivity.TicketType = "Standing";

                        joinActivityBLL.Add(joinActivity);
                        Response.Write("<script>alert('抢票成功。')</script>");
                    }
                    else Response.Write("<script>alert('抢票失败，活动只能领取一张门票。')</script>");
                }
                else Response.Write("<script>alert('抢票失败,抢票人数到达上限。')</script>");
            }
            }
        

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            
        }
    }
    

}