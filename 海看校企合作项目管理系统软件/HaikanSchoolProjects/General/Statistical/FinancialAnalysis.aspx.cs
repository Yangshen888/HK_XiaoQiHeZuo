using Haikan2.DBHelper;
using Haikan.SchoolProjectsCore;
using System;

namespace HaikanSchoolProjects.General.Statistical
{
    /// <summary>
    /// 项目参与人数的统计
    /// </summary>
    public partial class FinancialAnalysis : SystemPage
    {
        #region 实例化基类
        //得到企业列表
        public string DataA;
        //得到 财务表中 收款或者付款的金额 
        public string DataB;
        #endregion

        #region 数据绑定
        /// <summary>
        /// 加载页面
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            GetA();
            GetB(DropDownListXM.SelectedValue);
        }

        /// <summary>
        /// 得到企业列表
        /// </summary>
        private void GetA()
        {
            DataA = "'";
            var query = DbHelperSql.Query("select DISTINCT EnterpriseName from Eenterprises");
            for (int i = 0; i < query.Tables[0].Rows.Count; i++)
            {
                DataA += query.Tables[0].Rows[i]["EnterpriseName"] + "','";
            }
            //去除最后一个单引号
            DataA = DataA.Substring(0, DataA.Length - 1);
            DataA = DataA.TrimEnd(',');
        }

        /// <summary>
        /// 得到 财务表中 收款或者付款的金额 
        /// </summary>
        /// <param name="str"></param>
        private void GetB(string str)
        {
            string sql = "select * from Financial ";
            if (str!="")
            {
                sql = "select * from Financial where IsPay='"+str+"'";
            }
            var query = DbHelperSql.Query(sql);
            var entity = DbHelperSql.Query("select DISTINCT EnterpriseName from Eenterprises");
            string enterName = "";
            DataB = "";
            for (int i = 0; i < query.Tables[0].Rows.Count; i++)
            {
                enterName += entity.Tables[0].Rows[i]["EnterpriseName"];
                DataB += "{ value: " +  query.Tables[0].Rows[i]["PayMoney"] + ", name:'" + enterName + "'},";
            }
        }
        #endregion

        #region 事件方法
        /// <summary>
        /// 更改下载项的触发
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void DropDownListXM_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetB(DropDownListXM.SelectedValue);
        }
        #endregion
    }
}



