using System;
using Haikan.SchoolProjectsCore;

namespace HaikanSchoolProjects.General.SystemManage
{
    /// <summary>
    /// 全局设置
    /// </summary>
    public partial class SystemSetting : SystemPage
    {
        #region 对象初始化
        Haikan.SchoolProjectsCore.MDB.BLL.SystemSetting _systemsettingbll = new Haikan.SchoolProjectsCore.MDB.BLL.SystemSetting();
        Haikan.SchoolProjectsCore.MDB.Model.SystemSetting _systemsettingmodel = new Haikan.SchoolProjectsCore.MDB.Model.SystemSetting();
        protected string UploadFilseNameinfo = "";
        #endregion

        #region 页面加载
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

            // 对所有控件进行赋值
            _systemsettingmodel = _systemsettingbll.GetModel(2);

            //系统名称
            txtSystemName.Text = _systemsettingmodel.SystemName;

            TextBox1.Text = _systemsettingmodel.Email;
            TextBox2.Text = _systemsettingmodel.smtpSeverName;
            TextBox3.Text = _systemsettingmodel.EmailName;
            TextBox4.Text = _systemsettingmodel.Emailpwd;
            HiddenFieldName1.Value = _systemsettingmodel.SystemPicture;
            UploadFilseNameinfo = HiddenFieldName1.Value;
        }
        #endregion

        #region 按钮操作
        /// <summary>
        /// 点击提交
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (ActionValidator("SystemSettingModify"))
            {
                if (!Page.IsValid) { return; }

                _systemsettingmodel = _systemsettingbll.GetModel(1);
                //添加时间
                //_systemsettingmodel.AddTime = DateTime.Now;
                //系统名称
                _systemsettingmodel.SystemName = txtSystemName.Text;
                _systemsettingmodel.Email = TextBox1.Text;
                _systemsettingmodel.smtpSeverName = TextBox2.Text;
                _systemsettingmodel.EmailName = TextBox3.Text;
                _systemsettingmodel.Emailpwd = TextBox4.Text;
                //图片
                _systemsettingmodel.SystemPicture = HiddenFieldName1.Value;

                //更新一条数据
                if (_systemsettingbll.Update(_systemsettingmodel))
                {
                    AlertAndParentSkip("更新成功！", "SystemSetting.aspx");
                }
            }
        }
        #endregion
    }
}










