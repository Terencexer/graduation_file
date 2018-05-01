<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="DtCms.Web.index" ValidateRequest="false" %>
<%@ Import namespace="DtCms.Common" %>
<%@ Register TagPrefix="DtContorl" Namespace="DtCms.Web.UI" Assembly="DtCms.Web.UI" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<title>学生社团在线评选系统</title>
<link rel="shortcut icon" href="<%=SiteConfig.WebPath%>favicon.ico" mce_href="<%=SiteConfig.WebPath%>favicon.ico" type="image/x-icon">
<link rel="stylesheet" href="<%=SiteTemplatePath("default")%>css/style.css" />
<script type="text/javascript" src="<%=SiteConfig.WebPath%>js/jquery-1.3.2.min.js"></script>
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

<!-- ===== 正文内容 ===== -->
<div class="container">
	
    <div class="clear" style="height:20px;"></div>

	<!-- ===== 横幅首页图片 ===== -->
	<div class="banner"><script type="text/javascript" src="/Tools/Advert_js.ashx?id=2"></script></div>
	<div class="clear"></div>
	<hr />
	<h2 class="h2_link"><a href="<%=URLRewrite("article", "")%>">最新新闻</a></h2>
	<div class="news_list">
		<ul>
			<DtContorl:Repeater ID="newsList" runat="server" onload="Article_List_DataBind" Top="4" Where="IsLock=0 and IsRed=1">
            <ItemTemplate>
                <li><a href="<%#URLRewrite("article_show", Eval("Id"))%>"><%#Utils.CutString(Eval("Title").ToString(), 38)%></a><i><%#Eval("AddTime")%></i>
			    <p><%#Utils.CutString(Eval("Daodu").ToString(), 84)%></p>
		        </li>
            </ItemTemplate>
            </DtContorl:Repeater>
		</ul>
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
