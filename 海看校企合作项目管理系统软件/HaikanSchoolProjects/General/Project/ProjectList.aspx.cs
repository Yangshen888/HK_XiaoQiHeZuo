using Haikan2.DataTools;
using Haikan.SchoolProjectsCore;
using System;

namespace HaikanSchoolProjects.General.Project
{
    /// <summary>
    /// 项目相关人员列表
    /// </summary>
    public partial class ProjectList : SystemPage
    {
        #region 实例化基类
        //项目表
        readonly Haikan.SchoolProjectsCore.MDB.BLL.Project _projectBll = new Haikan.SchoolProjectsCore.MDB.BLL.Project();
        #endregion

        #region 数据绑定
        /// <summary>
        /// 页面加载
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack) return;

            Bind();
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

        /// <summary>
        /// 数据绑定 
        /// </summary>
        private void Bind()
        {
            var strwhere = " 1=1 ";
            if (TextBox1.Text.Trim() != "")
            {
                strwhere += " and ProjectName Like '%" + TextBox1.Text.Trim() + "%' ";
            }

            AspNetPager1.RecordCount = _projectBll.GetRecordCount(strwhere);
            Label1.Text = AspNetPager1.RecordCount.ToString();
            GVData.DataSource = _projectBll.GetListByPage(strwhere, "ProjectID desc", (AspNetPager1.CurrentPageIndex - 1) * AspNetPager1.PageSize + 1, AspNetPager1.CurrentPageIndex * AspNetPager1.PageSize);

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
        #endregion

        #region 事件方法
        /// <summary>
        /// 删除合同
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void BtnDel_Click(object sender, EventArgs e)
        {
            if (ActionValidator("ProjectDel"))
            {
                string dlist = ControlTools.CheckCbx(GVData, "CheckSelect", "LabVisible");
                if (_projectBll.GetModel(int.Parse(dlist))!=null &&  !_projectBll.DeleteList(dlist))
                {
                    Alert("删除选中记录时发生错误！请重新登陆后重试！！");
                }
                else
                {
                    Alert("删除成功！");
                    Bind();
                }

                AddSystemLog("用户删除合同信息", "删除");
            }
            else
                Alert("没有权限删除");
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
        #endregion
    }
}





  
 