using System;

namespace HaikanSchoolProjects.General
{
    /// <summary>
    /// 注销
    /// </summary>
    public partial class Logout : System.Web.UI.Page
    {
        /// <summary>
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            Session.Clear();
            Request.Cookies.Clear();
            Response.Redirect("Login.aspx?token=$token$");
        }
    }
}