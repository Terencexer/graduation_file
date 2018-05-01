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
    public partial class register : DtCms.Web.UI.BasePage
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
            string TureName = txtTureName.Text.Trim();
            string UserTel = txtUserTel.Text.Trim();
            string UserQQ = txtUserQQ.Text.Trim();
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
            if (string.IsNullOrEmpty(TureName))
            {
                Response.Write("<script>alert('请输入姓名！');</script>");
                return;
            }
            if (string.IsNullOrEmpty(UserTel))
            {
                Response.Write("<script>alert('请输入联系电话！');</script>");
                return;
            }
            if (string.IsNullOrEmpty(UserQQ))
            {
                Response.Write("<script>alert('请输入在线QQ！');</script>");
                return;
            }

            DtCms.Model.Member member = new DtCms.Model.Member();
            member.Username = UserName;
            member.Pwd = pwd;
            member.Turename = TureName;
            member.Usertel = UserTel;
            member.Userqq = UserQQ;

            DtCms.BLL.Member bll = new DtCms.BLL.Member();
            bll.Add(member);
            Session["Member"] = UserName;
            Response.Write("<script>alert('注册成功！');window.location.href='index.aspx'</script>");
        }
    }
}
