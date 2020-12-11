<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ProjectAdd.aspx.cs" Inherits="HaikanSchoolProjects.General.Project.ProjectAdd" %>

<!DOCTYPE>
<html lang="zh">
<head>
    <title>添加管理员</title>
    <%-- ReSharper disable once Html.Warning --%>
    <!--#include file="../head.htm" -->
    <script type="text/javascript">
        function check() {
            if ($("#txtTrueName").val() === "") {
                layer.msg("请输入项目名称！");
                return false;
            }
            if ($("#person").val() === "") {
                layer.msg("请输入项目负责人！");
                return false;
            }
            return true;
        }
 
        $(function () {
            layui.use('laydate',
                function () {
                    var laydate = layui.laydate;
                    laydate.render({
                        elem: '#time'
                    });
                });
        });
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
                <label class="layui-form-label" style="width: 110px">所属企业：</label>
                <div class="layui-input-inline" style="margin-top: 10px;">
                    <asp:DropDownList ID="DropDownList_qy" runat="server" AutoPostBack="True" Height="16px" Width="112px"></asp:DropDownList>
                    <span style="color: red;">注:只能添加已经审核通过的企业</span>
                    </div>
            </div>
            <div class="layui-form-item">
                <label class="layui-form-label" style="width: 110px">项目名称：</label>
                <div class="layui-input-inline">
                    <asp:TextBox ID="txtTrueName" runat="server" placeholder="请输入项目名称" autocomplete="off" class="layui-input"></asp:TextBox>
                </div>
            </div>
            <div class="layui-form-item" runat="server" id="srpwd">
                <label class="layui-form-label" style="width: 110px">项目负责人：</label>
                <div class="layui-input-inline">
                    <asp:TextBox ID="person"  class="layui-input" runat="server"></asp:TextBox>
                 </div>
            </div>
            <div class="layui-form-item" runat="server" id="Div1">
                <label class="layui-form-label" style="width: 110px">项目状态：</label>
                <div class="layui-input-inline">
                    <asp:DropDownList ID="DropDownList1" runat="server">
                        <asp:ListItem>开发中</asp:ListItem>
                        <asp:ListItem>维护中</asp:ListItem>
                        <asp:ListItem>测试中</asp:ListItem>
                    </asp:DropDownList>
                </div>
            </div>
            <div class="layui-form-item" >
                <label class="layui-form-label" style="width: 110px">备注：</label>
                <div class="layui-input-inline">
                    <asp:TextBox ID="txty" runat="server"  autocomplete="off" class="layui-input"></asp:TextBox>
                </div>
            </div>
            <div class="layui-form-item">
                <div class="layui-input-block">
                    <asp:Button ID="Button1" runat="server" OnClientClick="return check();" class="layui-btn" Text="确  定" OnClick="BtnSubmit_Click" />
                </div>
            </div>
        </div>
    </form>
</body>
</html>
 