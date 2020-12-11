<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="HfileAdd.aspx.cs" Inherits="HaikanSchoolProjects.General.Hfile.HfileAdd" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html lang="zh">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>添加文件</title>
    <%-- ReSharper disable once Html.Warning --%>
    <!--#include file="../head.htm" -->
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
                <legend>上传文件</legend>
            </fieldset>
            <div class="layui-form-item">
                <label class="layui-form-label" style="width: 110px">企业名称：</label>
                <div class="layui-input-inline" style="margin-top: 10px;">
                 <%--   <asp:DropDownList ID="DropDownList1" runat="server"></asp:DropDownList>--%>
                    <asp:TextBox ID="TextBox_E" ReadOnly="True" runat="server"  autocomplete="off" class="layui-input"></asp:TextBox>
                </div>
            </div>
            <div class="layui-form-item" runat="server">
                <label class="layui-form-item" style="width: 110px">企业文件：</label>
                <button type="button" class="layui-btn layui-btn-normal" id="testList1">选择多文件</button>
                <div class="layui-upload-list" style="margin-left: 100px;">
                    <table class="layui-table">
                        <thead>
                        <tr>
                            <th>文件名</th>
                            <th>大小</th>
                            <th>状态</th>
                            <th>操作</th>
                        </tr>
                        </thead>
                        <tbody id="demoList1"></tbody>
                    </table>
                </div>
                <button type="button" style="margin-left: 110px;" class="layui-btn" id="testListAction1">开始上传</button>
                <asp:HiddenField ID="qyFile1" runat="server" />
                <br />
                <br />
            </div>
            <div class="layui-form-item" runat="server">
                <label class="layui-form-item" style="width: 110px">合同文件：</label>
                <button type="button" class="layui-btn layui-btn-normal" id="testList2">选择多文件</button>
                <div class="layui-upload-list" style="margin-left: 100px;">
                    <table class="layui-table">
                        <thead>
                        <tr>
                            <th>文件名</th>
                            <th>大小</th>
                            <th>状态</th>
                            <th>操作</th>
                        </tr>
                        </thead>
                        <tbody id="demoList2"></tbody>
                    </table>
                </div>
                <button type="button" style="margin-left: 110px;" class="layui-btn" id="testListAction2">开始上传</button>
                <asp:HiddenField ID="HtFile2" runat="server" />
                <br />
                <br />
            </div>
            <div class="layui-form-item" runat="server">
                <label class="layui-form-label" style="width: 110px;">发票文件：</label>
                <button type="button" class="layui-btn layui-btn-normal" id="testList3">选择多文件</button>
                <div class="layui-upload-list" style="margin-left: 100px;">
                    <table class="layui-table">
                        <thead>
                        <tr>
                            <th>文件名</th>
                            <th>大小</th>
                            <th>状态</th>
                            <th>操作</th>
                        </tr>
                        </thead>
                        <tbody id="demoList3"></tbody>
                    </table>
                </div>
                <button type="button" style="margin-left: 100px;" class="layui-btn" id="testListAction3">开始上传</button>
                <asp:HiddenField ID="FpFile3" runat="server" />
                    <br />
                <br />
            </div>
            <div class="layui-form-item" runat="server">
                <label class="layui-form-label" style="width: 110px;">项目资料：</label>
                <button type="button" class="layui-btn layui-btn-normal" id="testList4">选择多文件</button>
                <div class="layui-upload-list" style="margin-left: 100px;">
                    <table class="layui-table">
                        <thead>
                        <tr>
                            <th>文件名</th>
                            <th>大小</th>
                            <th>状态</th>
                            <th>操作</th>
                        </tr>
                        </thead>
                        <tbody id="demoList4"></tbody>
                    </table>
                </div>
                <button type="button" style="margin-left: 100px;" class="layui-btn" id="testListAction4">开始上传</button>
                <asp:HiddenField ID="xmzl4" runat="server" />
                <br />
                <br />
            </div>
            <div class="layui-form-item">
                <div class="layui-input-block">
                    <asp:Button ID="Button1" runat="server" OnClientClick="return check();" class="layui-btn" Text="确  定" OnClick="BtnSubmit_Click" />
                </div>
            </div>
        </div>
    </form>
<script type="text/javascript">
    //多文件上传
    HaikanUpload("qyFile", "testList1", "images-video-file", 1, "Docking");
    HaikanUpload("HtFile", "testList2", "images-video-file", 2, "Docking");
    HaikanUpload("FpFile", "testList3", "images-video-file", 3, "Docking");
    HaikanUpload("xmzl", "testList4", "images-video-file", 4, "Docking");
</script>
</body>
</html>