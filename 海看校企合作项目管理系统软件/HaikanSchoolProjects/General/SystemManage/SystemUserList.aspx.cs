using Haikan2.DataTools;
using Haikan2.DBHelper;
using System;
using System.Data;
using System.Web.UI;
using Haikan.SchoolProjectsCore;
using System.Web.UI.WebControls;

namespace HaikanSchoolProjects.General.SystemManage
{
    /// <summary>
    /// 系统管理员列表
    /// </summary>
    public partial class SystemUserList : SystemPage
    {
        #region 实例化基类
        // 部门
        Haikan.SchoolProjectsCore.MDB.BLL.Department _departBll = new Haikan.SchoolProjectsCore.MDB.BLL.Department();
        Haikan.SchoolProjectsCore.MDB.Model.Department _departModel = new Haikan.SchoolProjectsCore.MDB.Model.Department();

        // 用户
        Haikan.SchoolProjectsCore.MDB.BLL.SystemUser _userBll = new Haikan.SchoolProjectsCore.MDB.BLL.SystemUser();
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

            // 绑定部门
            BindDepartment();

            if (!ActionValidator("SystemUserList")) return;

            // 绑定列表数据
            Bind();

            AddSystemLog("查看用户列表", "查询");

            ImgBtnsearch.Visible = ActionValidator("SystemUserSearch");
            ImgBtnAdd.Visible = ActionValidator("SystemUserAdd");
            ImgBtnDel.Visible = ActionValidator("SystemUserDel");
        }

        /// <summary>
        /// 绑定部门
        /// </summary>
        private void BindDepartment()
        {
            var ds = _departBll.GetList("1=1 and IsDelete !=2");

            ddlDepartment.DataSource = ds;
            ddlDepartment.DataTextField = "DepartmentName";
            ddlDepartment.DataValueField = "ID";
            ddlDepartment.DataBind();

            ddlDepartment.Items.Insert(0, "所有部门");
        }

        /// <summary>
        /// 获取状态
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        protected static string GetEnter(string id)
        {
            var name = "禁止";

            if (id == "0")
            {
                name = "允许";
            }

            return name;
        }

        /// <summary>
        /// 数据绑定
        /// </summary>
        private void Bind()
        {
            var strWhere = " 1=1";
            if (ddlDepartment.SelectedIndex != 0)
            {
                strWhere += " and DepartmentID =" + ddlDepartment.SelectedValue;
            }

            if (TextBox1.Text.Trim() != "")
            {
                strWhere += " and TrueName Like '%" + TextBox1.Text + "%' ";
            }

            if (DropDownList2.Text == "在职")
            {
                strWhere = " IsDelete=1 and " + strWhere;
            }
            else
            {
                strWhere = " IsDelete=0 and " + strWhere;
            }

            AspNetPager1.RecordCount = _userBll.GetRecordCount(strWhere);
            Label1.Text = AspNetPager1.RecordCount.ToString();

            // 在职
            GVData.DataSource = _userBll.GetListByPage(strWhere, "ID desc", (AspNetPager1.CurrentPageIndex - 1) * AspNetPager1.PageSize + 1, AspNetPager1.CurrentPageIndex * AspNetPager1.PageSize);
            GVData.DataBind();
        }
        #endregion

        /// <summary>
        /// 点击查询
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void BtnSearch_Click(object sender, EventArgs e)
        {
            Bind();
        }

        /// <summary>
        /// 删除用户
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void BtnDel_Click(object sender, EventArgs e)
        {
            if (ActionValidator("SystemUserDel"))
            {
                string dlist = ControlTools.CheckCbx(this.GVData, "CheckSelect", "LabVisible");
                if (!_userBll.DeleteList(dlist))
                {
                    Alert("删除选中记录时发生错误！请重新登陆后重试！！");
                }
                else
                {
                    Alert("删除成功！");
                    // 重新绑定数据
                    Bind();
                }
                AddSystemLog("用户删除用户信息", "删除");
            }
        }

        /// <summary>
        /// 角色
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        protected string Leixing(string id)
        {
            string name = "";
            if (id != "")
            {
                DataSet set = DbHelperSql.Query("select * from SystemRoles where ID='" + id + "'");
                if (set.Tables[0].Rows.Count > 0)
                {
                    name += set.Tables[0].Rows[0]["RoleName"].ToString();
                }

            }

            return name;
        }
        /// <summary>
        /// 修改，默认修改选中的第一个复选框的条目
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void ImgBtnModify_Click(object sender, ImageClickEventArgs e)
        {
            string checkStr = ControlTools.CheckCbx(this.GVData, "CheckSelect", "LabVisible");
            string[] checkStrArray = checkStr.Split(',');

            // 默认修改选中的第一个复选框的条目
            Response.Redirect("SystemUserAdd.aspx?ID=" + checkStrArray[0] + "&TypeID=All");
        }

        /// <summary>
        /// 显示部门
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        protected string DepartmentShow(string id)
        {
            if (id.Trim() != "")
            {
                _departModel = _departBll.GetModel(Convert.ToInt32(id));
                if (_departModel != null)
                {
                    return _departModel.DepartmentName;
                }
            }
            return "";
        }

        /// <summary>
        /// 分页
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void AspNetPager1_PageChanged(object sender, EventArgs e)
        {
            Bind();
        }

        /// <summary>
        /// 判断显示与隐藏
        /// </summary>
        /// <returns></returns>
        public string CheckModify()
        {
            return ActionValidator("SystemRolesModify") ? "style='display:inline-block;'" : "style='display:none;'";
        }
        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            AspNetPager1.PageSize = Convert.ToInt32(DropDownList1.SelectedValue);
            Bind();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Bind();
        }
        protected void GVData_PreRender(object sender, EventArgs e)
        {
            if (GVData.Rows.Count > 0)
            {
                // 使用<TH>替换<TD>
                GVData.UseAccessibleHeader = true;

                //This will add the <thead> and <tbody> elements
                //HeaderRow将被<thead>包裹，数据行将被<tbody>包裹
                GVData.HeaderRow.TableSection = TableRowSection.TableHeader;

                // FooterRow将被<tfoot>包裹
                GVData.FooterRow.TableSection = TableRowSection.TableFooter;
            }
        }
    }
}