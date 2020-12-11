// 单个删除前的提示
function CheckDel() {
    let number = 0;
    for (let i = 0; i < document.getElementById("form1").elements.length; i++) {
        let e = document.getElementById("form1").elements[i];
        if (e.name !== "CheckBoxAll") {
            if (e.checked === true) {
                number = number + 1;
            }
        }
    }
    
    if (number === 0) {
        alert("请选择需要删除的项！");
        return false;
    }
    
    return window.confirm("你确认删除吗？");
}


// 列表当中的全选功能
function CheckAll() {
    var code_Values = document.getElementsByTagName("input");
    for (i = 0; i < code_Values.length; i++) {
        if (code_Values[i].type == "checkbox") {
            if (code_Values[i].checked == true) {
                code_Values[i].checked = false;
            } else {
                code_Values[i].checked = true;
            }
        }
    }
}

// 批量删除前的提示
function DelConfirm() {
    var st = 0;
    for (var i = 0; i < document.getElementsByTagName("input").length; i++) {
        if (document.getElementsByTagName("input")[i].checked) {
            st = 1;
        }
    }

    if (st == 1) {
        if (window.confirm("你确实要彻底删除选中的信息吗？")) {
            return true;
        }
        else {
            return false;
        }
    } else {
        layer.msg("请选择你要删除的项！", { icon: 2 });
        return false;
    }
}

// 弹出自定义页面窗体
function ShowWindow(title, url, width, height, type, time, maxMin, shadeClose, scrollbar, moveOut) {
    layui.use('layer', function () {
            let layer = layui.layer;
            layer.open({
            type: type,
            time: time,
            title: title,
            maxMin: maxMin,
            shadeClose: shadeClose, //点击遮罩关闭层
            scrollbar: scrollbar,
            moveOut: moveOut,
            area: [width, height],
            content: url,
        });
    }
    )
}

// 弹出自定义页面窗体
function ShowWindow1(title, url, width, height) {
    layui.use('layer', function () {
        var layer = layui.layer;
        layer.open({
            type: 2,
            time: false,
            title: title,
            maxmin: true,
            shadeClose: true, //点击遮罩关闭层
            scrollbar: false,
            moveOut: true,
            area: [width, height],
            content: url,
        });
    }
    )
}



KindEditor.ready(function (K) {
    editor = K.create('#txtInfo',
        {
            filterMode: false,//是否开启过滤模式
            // 上传配置
            uploadJson: '/libs/kindeditor/asp.net/upload_json.ashx',
            fileManagerJson: '/libs/kindeditor/asp.net/file_manager_json.ashx',
            allowFileManager: true,
            urlType: 'relative',
            width: '700px',
            height:'400px',
            afterBlur: function () {
                this.sync();
            }
        });
});

