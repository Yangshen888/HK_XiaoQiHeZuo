using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using Haikan2.DataTools;
using Haikan2.DBHelper;
using Haikan2.ExcelTools;
using Haikan.SchoolProjectsCore;

namespace HaikanSchoolProjects.General.SystemManage
{
    /// <summary>
    /// 角色权限列表
    /// </summary>
    public partial class SystemRolesList : SystemPage
    {
        #region 实例化基类
        //角色权限
        readonly Haikan.SchoolProjectsCore.MDB.BLL.SystemRoles _systemRolesBll = new Haikan.SchoolProjectsCore.MDB.BLL.SystemRoles();
        #endregion
        #region 页面加载
        /// <summary>
        /// 页面加载
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (ActionValidator("SystemRolesList"))
                {
                    // 绑定数据
                    Bind();
                    ImgBtnsearch.Visible = ActionValidator("SystemRolessearch");
                    ImgBtnAdd.Visible = ActionValidator("SystemRolesAdd");
                    ImgBtnDel.Visible = ActionValidator("SystemRolesDel");
                }
            }
        }
        #endregion
        #region  绑定数据
        /// <summary>
        /// 绑定数据
        /// </summary>
        public void Bind()
        {
            string strWhere = " 1 = 1  ";
            if (!string.IsNullOrEmpty(tbRoleName.Text)) //角色名称查询
            {
                strWhere += " And RoleName Like '%" + tbRoleName.Text + "%'";
            }
            //按ID倒序排列
            AspNetPager1.RecordCount = _systemRolesBll.GetRecordCount(strWhere);
            Label1.Text = AspNetPager1.RecordCount.ToString();
            GVData.DataSource = _systemRolesBll.GetListByPage(strWhere, "id desc", (AspNetPager1.CurrentPageIndex - 1) * AspNetPager1.PageSize + 1, AspNetPager1.CurrentPageIndex * AspNetPager1.PageSize);
            GVData.DataBind();
        }
        #endregion
        #region gridview显示的时候进行的处理
        /// <summary>
        /// gridview显示的时候进行的处理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void GVData_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            ControlTools.GridViewRowDataBound(e);
        }
        #endregion
        #region 事件
        /// <summary>
        /// 直接跳转到指定的按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void ButtonGo_Click(object sender, ImageClickEventArgs e)
        {
            Bind();
        }
        /// <summary>
        /// 点击上一页，下一页，首页，尾页
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void PagerButtonClick(object sender, ImageClickEventArgs e)
        {
            PagerButtonClick(sender, e, GVData);
            Bind();
        }
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
        /// 点击导出
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void ImgBtnExport_Click(object sender, ImageClickEventArgs e)
        {
           if (ActionValidator("SystemRolesExpert"))
           {
                DataTable dt = DbHelperSql.GetDataTable("SystemRoles", "RloeName,Remarks", (string.IsNullOrEmpty(tbRoleName.Text) ? string.Empty : " RoleName Like '%" + tbRoleName.Text + "%' "), "ID desc").Tables[0]; //导出;
                dt.Columns[0].ColumnName = "角色名称";
                dt.Columns[1].ColumnName = "备注说明";
                ExcelManage.HaikanExcelExport("角色信息列表", dt);
            }
        }

        /// <summary>
        /// 点击修改
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void ImgBtnModify_Click(object sender, ImageClickEventArgs e)
        {
            if (ActionValidator("SystemRolesModify"))
            {
                string checkStr = ControlTools.CheckCbx(GVData, "CheckSelect", "LabVisible");
                string[] checkStrArray = checkStr.Split(',');
                if (checkStrArray[0] == "")
                {
                    Alert("选择项不能为空！");
                    return;
                }
                Response.Redirect("SystemRolesAdd.aspx?ID=" + checkStrArray[0]);
            }
        }
        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void imgBtnAdd_Click(object sender, ImageClickEventArgs e)
        {
            if (ActionValidator("SystemRolesAdd"))
            {
                Response.Redirect("SystemRolesAdd.aspx");
            }
        }
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void BtnDel_Click(object sender, EventArgs e)
        {
            string dlist = ControlTools.CheckCbx(GVData, "CheckSelect", "LabVisible");
            if (_systemRolesBll.GetModel(int.Parse(dlist)) ==null)
            {
                Alert("该项已经不存在");return;
            }
            string[] listid = dlist.Split(new [] { ',' }, StringSplitOptions.RemoveEmptyEntries);
            int id = 0;
            if (listid.Length > 0)
            {
                for (int i = 0; i < listid.Length; i++)
                {
                    if (new Haikan.SchoolProjectsCore.MDB.BLL.SystemUser().GetList("RoleID=" + listid[i]).Tables[0].Rows.Count > 0)
                    {
                        id += 1;
                    }
                }
            }
            if (id <= 0)
            {
                _systemRolesBll.DeleteList(dlist);
                Bind();
            }
            else
            {
                Alert("所选部门中有存在用户的部门，不能删除，请重新选择！");
            }
        }
        #endregion
        #region 分页
        //分页
        protected void AspNetPager1_PageChanged(object sender, EventArgs e)
        {
            Bind();
        }
        #endregion
        /// <summary>
        /// 判断显示与隐藏
        /// </summary>
        /// <returns></returns>
        public string Gettre2()
        {
            if (ActionValidator("SystemRolesModify") )
            {
                return "style='display:inline-block;'";
           }
           else
            {
             return "style='display:none;'";
           }
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



