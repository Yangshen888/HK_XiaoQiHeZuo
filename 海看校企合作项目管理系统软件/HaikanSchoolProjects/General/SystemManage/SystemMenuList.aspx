<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SystemMenuList.aspx.cs" Inherits="HaikanSchoolProjects.General.SystemManage.Menu" %>
<%@ Register Src="~/General/HeadAndMenu.ascx" TagPrefix="uc1" TagName="HeadAndMenu" %>

<!DOCTYPE >
<html>
<head>
    <title>菜单列表</title>
    <%-- ReSharper disable once Html.Warning --%>
    <!--#include file="../head.htm" -->
</head>
<body style="" class="side_menu_active side_menu_expanded">
    <div id="page_wrapper">
        <form id="form1" runat="server" class="layui-form-pane">
            <uc1:HeadAndMenu runat="server" ID="HeadAndMenu" />
            <div id="main_wrapper">
                <div id="mymain">
                    <div class="layui-form-item">
                        <fieldset class="layui-elem-field layui-field-title" style="margin-top: 40px;">
                            <legend>菜单管理列表</legend>
                        </fieldset>
                    </div>
                    <blockquote class="layui-elem-quote">
                        <div style="margin-bottom: auto;" class="layui-form-item">
                            <label class="layui-form-pane layui-form-label" style="width: 100px;">模块名称：</label>
                            <div class="layui-input-inline">
                                <asp:TextBox ID="txtModelName" runat="server" placeholder="请输入模块名称" autocomplete="off" class="layui-input" />
                            </div>
                            <span></span>
                            <a class="layui-btn layui-btn-normal" onserverclick="BtnSearch_Click" runat="server" id="ImgBtnsearch">
                                <i class="layui-icon" style="color: #fff;">&#xe615;</i> 查询
                            </a>
                            <a class="layui-btn" onclick="ShowWindow('添加','SystemMenuAdd.aspx','80%','90%',2,false,true,true,false,true)" runat="server" id="ImgBtnAdd">
                                <i class="layui-icon" style="color: #fff;">&#xe608;</i> 添加
                            </a>
                        </div>
                    </blockquote>
                    <asp:ScriptManager ID="ScriptManager1" runat="server" />
                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                        <ContentTemplate>
                            <div>
                                <div class="layui-btn-group">
                                    <input type="button" class="layui-btn" id="btn-expand" value="全部展开" />

                                    <input type="button" class="layui-btn" id="btn-fold" value="全部折叠">
                                </div>
                                <table id="auth-table" class="layui-table" lay-filter="auth-table"></table>
                            </div>

                            <!-- 操作列 -->
                            <script type="text/html" id="auth-state">
                                <a class="layui-btn layui-btn-primary layui-btn-xs" onclick="ShowWindow('添加','SystemUserAdd.aspx','50%','80%',2,false,true,true,false,true)" lay-event="edit">修改</a>
                                <a class="layui-btn layui-btn-danger layui-btn-xs" lay-event="del">删除</a>
                            </script>
                            
                            <script>
                                layui.config({
                                    base: '/libs/layui/modules/'
                                }).extend({
                                    treetable: 'treetable-lay/treetable'
                                }).use(['table', 'treetable'], function () {
                                    var $ = layui.jquery;
                                    var treetable = layui.treetable;

                                    // 渲染表格
                                    layer.load(2);
                                    treetable.render({
                                        treeColIndex: 1,
                                        treeSpid: 0,
                                        treeIdName: 'authorityId',
                                        treePidName: 'parentId',
                                        elem: '#auth-table',
                                        url: "SystemMenuHandler.ashx?where=<%=Strwhere%>",
                                            page: false,
                                            cols: [[
                                                { type: 'numbers' },
                                                { field: 'FullName', minWidth: 150, title: '模块名称' },
                                                { field: 'MenuRole', title: '权限字符串' },
                                                { field: 'SortCode', title: '显示顺序' },
                                                { field: 'Location', title: '地址' },
                                                {
                                                    field: 'isMenu', width: 100, templet: function (d) {
                                                        return '<a class="layui-btn  layui-btn-xs" onclick="ShowWindow(\'修改\',\'SystemMenuAdd.aspx?id=' + d.authorityId + '\', \'50%\',\'80%\',2,false,true,true,false,true)" lay-event="edit" style="<%= GetModifyRole() %>"><i class="layui-icon" style="color: #fff;">&#xe642;</i>修改</a>';

                                                }, title: '操作'
                                            }
                                        ]],
                                        done: function () {
                                            layer.closeAll('loading');
                                        }
                                    });

                                    $('#btn-expand').click(function () {
                                        treetable.expandAll('#auth-table');
                                    });

                                    $('#btn-fold').click(function () {
                                        treetable.foldAll('#auth-table');
                                    });
                                });
                            </script>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>
            </div>
        </form>
    </div>
</body>
</html>