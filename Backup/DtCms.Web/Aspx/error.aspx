<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="error.aspx.cs" Inherits="DtCms.Web.error" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
<title>出错啦，当前页面可能不存在或已被删除！</title>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<style type="text/css">

body{text-align:center;}
.err{margin:50px auto auto auto;text-align:left;padding:10px 0 20px 80px;background:url(../images/error.jpg) no-repeat 20px center;width:350px;min-height:80px;_height:80px;line-height:24px;font-size:14px;font-family:"宋体"; border:1px solid #ccc;}
.err b{font-family:"微软雅黑";line-height:35px;}

</style>
<script language="javascript" type="text/jscript">
	setTimeout(startaction,3000);
	function startaction()
	{
		history.back();
	}
</script>
</head>
<body>
<div class="err">
  <b>出错啦，当前页面可能不存在或已被删除！</b><br />
  3秒钟后自动返回上一页。请稍等……<br />
  如果长时间没有反应，将手动点击<a href="javascript:history.back();">返回上一页</a>。
</div>
</body>
</html>
