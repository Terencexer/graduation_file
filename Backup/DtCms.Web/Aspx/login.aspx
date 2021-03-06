﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="DtCms.Web.Aspx.login" %>


<%@ Import namespace="DtCms.Common" %>
<%@ Register TagPrefix="DtContorl" Namespace="DtCms.Web.UI" Assembly="DtCms.Web.UI" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<title>会员登录</title>

<!-- ===== css ===== -->
<link rel="shortcut icon" href="<%=SiteConfig.WebPath%>favicon.ico" mce_href="<%=SiteConfig.WebPath%>favicon.ico" type="image/x-icon" />
<link rel="stylesheet" href="<%=SiteTemplatePath("default")%>css/style.css" />
<script type="text/javascript" src="<%=SiteConfig.WebPath%>js/jquery-1.3.2.min.js"></script>
<script type="text/javascript" src="<%=SiteConfig.WebPath%>js/jquery.form.js"></script>
<script type="text/javascript" src="<%=SiteConfig.WebPath%>js/jquery.validate.min.js"></script>
<script type="text/javascript" src="<%=SiteConfig.WebPath%>js/messages_cn.js"></script>
<link type="text/css" rel="stylesheet" href="<%=SiteConfig.WebPath%>images/library/msg.css" />
<script type="text/javascript" src="<%=SiteConfig.WebPath%>images/library/msg.js"></script>
<script type="text/javascript" src="<%=SiteTemplatePath("default")%>js/send_json.js"></script>
<script type="text/javascript" src="<%=SiteTemplatePath("default")%>js/base.js"></script>
</head>
<body>
<div class="top">
	<!-- ===== 导航 ===== -->
	<ul class="nav">
		<li><a href="<%=URLRewrite("index", "")%>">首页</a></li>
		<li><a href="<%=URLRewrite("article", "")%>">新闻中心</a></li>
		<li><a href="<%=URLRewrite("societies", "")%>">社团评选</a></li>
		<li><a href="<%=URLRewrite("feedback", "")%>">意见反馈</a></li>
		<li><a href="<%=URLRewrite("register", "register")%>">会员注册</a></li>
		<li><a href="<%=URLRewrite("login", "login")%>">会员登录</a></li>
		<li><%if (Session["Member"] != null)
        {%><a href="#">会员名：<%=Session["Member"].ToString()%></a><%}%></li>
	</ul>
</div>
<div class="container">
	<div class="clear" style="height:20px;"></div>
	<div class="bread_crumbs"><a href="<%=URLRewrite("index", "")%>">首页</a> > 会员注册
		
	</div>
	<div class="page_left">
		<h2 id="page_title">会员登录</h2>
		<div id="comment">
			<div class="clear"></div>
			<div class="commentform">
				<div class="nTitle">会员登录</div>
				<form id="comment_form" name="comment_form" runat="server">
				    <dl>
						<dt>会员名：</dt>
						<dd>
                            <asp:TextBox ID="txtUserName" runat="server" maxlength="30" class="input2 required" style="width:250px;" ></asp:TextBox>
						</dd>
					</dl>
					<dl>
						<dt>密码：</dt>
						<dd>
						<asp:TextBox ID="txtpwd" runat="server" maxlength="30" TextMode="Password" class="input2 required" style="width:250px;" ></asp:TextBox>
						</dd>
					</dl>
					<dl>
						<dt>验证码：</dt>
						<dd style="width:385px;">
						    <asp:TextBox ID="txtCode" runat="server" minlength="4" maxlength="5" class="input2 required" style="width:50px;" ></asp:TextBox>
							
							<a href="javascript:void(0);" onclick="ToggleCode(this, '<%=SiteConfig.WebPath%>Tools/VerifyCodeImage.ashx');return false;"><img src="<%=SiteConfig.WebPath%>Tools/VerifyCodeImage.ashx" width="80" height="22" alt="点击切换验证码" style="vertical-align:middle;"> 看不清楚？</a> </dd>
						<dd>
                            <asp:Button id="btnSubmit" name="btnSubmit" runat="server" Text="登录" 
                                onclick="btnSubmit_Click" />
						</dd>
					</dl>
					<div class="clear"></div>
				</form>
			</div>
		</div>
	</div>
	<div class="clear"></div>
</div>

<div class="bottom">

	<div class="footer" style="height:25px;">
		<p class="footer_links" >
		    学生社团在线评选系统
		</p>
	</div>
</div>

</body>
</html>