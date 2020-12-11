using System;
using Haikan2.DBHelper;
using Haikan.SchoolProjectsCore;

namespace HaikanSchoolProjects.General.Statistical
{
    /// <summary>
    /// 项目开发情况分析
    /// </summary>
    public partial class ProjectAnalyze : SystemPage
    {
        #region 实例化基类
        //项目表
        readonly Haikan.SchoolProjectsCore.MDB.BLL.Project _projectBll = new Haikan.SchoolProjectsCore.MDB.BLL.Project();

        //返回项目列表
        public string Prj = "";
        //返回项目统计
        public string Prjanalyze = "";
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

            GetPrjanalyze();
        }

        /// <summary>
        /// 获得项目 状态的统计
        /// </summary>
        public void GetPrjanalyze()
        {
            string sql = "select DISTINCT Projectstatus from Project";
            if (!string.IsNullOrEmpty(time.Text))
            {
                sql = "select DISTINCT Projectstatus from Project where addTime LIKE '%"+time.Text.Trim()+"%'";
            }
            var ds = DbHelperSql.Query(sql);
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                //获取每一个项目
                string sa = ds.Tables[0].Rows[i]["Projectstatus"].ToString();
                var dd = _projectBll.GetList("Projectstatus='" + sa+"'");

                if (dd.Tables[0].Rows.Count > 0)
                {
                    int count = dd.Tables[0].Rows.Count;
                    Prjanalyze += "{ value: " + count + ", name: '" + sa + "' },";
                }
            }
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
            //再次绑定，地区名和地区次数的统计会根据文本框上的内容 做出相应的操作
            GetPrjanalyze();
        }
        #endregion
    }
}










