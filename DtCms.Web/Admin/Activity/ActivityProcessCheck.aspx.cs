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
    public partial class ActivityProcessCheck : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack == false)
            {
                PanelPre.Visible = false;
                PanelMiddle.Visible = false;
                PanelEve.Visible = false;
            }
        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow & (e.Row.RowState == DataControlRowState.Normal | e.Row.RowState == DataControlRowState.Alternate))
            {
                Button buttonpre = e.Row.FindControl("ButtonPreCheck") as Button;
                Button buttonmid = e.Row.FindControl("ButtonMidCheck") as Button;
                Button buttoneve = e.Row.FindControl("ButtonEveCheck") as Button;
                string activityId = ((DataRowView)e.Row.DataItem).Row.ItemArray[0].ToString();
                DtCms.BLL.Activity activity = new DtCms.BLL.Activity();
                Label LabelPreStatus = e.Row.FindControl("LabelPreStatus") as Label;
                if ((activity.QueryActivity(activityId).ATime < DateTime.Now))
                {
                    LabelPreStatus.Text = "已过期";
                    buttonpre.Enabled = false;
                    buttonmid.Enabled = false;
                    buttoneve.Enabled = false;
                }
                else
                {

                   if (activity.QueryActivity(activityId).Preparation.ToString()=="未提交"){
                       
                   
                        LabelPreStatus.Text = "筹备中";
                        buttonpre.Enabled = false;
                        buttonmid.Enabled = false;
                        buttoneve.Enabled = false;}

                        else if ((activity.QueryActivity(activityId).Middle.ToString())=="未提交")
                    {
                        LabelPreStatus.Text = "前期准备";
                        buttonpre.Enabled = true;
                        buttonmid.Enabled = false;
                        buttoneve.Enabled = false;

                    }
                   else if ((activity.QueryActivity(activityId).LastPre.ToString()) == "未提交")
                    {
                        LabelPreStatus.Text = "准备过半";
                        buttonpre.Enabled = true;
                        buttonmid.Enabled = true;
                        buttoneve.Enabled = false;


                    }
                     else if ((activity.QueryActivity(activityId).LastPre.ToString()) != "未提交")
                    {
                        LabelPreStatus.Text = "准备就绪";
                        buttonpre.Enabled = true;
                        buttonmid.Enabled = true;
                        buttoneve.Enabled = true;


                    }

                   

                    }

                }
            }
        

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "ButtonPreCheck")
            {

                int dataItemIndex = Convert.ToInt32(e.CommandArgument);
                int papeSize = GridView1.PageSize;
                int pageIndex = GridView1.PageIndex;
                int rowIndex = dataItemIndex - papeSize * pageIndex;
                string activityId = GridView1.Rows[rowIndex].Cells[0].Text;
                PanelPre.Visible = true;
                HiddenFieldCheck.Value = activityId;
                DtCms.BLL.Activity activity = new DtCms.BLL.Activity();
                TextBoxPre.Text = activity.QueryActivity(activityId).Preparation.ToString();

            }
            if (e.CommandName == "ButtonMidCheck")
            {

                int dataItemIndex = Convert.ToInt32(e.CommandArgument);
                int papeSize = GridView1.PageSize;
                int pageIndex = GridView1.PageIndex;
                int rowIndex = dataItemIndex - papeSize * pageIndex;
                string activityId = GridView1.Rows[rowIndex].Cells[0].Text;
                PanelMiddle.Visible = true;
                
                HiddenFieldCheck.Value = activityId;
                DtCms.BLL.Activity activity = new DtCms.BLL.Activity();
                TextBoxMiddle.Text = activity.QueryActivity(activityId).Middle.ToString();

            }
            if (e.CommandName == "ButtonEveCheck")
            {

                int dataItemIndex = Convert.ToInt32(e.CommandArgument);
                int papeSize = GridView1.PageSize;
                int pageIndex = GridView1.PageIndex;
                int rowIndex = dataItemIndex - papeSize * pageIndex;
                string activityId = GridView1.Rows[rowIndex].Cells[0].Text;
                HiddenFieldCheck.Value = activityId;
                PanelEve.Visible = true;

                DtCms.BLL.Activity activity = new DtCms.BLL.Activity();
                TextBoxEve.Text = activity.QueryActivity(activityId).LastPre.ToString();

            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            PanelPre.Visible = false;
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            PanelMiddle.Visible = false;
        }

        protected void Button6_Click(object sender, EventArgs e)
        {
            PanelEve.Visible = false;
        }
    }
}