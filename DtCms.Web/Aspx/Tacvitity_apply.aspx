<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Tacvitity_apply.aspx.cs" Inherits="DtCms.Web.Aspx.Tacvitity_apply" %>
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
<link rel="shortcut icon" href="<%=SiteConfig.WebPath%>favicon.ico" mce_href="<%=SiteConfig.WebPath%>favicon.ico" type="image/x-icon" />


<script type="text/javascript" src="<%=SiteConfig.WebPath%>js/jquery.form.js"></script>
<script type="text/javascript" src="<%=SiteConfig.WebPath%>js/jquery.validate.min.js"></script>
<script type="text/javascript" src="<%=SiteConfig.WebPath%>js/messages_cn.js"></script>
<link type="text/css" rel="stylesheet" href="<%=SiteConfig.WebPath%>images/library/msg.css" />
<script type="text/javascript" src="<%=SiteConfig.WebPath%>images/library/msg.js"></script>
<script type="text/javascript" src="<%=SiteTemplatePath("default")%>js/send_json.js"></script>

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
				<form id="comment_form" runat="server">
                
                <dl>    
                
						<dt>活动ID：</dt>
						<dd>
                            <asp:TextBox ID="TextBoxAID" runat="server" ReadOnly="true" BackColor="Silver" ></asp:TextBox>
                           
                        </dd>
					</dl>
					<dl>
						<dt>申请人：</dt>
						<dd>
                            <asp:TextBox ID="TextBoxApplicant" ReadOnly="True" runat="server" BackColor="Silver" ></asp:TextBox>
                        </dd>
					</dl>
					<dl>
						<dt>活动名字：</dt>
						<dd>
                            <asp:TextBox ID="TextBoxActivity" runat="server"></asp:TextBox>
                        </dd>
					</dl>
                    <dl>
						<dt>活动缩写：</dt>
						<dd>
                            <asp:TextBox ID="TextBoxActivitySim" runat="server"></asp:TextBox>
                        </dd>
					</dl>
					<dl>
						<dt>预算：</dt>
						<dd>
                            <asp:TextBox ID="TextBoxBudget" runat="server"></asp:TextBox>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" 
                                ControlToValidate="TextBoxBudget" ErrorMessage="请输入整数" 
                                ValidationExpression="^\+?[1-9][0-9]*$"></asp:RegularExpressionValidator>
                        </dd>
					</dl>
					 <dl>    
                
						<dt>活动开始时间：</dt>
						<dd>
                           <input type="text" id="test5" runat=server>
<script src="./layDate-v5.0.9/layDate-v5.0.9/laydate/laydate.js"></script> <!-- 改成你的路径 -->
<script>
    //执行一个laydate实例
    laydate.render({
        elem: '#test5' //指定元素
 , type: 'datetime'
    });
</script>
                        </dd>
					</dl>
                    <dl>
						<dt>地点：</dt>
						<dd>
                            <asp:DropDownList ID="DropDownAPlace" runat="server">
                                <asp:ListItem>学术一报</asp:ListItem>
                                <asp:ListItem>学术二报</asp:ListItem>
                                <asp:ListItem>学术四报</asp:ListItem>
                                <asp:ListItem>学术多功能厅</asp:ListItem>
                                <asp:ListItem>油桶剧场</asp:ListItem>
                                <asp:ListItem>文化长廊</asp:ListItem>
                                <asp:ListItem>教室</asp:ListItem>
                                <asp:ListItem>油桶307</asp:ListItem>
                                <asp:ListItem>油桶多功能厅</asp:ListItem>
                                <asp:ListItem>油桶外场</asp:ListItem>
                                <asp:ListItem>体育馆外场</asp:ListItem>
                                <asp:ListItem>体育馆</asp:ListItem>
                            </asp:DropDownList>
                        </dd>
					</dl>
					<dl>
						<dt>具体策划：</dt>
						<dd><textarea name="txtAContent" class="textarea required" minlength="5" 
                                maxlength="3000" id="TextAreaContent1"></textarea></dd>
					</dl>
                    <dl>
						<dt>审核状态：</dt>
						<dd><asp:TextBox ID="TextBoxAudMode" ReadOnly="True" runat="server" BackColor="Silver">未审核</asp:TextBox></textarea></dd>
					</dl>
					<dl>
						<dt>验证码：</dt>   
						<dd style="width:350px;">
							<input name="txtCode" type="text" class="input2 required" minlength="4" maxlength="5" style="width:50px;" />
							<a href="javascript:void(0);" onclick="ToggleCode(this, '<%=SiteConfig.WebPath%>Tools/VerifyCodeImage.ashx');return false;"><img src="<%=SiteConfig.WebPath%>Tools/VerifyCodeImage.ashx" width="80" height="22" alt="点击切换验证码" style="vertical-align:middle;"> 看不清楚？</a>
                         </dd>
                         <dd>   
                            <asp:Button ID="ButtonAS" runat="server" onclick="ActSubmit" Text="提交申请" />
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
		/p>
	</div>
</div>

</body>
</html>
