using System;
using System.Data;
using System.Web;
using Haikan.SchoolProjectsCore;
using Haikan2.DataTools;
using Haikan2.DEncrypt;
using Haikan2.NewControl;

namespace HaikanSchoolProjects.General
{
    /// <summary>
    /// 登陆页面
    /// </summary>
    public partial class Login : HaikanAlert
    {
        #region 实例化基类
        
        // 系统用户
        private readonly Haikan.SchoolProjectsCore.MDB.BLL.SystemUser _systemUserBll = new Haikan.SchoolProjectsCore.MDB.BLL.SystemUser();
        private Haikan.SchoolProjectsCore.MDB.Model.SystemUser _systemUserModel = new Haikan.SchoolProjectsCore.MDB.Model.SystemUser();
        
        // 用户权限
        private readonly Haikan.SchoolProjectsCore.MDB.BLL.SystemRoles _systemRolesBll = new Haikan.SchoolProjectsCore.MDB.BLL.SystemRoles();
        Haikan.SchoolProjectsCore.MDB.Model.SystemRoles _systemRolesModel = new Haikan.SchoolProjectsCore.MDB.Model.SystemRoles();
        
        // 全局设置
        private readonly Haikan.SchoolProjectsCore.MDB.BLL.SystemSetting _systemSetBll = new Haikan.SchoolProjectsCore.MDB.BLL.SystemSetting();
        private Haikan.SchoolProjectsCore.MDB.Model.SystemSetting _systemSetModel = new Haikan.SchoolProjectsCore.MDB.Model.SystemSetting();
        
        // 菜单管理
        private readonly Haikan.SchoolProjectsCore.MDB.BLL.SystemMenu _systemMenuBll = new Haikan.SchoolProjectsCore.MDB.BLL.SystemMenu();

        // 父页面
        private readonly SystemPage _systemPage = new SystemPage();
        
        // 防止恶意登录
        private readonly IllegalityLogin _illegalityLogin = new IllegalityLogin();

        // 系统标题
        protected string SystemTitle = "";
        #endregion

        /// <summary>
        /// 页面加载
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            // 获取全局配置中的系统名称
            _systemSetModel = _systemSetBll.GetModel(_systemSetBll.GetMaxId());
            lblSystemTitle.Text = SystemTitle = _systemSetModel.SystemName;

            //对接统一身份认证
            //if (ConfigurationManager.AppSettings["HaikanPassport_IfUse"].ToLower() == "true")
            //{
            //    if (Session["HaikanSchoolProjects.Cert"] != null)
            //    {
            //        //分站凭证存在
            //        //Response.Write("恭喜，分站凭证存在，您被授权访问该页面！");
            //    }
            //    else
            //    {
            //        //令牌验证结果返回
            //        if (Request.QueryString["token"] != null)
            //        {
            //            //持有令牌
            //            if (Request.QueryString["token"] != "$token$")
            //            {
            //                var tokenValue = Request.QueryString["token"];

            //                //调用WebService获取主站凭证
            //                //防止令牌伪造
            //                //此处还可使用公钥私钥的非对称加密策略
            //                passportservice.PassportService passportService = new passportservice.PassportService();
            //                object cert = passportService.TokenGetCert(tokenValue);
            //                if (cert != null)
            //                {
            //                    // 将token写入Session
            //                    Session["HaikanSchoolProjects.Token"] = tokenValue;

            //                    //令牌正确，产生分站凭证
            //                    Session["HaikanSchoolProjects.Cert"] = cert;
            //                    //Response.Write("恭喜，令牌存在，您被授权访问该页面！");
            //                }
            //                else
            //                {
            //                    //令牌错误，去Passport登录
            //                    Response.Redirect(HaikanPassportHelper.TokenReplace());
            //                }
            //            }
            //            //未持有令牌，去Passport登录
            //            else
            //            {
            //                Response.Redirect(HaikanPassportHelper.TokenReplace());
            //            }
            //        }
            //        //未进行令牌验证，去Passport验证
            //        else
            //        {
            //            //当前url附加上token参数
            //            Response.Redirect(HaikanPassportHelper.TokenUrl());
            //        }
            //    }

            //    // 进入用户认证的阶段
            //    if (!IsPostBack)
            //    {
            //        var userinfo = Session["HaikanSchoolProjects.Cert"];
            //        var blowFish = new BlowFish();
            //        var deText = blowFish.Decrypt(ConfigurationManager.AppSettings["HaikanPassport_ApiKey"], userinfo.ToString());
            //        string[] arr = deText.Split('&');

