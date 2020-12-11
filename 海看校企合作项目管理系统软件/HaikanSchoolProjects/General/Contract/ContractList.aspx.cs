using System;
using System.Data;
using Haikan2.DataTools;
using Haikan.SchoolProjectsCore;

namespace HaikanSchoolProjects.General.Contract
{
    /// <summary>
    /// 合同列表
    /// </summary>
    public partial class ContractList : SystemPage
    {
        #region 实例化基类
        /// <summary>
        /// 合同表
        /// </summary>
        private readonly Haikan.SchoolProjectsCore.MDB.BLL.Contract _contractBll = new Haikan.SchoolProjectsCore.MDB.BLL.Contract();
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
                strwhere += " and ContractName Like '%" + TextBox1.Text.Trim() + "%' ";
            }
            if (!string.IsNullOrEmpty(Request.QueryString["name"]))
            {
                strwhere += " and EnterpriseName Like '%" + Request.QueryString["name"] + "%' ";
            }
            //计算条数
            AspNetPager1.RecordCount = _contractBll.GetRecordCount(strwhere);
            Label1.Text = AspNetPager1.RecordCount.ToString();
            DataSet ds = _contractBll.GetListByPage(strwhere, "CID desc", (AspNetPager1.CurrentPageIndex - 1) * AspNetPager1.PageSize + 1, AspNetPager1.CurrentPageIndex * AspNetPager1.PageSize);
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

        #region 操作方法
        /// <summary>
        /// 删除合同
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void BtnDel_Click(object sender, EventArgs e)
        {
             if (ActionValidator("ContractDel"))
             {
                 string dlist = ControlTools.CheckCbx(GVData, "CheckSelect", "LabVisible");
                 if (_contractBll.GetModel(int.Parse(dlist)) != null && !_contractBll.DeleteList(dlist))
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
             else Alert("没有权限删除");
        }
        #endregion
    }
}




