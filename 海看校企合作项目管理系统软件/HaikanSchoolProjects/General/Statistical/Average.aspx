<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Average.aspx.cs" Inherits="HaikanSchoolProjects.General.Statistical.Average" %>
<%@ Register Src="~/General/HeadAndMenu.ascx" TagPrefix="uc1" TagName="HeadAndMenu" %>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>项目开发情况分析 </title>
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
    </head>
<<body class="side_menu_active side_menu_expanded">
    <div id="page_wrapper">
        <form id="form1" runat="server" class="layui-form-pane">
                 <div id="main_wrapper">
                <uc1:HeadAndMenu runat="server" ID="HeadAndMenu" />
                <fieldset class="layui-elem-field layui-field-title" style="margin-top: 40px;">
                    <legend>人员平均工作量分析饼图</legend>
                </fieldset>
                <blockquote class="layui-elem-quote">
                    <div style="float: left;">
                        <div class="layui-form-item">
                            <label class="layui-form-label">选择项目：</label>
                            <div class="layui-input-inline">
                                <asp:DropDownList Height="38px" Width="140px" ID="DropDownListXM" runat="server"></asp:DropDownList>
                            </div>
                        </div>
                    </div>
                    <a class="layui-btn layui-btn-normal" runat="server" OnServerClick="Seacher" >
                        <i class="layui-icon" style="color: #fff;">&#xe615;</i> 查询
                    </a>
                    <a class="layui-btn layui-btn-normal" href="Average.aspx"  >
                        <i class="layui-icon" style="color: #fff;">&#xe615;</i> 总览
                    </a>
                </blockquote>
            </div>
            <div id="container" style="width: 50%; height: 600px; float: left;"></div>
            <div id="container1" style="width: 50%; height: 600px; float: left;"></div>
        </form>
    </div>
    <script type="text/javascript">
        var dom = document.getElementById("container");
        var myChart = echarts.init(dom);
        var app = {};
        option = null;
        option = {
            title : {
                text: '人员平均工作量',
                subtext: '',
                x:'center'
            },
            tooltip : {
                trigger: 'item',
                formatter: "{a} <br/>{b} : {c} ({d}%)"
            },
            legend: {
                orient: 'vertical',
                left: 'left',
                data: [<%=Mean%>
                ]
            },
            series : [
                {
                    name: '员工平均工作量',
                    type: 'pie',
                    radius : '55%',
                    center: ['50%', '60%'],
                    data: [
                        <%=Project%>
                    ],
                    itemStyle: {
                        emphasis: {
                            shadowBlur: 10,
                            shadowOffsetX: 0,
                            shadowColor: 'rgba(0, 0, 0, 0.5)'
                        }
                    }
                }
            ]
        };
        if (option && typeof option === "object") {
            myChart.setOption(option, true);
        }
    </script>
    <!--柱状图-->
    <script type="text/javascript">
        var dom = document.getElementById("container1");
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
                    data: [<%=Mean%>],
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
                    name: '工作量百分比',
                    type: 'bar',
                    barWidth: '60%',
                    data: [<%=Project%>]
                }
            ]
        };
        if (option && typeof option === "object") {
            myChart.setOption(option, true);
        }
    </script>
</body>
</html>