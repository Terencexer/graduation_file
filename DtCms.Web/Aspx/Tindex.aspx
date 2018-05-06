<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Tindex.aspx.cs" Inherits="DtCms.Web.Aspx.Tindex" %>
<%@ Import namespace="DtCms.Common" %>
<%@ Register TagPrefix="DtContorl" Namespace="DtCms.Web.UI" Assembly="DtCms.Web.UI" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<title>浙江财经大学校艺术团学生组织管理系统</title>
<!--<link rel="shortcut icon" href="<%=SiteConfig.WebPath
%>favicon.ico" mce_href="<%=SiteConfig.WebPath%>favicon.ico" type="image/x-icon"> -->
  <!-- <link rel="stylesheet" type="text/css" href="css/style.css" /> 
  <script type="text/javascript" src="jquery-1.3.2.min.js"></script>
  <script type="text/javascript" src="base.js"></script> -->
  <link rel="stylesheet" href="<%=SiteTemplatePath("default")%>css/style.css" /> 
<script type="text/javascript" src="<%=SiteConfig.WebPath%>js/jquery-1.3.2.min.js"></script>
<script type="text/javascript" src="<%=SiteTemplatePath("default")%>js/base.js"></script>
</head>
<body>


<div class="top">
	<!-- ===== 导航 ===== -->
	<ul class="nav">
		<li><a href="Tindex.aspx">首页</a></li>
		<li><a href="Tfeedback.aspx">意见反馈</a></li>
		<li><a href="login.aspx">学生登录</a></li>
		<li><%if (Session["TeamLeader"] != null)
        {%><a href="#">用户名：<%=Session["TeamLeader"].ToString()%></a><%}%></li>
	</ul>
</div>

<!-- ===== 正文内容 ===== -->
<div class="container">
	
    <div class="clear" style="height:20px;"></div>

	<!-- ===== 横幅首页图片 ===== -->
	<div class="banner"><script type="text/javascript" src="/Tools/Advert_js.ashx?id=2"></script></div>
	<div class="clear"></div>
	<hr />
	<h2 class="h2_link">亲爱的队长，欢迎使用浙江财经大学校艺术团学生组织管理系统!</h2>
	<div class="news_list">
		<ul>
			
		</ul>
	</div>
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
