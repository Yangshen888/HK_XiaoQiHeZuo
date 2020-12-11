using System;
using Haikan2.DBHelper;
using Haikan.SchoolProjectsCore;

namespace HaikanSchoolProjects.General.Contract
{
    /// <summary>
    /// 合同添加/修改
    /// </summary>
    public partial class ContractAdd : SystemPage
    {
        #region 实例化基类
        //合同表
        private Haikan.SchoolProjectsCore.MDB.BLL.Contract _contractBll = new Haikan.SchoolProjectsCore.MDB.BLL.Contract();
        private Haikan.SchoolProjectsCore.MDB.Model.Contract _contractModel = new Haikan.SchoolProjectsCore.MDB.Model.Contract();
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
                if (ActionValidator("Contract"))
                {
                    var query = DbHelperSql.Query("select DISTINCT EnterpriseName from  Eenterprises where Audit='已通过'");
                    DropDownList_qy.DataSource = query;
                    DropDownList_qy.DataTextField = "EnterpriseName";
                    DropDownList_qy.DataValueField = "EnterpriseName";
                    DropDownList_qy.DataBind();
                    if (!string.IsNullOrEmpty(Request.QueryString["ContractName"]))
                    {
                        var entity = DbHelperSql.Query("select * from Contract where ContractName='" + Request.QueryString["ContractName"] + "'");
                        txtTrueName.Text = entity.Tables[0].Rows[0]["ContractName"].ToString();
                        time.Text = entity.Tables[0].Rows[0]["CInformation"].ToString();//签订时间
                        time2.Text = entity.Tables[0].Rows[0]["LastTime"].ToString();//到期时间
                        TextBox_JE.Text = entity.Tables[0].Rows[0]["Money"].ToString();//金额
                        txtj.Text = entity.Tables[0].Rows[0]["ConsigneeA"].ToString();
                        txty.Text = entity.Tables[0].Rows[0]["ConsigneeB"].ToString();
                        txtb.Text = entity.Tables[0].Rows[0]["Note"].ToString();
                        DropDownList_qy.SelectedValue = entity.Tables[0].Rows[0]["EnterpriseName"].ToString();
                    }
                }
                else
                    AlertAndParentSkip("没有权限", "ContractList");
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
            if (string.IsNullOrEmpty(txtTrueName.Text) || string.IsNullOrEmpty(txtj.Text) || string.IsNullOrEmpty(txty.Text))
            {
                Alert("合同名称，签订人不能为空！"); return;
            }
            _contractModel.EnterpriseName = DropDownList_qy.SelectedValue;  //所属企业的名称
            _contractModel.ContractName = txtTrueName.Text.Trim();  //合同名称
            _contractModel.CInformation = time.Text.Trim();//签订的日期
            _contractModel.LastTime = time2.Text.Trim();//到期时间
            _contractModel.Money = TextBox_JE.Text.Trim();//金额
            _contractModel.ConsigneeA = txtj.Text.Trim();//签订人 甲
            _contractModel.ConsigneeB = txty.Text.Trim();//签订人 乙
            _contractModel.Note = txtb.Text.Trim();//备注
            if (!string.IsNullOrEmpty(Request.QueryString["ContractName"]))
            {
                var aa = DbHelperSql.Query("select * from Contract where ContractName='" +
                                           Request.QueryString["ContractName"] + "'");
                _contractModel.CID = int.Parse(aa.Tables[0].Rows[0]["CID"].ToString());
                if (_contractBll.Update(_contractModel))
                    AlertAndParentReoload("修改成功");
                else
                    Alert("修改失败！");
            }
            else
            {
                if (_contractBll.Add(_contractModel) > 0)
                    AlertAndParentReoload("添加成功");
                else
                    Alert("添加失败！");
            }
        }
        #endregion
    }
}