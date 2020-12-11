<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EnterpriseList.aspx.cs" Inherits="HaikanSchoolProjects.General.Enterprise.EnterpriseList" %>
<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<%@ Register Src="~/General/HeadAndMenu.ascx" TagPrefix="uc1" TagName="HeadAndMenu" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html lang="zh">
<head>
    <title>合作企业列表</title>
    <%-- ReSharper disable once Html.Warning --%>
    <!--#include file="../head.htm" -->
</head>
<body class="side_menu_active side_menu_expanded">
    <div id="page_wrapper">
        <form id="form1" runat="server" class="layui-form-pane">
            <uc1:HeadAndMenu runat="server" ID="HeadAndMenu" />
            <div id="main_wrapper">
                <div id="mymain">
                    <fieldset class="layui-elem-field layui-field-title" style="margin-top: 40px;">
                        <legend>企业列表</legend>
                    </fieldset>
                    <blockquote class="layui-elem-quote">
                        <div style="margin-bottom: auto;" class="layui-form layui-form-item">
                            <div style="float: left;">
                                <div class="layui-form-item">
                                    <label class="layui-form-label">企业名称：</label>
                                    <div class="layui-input-inline">
                                        <asp:TextBox ID="TextBox1" runat="server" placeholder="请输入企业名称" autocomplete="off" class="layui-input"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                            <span></span>
                            <a class="layui-btn layui-btn-normal" onserverclick="BtnSearch_Click" runat="server">
                                <i class="layui-icon" style="color: #fff;">&#xe615;</i> 查询
                            </a>
                            <a class="layui-btn" onclick=" ShowWindow('添加','EnterpriseAdd.aspx','70%', '70%',2,false,true,true,false,true)" runat="server" id="add">
                                <i class="layui-icon" style="color: #fff;">&#xe654;</i> 添加
                            </a>
                            <a class="layui-btn layui-btn-danger" onclick="javascript:return CheckDel();" onserverclick="BtnDel_Click" runat="server" id="del">
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
                                            条 每页显示
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
                            <asp:GridView ID="GVData" runat="server" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False"
                                BorderStyle="Solid" BorderWidth="1px"
                                Width="100%" CellPadding="0" BackColor="White" BorderColor="Black" CssClass="layui-table"
                                EmptyDataText="该列表中暂时无数据！" ShowHeaderWhenEmpty="True" PageSize="999999">
                                <AlternatingRowStyle BackColor="WhiteSmoke" />
                                <HeaderStyle CssClass="haikangridview_head" Height="45" BackColor="#EBEBEB" />
                                <PagerSettings Mode="NumericFirstLast" Visible="False" />
                                <Columns>
                                    <asp:TemplateField>
                                        <ItemTemplate>
                                            <asp:Label ID="LabVisible" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "EnterpriseID")%>'
                                                Visible="False"></asp:Label><asp:CheckBox ID="CheckSelect" runat="server" />
                                        </ItemTemplate>
                                        <HeaderStyle />
                                        <HeaderTemplate>
                                            <input id="CheckBoxAll" onclick="CheckAll()" type="checkbox" />
                                        </HeaderTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="序号">
                                        <ItemTemplate>
                                            <%#Container.DataItemIndex+1%>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="企业名称">
                                        <ItemTemplate>
                                            <a style="cursor: pointer;" onclick="ShowWindow('修改信息','EnterpriseAdd.aspx?ID=<%# Eval("EnterpriseID") %>','70%', '70%',2,false,true,true,false,true)" <%=Gettre2()%>>
                                                <%# DataBinder.Eval(Container.DataItem, "EnterpriseName")%>
                                            </a>
                                        </ItemTemplate>
                                        <ItemStyle />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="审核状态">
                                        <ItemTemplate>
                                              <%#(Eval("Audit").ToString())%>
                                        </ItemTemplate>
                                        <ItemStyle />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="联系方式">
                                        <ItemTemplate>
                                            <i></i>
                                            <%#(Eval("Contact").ToString())%>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="备注">
                                        <ItemTemplate>
                                            <i></i>
                                            <%#(Eval("Note").ToString())%>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="合作履历">
                                        <ItemTemplate>
                                            <i></i>
                                            <a class="layui-btn layui-btn-sm" href="/General/Contract/ContractList.aspx?name=<%#(Eval("EnterpriseName").ToString())%>">查看详情
                                            </a>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="文件资料">
                                        <ItemTemplate>
                                            <a class="layui-btn layui-btn-sm" href="/General/Hfile/Hfile.aspx?name=<%#(Eval("EnterpriseName").ToString())%>"><i class="layui-icon" style="color: #fff;">&#xe642;</i>企业文件</a>
                                        </ItemTemplate>
                                        <ItemStyle Width="120px" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="操作">
                                        <ItemTemplate>
                                            <a class="layui-btn layui-btn-sm" onclick=" ShowWindow('修改信息','EnterpriseAdd.aspx?ID=<%# Eval("EnterpriseID") %>','50%', '50%',2,false,true,true,false,true)" <%=Gettre2()%>>
                                                <i class="layui-icon" style="color: #fff;">&#xe642;</i>修改</a>
                                        </ItemTemplate>
                                        <ItemStyle Width="120px" />
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                            <div>
                                <div class="haikanpage">
                                    <webdiyer:AspNetPager ID="AspNetPager1" runat="server" Height="100%" ShowPageIndexBox="Never"
                                        PageIndexBoxType="TextBox" TextBeforePageIndexBox="转到 " UrlPagingTarget="_self"
                                        UrlPageSizeName="s" PageIndexBoxClass="flattext" ShowPageIndex="True"
                                        TextAfterPageIndexBox=" 页 " Wrap="False" NextPageText="下一页" PrevPageText="上一页"
                                        CustomInfoHTML="第%CurrentPageIndex%页，共%PageCount%页，第%CurrentPageIndex%页显示%PageSize%条" ShowCustomInfoSection="Left" PageSize="25" NumericButtonCount="5" PagingButtonSpacing="8px"
                                        FirstPageText="首页" LastPageText="末页" Style="text-align: right" OnPageChanged="AspNetPager1_PageChanged" AlwaysShow="True">
                                    </webdiyer:AspNetPager>
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