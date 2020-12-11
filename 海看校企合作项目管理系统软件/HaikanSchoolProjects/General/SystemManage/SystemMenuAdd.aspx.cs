using Haikan.SchoolProjectsCore;
using System;
using System.Data;
using System.Web.UI.WebControls;

namespace HaikanSchoolProjects.General.SystemManage
{
    /// <summary>
    /// 菜单添加/修改
    /// </summary>
    public partial class MenuAdd : SystemPage
    {
        #region 实例化基类
        //菜单表
        public Haikan.SchoolProjectsCore.MDB.BLL.SystemMenu SystemMenuBll = new Haikan.SchoolProjectsCore.MDB.BLL.SystemMenu();
        public Haikan.SchoolProjectsCore.MDB.Model.SystemMenu SystemMenuModel = new Haikan.SchoolProjectsCore.MDB.Model.SystemMenu();
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
            
            //绑定下拉框数据
            DdlBind();
            //绑定数据
            Bind();
        }

        /// <summary>
        /// 绑定数据
        /// </summary>
        protected void Bind()
        {
            if (Request.QueryString["ID"] == null)  return;
            
            SystemMenuModel = SystemMenuBll.GetModel(Convert.ToInt32(Request.QueryString["ID"]));
            //模块名称
            txtFullName.Text = SystemMenuModel.FullName;
            //父级菜单ID
            DDPLastModel.SelectedValue = SystemMenuModel.ParentID.ToString();
            //分类
            txtCategory.Text = SystemMenuModel.Category;
            //地址
            txtLocation.Text = SystemMenuModel.Location;
            //显示顺序
            txtSortCode.Text = SystemMenuModel.SortCode;
            //级别层次
            txtLevel.Text = SystemMenuModel.Level;
            //模板代码
            txtModuleID.Text = Request.QueryString["ID"];
            //链接目标
            ddlTarget.SelectedValue = SystemMenuModel.Target;
            //分类
            txtCategory.Text = SystemMenuModel.Category;
            //图片
            txtIcon.Text = SystemMenuModel.Icon;
            //说明
            txtRemark.Text = SystemMenuModel.Remark;
            //权限字符串
            txtMenuRole.Text = SystemMenuModel.MenuRole;
        }

        /// <summary>
        /// 绑定下拉框数据 上级模块
        /// </summary>
        public void DdlBind()
        {
            DataSet ds = SystemMenuBll.GetList("Category='目录'");
            DDPLastModel.DataSource = ds;
            DDPLastModel.DataTextField = "FullName";
            DDPLastModel.DataValueField = "ModuleID";
            DDPLastModel.DataBind();
            DDPLastModel.Items.Insert(0, new ListItem("--请选择--", "0"));
        }
        #endregion

        #region 事件
        /// <summary>
        /// 返回
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void BtnReturn_Click(object sender, EventArgs e)
        {
            Response.Redirect("menu.aspx");
        }

        /// <summary>
        /// 提交
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void BtnSubmit_Click(object sender, EventArgs e)
        {
            if (!Page.IsValid) { return; }
            {
                if (Request.QueryString["id"] == null)
                {
                    //模块名称
                    SystemMenuModel.FullName = txtFullName.Text;
                    SystemMenuModel.ParentID = Convert.ToInt32(DDPLastModel.SelectedValue);
                    //Icon图标
                    SystemMenuModel.Icon = txtIcon.Text;
                    //模块分类
                    SystemMenuModel.Category = txtCategory.Text;
                    //连接目标
                    SystemMenuModel.Target = ddlTarget.SelectedValue;
                    //级别层次
                    SystemMenuModel.Level = txtLevel.Text;
                    SystemMenuModel.Remark = txtRemark.Text;
                    //显示顺序
                    SystemMenuModel.SortCode = txtSortCode.Text;
                    //访问地址
                    SystemMenuModel.Location = txtLocation.Text;
                    //权限字符串
                    SystemMenuModel.MenuRole = txtMenuRole.Text;
                    //添加一条数据                                
                    if (SystemMenuBll.Add(SystemMenuModel) > 0)
                    {
                        //写系统日志
                        AddSystemLog("用户添加菜单信息", "添加");
                        AlertAndParentSkip("菜单信息添加成功!", "SystemMenuList.aspx");
                    }
                }
                else
                {
                    SystemMenuModel = SystemMenuBll.GetModel(Convert.ToInt32(Request.QueryString["id"]));
                    SystemMenuModel.FullName = txtFullName.Text;
                    SystemMenuModel.ParentID = Convert.ToInt32(DDPLastModel.SelectedValue);
                    //Icon图标
                    SystemMenuModel.Icon = txtIcon.Text;
                    //模块分类
                    SystemMenuModel.Category = txtCategory.Text;
                    //连接目标
                    SystemMenuModel.Target = ddlTarget.SelectedValue;
                    //级别层次
                    SystemMenuModel.Level = txtLevel.Text;
                    //显示顺序
                    SystemMenuModel.SortCode = txtSortCode.Text;
                    SystemMenuModel.Remark = txtRemark.Text;
                    //访问地址
                    SystemMenuModel.Location = txtLocation.Text;
                    //权限字符串
                    SystemMenuModel.MenuRole = txtMenuRole.Text;
                    //更新一条数据
                    if (SystemMenuBll.Update(SystemMenuModel))
                    {
                        //写系统日志
                        AddSystemLog("用户修改菜单信息", "修改");
                        AlertAndParentSkip("菜单信息修改成功!", "SystemMenuList.aspx");
                    }
                }
            }
        }
        #endregion
    }
}