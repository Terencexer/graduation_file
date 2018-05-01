﻿using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using DtCms.Common;

namespace DtCms.Web.Admin
{
    public partial class login : System.Web.UI.Page
    {
        DtCms.BLL.Administrator bll = new DtCms.BLL.Administrator();
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void loginsubmit_Click(object sender, ImageClickEventArgs e)
        {
            string UserName = txtUserName.Text.Trim();
            string UserPwd = txtUserPwd.Text.Trim();
            if (UserName.Equals("") || UserPwd.Equals(""))
            {
                lbMsg.Text = "请输入您要登录用户名或密码";
            }
            else
            {
                if (Session["AdminLoginSun"] == null)
                {
                    Session["AdminLoginSun"] = 1;
                }
                else
                {
                    Session["AdminLoginSun"] = Convert.ToInt32(Session["AdminLoginSun"]) + 1;
                }
                //判断登录
                if (Session["AdminLoginSun"] != null && Convert.ToInt32(Session["AdminLoginSun"]) > 3)
                {
                    lbMsg.Text = "登录错误超过3次，请关闭浏览器重新登录。";
                }
                else if (bll.chkAdminLogin(UserName, DESEncrypt.Encrypt(UserPwd)))
                {
                    DtCms.Model.Administrator model = new DtCms.Model.Administrator();
                    model = bll.GetModel(UserName);
                    Session["AdminNo"] = model.Id;
                    Session["AdminName"] = model.UserName;
                    Session["AdminType"] = model.UserType;
                    Session["AdminLevel"] = model.UserLevel;
                    //设置超时时间
                    Session.Timeout = 45;
                    Session["AdminLoginSun"] = null;
                    //写入Cookies
                    Utils.WriteCookie("AdminName", "DtCms", DESEncrypt.Encrypt(model.UserName));
                    Utils.WriteCookie("AdminPwd", "DtCms", model.UserPwd);
                    //保存日志
                    new DtCms.Web.UI.ManagePage().SaveLogs(UserName, "[用户登录]状态：登录成功！");

                    Response.Redirect("admin_index.aspx");
                }
                else
                {
                    lbMsg.Text = "您输入的用户名或密码不正确";
                    //保存日志
                    new DtCms.Web.UI.ManagePage().SaveLogs(UserName, "[用户登录] 状态：登录失败！");
                }
            }
        }
    }
}
