using System;
using System.Data;
using Haikan2.DBHelper;
using Haikan2.DEncrypt;

namespace Haikan.SchoolProjectsCore
{
    /// <summary>
    /// 检测是否非法登录
    /// </summary>
    public class IllegalityLogin
    {
        #region 对象实例化

        readonly MDB.BLL.SystemUser _systemUserBll = new MDB.BLL.SystemUser();
        #endregion

        #region 获取登录数据
        /// <summary>
        /// 判断密码是否正确，此处给该方法传递参数illLoginCount的目的是因为该方法中将会用到允许非法登录的次数
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="illLoginCount"></param>
        /// <param name="userPwd"></param>
        /// <returns></returns>
        public string PwdIsCorrect(string userName, int illLoginCount, string userPwd)
        {
            string result = "";

            //以下三行为从数据库中获取用户密码
            DataSet ds = _systemUserBll.GetList(" UserName='" + userName + "'");

            var loginCount = GetLoginCount(userName);

            //判断是否超时，为了方便测试,我们暂时设定允许非法用户再次登录的时间段为1分钟（1分钟约为0.0167小时，即1/60=0.0167）
            var isOverTime = IsOverTimeSpan(userName, 0.167f);

            //密码输入正确
            if (ds.Tables[0].Rows[0]["UserPwd"].ToString() == DesEncrypt.GetMd5String(userPwd) || ds.Tables[0].Rows[0]["UserPwd"].ToString() == userPwd)
            {
                //如果非法登录次数到达illLoginCount次，且没超过指定的时间范围（非法登录次数到达3次后，允许该用户能再次登录的时间段），即使帐号和密码正确也不能登录
                if ((loginCount == illLoginCount) && (isOverTime == false))
                {
                    result = "非法登录超过'+'" + illLoginCount + "'+'次，帐号：'+'" + userName + "'+' 已被锁!";
                }
                else //如果非法登录次数没达到illLoginCount次或已经达到illLoginCount次但已经超过了指定的时间范围，仍然可登录
                {
                    //成功登录时清空登录记录（非法登录次数和非法登录的时间）  
                    ClearLoginParameters(userName);
                    result = "成功";
                }
            }
            else
            {
                //密码输入不正确
                LoginWithIncorrectPwd(userName, 3);//密码输入错误时执行

                //系统提示“密码不正确” 的情况有两种：（1）用户非法登录的次数未超过3次时，系统应该提示“密码不正确”。
                //（2）用户非法登录次数已经达到3次，但再次登录的时间已经超过了禁止该用户登录的时间段，这时系统应该提示“密码不正确”。
                //如果用户非法登录次数已经达到3次，但再次登录的时间还没超过禁止该用户登录的时间段，这时系统应该提示“帐号：**已锁”，这个功能通过LoginWithIncorrectPwd(）实现。
                if ((loginCount < 3) || ((loginCount == 3) && isOverTime))
                {
                    result = "密码不正确";
                }
            }

            return result;
        }

        /// <summary>
        /// 获取非法登录的次数
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        private int GetLoginCount(string userName)
        {
            DataSet ds = _systemUserBll.GetList(" UserName='" + userName + "'");
            return Convert.ToInt32(ds.Tables[0].Rows[0]["loginCount"]);
        }

        /// <summary>
        /// 判断是否超时,非法登录次数超过指定次数后，在 hourTimeSpan时间内是不允许再登录的
        /// </summary>
        /// <param name="userName">当前用户</param>
        /// <param name="hourTimeSpan">非法登录次数超过指定次数后，在 timeSpan时间内是不允许再登录的</param>
        /// <returns>超过可以再次登录的时间段后返回true，否则返回false</returns>
        /// <author>赖顺生</author>
        private bool IsOverTimeSpan(string userName, float hourTimeSpan)
        {
            DateTime now = DateTime.Now;
            DateTime lastLoginTime = GetLoginTime(userName);

            int minute = now.Day * 24 * 60 + now.Hour * 60 + now.Minute - (lastLoginTime.Day * 24 * 60 + lastLoginTime.Hour * 60 + lastLoginTime.Minute);

            //按分钟计算是否超时
            if (minute > hourTimeSpan * 60)
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// 获取非法登录时间
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        private DateTime GetLoginTime(string userName)
        {
            DataSet ds = _systemUserBll.GetList(" UserName='" + userName + "'");
            DateTime loginTime = DateTime.Parse(ds.Tables[0].Rows[0]["loginTime"].ToString());
            return loginTime;
        }

        /// <summary>
        /// 登录成功时清空登录失败的记录
        /// </summary>
        /// <param name="userName"></param>
        private void ClearLoginParameters(string userName)
        {
            string str = "update SystemUser set loginCount = 0 where UserName='" + userName + "'";
            DbHelperSql.ExecuteSql(str);
        }

        /// <summary>
        ///  //非法登录(密码输入错误)时执行下列方法
        /// 通用的方法，可设置非法登录的次数，如下面的illLoginCount变量,在实际应用中该值可被管理员设置，使用时从数据库中获取.
        /// </summary>
        /// <param name="userName">当前用户</param>
        /// <param name="illLoginCount">允许非法登录的次数</param>
        /// <author>赖顺生</author>
        private void LoginWithIncorrectPwd(string userName, int illLoginCount)
        {
            //第一次非法登录
            if (GetLoginCount(userName) == 0)
            {
                UpdateLoginCount(userName);//数据库中的登录次数字段值更新为最新的登录次数
                UpdateLoginTime(userName);//数据库中的登录时间字段值更新为最新的登录时间
            }
            else
            {
                if (GetLoginCount(userName) < illLoginCount)//第illLoginCount次前非法登录
                {
                    if (IsOverTimeSpan(userName, 0.0167f))//判断是否超时，为了方便测试,我们暂时设定允许非法用户再次登录的时间段为1分钟（1分钟约为0.0167小时，即1/60=0.0167）
                    {
                        UpdateLoginTime(userName);
                    }
                    else
                    {
                        UpdateLoginCount(userName);
                    }
                }
                else
                {
                    //第illLoginCount次及以后登录
                    if (IsOverTimeSpan(userName, 0.0167f))
                    {
                        UpdateLoginTime(userName);
                    }
                    else
                    {
                        UpdateLoginTime(userName);
                    }
                }
            }
        }
        #endregion

        #region 更新登录数据
        /// <summary>
        /// 更新非法登录次数
        /// </summary>
        /// <param name="userName"></param>
        private void UpdateLoginCount(string userName)
        {
            var str = "update SystemUser set loginCount = loginCount+1 where UserName='" + userName + "'";
            DbHelperSql.ExecuteSql(str);
        }

        /// <summary>
        /// 更新非法登录时间
        /// </summary>
        /// <param name="userName"></param>
        private void UpdateLoginTime(string userName)
        {
            var str = "update SystemUser set loginTime = '" + DateTime.Now + "' where UserName='" + userName + "'";
            DbHelperSql.ExecuteSql(str);
        }
        #endregion
    }
}