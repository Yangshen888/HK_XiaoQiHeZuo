using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Haikan2.DBHelper;
namespace Haikan.SchoolProjectsCore.MDB.DAL
{
	/// <summary>
	/// 数据访问类:SystemSetting
	/// </summary>
	public partial class SystemSetting
	{
		public SystemSetting()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
			return DbHelperSql.GetMaxId("ID", "SystemSetting");
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int ID)
		{
			StringBuilder strSql = new StringBuilder();
			strSql.Append("select count(1) from SystemSetting");
			strSql.Append(" where ID=@ID ");
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)            };
			parameters[0].Value = ID;

			return DbHelperSql.Exists(strSql.ToString(), parameters);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(Haikan.SchoolProjectsCore.MDB.Model.SystemSetting model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into SystemSetting(");
			strSql.Append("SystemName,SystemPicture,Email,smtpSeverName,EmailName,Emailpwd,FileType,IsIdentifyingCode)");
			strSql.Append(" values (");
			strSql.Append("@SystemName,@SystemPicture,@Email,@smtpSeverName,@EmailName,@Emailpwd,@FileType,@IsIdentifyingCode)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@SystemName", SqlDbType.VarChar,255),
					new SqlParameter("@SystemPicture", SqlDbType.VarChar,255),
					new SqlParameter("@Email", SqlDbType.VarChar,255),
					new SqlParameter("@smtpSeverName", SqlDbType.VarChar,255),
					new SqlParameter("@EmailName", SqlDbType.VarChar,255),
					new SqlParameter("@Emailpwd", SqlDbType.VarChar,255),
					new SqlParameter("@FileType", SqlDbType.VarChar,255),
					new SqlParameter("@IsIdentifyingCode", SqlDbType.Int,4)};
			parameters[0].Value = model.SystemName;
			parameters[1].Value = model.SystemPicture;
			parameters[2].Value = model.Email;
			parameters[3].Value = model.smtpSeverName;
			parameters[4].Value = model.EmailName;
			parameters[5].Value = model.Emailpwd;
			parameters[6].Value = model.FileType;
			parameters[7].Value = model.IsIdentifyingCode;

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
		public bool Update(Haikan.SchoolProjectsCore.MDB.Model.SystemSetting model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update SystemSetting set ");
			strSql.Append("SystemName=@SystemName,");
			strSql.Append("SystemPicture=@SystemPicture,");
			strSql.Append("Email=@Email,");
			strSql.Append("smtpSeverName=@smtpSeverName,");
			strSql.Append("EmailName=@EmailName,");
			strSql.Append("Emailpwd=@Emailpwd,");
			strSql.Append("FileType=@FileType,");
			strSql.Append("IsIdentifyingCode=@IsIdentifyingCode");
			strSql.Append(" where ID=@ID");
			SqlParameter[] parameters = {
					new SqlParameter("@SystemName", SqlDbType.VarChar,255),
					new SqlParameter("@SystemPicture", SqlDbType.VarChar,255),
					new SqlParameter("@Email", SqlDbType.VarChar,255),
					new SqlParameter("@smtpSeverName", SqlDbType.VarChar,255),
					new SqlParameter("@EmailName", SqlDbType.VarChar,255),
					new SqlParameter("@Emailpwd", SqlDbType.VarChar,255),
					new SqlParameter("@FileType", SqlDbType.VarChar,255),
					new SqlParameter("@IsIdentifyingCode", SqlDbType.Int,4),
					new SqlParameter("@ID", SqlDbType.Int,4)};
			parameters[0].Value = model.SystemName;
			parameters[1].Value = model.SystemPicture;
			parameters[2].Value = model.Email;
			parameters[3].Value = model.smtpSeverName;
			parameters[4].Value = model.EmailName;
			parameters[5].Value = model.Emailpwd;
			parameters[6].Value = model.FileType;
			parameters[7].Value = model.IsIdentifyingCode;
			parameters[8].Value = model.ID;

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
			strSql.Append("delete from SystemSetting ");
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
			strSql.Append("delete from SystemSetting ");
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
		public Haikan.SchoolProjectsCore.MDB.Model.SystemSetting GetModel(int ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 ID,SystemName,SystemPicture,Email,smtpSeverName,EmailName,Emailpwd,FileType,IsIdentifyingCode from SystemSetting ");
			strSql.Append(" where ID=@ID");
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)
			};
			parameters[0].Value = ID;

			Haikan.SchoolProjectsCore.MDB.Model.SystemSetting model=new Haikan.SchoolProjectsCore.MDB.Model.SystemSetting();
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
		public Haikan.SchoolProjectsCore.MDB.Model.SystemSetting DataRowToModel(DataRow row)
		{
			Haikan.SchoolProjectsCore.MDB.Model.SystemSetting model=new Haikan.SchoolProjectsCore.MDB.Model.SystemSetting();
			if (row != null)
			{
				if(row["ID"]!=null && row["ID"].ToString()!="")
				{
					model.ID=int.Parse(row["ID"].ToString());
				}
				if(row["SystemName"]!=null)
				{
					model.SystemName=row["SystemName"].ToString();
				}
				if(row["SystemPicture"]!=null)
				{
					model.SystemPicture=row["SystemPicture"].ToString();
				}
				if(row["Email"]!=null)
				{
					model.Email=row["Email"].ToString();
				}
				if(row["smtpSeverName"]!=null)
				{
					model.smtpSeverName=row["smtpSeverName"].ToString();
				}
				if(row["EmailName"]!=null)
				{
					model.EmailName=row["EmailName"].ToString();
				}
				if(row["Emailpwd"]!=null)
				{
					model.Emailpwd=row["Emailpwd"].ToString();
				}
				if(row["FileType"]!=null)
				{
					model.FileType=row["FileType"].ToString();
				}
				if(row["IsIdentifyingCode"]!=null && row["IsIdentifyingCode"].ToString()!="")
				{
					model.IsIdentifyingCode=int.Parse(row["IsIdentifyingCode"].ToString());
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
			strSql.Append("select ID,SystemName,SystemPicture,Email,smtpSeverName,EmailName,Emailpwd,FileType,IsIdentifyingCode ");
			strSql.Append(" FROM SystemSetting ");
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
			strSql.Append(" ID,SystemName,SystemPicture,Email,smtpSeverName,EmailName,Emailpwd,FileType,IsIdentifyingCode ");
			strSql.Append(" FROM SystemSetting ");
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
			strSql.Append("select count(1) FROM SystemSetting ");
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
			strSql.Append(")AS Row, T.*  from SystemSetting T ");
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
			parameters[0].Value = "SystemSetting";
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

