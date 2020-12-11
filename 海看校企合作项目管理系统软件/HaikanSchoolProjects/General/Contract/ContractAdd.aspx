<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ContractAdd.aspx.cs" Inherits="HaikanSchoolProjects.General.Contract.ContractAdd" %>
<!DOCTYPE>
<html lang="zh">
<head>
    <title>添加合同</title>
    <%-- ReSharper disable once Html.Warning --%>
    <!--#include file="../head.htm" -->
    <script type="text/javascript">
        function check() {
            if ($("#txtTrueName").val() === "") {
                layer.msg("请输入合同名称！");
                return false;
            }
            if ($("#txtj").val() === "") {
                layer.msg("请甲方签订人！");
                return false;
            }
            if ($("#txty").val() === "") {
                layer.msg("请乙方签订人！");
                return false;
            }
            if ($("#time").val() === "") {
                layer.msg("请选择日期！");
                return false;
            }
            if ($("#time2").val() === "") {
                layer.msg("请选择日期！");
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
        $(function () {
            layui.use('laydate',
                function () {
                    var laydate = layui.laydate;
                    laydate.render({
                        elem: '#time2'
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
                <label class="layui-form-label" style="width: 110px">合同名称：</label>
                <div class="layui-input-inline">
                    <asp:TextBox ID="txtTrueName" runat="server" placeholder="请输入合同名称" autocomplete="off" class="layui-input"></asp:TextBox>
                </div>
            </div>
            <div class="layui-form-item" runat="server" id="srpwd">
                <label class="layui-form-label" style="width: 110px">签订日期：</label>
                <div class="layui-input-inline">
                    <asp:TextBox ID="time" class="layui-input" runat="server"></asp:TextBox>
                </div>
            </div>
            <div class="layui-form-item" runat="server" id="Div1">
                <label class="layui-form-label" style="width: 110px">到期时间：</label>
                <div class="layui-input-inline">
                    <asp:TextBox ID="time2" class="layui-input" runat="server"></asp:TextBox>
                </div>
            </div>
            <div class="layui-form-item" runat="server">
                <label class="layui-form-label" style="width: 110px">金额：</label>
                <div class="layui-input-inline">
                    <asp:TextBox ID="TextBox_JE" runat="server" placeholder="请输入金额" autocomplete="off" class="layui-input"></asp:TextBox>
                </div>
            </div>
            <div class="layui-form-item" runat="server">
                <label class="layui-form-label" style="width: 110px">甲方签订人：</label>
                <div class="layui-input-inline">
                    <asp:TextBox ID="txtj" runat="server" placeholder="请确认甲方签订人" autocomplete="off" class="layui-input"></asp:TextBox>
                </div>
            </div>
            <div class="layui-form-item">
                <label class="layui-form-label" style="width: 110px">乙方签订人：</label>
                <div class="layui-input-inline">
                    <asp:TextBox ID="txty" runat="server" placeholder="请输入乙方签订人" autocomplete="off" class="layui-input"></asp:TextBox>
                </div>
            </div>
            <div class="layui-form-item">
                <label class="layui-form-label" style="width: 110px">备注：</label>
                <div class="layui-input-inline">
                    <asp:TextBox ID="txtb" runat="server" placeholder="备注" autocomplete="off" class="layui-input"></asp:TextBox>
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