KindEditor.ready(function (K) {
    editor = K.create('#txtht',
        {
            filterMode: false,//是否开启过滤模式
            // 上传配置
            uploadJson: '/libs/kindeditor/asp.net/upload_json.ashx',
            fileManagerJson: '/libs/kindeditor/asp.net/file_manager_json.ashx',
            allowFileManager: true,
            urlType: 'relative',
            width: '700px',
            height: '400px',
            afterBlur: function () {
                this.sync();
            }
        });
});
function showDate(id) {
    console.info(id)
    layui.use("laydate", function () {
        var laydate = layui.laydate;
        laydate.render({
            elem: "#" + id,
            type: 'datetime'
        })
    })
}
//修改带过来的文件
function HaikanUploadonload(UploadFilseName, HiddenFieldName, haikanindex) {
    var kk = UploadFilseName;
    if (kk != "") {
        document.getElementById("HiddenFieldName" + haikanindex).value = kk;
        var kk1 = kk.split(',');
        if (kk1.length > 0) {
            for (var i = 0; i < kk1.length; i++) {
                var tr = $(['<tr id=' + i + '>'
                    , '<td>' + kk1[i].split('|')[0] + '</td>'
                    , '<td>' + kk1[i].split('|')[1] + '</td>'
                    , '<td><span style="color: #5FB878;">上传成功</span></td>'
                    , '<td>'
                    , '<button class="layui-btn layui-btn-mini demo-reload layui-hide">重传</button>'
                    , '<button onclick="delRow(this,' + haikanindex + ')" class="layui-btn layui-btn-mini layui-btn-danger demo-delete">删除</button>'
                    , '</td>'
                    , '</tr>'].join(''));
                $('#demoList').append(tr);
            }
        }
    }
}
//HiddenFieldName---隐藏域控件名称
//KongJianName--上传按钮控件名称
//type--上传文件类型
function HaikanUpload(HiddenFieldName, KongJianName, type, haikanindex,name) {
    layui.use('upload', function () {
        var $ = layui.jquery
            , upload = layui.upload;
        //指定允许上传的文件类型        
        var files;
        var kks;
        //多文件列表示例
        var demoListView = $('#demoList')
            , uploadListIns = upload.render({
                elem: '#' + KongJianName
                , url: '/General/Project/upload.ashx?name=' + name
                , accept: 'file'
                , multiple: true
                , auto: false
                , bindAction: '#testListAction'
                , choose: function (obj) {
                    files = obj.pushFile(); //将每次选择的文件追加到文件队列
                    kks = document.getElementById("" + HiddenFieldName + haikanindex).value;
                    //alert(files);
                    //console.log(files);
                    //读取本地文件
                    obj.preview(function (index, file, result) {
                        var tr = $(['<tr id="upload-' + index + '">'
                            , '<td>' + file.name + '</td>'
                            , '<td>' + (file.size / 1014).toFixed(1) + 'kb</td>'
                            , '<td>等待上传</td>'
                            , '<td>'
                            , '<button class="layui-btn layui-btn-mini demo-reload layui-hide">重传</button>'
                            , '<button onclick="delRow(this,' + haikanindex + ')" class="layui-btn layui-btn-mini layui-btn-danger demo-delete">删除</button>'
                            , '</td>'
                            , '</tr>'].join(''));
                        //单个重传
                        tr.find('.demo-reload').on('click', function () {
                            obj.upload(index, file);
                        });

                        demoListView.append(tr);
                    });
                }
                , done: function (res, index, upload) {
                    if (res.code == 0) { //上传成功                                                             
                        //alert(res.data.size);
                        if (kks == "") {
                            kks = res.data.src + "|" + res.data.size;
                        }
                        else {
                            kks += "," + res.data.src + "|" + res.data.size;
                        }
                        document.getElementById("" + HiddenFieldName + haikanindex).value = kks;
                        var tr = demoListView.find('tr#upload-' + index)
                            , tds = tr.children();
                        tds.eq(0).html(res.data.src);
                        tds.eq(2).html('<span style="color: #5FB878;">上传成功</span>');
                        //tds.eq(3).html(''); //清空操作
                        delete files[index]; //删除文件队列已经上传成功的文件
                        return;
                    }
                    this.error(index, upload);
                }
                , error: function (index, upload) {
                    var tr = demoListView.find('tr#upload-' + index)
                        , tds = tr.children();
                    tds.eq(2).html('<span style="color: #FF5722;">上传失败</span>');
                    tds.eq(3).find('.demo-reload').removeClass('layui-hide'); //显示重传
                }
            });
    });
}

function delRow(obj, haikanindex) {
    var tr = this.getRowObj(obj);
    if (tr != null) {
        var td1 = tr.children[0].innerHTML;
        var td2 = tr.children[1].innerHTML;
        var td3 = td1 + "|" + td2;

        console.log("HiddenFieldName" + haikanindex);
        var kks = document.getElementById("HiddenFieldName" + haikanindex).value;


        if (kks != "") {
            var kklist = kks.split(',');
            if (kklist.length > 0) {
                var strlist = "";
                for (var i = 0; i < kklist.length; i++) {
                    if (kklist[i].split('|')[0] != td1) {
                        strlist += "," + kklist[i];
                    }
                }
                if (strlist.substr(0, 1) == ",") {
                    strlist = strlist.substr(1);
                }
                document.getElementById("HiddenFieldName" + haikanindex).value = strlist;
            }
        }
        else {
            document.getElementById("HiddenFieldName" + haikanindex).value = "";
        }
        tr.parentNode.removeChild(tr);
        return false;
    } else {
        throw new Error("the given object is not contained by the table");
    }
}
//得到行对象 
function getRowObj(obj) {
    var i = 0;
    while (obj.tagName.toLowerCase() != "tr") {
        obj = obj.parentNode;
        if (obj.tagName.toLowerCase() == "table") return null;
    }
    return obj;
}

//提交时防止重复提交
let ClickTimes = 1;
function noDouble(e) {
    if (ClickTimes === 1) {
        $(e).addClass("layui-btn-disabled");
        $(e).val("正在提交中，请等待...");
        ClickTimes++;
        return 1;
    } else {
        $(e).attr("disabled", "true");
        ClickTimes++;
        return 0;
    }
}

// 图片宽高自适应
function DrawImage(imgD, fitWidth, fitHeight) {
    var image = new Image();
    image.src = imgD.src;
    if (image.width > 0 && image.height > 0) {
        if (image.width / image.height >= fitWidth / fitHeight) {
            if (image.width > fitWidth) {
                imgD.width = fitWidth;
                imgD.height = (image.height * fitWidth) / image.width;
            } else {
                imgD.width = image.width;
                imgD.height = image.height;
            }
        } else {
            if (image.height > fitHeight) {
                imgD.height = fitHeight;
                imgD.width = (image.width * fitHeight) / image.height;
            } else {
                imgD.width = image.width;
                imgD.height = image.height;
            }
        }
    }
}