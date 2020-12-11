using System;
using Haikan2.DBHelper;
using Haikan.SchoolProjectsCore;

namespace HaikanSchoolProjects.General.Employee
{
    /// <summary>
    /// 员工添加/修改
    /// </summary>
    public partial class EmployeeAdd : SystemPage
    {
        #region 实例化基类
        //员工表
        private Haikan.SchoolProjectsCore.MDB.BLL.Employee _employeeBLL = new Haikan.SchoolProjectsCore.MDB.BLL.Employee();
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
                if (ActionValidator("EmployeeAdd"))
                {
                    //绑定企业下拉列表框
                    var query = DbHelperSql.Query("select DISTINCT EnterpriseName from  Eenterprises where Audit='已通过'");
                    DropDownList_qy.DataSource = query;
                    DropDownList_qy.DataTextField = "EnterpriseName";
                    DropDownList_qy.DataValueField = "EnterpriseName";
                    DropDownList_qy.DataBind();
                   //判断是否为修改操作
                    if (!string.IsNullOrEmpty(Request.QueryString["EID"]))
                    {
                        var model = _employeeBLL.GetModel(int.Parse(Request.QueryString["EID"]));
                        DropDownList_qy.SelectedValue = model.EnterpriseName;
                        DropDownListXM.SelectedValue = model.ProjectName;
                        TextBoxName.Text = model.EmployeeName;
                        person_time.Text = model.EmployeeTime;
                        txty.Text = model.Note;
                    }
                }else AlertAndParentSkip("没有权限", "EmployeeList");
            }
        }

        /// <summary>
        /// 绑定项目下拉列表框
        /// </summary>
        /// <param name="enterprise"></param>
        public void GetProjectList(string enterprise)
        {
            //绑定项目下拉列表框
            var query = DbHelperSql.Query("select DISTINCT ProjectName from  Project where EnterpriseName like '" + enterprise + "'");
            DropDownListXM.DataSource = query;
            DropDownListXM.DataTextField = "ProjectName";
            DropDownListXM.DataValueField = "ProjectName";
            DropDownListXM.DataBind();
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
            //非空判断
            if (string.IsNullOrEmpty(TextBoxName.Text) || string.IsNullOrEmpty(person_time.Text))
            {
                Alert("姓名与工作时长都不能为空！"); return;
            }
            var model = new Haikan.SchoolProjectsCore.MDB.Model.Employee
            {
                EmployeeName = TextBoxName.Text.Trim(),
                EmployeeTime = person_time.Text.Trim(),//工作时间
                Note = txty.Text.Trim(),
                EnterpriseName = DropDownList_qy.SelectedValue,
                ProjectName = DropDownListXM.SelectedValue
            };
            if (!string.IsNullOrEmpty(Request.QueryString["EID"]))
            {
                model.EID = int.Parse(Request.QueryString["EID"]);
                if (_employeeBLL.Update(model))
                    AlertAndParentReoload("修改成功");
                else
                    Alert("修改失败！");
            }
            else
            {
                if (_employeeBLL.Add(model) > 0)
                    AlertAndParentReoload("添加成功");
                else
                    Alert("添加失败！");
            }
        }

        /// <summary>
        /// 选择企业，显示对应的项目信息列表
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void DropDownList_qy_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetProjectList(DropDownList_qy.SelectedValue);
        }
        #endregion
    }
}




