using Haikan2.DBHelper;
using Haikan.SchoolProjectsCore;
using System;

namespace HaikanSchoolProjects.General.Statistical
{
    /// <summary>
    /// 项目开发情况分析
    /// </summary>
    public partial class Average : SystemPage
    {
        #region 实例化基类
        //人员平均工作量
        public string Mean = "";
        //项目拼接
        public string Project = "";
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
            var query = DbHelperSql.Query("select DISTINCT ProjectName from  Employee");
            DropDownListXM.DataSource = query;
            DropDownListXM.DataValueField = "ProjectName";
            DropDownListXM.DataTextField = "ProjectName";
            DropDownListXM.DataBind();
            A("");
            B("");
        }

        /// <summary>
        /// 获得人员项目名称列表
        /// </summary>
        /// <param name="str"></param>
        public void A(string str)
        {
            Mean = "'";
            string sql = "select DISTINCT ProjectName,EmployeeTime from Employee where ProjectName like'%" + str + "'";
            var query = DbHelperSql.Query(sql);
            for (int i = 0; i < query.Tables[0].Rows.Count; i++)
            {
                //获取每一个项目
                Mean += query.Tables[0].Rows[i]["ProjectName"] + "','";
            }
            //除掉最后一个单引号
            Mean = Mean.Substring(0, Mean.Length - 1);
            //去除最后一个 逗号
            Mean = Mean.TrimEnd(',');
        }

        /// <summary>
        /// 计算出工作量进行拼接
        /// </summary>
        /// <param name="str"></param>
        public void B(string str)
        {
            string sql = "select DISTINCT ProjectName,EmployeeTime from Employee where ProjectName like'%" + str + "'";
            var query = DbHelperSql.Query(sql);
            for (int i = 0; i < query.Tables[0].Rows.Count; i++)
            {
                //获取每一个项目
                var entity = "";
                entity += query.Tables[0].Rows[i]["ProjectName"];
                //计算出人员的平均工作量
                double count = (double.Parse(query.Tables[0].Rows[i]["EmployeeTime"].ToString()) / query.Tables[0].Rows.Count) * 0.1; //计算出百分比
                Project += "{ value: " + count + ", name:'" + entity + "'},";
            }
            //去除最后一个 逗号
            Project = Project.TrimEnd(',');
        }
        #endregion

        #region 操作方法
        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Seacher(object sender, EventArgs e)
        {
            A(DropDownListXM.SelectedValue);
            B(DropDownListXM.SelectedValue);
        }
        #endregion
    }
}