            //        if (arr.Length < 2)
            //        {
            //            Alert("API密钥不正确！");
            //            return;
            //        }

            //        // 获取该用户的相关信息
            //        var ds = _systemUserBll.GetModelList("UserName='" + arr[0] + "' and (UserPWD = '" +
            //                                             DesEncrypt.GetMd5String(arr[1]) + "' or UserPWD = '" + arr[1] +
            //                                             "')");

            //        if (ds.Count <= 0)
            //        {
            //            Session.Abandon();
            //            Alert("对不起，没有找到对应的用户！");
            //            Response.Redirect(HaikanPassportHelper.TokenReplace());
            //            return;
            //        }

            //        _systemUserModel = ds[0];
            //        if (_systemUserModel.IsEnter == 1)
            //        {
            //            Alert("对不起，您已被禁止登录！");
            //            return;
            //        }

            //        // 获取角色和权限
            //        var roleId = Convert.ToInt32(_systemUserModel.RoleID);
            //        _systemRolesModel = _systemRolesBll.GetModel(roleId);
            //        if (_systemRolesModel != null)
            //        {
            //            Session["roleId"] = _systemUserModel.RoleID;
            //            Session["RoleName"] = _systemRolesModel.RoleName;
            //            Session["ActionStr"] = _systemRolesModel.Actionstr;
            //        }
            //        else
            //        {
            //            Session["roleId"] = "";
            //            Session["RoleName"] = "";
            //            Session["ActionStr"] = "";
            //        }

            //        // 个人信息
            //        Session["userid"] = _systemUserModel.ID;
            //        Session["TrueName"] = _systemUserModel.TrueName;
            //        Session["username"] = _systemUserModel.UserName;
            //        Session["Department"] = _systemUserModel.DepartmentID;
            //        Session["BirthDay"] = _systemUserModel.BirthDay;
            //        Session["IdentityCard"] = _systemUserModel.SFZSerils; //身份证号码
            //        Session["Sex"] = _systemUserModel.Sex;
            //        Session["JiaRuBenDanWeiTime"] = _systemUserModel.JiaRuBenDanWeiTime; // 入职时间
            //        Session["TelephoneNumber"] = _systemUserModel.TelphoneNumber; // 联系电话

            //        // 左侧菜单,保存到cookies中
            //        var menuStr = BindStr();
            //        if (menuStr != "")
            //        {
            //            DataCache.SetCache("HaikanSchoolProjects-" + Session["userid"], menuStr);
            //        }

            //        // 跳转到主界面
            //        Response.Redirect("/General/Main.aspx");
            //    }
            //}

            if (IsPostBack) return;

            // 清除浏览器缓存
            _systemPage.ClearClientPageCache();

            //是否显示验证码,如果不为0就隐藏
            if (_systemSetModel.IsIdentifyingCode.ToString() != "0")
            {
                Panelyzm.Visible = false;
            }

            //判断是否有cookie值，如果有就读取出来
            var cookies = Request.Cookies["RememberPWD"];
            if (cookies == null || !cookies.HasKeys) return;

            TxtUserName.Text = cookies["Name"];
            TxtUserPwd.Attributes.Add("value", cookies["UserPwd"]);

            chkRemembered.Checked = true;
        }

