<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AppliRecord.aspx.cs" Inherits="DtCms.Web.Aspx.AppliRecord" %>
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
        clear: both;
        font-size: xx-large;
    }
    .style2
    {
        font-size: xx-large;
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
	
    <div class="style1" style="height:20px;"></div>
    <div class="style2">
    
    
        活动提交记录</div>
	<!-- ===== 横幅首页图片 ===== -->
	<div ><script type="text/javascript" src="/Tools/Advert_js.ashx?id=2"></script></div>
	<div >
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
            DataSourceID="SqlDataSource1" AllowPaging="True" AllowSorting="True" 
            BackColor="White" BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px" 
            CellPadding="4" onrowcommand="GridView1_RowCommand" 
            onrowdatabound="GridView1_RowDataBound" Width="900px" 
            style="margin-right: 0px">
            <Columns>
                <asp:BoundField DataField="ActivityId" HeaderText="活动编号" 
                    SortExpression="ActivityId" />
                <asp:BoundField DataField="Applicant" HeaderText="申请人" />
                <asp:BoundField DataField="Title" HeaderText="主题" />
                <asp:BoundField DataField="Budget" HeaderText="预算" />
                <asp:BoundField DataField="ATime" HeaderText="举办时间" SortExpression="ATime" />
                <asp:BoundField DataField="AConten" HeaderText="策划" />
                <asp:BoundField DataField="Place" HeaderText="地点" SortExpression="Place" />
                <asp:BoundField DataField="AddTime" HeaderText="提交时间" 
                    SortExpression="AddTime" />
                <asp:TemplateField HeaderText="审核状态" SortExpression="CheckStatus">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("CheckStatus") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="LabelAudit" runat="server" Text='<%# Bind("CheckStatus") %>'></asp:Label>
                    </ItemTemplate>
                    <HeaderStyle Width="100px" />
                </asp:TemplateField>
                <asp:BoundField DataField="TicketNum" HeaderText="票数" />
                <asp:BoundField DataField="TicketType" HeaderText="发票类型" 
                    SortExpression="TicketType" />
                <asp:BoundField DataField="TicketStatus" HeaderText="发票状态" 
                    SortExpression="TicketStatus" />
                <asp:TemplateField HeaderText="编辑" ShowHeader="False">
                    <ItemTemplate>
                        <asp:Button ID="ButtonEdit" runat="server" 
                            CommandArgument="<% #Container.DataItemIndex %>" CommandName="ButtonEdit" 
                            Text="编辑" Width="40px" />
                    </ItemTemplate>
                    <HeaderStyle Width="40px" />
                    <ItemStyle Width="20px" />
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
            
            SelectCommand="SELECT [ActivityId], [Applicant], [Title], [Budget], [ATime], [AConten], [Place], [AddTime], [CheckStatus], [TicketNum], [TicketType], [TicketStatus] FROM [dt_TacvitityApply] WHERE ([Applicant] = @Applicant)">
            <SelectParameters>
                <asp:SessionParameter Name="Applicant" SessionField="TeamLeader" 
                    Type="String" />
            </SelectParameters>
        </asp:SqlDataSource>
        <asp:HiddenField ID="HiddenFieldEdit" runat="server" />
        <asp:Panel ID="PanelEdit" runat="server">
        <div id="Div1" class="commentform" runat="server">
				<div class="nTitle">修改信息</div>
		        <br />
                <div>
                
                
                
                
                    <table class="style3" dir="ltr" border="1px">
                        <tr>
                            <td class="style14" bgcolor="White" >
                                活动编号：</td>
                            <td class="style22" bgcolor="White">
                                <asp:TextBox ID="TextBoxActivityId" runat="server" ></asp:TextBox>
                            </td>
                            <td class="style16" bgcolor="White">
                                申请人：</td>
                            <td class="style25" bgcolor="White">
                                <asp:TextBox ID="TextBoxApplicant" runat="server" ReadOnly="True" BackColor="Silver"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="style15" bgcolor="White">
                                活动主题：</td>
                            <td class="style23" bgcolor="White">
                                <asp:TextBox ID="TextBoxTitle" runat="server"></asp:TextBox>
                            </td>
                            <td class="style17" bgcolor="White">
                                预算</td>
                            <td class="style26" bgcolor="White">
                                <asp:TextBox ID="TextBoxBudget" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="style15" bgcolor="White">
                                时间：</td>
                            <td class="style23" bgcolor="White">
                                <asp:TextBox ID="TextBoxATime" runat="server"></asp:TextBox>
                            </td>
                            <td class="style17" bgcolor="White">
                                地点：</td>
                            <td class="style26" bgcolor="White">
                                <asp:TextBox ID="TextBoxPlace" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="style4" bgcolor="White">
                                审核状态：</td>
                            <td class="style24" bgcolor="White">
                                <asp:TextBox ID="TextBoxCheckStatus" runat="server" ReadOnly="True" BackColor="Silver" ></asp:TextBox>
                            </td>
                            <td class="style18" bgcolor="White">
                                门票类型：</td>
                            <td class="style27" bgcolor="White">
                                <asp:DropDownList ID="DropDownListTicketType" runat="server" 
                                    ClientIDMode="Predictable">
                                    <asp:ListItem Value="SuperVIP">超级VIP</asp:ListItem>
                                    <asp:ListItem>VIP</asp:ListItem>
                                    <asp:ListItem Value="commonsite">普通座位</asp:ListItem>
                                    <asp:ListItem Value="StandingTicket">站票</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td class="style14" bgcolor="White">
                                门票数量：</td>
                            <td class="style22" bgcolor="White">
                                <asp:TextBox ID="TextBoxTicketNum" runat="server"></asp:TextBox>
                            </td>
                            <td class="style16" bgcolor="White">
                                发票情况：</td>
                            <td class="style25" bgcolor="White">
                                <asp:TextBox ID="TextBoxTicketIssue" runat="server" ReadOnly="true"></asp:TextBox>
                            </td>
                        </tr>
                      
                        <tr>
                            <td class="style11" bgcolor="White">
                                策划内容：</td>
                            <td colspan="3" bgcolor="White">
                                <asp:TextBox ID="TextBoxAcontent" runat="server" Height="131px" Width="532px" maxlength="3000"></asp:TextBox>
                            </td>
                            
                        </tr>
                      
                    </table>
                <br />
                <div>
                    <asp:Button ID="ButtonEditSub" runat="server" Text="提交修改" 
                        onclick="ButtonEditSub_Click" /> &nbsp; &nbsp;
                    <asp:Button ID="ButtonReturn" runat="server" Text="返回" Height="23px" 
                        Width="81px" onclick="ButtonReturn_Click" />
                    </div>
                
                
                </div>


                    <div class="clear"></div>
				
			</div>
        </asp:Panel>
    </div>
	
	<div class="news_list">
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
