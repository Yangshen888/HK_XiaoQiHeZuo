<%@ Page Language="C#" CodeBehind="SystemLicense.aspx.cs" Inherits="HaikanSchoolProjects.General.SystemManage.SystemLicense" %>

<%@ Register Src="~/General/HeadAndMenu.ascx" TagPrefix="uc1" TagName="HeadAndMenu" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml" lang="zh">
<head runat="server">
    <title>系统参数设置</title>
    <%-- ReSharper disable once Html.Warning --%>
    <!--#include file="../head.htm" -->
    <script type="text/javascript">
        function FormCheck(e) {
            if (document.getElementById("txtAuthorizationCode").value.replace(/[ ]/g, "") === "") {
                layer.msg("请输入授权码！");
                return false;
            }
            // 防止二次提交
            var x = noDouble(e);
            return x!==0;
        }
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
                                <legend>软件授权</legend>
                            </fieldset>
                        </div>
 
                    <div id="wizard_validation">
                        <div id="wizard_form" class="wizard clearfix">
                            
                            <div class="layui-form-item">
                                <label class="layui-form-label" style="width: 110px;">机器码：</label>
                                <div class="layui-input-block">
                                    <asp:TextBox ID="txtMachineCode" runat="server" placeholder="机器码" autocomplete="off" class="layui-input" ReadOnly="true" />
                                </div>
                            </div>
                            
                            <div class="layui-form-item">
                                <label class="layui-form-label" style="width: 110px;">授权码：</label>
                                <div class="layui-input-block">
                                    <asp:TextBox ID="txtAuthorizationCode" runat="server" TextMode="MultiLine" placeholder="请输入授权码" autocomplete="off" class="layui-textarea" />
                                    <asp:RequiredFieldValidator ID="RFVAuthorizationCode" runat="server" ControlToValidate="txtAuthorizationCode" Display="Dynamic" ErrorMessage="授权码必须要填写！" Style="font-size: 12px; color: red;" />
                                </div>
                            </div>
                            
                            <div class="layui-form-item">
                                                            <label class="layui-form-label" style="width: 110px;">到期时间：</label>
                                                            <div class="layui-input-block">
                                                                <asp:Label runat="server" ID="labStopDateTime" />
                                                            </div>
                                                        </div>
                            
                        <div class="layui-form-item">
                            <label class="layui-form-label" style="width: 110px;"></label>
                            <div class="layui-input-block">
                                <asp:Button ID="btnSubmit" CssClass="layui-btn" OnClientClick="return FormCheck(this);" runat="server" Text="提  交" OnClick="btnSubmit_Click" />
                            </div>
                        </div></div>
            </div></div>
             </div>
        </form>
    </div>
</body>
</html>
