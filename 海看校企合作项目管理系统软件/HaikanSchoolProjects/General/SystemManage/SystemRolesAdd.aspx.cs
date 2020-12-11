using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using Haikan2.DataTools;
using Haikan.SchoolProjectsCore;
using System.Globalization;

namespace HaikanSchoolProjects.General.SystemManage
{
    /// <summary>
    /// 角色权限编辑
    /// </summary>
    public partial class SystemRolesAdd : SystemPage
    {
        #region 实例化基类
        //角色权限
        Haikan.SchoolProjectsCore.MDB.BLL.SystemRoles _systemRolesBll = new Haikan.SchoolProjectsCore.MDB.BLL.SystemRoles();
        Haikan.SchoolProjectsCore.MDB.Model.SystemRoles _systemRolesModel = new Haikan.SchoolProjectsCore.MDB.Model.SystemRoles();
        //菜单管理
        private Haikan.SchoolProjectsCore.MDB.BLL.SystemMenu _systemMenuBll = new Haikan.SchoolProjectsCore.MDB.BLL.SystemMenu();
        Haikan.SchoolProjectsCore.MDB.Model.SystemMenu _systemMenuModel = new Haikan.SchoolProjectsCore.MDB.Model.SystemMenu();
        #endregion
        #region 页面加载
        /// <summary>
        /// 页面加载
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.IsPostBack) return;

