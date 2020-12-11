using Haikan2.NewControl;
using Haikan.SchoolProjectsCore.MDB.Model;
using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Linq;

namespace Haikan.SchoolProjectsCore
{
    /// <summary>
    /// ��̨����ҳ��̳е���
    /// </summary>
    public class SystemPage : HaikanSystemPage
    {
        #region ʵ��������
        // ϵͳ��־��
        private readonly MDB.BLL.SystemLog _systemLogBll = new SchoolProjectsCore.MDB.BLL.SystemLog();
        private readonly SystemLog _systemLogModel = new SystemLog();

        //�˵�����
        private readonly MDB.BLL.SystemMenu _systemMenuBll = new MDB.BLL.SystemMenu();
        #endregion

        #region ��Ʒ������صķ���
        /// <summary>
        /// ��Ӳ�����־
        /// </summary>
        /// <param name="logs">��־��������</param>
        /// <param name="type">��־����</param>
        public void AddSystemLog(string logs, string type)
        {
            _systemLogModel.UserName = Session["UserName"].ToString();//������

            _systemLogModel.TimeStr = DateTime.Now;//����ʱ��

            _systemLogModel.ActionStr = logs;//��������

            if (System.Web.HttpContext.Current.Request.UserHostAddress != null)
                _systemLogModel.IPAddress = System.Web.HttpContext.Current.Request.UserHostAddress; //ip��ַ

            _systemLogModel.Type = type;//��������

            //systemlogmodel.IsDelete = 1;

            _systemLogModel.AddTime = DateTime.Now;//����ʱ��

            _systemLogModel.AddPeople = Session["TrueName"].ToString();//�������ʵ����

            _systemLogBll.Add(_systemLogModel);
        }
        #endregion

        #region �����Զ���ɵļ�������
        /// <summary>
        /// ϵͳȨ�޷���
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <param name="gvData"></param>
        protected void PagerButtonClick(object sender, ImageClickEventArgs e, GridView gvData)
        {
            string str = ((ImageButton)sender).CommandName;
            if (str == "Next")
            {
                if (gvData.PageIndex < gvData.PageCount - 1)
                    ++gvData.PageIndex;
            }
            else
            {
                if (str == "Pre")
                {
                    if (gvData.PageIndex > 0)
                        --gvData.PageIndex;
                }
                else
                {
                    if (str != "Last")
                        gvData.PageIndex = 0;
                    else
                    {
                        try
                        {
                            gvData.PageIndex = gvData.PageCount - 1;
                        }
                        catch
                        {
                            gvData.PageIndex = 0;
                        }
                    }
                }
            }
        }

        /// <summary>
        /// �Զ���ȡ���е�ҳ��˵�
        /// </summary>
        /// <returns></returns>
        public string GetPageUrlByAuto()
        {
            var result = "";

            var dss = _systemMenuBll.GetList("1=1 and Category='ҳ��'");
            if (dss.Tables[0].Rows.Count <= 0) return result;
            for (int i = 0; i < dss.Tables[0].Rows.Count; i++)
            {
                if (dss.Tables[0].Rows.Count == i + 1)
                {
                    result += "{'pageurl': '" + dss.Tables[0].Rows[i]["Location"] + "','label': '" + dss.Tables[0].Rows[i]["FullName"] + "','rgb': '(239, 222, 205)'}";
                }
                else
                {
                    result += "{'pageurl': '" + dss.Tables[0].Rows[i]["Location"] + "','label': '" + dss.Tables[0].Rows[i]["FullName"] + "','rgb': '(239, 222, 205)'},";
                }
            }
            return result;
        }
        #endregion

        #region ��sqlע�뷽��
        /// <summary>
        /// ��sqlע�뷽��
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static bool SqlFilter(String str)
        {
            const string word = "'|--|;|+|%27|/*|@| and | or |%20and%20|%20or%20";
            return str != null && word.Split('|').Any(i => (str.ToLower().IndexOf(i, StringComparison.Ordinal) > -1));
        }
        #endregion
    }
}