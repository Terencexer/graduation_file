<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TJCheck.aspx.cs" Inherits="DtCms.Web.Aspx.TJCheck" %>
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

    .style1
    {
        width: 100%;
    }

    .container
    {
        text-align: center;
    }
    .style2
    {
        width: 190px;
    }

</style>   
</head>
<body>


    <form id="form1" runat="server">


<div class="top">
	<!-- ===== 导航 ===== -->
	<ul class="nav">
		<li><a href="Tindex.aspx">首页</a>
        </li>
		<li><a href="Tfeedback.aspx" >意见反馈</a></li>
		
        <li><a href="login.aspx" >学生登录</a></li>
        <li><a href="">活动承办</a>
	    <ul class="sub_menue">
           <li ><a href="Tacvitity_apply.aspx"style="text-align:center">活动申请</a>
                <ul class="sub_menue">
                <li ><a href="AppliRecord.aspx" style="text-align:center" >申请记录</a>
                <ul class="sub_menue">
                
                <li ><a href="ActivityProcess.aspx" style="text-align:center" >进度汇报</a></li>
                <ul class="sub_menue">
                
                <li ><a href="ProgrammeAdd.aspx" style="text-align:center" >添加节目单</a></li>

                </ul>
                </ul>
                </li>
           
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
    队伍：<asp:DropDownList ID="DropDownList1" runat="server" >
    </asp:DropDownList>
	<asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
        DataSourceID="SqlDataSource1" AllowPaging="True" BackColor="White" 
        BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px" CellPadding="4" 
        onrowcommand="GridView1_RowCommand">
        <Columns>
            <asp:BoundField DataField="UserName" HeaderText="用户名" 
                SortExpression="UserName" />
            <asp:BoundField DataField="SelfIntro" HeaderText="自我介绍" 
                SortExpression="SelfIntro" />
            <asp:BoundField DataField="Reward" HeaderText="获奖" 
                SortExpression="Reward" />
            <asp:BoundField DataField="JoinReason" HeaderText="加入原因" 
                SortExpression="JoinReason" />
            <asp:BoundField DataField="TLCheckMode" HeaderText="队长审核状态" 
                SortExpression="TLCheckMode" />
            <asp:BoundField DataField="AdminCheckMode" HeaderText="管理员审核状态" 
                SortExpression="AdminCheckMode" />
            <asp:BoundField DataField="Team" HeaderText="队伍" 
                SortExpression="Team" />
            <asp:TemplateField HeaderText="审核1" ShowHeader="False">
                <ItemTemplate>
                    <asp:Button ID="ButtonAllow" runat="server" 
                        CommandArgument="<% #Container.DataItemIndex %>" CommandName="ButtonAllow" 
                        Text="通过" />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="审核2" ShowHeader="False">
                <ItemTemplate>
                    <asp:Button ID="ButtonReject" runat="server" 
                        CommandArgument="<% #Container.DataItemIndex %>" CommandName="ButtonReject" 
                        Text="拒绝" />
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
        <FooterStyle BackColor="#99CCCC" ForeColor="#003399" />
        <HeaderStyle BackColor="#003399" Font-Bold="True" ForeColor="#CCCCFF" />
        <PagerStyle BackColor="#99CCCC" ForeColor="#003399" HorizontalAlign="Left" />
        <RowStyle BackColor="White" ForeColor="#003399" />
        <SelectedRowStyle BackColor="#009999" Font-Bold="True" ForeColor="#CCFF99" />
        <SortedAscendingCellStyle BackColor="#EDF6F6" />
        <SortedAscendingHeaderStyle BackColor="#0D4AC4" />
        <SortedDescendingCellStyle BackColor="#D6DFDF" />
        <SortedDescendingHeaderStyle BackColor="#002876" />
    </asp:GridView>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
        ConnectionString="<%$ ConnectionStrings:DtCmsdbConnectionAudit %>" 
        
        SelectCommand="SELECT [UserName], [SelfIntro], [TLCheckMode], [Reward], [AdminCheckMode], [Team], [JoinReason] FROM [dt_JoinAT] WHERE (([TLCheckMode] = @TLCheckMode) AND ([Team] = @Team))">
        <SelectParameters>
            <asp:Parameter DefaultValue="未审核" Name="TLCheckMode" Type="String" />
            <asp:ControlParameter ControlID="DropDownList1" Name="Team" 
                PropertyName="SelectedValue" Type="String" />
        </SelectParameters>
    </asp:SqlDataSource>
	<asp:Panel ID="Panel1" runat="server">
    
	<table class="style1">
        <tr>
            <td class="style2">
                队长意见：</td>
            <td>
                <asp:TextBox ID="TextBoxTL1" runat="server" Height="100px" Width="448px"></asp:TextBox>
            </td>
        </tr>

    </table>
    <asp:Button ID="ButtonSub1" runat="server" Text="提交" onclick="ButtonSub1_Click" />
	<asp:HiddenField ID="HiddenFieldTL1" runat="server" />
	
    </asp:Panel>
    <asp:Panel ID="Panel2" runat="server">
    
	<table class="style1">
        <tr>
            <td class="style2">
                队长意见：</td>
            <td>
                <asp:TextBox ID="TextBoxTL2" runat="server" Height="100px" Width="448px"></asp:TextBox>
            </td>
        </tr>

    </table>
    <asp:Button ID="ButtonSub2" runat="server" Text="提交" onclick="ButtonSub2_Click" />
	<asp:HiddenField ID="HiddenFieldTL2" runat="server" />
	
    </asp:Panel>
    </div>
<div class="bottom">

	<div class="footer" style="height:25px;">
		<p class="footer_links" >
		   浙江财经大学校艺术团学生组织管理系统
		</p>
	</div>
</div>

    </form>

</body>
</html>