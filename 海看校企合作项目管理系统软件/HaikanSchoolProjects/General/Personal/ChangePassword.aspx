<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ChangePassword.aspx.cs" Inherits="HaikanSchoolProjects.General.Personal.ChangePassword" %>

<!DOCTYPE >
<html lang="zh">
<head>
    <title>修改密码</title>
    <%-- ReSharper disable once Html.Warning --%>
   <!--#include file="../head.htm" -->
</head>
<body class="side_menu_active side_menu_expanded">
    <form id="form1" runat="server">
        <div id="main_wrapper">
            <div class="layui-form-item" style="padding: 25px;">
                <fieldset class="layui-elem-field layui-field-title">
                    <legend>修改密码</legend></fieldset>
                    <div class="layui-form-item">
                        <label class="layui-form-label" style="width:110px">
                            原密码：
                        </label>
                        <div class="layui-input-inline">
                            <asp:TextBox ID="txtPassword" class="layui-input" TextMode="Password" runat="server" placeholder="请输入原密码"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvAsterisk" runat="server" ControlToValidate="txtPassword" ErrorMessage="*"
                                ForeColor="Red" ValidationGroup="sxp" Display="Dynamic"></asp:RequiredFieldValidator>
                        </div>
                    </div>
                    <div class="layui-form-item">
                        <label class="layui-form-label" style="width:110px">
                            新密码：
                        </label>
                        <div class="layui-input-inline">
                            <asp:TextBox ID="txtPwd" class="layui-input" TextMode="Password" runat="server" placeholder="请输入新密码"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvAsterisk2" runat="server" ControlToValidate="txtPwd" ErrorMessage="*"
                                ForeColor="Red" ValidationGroup="sxp" Display="Dynamic"></asp:RequiredFieldValidator>
                        </div>
                    </div>
                    <div class="layui-form-item">
                        <label class="layui-form-label" style="width:110px">
                            确定密码：
                        </label>
                        <div class="layui-input-inline">
                            <asp:TextBox ID="txtRpwd" class="layui-input" TextMode="Password" runat="server" placeholder="请确定密码"></asp:TextBox>
                        </div>
                    </div>
                    <div class="layui-form-item">
                        <div class="layui-input-block">
                            <asp:Button ID="btnConfirm" CssClass="layui-btn layui-btn-normal" runat="server" Text="确定" OnClick="btnConfirm_Click"
                                ValidationGroup="sxp" />
                        </div>
                    </div>
            </div>
        </div>
    </form>
</body>
</html>