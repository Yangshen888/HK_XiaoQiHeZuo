<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PersonaInformation.aspx.cs" Inherits="HaikanSchoolProjects.General.Personal.PersonalInformation" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <%-- ReSharper disable once Html.Warning --%>
    <!--#include file="../head.htm" -->
</head>
<body style="padding: 0 10px; padding-bottom: 10px; background: #fff;">
    <form id="form1" runat="server" class="layui-form">
        <div class="layui-form-item">
            <fieldset class="layui-elem-field layui-field-title" style="margin-top: 20px;">
                <legend>个人信息</legend>
            </fieldset>
            <div class="layui-form-item">
                <label class="layui-form-label" style="width: 110px">角色：</label>
                <div class="layui-input-inline">
                    <asp:TextBox ID="TextBoxJS" ReadOnly="True" runat="server"  autocomplete="off" class="layui-input"></asp:TextBox>
                </div>
            </div>
            <div class="layui-form-item">
                <label class="layui-form-label" style="width: 110px">用户名：</label>
                <div class="layui-input-inline">
                    <asp:TextBox ID="TextBoxName"  ReadOnly="True" runat="server" autocomplete="off" class="layui-input"></asp:TextBox>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
