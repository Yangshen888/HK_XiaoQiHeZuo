using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Haikan2.DBHelper;
namespace Haikan.SchoolProjectsCore.MDB.DAL
{
	/// <summary>
	/// 数据访问类:SystemUser
	/// </summary>
	public partial class SystemUser
	{
		public SystemUser()
		{}
		#region  BasicMethod



		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(Haikan.SchoolProjectsCore.MDB.Model.SystemUser model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into SystemUser(");
			strSql.Append("UserName,UserPwd,TrueName,RoleID,EmailStr,Sex,BirthDay,MingZu,SFZSerils,XueLi,ZhiCheng,BiYeYuanXiao,ZhuanYe,CanJiaGongZuoTime,JiaRuBenDanWeiTime,photo,IsDelete,DepartmentID,IsEnter,TelphoneNumber,AddTime,AddPeople,loginCount,loginTime)");
			strSql.Append(" values (");
			strSql.Append("@UserName,@UserPwd,@TrueName,@RoleID,@EmailStr,@Sex,@BirthDay,@MingZu,@SFZSerils,@XueLi,@ZhiCheng,@BiYeYuanXiao,@ZhuanYe,@CanJiaGongZuoTime,@JiaRuBenDanWeiTime,@photo,@IsDelete,@DepartmentID,@IsEnter,@TelphoneNumber,@AddTime,@AddPeople,@loginCount,@loginTime)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@UserName", SqlDbType.VarChar,50),
					new SqlParameter("@UserPwd", SqlDbType.VarChar,200),
					new SqlParameter("@TrueName", SqlDbType.VarChar,50),
					new SqlParameter("@RoleID", SqlDbType.VarChar,50),
					new SqlParameter("@EmailStr", SqlDbType.VarChar,250),
					new SqlParameter("@Sex", SqlDbType.VarChar,50),
					new SqlParameter("@BirthDay", SqlDbType.VarChar,50),
					new SqlParameter("@MingZu", SqlDbType.VarChar,50),
					new SqlParameter("@SFZSerils", SqlDbType.VarChar,50),
					new SqlParameter("@XueLi", SqlDbType.VarChar,50),
					new SqlParameter("@ZhiCheng", SqlDbType.VarChar,50),
					new SqlParameter("@BiYeYuanXiao", SqlDbType.VarChar,50),
					new SqlParameter("@ZhuanYe", SqlDbType.VarChar,50),
					new SqlParameter("@CanJiaGongZuoTime", SqlDbType.VarChar,50),
					new SqlParameter("@JiaRuBenDanWeiTime", SqlDbType.VarChar,50),
					new SqlParameter("@photo", SqlDbType.NVarChar,50),
					new SqlParameter("@IsDelete", SqlDbType.Int,4),
					new SqlParameter("@DepartmentID", SqlDbType.Int,4),
					new SqlParameter("@IsEnter", SqlDbType.Int,4),
					new SqlParameter("@TelphoneNumber", SqlDbType.NVarChar,50),
					new SqlParameter("@AddTime", SqlDbType.DateTime),
					new SqlParameter("@AddPeople", SqlDbType.VarChar,255),
					new SqlParameter("@loginCount", SqlDbType.Int,4),
					new SqlParameter("@loginTime", SqlDbType.DateTime)};
			parameters[0].Value = model.UserName;
			parameters[1].Value = model.UserPwd;
			parameters[2].Value = model.TrueName;
			parameters[3].Value = model.RoleID;
			parameters[4].Value = model.EmailStr;
			parameters[5].Value = model.Sex;
			parameters[6].Value = model.BirthDay;
			parameters[7].Value = model.MingZu;
			parameters[8].Value = model.SFZSerils;
			parameters[9].Value = model.XueLi;
			parameters[10].Value = model.ZhiCheng;
			parameters[11].Value = model.BiYeYuanXiao;
			parameters[12].Value = model.ZhuanYe;
			parameters[13].Value = model.CanJiaGongZuoTime;
			parameters[14].Value = model.JiaRuBenDanWeiTime;
			parameters[15].Value = model.photo;
			parameters[16].Value = model.IsDelete;
			parameters[17].Value = model.DepartmentID;
			parameters[18].Value = model.IsEnter;
			parameters[19].Value = model.TelphoneNumber;
			parameters[20].Value = model.AddTime;
			parameters[21].Value = model.AddPeople;
			parameters[22].Value = model.loginCount;
			parameters[23].Value = model.loginTime;

			object obj = DbHelperSql.GetSingle(strSql.ToString(),parameters);
			if (obj == null)
			{
				return 0;
			}
			else
			{
				return Convert.ToInt32(obj);
			}
		}
		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(Haikan.SchoolProjectsCore.MDB.Model.SystemUser model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update SystemUser set ");
			strSql.Append("UserName=@UserName,");
			strSql.Append("UserPwd=@UserPwd,");
			strSql.Append("TrueName=@TrueName,");
			strSql.Append("RoleID=@RoleID,");
			strSql.Append("EmailStr=@EmailStr,");
			strSql.Append("Sex=@Sex,");
			strSql.Append("BirthDay=@BirthDay,");
			strSql.Append("MingZu=@MingZu,");
			strSql.Append("SFZSerils=@SFZSerils,");
			strSql.Append("XueLi=@XueLi,");
			strSql.Append("ZhiCheng=@ZhiCheng,");
			strSql.Append("BiYeYuanXiao=@BiYeYuanXiao,");
			strSql.Append("ZhuanYe=@ZhuanYe,");
			strSql.Append("CanJiaGongZuoTime=@CanJiaGongZuoTime,");
			strSql.Append("JiaRuBenDanWeiTime=@JiaRuBenDanWeiTime,");
			strSql.Append("photo=@photo,");
			strSql.Append("IsDelete=@IsDelete,");
			strSql.Append("DepartmentID=@DepartmentID,");
			strSql.Append("IsEnter=@IsEnter,");
			strSql.Append("TelphoneNumber=@TelphoneNumber,");
			strSql.Append("AddTime=@AddTime,");
			strSql.Append("AddPeople=@AddPeople,");
			strSql.Append("loginCount=@loginCount,");
			strSql.Append("loginTime=@loginTime");
			strSql.Append(" where ID=@ID");
			SqlParameter[] parameters = {
					new SqlParameter("@UserName", SqlDbType.VarChar,50),
					new SqlParameter("@UserPwd", SqlDbType.VarChar,200),
					new SqlParameter("@TrueName", SqlDbType.VarChar,50),
					new SqlParameter("@RoleID", SqlDbType.VarChar,50),
					new SqlParameter("@EmailStr", SqlDbType.VarChar,250),
					new SqlParameter("@Sex", SqlDbType.VarChar,50),
					new SqlParameter("@BirthDay", SqlDbType.VarChar,50),
					new SqlParameter("@MingZu", SqlDbType.VarChar,50),
					new SqlParameter("@SFZSerils", SqlDbType.VarChar,50),
					new SqlParameter("@XueLi", SqlDbType.VarChar,50),
					new SqlParameter("@ZhiCheng", SqlDbType.VarChar,50),
					new SqlParameter("@BiYeYuanXiao", SqlDbType.VarChar,50),
					new SqlParameter("@ZhuanYe", SqlDbType.VarChar,50),
					new SqlParameter("@CanJiaGongZuoTime", SqlDbType.VarChar,50),
					new SqlParameter("@JiaRuBenDanWeiTime", SqlDbType.VarChar,50),
					new SqlParameter("@photo", SqlDbType.NVarChar,50),
					new SqlParameter("@IsDelete", SqlDbType.Int,4),
					new SqlParameter("@DepartmentID", SqlDbType.Int,4),
					new SqlParameter("@IsEnter", SqlDbType.Int,4),
					new SqlParameter("@TelphoneNumber", SqlDbType.NVarChar,50),
					new SqlParameter("@AddTime", SqlDbType.DateTime),
					new SqlParameter("@AddPeople", SqlDbType.VarChar,255),
					new SqlParameter("@loginCount", SqlDbType.Int,4),
					new SqlParameter("@loginTime", SqlDbType.DateTime),
					new SqlParameter("@ID", SqlDbType.Int,4)};
			parameters[0].Value = model.UserName;
			parameters[1].Value = model.UserPwd;
			parameters[2].Value = model.TrueName;
			parameters[3].Value = model.RoleID;
			parameters[4].Value = model.EmailStr;
			parameters[5].Value = model.Sex;
			parameters[6].Value = model.BirthDay;
			parameters[7].Value = model.MingZu;
			parameters[8].Value = model.SFZSerils;
			parameters[9].Value = model.XueLi;
			parameters[10].Value = model.ZhiCheng;
			parameters[11].Value = model.BiYeYuanXiao;
			parameters[12].Value = model.ZhuanYe;
			parameters[13].Value = model.CanJiaGongZuoTime;
			parameters[14].Value = model.JiaRuBenDanWeiTime;
			parameters[15].Value = model.photo;
			parameters[16].Value = model.IsDelete;
			parameters[17].Value = model.DepartmentID;
			parameters[18].Value = model.IsEnter;
			parameters[19].Value = model.TelphoneNumber;
			parameters[20].Value = model.AddTime;
			parameters[21].Value = model.AddPeople;
			parameters[22].Value = model.loginCount;
			parameters[23].Value = model.loginTime;
			parameters[24].Value = model.ID;

			int rows=DbHelperSql.ExecuteSql(strSql.ToString(),parameters);
			if (rows > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(int ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from SystemUser ");
			strSql.Append(" where ID=@ID");
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)
			};
			parameters[0].Value = ID;

			int rows=DbHelperSql.ExecuteSql(strSql.ToString(),parameters);
			if (rows > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}
		/// <summary>
		/// 批量删除数据
		/// </summary>
		public bool DeleteList(string IDlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from SystemUser ");
			strSql.Append(" where ID in ("+IDlist + ")  ");
			int rows=DbHelperSql.ExecuteSql(strSql.ToString());
			if (rows > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Haikan.SchoolProjectsCore.MDB.Model.SystemUser GetModel(int ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 ID,UserName,UserPwd,TrueName,RoleID,EmailStr,Sex,BirthDay,MingZu,SFZSerils,XueLi,ZhiCheng,BiYeYuanXiao,ZhuanYe,CanJiaGongZuoTime,JiaRuBenDanWeiTime,photo,IsDelete,DepartmentID,IsEnter,TelphoneNumber,AddTime,AddPeople,loginCount,loginTime from SystemUser ");
			strSql.Append(" where ID=@ID");
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)
			};
			parameters[0].Value = ID;

			Haikan.SchoolProjectsCore.MDB.Model.SystemUser model=new Haikan.SchoolProjectsCore.MDB.Model.SystemUser();
			DataSet ds=DbHelperSql.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				return DataRowToModel(ds.Tables[0].Rows[0]);
			}
			else
			{
				return null;
			}
		}


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Haikan.SchoolProjectsCore.MDB.Model.SystemUser DataRowToModel(DataRow row)
		{
			Haikan.SchoolProjectsCore.MDB.Model.SystemUser model=new Haikan.SchoolProjectsCore.MDB.Model.SystemUser();
			if (row != null)
			{
				if(row["ID"]!=null && row["ID"].ToString()!="")
				{
					model.ID=int.Parse(row["ID"].ToString());
				}
				if(row["UserName"]!=null)
				{
					model.UserName=row["UserName"].ToString();
				}
				if(row["UserPwd"]!=null)
				{
					model.UserPwd=row["UserPwd"].ToString();
				}
				if(row["TrueName"]!=null)
				{
					model.TrueName=row["TrueName"].ToString();
				}
				if(row["RoleID"]!=null)
				{
					model.RoleID=row["RoleID"].ToString();
				}
				if(row["EmailStr"]!=null)
				{
					model.EmailStr=row["EmailStr"].ToString();
				}
				if(row["Sex"]!=null)
				{
					model.Sex=row["Sex"].ToString();
				}
				if(row["BirthDay"]!=null)
				{
					model.BirthDay=row["BirthDay"].ToString();
				}
				if(row["MingZu"]!=null)
				{
					model.MingZu=row["MingZu"].ToString();
				}
				if(row["SFZSerils"]!=null)
				{
					model.SFZSerils=row["SFZSerils"].ToString();
				}
				if(row["XueLi"]!=null)
				{
					model.XueLi=row["XueLi"].ToString();
				}
				if(row["ZhiCheng"]!=null)
				{
					model.ZhiCheng=row["ZhiCheng"].ToString();
				}
				if(row["BiYeYuanXiao"]!=null)
				{
					model.BiYeYuanXiao=row["BiYeYuanXiao"].ToString();
				}
				if(row["ZhuanYe"]!=null)
				{
					model.ZhuanYe=row["ZhuanYe"].ToString();
				}
				if(row["CanJiaGongZuoTime"]!=null)
				{
					model.CanJiaGongZuoTime=row["CanJiaGongZuoTime"].ToString();
				}
				if(row["JiaRuBenDanWeiTime"]!=null)
				{
					model.JiaRuBenDanWeiTime=row["JiaRuBenDanWeiTime"].ToString();
				}
				if(row["photo"]!=null)
				{
					model.photo=row["photo"].ToString();
				}
				if(row["IsDelete"]!=null && row["IsDelete"].ToString()!="")
				{
					model.IsDelete=int.Parse(row["IsDelete"].ToString());
				}
				if(row["DepartmentID"]!=null && row["DepartmentID"].ToString()!="")
				{
					model.DepartmentID=int.Parse(row["DepartmentID"].ToString());
				}
				if(row["IsEnter"]!=null && row["IsEnter"].ToString()!="")
				{
					model.IsEnter=int.Parse(row["IsEnter"].ToString());
				}
				if(row["TelphoneNumber"]!=null)
				{
					model.TelphoneNumber=row["TelphoneNumber"].ToString();
				}
				if(row["AddTime"]!=null && row["AddTime"].ToString()!="")
				{
					model.AddTime=DateTime.Parse(row["AddTime"].ToString());
				}
				if(row["AddPeople"]!=null)
				{
					model.AddPeople=row["AddPeople"].ToString();
				}
				if(row["loginCount"]!=null && row["loginCount"].ToString()!="")
				{
					model.loginCount=int.Parse(row["loginCount"].ToString());
				}
				if(row["loginTime"]!=null && row["loginTime"].ToString()!="")
				{
					model.loginTime=DateTime.Parse(row["loginTime"].ToString());
				}
			}
			return model;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ID,UserName,UserPwd,TrueName,RoleID,EmailStr,Sex,BirthDay,MingZu,SFZSerils,XueLi,ZhiCheng,BiYeYuanXiao,ZhuanYe,CanJiaGongZuoTime,JiaRuBenDanWeiTime,photo,IsDelete,DepartmentID,IsEnter,TelphoneNumber,AddTime,AddPeople,loginCount,loginTime ");
			strSql.Append(" FROM SystemUser ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			return DbHelperSql.Query(strSql.ToString());
		}

		/// <summary>
		/// 获得前几行数据
		/// </summary>
		public DataSet GetList(int Top,string strWhere,string filedOrder)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ");
			if(Top>0)
			{
				strSql.Append(" top "+Top.ToString());
			}
			strSql.Append(" ID,UserName,UserPwd,TrueName,RoleID,EmailStr,Sex,BirthDay,MingZu,SFZSerils,XueLi,ZhiCheng,BiYeYuanXiao,ZhuanYe,CanJiaGongZuoTime,JiaRuBenDanWeiTime,photo,IsDelete,DepartmentID,IsEnter,TelphoneNumber,AddTime,AddPeople,loginCount,loginTime ");
			strSql.Append(" FROM SystemUser ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			strSql.Append(" order by " + filedOrder);
			return DbHelperSql.Query(strSql.ToString());
		}

		/// <summary>
		/// 获取记录总数
		/// </summary>
		public int GetRecordCount(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) FROM SystemUser ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			object obj = DbHelperSql.GetSingle(strSql.ToString());
			if (obj == null)
			{
				return 0;
			}
			else
			{
				return Convert.ToInt32(obj);
			}
		}
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("SELECT * FROM ( ");
			strSql.Append(" SELECT ROW_NUMBER() OVER (");
			if (!string.IsNullOrEmpty(orderby.Trim()))
			{
				strSql.Append("order by T." + orderby );
			}
			else
			{
				strSql.Append("order by T.ID desc");
			}
			strSql.Append(")AS Row, T.*  from SystemUser T ");
			if (!string.IsNullOrEmpty(strWhere.Trim()))
			{
				strSql.Append(" WHERE " + strWhere);
			}
			strSql.Append(" ) TT");
			strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
			return DbHelperSql.Query(strSql.ToString());
		}

		/*
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public DataSet GetList(int PageSize,int PageIndex,string strWhere)
		{
			SqlParameter[] parameters = {
					new SqlParameter("@tblName", SqlDbType.VarChar, 255),
					new SqlParameter("@fldName", SqlDbType.VarChar, 255),
					new SqlParameter("@PageSize", SqlDbType.Int),
					new SqlParameter("@PageIndex", SqlDbType.Int),
					new SqlParameter("@IsReCount", SqlDbType.Bit),
					new SqlParameter("@OrderType", SqlDbType.Bit),
					new SqlParameter("@strWhere", SqlDbType.VarChar,1000),
					};
			parameters[0].Value = "SystemUser";
			parameters[1].Value = "ID";
			parameters[2].Value = PageSize;
			parameters[3].Value = PageIndex;
			parameters[4].Value = 0;
			parameters[5].Value = 0;
			parameters[6].Value = strWhere;	
			return DbHelperSql.RunProcedure("UP_GetRecordByPage",parameters,"ds");
		}*/

		#endregion  BasicMethod
		#region  ExtensionMethod

		#endregion  ExtensionMethod
	}
}