        #region 点击事件
        /// <summary>
        /// 点击登陆
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnLogin_Click(object sender, EventArgs e)
        {
            // 先判断验证码
            _systemSetModel = _systemSetBll.GetModel(_systemSetBll.GetMaxId());
            // 判断是否需要验证码
            if (_systemSetModel.IsIdentifyingCode.ToString() == "0")
            {
                if (Session["yzm"] != null && !string.Equals(Session["yzm"].ToString(), TxtYZM.Text, StringComparison.CurrentCultureIgnoreCase))
                {
                    Alert("验证码错误");
                    return;
                }
            }
            
            // sql注入风险检查
            if (SystemPage.SqlFilter(TxtUserName.Text.Trim()) || SystemPage.SqlFilter(TxtUserPwd.Text.Trim()))
            {
                Alert("帐号错误，请注意非法字符！");
                return;
            }

            // 密码可能是原文或者md5加密后的
            var strWhere = "UserName = '" + TxtUserName.Text.Trim() + "' and (UserPWD = '" + DesEncrypt.GetMd5String(TxtUserPwd.Text.Trim()) + "' or UserPWD = '" + TxtUserPwd.Text.Trim() + "')";
            
            var d = _systemUserBll.GetList(" UserName='" + TxtUserName.Text.Trim() + "'");
            if (d.Tables[0].Rows.Count > 0)
            {
                // 检测是否非法登录3次
                var verify = _illegalityLogin.PwdIsCorrect(TxtUserName.Text.Trim(), 3, TxtUserPwd.Text.Trim());

                if (verify == "成功")
                {
                    // 获取该用户的相关信息
                    var ds = _systemUserBll.GetModelList(strWhere);
                    
                    if (ds.Count <= 0) {
                        Alert("对不起，没有找到对应的用户！");
                        return;
                    }
                    
                    _systemUserModel = ds[0];
                    if (_systemUserModel == null) {
                        Alert("对不起，没有找到对应的用户！");
                        return;
                    }
                        
                    if (_systemUserModel.IsEnter == 1)
                    {
                        Alert("对不起，您已被禁止登录！");
                        return;
                    }
                    
                    // 获取角色和权限
                    var roleId = Convert.ToInt32(_systemUserModel.RoleID);
                    _systemRolesModel = _systemRolesBll.GetModel(roleId);
                    if (_systemRolesModel != null)
                    {
                        Session["roleId"] = _systemUserModel.RoleID;
                        Session["RoleName"] = _systemRolesModel.RoleName;
                        Session["ActionStr"] = _systemRolesModel.Actionstr;
                    }
                    
                    // 个人信息
                    Session["userid"] = _systemUserModel.ID;
                    Session["TrueName"] = _systemUserModel.TrueName;
                    Session["username"] = TxtUserName.Text.Trim();
                    Session["Department"] = _systemUserModel.DepartmentID;
                    Session["BirthDay"] = _systemUserModel.BirthDay;
                    Session["IdentityCard"] = _systemUserModel.SFZSerils;//身份证号码
                    Session["Sex"] = _systemUserModel.Sex;
                    Session["JiaRuBenDanWeiTime"] = _systemUserModel.JiaRuBenDanWeiTime; // 入职时间
                    Session["TelephoneNumber"] = _systemUserModel.TelphoneNumber; // 联系电话

                    // 判断是否选择了记住密码
                    if (chkRemembered.Checked)
                    {
                        var cookie = new HttpCookie("RememberPWD");
                        cookie.Values.Add("Name", TxtUserName.Text.Trim());

                        // 如果长度大于20，可以判定为md5加密后的密码，直接保存即可，否则需要加密后保存
                        cookie.Values.Add("UserPwd",
                            TxtUserPwd.Text.Trim().Length > 20
                                ? TxtUserPwd.Text.Trim()
                                : DesEncrypt.GetMd5String(TxtUserPwd.Text.Trim()));

                        cookie.Expires = DateTime.Now.AddDays(60.0);// 有效期2个月
                        HttpContext.Current.Response.Cookies.Add(cookie);
                    }

                    // 左侧菜单,保存到cookies中
                    var menuStr = BindStr();
                    if (menuStr != "")
                    {
                        DataCache.SetCache("HaikanSchoolProjects-" + Session["userid"], menuStr);
                    }
                    
                    // 跳转到主界面
                    Response.Redirect("/General/Main.aspx");
                }
                else
                {
                    Alert(verify);
                }
            }
            else
            {
                Alert("不存在该用户");
            }
        }
        #endregion

