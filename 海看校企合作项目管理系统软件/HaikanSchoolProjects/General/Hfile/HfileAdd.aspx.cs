using System;
using Haikan.SchoolProjectsCore;
using Haikan.SchoolProjectsCore.MDB.Model;

namespace HaikanSchoolProjects.General.Hfile
{
    /// <summary>
    /// 文件添加
    /// </summary>
    public partial class HfileAdd : SystemPage
    {
        #region 实例化基类
        //文件表
        private Haikan.SchoolProjectsCore.MDB.BLL.HFile _hFileBLL = new Haikan.SchoolProjectsCore.MDB.BLL.HFile();
        private HFile hFileModel = new HFile();
        #endregion

        #region 数据绑定
        /// <summary>
        /// 页面加载
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            TextBox_E.Text = Session["name"].ToString();
        }
        #endregion

        #region 操作方法
        /// <summary>
        /// 提交
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void BtnSubmit_Click(object sender, EventArgs e)
        {
            hFileModel.InvoiceFile = FpFile3.Value;//发票文件
            hFileModel.EnterpriseFile = qyFile1.Value;//企业文件
            hFileModel.ContractFile = HtFile2.Value;//合同文件
            hFileModel.ProjectFile = xmzl4.Value;//项目资料
            hFileModel.EnterpriseName = TextBox_E.Text.Trim();//企业名称
            if (_hFileBLL.Add(hFileModel) > 0)
            {
                AlertAndParentReoload("添加成功！");
            }
            else Alert("添加失败！");
        }
        #endregion
    }
}