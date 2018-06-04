<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="report.aspx.cs" Inherits="DtCms.Web.Admin.Activity.report" %>
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
            width: 700px;
            height: 300px;
        }
    </style>
</head>
<body style="padding:10px;">
    
    <form id="form1" runat="server">
    
    <div class="navigation"><b>您当前的位置：首页 &gt; 活动管理 &gt; 预算分析</b></div>
    <div class="spClear"></div>
    <div>
    
    
        <asp:Panel ID="PanelPre" runat="server">
        <br />
            <br />
            <div>
                &nbsp;&nbsp;&nbsp;
                </div>
                <div align="center">
    
        <asp:Chart ID="Chart1" runat="server" DataSourceID="SqlDataSource3">
            <Series>
                <asp:Series ChartType="Line" Name="Series1" XValueMember="Title" 
                    YValueMembers="Budget">
                </asp:Series>
            </Series>
            <ChartAreas>
                <asp:ChartArea Name="ChartArea1">
                </asp:ChartArea>
            </ChartAreas>
        </asp:Chart>
        <asp:SqlDataSource ID="SqlDataSource3" runat="server" 
            ConnectionString="<%$ ConnectionStrings:DtCmsdbConnectionAudit %>" 
            
                        
                        SelectCommand="SELECT [Budget], [ATime], [Title] FROM [dt_TacvitityApply] WHERE ([CheckStatus] = @CheckStatus) ORDER BY [ATime]">
            <SelectParameters>
                <asp:Parameter DefaultValue="审核通过" Name="CheckStatus" Type="String" />
            </SelectParameters>
        </asp:SqlDataSource>
    
    </div>

        <br />
    </asp:Panel>
        
    
    </div>
    
                    <div class="clear"></div>

    </form>
</body>
</html>

