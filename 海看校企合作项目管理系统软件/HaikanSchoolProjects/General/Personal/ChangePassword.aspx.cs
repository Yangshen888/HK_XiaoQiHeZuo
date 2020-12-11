using System;
using Haikan.SchoolProjectsCore;
using Haikan2.DEncrypt;

namespace HaikanSchoolProjects.General.Personal
{
    /// <summary>
    /// 修改密码
    /// </summary>
    public partial class ChangePassword : SystemPage
    {
        #region 实例化基类
        // 用户表
        private readonly Haikan.SchoolProjectsCore.MDB.BLL.SystemUser _systemUserBll =
            new Haikan.SchoolProjectsCore.MDB.BLL.SystemUser();
        private Haikan.SchoolProjectsCore.MDB.Model.SystemUser _systemUserModel =
            new Haikan.SchoolProjectsCore.MDB.Model.SystemUser();
        #endregion

        #region 数据绑定
        /// <summary>
        /// 页面加载
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
        }
        #endregion

        #region 操作方法
        /// <summary>
        /// 修改密码
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnConfirm_Click(object sender, EventArgs e)
        {
            if (!Page.IsValid) { return; }
            _systemUserModel = _systemUserBll.GetModel(Convert.ToInt32(Session["userid"]));
            string password =DesEncrypt.GetMd5String(txtPassword.Text);
            string pwd = DesEncrypt.GetMd5String(txtPwd.Text);
            if (_systemUserModel != null)
            {
                if (_systemUserModel.UserPwd.ToUpper() == password.ToUpper())
                {
                    if (txtPwd.Text != txtRpwd.Text)
                    {
                        Alert("新密码和确认密码不一样！");
                    }
                    else
                    {
                        if (_systemUserModel.UserPwd == pwd || pwd.Length<6)
                        {
                            Alert("新密码和旧密码太相似，且密码长度不少于6位,请重新设置！");
                        }
                        else
                        {
                            _systemUserModel.UserPwd = pwd;
                            if (_systemUserBll.Update(_systemUserModel))
                            {
                                Session.Abandon();
                                AlertAndParentReoload("修改成功！");
                                AddSystemLog("用户修改密码","修改");
                            }
                        }
                    }
                }else Alert("原密码不正确！");
            }else Alert("没找到该用户！");
        }
        #endregion
    }
}