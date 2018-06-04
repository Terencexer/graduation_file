<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ActivityAudit.aspx.cs" Inherits="DtCms.Web.Admin.Activity.ActivityAudit" %>
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
        
        $(function() {
            $(".msgtable tr:nth-child(odd)").addClass("tr_bg"); //隔行变色
            $(".msgtable tr").hover(
			    function() {
			        $(this).addClass("tr_hover_col");
			    },
			    function() {
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
        .style2
        {
            font-size: xx-large;
            height: 35px;
        }
        .style3
        {
            width: 100%;
        }
        .style4
        {
            width: 377px;
        }
        .style5
        {
            width: 216px;
        }
    </style>
</head>
<body style="padding:10px;">
    
    <form id="form1" runat="server">
    
    <div class="navigation"><b>您当前的位置：首页 &gt; 活动管理 &gt; 活动审批</b></div>
    <div class="spClear"></div>
    <table class="style1">
        <tr>
            <td align="center" class="style2" >
                活动审批 </td>
        </tr>
        <tr>
            <td align="center">
                审核状态：<asp:DropDownList 
                    ID="DropDownListMode" runat="server" AutoPostBack="True">
                    <asp:ListItem>审核通过</asp:ListItem>
                    <asp:ListItem>退回修改</asp:ListItem>
                    <asp:ListItem>再次提交</asp:ListItem>
                    <asp:ListItem>不批准</asp:ListItem>
                    <asp:ListItem>未审核</asp:ListItem>
                </asp:DropDownList>
                <asp:GridView ID="GridView1" runat="server" AllowPaging="True" 
                    AllowSorting="True" AutoGenerateColumns="False" BackColor="White" 
                    BorderColor="#999999" BorderStyle="None" BorderWidth="1px" CellPadding="3" 
                    DataSourceID="SqlDataSource1" GridLines="Vertical" Height="159px" 
                    onrowdatabound="GridView1_RowDataBound" Width="1000px" 
                    onrowcommand="GridView1_RowCommand">
                    <AlternatingRowStyle BackColor="Gainsboro" />
                    <Columns>
                        <asp:BoundField DataField="ActivityId" HeaderText="活动编号" 
                            SortExpression="ActivityId" />
                        <asp:BoundField DataField="Title" HeaderText="活动主题" />
                        <asp:TemplateField HeaderText="申请人" SortExpression="Applicant">
                            <EditItemTemplate>
                                <asp:TextBox  ID="TextBoxApplicant" runat="server" Text='<%# Bind("Applicant") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="LabelApplicant" runat="server" Text='<%# Bind("Applicant") %>'></asp:Label>
                            </ItemTemplate>
                           
                            <HeaderStyle Width="50px" />
                           
                        </asp:TemplateField>
                        <asp:BoundField DataField="Budget" HeaderText="活动预算" />
                        <asp:BoundField DataField="AConten" HeaderText="活动策划" />
                        <asp:TemplateField HeaderText="活动时间" SortExpression="ATime">
                            <EditItemTemplate>
                                <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("ATime") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="LabelTime" runat="server" Text='<%# Bind("ATime") %>'></asp:Label>
                            </ItemTemplate>
                            <HeaderStyle Width="150px" />
                        </asp:TemplateField>
                        <asp:BoundField DataField="Place" HeaderText="活动地点" SortExpression="Place" />
                        <asp:TemplateField HeaderText="审核状态" SortExpression="CheckStatus">
                            <EditItemTemplate>
                                <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("CheckStatus") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="LabelAudit" runat="server" Text='<%# Bind("CheckStatus") %>'></asp:Label>
                            </ItemTemplate>
                            <HeaderStyle Width="80px" />
                        </asp:TemplateField>
                       
                        <asp:TemplateField HeaderText="审核" ShowHeader="False">
                            <ItemTemplate>
                                <asp:Button ID="ButtonAudit" runat="server" 
                                    CommandArgument="<%#Container.DataItemIndex%>" CommandName="ButtonAudit" 
                                    Text="审核" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="审核2" ShowHeader="False">
                            <ItemTemplate>
                                <asp:Button ID="ButtonBack" runat="server" 
                                    CommandArgument="<%#Container.DataItemIndex%>" CommandName="ButtonBack" 
                                    Text="退回" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="审核3" ShowHeader="False">
                            <ItemTemplate>
                                <asp:Button ID="ButtonUncheck" runat="server" 
                                    CommandArgument="<%#Container.DataItemIndex%>" CommandName="ButtonUncheck" 
                                    Text="不批准" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="编辑" ShowHeader="False">
                            <ItemTemplate>
                                <asp:Button ID="ButtonEdit" runat="server" 
                                    CommandArgument="<%#Container.DataItemIndex%>" CommandName="ButtonEdit" 
                                    Text="修改" />
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                    <FooterStyle BackColor="#CCCCCC" ForeColor="Black" />
                    <HeaderStyle BackColor="#000084" Font-Bold="True" ForeColor="White" />
                    <PagerSettings FirstPageText="首页" LastPageText="尾页" 
                        Mode="NextPreviousFirstLast" NextPageText="下一页" PreviousPageText="上一页" />
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
                    
                    SelectCommand="SELECT [ActivityId], [Title], [Applicant], [Budget], [AConten], [ATime], [Place], [CheckStatus] FROM [dt_TacvitityApply] WHERE ([CheckStatus] = @CheckStatus)">
                    <SelectParameters>
                        <asp:ControlParameter ControlID="DropDownListMode" Name="CheckStatus" 
                            PropertyName="SelectedValue" Type="String" />
                    </SelectParameters>
                </asp:SqlDataSource>
                
                <asp:HiddenField ID="HiddenFieldEdit" runat="server" />
                
            </td>
        </tr>
    </table>

    
     <asp:Panel ID="PanelEdit" runat="server" Height="414px" Visible="False" 
        Width="880px">
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
                                发票情况：</td>
                            <td class="style27" bgcolor="White">
                                <asp:TextBox ID="TextBoxTicketIssue" runat="server" ReadOnly="true" BackColor="Silver"></asp:TextBox>
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
                    <asp:Button ID="ButtonEditSub" runat="server" Text="确认修改" 
                        onclick="ButtonEditSub_Click" /> &nbsp; &nbsp;
                    <asp:Button ID="ButtonReturn" runat="server" Text="返回" Height="23px" 
                        Width="81px" onclick="ButtonReturn_Click" />
                    </div>
                
                
                </div>


                    <div class="clear"></div>
				
			</div>
 
                </asp:Panel>
    <asp:Panel ID="PanelBack" runat="server">
        <table class="style3" style="border: thin solid #000000" width="700px">
            <tr>
                <td align="center" colspan="2" 
                    
                    style="border: thin solid #000000; font-size: xx-large; font-family: 黑体; text-align: center" 
                    width="600px">
                    退回提供修改建议</td>
            </tr>
            <tr>
                <td class="style5" style="border: thin solid #000000" width="600px">
                    修改意见：</td>
                <td width="600px">
                    <asp:TextBox ID="TextBoxSuggestion" runat="server" Height="131px" 
                        maxlength="3000" Width="593px"></asp:TextBox>
                </td>
            </tr>
        </table>
        <div>
        <asp:Button ID="ButtonBack" runat="server" Text="确定" onclick="ButtonBack_Click" 
                        /> &nbsp; &nbsp;
                    <asp:Button ID="ButtonBackCancel" runat="server" Text="返回" Height="23px" 
                        Width="81px" onclick="ButtonBackCancel_Click" />
            <asp:HiddenField ID="HiddenFieldBack" runat="server" />
        </div>
    </asp:Panel>
    </form>
</body>
</html>
