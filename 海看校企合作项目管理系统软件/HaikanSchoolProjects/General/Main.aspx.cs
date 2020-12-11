using System;
using Haikan.SchoolProjectsCore;
using Haikan.SchoolProjectsCore.MDB.Model;

namespace HaikanSchoolProjects.General
{
    public partial class Main : SystemPage
    {
        #region 实例化基类             
        //全局设置
        readonly Haikan.SchoolProjectsCore.MDB.BLL.SystemSetting _systemSettingBll = new Haikan.SchoolProjectsCore.MDB.BLL.SystemSetting();
        SystemSetting _systemSettingModel = new SystemSetting();
        public new string Title = "";
        #endregion

        #region 页面加载
        /// <summary>
        /// 页面加载
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            _systemSettingModel = _systemSettingBll.GetModel(2);
            //显示 用户名 作为标题
            Title = _systemSettingModel.SystemName;

        }
        #endregion
    }
}