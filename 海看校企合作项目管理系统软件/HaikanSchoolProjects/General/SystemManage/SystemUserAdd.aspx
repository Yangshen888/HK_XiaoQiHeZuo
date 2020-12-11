<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SystemUserAdd.aspx.cs" Inherits="HaikanSchoolProjects.General.SystemManage.SystemUserAdd" %>

<!DOCTYPE >
<html lang="zh">
<head>
    <title>添加管理员</title>
    <%-- ReSharper disable once Html.Warning --%>
    <!--#include file="../head.htm" -->
    <script type="text/javascript">
        function check() {
            if ($("#txtTrueName").val() === "") {
                layer.msg("请输入姓名！");
                return false;
            }
            if ($("#txtJobNumber").val() === "") {
                layer.msg("请输入职工号！");
                return false;
            }
            if ($("#txtIDCard").val() === "") {
                layer.msg("身份证不能为空！");
                return false;
            }
            if ($("#txtIDCard").val() !== "") {
                var reg = /(^\d{15}$)|(^\d{18}$)|(^\d{17}(\d|X|x)$)/;
                if (reg.test($("#txtIDCard").val()) === false) {
                    layer.msg("身份证输入不正确！");
                    return false;
                }
            }
            if ($("#txtJiaRuBenDanWeiTime").val() === "") {
                layer.msg("入职时间不能为空！");
                return false;
            }
            if ($("#TextBox2").val() !== "") {
                //入职
                var time1 = $("#txtJiaRuBenDanWeiTime").val();
                //转正
                var time2 = $("#TextBox2").val();
                var date1 = new Date(time1);
                var date2 = new Date(time2);
                if (Date.parse(date1) > Date.parse(date2)) {
                    layer.msg("入职时间不能大于转正时间");
                    return false;
                }
            }
            if ($("#txtTelPhone").val() === "") {
                layer.msg("手机号不能为空！");
                return false;
            }
            if ($("#txtTelPhone").val() !== "") {
                if ($("#txtTelPhone").val().length !== 11) {
                    layer.msg("手机格式不正确！");
                    return false;
                }
            }
            var filter = /^([a-zA-Z0-9_\.\-])+\@(([a-zA-Z0-9\-])+\.)+([a-zA-Z0-9]{2,4})+$/;
            if ($("#txtEmail").val() !== "") {
                if (!filter.test($("#txtEmail").val())) {
                    layer.msg('您的邮箱格式不正确');
                    return false;
                }
            }
            if ($("#ddlDepart").val() === "0") {
                layer.msg("请选择所属部门！");
                return false;
            }
            return false;
        }

        $(function () {
            layui.use('laydate',
                function () {
                    var laydate = layui.laydate;
                    laydate.render({
                        elem: '#txtBirthDay'
                    });
                    laydate.render({
                        elem: '#txtJiaRuBenDanWeiTime'
                    });
                    laydate.render({
                        elem: '#TextBox2'
                    });
                    laydate.render({
                        elem: '#TxtIDCardTime'
                    });
                    laydate.render({
                        elem: '#TxtPactTime'
                    });
                    laydate.render({
                        elem: '#TxtLabourTime'
                    });
                });
        });
    </script>
