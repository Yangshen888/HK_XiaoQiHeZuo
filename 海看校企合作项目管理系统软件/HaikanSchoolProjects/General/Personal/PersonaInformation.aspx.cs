using System;
using Haikan.SchoolProjectsCore;

namespace HaikanSchoolProjects.General.Personal
{
    /// <summary>
    /// 个人信息
    /// </summary>
    public partial class PersonalInformation : SystemPage
    {
        #region 数据绑定
        /// <summary>
        /// 页面加载
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(Request.QueryString["id"]))    return;

            var a = new Haikan.SchoolProjectsCore.MDB.BLL.SystemUser().GetModel(int.Parse(Request.QueryString["id"]));
            var b = new Haikan.SchoolProjectsCore.MDB.BLL.SystemRoles().GetModel(int.Parse(a.RoleID));

            TextBoxJS.Text = b.RoleName;
            TextBoxName.Text = a.UserName;
        }
        #endregion
    }
}