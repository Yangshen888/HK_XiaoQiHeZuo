<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SystemRolesList.aspx.cs" Inherits="HaikanSchoolProjects.General.SystemManage.SystemRolesList" %>
<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<%@ Register Src="~/General/HeadAndMenu.ascx" TagPrefix="uc1" TagName="HeadAndMenu" %>
<!DOCTYPE html>
<html>
<head>
    <title>角色信息管理</title>
    <%-- ReSharper disable once Html.Warning --%>
    <!--#include file="../head.htm" -->
</head>
<body class="side_menu_active side_menu_expanded">
    <div id="page_wrapper">
        <form id="form1" runat="server" class="layui-form-pane">
            <uc1:HeadAndMenu runat="server" ID="HeadAndMenu" />
            <!-- breadcrumbs -->
            <nav id="breadcrumbs">
                <ul>
                    <li><a href="/General/Main.aspx">首页</a></li>
                    <li><span>系统管理</span></li>
                    <li><span>角色信息管理</span></li>
                </ul>
            </nav>
            <div id="main_wrapper">
                <div id="mymain">
                    <div class="layui-form-item">
                        <fieldset class="layui-elem-field layui-field-title">
                            <legend>角色信息列表</legend>
                        </fieldset>
                    </div>
                    <blockquote class="layui-elem-quote">
                        <div style="margin-bottom: auto;" class="layui-form-item">
                            <label class="layui-form-pane layui-form-label" style="width: 100px;">角色名称：</label>
                            <div class="layui-input-inline">
                                <asp:TextBox ID="tbRoleName" runat="server" placeholder="请输入角色名称" autocomplete="off" class="layui-input"></asp:TextBox>
                            </div>
                            <span></span>
                            <a class="layui-btn layui-btn-normal" onserverclick="BtnSearch_Click" runat="server" id="ImgBtnsearch">
                                <i class="layui-icon" style="color: #fff;">&#xe615;</i> 查询
                            </a>
                            <a class="layui-btn" onclick="ShowWindow('添加','SystemRolesAdd.aspx','50%','80%',2,false,true,true,false,true)" runat="server" id="ImgBtnAdd">
                                <i class="layui-icon" style="color: #fff;">&#xe608;</i> 添加
                            </a>
                            <a class="layui-btn layui-btn-danger" onclick="javascript:return CheckDel();" onserverclick="BtnDel_Click" runat="server" id="ImgBtnDel">
                                <i class="layui-icon" style="color: #fff;">&#xe640;</i> 删除
                            </a>
                        </div>
                    </blockquote>
                    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                        <ContentTemplate>
                            <div>
                                <div>
                                    <div class="dataTables_length" id="DataTables_Table_0_length">
                                        <label>
                                            共
                    <asp:Label ID="Label1" runat="server" Text="0" ForeColor="Red"></asp:Label>
                                            条
                            每页显示
                             <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="true" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged">
                                 <asp:ListItem Value="5">5</asp:ListItem>
                                 <asp:ListItem Value="10">10</asp:ListItem>
                                 <asp:ListItem Value="25" Selected="True">25</asp:ListItem>
                                 <asp:ListItem Value="50">50</asp:ListItem>
                                 <asp:ListItem Value="999999">全部</asp:ListItem>
                             </asp:DropDownList>
                                            条</label>
                                    </div>
                                </div>
                            </div>
                            <asp:Button ID="Button1" runat="server" Text="" Style="display: none;" OnClick="Button1_Click" />
                            <asp:GridView ID="GVData" runat="server" OnPreRender="GVData_PreRender" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" PageSize="25" CellPadding="0" EmptyDataText="该列表中暂时无数据！" CssClass="layui-table" ShowHeaderWhenEmpty="True">
                                <HeaderStyle CssClass="haikangridview_head" />
                                <PagerSettings Mode="NumericFirstLast" Visible="False" />
                                <Columns>
                                    <asp:TemplateField>
                                        <ItemTemplate>
                                            <asp:Label ID="LabVisible" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "ID")%>' Visible="False"></asp:Label>
                                            <asp:CheckBox ID="CheckSelect" runat="server" />
                                        </ItemTemplate>
                                        <HeaderTemplate>
                                            <input id="CheckBoxAll" onclick="CheckAll()" type="checkbox" />
                                        </HeaderTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="角色名称" HeaderStyle-CssClass="sorting">
                                        <ItemTemplate>
                                            <a style="cursor: pointer;" onclick="ShowWindow('修改','SystemRolesAdd.aspx?id=<%#Eval("ID") %>','80%','80%',2,false,true,true,false,true)" <%=Gettre2()%>><%# DataBinder.Eval(Container.DataItem, "RoleName")%></a>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Left" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="操作">
                                        <ItemTemplate>
                                            <a onclick="ShowWindow('修改','SystemRolesAdd.aspx?id=<%#Eval("ID") %>','80%','80%',2,false,true,true,false,true)" class="layui-btn layui-btn-sm" <%=Gettre2()%>>
                                                <i class="layui-icon" style="color: #fff;">&#xe642;</i>修改</a>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                                <RowStyle HorizontalAlign="Left" Height="24px" />
                            </asp:GridView>
                            <div>
                                <div class="haikanpage">
                                    <webdiyer:AspNetPager ID="AspNetPager1" runat="server" Height="100%" ShowPageIndexBox="Never"
                                                          PageIndexBoxType="TextBox" TextBeforePageIndexBox="转到 " UrlPagingTarget="_self"
                                                          UrlPageSizeName="s" PageIndexBoxClass="flattext" ShowPageIndex="True"
                                                          TextAfterPageIndexBox=" 页 " Wrap="False" NextPageText="下一页" PrevPageText="上一页" ShowCustomInfoSection="Left"
                                                          CustomInfoHTML="第%CurrentPageIndex%页，共%PageCount%页，第%CurrentPageIndex%页显示%PageSize%条" PageSize="25" NumericButtonCount="3" PagingButtonSpacing="8px"
                                                          FirstPageText="首页" LastPageText="末页" Style="text-align: right" OnPageChanged="AspNetPager1_PageChanged" AlwaysShow="True"/>
                                </div>
                            </div>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>
            </div>
        </form>
    </div>
</body>
</html>
