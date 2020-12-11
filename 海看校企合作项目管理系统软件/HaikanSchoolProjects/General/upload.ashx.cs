using System;
using System.IO;
using System.Web;

namespace HaikanSchoolProjects.General
{
    /// <summary>
    /// upload 的摘要说明
    /// </summary>
    public class upload : IHttpHandler
    {
        public void ProcessRequest(HttpContext context)
        {
            string end = "{\"code\": 1,\"msg\": \"服务器故障\",\"data\": {\"src\": \"\"}}"; //返回的json
            context.Response.ContentType = "text/html";
            HttpServerUtility server = context.Server;
            HttpRequest request = context.Request;
            HttpResponse response = context.Response;
            HttpPostedFile file = context.Request.Files[0];
            if (file.ContentLength > 0)
            {
                string extName = Path.GetExtension(file.FileName);
                string fileName = Path.GetFileNameWithoutExtension(file.FileName) + Guid.NewGuid().ToString().Split('-')[0];
                string fullName = fileName + extName;
                //string imageFilter = ".jpg|.jpeg|.png|.gif|.ico";// 随便模拟几个图片类型
                //if (imageFilter.Contains(extName.ToLower()))
                {
                    if (request["name"] != null && request["name"] != "")
                    {
                        CheckDirectory(server.MapPath("/UploadFiles/" + request["name"] + "/"));
                        string phyFilePath = server.MapPath("/UploadFiles/" + request["name"] + "/") + fullName;
                        file.SaveAs(phyFilePath);

                        end = "{\"code\": 0,\"msg\": \"上传成功\",\"data\": {\"src\": \"" + fullName + "\",\"size\":\"" + file.ContentLength / 1024 + "kb\"}}";
                    }
                }
            }
            response.Write(end);
            response.End();
        }
        public void CheckDirectory(string folderPath)
        {
            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }
        }
        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}