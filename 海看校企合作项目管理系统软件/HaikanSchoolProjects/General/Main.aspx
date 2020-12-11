<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Main.aspx.cs" Inherits="HaikanSchoolProjects.General.Main" %>
<%@ Register Src="~/General/HeadAndMenu.ascx" TagPrefix="ucl" TagName="HeadAndMenu" %>

<!DOCTYPE HTML>
<html lang="zh">
<head>
    <title><%=Title %></title>
    <%-- ReSharper disable once Html.Warning --%>
    <!--#include file="head.htm" -->
</head>

<body class="side_menu_active side_menu_expanded">
<div id="page_wrapper">
    <form id="form1" runat="server" class="layui-form-pane">
        <ucl:HeadAndMenu runat="server" ID="HeadAndMenu" />
        <img src="../libs/wa.jpg" width="1920" />
    </form>
</div>
</body>
</html>