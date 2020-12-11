using Haikan2.DataTools;
using Haikan.SchoolProjectsCore;
using System;
using System.Data;

namespace HaikanSchoolProjects.General.Employee
{
    /// <summary>
    /// 人员列表
    /// </summary>
    public partial class PersonList : SystemPage
    {
        #region 实例化基类
        //人员表
        Haikan.SchoolProjectsCore.MDB.BLL.Employee _employeeBLL = new Haikan.SchoolProjectsCore.MDB.BLL.Employee();
        #endregion

        #region 数据绑定
        /// <summary>
        /// 数据加载
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Bind();
            }
        }

        /// <summary>
        /// 数据绑定
        /// </summary>
        private void Bind()
        {
            var strwhere = " 1=1 ";
            if (TextBox1.Text.Trim() != "")
            {
                strwhere += " and EmployeeName Like '%" + TextBox1.Text.Trim() + "%' ";
            }
            AspNetPager1.RecordCount = _employeeBLL.GetRecordCount(strwhere);
            Label1.Text = AspNetPager1.RecordCount.ToString();
            DataSet query = _employeeBLL.GetListByPage(strwhere, "EID desc", (AspNetPager1.CurrentPageIndex - 1) * AspNetPager1.PageSize + 1, AspNetPager1.CurrentPageIndex * AspNetPager1.PageSize);
            GVData.DataSource = query;
            GVData.DataBind();
        }

        /// <summary>
        /// 分页绑定
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void AspNetPager1_PageChanged(object sender, EventArgs e)
        {
            Bind();
        }

        /// 点击查询 
        protected void BtnSearch_Click(object sender, EventArgs e)
        {
            Bind();
        }
        #endregion

        #region 操作方法
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void BtnDel_Click(object sender, EventArgs e)
        {
            if (ActionValidator("EmployeeDel"))
            {
                string dlist = ControlTools.CheckCbx(GVData, "CheckSelect", "LabVisible");
                if (_employeeBLL.GetModel(int.Parse(dlist)) != null && !_employeeBLL.DeleteList(dlist))
                {
                    Alert("删除选中记录时发生错误！请重新登陆后重试！！");
                }
                else
                {
                    Alert("删除成功！");
                    Bind();
                }
                AddSystemLog("用户删除员工", "删除");
            }
            else
                Alert("没有权限删除");
        }

        /// <summary>
        /// 下拉列表事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            AspNetPager1.PageSize = Convert.ToInt32(DropDownList1.SelectedValue);
            Bind();
        }
        #endregion
    }
}

 










