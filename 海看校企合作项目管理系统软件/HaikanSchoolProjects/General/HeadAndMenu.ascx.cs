using System;
using Haikan.SchoolProjectsCore;
using Haikan2.DataTools;

namespace HaikanSchoolProjects.General
{
    /// <summary>
    /// 头部和菜单控件
    /// </summary>
    public partial class HeadAndMenu : System.Web.UI.UserControl
    {
        #region 对象实例化
        // 全局设置
        private readonly Haikan.SchoolProjectsCore.MDB.BLL.SystemSetting _systemSetBll = new Haikan.SchoolProjectsCore.MDB.BLL.SystemSetting();
        private Haikan.SchoolProjectsCore.MDB.Model.SystemSetting _systemSetModel = new Haikan.SchoolProjectsCore.MDB.Model.SystemSetting();

        protected string PageUrl = "";
        protected string MenuStr = "";
        protected string Image = "";
        protected string LeftImage = "";

        // 页面基类
        private readonly SystemPage _systemPage = new SystemPage();
        
        #endregion

        /// <summary>
        /// 页面加载
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            // 读取系统名称
            _systemSetModel = _systemSetBll.GetModel(2);
            LbSystemName.Text = _systemSetModel.SystemName;
            LbUserName.Text = Session["TrueName"] + ",欢迎您";

            // 绑定用户名
            Label1.Text = Session["username"].ToString();

            // 菜单缓存
            var cookie = DataCache.GetCache("HaikanSchoolProjects-" + Session["userid"]);
            if (cookie!=null)
            {
                MenuStr += cookie;
            }
            else
            {
                Response.Redirect("Login.aspx?info=菜单缓存清空");
            }

            // 绑定搜索框的自动完成
            PageUrl = _systemPage.GetPageUrlByAuto();

            // 绑定用户头像
            if (!string.IsNullOrEmpty(Session["HeadPort"] as string))
            {
                Image = "/UploadFiles/SystemManage/" + Session["HeadPort"];
            }
            else
            {
                Image = "/libs/haikan/img/avatars/user.png";
            }

            // Logo
            LeftImage = "/libs/haikan/img/avatars/logo_white.png";
        }
    }
}