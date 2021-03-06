﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="societies_show.aspx.cs" Inherits="DtCms.Web.Aspx.societies_show" %>

<%@ Import namespace="DtCms.Common" %>
<%@ Register TagPrefix="DtContorl" Namespace="DtCms.Web.UI" Assembly="DtCms.Web.UI" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<title>浙江财经大学校艺术团学生组织管理系统</title>

<link rel="shortcut icon" href="<%=SiteConfig.WebPath%>favicon.ico" mce_href="<%=SiteConfig.WebPath%>favicon.ico" type="image/x-icon">
<link rel="stylesheet" href="<%=SiteTemplatePath("default")%>css/style.css" />
<script type="text/javascript" src="<%=SiteConfig.WebPath%>js/jquery-1.3.2.min.js"></script>
<script type="text/javascript" src="<%=SiteTemplatePath("default")%>js/base.js"></script>

<link type="text/css" rel="stylesheet" href="<%=SiteConfig.WebPath%>images/library/msg.css" />
<link type="text/css" rel="stylesheet" href="<%=SiteConfig.WebPath%>css/pagination.css" />
<script type="text/javascript" src="<%=SiteConfig.WebPath%>js/jquery.form.js"></script>
<script type="text/javascript" src="<%=SiteConfig.WebPath%>js/jquery.validate.min.js"></script>
<script type="text/javascript" src="<%=SiteConfig.WebPath%>js/messages_cn.js"></script>
<script type="text/javascript" src="<%=SiteConfig.WebPath%>images/library/msg.js"></script>
<script type="text/javascript" src="<%=SiteConfig.WebPath%>js/jquery.pagination.js"></script>
<script type="text/javascript" src="<%=SiteTemplatePath("default")%>js/send_json.js"></script>
<script type="text/javascript" src="<%=SiteTemplatePath("default")%>js/comment.js"></script>

</head>
<body>


<div class="top">
	<!-- ===== 导航 ===== -->
	<ul class="nav">
		<li><a href="<%=URLRewrite("index", "")%>">首页</a></li>
		<li><a href="<%=URLRewrite("article", "")%>">新闻中心</a></li>
		<li><a href="<%=URLRewrite("societies", "")%>">晚会评分</a></li>
		<li><a href="<%=URLRewrite("feedback", "")%>">意见反馈</a></li>
		<li><a href="<%=URLRewrite("register", "register")%>">学生注册</a></li>
		<li><a href="<%=URLRewrite("login", "login")%>">学生登录</a></li>
		<li><%if (Session["Member"] != null)
        {%><a href="#">用户名：<%=Session["Member"].ToString()%></a><%}%></li>
	</ul>
</div>

<!-- ===== 正文内容 ===== -->
<div class="container">
	
    <div class="clear" style="height:20px;"></div>
	<div class="bread_crumbs"><a href="<%=URLRewrite("index", "")%>">首页</a> &gt; <a href="<%=URLRewrite("societies", "")%>">活动评分</a> 
		<div class="right_function_key"></div>
	</div>
	<!-- ===== 左侧正文 ===== -->
	<div class="page_left">
		<h2 id="news_title"><%=model.SocietiesName%></h2>
		<!-- ===== 编辑框内容 开始 ===== -->
		<div class="content_box">
			<%=model.SocietiesRemark%>
		</div>
		<div class="clear"></div>
		<div class="commentform">
				<div class="nTitle">晚会评分</div>
				<form id="comment_form" name="comment_form" runat="server">
					<dl>
						<dt>活动质量：</dt>
						<dd>
                            <asp:DropDownList ID="DropDownList1" runat="server">
                            </asp:DropDownList>
						</dd>
					</dl>
					<dl>
						<dt>活动次数：</dt>
						<dd><asp:DropDownList ID="DropDownList2" runat="server">
                            </asp:DropDownList></dd>
					</dl>
					<dl>
						<dt>活动气氛：</dt>
						<dd><asp:DropDownList ID="DropDownList3" runat="server">
                            </asp:DropDownList></dd>
					</dl>
					<dl>
						<dt>大型活动：</dt>
						<dd><asp:DropDownList ID="DropDownList4" runat="server">
                            </asp:DropDownList></dd>
					</dl>
					<dl>
						<dt>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</dt>
						<dd>
                            <asp:Button ID="Button1" runat="server" Text="提交保存" onclick="Button1_Click" />
						</dd>
					</dl>
					<div class="clear"></div>
				</form>
			</div>
	</div>
	<!-- ===== 左侧子导航 ===== -->
	<div class="clear"></div>
</div>

<div class="bottom">

	<div class="footer" style="height:25px;">
		<p class="footer_links" >
		   浙江财经大学校艺术团学生组织管理系统
		</p>
	</div>
</div>

</body>
</html>