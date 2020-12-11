<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SystemSetting.aspx.cs" Inherits="HaikanSchoolProjects.General.SystemManage.SystemSetting" %>

<%@ Register Src="~/General/HeadAndMenu.ascx" TagPrefix="uc1" TagName="HeadAndMenu" %>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>系统参数设置</title>
    <%-- ReSharper disable once Html.Warning --%>
    <!--#include file="../head.htm" -->
    <script type="text/javascript">
        function FormCheck() {
            if (document.getElementById("TextBox1").value.replace(/[ ]/g, "") === "") {
                layer.msg("请输入邮箱地址！");
                return false;
            }
            var objName = document.getElementById("TextBox1").value.replace(/[ ]/g, "");
            var pattern = /^([.a-zA-Z0-9_-])+@([a-zA-Z0-9_-])+(\.[a-zA-Z0-9_-])+/;
            if (!pattern.test(objName)) {
                layer.msg("请输入正确的邮箱地址。");
                return false;
            }
            if (document.getElementById("TextBox2").value.replace(/[ ]/g, "") === "") {
                layer.msg("请输入smtp服务器名称！");
                return false;
            }
            if (document.getElementById("TextBox3").value.replace(/[ ]/g, "") === "") {
                layer.msg("请输入发送人邮箱登录名！");
                return false;
            }
            if (document.getElementById("TextBox4").value.replace(/[ ]/g, "") === "") {
                layer.msg("请输入发送人邮箱密码(如果是QQ邮箱则输入授权码)！");
                return false;
            }
            return false;
        }
        //注意：选项卡 依赖 element 模块，否则无法进行功能性操作
        layui.use('element', function () {
            //…
        });
    </script>
</head>
<body class="side_menu_active side_menu_expanded">
    <div id="page_wrapper">
        <form id="form1" runat="server">
            <uc1:HeadAndMenu runat="server" ID="HeadAndMenu" />

             <div id="main_wrapper">
                <div id="mymain">
                    <div class="layui-form-item" style="padding-top: 25px;">
                        <fieldset class="layui-elem-field layui-field-title">
                            <legend>系统参数设置</legend>
                        </fieldset>
                    </div>
 
                    <div id="wizard_validation">
                        <div id="wizard_form" class="wizard clearfix">
                            <div class="layui-form-item">
                                <label class="layui-form-label" style="width: 110px;">系统名称：</label>
                                <div class="layui-input-block">
                                    <asp:TextBox ID="txtSystemName" runat="server" placeholder="请输入系统名称" autocomplete="off" class="layui-input" />
                                    <asp:RequiredFieldValidator ID="RFVSystemName" runat="server" ControlToValidate="txtSystemName" Display="Dynamic" ErrorMessage="系统名称必须要填写！" Style="font-size: 12px; color: red;" />
                                </div>
                            </div>
                            <div class="layui-form-item">
                                <label class="layui-form-label" style="width: 110px;">邮箱地址：</label>
                                <div class="layui-input-block">
                                    <asp:TextBox ID="TextBox1" runat="server" placeholder="请输入发送人邮箱地址" autocomplete="off" class="layui-input" />(邮箱需开启smtp服务)
                                </div>
                            </div>
                            <div class="layui-form-item">
                                <label class="layui-form-label" style="width: 110px;">服务器：</label>
                                <div class="layui-input-block">
                                    <asp:TextBox ID="TextBox2" runat="server" placeholder="请输入smtp服务器名称" autocomplete="off" class="layui-input" />(格式例如：smtp.qq.com ; smtp.163.com)
                                </div>
                            </div>

                            <div class="layui-form-item">
                                <label class="layui-form-label" style="width: 110px;">邮箱登录名：</label>
                                <div class="layui-input-block">
                                    <asp:TextBox ID="TextBox3" runat="server" placeholder="请输入发送人登录名" autocomplete="off" class="layui-input" />
                                </div>
                            </div>
                            <div class="layui-form-item">
                                <label class="layui-form-label" style="width: 110px;">邮箱密码：</label>
                                <div class="layui-input-block">
                                    <asp:TextBox ID="TextBox4" runat="server" placeholder="请输入发送人密码" autocomplete="off" class="layui-input" />(如果是QQ邮箱则输入授权码)
                                </div>
                            </div>
                            <div class="layui-form-item">
                                <label class="layui-form-label" style="width: 110px;">附件上传：</label>
                                <div class="layui-input-block">
                                    <div>
                                        <button type="button" class="layui-btn layui-btn-normal" id="testList">选择多文件</button>
                                        <div class="layui-upload-list">
                                            <table class="layui-table">
                                                <thead>
                                                    <tr>
                                                        <th>文件名</th>
                                                        <th>大小</th>
                                                        <th>状态</th>
                                                        <th>操作</th>
                                                    </tr>
                                                </thead>
                                                <tbody id="demoList"></tbody>
                                            </table>
                                        </div>
                                        <button type="button" class="layui-btn" id="testListAction">开始上传</button>
                                        <asp:HiddenField ID="HiddenFieldName1" runat="server" />
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="layui-form-item">
                            <label class="layui-form-label" style="width: 110px;"></label>
                            <div class="layui-input-block">
                                <asp:Button ID="btnSubmit" CssClass="layui-btn" OnClientClick="return FormCheck();" runat="server" Text="提  交" OnClick="btnSubmit_Click" />
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </form>
    </div>
    <script type="text/javascript">
        //修改
        HaikanUploadonload("<%=UploadFilseNameinfo%>", "HiddenFieldName", 1);
        //多文件上传
        HaikanUpload("HiddenFieldName", "testList", "images-video-file", 1, "SystemManage");
    </script>
</body>
</html>