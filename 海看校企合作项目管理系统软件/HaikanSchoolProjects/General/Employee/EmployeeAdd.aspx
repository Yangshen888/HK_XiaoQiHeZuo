<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EmployeeAdd.aspx.cs" Inherits="HaikanSchoolProjects.General.Employee.EmployeeAdd" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html lang="zh">
<head>
    <title>添加/修改人员</title>
    <%-- ReSharper disable once Html.Warning --%>
    <!--#include file="../head.htm" -->
    <script type="text/javascript">
        function check() {
            if ($("#TextBoxName").val() === "") {
                layer.msg("请输入姓名！");
                return false;
            }
            if ($("#person_time").val() === "") {
                layer.msg("请输入工作时长！");
                return false;
            }
            return true;
        }
    </script>
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
    </script>
    <style type="text/css">
        .laydate_body .laydate_table tr {
            height: 21px;
            line-height: 21px;
        }
    </style>
</head>
<body style="padding: 0 10px; padding-bottom: 10px; background: #fff;">
    <form id="form1" runat="server">
        <div class="layui-form-item">
            <fieldset class="layui-elem-field layui-field-title" style="margin-top: 20px;">
            </fieldset>
            <div class="layui-form-item">
                <label class="layui-form-label" style="width: 110px">所属企业：</label>
                <div class="layui-input-inline" style="margin-top: 10px;">
                    <asp:DropDownList ID="DropDownList_qy" class="form-control" runat="server" AutoPostBack="True" Height="40px" Width="109px" OnSelectedIndexChanged="DropDownList_qy_SelectedIndexChanged"></asp:DropDownList>
                </div>
                <span style="color: red;">注:只能添加已经审核通过的企业</span>
            </div>
            <div class="layui-form-item">
                <label class="layui-form-label" style="width: 110px">所属项目：</label>
                <div class="layui-input-inline">
                    <asp:DropDownList ID="DropDownListXM" class="form-control" runat="server"  Height="40px" Width="109px"></asp:DropDownList>
                </div>
            </div>
            <div class="layui-form-item">
                <label class="layui-form-label" style="width: 110px">姓名：</label>
                <div class="layui-input-inline">
                    <asp:TextBox ID="TextBoxName" runat="server" autocomplete="off" class="layui-input"></asp:TextBox>
                </div>
            </div>
            <div class="layui-form-item" runat="server" id="srpwd">
                <label class="layui-form-label" style="width: 110px">工作时长：</label>
                <div class="layui-input-inline">
                    <asp:TextBox ID="person_time" class="layui-input" runat="server"></asp:TextBox>
                </div>
            </div>
            <div class="layui-form-item">
                <label class="layui-form-label" style="width: 110px">备注：</label>
                <div class="layui-input-inline">
                    <asp:TextBox ID="txty" runat="server" autocomplete="off" class="layui-input"></asp:TextBox>
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


