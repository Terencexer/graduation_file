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
           

            DtCms.Model.Member member = new DtCms.Model.Member();
            member.Username = UserName;
            member.Pwd = pwd;

            if (RadioButtonListRole.SelectedValue == "管理员")
            {
                DtCms.BLL.Member bll = new DtCms.BLL.Member();
                if (bll.GetCount(" Username='" + UserName + "' and Pwd='" + pwd + "' ") > 0)
                {
                    Session["Member"] = UserName;
                    Response.Write("<script>alert('登录成功！');window.location.href='index.aspx'</script>");
                }
                else
                {
                    Response.Write("<script>alert('登录失败,会员名或密码输入错误！');</script>");
                }
            }
            if (RadioButtonListRole.SelectedValue == "OD")
            {
                UserBLL userBLL = new UserBLL();
                if (userBLL.VerifyUserPwd(TextBoxUserID.Text, TextBoxPwd.Text) == true)
                {
                    Session["department"] = userBLL.GetdepartName(TextBoxUserID.Text);
                    Response.Redirect("~/OD/ODdefault.aspx");
                    //ClientScript.RegisterClientScriptBlock(Page.GetType(), "", "<script>alert('登陆成功')</script>");
                }
                else
                    ClientScript.RegisterClientScriptBlock(Page.GetType(), "", "<script>alert('用户名或密码错误!')</script>");
            }
        }
        protected void ButtonReset_Click(object sender, EventArgs e)
        {
            txtUserName.Text = "";
            txtpwd.Text = "";
            txtCode.Text = "";
        }

       
    }
}
