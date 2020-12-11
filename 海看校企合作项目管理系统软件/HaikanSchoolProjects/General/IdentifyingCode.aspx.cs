using System;
using Haikan2.SafeTools;

namespace HaikanSchoolProjects.General
{
    /// <summary>
    /// 验证码生成页面
    /// </summary>
    public partial class IdentifyingCode : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var code = new HaikanIdentifyingCode(4);

            // 将验证码保存到Session当中
            Session["yzm"] = code.RandomCode;

            // 输出图片
            var yzm = code.Ms;
            Response.ClearContent();
            Response.ContentType = "image/gif";
            Response.BinaryWrite(yzm.ToArray());
        }
    }
}