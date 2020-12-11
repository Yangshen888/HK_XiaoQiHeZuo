using System;
using System.Data;
using Haikan2.DataTools;
using Haikan.SchoolProjectsCore;

namespace HaikanSchoolProjects.General.Hfile
{
    /// <summary>
    /// 文件列表
    /// </summary>
    public partial class Hfile : SystemPage
    {
        #region 实例化基类
        //文件表
        private readonly Haikan.SchoolProjectsCore.MDB.BLL.HFile _hFileBll = new Haikan.SchoolProjectsCore.MDB.BLL.HFile();

        //企业名称
        public string EnterpriseName = "";
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

            if (string.IsNullOrEmpty(Request.QueryString["name"]))
            {
                Response.Redirect("EnterpriseList.aspx");
            }
            //这个企业名称，将在文件列表中使用到它，更在添加文件中使用到
            Session["name"] = Request.QueryString["name"];
            EnterpriseName = Session["name"].ToString();
            Bind();
        }

        /// <summary>
        /// 下拉列表事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            AspNetPager1.PageSize = Convert.ToInt32(DropDownList1.SelectedValue);
            Bind();
        }

        /// <summary>
        /// 数据绑定
        /// </summary>
        private void Bind()
        {
            var strwhere = " 1=1 and EnterpriseName Like '%" + Request.QueryString["name"] + "%'";
            AspNetPager1.RecordCount = _hFileBll.GetRecordCount(strwhere);
            Label1.Text = AspNetPager1.RecordCount.ToString();
            DataSet ds = _hFileBll.GetListByPage(strwhere, "FileID desc", (this.AspNetPager1.CurrentPageIndex - 1) * AspNetPager1.PageSize + 1, this.AspNetPager1.CurrentPageIndex * AspNetPager1.PageSize);

            GVData.DataSource = ds;
            GVData.DataBind();
        }

        /// <summary>
        /// 分页绑定
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void AspNetPager1_PageChanged(object sender, EventArgs e)
        {
            Bind();
        }
        #endregion

        #region 操作方法
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void BtnDel_Click(object sender, EventArgs e)
        {
            string dlist = ControlTools.CheckCbx(GVData, "CheckSelect", "LabVisible");
            var hFile = _hFileBll.GetModel(int.Parse(dlist));
            hFile.FileID = int.Parse(ControlTools.CheckCbx(GVData, "CheckSelect", "LabVisible"));
            if (hFile.IsDele == "0")
            {
                hFile.IsDele = "1";
            }
            if (_hFileBll.Update(hFile))
            {
                Bind();
            }
            else Alert("标记删除失败！");
        }

        /// <summary>
        /// 判断状态
        /// </summary>
        /// <param name="isDele"></param>
        /// <returns></returns>
        public string IsIf(string isDele)
        {
            return isDele == "1" ? "已删除" : "存在";
        }
        #endregion
    }
}










