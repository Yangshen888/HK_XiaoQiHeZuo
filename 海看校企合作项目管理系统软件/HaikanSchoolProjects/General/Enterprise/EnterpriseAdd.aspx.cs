using Haikan.SchoolProjectsCore;
using Haikan.SchoolProjectsCore.MDB.Model;
using System;

namespace HaikanSchoolProjects.General.Enterprise
{
    /// <summary>
    /// 企业添加/修改
    /// </summary>
    public partial class EnterpriseAdd : SystemPage
    {
        #region 实例化基类
        //企业表
        private readonly Haikan.SchoolProjectsCore.MDB.BLL.Eenterprises _eenterprisesBll = new Haikan.SchoolProjectsCore.MDB.BLL.Eenterprises();
        private Eenterprises _eenterprisesModel = new Eenterprises();
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
            //不为空的话，执行修改操作
            if (string.IsNullOrEmpty(Request.QueryString["ID"]))
                return;
            if (!ActionValidator("EnterpriseAdd"))
                return;

            _eenterprisesModel = _eenterprisesBll.GetModel(Convert.ToInt32(Request.QueryString["ID"]));

            if (_eenterprisesModel == null)
                return;

            //赋值企业名称
            TextBox_QY.Text = _eenterprisesModel.EnterpriseName;
            //赋值联系方式
            TextBox_LX.Text = _eenterprisesModel.Contact;
            //赋值备注
            TextBox_Note.Text = _eenterprisesModel.Note;
            //企业状态的赋值
            DropDownList1.SelectedValue = _eenterprisesModel.Audit;
        }

        /// <summary>
        /// 判断显示与隐藏  "修改按钮"
        /// </summary>
        /// <returns></returns>
        public string Gettre2()
        {
            //是否具备审批的权限
            if (ActionValidator("Enterpriseaccredit"))
            {
                return "style='display:inline-block;'";
            }
            else
            {
                return "style='display:none;'";
            }
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
            if (string.IsNullOrEmpty(TextBox_QY.Text.Trim()) || string.IsNullOrEmpty(TextBox_LX.Text.Trim()))
            {
                Alert("信息不能为空！"); return;
            }
            _eenterprisesModel.EnterpriseName = TextBox_QY.Text.Trim();
            _eenterprisesModel.Contact = TextBox_LX.Text.Trim();
            _eenterprisesModel.Note = TextBox_Note.Text.Trim();
            //不具备审批的权限，默认为 ”待审核“
            if (ActionValidator("Enterpriseaccredit"))
            {
                _eenterprisesModel.Audit = DropDownList1.SelectedValue;
            }
            else
            {
                _eenterprisesModel.Audit = "待审核";
            }
            if (!string.IsNullOrEmpty(Request.QueryString["ID"]))
            {
                _eenterprisesModel.EnterpriseID = int.Parse(Request.QueryString["ID"]);
                if (!_eenterprisesBll.Update(_eenterprisesModel))
                    Alert("修改失败！");
                else
                    AlertAndParentSkip("修改成功！", "EnterpriseList.aspx");
            }
            //添加操作
            else
            {
                if (_eenterprisesBll.Add(_eenterprisesModel) > 0)
                     AlertAndParentSkip("添加成功！", "EnterpriseList.aspx");
                else Alert("添加失败！");
            }
        }
        #endregion
    }
}



