<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="article_show.aspx.cs" Inherits="DtCms.Web.article_show" ValidateRequest="false" %>
<%@ Import namespace="DtCms.Common" %>
<%@ Register TagPrefix="DtContorl" Namespace="DtCms.Web.UI" Assembly="DtCms.Web.UI" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<title><%=model.Title %> - 新闻中心</title>

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
<script type="text/javascript">
$(function() {
    //初始化星级事件
    CommentStar("#comment #stars", "#comment #stars a", "#hidStar");
    //初始化评论列表
    AjaxCommentList("#pagination", 10, <%=Comment_Count(this.kindId, this.Id)%>, "<%=SiteConfig.WebPath%>Tools/Comment_json.ashx?action=list&kindId=<%=this.kindId%>&parentId=<%=this.Id%>");
    //初始化发表评论表单
    AjaxOnSubmit("comment_form", "btnSubmit", "<%=SiteConfig.WebPath%>Tools/Comment_json.ashx?action=add&kindId=<%=this.kindId%>&parentId=<%=this.Id%>");
});
</script>

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
	<div class="bread_crumbs"><a href="<%=URLRewrite("index", "")%>">首页</a> &gt; <a href="<%=URLRewrite("article", "")%>">资讯中心</a> <%=GetChannel_Menu("article_list1", model.ClassId) %>
		<div class="right_function_key"></div>
	</div>
	<!-- ===== 左侧正文 ===== -->
	<div class="page_left">
		<h2 id="news_title"><%=model.Title %></h2>
		<i class="date_i">作者：<%=model.Author %> 来源：<%=model.Form %> 浏览：<%=model.Click %> 发布时间：<%=model.AddTime %></i>
		<!-- ===== 编辑框内容 开始 ===== -->
		<div class="content_box">
			<%=model.Content %>
		</div>
		<div class="clear"></div>
		<!-- ===== 前后与返回 Previous, Next and Back ===== -->
		<div class="p_n_b">
		    <%if(GetArticleId("IsLock=0 and Id<" + model.Id)>0){%>
		    <a class="previous" href="<%=URLRewrite("article_show", GetArticleId("IsLock=0 and Id<" + model.Id))%>">« 上一篇</a>
		    <%}else{ %>
		     <a class="previous">上一篇没有啦</a>
		    <%} %>
		    <a class="back" href="javascript:history.back(-1);">返回</a>
		    <%if(GetArticleId("IsLock=0 and Id>" + model.Id)>0){%>
		    <a class="next" href="<%=URLRewrite("article_show", GetArticleId("IsLock=0 and Id>" + model.Id))%>">下一篇 »</a>
		    <%}else{ %>
		     <a class="next">下一篇没有啦</a>
		    <%} %>
		</div>
		<div class="clear"></div>
		<!-- ===== 用户留言评论 ===== -->
        <%if(model.IsMsg > 0){ %>
        
		<h2 id="page_title"><%=Comment_Count(this.kindId,  model.Id)%> 条评论</h2>
		<div id="comment">
			<div id="commentList">
				显示评论列表
			</div>
			<%if(Comment_Count(this.kindId, this.Id)>0) {%>
            <div id="pagination" class="scott"></div>
            <%} %>
            <div class="clear"></div>
			<!--用户评价开始-->
			<div class="commentform clearfix">
				<div class="nTitle">发表评论</div>
				<form id="comment_form" name="comment_form">
					<dl>
						<dt>用户昵称：</dt>
						<dd style="width:250px;">
							<input name="txtUserName" type="text" maxlength="30" class="input2 required">
							&nbsp;</dd>
						<dt>评价等级：</dt>
						<dd>
                          <span id="stars" class="star star0">
                            <a title="一星级">1</a>
                            <a class="a2" title="二星级">2</a>
                            <a class="a3" title="三星级">3</a>
                            <a class="a4" title="四星级">4</a>
                            <a class="a5" title="五星级">5</a>
                          </span>&nbsp;
                          <input id="hidStar" name="hidStar" type="hidden" value="" class="required" />
                        </dd>
					</dl>
					<dl>
						<dt>评论内容：</dt>
						<dd>
							<textarea name="txtContent" class="textarea required" minlength="5" maxlength="3000"></textarea>
							&nbsp;</dd>
					</dl>
					<dl>
						<dt>验证码：</dt>
						<dd style="width:385px;">
							<input name="txtCode" type="text" class="input2 required" minlength="4" maxlength="5" style="width:50px;">
							<a href="javascript:void(0);" onclick="ToggleCode(this, '<%=SiteConfig.WebPath%>Tools/VerifyCodeImage.ashx');return false;"><img src="<%=SiteConfig.WebPath%>Tools/VerifyCodeImage.ashx" width="80" height="22" alt="点击切换验证码" style="vertical-align:middle;"> 看不清楚？</a> </dd>
						<dd>
							<input id="btnSubmit" name="btnSubmit" type="submit" class="submit2" value="提交评论">
						</dd>
					</dl>
					<div class="clear"></div>
				</form>
			</div>
			<!--用户评价结束-->
		</div>

        <%} %>
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
		    浙江财经大学校艺术团学生组织管理系统
		</p>
	</div>
</div>

</body>
</html>