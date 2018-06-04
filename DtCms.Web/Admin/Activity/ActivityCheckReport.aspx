<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ActivityCheckReport.aspx.cs" Inherits="DtCms.Web.Admin.Activity.ActivityCheckReport" %>

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
    
    <div class="navigation"><b>您当前的位置：首页 &gt; 活动管理 &gt; 活动报告</b></div>
    <div class="spClear"></div>
    <div>
    
    
        <asp:Panel ID="PanelPre" runat="server">
        <br />
           年份： <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True">
                <asp:ListItem>2018-12-31</asp:ListItem>
                <asp:ListItem>2017-12-31</asp:ListItem>
            </asp:DropDownList>
            <br />
            <div>
                &nbsp;&nbsp;&nbsp;
                </div>
                <div align="center">
                   
                    <asp:Chart ID="Chart1" runat="server" Width="900px">
                    <Legends>
                                <asp:Legend BackColor="Transparent" Alignment="Center" Font="Trebuchet MS, 8.25pt, style=Bold"
                                    IsTextAutoFit="False" Name="Default" LegendStyle="Column">
                                </asp:Legend>
                            </Legends>
                        <Series>
                            <asp:Series ChartType="Pie" Name="Series1">
                            </asp:Series>
                        </Series>
                        <ChartAreas>
                            <asp:ChartArea Name="ChartArea1">
                            <Area3DStyle Rotation="0" />
                                    <AxisY LineColor="64, 64, 64, 64">
                                        <LabelStyle Font="Trebuchet MS, 8.25pt, style=Bold" />
                                        <MajorGrid LineColor="64, 64, 64, 64" />
                                    </AxisY>
                                    <AxisX LineColor="64, 64, 64, 64">
                                        <LabelStyle Font="Trebuchet MS, 8.25pt, style=Bold" />
                                        <MajorGrid LineColor="64, 64, 64, 64" />
                                    </AxisX>
                            </asp:ChartArea>
                        </ChartAreas>
                    </asp:Chart>
                   
                </div>

        <br />
    </asp:Panel>
        
    
    </div>
    
                    <div class="clear"></div>

    </form>
</body>
</html>
