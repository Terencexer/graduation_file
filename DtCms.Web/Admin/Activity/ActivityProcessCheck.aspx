<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ActivityProcessCheck.aspx.cs" Inherits="DtCms.Web.Admin.Activity.ActivityProcessCheck" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>资讯管理</title>
    <link rel="stylesheet" type="text/css" href="../images/style.css" />
    <link href="../../css/pagination.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="../../js/jquery-1.3.2.min.js"></script>
    <script type="text/javascript" src="../../js/jquery.pagination.js"></script>
    <script type="text/javascript" src="../js/function.js"></script>
    <script type="text/javascript">



        function pageselectCallback(page_id, jq) {
            //alert(page_id); 回调函数，进一步使用请参阅说明文档
        }

        $(function () {
            $(".msgtable tr:nth-child(odd)").addClass("tr_bg"); //隔行变色
            $(".msgtable tr").hover(
			    function () {
			        $(this).addClass("tr_hover_col");
			    },
			    function () {
			        $(this).removeClass("tr_hover_col");
			    }
		    );
        });
    </script>
    <style type="text/css">
        .style1
        {
            width: 890px;
            height: 110px;
        }
        </style>
</head>
<body style="padding:10px;">
    
    <form id="form1" runat="server">
    
    <div class="navigation"><b>您当前的位置：首页 &gt; 活动管理 &gt; 活动审批</b></div>
    <div class="spClear"></div>
    <div>
    
    
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
            DataSourceID="SqlDataSource1" Width="1000px" 
            onrowcommand="GridView1_RowCommand" 
            onrowdatabound="GridView1_RowDataBound" AllowPaging="True" AllowSorting="True" 
            BackColor="White" BorderColor="#999999" BorderStyle="None" BorderWidth="1px" 
            CellPadding="3" GridLines="Vertical">
            <AlternatingRowStyle BackColor="#DCDCDC" />
            <Columns>
                <asp:BoundField DataField="ActivityId" HeaderText="活动编号" 
                    SortExpression="ActivityId" />
                <asp:BoundField DataField="Applicant" HeaderText="申请人" 
                    SortExpression="Applicant" />
                <asp:BoundField DataField="Title" HeaderText="主题" />
                <asp:BoundField DataField="Budget" HeaderText="预算" />
                <asp:BoundField DataField="ATime" HeaderText="时间" SortExpression="ATime" />
                <asp:BoundField DataField="Place" SortExpression="Place" />
                <asp:BoundField DataField="CheckStatus" HeaderText="审核状态" 
                    SortExpression="CheckStatus" />
                <asp:BoundField DataField="TicketNum" HeaderText="发票数目" />
                <asp:BoundField DataField="TicketType" HeaderText="门票类型" />
                <asp:BoundField DataField="TicketStatus" HeaderText="发票状态" 
                    SortExpression="TicketStatus" />
                <asp:TemplateField HeaderText="活动状态">
                    <ItemTemplate>
                        <asp:Label ID="LabelPreStatus" runat="server" Text="准备中"></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="前期准备" ShowHeader="False">
                    <ItemTemplate>
                        <asp:Button ID="ButtonPreCheck" runat="server" 
                            CommandArgument="<% #Container.DataItemIndex %>" CommandName="ButtonPreCheck" 
                            Text="查看" />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="中期汇报" ShowHeader="False">
                    <ItemTemplate>
                        <asp:Button ID="ButtonMidCheck" runat="server" 
                            CommandArgument="<% #Container.DataItemIndex %>" CommandName="ButtonMidCheck" 
                            Text="查看" />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="晚会前期" ShowHeader="False">
                    <ItemTemplate>
                        <asp:Button ID="ButtonEveCheck" runat="server" 
                            CommandArgument="<% #Container.DataItemIndex %>" CommandName="ButtonEveCheck" 
                            Text="查看" />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
            <FooterStyle BackColor="#CCCCCC" ForeColor="Black" />
            <HeaderStyle BackColor="#000084" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
            <RowStyle BackColor="#EEEEEE" ForeColor="Black" />
            <SelectedRowStyle BackColor="#008A8C" Font-Bold="True" ForeColor="White" />
            <SortedAscendingCellStyle BackColor="#F1F1F1" />
            <SortedAscendingHeaderStyle BackColor="#0000A9" />
            <SortedDescendingCellStyle BackColor="#CAC9C9" />
            <SortedDescendingHeaderStyle BackColor="#000065" />
        </asp:GridView>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
            ConnectionString="<%$ ConnectionStrings:DtCmsdbConnectionAudit %>" 
            SelectCommand="SELECT [ActivityId], [Applicant], [Title], [Budget], [ATime], [Place], [CheckStatus], [TicketNum], [TicketType], [TicketStatus] FROM [dt_TacvitityApply] WHERE ([CheckStatus] = @CheckStatus)">
            <SelectParameters>
                <asp:Parameter DefaultValue="审核通过" Name="CheckStatus" Type="String" />
            </SelectParameters>
        </asp:SqlDataSource>
        <asp:HiddenField ID="HiddenFieldCheck" runat="server" />
        <asp:Panel ID="PanelPre" runat="server">
        <br />
            <table class="style1">
                <tr>
                    <td align="center" width="300px" style="font-size: xx-large">
                        <br />
                        前期准备：</td>
                    <td>
                        <asp:TextBox ID="TextBoxPre" runat="server" Height="105px" Width="432px" 
                        maxlength="3000" ReadOnly="true"></asp:TextBox>
                    </td>
                </tr>
                
            </table>
            <br />
                <div align="center">
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
                        maxlength="3000" ReadOnly="true"></asp:TextBox>
                    </td>
                </tr>
            </table>
            <br />
                <div align="center">
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
                        maxlength="3000" ReadOnly="true"></asp:TextBox>
                    </td>
                </tr>
            </table>
            <br />
                <div align="center">
                    <asp:Button ID="Button6" runat="server" Text="返回" onclick="Button6_Click" />
                </div>
        </asp:Panel>
    
    </div>
                    <div class="clear"></div>

    </form>
</body>
</html>
