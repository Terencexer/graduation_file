<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="article.aspx.cs" Inherits="DtCms.Web.article" ValidateRequest="false" %>
<%@ Import namespace="DtCms.Common" %>
<%@ Register TagPrefix="DtContorl" Namespace="DtCms.Web.UI" Assembly="DtCms.Web.UI" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<title>新闻中心</title>
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
	<div class="bread_crumbs"><a href="<%=URLRewrite("index", "")%>">首页</a> &gt; <a href="<%=URLRewrite("article", "")%>">新闻中心</a> <%=GetChannel_Menu("article_list1", this.classId) %>
		<div class="right_function_key">
		</div>
	</div>
	<!-- ===== 左侧正文 ===== -->
	<div class="page_left">
		<%if(this.classId>0) {%>
		<h2 id="page_title"><%=GetChannel_Title(this.classId) %></h2>
		<%} %>
		<!-- ===== 新闻列表 ===== -->
		<ul class="page_news_list">
			<DtContorl:Repeater ID="rptList1" runat="server" onload="Article_List_DataBind" Where='<%#this.pwhere %>' PageSize='<%#this.pagesize %>' PageIndex='<%#this.page %>'>
              <ItemTemplate>
                <li><a href="<%#URLRewrite("article_show", Eval("Id")) %>"><%#Eval("Title")%></a><i><%#Eval("AddTime")%><span><%#Comment_Count(this.kindId,  Convert.ToInt32(Eval("Id")))%> 评论</span></i>
				    <p><%#Eval("Daodu")%></p>
			    </li>
              </ItemTemplate>
            </DtContorl:Repeater>
		</ul>
		<%=PagerText(this.pcount, this.pagesize, this.page, URLRewrite("article_list2", this.classId, "__id__"), "pagination", "flickr")%>
	</div>
	<!-- ===== 左侧子导航 ===== -->
	<div class="page_right">
		<h3>新闻导航</h3>
		<ul class="sidebar_nav">
			<%=GetChannel_List(this.kindId, 0, "article_list1")%>
		</ul>
		<h3>最新新闻</h3>
		<ul class="sidebar_news">
			<DtContorl:Repeater ID="rptList2" runat="server" onload="Article_List_DataBind" Top="8" Where="IsLock=0 and IsRed=1">
              <ItemTemplate>
                <li><a href="<%#URLRewrite("article_show", Eval("Id")) %>"><%#Eval("Title")%></a><i><span><%#Comment_Count(this.kindId,  Convert.ToInt32(Eval("Id")))%> 评论</span><%#Eval("AddTime")%></i></li>
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
