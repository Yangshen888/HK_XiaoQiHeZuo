using Haikan2.DataTools;
using Haikan.SchoolProjectsCore;
using System;
using System.Data;

namespace HaikanSchoolProjects.General.Enterprise
{
    /// <summary>
    /// 企业列表
    /// </summary>
    public partial class EnterpriseList : SystemPage
    {
        #region 实例化基类
        //企业表
        private readonly Haikan.SchoolProjectsCore.MDB.BLL.Eenterprises _eenterprisesBll = new Haikan.SchoolProjectsCore.MDB.BLL.Eenterprises();
        #endregion

        #region 数据绑定
        /// <summary>
        /// 页面加载
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.IsPostBack)
                return;
            // SystemUser 在权限表中有这个字段，方可通过，返回true
            if (ActionValidator("EnterpriseShow"))
            {
                // 绑定列表数据
                Bind();
                AddSystemLog("查看用户列表", "查询");
            }
            //判断是否显示添加和删除的按钮
            if (ActionValidator("EnterpriseDel"))
                del.Visible = true;
            else
                del.Visible = false;
            if (ActionValidator("EnterpriseAdd"))
                add.Visible = true;
            else add.Visible = false;

            AddSystemLog("用户查看管理员列表", "查看");
        }

        /// <summary>
        /// 判断显示与隐藏  "修改按钮"
        /// </summary>
        /// <returns></returns>
        public string Gettre2()
        {
            if (ActionValidator("EnterpriseModify"))
            {
                return "style='display:inline-block;'";
            }
            else
            {
                return "style='display:none;'";
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
                strwhere += " and EnterpriseName Like '%" + TextBox1.Text.Trim() + "%' ";
            }
            //计算条数
            AspNetPager1.RecordCount = _eenterprisesBll.GetRecordCount(strwhere);
            Label1.Text = AspNetPager1.RecordCount.ToString();
            DataSet ds = _eenterprisesBll.GetListByPage(strwhere, "EnterpriseID desc", (AspNetPager1.CurrentPageIndex - 1) * AspNetPager1.PageSize + 1, AspNetPager1.CurrentPageIndex * AspNetPager1.PageSize);
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
        /// 删除企业
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void BtnDel_Click(object sender, EventArgs e)
        {
            if (ActionValidator("EnterpriseDel"))
            {
                string dlist = ControlTools.CheckCbx(GVData, "CheckSelect", "LabVisible");
                if (_eenterprisesBll.GetModel(int.Parse(dlist))!=null&& !_eenterprisesBll.DeleteList(dlist))
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
        #endregion
    }
}




