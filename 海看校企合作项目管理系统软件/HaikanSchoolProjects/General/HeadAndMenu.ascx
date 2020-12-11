<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="HeadAndMenu.ascx.cs" Inherits="HaikanSchoolProjects.General.HeadAndMenu" %>

<%--头部--%>
<div id="main_header">
    <div class="container-fluid">
        <img style="width: 40px; float: left; margin-top: 12px;margin-right: 20px;" src="<%= LeftImage %>" alt="haikan"/>
        <div class="brand_section hidden-xs">
            <asp:Label ID="LbSystemName" runat="server" Text="" Style="font-size: 22px; color: white;" />
            <asp:Label ID="LbUserName" runat="server" Text="Label" />
        </div>

        <%--通知图标--%>
        <ul class="header_notifications clearfix">
            <li class="dropdown">
                <a href="http://mail.haikan.com.cn" class="dropdown-toggle" target="_blank"><i class="el-icon-envelope"></i>&nbsp;企业邮箱</a>
            </li>
            
            <li class="dropdown">
                <a href="https://crm.dodokon.com" class="dropdown-toggle" target="_blank"><i class="el-icon-tasks"></i>&nbsp;CRM</a>
            </li>
            
            <li class="dropdown">
                <a href="https://gzt.dodokon.com" class="dropdown-toggle" target="_blank"><i class="el-icon-gift"></i>&nbsp;工资条</a>
            </li>
        </ul>

        <%--用户信息--%>
        <div class="header_user_actions dropdown">
            <div data-toggle="dropdown" class="dropdown-toggle user_dropdown" aria-expanded="false">
                <div class="user_avatar">
                    <img src="<%=Image %>" alt="" title="头像" width="38" height="38">
                </div>
                <span class="caret"></span>
            </div>
            <ul class="dropdown-menu dropdown-menu-right">
                <li>
                    <a><asp:Label ID="Label1" runat="server" /></a>
                </li>
                <li><a onclick="ShowWindow('修改资料','/General/Personal/ChangePassword.aspx','600px','700px',2,false,true,false,false,true)">修改资料</a></li>
                <li id="metnav_7"><a id="nav_7" href="/General/Logout.aspx">安全退出</a></li>
            </ul>
        </div>

        <%--搜索条--%>
        <div class="search_section hidden-sm hidden-xs">
            <asp:TextBox ID="TextBox1" runat="server" class="form-control" autocomplete="off" />
            <button class="btn btn-link btn-sm" onclick="return false;" type="button" runat="server"><span class="icon_search"></span></button>
        </div>
    </div>
</div>
<%--头部结束--%>

<%--左侧导航--%>
<nav id="main_menu">
    <div class="menu_wrapper" id="grovg">
        <ul>
            <li class="first_level">
                <a href="/General/Main.aspx" style="font-size: 14px;">
                    <span class="el-icon-home first_level_icon"></span>
                    <span class="menu-title" style="margin-left: 10px;">欢迎首页</span>
                </a>
            </li>
            <%=MenuStr %>
        </ul>
    </div>
    <div class="menu_toggle">
        <span class="icon_menu_toggle">
            <i class="arrow_carrot-2left"></i>
            <i class="arrow_carrot-2right" style="display: none"></i>
        </span>
    </div>
</nav>

<%--左侧导航结束--%>
<script>
    // 搜索框自动完成
    $(function () {
        $('#HeadAndMenu_TextBox1').autocomplete({
            source: [<%=PageUrl%>],
            select: function (event, ui) {
                location.href = ui.item.pageurl;
                return false;
            }
        });
    });

    // 左侧菜单样式和点击事件
    $(function () {              
        $(".subNavs").each(function () {
            if ($(this).prop("href") === String(window.location)) {
                $(this).css("background-color", "#d2d2d2");
                $(this).parent().parent().show();
                $(this).parent().parent().parent().children("a").css("background-color", "#555555");
                $(this).parent().parent().parent().children("a").css("color", "white");
                $(this).parent().parent().parent().parent().show();
                $(this).parent().parent().parent().parent().parent().children("a").css("background-color", "#444444");
                $(this).parent().parent().parent().parent().parent().children("a").css("color", "white");
            }
        });
    });
</script>