            // 修改
            if (Request.QueryString["ID"] != null)
            {
                var id = Convert.ToInt32(Request.QueryString["ID"]);
                if (id <= 0) return;

                // 获取数据
                _systemRolesModel = _systemRolesBll.GetModel(id);
                if (_systemRolesModel == null) return;

                tbRoleName.Text = _systemRolesModel.RoleName; // 角色名称
                tbRoleName.Enabled = false; // 如果是修改，禁止编辑角色名称
                tbRemarks.Text = _systemRolesModel.Remarks;   // 备注信息

                // 绑定数据
                Bind();

                // 对控件进行赋值
                foreach (Control item in MyMenus.Items)
                {
                    var checklist = item.FindControl("MyCheckBoxList") as CheckBoxList;
                    ControlTools.GetCheckList(checklist, _systemRolesModel.Actionstr);
                }
            }
            else // 添加
            {
                Bind();
            }
        }
        #endregion
        #region 数据绑定
        /// <summary>
        /// 绑定选择框
        /// </summary>
        public void Bind()
        {
            // 首先绑定目录
            var dsMenu = _systemMenuBll.GetList("category = '目录'");

            MyMenus.DataSource = dsMenu;
            MyMenus.DataBind();

            // 然后绑定页面
            foreach (Control item in MyMenus.Items)
            {
                // checkbox容器，用来装载
                if (!(item.FindControl("MyCheckBoxList") is CheckBoxList checklist)) return;

                // 隐藏域，当前目录的ID
                if (!(item.FindControl("hfModuleID") is HiddenField hidId)) return;

                // 查询所有二级页面
                var ds = _systemMenuBll.GetList("ParentID=" + Convert.ToInt32(hidId.Value));
                _systemMenuModel = _systemMenuBll.GetModel(Convert.ToInt32(hidId.Value));

                if (ds.Tables[0].Rows.Count <= 0) continue;
                for (var i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    for (var j = 0; j < 12; j++)
                    {
                        switch (j)
                        {
                            case 0:
                                checklist.Items.Add(new ListItem(_systemMenuModel.FullName + "--" + ds.Tables[0].Rows[i]["FullName"] + "--" + "查看", _systemMenuModel.MenuRole + "||" + ds.Tables[0].Rows[i]["MenuRole"] + "Show||" + ds.Tables[0].Rows[i]["MenuRole"] + "List||" + ds.Tables[0].Rows[i]["MenuRole"]));
                                break;
                            case 1:
                                checklist.Items.Add(new ListItem("添加", ds.Tables[0].Rows[i]["MenuRole"] + "Add"));
                                break;
                            case 2:
                                checklist.Items.Add(new ListItem("修改", ds.Tables[0].Rows[i]["MenuRole"] + "Modify"));
                                break;
                            case 3:
                                checklist.Items.Add(new ListItem("删除", ds.Tables[0].Rows[i]["MenuRole"] + "Del"));
                                break;
                            case 4:
                                checklist.Items.Add(new ListItem("导入", ds.Tables[0].Rows[i]["MenuRole"] + "Import"));
                                break;
                            case 5:
                                checklist.Items.Add(new ListItem("导出", ds.Tables[0].Rows[i]["MenuRole"] + "Export"));
                                break;
                            case 6:
                                checklist.Items.Add(new ListItem("打印", ds.Tables[0].Rows[i]["MenuRole"] + "Print"));
                                break;
                            case 7:
                                checklist.Items.Add(new ListItem("查询", ds.Tables[0].Rows[i]["MenuRole"] + "Search"));
                                break;
                            case 8:
                                checklist.Items.Add(new ListItem("刷新", ds.Tables[0].Rows[i]["MenuRole"] + "Refresh"));
                                break;
                            case 9:
                                checklist.Items.Add(new ListItem("审批", ds.Tables[0].Rows[i]["MenuRole"] + "Accredit"));
                                break;
                            case 10:
                                checklist.Items.Add(new ListItem("查看全部", ds.Tables[0].Rows[i]["MenuRole"] + "AllShow"));
                                break;
                        }
                    }
                }
            }
        }
        #endregion
        #region 事件
        /// <summary>
        /// 点击提交
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void BtnSubmit_Click(object sender, EventArgs e)
        {
            if (tbRoleName.Text != "")
            {
                if (Request.QueryString["ID"] != null)
                {
                    var id = Convert.ToInt32(Request.QueryString["ID"]);
                    if (id > 0) // 修改
                    {
                        _systemRolesModel = _systemRolesBll.GetModel(int.Parse(Request.QueryString["ID"]));

                        _systemRolesModel.RoleName = tbRoleName.Text;
                        _systemRolesModel.Remarks = tbRemarks.Text;

                        var actionStr = "";

                        foreach (Control item1 in MyMenus.Items)
                        {
                            // 页面checkbox集合对象
                            var myCheckBoxList = item1.FindControl("MyCheckBoxList") as CheckBoxList;

                            // 添加子项的权限
                            actionStr += ControlTools.GetStringFromCheckList(myCheckBoxList);
                        }

                        _systemRolesModel.Actionstr = actionStr;
                        _systemRolesBll.Update(_systemRolesModel);

                        // 写系统日志
                        AddSystemLog("用户修改角色信息，角色名为：" + tbRoleName.Text + "，权限字符串为：" + actionStr, "修改");

                        // 提示框
                        AlertAndParentSkip("角色信息修改成功！", "SystemRolesList.aspx");
                    }
                }
                else // 添加
                {
                    // 如果是新增，则要判断是否存在同名的角色名称
                    var ds = _systemRolesBll.GetList("RoleName='" + tbRoleName.Text + "'");

                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        Alert("该角色名已经存在，请更换其他名称！");
                    }
                    else
                    {
                        // 获取控件信息
                        _systemRolesModel.RoleName = tbRoleName.Text; // 角色名称
                        _systemRolesModel.Remarks = tbRemarks.Text; // 备注信息
                        _systemRolesModel.AddTime = DateTime.Now.ToString(CultureInfo.InvariantCulture); // 添加时间
                        _systemRolesModel.AddPeople = Session["TrueName"].ToString(); // 添加人真实姓名

                        var actionStr = "";

                        foreach (Control item1 in MyMenus.Items)
                        {
                            var checklist1 = item1.FindControl("MyCheckBoxList") as CheckBoxList;
                            actionStr += ControlTools.GetStringFromCheckList(checklist1);
                        }

                        _systemRolesModel.Actionstr = actionStr;
                        _systemRolesModel.IsDelete = 1;
                        _systemRolesBll.Add(_systemRolesModel);

                        //写系统日志
                        AddSystemLog("用户添加角色信息，角色名为：" + tbRoleName.Text, "添加");

                        AlertAndParentSkip("角色信息添加成功！", "SystemRolesList.aspx");
                    }
                }
            }
            else
            {
                Alert("请输入角色名称！");
            }
        }
        /// <summary>
        /// 返回
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnReturn_Click(object sender, EventArgs e)
        {
            Response.Redirect("SystemRolesList.aspx");
        }

        #endregion
        #region 方法
        /// <summary>
        /// 将没有值的项目禁用掉
        /// </summary>
        /// <param name="cbl"></param>
        public void BindCheckBoxList(CheckBoxList cbl)
        {
            for (int i = 0; i < cbl.Items.Count; i++)
            {
                if (cbl.Items[i].Text.Trim() == "")
                {
                    cbl.Items[i].Enabled = false;
                    cbl.Items[i].Attributes.CssStyle.Add("DISPLAY", "none");
                }
            }
        }
        #endregion
    }
}