<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ProjectAnalyze.aspx.cs" Inherits="HaikanSchoolProjects.General.Statistical.ProjectAnalyze" %>
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
    <script>
        $(function () {
            layui.use('laydate',
                function () {
                    var laydate = layui.laydate;
                    laydate.render({
                        elem: '#time' ,type: 'year'
                    });
                });
        });
    </script>
</head>
<<body class="side_menu_active side_menu_expanded">
    <div id="page_wrapper">
        <form id="form1" runat="server" class="layui-form-pane">
                 <div id="main_wrapper">
                <uc1:HeadAndMenu runat="server" ID="HeadAndMenu" />
                <fieldset class="layui-elem-field layui-field-title" style="margin-top: 40px;">
                    <legend>项目开发情况分析</legend>
                </fieldset>
                <blockquote class="layui-elem-quote">
                    <div style="float: left">
                        <div class="layui-form-item">
                            <label class="layui-form-label">请选择年份：</label>
                            <div class="layui-input-inline">
                                <asp:TextBox ID="time" Width="100px" class="layui-input" runat="server"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                    <a class="layui-btn layui-btn-normal" onserverclick="BtnSearch_Click" runat="server">
                        <i class="layui-icon" style="color: #fff;">&#xe615;</i> 查询
                    </a>
                    <a class="layui-btn layui-btn-normal" href="ProjectAnalyze.aspx"  >
                        <i class="layui-icon" style="color: #fff;">&#xe615;</i> 总览
                    </a>
                </blockquote>
            </div>
            <!-- breadcrumbs -->
            <div id="container" style="width: 50%; height: 600px;"></div>
        </form>
    </div>
    <script type="text/javascript">
        var dom = document.getElementById("container");
        var myChart = echarts.init(dom);
        var app = {};
        option = null;
        option = {
            title: {
                text: '项目开发情况分析',
                subtext: '',
                x: 'center'
            },
            tooltip: {
                trigger: 'item',
                formatter: "{a} <br/>{b} : {c} ({d}%)"
            },
            legend: {
                orient: 'vertical',
                left: 'left',
                //这个地方可以绑定后台数据源
                data: [
                    '开发中','维护中','测试中'
                    <%--<%=Prj%>--%>
                ]
            },
            series: [
                {
                    name: '项目个数',
                    type: 'pie',
                    radius: '55%',
                    center: ['50%', '60%'],
                    data: [<%=Prjanalyze%>
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
</body>
</html>









