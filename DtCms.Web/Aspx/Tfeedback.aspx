<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Tfeedback.aspx.cs" Inherits="DtCms.Web.Aspx.Tfeedback" %>
<%@ Import namespace="DtCms.Common" %>
<%@ Register TagPrefix="DtContorl" Namespace="DtCms.Web.UI" Assembly="DtCms.Web.UI" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<title>意见反馈</title>
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
<script type="text/javascript">
    $(function () {
        $("#comment .item:nth-child(even)").addClass("odd"); //隔行变色
        //初始化表单
        AjaxOnSubmit("comment_form", "btnSubmit", "<%=SiteConfig.WebPath%>Tools/Submit_json.ashx?action=feedback");
    });
</script>
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
	<!-- ===== 左侧正文 ===== -->
	<div class="page_left">
		<h2 id="page_title">意见反馈</h2>
        <div id="comment">
			<div id="commentList">
				<DtContorl:Repeater ID="rptFeedbackList" runat="server" onload="Feedback_List_DataBind" Where="IsLock=0" PageSize='<%#this.pagesize %>' PageIndex='<%#this.page %>'>
                <ItemTemplate>
                <div class="item">
					<div class="user"><span class="u-name">网友：<%#Eval("UserName")%></span> <span class="date-ask"><%#Eval("AddTime")%></span></div>
					<dl class="answer">
						<dt>意见反馈内容：</dt>
						<dd>
							<p><%#Eval("Content")%></p>
							<div class="clear"></div>
						</dd>
					</dl>
					<%#Eval("ReContent").ToString() != "" ? "<dl class=\"reply\">\n<dt>管理员答复：<i>" + Eval("ReTime").ToString() + "</i></dt>\n<dd>" + Eval("ReContent").ToString() + "</dd></dl>\n" : ""%>
				</div>
                </ItemTemplate>
                </DtContorl:Repeater>
			</div>
			<%=PagerText(this.pcount, this.pagesize, this.page, URLRewrite("feedback_list1", "__id__"), "pagination", "flickr")%>
			<div class="clear"></div>
			<!--用户留言开始-->
			<div class="commentform">
				<div class="nTitle">发表意见反馈</div>
				<form id="comment_form" name="comment_form">
					<dl>
						<dt>你的姓名：</dt>
						<dd><input name="txtUserName" type="text" maxlength="30" class="input2 required" style="width:265px;" /></dd>
					</dl>
					<dl>
						<dt>联系电话：</dt>
						<dd><input name="txtUserTel" type="text" maxlength="30" class="input2 required" style="width:265px;" /></dd>
					</dl>
					<dl>
						<dt>在线QQ：</dt>
						<dd><input name="txtUserQQ" type="text" maxlength="20" class="input2 required" style="width:265px;" /></dd>
					</dl>
					<dl>
						<dt>意见反馈标题：</dt>
						<dd><input name="txtTitle" type="text" maxlength="100" class="input2 required" style="width:350px;" /></dd>
					</dl>
					<dl>
						<dt>意见反馈内容：</dt>
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
			<!--用户留言结束-->
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
