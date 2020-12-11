using System;
using System.Data;
using Haikan2.DEncrypt;
using System.Web.UI.WebControls;
using Haikan.SchoolProjectsCore;
using Haikan2.NewControl;
using System.Configuration;

namespace HaikanSchoolProjects.General.SystemManage
{
    public partial class SystemUserAdd : SystemPage
    {
        #region 对象实例化
        // 角色
        Haikan.SchoolProjectsCore.MDB.BLL.SystemRoles rolesbll = new Haikan.SchoolProjectsCore.MDB.BLL.SystemRoles();

        // 部门
        Haikan.SchoolProjectsCore.MDB.BLL.Department departbll = new Haikan.SchoolProjectsCore.MDB.BLL.Department();

        // 用户
        Haikan.SchoolProjectsCore.MDB.Model.SystemUser _systemUserModel = new Haikan.SchoolProjectsCore.MDB.Model.SystemUser();
        Haikan.SchoolProjectsCore.MDB.BLL.SystemUser _systemUserBll = new Haikan.SchoolProjectsCore.MDB.BLL.SystemUser();

        #endregion

        #region 数据绑定
        /// <summary>
        /// 页面加载
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.IsPostBack) return;

            // 绑定角色
            BindRoles();
            // 绑定部门
            BindDepartment();

            if (string.IsNullOrEmpty(Request.QueryString["id"])) return;
            
