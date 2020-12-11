using System;
using Haikan2.DBHelper;
using Haikan.SchoolProjectsCore;

namespace HaikanSchoolProjects.General.Financial
{
    /// <summary>
    /// 添加管理员
    /// </summary>
    public partial class FinancialAdd : SystemPage
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
            if (IsPostBack) return;
            if (ActionValidator("FinancialAdd"))
            {
                var query = DbHelperSql.Query("select DISTINCT EnterpriseName from  Eenterprises where Audit='已通过'");
                DropDownList_qy.DataSource = query;
                DropDownList_qy.DataTextField = "EnterpriseName";
                DropDownList_qy.DataValueField = "EnterpriseName";
                DropDownList_qy.DataBind();

                var entity = DbHelperSql.Query("select DISTINCT ProjectName from  Project ");
                DropDownListXM.DataSource = entity;
                DropDownListXM.DataTextField = "ProjectName";
                DropDownListXM.DataValueField = "ProjectName";
                DropDownListXM.DataBind();
                if (!string.IsNullOrEmpty(Request.QueryString["FID"]))
                {
                    var data = DbHelperSql.Query("select * from Financial where FID='" + Request.QueryString["FID"] + "'");
                    txtTrueMoney.Text = data.Tables[0].Rows[0]["PayMoney"].ToString();
                    FZperson.Text = data.Tables[0].Rows[0]["Person"].ToString();
                    DropDownList2.SelectedValue = data.Tables[0].Rows[0]["IsPay"].ToString();
                    time.Text = data.Tables[0].Rows[0]["SuccessfulTime"].ToString();
                    note.Text = data.Tables[0].Rows[0]["Note"].ToString();
                    //项目
                    DropDownListXM.SelectedValue = data.Tables[0].Rows[0]["ProjectName"].ToString();
                    //企业
                    DropDownList_qy.SelectedValue = data.Tables[0].Rows[0]["EnterpriseName"].ToString(); 
                }
            }
            else AlertAndParentSkip("没有权限", "FinancialList");
        }
        #endregion

        #region 操作方法
        /// <summary>
        /// 提交
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void ButSubmit_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtTrueMoney.Text.Trim()) || string.IsNullOrEmpty(FZperson.Text.Trim()) || string.IsNullOrEmpty(time.Text.Trim()))
            {
                Alert("金额，负责人，成交时间都不能为空！");
                return;
            }

            var finacialModel = new Haikan.SchoolProjectsCore.MDB.Model.Financial()
            {
                ProjectName = DropDownListXM.SelectedValue,
                EnterpriseName = DropDownList_qy.SelectedValue,
                //状态
                IsPay = DropDownList2.SelectedValue,
                //成交时间
                SuccessfulTime = time.Text.Trim(),
                //负责人
                Person = FZperson.Text.Trim(),
                //金额
                PayMoney = txtTrueMoney.Text.Trim(),
                //得到用户名
                SystemUser = Session["username"].ToString(),
                //备注
                Note = note.Text.Trim(),
                TimeStr = DateTime.Now.ToString("yyyy - MM - dd HH: mm:ss")
            };

            if (!string.IsNullOrEmpty(Request.QueryString["FID"]))
            {
                finacialModel.FID = int.Parse(Request.QueryString["FID"]);
                if (_financialBLL.Update(finacialModel)) AlertAndParentReoload("修改成功！");
                else Alert("修改失败！");
            }
            else
            {
                if(_financialBLL.Add(finacialModel)>0) AlertAndParentReoload("添加成功！");
                else Alert("添加失败！");
            }
        }
        #endregion
    }
}





