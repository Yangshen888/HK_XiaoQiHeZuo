<%@ Page Language="C#"  AutoEventWireup="true" CodeBehind="EnterpriseAdd.aspx.cs" Inherits="HaikanSchoolProjects.General.Enterprise.EnterpriseAdd" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html lang="zh">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>添加管理员</title>
    <%-- ReSharper disable once Html.Warning --%>
    <!--#include file="../head.htm" -->
    <script type="text/javascript">
        function check() {
            if ($("#txtTrueName").val() === "") {
                layer.msg("请输入账号！");
                return false;
            }
            if ($("#txtsrpwd").val() === "") {
                layer.msg("请输入密码！");
                return false;
            }
            return true;
        }
    </script>
    <style type="text/css">
        .laydate_body .laydate_table tr {
            height: 21px;
            line-height: 21px;
        }
    </style>
</head>
<body style="padding: 0 10px; padding-bottom: 10px; background: #fff;">
    <form id="form1" runat="server" class="layui-form">
        <div class="layui-form-item">
            <fieldset class="layui-elem-field layui-field-title" style="margin-top: 20px;">
            </fieldset>
            <div class="layui-form-item">
                <label class="layui-form-label" style="width: 110px">企业名称：</label>
                <div class="layui-input-inline" style="margin-top: 10px;">
                    <asp:TextBox ID="TextBox_QY" placeholder="请输入企业名称" runat="server" autocomplete="off" class="layui-input"></asp:TextBox>
                </div>
            </div>
            <div  class="layui-form-item"  id="Div1" <%=Gettre2()%>>
                <label class="layui-form-label" style="width: 110px" >企业状态</label>
                <div class="layui-input-inline" >
                    <asp:DropDownList ID="DropDownList1" runat="server">
                        <asp:ListItem>待审核</asp:ListItem>
                        <asp:ListItem>审核中</asp:ListItem>
                        <asp:ListItem>已通过</asp:ListItem>
                    </asp:DropDownList>
                 </div>
            </div>
            <div class="layui-form-item" runat="server" id="srpwd">
                <label class="layui-form-label" style="width: 110px">联系方式：</label>
                <div class="layui-input-inline">
                    <asp:TextBox ID="TextBox_LX" runat="server" placeholder="请输入联系方式" autocomplete="off" class="layui-input"></asp:TextBox>
                </div>
            </div>
            <div class="layui-form-item">
                <label class="layui-form-label" style="width: 110px">备注：</label>
                <div class="layui-input-inline">
                    <asp:TextBox ID="TextBox_Note" runat="server"  autocomplete="off" class="layui-input"></asp:TextBox>
                </div>
            </div>
            <div class="layui-form-item">
                <div class="layui-input-block">
                    <asp:Button ID="Button1" runat="server" OnClientClick="return check();" class="layui-btn" Text="确  定" OnClick="BtnSubmit_Click" />
                </div>
            </div>
        </div>
    </form>
<script type="text/javascript">
    $(function () {
        layui.use('laydate',
            function () {
                var laydate = layui.laydate;
                //执行一个laydate实例
                laydate.render({
                    elem: '#dockingtime',
                    type: 'date'
                    //指定元素
                });
            });
    })
</script>
</body>
</html>