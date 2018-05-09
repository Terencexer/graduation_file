using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;

namespace DtCms.Web.Aspx
{
    public partial class Tacvitity_apply : DtCms.Web.UI.BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            TextBoxApplicant.Text = Session["TeamLeader"].ToString();
        }

        protected void ActSubmit(object sender, EventArgs e)
        {  
            
          
                  
                  

            DtCms.BLL.Activity planBLL = new DtCms.BLL.Activity();
            if (planBLL.Exists(TextBoxAID.Text.Trim()) == true)
               ClientScript.RegisterClientScriptBlock(Page.GetType(), "", "<script>alert('该编号已被使用，请更换。')</script>");
           else
            {
               
                DateTime dtDate;
                if (DateTime.TryParse(TextBoxATime.Text, out dtDate))
                {
                    Console.WriteLine(dtDate);
                }
                else
                {
           
                    throw new Exception("不是正确的日期格式类型！");
                }

               
                 DtCms.Model.Activity plan = new DtCms.Model.Activity();
                plan.ActivityId = TextBoxAID    .Text.Trim();
                plan.Applicant = Session["TeamLeader"].ToString();;
                plan.Title = TextBoxActivity.Text.Trim();
               plan.Budget = Convert.ToInt32(TextBoxBudget.Text.Trim());
                plan.ATime = Convert.ToDateTime(TextBoxATime.Text);
                plan.Place = TextBoxAPlace.Text.Trim();
                plan.AConten = Request.Form["txtAContent"];
                plan.CheckStatus = TextBoxAudMode.Text;
                int result = planBLL.Add(plan);
                if (result == 0)
                    Response.Write("<script>alert('提交成功。')</script>");
                else
                    ClientScript.RegisterClientScriptBlock(Page.GetType(), "", "<script>alert('提交失败。')</script>");
               
               
                }
           

        }

       
    }
    }

