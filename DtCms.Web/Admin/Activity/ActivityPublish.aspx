<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ActivityPublish.aspx.cs" Inherits="DtCms.Web.Admin.Activity.ActivityPublish" %>

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
        .style3
        {
            width: 100%;
        }
        .style4
        {
            height: 13px;
        }
    </style>
</head>
<body style="padding:10px;">
    
    <form id="form1" runat="server">
    
    <div class="navigation"><b>您当前的位置：首页 &gt; 活动管理 &gt; 活动审批</b></div>
    <div class="spClear"></div>
    <div>
        <asp:Label ID="Label1" runat="server" Text="发布状态"></asp:Label> 
        <asp:DropDownList ID="DropDownPubMode" runat="server" AutoPostBack="True">
            <asp:ListItem>发布中</asp:ListItem>
            <asp:ListItem>未发布</asp:ListItem>
        </asp:DropDownList>
        <table class="style3">
            <tr>
                <td align="center" bgcolor="#6699FF" class="style4" 
                    style="font-family: 黑体; font-size: x-large; text-decoration: underline; text-align: center">
                    活动发布表</td>
            </tr>
            <tr>
                <td>
                    <asp:GridView ID="GridView1" runat="server" AllowPaging="True" 
                        AllowSorting="True" AutoGenerateColumns="False" CellPadding="4" 
                        DataKeyNames="ActivityId" DataSourceID="SqlDataSource1" ForeColor="#333333" 
                        GridLines="None" onrowcommand="GridView1_RowCommand" 
                        onrowdatabound="GridView1_RowDataBound">
                        <AlternatingRowStyle BackColor="White" />
                        <Columns>
                            <asp:BoundField DataField="ActivityId" HeaderText="编号" ReadOnly="True" 
                                SortExpression="ActivityId" />
                            <asp:BoundField DataField="Title" HeaderText="活动主题" SortExpression="Title" />
                            <asp:BoundField DataField="ATime" HeaderText="活动时间" SortExpression="ATime" />
                            <asp:BoundField DataField="Place" HeaderText="地点" SortExpression="Place" />
                            <asp:BoundField DataField="AInTrodatction" HeaderText="活动介绍" 
                                SortExpression="AInTrodatction" />
                            <asp:BoundField DataField="SuperVIPNum" HeaderText="超级VIP" 
                                SortExpression="SuperVIPNum" />
                            <asp:BoundField DataField="VIPNum" HeaderText="VIP" 
                                SortExpression="VIPNum" />
                            <asp:BoundField DataField="StandingNum" HeaderText="站票" 
                                SortExpression="StandingNum" />
                            <asp:BoundField DataField="CommonNum" HeaderText="普通票" 
                                SortExpression="CommonNum" />
                            <asp:BoundField DataField="TicketStatus" HeaderText="发票状态" 
                                SortExpression="TicketStatus" />
                            <asp:CommandField EditText="编辑" HeaderText="编辑" ShowEditButton="True" 
                                UpdateText="确定" />
                            <asp:TemplateField HeaderText="发布" ShowHeader="False">
                                <ItemTemplate>
                                    <asp:Button ID="ButtonIssue" runat="server" 
                                        CommandArgument="<% #Container.DataItemIndex %>" CommandName="ButtonIssue"   OnClientClick="return confirm('确认发布？')"
                                        Text="发布" />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="发布取消" ShowHeader="False">
                                <ItemTemplate>
                                    <asp:Button ID="ButtonIssueCancel" runat="server" 
                                        CommandArgument="<% #Container.DataItemIndex %>" 
                                        CommandName="ButtonIssueCancel" Text="取消" />
                                </ItemTemplate>
                            </asp:TemplateField>
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
                    <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
                        ConnectionString="<%$ ConnectionStrings:DtCmsdbConnectionAudit %>" 
                        DeleteCommand="DELETE FROM [dt_TacvitityApply] WHERE [ActivityId] = @ActivityId" 
                        InsertCommand="INSERT INTO [dt_TacvitityApply] ([ActivityId], [Title], [ATime], [Place], [AInTrodatction], [SuperVIPNum], [VIPNum], [StandingNum], [CommonNum], [TicketStatus]) VALUES (@ActivityId, @Title, @ATime, @Place, @AInTrodatction, @SuperVIPNum, @VIPNum, @StandingNum, @CommonNum, @TicketStatus)" 
                        SelectCommand="SELECT [ActivityId], [Title], [ATime], [Place], [AInTrodatction], [SuperVIPNum], [VIPNum], [StandingNum], [CommonNum], [TicketStatus] FROM [dt_TacvitityApply] WHERE (([CheckStatus] = @CheckStatus2) AND ([TicketStatus] = @TicketStatus))" 
                        
                        UpdateCommand="UPDATE [dt_TacvitityApply] SET [Title] = @Title, [ATime] = @ATime, [Place] = @Place, [AInTrodatction] = @AInTrodatction, [SuperVIPNum] = @SuperVIPNum, [VIPNum] = @VIPNum, [StandingNum] = @StandingNum, [CommonNum] = @CommonNum, [TicketStatus] = @TicketStatus WHERE [ActivityId] = @ActivityId">
                        <DeleteParameters>
                            <asp:Parameter Name="ActivityId" Type="String" />
                        </DeleteParameters>
                        <InsertParameters>
                            <asp:Parameter Name="ActivityId" Type="String" />
                            <asp:Parameter Name="Title" Type="String" />
                            <asp:Parameter Name="ATime" Type="DateTime" />
                            <asp:Parameter Name="Place" Type="String" />
                            <asp:Parameter Name="AInTrodatction" Type="String" />
                            <asp:Parameter Name="SuperVIPNum" Type="Int32" />
                            <asp:Parameter Name="VIPNum" Type="Int32" />
                            <asp:Parameter Name="StandingNum" Type="Int32" />
                            <asp:Parameter Name="CommonNum" Type="Int32" />
                            <asp:Parameter Name="TicketStatus" Type="String" />
                        </InsertParameters>
                        <SelectParameters>
                            <asp:Parameter DefaultValue="审核通过" Name="CheckStatus2" Type="String" />
                            <asp:ControlParameter ControlID="DropDownPubMode" Name="TicketStatus" 
                                PropertyName="SelectedValue" Type="String" />
                        </SelectParameters>
                        <UpdateParameters>
                            <asp:Parameter Name="Title" Type="String" />
                            <asp:Parameter Name="ATime" Type="DateTime" />
                            <asp:Parameter Name="Place" Type="String" />
                            <asp:Parameter Name="AInTrodatction" Type="String" />
                            <asp:Parameter Name="SuperVIPNum" Type="Int32" />
                            <asp:Parameter Name="VIPNum" Type="Int32" />
                            <asp:Parameter Name="StandingNum" Type="Int32" />
                            <asp:Parameter Name="CommonNum" Type="Int32" />
                            <asp:Parameter Name="TicketStatus" Type="String" />
                            <asp:Parameter Name="ActivityId" Type="String" />
                        </UpdateParameters>
                    </asp:SqlDataSource>
                    <br />
                </td>
            </tr>
        </table>
    </div>
                 
    </form>
</body>
</html>