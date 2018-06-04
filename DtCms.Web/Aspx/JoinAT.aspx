<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="JoinAT.aspx.cs" Inherits="DtCms.Web.Aspx.JoinAT" %>
<%@ Import namespace="DtCms.Common" %>
<%@ Register TagPrefix="DtContorl" Namespace="DtCms.Web.UI" Assembly="DtCms.Web.UI" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<title>浙江财经大学校艺术团学生组织管理系统</title>

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

    .style2
    {
        width: 260px;
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
        {%><a href="#">用户名：<%=Session["Member"].ToString()%></a><%}%></li>
	</ul>
</div>

<div class="container" align="center">
    <asp:GridView ID="GridView1" runat="server" AllowPaging="True" 
        AutoGenerateColumns="False" BackColor="White" BorderColor="#3366CC" 
        BorderStyle="None" BorderWidth="1px" CellPadding="4" 
        DataSourceID="SqlDataSource1" Height="135px" Width="663px" 
        onrowcommand="GridView1_RowCommand" 
        onrowdatabound="GridView1_RowDataBound">
        <Columns>
            <asp:BoundField DataField="SocietiesName" HeaderText="队伍名" 
                SortExpression="SocietiesName" />
            <asp:BoundField DataField="SocietiesRemark" HeaderText="队伍介绍" 
                SortExpression="SocietiesRemark" />
            <asp:TemplateField HeaderText="审核状态" ShowHeader="False">
                <ItemTemplate>
                    <asp:Label ID="LabelMode" runat="server" Text="未申请"></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="申请" ShowHeader="False">
                <ItemTemplate>
                    <asp:Button ID="ButtonJoinAT" runat="server" 
                        CommandArgument="<%#Container.DataItemIndex%>" CommandName="ButtonJoinAT" 
                        Text="申请" />
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
        <FooterStyle BackColor="#99CCCC" ForeColor="#003399" />
        <HeaderStyle BackColor="#003399" Font-Bold="True" ForeColor="#CCCCFF" />
        <PagerStyle ForeColor="#003399" HorizontalAlign="Left" BackColor="#99CCCC" />
        <RowStyle BackColor="White" ForeColor="#003399" />
        <SelectedRowStyle BackColor="#009999" Font-Bold="True" ForeColor="#CCFF99" />
        <SortedAscendingCellStyle BackColor="#EDF6F6" />
        <SortedAscendingHeaderStyle BackColor="#0D4AC4" />
        <SortedDescendingCellStyle BackColor="#D6DFDF" />
        <SortedDescendingHeaderStyle BackColor="#002876" />
    </asp:GridView>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
        ConnectionString="<%$ ConnectionStrings:DtCmsdbConnectionAudit %>" 
        SelectCommand="SELECT [SocietiesName], [SocietiesRemark] FROM [dt_Societies]">
    </asp:SqlDataSource>
    <asp:Panel ID="PanelApp" runat="server">
        <table class="style1">
            <tr>
                <td colspan="2">
                    申请信息</td>
            </tr>
            <tr>
                <td class="style2" style="border: thin solid #000000">
                    自我介绍：</td>
                <td style="border: thin solid #000000">
                    <asp:TextBox ID="TextBox1" runat="server" Height="100px" Width="363px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="style2" style="border: thin solid #000000">
                    所获奖项：</td>
                <td style="border: thin solid #000000">
                    <asp:TextBox ID="TextBox2" runat="server" Height="100px" Width="363px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="style2" style="border: thin solid #000000">
                    参加理由：</td>
                <td style="border: thin solid #000000">
                    <asp:TextBox ID="TextBox3" runat="server" Height="100px" Width="363px"></asp:TextBox>
                </td>
            </tr>
        </table>
        <asp:Button ID="Buttonsub" runat="server" onclick="Buttonsub_Click" Text="提交" />
        <asp:HiddenField ID="HiddenField1" runat="server" />
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
