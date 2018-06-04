<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="JoinActivity.aspx.cs" Inherits="DtCms.Web.Aspx.JoinActivity" %>
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
        font-size: x-large;
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

<div class="container">
    <table class="style1">
        <tr>
            <td align="center" class="style2">
                抢票</td>
        </tr>
        <tr>
            <td align="center">
                <asp:GridView ID="GridView1" runat="server" AllowPaging="True" 
                    AutoGenerateColumns="False" DataKeyNames="ActivityId" 
                    DataSourceID="SqlDataSource1" onrowcommand="GridView1_RowCommand" 
                    onrowdatabound="GridView1_RowDataBound" BackColor="White" 
                    BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px" CellPadding="4" 
                    Width="800px">
                    <Columns>
                        <asp:BoundField DataField="Title" HeaderText="主题" SortExpression="Title" />
                        <asp:BoundField DataField="ActivityId" HeaderText="活动编号" ReadOnly="True" 
                            SortExpression="ActivityId" Visible="False">
                        </asp:BoundField>
                        <asp:BoundField DataField="ATime" HeaderText="时间" SortExpression="ATime" />
                        <asp:BoundField DataField="AInTrodatction" HeaderText="活动介绍" 
                            SortExpression="AInTrodatction" />
                        <asp:BoundField DataField="Place" HeaderText="地点" SortExpression="Place" />
                        <asp:BoundField DataField="SuperVIPNum" HeaderText="超级VIP" 
                            SortExpression="SuperVIPNum" />
                        <asp:TemplateField HeaderText="抢票1" ShowHeader="False">
                            <ItemTemplate>
                                <asp:Button ID="ButtonSV" runat="server" 
                                    CommandArgument="<%#Container.DataItemIndex%>" CommandName="ButtonSV" 
                                    Text="抢票" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="VIPNum" HeaderText="VIP" SortExpression="VIPNum" />
                        <asp:TemplateField HeaderText="抢票2" ShowHeader="False">
                            <ItemTemplate>
                                <asp:Button ID="ButtonV" runat="server" 
                                    CommandArgument="<%#Container.DataItemIndex%>" CommandName="ButtonV" 
                                    Text="抢票" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="CommonNum" HeaderText="普通票" 
                            SortExpression="CommonNum" />
                        <asp:TemplateField HeaderText="抢票3" ShowHeader="False">
                            <ItemTemplate>
                                <asp:Button ID="ButtonC" runat="server" 
                                    CommandArgument="<%#Container.DataItemIndex%>" CommandName="ButtonC" 
                                    Text="抢票" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="StandingNum" HeaderText="站票" 
                            SortExpression="StandingNum" />
                        <asp:TemplateField HeaderText="抢票4" ShowHeader="False">
                            <ItemTemplate>
                                <asp:Button ID="ButtonS" runat="server" 
                                    CommandArgument="<%#Container.DataItemIndex%>" CommandName="ButtonS" 
                                    Text="抢票" />
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
                    SelectCommand="SELECT [Title], [ActivityId], [ATime], [AConten], [AInTrodatction], [Place], [SuperVIPNum], [VIPNum], [CommonNum], [StandingNum] FROM [dt_TacvitityApply] WHERE ([TicketStatus] = @TicketStatus) ORDER BY [ATime]">
                    <SelectParameters>
                        <asp:Parameter DefaultValue="发布中" Name="TicketStatus" Type="String" />
                    </SelectParameters>
                </asp:SqlDataSource>
                <br />
            </td>
        </tr>
    </table>
</div>
<div class="container">



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
 