        #region 数据绑定
        /// <summary>
        /// 左侧菜单
        /// </summary>
        /// <returns></returns>
        private string BindStr()
        {
            // 菜单字符串
            var menuStr = "";

            var kong = ""; // dsTwo.Tables[0].Rows[i1]["AllowButton"]
            
            // 查询所有有效菜单
            var ds = _systemMenuBll.GetList("1=1 order by CONVERT(INT,SortCode) desc");
            DataTable dt = ds.Tables[0];
            //var ds = _systemMenuBll.GetList("1=1 and Category='目录' and parentID=0 order by CONVERT(INT,SortCode) desc");
            
            DataRow[] drs = dt.Select("Category='目录' and parentID=0");
            
            if (drs.Length <= 0) return menuStr;
            
            menuStr += "<ul>";
            menuStr += "<li>";
            
            
            foreach (var t in drs)
            {
                var moduleId = Convert.ToInt32(t["ModuleID"]);
                
                // 二级菜单数据
                //DataSet dsTwo = _systemMenuBll.GetList("ParentID=" + moduleId + " order by CONVERT(INT,SortCode) desc");
                DataRow[] drs2 = dt.Select("ParentID=" + moduleId);
                
                // 只有存在二级菜单的情况下，才显示一级菜单   
                if (drs2.Length <= 0) continue;
                // 一级菜单
                menuStr += "<li class='first_level'" + _systemPage.ShowMenuByRole(t["MenuRole"].ToString()) + ">";
                menuStr += "<a class='titles' href='javascript:void(0)'>";
                menuStr += "<span class='" + t["Icon"] + "'></span>";
                menuStr += "<span class='menu-title' style='margin-left:10px;'>" + t["FullName"] + "</span>";
                menuStr += "</a>";
                menuStr += "<ul>";
                menuStr += "<li class='submenu-title'>" + t["FullName"] + "</li>";
                    
                // 二级菜单
                for (var i1 = 0; i1 < drs2.Length; i1++)
                {
                    var idTwo = Convert.ToInt32(drs2[i1]["ModuleID"]);
                        
                    menuStr += "<li class='first_level' id='" + idTwo + "' " + GetType(drs2[i1]["Location"].ToString(), 0, drs2[i1]["MenuRole"].ToString()) + ">";
                    menuStr += "<a class='titlesSecond' href='javascript:void(0)'>";
                    menuStr += "<span class='" + drs2[i1]["Icon"] + "'></span>";
                    menuStr += "<span style='margin-left:10px;'>" + drs2[i1]["FullName"] + "</span>";
                    menuStr += "</a>";
                    menuStr += "<ul>";
                    menuStr += "<li class='submenu-title'>" + drs2[i1]["FullName"] + "</li>";
                        
                    // 三级菜单
                    //DataSet dsThree = _systemMenuBll.GetList(" ParentID=" + idTwo + " order by CONVERT(INT,SortCode) desc");
                    DataRow[] drs3 = dt.Select(" ParentID=" + idTwo);
                    if (drs3.Length > 0)
                    {
                        for (var i2 = 0; i2 < drs3.Length; i2++)
                        {
                            menuStr += "<li " + GetType(drs3[i2]["Location"].ToString(), 1, drs3[i2]["MenuRole"].ToString()) + ">";
                            menuStr += "<a class='subNavs' ";
                            menuStr += Href(drs3[i2]["Location"].ToString(), kong) + ">";
                            menuStr += drs3[i2]["FullName"].ToString();
                            menuStr += "</a>";
                            menuStr += "</li>";
                        }
                    }
                        
                    menuStr += "</ul>";
                    menuStr += "</li>";
                    menuStr += "<li " + GetType(drs2[i1]["Location"].ToString(), 1, drs2[i1]["MenuRole"].ToString()) + ">";
                    menuStr += "<a class='subNavs' ";
                    menuStr += Href(drs2[i1]["Location"].ToString(), kong) + ">";
                    menuStr += "<span class='" + drs2[i1]["Icon"] + "'></span>";
                    menuStr += "<span style='margin-left:10px;'>" + drs2[i1]["FullName"] + "</span>";
                    menuStr += "</a>";
                    menuStr += "</li>";
                }
                menuStr += "</li>";
                menuStr += "</ul>";
            }
            return menuStr;
        }

        /// <summary>
        /// 判断是否有权限看到菜单
        /// </summary>
        /// <param name="location"></param>
        /// <param name="i"></param>
        /// <param name="menuRole"></param>
        /// <returns></returns>
        private string GetType(string location, int i, string menuRole)
        {
            if (i == 1)
            {
                return location == "1" ? "style='display:none;'" : _systemPage.ShowMenuByRole(menuRole);
            }

            return location == "1" ? _systemPage.ShowMenuByRole(menuRole) : "style='display:none;'";
        }

        /// <summary>
        /// 判断该路径是否为弹窗
        /// </summary>
        /// <param name="location"></param>
        /// <param name="allowButton"></param>
        /// <returns></returns>
        private static string Href(string location, string allowButton)
        {
            if (allowButton == "Add")
            { return ""; }

            return "href='" + location + "'";
        }

        /// <summary>
        /// 记住密码复选框点击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void chkRemembered_OnCheckedChanged(object sender, EventArgs e)
        {
            // 如果取消选择，则让cookies失效
            if (chkRemembered.Checked) return;
            
            var cookies = Request.Cookies["RememberPWD"];
            if (cookies == null || !cookies.HasKeys) return;
                
            cookies.Expires = DateTime.Now.AddDays(-1);
            
            Response.AppendCookie(cookies);
        }
        #endregion
    }
}