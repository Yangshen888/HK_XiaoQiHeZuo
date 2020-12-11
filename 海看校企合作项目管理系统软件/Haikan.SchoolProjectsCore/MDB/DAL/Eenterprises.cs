using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Haikan2.DBHelper;
namespace Haikan.SchoolProjectsCore.MDB.DAL
{
	/// <summary>
	/// 数据访问类:Eenterprises
	/// </summary>
	public partial class Eenterprises
	{
		public Eenterprises()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSql.GetMaxId("EnterpriseID", "Eenterprises"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int EnterpriseID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from Eenterprises");
			strSql.Append(" where EnterpriseID=@EnterpriseID");
			SqlParameter[] parameters = {
					new SqlParameter("@EnterpriseID", SqlDbType.Int,4)
			};
			parameters[0].Value = EnterpriseID;

			return DbHelperSql.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(Haikan.SchoolProjectsCore.MDB.Model.Eenterprises model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into Eenterprises(");
			strSql.Append("EnterpriseName,Contact,EInformation,Note,Audit)");
			strSql.Append(" values (");
			strSql.Append("@EnterpriseName,@Contact,@EInformation,@Note,@Audit)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@EnterpriseName", SqlDbType.VarChar,255),
					new SqlParameter("@Contact", SqlDbType.VarChar,255),
					new SqlParameter("@EInformation", SqlDbType.VarChar,255),
					new SqlParameter("@Note", SqlDbType.VarChar,255),
					new SqlParameter("@Audit", SqlDbType.VarChar,255)};
			parameters[0].Value = model.EnterpriseName;
			parameters[1].Value = model.Contact;
			parameters[2].Value = model.EInformation;
			parameters[3].Value = model.Note;
			parameters[4].Value = model.Audit;

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
		public bool Update(Haikan.SchoolProjectsCore.MDB.Model.Eenterprises model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update Eenterprises set ");
			strSql.Append("EnterpriseName=@EnterpriseName,");
			strSql.Append("Contact=@Contact,");
			strSql.Append("EInformation=@EInformation,");
			strSql.Append("Note=@Note,");
			strSql.Append("Audit=@Audit");
			strSql.Append(" where EnterpriseID=@EnterpriseID");
			SqlParameter[] parameters = {
					new SqlParameter("@EnterpriseName", SqlDbType.VarChar,255),
					new SqlParameter("@Contact", SqlDbType.VarChar,255),
					new SqlParameter("@EInformation", SqlDbType.VarChar,255),
					new SqlParameter("@Note", SqlDbType.VarChar,255),
					new SqlParameter("@Audit", SqlDbType.VarChar,255),
					new SqlParameter("@EnterpriseID", SqlDbType.Int,4)};
			parameters[0].Value = model.EnterpriseName;
			parameters[1].Value = model.Contact;
			parameters[2].Value = model.EInformation;
			parameters[3].Value = model.Note;
			parameters[4].Value = model.Audit;
			parameters[5].Value = model.EnterpriseID;

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
		public bool Delete(int EnterpriseID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Eenterprises ");
			strSql.Append(" where EnterpriseID=@EnterpriseID");
			SqlParameter[] parameters = {
					new SqlParameter("@EnterpriseID", SqlDbType.Int,4)
			};
			parameters[0].Value = EnterpriseID;

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
		public bool DeleteList(string EnterpriseIDlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Eenterprises ");
			strSql.Append(" where EnterpriseID in ("+EnterpriseIDlist + ")  ");
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
		public Haikan.SchoolProjectsCore.MDB.Model.Eenterprises GetModel(int EnterpriseID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 EnterpriseID,EnterpriseName,Contact,EInformation,Note,Audit from Eenterprises ");
			strSql.Append(" where EnterpriseID=@EnterpriseID");
			SqlParameter[] parameters = {
					new SqlParameter("@EnterpriseID", SqlDbType.Int,4)
			};
			parameters[0].Value = EnterpriseID;

			Haikan.SchoolProjectsCore.MDB.Model.Eenterprises model=new Haikan.SchoolProjectsCore.MDB.Model.Eenterprises();
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
		public Haikan.SchoolProjectsCore.MDB.Model.Eenterprises DataRowToModel(DataRow row)
		{
			Haikan.SchoolProjectsCore.MDB.Model.Eenterprises model=new Haikan.SchoolProjectsCore.MDB.Model.Eenterprises();
			if (row != null)
			{
				if(row["EnterpriseID"]!=null && row["EnterpriseID"].ToString()!="")
				{
					model.EnterpriseID=int.Parse(row["EnterpriseID"].ToString());
				}
				if(row["EnterpriseName"]!=null)
				{
					model.EnterpriseName=row["EnterpriseName"].ToString();
				}
				if(row["Contact"]!=null)
				{
					model.Contact=row["Contact"].ToString();
				}
				if(row["EInformation"]!=null)
				{
					model.EInformation=row["EInformation"].ToString();
				}
				if(row["Note"]!=null)
				{
					model.Note=row["Note"].ToString();
				}
				if(row["Audit"]!=null)
				{
					model.Audit=row["Audit"].ToString();
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
			strSql.Append("select EnterpriseID,EnterpriseName,Contact,EInformation,Note,Audit ");
			strSql.Append(" FROM Eenterprises ");
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
			strSql.Append(" EnterpriseID,EnterpriseName,Contact,EInformation,Note,Audit ");
			strSql.Append(" FROM Eenterprises ");
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
			strSql.Append("select count(1) FROM Eenterprises ");
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
				strSql.Append("order by T.EnterpriseID desc");
			}
			strSql.Append(")AS Row, T.*  from Eenterprises T ");
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
			parameters[0].Value = "Eenterprises";
			parameters[1].Value = "EnterpriseID";
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

