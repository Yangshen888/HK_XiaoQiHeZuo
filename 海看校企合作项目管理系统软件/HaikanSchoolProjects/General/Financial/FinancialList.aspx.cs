using System;
using System.Data;
using Haikan2.DataTools;
using Haikan.SchoolProjectsCore;

namespace HaikanSchoolProjects.General.Financial
{
    /// <summary>
    /// 财务信息
    /// </summary>
    public partial class FinancialList : SystemPage
    {
        #region 实例化基类
        //财务表
        private Haikan.SchoolProjectsCore.MDB.BLL.Financial _financialBLL =new Haikan.SchoolProjectsCore.MDB.BLL.Financial();
        #endregion

        #region 数据绑定
        /// <summary>
        /// 页面加载
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
                strwhere += " and ProjectName Like '%" + TextBox1.Text.Trim() + "%' ";
            }
            //计算条数
            AspNetPager1.RecordCount = _financialBLL.GetRecordCount(strwhere);
            Label1.Text = AspNetPager1.RecordCount.ToString();
            DataSet ds = _financialBLL.GetListByPage(strwhere, "FID desc", (AspNetPager1.CurrentPageIndex - 1) * AspNetPager1.PageSize + 1, AspNetPager1.CurrentPageIndex * AspNetPager1.PageSize);
            //数据绑定
            GVData.DataSource = ds;
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

        #region 操作方法
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
        ///  点击查询
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void BtnSearch_Click(object sender, EventArgs e)
        {
            Bind();
        }

        /// <summary>
        /// 删除财务信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void del_OnServerClick(object sender, EventArgs e)
        {
            if (ActionValidator("FinancialDel"))
            {
                string dlist = ControlTools.CheckCbx(GVData, "CheckSelect", "LabVisible");
                if (_financialBLL.GetModel(int.Parse(dlist))!=null &&!_financialBLL.DeleteList(dlist))
                {
                    Alert("删除选中记录时发生错误！请重新登陆后重试！！");
                }
                else
                {
                    Alert("删除成功！");
                    Bind();
                }
                AddSystemLog("用户删除财务信息", "删除");
            }
            else
                Alert("没有权限删除");
        }
        #endregion
    }
}

