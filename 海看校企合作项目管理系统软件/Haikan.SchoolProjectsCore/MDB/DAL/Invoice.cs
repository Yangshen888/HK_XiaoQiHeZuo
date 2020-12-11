using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Haikan2.DBHelper;
namespace Haikan.SchoolProjectsCore.MDB.DAL
{
	/// <summary>
	/// 数据访问类:Invoice
	/// </summary>
	public partial class Invoice
	{
		public Invoice()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSql.GetMaxId("InvoiceID", "Invoice"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int InvoiceID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from Invoice");
			strSql.Append(" where InvoiceID=@InvoiceID");
			SqlParameter[] parameters = {
					new SqlParameter("@InvoiceID", SqlDbType.Int,4)
			};
			parameters[0].Value = InvoiceID;

			return DbHelperSql.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(Haikan.SchoolProjectsCore.MDB.Model.Invoice model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into Invoice(");
			strSql.Append("ProjectName,EnterpriseName,InvoiceName,InvoiceTime,Note)");
			strSql.Append(" values (");
			strSql.Append("@ProjectName,@EnterpriseName,@InvoiceName,@InvoiceTime,@Note)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@ProjectName", SqlDbType.VarChar,50),
					new SqlParameter("@EnterpriseName", SqlDbType.VarChar,50),
					new SqlParameter("@InvoiceName", SqlDbType.VarChar,20),
					new SqlParameter("@InvoiceTime", SqlDbType.VarChar,20),
					new SqlParameter("@Note", SqlDbType.VarChar,20)};
			parameters[0].Value = model.ProjectName;
			parameters[1].Value = model.EnterpriseName;
			parameters[2].Value = model.InvoiceName;
			parameters[3].Value = model.InvoiceTime;
			parameters[4].Value = model.Note;

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
		public bool Update(Haikan.SchoolProjectsCore.MDB.Model.Invoice model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update Invoice set ");
			strSql.Append("ProjectName=@ProjectName,");
			strSql.Append("EnterpriseName=@EnterpriseName,");
			strSql.Append("InvoiceName=@InvoiceName,");
			strSql.Append("InvoiceTime=@InvoiceTime,");
			strSql.Append("Note=@Note");
			strSql.Append(" where InvoiceID=@InvoiceID");
			SqlParameter[] parameters = {
					new SqlParameter("@ProjectName", SqlDbType.VarChar,50),
					new SqlParameter("@EnterpriseName", SqlDbType.VarChar,50),
					new SqlParameter("@InvoiceName", SqlDbType.VarChar,20),
					new SqlParameter("@InvoiceTime", SqlDbType.VarChar,20),
					new SqlParameter("@Note", SqlDbType.VarChar,20),
					new SqlParameter("@InvoiceID", SqlDbType.Int,4)};
			parameters[0].Value = model.ProjectName;
			parameters[1].Value = model.EnterpriseName;
			parameters[2].Value = model.InvoiceName;
			parameters[3].Value = model.InvoiceTime;
			parameters[4].Value = model.Note;
			parameters[5].Value = model.InvoiceID;

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
		public bool Delete(int InvoiceID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Invoice ");
			strSql.Append(" where InvoiceID=@InvoiceID");
			SqlParameter[] parameters = {
					new SqlParameter("@InvoiceID", SqlDbType.Int,4)
			};
			parameters[0].Value = InvoiceID;

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
		public bool DeleteList(string InvoiceIDlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Invoice ");
			strSql.Append(" where InvoiceID in ("+InvoiceIDlist + ")  ");
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
		public Haikan.SchoolProjectsCore.MDB.Model.Invoice GetModel(int InvoiceID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 ProjectName,EnterpriseName,InvoiceID,InvoiceName,InvoiceTime,Note from Invoice ");
			strSql.Append(" where InvoiceID=@InvoiceID");
			SqlParameter[] parameters = {
					new SqlParameter("@InvoiceID", SqlDbType.Int,4)
			};
			parameters[0].Value = InvoiceID;

			Haikan.SchoolProjectsCore.MDB.Model.Invoice model=new Haikan.SchoolProjectsCore.MDB.Model.Invoice();
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
		public Haikan.SchoolProjectsCore.MDB.Model.Invoice DataRowToModel(DataRow row)
		{
			Haikan.SchoolProjectsCore.MDB.Model.Invoice model=new Haikan.SchoolProjectsCore.MDB.Model.Invoice();
			if (row != null)
			{
				if(row["ProjectName"]!=null)
				{
					model.ProjectName=row["ProjectName"].ToString();
				}
				if(row["EnterpriseName"]!=null)
				{
					model.EnterpriseName=row["EnterpriseName"].ToString();
				}
				if(row["InvoiceID"]!=null && row["InvoiceID"].ToString()!="")
				{
					model.InvoiceID=int.Parse(row["InvoiceID"].ToString());
				}
				if(row["InvoiceName"]!=null)
				{
					model.InvoiceName=row["InvoiceName"].ToString();
				}
				if(row["InvoiceTime"]!=null)
				{
					model.InvoiceTime=row["InvoiceTime"].ToString();
				}
				if(row["Note"]!=null)
				{
					model.Note=row["Note"].ToString();
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
			strSql.Append("select ProjectName,EnterpriseName,InvoiceID,InvoiceName,InvoiceTime,Note ");
			strSql.Append(" FROM Invoice ");
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
			strSql.Append(" ProjectName,EnterpriseName,InvoiceID,InvoiceName,InvoiceTime,Note ");
			strSql.Append(" FROM Invoice ");
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
			strSql.Append("select count(1) FROM Invoice ");
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
				strSql.Append("order by T.InvoiceID desc");
			}
			strSql.Append(")AS Row, T.*  from Invoice T ");
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
			parameters[0].Value = "Invoice";
			parameters[1].Value = "InvoiceID";
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

