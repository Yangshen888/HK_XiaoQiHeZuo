using System;
using System.Data;
using System.Web.UI.WebControls;
using Haikan.SchoolProjectsCore;
using Haikan2.DBHelper;
using Haikan2.ExcelTools;

namespace HaikanSchoolProjects.General.SystemManage
{
    /// <summary>
    /// 系统日志
    /// </summary>
    public partial class CertificationLog : SystemPage
    {
        #region 实例化基类
        //系统操作日志
        Haikan.SchoolProjectsCore.MDB.BLL.SystemLog _sysoperationlogbll = new Haikan.SchoolProjectsCore.MDB.BLL.SystemLog();
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

            if (!ActionValidator("SystemLogList")) return;
            
            Bind();
            ImgBtnsearch.Visible = ActionValidator("SystemLogsearch");
            ImgBtnExport.Visible = ActionValidator("SystemLogExport");
        }

        /// <summary>
        /// 绑定数据
        /// </summary>
        public void Bind()
        {
            string whereStr = " 1=1 ";
            if (txtUserName.Text != "")
            {
                whereStr += " and UserName like '%" + txtUserName.Text + "%'";
            }

            int total1 = _sysoperationlogbll.GetRecordCount(whereStr);
            AspNetPager1.RecordCount = total1;
            Label1.Text = AspNetPager1.RecordCount.ToString();
            DataSet ds = _sysoperationlogbll.GetListByPage(whereStr, "id desc", (this.AspNetPager1.CurrentPageIndex - 1) * AspNetPager1.PageSize + 1, this.AspNetPager1.CurrentPageIndex * AspNetPager1.PageSize);
            GVData.DataSource = ds;
            GVData.DataBind();
        }

        /// <summary>
        /// 页面美化
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void GVData_PreRender(object sender, EventArgs e)
        {
            if (GVData.Rows.Count > 0)
            {
                // 使用<TH>替换<TD>
                GVData.UseAccessibleHeader = true;

                //This will add the <thead> and <tbody> elements
                //HeaderRow将被<thead>包裹，数据行将被<tbody>包裹
                GVData.HeaderRow.TableSection = TableRowSection.TableHeader;

                // FooterRow将被<tfoot>包裹
                GVData.FooterRow.TableSection = TableRowSection.TableFooter;
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
            Bind();
        }

        /// <summary>
        /// 分页
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void AspNetPager1_PageChanged(object sender, EventArgs e)
        {
            Bind();
        }

        /// <summary>
        /// 点击导出
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void BtnExport_Click(object sender, EventArgs e)
        {

            DataTable dt = DbHelperSql.GetDataTable("SystemLog", "UserName,TimeStr,ActionStr,IPAddress", "UserName like '%" + txtUserName.Text.Trim() + "%'  order by ID desc", "").Tables[0]; //导出;
            dt.Columns[0].ColumnName = "用户名";
            dt.Columns[1].ColumnName = "日志时间";
            dt.Columns[2].ColumnName = "操作内容";
            dt.Columns[3].ColumnName = "IP地址";
            ExcelManage.HaikanExcelExport("操作日志", dt);
            AddSystemLog("导出操作日志", "导出");
        }

        /// <summary>
        /// 切换分页条目
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            AspNetPager1.PageSize = Convert.ToInt32(DropDownList1.SelectedValue);
            Bind();
        }
        #endregion
    }
}


