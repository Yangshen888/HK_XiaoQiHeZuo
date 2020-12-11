using Haikan.SchoolProjectsCore;
using System;
using System.Data;

namespace HaikanSchoolProjects.General.SystemManage
{
    /// <summary>
    /// 菜单列表
    /// </summary>
    public partial class Menu : SystemPage
    {
        #region 实例化对象
        Haikan.SchoolProjectsCore.MDB.BLL.SystemMenu _systemMenuBll = new Haikan.SchoolProjectsCore.MDB.BLL.SystemMenu();

        protected string Strwhere = "1=1";
        #endregion

        #region 页面加载
        /// <summary>
        /// 页面加载
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.IsPostBack) return;

            if (!ActionValidator("SystemMenuList"))  return;
            
            ImgBtnsearch.Visible = ActionValidator("SystemMenuSearch");
            ImgBtnAdd.Visible = ActionValidator("SystemMenuAdd");
            Bind();
        }

        /// <summary>
        /// 绑定数据
        /// </summary>
        private void Bind()
        {
            //模块名称
            if (txtModelName.Text != "")
            {
                string strs = "0";
                DataSet dss = _systemMenuBll.GetList("FullName Like '%" + this.txtModelName.Text.Trim() + "%'");
                if (dss.Tables[0].Rows.Count > 0)
                {
                    for (int i = 0; i < dss.Tables[0].Rows.Count; i++)
                    {
                        //判断有没有上级而且是不是自己
                        if (GetSubMenus(dss.Tables[0].Rows[i]["ParentID"].ToString()) == "0")//没有上级
                        {
                            strs += "," + dss.Tables[0].Rows[i]["ModuleID"];
                        }
                        else
                        {
                            strs += "," + GetSubMenus(dss.Tables[0].Rows[i]["ParentID"].ToString());
                        }
                    }
                }
                Strwhere += " AND ModuleID in (" + strs + ")";
            }
            else
            {
                Strwhere += " and ParentID='0'";
            }
        }
        #endregion

        #region 判断权限
        /// <summary>
        /// 判断登陆用户是否有权限修改、扩展信息
        /// </summary>
        /// <returns></returns>
        protected string GetModifyRole()
        {
            string style = "display:none";
            if (ActionValidator("SystemMenuModify"))
            {
                style = "display:inline-block";
            }
            return style;
        }

        /// <summary>
        /// 判断显示与隐藏，绑定前台
        /// </summary>
        /// <returns></returns>
        public string Gettre2()
        {
            if (ActionValidator("SystemMenuModify"))
            {
                return "style='display:inline-block;'";
            }
            else
            {
                return "style='display:none;'";
            }
        }
        #endregion

        #region 事件方法
        /// <summary>
        /// 判断有没有上级
        /// </summary>
        /// <param name="pid"></param>
        /// <returns></returns>
        private string GetSubMenus(string pid)
        {
            string strs = "0";
            DataSet ds = _systemMenuBll.GetList("ModuleID=" + pid);
            if (ds.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    strs += "," + ds.Tables[0].Rows[i]["ModuleID"];
                    strs += "," + GetSubMenus(ds.Tables[0].Rows[i]["ParentID"].ToString());
                }
            }
            return strs;
        }

        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void BtnSearch_Click(object sender, EventArgs e)
        {
            Bind();
        }
        #endregion
    }
}



