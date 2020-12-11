using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Haikan2.DBHelper;
namespace Haikan.SchoolProjectsCore.MDB.DAL
{
	/// <summary>
	/// 数据访问类:HFile
	/// </summary>
	public partial class HFile
	{
		public HFile()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSql.GetMaxId("FileID", "HFile"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int FileID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from HFile");
			strSql.Append(" where FileID=@FileID");
			SqlParameter[] parameters = {
					new SqlParameter("@FileID", SqlDbType.Int,4)
			};
			parameters[0].Value = FileID;

			return DbHelperSql.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(Haikan.SchoolProjectsCore.MDB.Model.HFile model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into HFile(");
			strSql.Append("EnterpriseName,EnterpriseFile,ContractFile,InvoiceFile,ProjectFile,IsDele)");
			strSql.Append(" values (");
			strSql.Append("@EnterpriseName,@EnterpriseFile,@ContractFile,@InvoiceFile,@ProjectFile,@IsDele)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@EnterpriseName", SqlDbType.VarChar,255),
					new SqlParameter("@EnterpriseFile", SqlDbType.VarChar,255),
					new SqlParameter("@ContractFile", SqlDbType.VarChar,255),
					new SqlParameter("@InvoiceFile", SqlDbType.VarChar,255),
					new SqlParameter("@ProjectFile", SqlDbType.VarChar,255),
					new SqlParameter("@IsDele", SqlDbType.VarChar,255)};
			parameters[0].Value = model.EnterpriseName;
			parameters[1].Value = model.EnterpriseFile;
			parameters[2].Value = model.ContractFile;
			parameters[3].Value = model.InvoiceFile;
			parameters[4].Value = model.ProjectFile;
			parameters[5].Value = model.IsDele;

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
		public bool Update(Haikan.SchoolProjectsCore.MDB.Model.HFile model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update HFile set ");
			strSql.Append("EnterpriseName=@EnterpriseName,");
			strSql.Append("EnterpriseFile=@EnterpriseFile,");
			strSql.Append("ContractFile=@ContractFile,");
			strSql.Append("InvoiceFile=@InvoiceFile,");
			strSql.Append("ProjectFile=@ProjectFile,");
			strSql.Append("IsDele=@IsDele");
			strSql.Append(" where FileID=@FileID");
			SqlParameter[] parameters = {
					new SqlParameter("@EnterpriseName", SqlDbType.VarChar,255),
					new SqlParameter("@EnterpriseFile", SqlDbType.VarChar,255),
					new SqlParameter("@ContractFile", SqlDbType.VarChar,255),
					new SqlParameter("@InvoiceFile", SqlDbType.VarChar,255),
					new SqlParameter("@ProjectFile", SqlDbType.VarChar,255),
					new SqlParameter("@IsDele", SqlDbType.VarChar,255),
					new SqlParameter("@FileID", SqlDbType.Int,4)};
			parameters[0].Value = model.EnterpriseName;
			parameters[1].Value = model.EnterpriseFile;
			parameters[2].Value = model.ContractFile;
			parameters[3].Value = model.InvoiceFile;
			parameters[4].Value = model.ProjectFile;
			parameters[5].Value = model.IsDele;
			parameters[6].Value = model.FileID;

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
		public bool Delete(int FileID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from HFile ");
			strSql.Append(" where FileID=@FileID");
			SqlParameter[] parameters = {
					new SqlParameter("@FileID", SqlDbType.Int,4)
			};
			parameters[0].Value = FileID;

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
		public bool DeleteList(string FileIDlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from HFile ");
			strSql.Append(" where FileID in ("+FileIDlist + ")  ");
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
		public Haikan.SchoolProjectsCore.MDB.Model.HFile GetModel(int FileID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 FileID,EnterpriseName,EnterpriseFile,ContractFile,InvoiceFile,ProjectFile,IsDele from HFile ");
			strSql.Append(" where FileID=@FileID");
			SqlParameter[] parameters = {
					new SqlParameter("@FileID", SqlDbType.Int,4)
			};
			parameters[0].Value = FileID;

			Haikan.SchoolProjectsCore.MDB.Model.HFile model=new Haikan.SchoolProjectsCore.MDB.Model.HFile();
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
		public Haikan.SchoolProjectsCore.MDB.Model.HFile DataRowToModel(DataRow row)
		{
			Haikan.SchoolProjectsCore.MDB.Model.HFile model=new Haikan.SchoolProjectsCore.MDB.Model.HFile();
			if (row != null)
			{
				if(row["FileID"]!=null && row["FileID"].ToString()!="")
				{
					model.FileID=int.Parse(row["FileID"].ToString());
				}
				if(row["EnterpriseName"]!=null)
				{
					model.EnterpriseName=row["EnterpriseName"].ToString();
				}
				if(row["EnterpriseFile"]!=null)
				{
					model.EnterpriseFile=row["EnterpriseFile"].ToString();
				}
				if(row["ContractFile"]!=null)
				{
					model.ContractFile=row["ContractFile"].ToString();
				}
				if(row["InvoiceFile"]!=null)
				{
					model.InvoiceFile=row["InvoiceFile"].ToString();
				}
				if(row["ProjectFile"]!=null)
				{
					model.ProjectFile=row["ProjectFile"].ToString();
				}
				if(row["IsDele"]!=null)
				{
					model.IsDele=row["IsDele"].ToString();
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
			strSql.Append("select FileID,EnterpriseName,EnterpriseFile,ContractFile,InvoiceFile,ProjectFile,IsDele ");
			strSql.Append(" FROM HFile ");
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
			strSql.Append(" FileID,EnterpriseName,EnterpriseFile,ContractFile,InvoiceFile,ProjectFile,IsDele ");
			strSql.Append(" FROM HFile ");
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
			strSql.Append("select count(1) FROM HFile ");
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
				strSql.Append("order by T.FileID desc");
			}
			strSql.Append(")AS Row, T.*  from HFile T ");
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
			parameters[0].Value = "HFile";
			parameters[1].Value = "FileID";
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

