using Haikan2.DBHelper;
using Haikan.SchoolProjectsCore;
using System;
using System.Data;

namespace HaikanSchoolProjects.General.Project
{
    /// <summary>
    /// 管理员添加
    /// </summary>
    public partial class ProjectAdd : SystemPage
    {
        #region 实例化基类
        //项目表
        private readonly Haikan.SchoolProjectsCore.MDB.BLL.Project _projectBll = new Haikan.SchoolProjectsCore.MDB.BLL.Project();
        private readonly Haikan.SchoolProjectsCore.MDB.Model.Project _projectModel = new Haikan.SchoolProjectsCore.MDB.Model.Project();
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

            if (!ActionValidator("ProjectAdd")) return;

            //帮定已经通过的企业到下拉列表控件
            var query = DbHelperSql.Query("select DISTINCT EnterpriseName from  Eenterprises where Audit='已通过'");
            DropDownList_qy.DataSource = query;
            DropDownList_qy.DataTextField = "EnterpriseName";
            DropDownList_qy.DataValueField = "EnterpriseName";
            DropDownList_qy.DataBind();

            //判断是否为修改操作
            if (string.IsNullOrEmpty(Request.QueryString["ProjectID"]))  return;

            DataSet dsProject = DbHelperSql.Query("select * from Project where ProjectID='" +Request.QueryString["ProjectID"] + "'");

            if (dsProject.Tables[0].Rows.Count > 0)
            {
                txtTrueName.Text = dsProject.Tables[0].Rows[0]["ProjectName"].ToString();
                person.Text = dsProject.Tables[0].Rows[0]["PersonInCharge"].ToString();
                txty.Text = dsProject.Tables[0].Rows[0]["Note"].ToString();
                DropDownList_qy.SelectedValue = dsProject.Tables[0].Rows[0]["EnterpriseName"].ToString();
            }
            else
            {
                AlertAndParentReoload("该数据不存在，请检查后重试！");
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
            //非空验证
            if (string.IsNullOrEmpty(txtTrueName.Text.Trim()) )
            {
                Alert("项目名称不能为空！"); return;
            }
            if (string.IsNullOrEmpty(person.Text.Trim()))
            {
                Alert("主要负责人不能为空！"); return;
            }
            _projectModel.EnterpriseName = DropDownList_qy.SelectedValue;  //所属企业的名称
            _projectModel.ProjectName = txtTrueName.Text.Trim();  //项目名称
            _projectModel.PersonInCharge = person.Text.Trim();//主要负责人
            _projectModel.Note = txty.Text.Trim();//备注
            _projectModel.Projectstatus = DropDownList1.SelectedValue;//项目状态
            _projectModel.DName = Session["rolename"].ToString();//项目的引进角色
            _projectModel.Note = txty.Text.Trim();//备注

            if (!string.IsNullOrEmpty(Request.QueryString["ProjectID"]))
            {
                _projectModel.ProjectID = int.Parse(Request.QueryString["ProjectID"]);
                if (_projectBll.Update(_projectModel))
                    AlertAndParentReoload("修改成功");
                else
                    Alert("修改失败！");
            }
            else
            {
                if (_projectBll.Add(_projectModel) > 0)
                    AlertAndParentReoload("添加成功");
                else
                    Alert("添加失败！");
            }
        }
        #endregion
    }
}