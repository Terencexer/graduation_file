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
using DtCms.BLL;
using DtCms.Model;
using DtCms.Common;


namespace DtCms.Web.Aspx
{
    public partial class login : DtCms.Web.UI.BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.DataBind();
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            string Code = txtCode.Text.Trim();
            string UserName = txtUserName.Text.Trim();
            string pwd = txtpwd.Text.Trim();
          if (Code.ToLower() != (Session["DtCode"].ToString()).ToLower())
           {
               Response.Write("<script>alert('您输入的验证码与系统的不一致！');</script>");
                return;
          }
            if (string.IsNullOrEmpty(UserName))
            {
                Response.Write("<script>alert('请输入会员名！');</script>");
                return;
            }
            if (string.IsNullOrEmpty(pwd))
            {
                Response.Write("<script>alert('请输入密码！');</script>");
                return;
            }
           

           
            
           // if (RadioButtonListRole.SelectedValue == "管理员")
            //{
              //  DtCms.Model.Administrator administrator = new DtCms.Model.Administrator();
               // administrator.UserName = UserName;
               // administrator.UserPwd = pwd;
               // DtCms.BLL.Administrator bll = new DtCms.BLL.Administrator();
               // if (bll.chkAdminLogin(UserName, DESEncrypt.Encrypt(pwd)))
                //{
                   // Session["Administrator"] = UserName;
                  //  Response.Write("<script>alert('登录成功！')</script>");
                 //   Response.Redirect("~/Admin/Admin_Index.aspx");
               // }
               // else if (bll.GetCount(" Username='" + UserName + "' and UserPwd='" + pwd + "' ") == 0)
               // {
                 //   Response.Write("<script>alert('登录失败,管理员名名或密码输入错误！');</script>");
              //  }
           // }

            
            if (RadioButtonListRole.SelectedValue == "学生")
            {
                DtCms.Model.Member member = new DtCms.Model.Member();
                member.Username = UserName;
                member.Pwd = pwd;
                DtCms.BLL.Member bll = new DtCms.BLL.Member();
                if (bll.GetCount(" Username='" + UserName + "' and Pwd='" + pwd + "' ") > 0)
                {
                    Session["Member"] = UserName;
                    Response.Write("<script>alert('登录成功！');window.location.href='index.aspx'</script>");
                }
                else
                {
                    Response.Write("<script>alert('登录失败,用户名或密码输入错误！');</script>");
                }
            }
            if (RadioButtonListRole.SelectedValue == "队长")
            {
                DtCms.Model.TeamLeader teamleader = new DtCms.Model.TeamLeader();
                teamleader.Username = UserName;
                teamleader.Pwd = pwd;
                DtCms.BLL.TeamLeader bll = new DtCms.BLL.TeamLeader();
                if (bll.GetCount(" Username='" + UserName + "' and Pwd='" + pwd + "' ") > 0)
                {
                    Session["TeamLeader"] = UserName;
                    Response.Write("<script>alert('登录成功！');window.location.href='Tindex.aspx'</script>");
                   
                }
                else
                {
                    Response.Write("<script>alert('登录失败,用户名或密码输入错误！');</script>");
                }
            }
        }
        protected void ButtonReset_Click(object sender, EventArgs e)
        {
            txtUserName.Text = "";
            txtpwd.Text = "";
            txtCode.Text = "";
        }

        protected void RadioButtonListRole_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

      
    }
}
