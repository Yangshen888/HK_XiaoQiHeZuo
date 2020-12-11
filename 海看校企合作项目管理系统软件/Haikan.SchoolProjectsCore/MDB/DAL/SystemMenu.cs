using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Haikan2.DBHelper;
namespace Haikan.SchoolProjectsCore.MDB.DAL
{
	/// <summary>
	/// 数据访问类:SystemMenu
	/// </summary>
	public partial class SystemMenu
	{
		public SystemMenu()
		{}
		#region  BasicMethod



		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(Haikan.SchoolProjectsCore.MDB.Model.SystemMenu model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into SystemMenu(");
			strSql.Append("FullName,ParentID,Category,Icon,Target,Level,SortCode,Location,Remark,MenuRole)");
			strSql.Append(" values (");
			strSql.Append("@FullName,@ParentID,@Category,@Icon,@Target,@Level,@SortCode,@Location,@Remark,@MenuRole)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@FullName", SqlDbType.VarChar,100),
					new SqlParameter("@ParentID", SqlDbType.Int,4),
					new SqlParameter("@Category", SqlDbType.VarChar,100),
					new SqlParameter("@Icon", SqlDbType.VarChar,100),
					new SqlParameter("@Target", SqlDbType.VarChar,100),
					new SqlParameter("@Level", SqlDbType.VarChar,100),
					new SqlParameter("@SortCode", SqlDbType.VarChar,100),
					new SqlParameter("@Location", SqlDbType.VarChar,100),
					new SqlParameter("@Remark", SqlDbType.VarChar,100),
					new SqlParameter("@MenuRole", SqlDbType.VarChar,100)};
			parameters[0].Value = model.FullName;
			parameters[1].Value = model.ParentID;
			parameters[2].Value = model.Category;
			parameters[3].Value = model.Icon;
			parameters[4].Value = model.Target;
			parameters[5].Value = model.Level;
			parameters[6].Value = model.SortCode;
			parameters[7].Value = model.Location;
			parameters[8].Value = model.Remark;
			parameters[9].Value = model.MenuRole;

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
		public bool Update(Haikan.SchoolProjectsCore.MDB.Model.SystemMenu model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update SystemMenu set ");
			strSql.Append("FullName=@FullName,");
			strSql.Append("ParentID=@ParentID,");
			strSql.Append("Category=@Category,");
			strSql.Append("Icon=@Icon,");
			strSql.Append("Target=@Target,");
			strSql.Append("Level=@Level,");
			strSql.Append("SortCode=@SortCode,");
			strSql.Append("Location=@Location,");
			strSql.Append("Remark=@Remark,");
			strSql.Append("MenuRole=@MenuRole");
			strSql.Append(" where ModuleID=@ModuleID");
			SqlParameter[] parameters = {
					new SqlParameter("@FullName", SqlDbType.VarChar,100),
					new SqlParameter("@ParentID", SqlDbType.Int,4),
					new SqlParameter("@Category", SqlDbType.VarChar,100),
					new SqlParameter("@Icon", SqlDbType.VarChar,100),
					new SqlParameter("@Target", SqlDbType.VarChar,100),
					new SqlParameter("@Level", SqlDbType.VarChar,100),
					new SqlParameter("@SortCode", SqlDbType.VarChar,100),
					new SqlParameter("@Location", SqlDbType.VarChar,100),
					new SqlParameter("@Remark", SqlDbType.VarChar,100),
					new SqlParameter("@MenuRole", SqlDbType.VarChar,100),
					new SqlParameter("@ModuleID", SqlDbType.Int,4)};
			parameters[0].Value = model.FullName;
			parameters[1].Value = model.ParentID;
			parameters[2].Value = model.Category;
			parameters[3].Value = model.Icon;
			parameters[4].Value = model.Target;
			parameters[5].Value = model.Level;
			parameters[6].Value = model.SortCode;
			parameters[7].Value = model.Location;
			parameters[8].Value = model.Remark;
			parameters[9].Value = model.MenuRole;
			parameters[10].Value = model.ModuleID;

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
		public bool Delete(int ModuleID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from SystemMenu ");
			strSql.Append(" where ModuleID=@ModuleID");
			SqlParameter[] parameters = {
					new SqlParameter("@ModuleID", SqlDbType.Int,4)
			};
			parameters[0].Value = ModuleID;

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
		public bool DeleteList(string ModuleIDlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from SystemMenu ");
			strSql.Append(" where ModuleID in ("+ModuleIDlist + ")  ");
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
		public Haikan.SchoolProjectsCore.MDB.Model.SystemMenu GetModel(int ModuleID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 ModuleID,FullName,ParentID,Category,Icon,Target,Level,SortCode,Location,Remark,MenuRole from SystemMenu ");
			strSql.Append(" where ModuleID=@ModuleID");
			SqlParameter[] parameters = {
					new SqlParameter("@ModuleID", SqlDbType.Int,4)
			};
			parameters[0].Value = ModuleID;

			Haikan.SchoolProjectsCore.MDB.Model.SystemMenu model=new Haikan.SchoolProjectsCore.MDB.Model.SystemMenu();
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
		public Haikan.SchoolProjectsCore.MDB.Model.SystemMenu DataRowToModel(DataRow row)
		{
			Haikan.SchoolProjectsCore.MDB.Model.SystemMenu model=new Haikan.SchoolProjectsCore.MDB.Model.SystemMenu();
			if (row != null)
			{
				if(row["ModuleID"]!=null && row["ModuleID"].ToString()!="")
				{
					model.ModuleID=int.Parse(row["ModuleID"].ToString());
				}
				if(row["FullName"]!=null)
				{
					model.FullName=row["FullName"].ToString();
				}
				if(row["ParentID"]!=null && row["ParentID"].ToString()!="")
				{
					model.ParentID=int.Parse(row["ParentID"].ToString());
				}
				if(row["Category"]!=null)
				{
					model.Category=row["Category"].ToString();
				}
				if(row["Icon"]!=null)
				{
					model.Icon=row["Icon"].ToString();
				}
				if(row["Target"]!=null)
				{
					model.Target=row["Target"].ToString();
				}
				if(row["Level"]!=null)
				{
					model.Level=row["Level"].ToString();
				}
				if(row["SortCode"]!=null)
				{
					model.SortCode=row["SortCode"].ToString();
				}
				if(row["Location"]!=null)
				{
					model.Location=row["Location"].ToString();
				}
				if(row["Remark"]!=null)
				{
					model.Remark=row["Remark"].ToString();
				}
				if(row["MenuRole"]!=null)
				{
					model.MenuRole=row["MenuRole"].ToString();
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
			strSql.Append("select ModuleID,FullName,ParentID,Category,Icon,Target,Level,SortCode,Location,Remark,MenuRole ");
			strSql.Append(" FROM SystemMenu ");
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
			strSql.Append(" ModuleID,FullName,ParentID,Category,Icon,Target,Level,SortCode,Location,Remark,MenuRole ");
			strSql.Append(" FROM SystemMenu ");
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
			strSql.Append("select count(1) FROM SystemMenu ");
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
				strSql.Append("order by T.ModuleID desc");
			}
			strSql.Append(")AS Row, T.*  from SystemMenu T ");
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
			parameters[0].Value = "SystemMenu";
			parameters[1].Value = "ModuleID";
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

