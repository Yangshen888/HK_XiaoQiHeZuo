<%@ webhandler Language="C#" class="FileManager" %>
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using System.Web;
using LitJson;

public class FileManager : IHttpHandler
{
    public void ProcessRequest(HttpContext context)
    {
        var aspxUrl = context.Request.Path.Substring(0, context.Request.Path.LastIndexOf("/", StringComparison.Ordinal) + 1);

        //根目录路径，相对路径
        var rootPath = "../attached/";
        //根目录URL，可以指定绝对路径，比如 http://www.yoursite.com/attached/
        var rootUrl = aspxUrl + "../../../UploadFiles/";
        //图片扩展名
        var fileTypes = "gif,jpg,jpeg,png,bmp";

        var currentPath = "";
        var currentUrl = "";
        var currentDirPath = "";
        var moveupDirPath = "";

        var dirPath = context.Server.MapPath(rootPath);
        var dirName = context.Request.QueryString["dir"];
        if (!string.IsNullOrEmpty(dirName))
        {
            if (Array.IndexOf("image,flash,media,file".Split(','), dirName) == -1)
            {
                context.Response.Write("Invalid Directory name.");
                context.Response.End();
            }

            dirPath += dirName + "//";
            rootUrl += dirName + "//";
            if (!Directory.Exists(dirPath)) Directory.CreateDirectory(dirPath);
        }

        //根据path参数，设置各路径和URL
        var path = context.Request.QueryString["path"];
        path = string.IsNullOrEmpty(path) ? "" : path;
        if (path == "")
        {
            currentPath = dirPath;
            currentUrl = rootUrl;
            currentDirPath = "";
            moveupDirPath = "";
        }
        else
        {
            currentPath = dirPath + path;
            currentUrl = rootUrl + path;
            currentDirPath = path;
            moveupDirPath = Regex.Replace(currentDirPath, @"(.*?)[^\/]+\/$", "$1");
        }

        //排序形式，name or size or type
        var order = context.Request.QueryString["order"];
        order = string.IsNullOrEmpty(order) ? "" : order.ToLower();

        //不允许使用..移动到上一级目录
        if (Regex.IsMatch(path, @"\.\."))
        {
            context.Response.Write("Access is not allowed.");
            context.Response.End();
        }

        //最后一个字符不是/
        if (path != "" && !path.EndsWith("/"))
        {
            context.Response.Write("Parameter is not valid.");
            context.Response.End();
        }

        //目录不存在或不是目录
        if (!Directory.Exists(currentPath))
        {
            context.Response.Write("Directory does not exist.");
            context.Response.End();
        }

        //遍历目录取得文件信息
        var dirList = Directory.GetDirectories(currentPath);
        var fileList = Directory.GetFiles(currentPath);

        switch (order)
        {
            case "size":
                Array.Sort(dirList, new NameSorter());
                Array.Sort(fileList, new SizeSorter());
                break;
            case "type":
                Array.Sort(dirList, new NameSorter());
                Array.Sort(fileList, new TypeSorter());
                break;
            case "name":
            default:
                Array.Sort(dirList, new NameSorter());
                Array.Sort(fileList, new NameSorter());
                break;
        }

        var result = new Hashtable();
        result["moveup_dir_path"] = moveupDirPath;
        result["current_dir_path"] = currentDirPath;
        result["current_url"] = currentUrl;
        result["total_count"] = dirList.Length + fileList.Length;
        var dirFileList = new List<Hashtable>();
        result["file_list"] = dirFileList;
        for (var i = 0; i < dirList.Length; i++)
        {
            var dir = new DirectoryInfo(dirList[i]);
            var hash = new Hashtable();
            hash["is_dir"] = true;
            hash["has_file"] = dir.GetFileSystemInfos().Length > 0;
            hash["filesize"] = 0;
            hash["is_photo"] = false;
            hash["filetype"] = "";
            hash["filename"] = dir.Name;
            hash["datetime"] = dir.LastWriteTime.ToString("yyyy-MM-dd HH:mm:ss");
            dirFileList.Add(hash);
        }

        for (var i = 0; i < fileList.Length; i++)
        {
            var file = new FileInfo(fileList[i]);
            var hash = new Hashtable();
            hash["is_dir"] = false;
            hash["has_file"] = false;
            hash["filesize"] = file.Length;
            hash["is_photo"] = Array.IndexOf(fileTypes.Split(','), file.Extension.Substring(1).ToLower()) >= 0;
            hash["filetype"] = file.Extension.Substring(1);
            hash["filename"] = file.Name;
            hash["datetime"] = file.LastWriteTime.ToString("yyyy-MM-dd HH:mm:ss");
            dirFileList.Add(hash);
        }

        context.Response.AddHeader("Content-Type", "application/json; charset=UTF-8");
        context.Response.Write(JsonMapper.ToJson(result));
        context.Response.End();
    }

    public bool IsReusable 
    {
     get { return true; }
    }

    public class NameSorter : IComparer
    {
        public int Compare(object x, object y)
        {
            if (x == null && y == null) return 0;
            if (x == null) return -1;
            if (y == null) return 1;
            var xInfo = new FileInfo(x.ToString());
            var yInfo = new FileInfo(y.ToString());

            return String.Compare(xInfo.FullName, yInfo.FullName, StringComparison.Ordinal);
        }
    }

    public class SizeSorter : IComparer
    {
        public int Compare(object x, object y)
        {
            if (x == null && y == null) return 0;
            if (x == null) return -1;
            if (y == null) return 1;
            var xInfo = new FileInfo(x.ToString());
            var yInfo = new FileInfo(y.ToString());

            return xInfo.Length.CompareTo(yInfo.Length);
        }
    }

    public class TypeSorter : IComparer
    {
        public int Compare(object x, object y)
        {
            if (x == null && y == null) return 0;
            if (x == null) return -1;
            if (y == null) return 1;
            var xInfo = new FileInfo(x.ToString());
            var yInfo = new FileInfo(y.ToString());

            return String.Compare(xInfo.Extension, yInfo.Extension, StringComparison.Ordinal);
        }
    }
}
