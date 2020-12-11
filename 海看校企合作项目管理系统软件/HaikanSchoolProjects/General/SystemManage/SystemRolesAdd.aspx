<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SystemRolesAdd.aspx.cs" Inherits="HaikanSchoolProjects.General.SystemManage.SystemRolesAdd" %>

<!DOCTYPE>
<html>
<head>
    <title>添加角色</title>
    <%-- ReSharper disable once Html.Warning --%>
    <!--#include file="../head.htm" -->
    <script type="text/javascript">
        //列表当中的单个表格全选功能
        function CheckAllOne(i) {
            var trs = $("#tx_" + i).find('input');//获取所有的tr
            var checkBoxAll = document.getElementById("check" + i);

            if (checkBoxAll.checked === true) {
                trs.each(function (index, item) {
                    item.checked = true;
                });
            } else {
                trs.each(function (index, item) {
                    item.checked = false;
                });
            }
        }
    </script>
</head>

<body class="scroll-wrapper">
    <form id="form1" runat="server">
        <div class="layui-form-item" style="padding: 25px;">
            <fieldset class="layui-elem-field layui-field-title" style="margin-top: 20px;">
                <legend>角色添加/修改</legend>
            </fieldset>
            
            <div class="layui-form-item">
                <label class="layui-form-label" style="width: 110px"><span style="color: red">*</span>角色名称：</label>
                <div class="layui-input-block">
                    <asp:TextBox ID="tbRoleName" runat="server" placeholder="请输入角色名称" autocomplete="off" class="layui-input" />
                </div>
            </div>
            
            <div class="layui-form-item">
                <label class="layui-form-label" style="width: 110px">备注信息：</label>
                <div class="layui-input-block">
                    <asp:TextBox ID="tbRemarks" runat="server" placeholder="请输入备注信息" autocomplete="off" class="layui-input" />
                </div>
            </div>
            
            <div class="layui-form-item">
                <label class="layui-form-label" style="width: 110px">对应权限：</label>
                <div class="layui-input-block">
                    <label for="CheckBoxAll">全选</label>&nbsp;<input id="CheckBoxAll" onclick="CheckAll()" style="margin-top: 10px;" type="checkbox" />
                </div>
            </div>
            
            <div class="layui-form-item">
                <div class="layui-input-block">
                    <asp:Button ID="btnSubmit" runat="server" CssClass="layui-btn layui-btn-normal" OnClientClick="return judge();" Text="提交保存" OnClick="BtnSubmit_Click" />&nbsp;
                </div>
            </div>
            
            <table class="layui-table" lay-even lay-skin="nob" style="width: 100%;">
                <asp:Repeater ID="MyMenus" runat="server">
                    <ItemTemplate>
                        <tr>
                            <td>
                                <fieldset class="layui-elem-field layui-field-title" style="margin-top: 30px; margin-left: -16px;">
                                    <legend>
                                        <label for="check<%# Eval("ModuleID") %>"></label>
                                        <input type="checkbox" onclick="CheckAllOne(<%#Eval("ModuleID")%>)" id="check<%# Eval("ModuleID") %>" />
                                        <%#Eval("FullName") %>
                                    </legend>
                                </fieldset>
                            </td>
                        </tr>

                        <tr>
                            <td colspan="2" id="tx_<%#Eval("ModuleID")%>">
                                <asp:HiddenField ID="hfModuleID" runat="server" Value='<%#Eval("ModuleID") %>' />
                                <asp:CheckBoxList ID="MyCheckBoxList" runat="server" RepeatColumns="11" RepeatDirection="Horizontal" Width="100%" Height="20px">
                                </asp:CheckBoxList>
                            </td>
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>
            </table>
        </div>
    </form>
</body>
</html>