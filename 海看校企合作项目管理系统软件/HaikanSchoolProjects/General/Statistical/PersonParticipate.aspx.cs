using Haikan.SchoolProjectsCore;
using System;
using System.Data;
using Haikan2.DBHelper;

namespace HaikanSchoolProjects.General.Statistical
{
    /// <summary>
    /// 项目参与人数的统计
    /// </summary>
    public partial class PersonParticipate : SystemPage
    {
        #region 实例化基类
        //获得项目列表的拼接
        public string GetProject;
        //获得项目人数的拼接
        public string GetProjectPerson;
        #endregion

        #region 数据绑定
        /// <summary>
        /// 页面加载
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)  return;
            
            var ds = DbHelperSql.Query("select DISTINCT ProjectName from  Employee");
            DropDownListXM.DataSource = ds;
            DropDownListXM.DataValueField = "ProjectName";
            DropDownListXM.DataTextField = "ProjectName";
            DropDownListXM.DataBind();
            GetProjects("");
        }

        /// <summary>
        /// 获取数据
        /// </summary>
        /// <param name="text"></param>
        public void GetProjects(string text)
        {
            var ds = DbHelperSql.Query("select DISTINCT ProjectName from  Project where ProjectName like '%" + text + "%'");
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                GetProject += "'" + ds.Tables[0].Rows[i]["ProjectName"] + "',";
                //统计每个数据表 它的记录条数有多少
                string sql = " SELECT * FROM Employee where ProjectName='" + ds.Tables[0].Rows[i]["ProjectName"] + "'";
                DataSet s = DbHelperSql.Query(sql);
                GetProjectPerson += "'" + s.Tables[0].Rows.Count + "',";
            }
            GetProject = GetProject.Substring(0, GetProject.Length - 1);
            GetProjectPerson = GetProjectPerson.Substring(0, GetProjectPerson.Length - 1);
        }
        #endregion

        #region 事件方法
        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void BtnSearch_Click(object sender, EventArgs e)
        {
            GetProjects(DropDownListXM.SelectedValue);
        }
        #endregion
    }
}


