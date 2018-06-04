<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ProgrammeAdd.aspx.cs" Inherits="DtCms.Web.Aspx.ProgrammeAdd" %>
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
        width: 207px;
    }
    .style3
    {
        width: 207px;
        font-weight: bold;
        font-size: x-large;
    }
    .style4
    {
        font-size: x-large;
        font-weight: bold;
    }

    .style5
    {
        font-size: x-large;
        width: 311px;
    }
    .style6
    {
        width: 311px;
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

<div class="container" align="center">



<br />

    活动名称：<asp:DropDownList 
        ID="DropDownList1" runat="server" 
        DataSourceID="SqlDataSource1" DataTextField="Title" DataValueField="Title" 
        AutoPostBack="True">
    </asp:DropDownList>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
        ConnectionString="<%$ ConnectionStrings:DtCmsdbConnectionAudit %>" 
        SelectCommand="SELECT DISTINCT [Title] FROM [dt_TacvitityApply]">
    </asp:SqlDataSource>
    <asp:GridView ID="GridView1" runat="server" AllowPaging="True" 
        AutoGenerateColumns="False" CellPadding="4" DataKeyNames="ActivityId" 
        DataSourceID="SqlDataSource2" ForeColor="#333333" GridLines="None" 
        Height="286px" HorizontalAlign="Center" onrowcommand="GridView1_RowCommand" 
        onrowdatabound="GridView1_RowDataBound" Width="499px">
        <AlternatingRowStyle BackColor="White" />
        <Columns>
            <asp:BoundField DataField="ActivityId" HeaderText="活动编号" ReadOnly="True" 
                SortExpression="ActivityId">
            <HeaderStyle HorizontalAlign="Center" />
            </asp:BoundField>
            <asp:BoundField DataField="Applicant" HeaderText="申请人" 
                SortExpression="Applicant">
            <HeaderStyle HorizontalAlign="Center" />
            </asp:BoundField>
            <asp:BoundField DataField="Title" HeaderText="主题" SortExpression="Title">
            <HeaderStyle HorizontalAlign="Center" />
            </asp:BoundField>
            <asp:BoundField DataField="ATime" HeaderText="时间" SortExpression="ATime">
            <HeaderStyle HorizontalAlign="Center" />
            </asp:BoundField>
            <asp:TemplateField HeaderText="节目单" ShowHeader="False">
                <ItemTemplate>
                    <asp:Button ID="ButtonAdd" runat="server" 
                        CommandArgument="<% #Container.DataItemIndex %>" CommandName="ButtonAdd" 
                        Text="添加" />
                </ItemTemplate>
                <HeaderStyle HorizontalAlign="Center" />
                <ItemStyle HorizontalAlign="Center" />
            </asp:TemplateField>
        </Columns>
        <EditRowStyle BackColor="#2461BF" />
        <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
        <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
        <RowStyle BackColor="#EFF3FB" />
        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
        <SortedAscendingCellStyle BackColor="#F5F7FB" />
        <SortedAscendingHeaderStyle BackColor="#6D95E1" />
        <SortedDescendingCellStyle BackColor="#E9EBEF" />
        <SortedDescendingHeaderStyle BackColor="#4870BE" />
    </asp:GridView>
    <asp:SqlDataSource ID="SqlDataSource2" runat="server" 
        ConnectionString="<%$ ConnectionStrings:DtCmsdbConnectionAudit %>" 
        SelectCommand="SELECT [ActivityId], [Applicant], [Title], [ATime] FROM [dt_TacvitityApply] WHERE (([CheckStatus] = @CheckStatus) AND ([Applicant] = @Applicant) AND ([Title] = @Title)) ORDER BY [ATime] DESC">
        <SelectParameters>
            <asp:Parameter DefaultValue="审核通过" Name="CheckStatus" Type="String" />
            <asp:SessionParameter Name="Applicant" SessionField="TeamLeader" 
                Type="String" />
            <asp:ControlParameter ControlID="DropDownList1" Name="Title" 
                PropertyName="SelectedValue" Type="String" />
        </SelectParameters>
    </asp:SqlDataSource>
    <asp:Panel ID="PanelAdd" runat="server" Width="600px">
        <table class="style1">
            <tr>
                <td class="style3" style="border: thin solid #000000; text-align: center">
                    节目顺序</td>
                <td class="style5" style="border: thin solid #000000; text-align: center">
                    <b>节目名</b></td>
                <td class="style4" style="border: thin solid #000000; text-align: center">
                    演员</td>
            </tr>
            <tr>
                <td class="style2" style="border: thin solid #000000; text-align: center">
                    <asp:Label ID="Label1" runat="server" Text="1"></asp:Label>
                </td>
                <td style="border: thin solid #000000; text-align: center" class="style6">
                    <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                </td>
                <td style="border: thin solid #000000; text-align: center">
                    <asp:Button ID="Button2" runat="server" Text="添加" onclick="Button2_Click" />
                </td>
            </tr>
            <tr>
                <td class="style2" style="border: thin solid #000000; text-align: center">
                    <asp:Label ID="Label2" runat="server" Text="2"></asp:Label>
                </td>
                <td style="border: thin solid #000000; text-align: center" class="style6">
                    <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
                </td>
                <td style="border: thin solid #000000; text-align: center">
                    <asp:Button ID="Button3" runat="server" Text="添加" onclick="Button3_Click" />
                </td>
            </tr>
            <tr>
                <td class="style2" style="border: thin solid #000000; text-align: center">
                    <asp:Label ID="Label3" runat="server" Text="3"></asp:Label>
                </td>
                <td style="border: thin solid #000000; text-align: center" class="style6">
                    <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
                </td>
                <td style="border: thin solid #000000; text-align: center">
                    <asp:Button ID="Button4" runat="server" Text="添加" onclick="Button4_Click" />
                </td>
            </tr>
            <tr>
                <td class="style2" style="border: thin solid #000000; text-align: center">
                    <asp:Label ID="Label4" runat="server" Text="4"></asp:Label>
                </td>
                <td style="border: thin solid #000000; text-align: center" class="style6">
                    <asp:TextBox ID="TextBox4" runat="server"></asp:TextBox>
                </td>
                <td style="border: thin solid #000000; text-align: center">
                    <asp:Button ID="Button5" runat="server" Text="添加" onclick="Button5_Click" />
                </td>
            </tr>
            <tr>
                <td class="style2" style="border: thin solid #000000; text-align: center">
                    <asp:Label ID="Label5" runat="server" Text="5"></asp:Label>
                </td>
                <td style="border: thin solid #000000; text-align: center" class="style6">
                    <asp:TextBox ID="TextBox5" runat="server"></asp:TextBox>
                </td>
                <td style="border: thin solid #000000; text-align: center">
                    <asp:Button ID="Button6" runat="server" Text="添加" onclick="Button6_Click" />
                </td>
            </tr>
            <tr>
                <td class="style2" style="border: thin solid #000000; text-align: center">
                    <asp:Label ID="Label6" runat="server" Text="6"></asp:Label>
                </td>
                <td style="border: thin solid #000000; text-align: center" class="style6">
                    <asp:TextBox ID="TextBox6" runat="server"></asp:TextBox>
                </td>
                <td style="border: thin solid #000000; text-align: center">
                    <asp:Button ID="Button7" runat="server" Text="添加" onclick="Button7_Click" />
                </td>
            </tr>
            <tr>
                <td class="style2" style="border: thin solid #000000; text-align: center">
                    <asp:Label ID="Label7" runat="server" Text="7"></asp:Label>
                </td>
                <td style="border: thin solid #000000; text-align: center" class="style6">
                    <asp:TextBox ID="TextBox7" runat="server"></asp:TextBox>
                </td>
                <td style="border: thin solid #000000; text-align: center">
                    <asp:Button ID="Button8" runat="server" Text="添加" onclick="Button8_Click" />
                </td>
            </tr>
            <tr>
                <td class="style2" style="border: thin solid #000000; text-align: center">
                    <asp:Label ID="Label8" runat="server" Text="8"></asp:Label>
                </td>
                <td style="border: thin solid #000000; text-align: center" class="style6">
                    <asp:TextBox ID="TextBox8" runat="server"></asp:TextBox>
                </td>
                <td style="border: thin solid #000000; text-align: center">
                    <asp:Button ID="Button9" runat="server" Text="添加" onclick="Button9_Click" />
                </td>
            </tr>
            <tr>
                <td class="style2" style="border: thin solid #000000; text-align: center">
                    <asp:Label ID="Label9" runat="server" Text="9"></asp:Label>
                </td>
                <td style="border: thin solid #000000; text-align: center" class="style6">
                    <asp:TextBox ID="TextBox9" runat="server"></asp:TextBox>
                </td>
                <td style="border: thin solid #000000; text-align: center">
                    <asp:Button ID="Button10" runat="server" Text="添加" onclick="Button10_Click" />
                </td>
            </tr>
            <tr>
                <td class="style2" style="border: thin solid #000000; text-align: center">
                    <asp:Label ID="Label10" runat="server" Text="10"></asp:Label>
                </td>
                <td style="border: thin solid #000000; text-align: center" class="style6">
                    <asp:TextBox ID="TextBox10" runat="server"></asp:TextBox>
                </td>
                <td style="border: thin solid #000000; text-align: center">
                    <asp:Button ID="Button11" runat="server" Text="添加" onclick="Button11_Click" 
                        style="height: 21px" />
                </td>
            </tr>
            <tr>
                <td class="style2" style="border: thin solid #000000; text-align: center">
                    <asp:Label ID="Label11" runat="server" Text="11"></asp:Label>
                </td>
                <td style="border: thin solid #000000; text-align: center" class="style6">
                    <asp:TextBox ID="TextBox11" runat="server"></asp:TextBox>
                </td>
                <td style="border: thin solid #000000; text-align: center">
                    <asp:Button ID="Button12" runat="server" Text="添加" onclick="Button12_Click" />
                </td>
            </tr>
            <tr>
                <td class="style2" style="border: thin solid #000000; text-align: center">
                    <asp:Label ID="Label12" runat="server" Text="12"></asp:Label>
                </td>
                <td style="border: thin solid #000000; text-align: center" class="style6">
                    <asp:TextBox ID="TextBox12" runat="server"></asp:TextBox>
                </td>
                <td style="border: thin solid #000000; text-align: center">
                    <asp:Button ID="Button13" runat="server" Text="添加" onclick="Button13_Click" />
                </td>
            </tr>
            <tr>
                <td class="style2" style="border: thin solid #000000; text-align: center">
                    <asp:Label ID="Label13" runat="server" Text="13"></asp:Label>
                </td>
                <td style="border: thin solid #000000; text-align: center" class="style6">
                    <asp:TextBox ID="TextBox13" runat="server"></asp:TextBox>
                </td>
                <td style="border: thin solid #000000; text-align: center">
                    <asp:Button ID="Button14" runat="server" Text="添加" onclick="Button14_Click" />
                </td>
            </tr>
            <tr>
                <td class="style2" style="border: thin solid #000000; text-align: center">
                    <asp:Label ID="Label14" runat="server" Text="14"></asp:Label>
                </td>
                <td style="border: thin solid #000000; text-align: center" class="style6">
                    <asp:TextBox ID="TextBox14" runat="server"></asp:TextBox>
                </td>
                <td style="border: thin solid #000000; text-align: center">
                    <asp:Button ID="Button15" runat="server" Text="添加" onclick="Button15_Click" />
                </td>
            </tr>
            <tr>
                <td class="style2" style="border: thin solid #000000; text-align: center">
                    <asp:Label ID="Label15" runat="server" Text="15"></asp:Label>
                </td>
                <td style="border: thin solid #000000; text-align: center" class="style6">
                    <asp:TextBox ID="TextBox15" runat="server"></asp:TextBox>
                </td>
                <td style="border: thin solid #000000; text-align: center">
                    <asp:Button ID="Button16" runat="server" Text="添加" onclick="Button16_Click" />
                </td>
            </tr>
        </table>
        <br />
        <asp:Button ID="ButtonPSub" runat="server" Text="提交" 
            onclick="ButtonPSub_Click" />
        <asp:HiddenField ID="HiddenFieldP" runat="server" />
        <br />
    </asp:Panel>
    <br />
    
    <asp:Panel ID="PanelActor" runat="server">
    <div align="center">
    队伍：<asp:DropDownList ID="DropDownListTeam" runat="server" AutoPostBack="True">
        <asp:ListItem>韵落钱塘合唱团</asp:ListItem>
        <asp:ListItem>流行音乐工作室</asp:ListItem>
        <asp:ListItem>青藤话剧社</asp:ListItem>
        <asp:ListItem>舞蹈队</asp:ListItem>
        <asp:ListItem>街舞队</asp:ListItem>
        <asp:ListItem>麦浪主持朗诵组</asp:ListItem>
        <asp:ListItem>西洋乐队</asp:ListItem>
        <asp:ListItem>民乐队</asp:ListItem>
        <asp:ListItem>模特队</asp:ListItem>
    </asp:DropDownList>
        <asp:GridView ID="GridViewActor" runat="server" AutoGenerateColumns="False" 
            DataSourceID="SqlDataSource3" CellPadding="4" ForeColor="#333333" 
            GridLines="None" Height="169px" Width="435px">
            <AlternatingRowStyle BackColor="White" />
            <Columns>
                <asp:TemplateField HeaderText="选择" ShowHeader="False">
                    <ItemTemplate>
                        <asp:CheckBox ID="CheckBox1" runat="server" />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="UserName" HeaderText="用户名" 
                    SortExpression="UserName" />
                <asp:BoundField DataField="TureName" HeaderText="姓名" 
                    SortExpression="TureName" />
                <asp:BoundField DataField="UserTel" HeaderText="手机" SortExpression="UserTel" />
            </Columns>
            <EditRowStyle BackColor="#7C6F57" />
            <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center" />
            <RowStyle BackColor="#E3EAEB" />
            <SelectedRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />
            <SortedAscendingCellStyle BackColor="#F8FAFA" />
            <SortedAscendingHeaderStyle BackColor="#246B61" />
            <SortedDescendingCellStyle BackColor="#D4DFE1" />
            <SortedDescendingHeaderStyle BackColor="#15524A" />
        </asp:GridView>
        <asp:SqlDataSource ID="SqlDataSource3" runat="server" 
            ConnectionString="<%$ ConnectionStrings:DtCmsdbConnectionAudit %>" 
            SelectCommand="SELECT [UserName], [TureName], [UserTel] FROM [dt_Member] WHERE ([Team] = @Team)">
            <SelectParameters>
                <asp:ControlParameter ControlID="DropDownListTeam" Name="Team" 
                    PropertyName="SelectedValue" Type="String" />
            </SelectParameters>
        </asp:SqlDataSource>
        <asp:HiddenField ID="HiddenFieldActor" runat="server" />
        <asp:Button ID="ButtonSub" runat="server" onclick="ButtonSub_Click" 
            style="width: 40px" Text="提交" />
        <asp:Button ID="ButtonReturn" runat="server" onclick="ButtonReturn_Click" 
            Text="返回" />
        <br />
        </div>
        <br />
    </asp:Panel>





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
 
