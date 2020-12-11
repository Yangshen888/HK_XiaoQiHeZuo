<%@ Page Language="C#" EnableEventValidation="false" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="HaikanSchoolProjects.General.Login" %>

<!DOCTYPE html>
<html lang="zh">
<head>
    <title><%= SystemTitle %>-登录</title>
    <!--#include file="head.htm" -->
    <script type="text/javascript">
        // 防止被嵌套
        if (window !== top) {        
            top.location.href = location.href;
        }
        
        // 表单验证
        function FormCheck(e) {
            if (document.getElementById("TxtUserName").value.replace(/[ ]/g, "") === "") {
                layer.msg("请输入用户名！");
                return false;
            }
            if (document.getElementById("TxtUserPwd").value.replace(/[ ]/g, "") === "") {
                layer.msg("请输入密码！");
                return false;
            }
            if (document.getElementById("TxtYZM").value.replace(/[ ]/g, "") === "") {
                layer.msg("请输入验证码！");
                return false;
            }
            
            // 防止二次提交
            var x = noDouble(e);
            return x!==0;
        }
    </script>
</head>
<body onload="document.getElementById('TxtUserName').focus();" class="login_page">
<form id="form1" runat="server">
    <div class="login_header" style="font-family: 'Microsoft YaHei',sans-serif">
        <asp:Label ID="lblSystemTitle" runat="server" Text="" Style="font-size: 24px; color: #fff" />
    </div>
    <div class="login_register_form">
        <div class="form_wrapper animated-short" id="login_form">
            <h3 class="sepH_c" style="font-family: 'Microsoft YaHei',sans-serif;">
                <span>登录</span>
            </h3>
        <div class="input-group input-group-lg sepH_a">
                    <span class="input-group-addon">
                        <span class="icon_profile"></span>
                    </span>
                    <asp:TextBox ID="TxtUserName" runat="server" placeholder="用户名" class="form-control" />
                </div>
                <div class="input-group input-group-lg">
                    <span class="input-group-addon">
                        <span class="icon_key_alt"></span>
                    </span>
                    <asp:TextBox ID="TxtUserPwd" runat="server" TextMode="Password" placeholder="密码" class="form-control" />
                    <br/>
                </div>
                <asp:Panel ID="Panelyzm" runat="server">
                    <div class="input-group input-group-lg sepH_a" style="margin-top: 10px;">
                        <span class="input-group-addon">
                            <span class="el-icon-warning-sign"></span>
                        </span>
                        <asp:TextBox ID="TxtYZM" runat="server" placeholder="验证码" class="form-control" Style="width: 59%" MaxLength="4" />
                        <img style="width: 39%; vertical-align: bottom; margin-bottom: 1px; cursor: pointer;" alt="点击刷新" onclick="const time = new Date().getTime();this.src = this.src + '?' + time;"/>
                    </div>
                </asp:Panel>
                <div style="margin-top: 10px; margin-bottom: 15px;">
                    <asp:CheckBox ClientIDMode="Static" ID="chkRemembered" OnCheckedChanged="chkRemembered_OnCheckedChanged" runat="server"/>&nbsp;<label for="chkRemembered">记住密码</label>
                </div>
                <div style="font-family: 'Microsoft YaHei',serif" class="form-group sepH_c">
                    <asp:Button ID="btnLogin" runat="server" Text="立即登录" CssClass="btn btn-lg btn-primary btn-block" OnClick="btnLogin_Click" OnClientClick="return FormCheck(this);"/>
                </div>
        </div>
    </div>
</form>
</body>
</html>