            Bind();
        }

        /// <summary>
        /// 判断显示与隐藏
        /// </summary>
        /// <returns></returns>
        protected string GetPwd()
        {
            return !string.IsNullOrEmpty(Request.QueryString["id"]) ? "style='display:block;'" : "style='display:none;'";
        }

        /// <summary>
        /// 绑定
        /// </summary>
        private void Bind()
        {
            _systemUserModel = _systemUserBll.GetModel(Convert.ToInt32(Request.QueryString["id"]));
            if (_systemUserModel == null) return;
            txtTrueName.Text = _systemUserModel.TrueName;
            ddlSex.SelectedValue = _systemUserModel.Sex;
            txtJobNumber.Text = _systemUserModel.UserName;
            ddlDepart.SelectedValue = _systemUserModel.DepartmentID.ToString();
            ddlRoles.SelectedValue = _systemUserModel.RoleID;
            txtTelPhone.Text = _systemUserModel.TelphoneNumber;
            txtEmail.Text = _systemUserModel.EmailStr;
            txtBirthDay.Text = _systemUserModel.BirthDay;
            ddlEnter.SelectedValue = _systemUserModel.IsEnter.ToString();
            DropDownList4.SelectedValue = _systemUserModel.IsDelete.ToString();
            //入职时间
            txtJiaRuBenDanWeiTime.Text = _systemUserModel.JiaRuBenDanWeiTime;
            txtIDCard.Text = _systemUserModel.SFZSerils;
        }
        #endregion

        #region 绑定角色数据
        /// <summary>
        /// 绑定角色数据
        /// </summary>
        private void BindRoles()
        {
            DataSet ds = rolesbll.GetList("IsDelete = 1");
            ddlRoles.DataSource = ds;
            ddlRoles.DataTextField = "RoleName";
            ddlRoles.DataValueField = "ID";
            ddlRoles.DataBind();
        }
        #endregion

        #region 绑定部门
        /// <summary>
        /// 绑定部门
        /// </summary>
        private void BindDepartment()
        {
            DataSet ds = departbll.GetList("1=1 and IsDelete = 1");
            ddlDepart.DataSource = ds;
            ddlDepart.DataTextField = "DepartmentName";
            ddlDepart.DataValueField = "ID";
            ddlDepart.DataBind();

            ListItem li = new ListItem("--请选择--", "0");
            ddlDepart.Items.Insert(0, li);
        }
        #endregion

        #region 事件方法
        /// <summary>
        /// 确定
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void BtnSubmit_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Request.QueryString["id"]))
            {
                _systemUserModel = _systemUserBll.GetModel(Convert.ToInt32(Request.QueryString["id"]));
            }
            _systemUserModel.UserName = txtJobNumber.Text.Trim();
            _systemUserModel.IsDelete = 1;
            _systemUserModel.TrueName = txtTrueName.Text.Trim();
            _systemUserModel.Sex = ddlSex.SelectedValue;
            _systemUserModel.TelphoneNumber = txtTelPhone.Text;
            _systemUserModel.BirthDay = txtBirthDay.Text.Trim();// 出生日期
            _systemUserModel.EmailStr = txtEmail.Text.Trim();//邮箱
            _systemUserModel.DepartmentID = Convert.ToInt32(ddlDepart.SelectedValue);
            _systemUserModel.AddTime = DateTime.Now;
            _systemUserModel.AddPeople = Session["truename"].ToString();
            _systemUserModel.RoleID = ddlRoles.SelectedValue;
            _systemUserModel.IsEnter = Convert.ToInt32(ddlEnter.SelectedValue);
            _systemUserModel.IsDelete = Convert.ToInt32(DropDownList4.SelectedValue);
            _systemUserModel.XueLi = DropDownList3.SelectedValue; // 最高学历
            _systemUserModel.JiaRuBenDanWeiTime = txtJiaRuBenDanWeiTime.Text; // 入职时间
            _systemUserModel.SFZSerils = txtIDCard.Text;

            //修改密码
            if (txtPwdSure.Text != "")
            {
                _systemUserModel.UserPwd = DesEncrypt.GetMd5String(txtPwdSure.Text);
            }

            if (!string.IsNullOrEmpty(Request.QueryString["id"]))
            {
                if (!ActionValidator("SystemUserModify")) return;

                if (!_systemUserBll.Update(_systemUserModel)) return;

                var alertStr = "用户信息修改成功！";

                // 如果开启了统一身份认证，则同步修改统一身份认证上的账号密码
                if (ConfigurationManager.AppSettings["HaikanPassport_IfUse"].ToLower() == "true")
                {
                    var api = new HaikanPassportApi();
                    if (api.UpdateUser(_systemUserModel.UserName, _systemUserModel.UserPwd,
                        _systemUserModel.EmailStr) > 0)
                    {
                        alertStr += "统一身份认证系统账号同步更新了！";
                    }
                }
                else
                {
                    alertStr += "统一身份认证系统没有配置，账号不同步！";
                }

                AlertAndParentReoload(alertStr);
            }
            else
            {
                var count = _systemUserBll.GetRecordCount("1=1 and UserName='" + txtJobNumber.Text.Trim() + "'");
                if (count > 0)
                {
                    Alert("该工号已经存在！");
                    return;
                }
                _systemUserModel.UserPwd = DesEncrypt.GetMd5String("123456");
                _systemUserModel.UserName = txtJobNumber.Text.Trim();
                if (ActionValidator("SystemUserAdd"))
                {
                    // 如果开启了统一身份认证，则需要检查账号和邮箱的唯一性
                    if (ConfigurationManager.AppSettings["HaikanPassport_IfUse"].ToLower() == "true")
                    {
                        HaikanPassportApi api = new HaikanPassportApi();
                        if (api.CheckRegister(_systemUserModel.UserName, _systemUserModel.EmailStr, out _) < 1)
                        {
                            Alert("账号或者邮箱存在重复或者错误，请检查后再提交！");
                            return;
                        }
                    }

                    if (_systemUserBll.Add(_systemUserModel) > 0)
                    {
                        var alertStr = "用户信息添加成功！";

                        // 如果开启了统一身份认证，则同步修改统一身份认证上的账号密码
                        if (ConfigurationManager.AppSettings["HaikanPassport_IfUse"].ToLower() == "true")
                        {
                            HaikanPassportApi api = new HaikanPassportApi();
                            if (api.RegisterUser(_systemUserModel.UserName, _systemUserModel.UserPwd,
                                _systemUserModel.EmailStr, out string msg) > 0)
                            {
                                alertStr += "统一身份认证系统账号同步添加了！" + msg;
                            }
                        }

                        //empbll.Add(_employeesModel);
                        AlertAndParentSkip(alertStr, "SystemUserList.aspx");
                    }
                }
            }
        }
        #endregion

        #region 通过身份证自动获取生日
        /// <summary>
        /// 通过身份证自动获取生日
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void txtIDCard_TextChanged(object sender, EventArgs e)
        {
            string sfz = txtIDCard.Text;
            if (sfz.Length < 18)
            {
                Alert("身份证格式不正确，请重新输入");
            }
            else
            {
                txtBirthDay.Text = sfz.Substring(6, 4) + "-" + sfz.Substring(10, 2) + "-" + sfz.Substring(12, 2);
            }
        }
        #endregion
    }
}