</head>
<body class="scroll-wrapper">
    <div id="main_wrapper">
        <div class="container-fluid">
            <fieldset class="layui-elem-field layui-field-title" style="margin-top: 0;">
                <legend><span>用户信息添加/修改</span></legend>
            </fieldset>
            <div class="col-md-6" style="width: 1000px">
                <form id="wizard_validation" runat="server">
                    <div id="wizard_form" class="wizard clearfix">
                        <fieldset>
                            <div class="layui-form-item">
                                <label class="layui-form-label" style="width: 110px;"><span style="color: red">*</span>姓名：</label>
                                <div class="layui-input-inline" style="width: 250px">
                                    <asp:TextBox ID="txtTrueName" runat="server" class="layui-input" placeholder="请输入姓名" autocomplete="off" />
                                </div>
                            </div>
                            <div class="layui-form-item">
                                <label class="layui-form-label" style="width: 110px;"><span style="color: red">*</span>职工号：</label>
                                <div class="layui-input-inline" style="width: 250px">
                                    <asp:TextBox ID="txtJobNumber" class="layui-input" onkeyup="if(isNaN(value))execCommand('undo')" onafterpaste="if(isNaN(value))execCommand('undo')" runat="server" placeholder="请输入职工号" autocomplete="off" />
                                </div>
                            </div>

                            <div class="layui-form-item">
                                <label class="layui-form-label" style="width: 110px;"><span style="color: red">*</span>身份证号：</label>
                                <div class="layui-input-inline" style="width: 250px">
                                    <asp:TextBox ID="txtIDCard" runat="server" class="layui-input" placeholder="请输入身份证号" autocomplete="off" OnTextChanged="txtIDCard_TextChanged" AutoPostBack="true" />
                                </div>
                            </div>
                            <div class="layui-form-item">
                                <label class="layui-form-label" style="width: 110px;"><span style="color: red">*</span>出生日期：</label>
                                <div class="layui-input-inline" style="width: 250px">
                                    <asp:TextBox ID="txtBirthDay" runat="server" placeholder="请输入出生日期" autocomplete="off" class="layui-input" />
                                </div>
                            </div>
                            <div class="layui-form-item">
                                <label class="layui-form-label" style="width: 110px;"><span style="color: red">*</span>入职日期：</label>
                                <div class="layui-input-inline" style="width: 250px">
                                    <asp:TextBox ID="txtJiaRuBenDanWeiTime" runat="server" placeholder="请输入入职日期" autocomplete="off" class="layui-input" />
                                </div>
                            </div>
                            <div class="layui-form-item">
                                <label class="layui-form-label" style="width: 110px;"><span style="color: red">*</span>性别：</label>
                                <div class="layui-input-inline" style="width: 250px">
                                    <asp:DropDownList ID="ddlSex" runat="server" name="quiz1" class="layui-input">
                                        <asp:ListItem>男</asp:ListItem>
                                        <asp:ListItem>女</asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                            </div>
                            <div class="layui-form-item">
                                <label class="layui-form-label" style="width: 110px;"><span style="color: red">*</span>学历：</label>
                                <div class="layui-input-inline" style="width: 250px">
                                    <asp:DropDownList ID="DropDownList3" runat="server" name="quiz1" class="layui-input">
                                        <asp:ListItem>中专</asp:ListItem>
                                        <asp:ListItem Selected="True">大专</asp:ListItem>
                                        <asp:ListItem>本科</asp:ListItem>
                                        <asp:ListItem>研究生</asp:ListItem>
                                        <asp:ListItem>硕士</asp:ListItem>
                                        <asp:ListItem>博士</asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                            </div>


                            <div class="layui-form-item">
                                <label class="layui-form-label" style="width: 110px;"><span style="color: red">*</span>联系电话：</label>
                                <div class="layui-input-inline" style="width: 250px">
                                    <asp:TextBox ID="txtTelPhone" onkeyup="if(isNaN(value))execCommand('undo')" onafterpaste="if(isNaN(value))execCommand('undo')" runat="server" placeholder="请输入联系电话" autocomplete="off" class="layui-input" />
                                </div>
                            </div>
                            <div class="layui-form-item">
                                <label class="layui-form-label" style="width: 110px;">邮箱：</label>
                                <div class="layui-input-inline" style="width: 250px">
                                    <asp:TextBox ID="txtEmail" runat="server" class="layui-input" placeholder="请输入邮箱" autocomplete="off" />
                                </div>
                            </div>
                            <asp:Panel ID="Panel1" runat="server">
                                <div class="layui-form-item">
                                    <label class="layui-form-label" style="width: 110px;"><span style="color: red">*</span>所属角色：</label>
                                    <div class="layui-input-inline" style="width: 250px">
                                        <asp:DropDownList ID="ddlRoles" runat="server" placeholder="请输入所属角色" autocomplete="off" class="layui-input" />
                                    </div>
                                </div>
                                <div class="layui-form-item">
                                    <label class="layui-form-label" style="width: 110px;"><span style="color: red">*</span>所属部门：</label>
                                    <div class="layui-input-inline" style="width: 250px">
                                        <asp:DropDownList ID="ddlDepart" runat="server" class="layui-input" />
                                    </div>
                                </div>
                                <div class="layui-form-item" <%=GetPwd()%>>
                                    <label class="layui-form-label" style="width: 110px;">修改密码：</label>
                                    <div class="layui-input-inline" style="width: 250px">
                                        <asp:TextBox ID="txtPwdSure" runat="server" placeholder="请输入确认密码" autocomplete="off" class="layui-input" />
                                    </div>
                                </div>
                                <div class="layui-form-item">
                                    <label class="layui-form-label" style="width: 110px;"><span style="color: red">*</span>允许登录：</label>
                                    <div class="layui-input-inline" style="width: 250px">
                                        <asp:DropDownList ID="ddlEnter" runat="server" class="layui-input">
                                            <asp:ListItem Value="0">允许</asp:ListItem>
                                            <asp:ListItem Value="1">不允许</asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                </div>
                                <div class="layui-form-item">
                                    <label class="layui-form-label" style="width: 110px;">是否在职：</label>
                                    <div class="layui-input-inline" style="width: 250px">
                                        <asp:DropDownList ID="DropDownList4" runat="server" class="layui-input">
                                            <asp:ListItem Value="1">在职</asp:ListItem>
                                            <asp:ListItem Value="0">离职</asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                </div>
                            </asp:Panel>
                        </fieldset>
                    </div>
                    <div class="layui-form-item">
                        <label class="layui-form-label" style="width: 110px;"></label>
                        <div class="layui-input-inline" style="width: 250px">
                            <asp:Button ID="Button1" runat="server" OnClientClick="return check();" CssClass="layui-btn" Text="确  定" OnClick="BtnSubmit_Click" />
                        </div>
                    </div>
                </form>
            </div>
        </div>
    </div>
</body>

