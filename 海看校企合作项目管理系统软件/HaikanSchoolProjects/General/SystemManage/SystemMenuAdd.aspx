<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SystemMenuAdd.aspx.cs" Inherits="HaikanSchoolProjects.General.SystemManage.MenuAdd" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml" lang="zh">
<head runat="server">
    <base target="_self" />
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>菜单添加</title>
    <%-- ReSharper disable once Html.Warning --%>
     <!--#include file="../head.htm" -->
    <script type="text/javascript">
        function FormCheck() {
            if (document.getElementById("txtFullName").value.replace(/[ ]/g, "") === "") {
                window.layer.msg("请输入模块名称！");
                return false;
            }
            if (document.getElementById("txtSortCode").value.replace(/[ ]/g, "") === "") {
                window.layer.msg("请输入显示顺序！");
                return false;
            }
            if (document.getElementById("txtLocation").value.replace(/[ ]/g, "") === "") {
                window.layer.msg("请输入访问地址！");
                return false;
            }
            if (document.getElementById("txtMenuRole").value.replace(/[ ]/g, "") === "") {
                window.layer.msg("请输入权限字符串！");
                return false;
            }
            // ReSharper disable once NotAllPathsReturnValue
        }
    </script>
</head>
<body class="scroll-wrapper">
    <div id="main_wrapper">
        <div class="container-fluid">
            <div class="layui-form-item" style="padding-top: 25px">
                <fieldset class="layui-elem-field layui-field-title" style="margin-top: 20px;">
                    <legend>菜单添加/修改</legend>
                </fieldset>
            </div>
            <form id="wizard_validation" runat="server">
                <div id="wizard_form" class="wizard clearfix">
                    <div class="layui-form-item">
                        <label class="layui-form-label" style="width: 110px">模块编码：</label>
                        <div class="layui-input-block">
                            <asp:TextBox ID="txtModuleID" runat="server" placeholder="请输入模块编码" autocomplete="off" class="layui-input" />
                        </div>
                    </div>
                    <div class="layui-form-item">
                        <label class="layui-form-label" style="width: 110px"><span style="color: red">*</span>模块名称：</label>
                        <div class="layui-input-block">
                            <asp:TextBox ID="txtFullName" runat="server" placeholder="请输入模块名称" autocomplete="off" class="layui-input" />
                        </div>
                    </div>
                    <div class="layui-form-item">
                        <label class="layui-form-label" style="width: 110px">模块分类：</label>
                        <div class="layui-input-block">
                            <asp:DropDownList ID="txtCategory" runat="server" AutoPostBack="true" class="layui-input">
                                <asp:ListItem>目录</asp:ListItem>
                                <asp:ListItem>页面</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                    </div>
                    <div class="layui-form-item">
                        <label class="layui-form-label" style="width: 110px">上级模块：</label>
                        <div class="layui-input-block">
                            <asp:DropDownList ID="DDPLastModel" runat="server" AutoPostBack="true" class="layui-input" />
                        </div>
                    </div>
                    <div class="layui-form-item">
                        <label class="layui-form-label" style="width: 110px">Icon图标：</label>
                        <div class="layui-input-block">
                            <asp:TextBox ID="txtIcon" runat="server" placeholder="请输入Icon图标" autocomplete="off" class="layui-input" />
                        </div>
                    </div>
                    <div class="layui-form-item">
                        <label class="layui-form-label" style="width: 110px">连接目标：</label>
                        <div class="layui-input-block">
                            <asp:DropDownList ID="ddlTarget" runat="server" AutoPostBack="true" class="layui-input">
                                <asp:ListItem Selected="True">iframe</asp:ListItem>
                                <asp:ListItem>click</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                    </div>
                    <div class="layui-form-item">
                        <label class="layui-form-label" style="width: 110px">级别层次：</label>
                        <div class="layui-input-block">
                            <asp:TextBox ID="txtLevel" runat="server" placeholder="请输入级别层次" autocomplete="off" class="layui-input" />
                        </div>
                    </div>
                    <div class="layui-form-item">
                        <label class="layui-form-label" style="width: 110px"><span style="color: red">*</span>显示顺序：</label>
                        <div class="layui-input-block">
                            <asp:TextBox ID="txtSortCode" runat="server" placeholder="请输入显示顺序(  注：数字越大越上层 )" autocomplete="off" class="layui-input" />
                        </div>
                    </div>
                    <div class="layui-form-item">
                        <label class="layui-form-label" style="width: 110px"><span style="color: red">*</span>访问地址：</label>
                        <div class="layui-input-block">
                            <asp:TextBox ID="txtLocation" runat="server" placeholder="请输入访问地址" autocomplete="off" class="layui-input" />
                        </div>
                    </div>
                    <div class="layui-form-item">
                        <label class="layui-form-label" style="width: 110px"><span style="color: red">*</span>权限字符串：</label>
                        <div class="layui-input-block">
                            <asp:TextBox ID="txtMenuRole" runat="server" placeholder="请输入权限字符串" autocomplete="off" class="layui-input" />
                        </div>
                    </div>
                    <div class="layui-form-item">
                        <label class="layui-form-label" style="width: 110px">说明：</label>
                        <div class="layui-input-block">
                            <asp:TextBox ID="txtRemark" runat="server" placeholder="请输入说明" autocomplete="off" class="layui-input" />
                        </div>
                    </div>
                </div>
                <div class="layui-form-item">
                    <label class="layui-form-label" style="width: 110px"></label>
                    <div class="layui-input-block">
                        <asp:Button ID="btnSubmit" runat="server" CssClass="layui-btn" Text="提  交" OnClick="BtnSubmit_Click" OnClientClick="return  FormCheck();" />&nbsp;&nbsp;
                    </div>
                </div>
            </form>
        </div>
    </div>
</body>
</html>