using System;
using System.Globalization;
using Haikan.SchoolProjectsCore;
using Haikan2.DataTools;
using Haikan2.DEncrypt;
using Haikan2.SafeTools;

namespace HaikanSchoolProjects.General.SystemManage
{
    /// <summary>
    /// 软件授权
    /// </summary>
    public partial class SystemLicense : SystemPage
    {
        #region 数据绑定
        /// <summary>
        /// 页面加载
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack) return;
            
            //按钮权限
            btnSubmit.Visible = ActionValidator("SystemSettingAdd");
            
            // 机器码
            txtMachineCode.Text = HaikanAuthorization.GetPcCode();
            
            // 授权码
            var authorizationCode= ConfigHelper.GetConfigString("AuthorizationCode");
            txtAuthorizationCode.Text = authorizationCode;

            // 到期时间
            if (string.IsNullOrEmpty(authorizationCode)) return;
            var code = DesEncrypt.Decrypt(authorizationCode);
            DateTime stopDateTime = Convert.ToDateTime(code.Split('|')[1]);
            labStopDateTime.Text = stopDateTime.ToString(CultureInfo.InvariantCulture);

            if (stopDateTime < DateTime.Now)
            {
                labStopDateTime.Text += "已经到期！请联系客服人员进行授权更新！";
            }
        }
        #endregion

        #region 事件方法
        /// <summary>
        /// 点击提交
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (!ActionValidator("SystemSettingModify"))
            {
                Alert("您没有权限！");
                return;
            }
            if (!Page.IsValid) { return; }

            if (ConfigHelper.EditAppValue("AuthorizationCode", txtAuthorizationCode.Text))
            {
                AlertAndParentSkip("更新成功！", "/General/Main.aspx");
            }
            else
            {
                Alert("保存出错了，请联系客服人员！");
            }
        }
        #endregion
    }
}