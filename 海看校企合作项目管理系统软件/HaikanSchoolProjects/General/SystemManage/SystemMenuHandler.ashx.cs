using System.Data;
using System.Web;

namespace HaikanSchoolProjects.General.SystemManage
{
    /// <summary>
    /// Handler1 的摘要说明
    /// </summary>
    public class SystemMenuHandler : IHttpHandler
    {
        #region 实例化基类
        //菜单
        Haikan.SchoolProjectsCore.MDB.BLL.SystemMenu _systemMenuBll = new Haikan.SchoolProjectsCore.MDB.BLL.SystemMenu();
        #endregion

        public void ProcessRequest(HttpContext context)
        {
            HttpResponse res = context.Response;
            HttpRequest req = context.Request;
            string wherestr = req.QueryString["where"];
            string str = "";
            DataSet ds = _systemMenuBll.GetList(wherestr +" order by SortCode desc");
            if (ds.Tables[0].Rows.Count > 0)
            {
                str += "{\"code\": 0,\"msg\":\"\",\"count\": 19,\"data\": [";
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    if (i == 0)
                    {
                        str += "{";
                        str += "\"authorityId\":" + ds.Tables[0].Rows[i]["ModuleID"] + ",";
                        str += "\"FullName\": \"" + "<span style='margin-right:10px;' class='" + ds.Tables[0].Rows[i]["Icon"] + "'></span>" + ds.Tables[0].Rows[i]["FullName"] + "\",";//模块名称
                        str += "\"MenuRole\": \"" + ds.Tables[0].Rows[i]["MenuRole"] + "\",";//权限字符串                        
                        str += "\"SortCode\": \"" + ds.Tables[0].Rows[i]["SortCode"] + "\",";//显示顺序
                        str += "\"Location\":\"" + ds.Tables[0].Rows[i]["Location"] + "\",";//地址
                        str += "\"menuIcon\": \"layui-icon-set\",";
                        str += "\"createTime\":\"2018/06/29 11:05:41\",";
                        str += "\"checked\": 0,";
                        str += "\"parentId\":" + ds.Tables[0].Rows[i]["ParentID"];//父级id                        
                        str += "}";
                    } 
                    else
                    {
                        str += ",{";
                        str += "\"authorityId\":" + ds.Tables[0].Rows[i]["ModuleID"] + ",";
                        str += "\"FullName\": \"" + "<span style='margin-right:10px;' class='" + ds.Tables[0].Rows[i]["Icon"] + "'></span>" + ds.Tables[0].Rows[i]["FullName"] + "\",";//模块名称
                        str += "\"MenuRole\": \"" + ds.Tables[0].Rows[i]["MenuRole"] + "\",";//权限字符串
                        str += "\"SortCode\": \"" + ds.Tables[0].Rows[i]["SortCode"] + "\",";//显示顺序
                        str += "\"Location\":\"" + ds.Tables[0].Rows[i]["Location"] + "\",";//地址
                        str += "\"menuIcon\": \"layui-icon-set\",";
                        str += "\"createTime\":\"2018/06/29 11:05:41\",";
                        str += "\"checked\": 0,";
                        str += "\"parentId\":" + ds.Tables[0].Rows[i]["ParentID"];//父级id           
                        str += "}";
                    }
                    str += GetSubMenu(ds.Tables[0].Rows[i]["ModuleID"].ToString());
                }
                str += "]}";
            }
            else
            {
                str += "{\"code\": 0,\"msg\":\"'暂无数据'\",\"count\": 19,\"data\": []}";
            }
            res.Write(str);
            res.ContentType = "text/plain";
            res.End();
        }

        /// <summary>
        /// 递归查询
        /// </summary>
        /// <param name="pid"></param>
        /// <returns></returns>
        public string GetSubMenu(string pid)
        {
            string strs = "";
            DataSet ds = _systemMenuBll.GetList("ParentID=" + pid);
            if (ds.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    strs += ",{";
                    strs += "\"authorityId\":" + ds.Tables[0].Rows[i]["ModuleID"] + ",";
                    strs += "\"FullName\": \"" + "<span style='margin-right:10px;' class='" + ds.Tables[0].Rows[i]["Icon"] + "'></span>" + ds.Tables[0].Rows[i]["FullName"] + "\",";//模块名称
                    strs += "\"MenuRole\": \"" + ds.Tables[0].Rows[i]["MenuRole"] + "\",";//权限字符串
                    strs += "\"SortCode\": \"" + ds.Tables[0].Rows[i]["SortCode"] + "\",";//显示顺序
                    strs += "\"Location\":\"" + ds.Tables[0].Rows[i]["Location"] + "\",";//地址
                    strs += "\"menuIcon\": \"layui-icon-set\",";
                    strs += "\"createTime\":\"2018/06/29 11:05:41\",";
                    strs += "\"checked\": 0,";
                    strs += "\"parentId\":" + ds.Tables[0].Rows[i]["ParentID"];//父级id          
                    strs += "}";
                    strs += GetSubMenu(ds.Tables[0].Rows[i]["ModuleID"].ToString());
                }
            }
            return strs;
        }

        public bool IsReusable => false;
    }
}