<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ActivityProcess.aspx.cs" Inherits="DtCms.Web.Aspx.ActivityProcess" %>
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
           <li ><a href="AppliRecord.aspx" style="text-align:center" >申请记录</a></li>
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
	
	<div class="news_list">
		<asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
            BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" 
            CellPadding="3" DataSourceID="SqlDataSource1" Width="800px" 
            onrowcommand="GridView1_RowCommand" onrowdatabound="GridView1_RowDataBound">
            <Columns>
                <asp:BoundField DataField="ActivityId" HeaderText="活动编号" 
                    SortExpression="ActivityId" />
                <asp:BoundField DataField="Title" HeaderText="主题" SortExpression="Title" />
                <asp:BoundField DataField="ATime" HeaderText="时间" SortExpression="ATime" />
                <asp:BoundField DataField="Place" HeaderText="地点" SortExpression="Place" />
                <asp:BoundField DataField="CheckStatus" HeaderText="审核状态" 
                    SortExpression="CheckStatus">
                <HeaderStyle Width="50px" />
                </asp:BoundField>
                <asp:BoundField DataField="TicketStatus" HeaderText="发票状态" 
                    SortExpression="TicketStatus" />
                <asp:BoundField DataField="TicketType" HeaderText="发票类型" 
                    SortExpression="TicketType" />
                <asp:BoundField DataField="TicketNum" HeaderText="门票数" 
                    SortExpression="TicketNum" />
                <asp:TemplateField HeaderText="前期准备" ShowHeader="False">
                    <ItemTemplate>
                        <asp:Button ID="ButtonPreSub" runat="server" 
                            CommandArgument="<% #Container.DataItemIndex %>" CommandName="ButtonPreSub" 
                            Text="提交" />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="中期汇报" ShowHeader="False">
                    <ItemTemplate>
                        <asp:Button ID="ButtonMidSub" runat="server" 
                            CommandArgument="<% #Container.DataItemIndex %>" CommandName="ButtonMidSub" 
                            Text="提交" />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="活动前夕" ShowHeader="False">
                    <ItemTemplate>
                        <asp:Button ID="ButtonEveSub" runat="server" 
                            CommandArgument="<% #Container.DataItemIndex %>" CommandName="ButtonEveSub" 
                            Text="提交" />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
            <FooterStyle BackColor="White" ForeColor="#000066" />
            <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
            <RowStyle ForeColor="#000066" />
            <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
            <SortedAscendingCellStyle BackColor="#F1F1F1" />
            <SortedAscendingHeaderStyle BackColor="#007DBB" />
            <SortedDescendingCellStyle BackColor="#CAC9C9" />
            <SortedDescendingHeaderStyle BackColor="#00547E" />
        </asp:GridView>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
            ConnectionString="<%$ ConnectionStrings:DtCmsdbConnectionAudit %>" 
            SelectCommand="SELECT [ActivityId], [Title], [Budget], [ATime], [Place], [TicketStatus], [TicketType], [TicketNum], [CheckStatus] FROM [dt_TacvitityApply] WHERE (([Applicant] = @Applicant) AND ([CheckStatus] = @CheckStatus))">
            <SelectParameters>
                <asp:SessionParameter Name="Applicant" SessionField="TeamLeader" 
                    Type="String" />
                <asp:Parameter DefaultValue="审核通过" Name="CheckStatus" Type="String" />
            </SelectParameters>
        </asp:SqlDataSource>
        <asp:HiddenField ID="HiddenFieldSub" runat="server" />
        <br />
        <asp:Panel ID="PanelPre" runat="server">
            <table class="style1">
                <tr>
                    <td align="center" width="300px" style="font-size: xx-large">
                        <br />
                        前期准备：</td>
                    <td>
                        <asp:TextBox ID="TextBoxPre" runat="server" Height="105px" Width="432px" 
                        maxlength="3000"></asp:TextBox>
                    </td>
                </tr>
                
            </table>
            <br />
                <div align="center">
                    <asp:Button ID="Button1" runat="server" Text="提交" onclick="Button1_Click" />
                    <asp:Button ID="Button2" runat="server" Text="返回" onclick="Button2_Click" />
                </div>
        <br />

        </asp:Panel>
        <asp:Panel ID="PanelMiddle" runat="server">
        <br />

            <table class="style1">
                <tr>
                    <td align="center" width="300px" style="font-size: xx-large">
                        <br />
                        中期汇报：</td>
                    <td>
                        <asp:TextBox ID="TextBoxMiddle" runat="server" Height="105px" Width="432px" 
                        maxlength="3000"></asp:TextBox>
                    </td>
                </tr>
            </table>
            <br />
                <div align="center">
                    <asp:Button ID="Button3" runat="server" Text="提交" onclick="Button3_Click" />
                    <asp:Button ID="Button4" runat="server" Text="返回" onclick="Button4_Click" />
        <br />

                </div>
        </asp:Panel>
        <asp:Panel ID="PanelEve" runat="server">
        <br />

            <table class="style1">
                <tr>
                    <td align="center" width="300px" style="font-size: xx-large">
                        <br />
                        活动前夕：</td>
                    <td>
                        <asp:TextBox ID="TextBoxEve" runat="server" Height="105px" Width="432px" 
                        maxlength="3000"></asp:TextBox>
                    </td>
                </tr>
            </table>
            <br />
                <div align="center">
                    <asp:Button ID="Button5" runat="server" Text="提交" onclick="Button5_Click" />
                    <asp:Button ID="Button6" runat="server" Text="返回" onclick="Button6_Click" />
                </div>
        </asp:Panel>
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

    </form>

</body>
</html>
