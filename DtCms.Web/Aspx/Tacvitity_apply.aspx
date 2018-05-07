﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Tacvitity_apply.aspx.cs" Inherits="DtCms.Web.Aspx.Tacvitity_apply" %>
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
<style type="text/css">  
.sub_menue  
{  
    font: 12px bolder "Lucida Grande" ,​Helvetica,​Arial,​Verdana,​sans-serif; /* 设置文字大小和字体样式 */  
    height: 40px;  
    background:#FFFFFF;  
    display :none;              /*先将子菜单设置为隐藏*/  
}  
li:hover .sub_menue  
{  
    background: #EDEDED; /* 变换背景色 */  
    color: #fff; /* 变换文字颜色 */  
    border: 1px solid #000;  
    display:block;             /*设置鼠标滑过动作，以块级元素的形式显示出子菜单*/  
}  
.clear{
        clear:both;
    }

</style>   
</head>
<body>


<div class="top">
	<!-- ===== 导航 ===== -->
	<ul class="nav">
		<li><a href="Tindex.aspx">首页</a>
        </li>
		<li><a href="Tfeedback.aspx" >意见反馈</a></li>
		
        <li><a href="login.aspx" >学生登录</a></li>
        <li><a href="Tindex.aspx">活动承办</a>
	    <ul class="sub_menue">
           <li ><a href="Tacvitity_apply.aspx"style="text-align:center">活动申请</a>
            <ul class="sub_menue">
           <li ><a href="Tfeedback.aspx" style="text-align:center" >意见反馈</a></li>
           </ul>
          </li>
        </ul>
        </li>
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
    <div class="commentform">
				<div class="nTitle">提交策划</div>
				<form id="comment_form" name="comment_form">
					<dl>
						<dt>申请人：</dt>
						<dd><input name="Applicant" type="text" maxlength="30" class="input2 required" style="width:265px;" /></dd>
					</dl>
					<dl>
						<dt>活动名字：</dt>
						<dd><input name="ATitle" type="text" maxlength="30" class="input2 required" style="width:265px;" /></dd>
					</dl>
					<dl>
						<dt>预算：</dt>
						<dd><input name="ABudget" type="text" maxlength="20" class="input2 required" style="width:265px;" /></dd>
					</dl>
					<dl>
						<dt>时间：</dt>
						<dd><input name="ATime" type="text" maxlength="100" class="input2 required" style="width:350px;" /></dd>
					</dl>
                    <dl>
						<dt>地点：</dt>
						<dd><input name="APlace" type="text" maxlength="100" class="input2 required" style="width:350px;" /></dd>
					</dl>
					<dl>
						<dt>具体策划：</dt>
						<dd><textarea name="txtContent" class="textarea required" minlength="5" maxlength="3000"></textarea></dd>
					</dl>
					<dl>
						<dt>验证码：</dt>
						<dd style="width:350px;">
							<input name="txtCode" type="text" class="input2 required" minlength="4" maxlength="5" style="width:50px;" />
							<a href="javascript:void(0);" onclick="ToggleCode(this, '<%=SiteConfig.WebPath%>Tools/VerifyCodeImage.ashx');return false;"><img src="<%=SiteConfig.WebPath%>Tools/VerifyCodeImage.ashx" width="80" height="22" alt="点击切换验证码" style="vertical-align:middle;"> 看不清楚？</a> </dd>
						<dd>
							<input id="btnSubmit" name="btnSubmit" type="submit" class="submit2" value="提交保存">
						</dd>
					</dl>
					<div class="clear"></div>
				</form>
			</div>
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