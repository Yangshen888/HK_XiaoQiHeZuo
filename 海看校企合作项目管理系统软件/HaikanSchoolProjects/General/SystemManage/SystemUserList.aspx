<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SystemUserList.aspx.cs" Inherits="HaikanSchoolProjects.General.SystemManage.SystemUserList" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<%@ Register Src="~/General/HeadAndMenu.ascx" TagPrefix="uc1" TagName="HeadAndMenu" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html>
<head lang="zh">
    <title>系统管理员列表</title>
    <%-- ReSharper disable once Html.Warning --%>
    <!--#include file="../head.htm" -->
</head>
<body class="side_menu_active side_menu_expanded">
    <div id="page_wrapper">
        <form id="form1" runat="server" class="layui-form-pane">
            <uc1:headandmenu runat="server" id="HeadAndMenu" />
  
            <div id="main_wrapper">
                <div id="mymain">
                    <div class="layui-form-item">
                        <fieldset class="layui-elem-field layui-field-title" style="margin-top: 40px;">
                            <legend>用户信息列表</legend>
                        </fieldset>
                    </div>

                    <blockquote class="layui-elem-quote">
                        <div style="margin-bottom: auto;" class="layui-form-item">
                            <div style="float: left;">
                                <div class="layui-form-item">
                                    <label class="layui-form-label" style="width: 100px;">所属部门：</label>
                                    <div class="layui-input-inline">
                                        <asp:DropDownList ID="ddlDepartment" runat="server" Visible="true" class="layui-input" />
                                    </div>
                                </div>
                            </div>
                            <div style="float: left;">
                                <div class="layui-form-item">
                                    <label class="layui-form-label" style="width: 100px;">真实姓名：</label>
                                    <div class="layui-input-inline">
                                        <asp:TextBox ID="TextBox1" runat="server" placeholder="请输入真实姓名" autocomplete="off" class="layui-input" />
                                    </div>

                                </div>
                            </div>
                            <div style="float: left;">
                                <div class="layui-form-item">
                                    <label class="layui-form-label" style="width: 100px;">在职状态：</label>
                                    <div class="layui-input-inline">
                                        <asp:DropDownList ID="DropDownList2" runat="server" class="layui-input">
                                            <asp:ListItem>在职</asp:ListItem>
                                            <asp:ListItem>离职</asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                </div>
                            </div>
                            <span></span>
                            <a class="layui-btn layui-btn-normal" onserverclick="BtnSearch_Click" runat="server" id="ImgBtnsearch">
                                <i class="layui-icon" style="color: #fff;">&#xe615;</i> 查询
                            </a>
                            <a class="layui-btn" runat="server" onclick="ShowWindow('添加','SystemUserAdd.aspx','55%','85%',2,false,true,true,false,true)" id="ImgBtnAdd">
                                <i class="layui-icon" style="color: #fff;">&#xe608;</i> 添加
                            </a>
                            <a class="layui-btn layui-btn-danger" onclick="return CheckDel();" onserverclick="BtnDel_Click" runat="server" id="ImgBtnDel">
                                <i class="layui-icon" style="color: #fff;">&#xe640;</i> 删除
                            </a>
                        </div>
                    </blockquote>

                    <asp:ScriptManager ID="ScriptManager1" runat="server" />
                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                        <ContentTemplate>
              
                                    <div class="dataTables_length" id="DataTables_Table_0_length">
                                        <label>
                                            共
                                            <asp:Label ID="Label1" runat="server" Text="0" ForeColor="Red" />
                                               条 每页显示
                                             <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="true" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged">
                                                 <asp:ListItem Value="5">5</asp:ListItem>
                                                 <asp:ListItem Value="10">10</asp:ListItem>
                                                 <asp:ListItem Value="25" Selected="True">25</asp:ListItem>
                                                 <asp:ListItem Value="50">50</asp:ListItem>
                                             </asp:DropDownList>
                                            条</label>
                                    </div>
                
            
                            <asp:Button ID="Button1" runat="server" Text="" Style="display: none;" OnClick="Button1_Click" />

                            <asp:GridView ID="GVData" runat="server" OnPreRender="GVData_PreRender" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" PageSize="25" CellPadding="0" EmptyDataText="该列表中暂时无数据！" CssClass="layui-table" ShowHeaderWhenEmpty="True">
                                <AlternatingRowStyle BackColor="WhiteSmoke"></AlternatingRowStyle>
                                <HeaderStyle CssClass="haikangridview_head"></HeaderStyle>
                                <PagerSettings Mode="NumericFirstLast" Visible="False"></PagerSettings>
                                <Columns>
                                    <asp:TemplateField>
                                        <ItemTemplate>
                                            <asp:Label ID="LabVisible" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "Id")%>'
                                                       Visible="False" /><asp:CheckBox ID="CheckSelect" runat="server" />
                                        </ItemTemplate>
                                        <HeaderTemplate>
                                            <label for="CheckBoxAll"></label><input id="CheckBoxAll" onclick="CheckAll()" type="checkbox" />
                                        </HeaderTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="姓名【用户名】" HeaderStyle-CssClass="sorting">
                                        <ItemTemplate>
                                            <a href="#" onclick="ShowWindow('查看','SystemUserView.aspx?id=<%#Eval("ID") %>','50%','70%',2,false,true,true,false,true)">
                                                <%#Eval("TrueName")%>[<%# Eval("UserName")%>]
                                            </a>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="Birthday" HeaderText="出生年月" HeaderStyle-CssClass="sorting" />
                                    <asp:BoundField DataField="TelphoneNumber" HeaderText="手机号" HeaderStyle-CssClass="sorting" />
                                    <asp:TemplateField HeaderText="所属部门" HeaderStyle-CssClass="sorting">
                                        <ItemTemplate>
                                            <i></i>
                                            <%#DepartmentShow(DataBinder.Eval(Container.DataItem, "DepartmentID").ToString()) %>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="所属角色" HeaderStyle-CssClass="sorting">
                                        <ItemTemplate>
                                            <i></i>
                                            <%#Leixing(Eval("RoleID").ToString())%>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="登陆系统" HeaderStyle-CssClass="sorting">
                                        <ItemTemplate>
                                            <%#GetEnter(Eval("IsEnter").ToString()) %>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="操作">
                                        <ItemTemplate>
                                            <a class="layui-btn layui-btn-xs" onclick="ShowWindow('修改','SystemUserAdd.aspx?id=<%#Eval("ID") %>','50%','70%',2,false,true,true,false,true)" <%=CheckModify()%> >
                                                <i class="layui-icon" style="color: #fff;">&#xe642;</i>修改
                                            </a>
                                            <a <%=CheckModify()%> >
                                                <i class="layui-icon" style="color: #fff;">&#xe673;</i>解除锁定
                                                    <asp:HiddenField ID="HiddenField1" runat="server" Value='<%#Eval("id") %>' />
                                            </a>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                                <RowStyle HorizontalAlign="Left" Height="25px"></RowStyle>
                            </asp:GridView>

                            <div class="haikanpage">
                                <webdiyer:AspNetPager ID="AspNetPager1" runat="server" Height="100%" ShowPageIndexBox="Never"
                                    PageIndexBoxType="TextBox" TextBeforePageIndexBox="转到 " UrlPagingTarget="_self"
                                    UrlPageSizeName="s" PageIndexBoxClass="flattext" ShowPageIndex="True"
                                    TextAfterPageIndexBox=" 页 " Wrap="False" NextPageText="下一页" PrevPageText="上一页"
                                    CustomInfoHTML="第%CurrentPageIndex%页，共%PageCount%页，第%CurrentPageIndex%页显示%PageSize%条" 
                                                        ShowCustomInfoSection="Left" CustomInfoTextAlign="Left"
                                                        PageSize="25" NumericButtonCount="3" PagingButtonSpacing="8px"
                                    FirstPageText="首页" LastPageText="末页" OnPageChanged="AspNetPager1_PageChanged" AlwaysShow="True">
                                </webdiyer:AspNetPager>
                            </div>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>
            </div>
        </form>
    </div>
    <script>
        $(".unlock").click(function () {
            var id = $(this).children("input")[0].value;
            $.ajax({
                url: "Unlock.ashx?id=" + id,
                type: 'get',
                dataType: 'text',
                success: function (data) {
                    if (data === 'success')
                        layer.open({
                            content: '解锁成功'
                            , btn: ['关闭']
                        });
                    window.location.reload();
                },
                error: function () {
                    layer.open({
                        type: 1,
                        content: '失败'
                        , btn: ['关闭'],
                        yes: function () {
                            window.location.reload();
                        }
                    });
                }
            });
        });
    </script>
</body>
</html>