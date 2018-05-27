<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ActivityReport.aspx.cs" Inherits="DtCms.Web.Admin.Activity.ActivityReport" %>
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
            <br />
            <div>
                <asp:Label ID="Label1" runat="server" Text="年份:"></asp:Label>
                <asp:DropDownList ID="DropDownList1" runat="server">
                    <asp:ListItem>2015</asp:ListItem>
                    <asp:ListItem>2016</asp:ListItem>
                    <asp:ListItem>2017</asp:ListItem>
                    <asp:ListItem>2018</asp:ListItem>
                </asp:DropDownList>
                &nbsp;&nbsp;&nbsp;
                <asp:Button ID="ButtonCheck" runat="server" Text="查询" />
            </div>
                <div align="center">
                    <img alt="" class="style1" src="../Images/Pie.jpg" />
                </div>

        <br />
    </asp:Panel>
        
    
    </div>
    
                    <div class="clear"></div>

    </form>
</body>
</html>
