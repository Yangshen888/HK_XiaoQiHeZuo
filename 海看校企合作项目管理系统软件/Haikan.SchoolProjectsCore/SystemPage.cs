using Haikan2.NewControl;
using Haikan.SchoolProjectsCore.MDB.Model;
using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Linq;

namespace Haikan.SchoolProjectsCore
{
    /// <summary>
    /// 后台所有页面继承的类
    /// </summary>
    public class SystemPage : HaikanSystemPage
    {
        #region 实例化基类
        // 系统日志表
        private readonly MDB.BLL.SystemLog _systemLogBll = new SchoolProjectsCore.MDB.BLL.SystemLog();
        private readonly SystemLog _systemLogModel = new SystemLog();

        //菜单管理
        private readonly MDB.BLL.SystemMenu _systemMenuBll = new MDB.BLL.SystemMenu();
        #endregion

        #region 产品管理相关的方法
        /// <summary>
        /// 添加操作日志
        /// </summary>
        /// <param name="logs">日志具体内容</param>
        /// <param name="type">日志类型</param>
        public void AddSystemLog(string logs, string type)
        {
            _systemLogModel.UserName = Session["UserName"].ToString();//操作人

            _systemLogModel.TimeStr = DateTime.Now;//操作时间

            _systemLogModel.ActionStr = logs;//操作内容

            if (System.Web.HttpContext.Current.Request.UserHostAddress != null)
                _systemLogModel.IPAddress = System.Web.HttpContext.Current.Request.UserHostAddress; //ip地址

            _systemLogModel.Type = type;//操作类型

            //systemlogmodel.IsDelete = 1;

            _systemLogModel.AddTime = DateTime.Now;//操作时间

            _systemLogModel.AddPeople = Session["TrueName"].ToString();//添加人真实姓名

            _systemLogBll.Add(_systemLogModel);
        }
        #endregion

        #region 用于自动完成的几个方法
        /// <summary>
        /// 系统权限分列
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <param name="gvData"></param>
        protected void PagerButtonClick(object sender, ImageClickEventArgs e, GridView gvData)
        {
            string str = ((ImageButton)sender).CommandName;
            if (str == "Next")
            {
                if (gvData.PageIndex < gvData.PageCount - 1)
                    ++gvData.PageIndex;
            }
            else
            {
                if (str == "Pre")
                {
                    if (gvData.PageIndex > 0)
                        --gvData.PageIndex;
                }
                else
                {
                    if (str != "Last")
                        gvData.PageIndex = 0;
                    else
                    {
                        try
                        {
                            gvData.PageIndex = gvData.PageCount - 1;
                        }
                        catch
                        {
                            gvData.PageIndex = 0;
                        }
                    }
                }
            }
        }

        /// <summary>
        /// 自动获取所有的页面菜单
        /// </summary>
        /// <returns></returns>
        public string GetPageUrlByAuto()
        {
            var result = "";

            var dss = _systemMenuBll.GetList("1=1 and Category='页面'");
            if (dss.Tables[0].Rows.Count <= 0) return result;
            for (int i = 0; i < dss.Tables[0].Rows.Count; i++)
            {
                if (dss.Tables[0].Rows.Count == i + 1)
                {
                    result += "{'pageurl': '" + dss.Tables[0].Rows[i]["Location"] + "','label': '" + dss.Tables[0].Rows[i]["FullName"] + "','rgb': '(239, 222, 205)'}";
                }
                else
                {
                    result += "{'pageurl': '" + dss.Tables[0].Rows[i]["Location"] + "','label': '" + dss.Tables[0].Rows[i]["FullName"] + "','rgb': '(239, 222, 205)'},";
                }
            }
            return result;
        }
        #endregion

        #region 防sql注入方法
        /// <summary>
        /// 防sql注入方法
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static bool SqlFilter(String str)
        {
            const string word = "'|--|;|+|%27|/*|@| and | or |%20and%20|%20or%20";
            return str != null && word.Split('|').Any(i => (str.ToLower().IndexOf(i, StringComparison.Ordinal) > -1));
        }
        #endregion
    }
}