<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SystemLog.aspx.cs" Inherits="HaikanSchoolProjects.General.SystemManage.CertificationLog" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<%@ Register Src="~/General/HeadAndMenu.ascx" TagPrefix="uc1" TagName="HeadAndMenu" %>

<!DOCTYPE>
<html lang="zh">
<head>
    <title>系统日志</title>
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
                    <li><span>系统日志</span></li>
                </ul>
            </nav>
            <div id="main_wrapper">
                <div id="mymain">
                    <div class="layui-form-item">
                        <fieldset class="layui-elem-field layui-field-title">
                            <legend>系统操作日志列表</legend>
                        </fieldset>
                    </div>
                    <blockquote class="layui-elem-quote">
                        <div style="margin-bottom: auto;" class="layui-form-item">
                            <label class="layui-form-pane layui-form-label" style="width: 100px;">用户名：</label>
                            <div class="layui-input-inline">
                                <asp:TextBox ID="txtUserName" runat="server" placeholder="请输入用户名" autocomplete="off" class="layui-input" />
                            </div>
                            <span></span>
                            <a class="layui-btn layui-btn-normal" onserverclick="BtnSearch_Click" runat="server" id="ImgBtnsearch">
                                <i class="layui-icon" style="color: #fff;">&#xe615;</i> 查询
                            </a>
                            <a class="layui-btn layui-btn-warm" onserverclick="BtnExport_Click" runat="server" id="ImgBtnExport">
                                <i class="layui-icon" style="color: #fff;">&#xe62f;</i> 导出
                            </a> 
                        </div>
                    </blockquote>
                    <asp:ScriptManager ID="ScriptManager1" runat="server" />
                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                        <ContentTemplate>
                            <div>
                                <div>
                                    <div class="dataTables_length" id="DataTables_Table_0_length">
                                        <label>
                                            共
                                            <asp:Label ID="Label1" runat="server" Text="0" ForeColor="Red" />
                                            条
                            每页显示
                             <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="true" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged">
                                 <asp:ListItem Value="5">5</asp:ListItem>
                                 <asp:ListItem Value="10">10</asp:ListItem>
                                 <asp:ListItem Value="25" Selected="True">25</asp:ListItem>
                                 <asp:ListItem Value="50">50</asp:ListItem>
                             </asp:DropDownList>
                                            条</label>
                                    </div>
                                </div>
                            </div>
                            <asp:GridView ID="GVData" runat="server" OnPreRender="GVData_PreRender" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" PageSize="25" CellPadding="0" EmptyDataText="该列表中暂时无数据！" CssClass="layui-table" ShowHeaderWhenEmpty="True">
                                <AlternatingRowStyle BackColor="WhiteSmoke"></AlternatingRowStyle>
                                <HeaderStyle CssClass="haikangridview_head"></HeaderStyle>
                                <PagerSettings Mode="NumericFirstLast" Visible="False"></PagerSettings>
                                <Columns>
                                    <asp:TemplateField>
                                        <ItemTemplate>
                                            <asp:Label ID="LabVisible" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "id")%>'
                                                Visible="False" /><asp:CheckBox ID="CheckSelect" runat="server" />
                                        </ItemTemplate>
                                        <HeaderStyle></HeaderStyle>
                                        <HeaderTemplate>
                                            <label for="CheckBoxAll"></label><input id="CheckBoxAll" onclick="CheckAll()" type="checkbox" />
                                        </HeaderTemplate>
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="UserName" HeaderText="用户名" HeaderStyle-CssClass="sorting" />
                                    <asp:BoundField DataField="TimeStr" HeaderText="时间" HeaderStyle-CssClass="sorting" />
                                    <asp:BoundField DataField="ActionStr" HeaderText="操作内容" HeaderStyle-CssClass="sorting" />
                                    <asp:BoundField DataField="IPAddress" HeaderText="IP地址" HeaderStyle-CssClass="sorting" />
                                    <asp:BoundField DataField="Type" HeaderText="类型" HeaderStyle-CssClass="sorting" />
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
</body>
</html>