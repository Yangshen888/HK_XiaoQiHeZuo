<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FinancialAnalysis.aspx.cs" Inherits="HaikanSchoolProjects.General.Statistical.FinancialAnalysis" %>
<%@ Register Src="~/General/HeadAndMenu.ascx" TagPrefix="uc1" TagName="HeadAndMenu" %>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>项目参与人数的统计</title>
    <%-- ReSharper disable once Html.Warning --%>
    <!--#include file="../head.htm" -->
    <script type="text/javascript" src="http://echarts.baidu.com/gallery/vendors/echarts/echarts.min.js"></script>
    <script type="text/javascript" src="http://echarts.baidu.com/gallery/vendors/echarts-gl/echarts-gl.min.js"></script>
    <script type="text/javascript" src="http://echarts.baidu.com/gallery/vendors/echarts-stat/ecStat.min.js"></script>
    <script type="text/javascript" src="http://echarts.baidu.com/gallery/vendors/echarts/extension/dataTool.min.js"></script>
    <script type="text/javascript" src="http://echarts.baidu.com/gallery/vendors/echarts/map/js/china.js"></script>
    <script type="text/javascript" src="http://echarts.baidu.com/gallery/vendors/echarts/map/js/world.js"></script>
    <script type="text/javascript" src="http://api.map.baidu.com/api?v=2.0&ak=ZUONbpqGBsYGXNIYHicvbAbM"></script>
    <script type="text/javascript" src="http://echarts.baidu.com/gallery/vendors/echarts/extension/bmap.min.js"></script>
    <script type="text/javascript" src="http://echarts.baidu.com/gallery/vendors/simplex.js"></script>
    <script>
        $(function () {
            layui.use('laydate',
                function () {
                    var laydate = layui.laydate;
                    laydate.render({
                        elem: '#time'
                    });
                });
        });
    </script>
</head>
<body class="side_menu_active side_menu_expanded">
    <div id="page_wrapper">
        <form id="form1" runat="server" class="layui-form-pane">
            <div id="main_wrapper">
                <uc1:HeadAndMenu runat="server" ID="HeadAndMenu" />
                <fieldset class="layui-elem-field layui-field-title" style="margin-top: 40px;">
                    <legend>财务收入情况分析</legend>
                </fieldset>
            </div>
            <blockquote class="layui-elem-quote" style="margin-left: 190px;">
                <div style="float: left;">
                    <div class="layui-form-item">
                        <label class="layui-form-label">请选择项目：</label>
                        <div class="layui-input-inline">
                            <asp:DropDownList  Height="38px" ID="DropDownListXM" runat="server" Width="140px" AutoPostBack="True" OnSelectedIndexChanged="DropDownListXM_SelectedIndexChanged">
                                <asp:ListItem>收款</asp:ListItem>
                                <asp:ListItem>付款</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                    </div>
                </div>
            </blockquote>
            <div id="container" style="margin-left: 200px; width: 50%; height: 500px;"></div>
        </form>
        <script type="text/javascript">
            var dom = document.getElementById("container");
            var myChart = echarts.init(dom);
            var app = {};
            option = null;
            option = {
                color: ['#3398DB'],
                tooltip: {
                    trigger: 'axis',
                    axisPointer: {            // 坐标轴指示器，坐标轴触发有效
                        type: 'shadow'        // 默认为直线，可选为：'line' | 'shadow'
                    }
                },
                grid: {
                    left: '3%',
                    right: '4%',
                    bottom: '3%',
                    containLabel: true
                },
                xAxis: [
                    {
                        type: 'category',
                        data: [ <%=DataA%> ],
                        axisTick: {
                            alignWithLabel: true
                        }
                    }
                ],
                yAxis: [
                    {
                        type: 'value'
                    }
                ],
                series: [
                    {
                        name: '金额',
                        type: 'bar',
                        barWidth: '60%',
                        data: [<%=DataB%>]
                    }
                ]
            };
            if (option && typeof option === "object") {
                myChart.setOption(option, true);
            }
        </script>
    </div>
</body>
</html>
