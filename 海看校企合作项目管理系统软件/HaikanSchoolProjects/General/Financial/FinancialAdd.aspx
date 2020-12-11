<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FinancialAdd.aspx.cs" Inherits="HaikanSchoolProjects.General.Financial.FinancialAdd" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html lang="zh">
<head>
    <title>添加管理员</title>
    <%-- ReSharper disable once Html.Warning --%>
    <!--#include file="../head.htm" -->
    <script type="text/javascript">
        $(function () {
            layui.use('laydate',
                function () {
                    var laydate = layui.laydate;
                    laydate.render({
                        elem: '#time'
                    });
                });
        });
        function check() {
            if ($("#txtTrueMoney").val() === "") {
                layer.msg("请输入金额！");
                return false;
            }
            if ($("#FZperson").val() === "") {
                layer.msg("请输入账目负责人！");
                return false;
            }
            if ($("#time").val() === "") {
                layer.msg("请选择时间！");
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
    <form id="form2" runat="server" class="layui-form">
        <div class="layui-form-item">
            <fieldset class="layui-elem-field layui-field-title" style="margin-top: 20px;">
            </fieldset>
            <div class="layui-form-item">
                <label class="layui-form-label" style="width: 110px">请选择企业：</label>
                <div class="layui-input-inline" style="margin-top: 10px;">
                    <asp:DropDownList ID="DropDownList_qy" runat="server" AutoPostBack="True" Height="16px" Width="112px">
                    </asp:DropDownList>
                    <span style="color: red;">注:只能添加已经审核通过的企业</span>
                </div>
            </div> <div class="layui-form-item">
                <label class="layui-form-label" style="width: 110px">请选择项目：</label>
                <div class="layui-input-inline" style="margin-top: 10px;">
                    <asp:DropDownList ID="DropDownListXM" runat="server" AutoPostBack="True" Height="16px" Width="112px">
                    </asp:DropDownList>
                </div>
            </div>
            <div class="layui-form-item">
                <label class="layui-form-label" style="width: 110px">请选择：</label>
                <div class="layui-input-inline" style="margin-top: 10px;">
                    <asp:DropDownList ID="DropDownList2" runat="server" AutoPostBack="True" Height="16px" Width="112px">
                        <asp:ListItem>付款</asp:ListItem>
                        <asp:ListItem>收款</asp:ListItem>
                    </asp:DropDownList>
                </div>
            </div>
            <div class="layui-form-item">
                <label class="layui-form-label" style="width: 110px">金额：</label>
                <div class="layui-input-inline">
                    <asp:TextBox ID="txtTrueMoney" runat="server" placeholder="请输入金额" autocomplete="off" class="layui-input"></asp:TextBox>
                </div>
            </div>
            <div class="layui-form-item" runat="server"  >
                <label class="layui-form-label" style="width: 110px">负责人：</label>
                <div class="layui-input-inline">
                    <asp:TextBox ID="FZperson"  class="layui-input" runat="server"></asp:TextBox>
                 </div>
            </div>
            <div class="layui-form-item" runat="server"  >
                <label class="layui-form-label" style="width: 110px">成交时间：</label>
                <div class="layui-input-inline">
                    <asp:TextBox ID="time"  class="layui-input" runat="server"></asp:TextBox>
                </div>
            </div>
            <div class="layui-form-item" >
                <label class="layui-form-label" style="width: 110px">备注：</label>
                <div class="layui-input-inline">
                    <asp:TextBox ID="note" runat="server"  autocomplete="off" class="layui-input"></asp:TextBox>
                </div>
            </div>
            <div class="layui-form-item">
                <div class="layui-input-block">
                    <asp:Button ID="ButSubmit" runat="server" OnClientClick="return check();" class="layui-btn" Text="确  定" OnClick="ButSubmit_Click"/>
                </div>
            </div>
        </div>
    </form>
</body>
</html>