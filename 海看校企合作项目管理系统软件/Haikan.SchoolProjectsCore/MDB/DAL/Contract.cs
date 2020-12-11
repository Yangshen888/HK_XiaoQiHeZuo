using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Haikan2.DBHelper;
namespace Haikan.SchoolProjectsCore.MDB.DAL
{
	/// <summary>
	/// 数据访问类:Contract
	/// </summary>
	public partial class Contract
	{
		public Contract()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSql.GetMaxId("CID", "Contract"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int CID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from Contract");
			strSql.Append(" where CID=@CID");
			SqlParameter[] parameters = {
					new SqlParameter("@CID", SqlDbType.Int,4)
			};
			parameters[0].Value = CID;

			return DbHelperSql.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(Haikan.SchoolProjectsCore.MDB.Model.Contract model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into Contract(");
			strSql.Append("ProjectID,EnterpriseName,ContractName,CInformation,Note,ConsigneeA,ConsigneeB,LastTime,Money)");
			strSql.Append(" values (");
			strSql.Append("@ProjectID,@EnterpriseName,@ContractName,@CInformation,@Note,@ConsigneeA,@ConsigneeB,@LastTime,@Money)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@ProjectID", SqlDbType.Int,4),
					new SqlParameter("@EnterpriseName", SqlDbType.VarChar,255),
					new SqlParameter("@ContractName", SqlDbType.VarChar,255),
					new SqlParameter("@CInformation", SqlDbType.VarChar,255),
					new SqlParameter("@Note", SqlDbType.VarChar,255),
					new SqlParameter("@ConsigneeA", SqlDbType.VarChar,255),
					new SqlParameter("@ConsigneeB", SqlDbType.VarChar,255),
					new SqlParameter("@LastTime", SqlDbType.VarChar,255),
					new SqlParameter("@Money", SqlDbType.VarChar,255)};
			parameters[0].Value = model.ProjectID;
			parameters[1].Value = model.EnterpriseName;
			parameters[2].Value = model.ContractName;
			parameters[3].Value = model.CInformation;
			parameters[4].Value = model.Note;
			parameters[5].Value = model.ConsigneeA;
			parameters[6].Value = model.ConsigneeB;
			parameters[7].Value = model.LastTime;
			parameters[8].Value = model.Money;

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
		public bool Update(Haikan.SchoolProjectsCore.MDB.Model.Contract model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update Contract set ");
			strSql.Append("ProjectID=@ProjectID,");
			strSql.Append("EnterpriseName=@EnterpriseName,");
			strSql.Append("ContractName=@ContractName,");
			strSql.Append("CInformation=@CInformation,");
			strSql.Append("Note=@Note,");
			strSql.Append("ConsigneeA=@ConsigneeA,");
			strSql.Append("ConsigneeB=@ConsigneeB,");
			strSql.Append("LastTime=@LastTime,");
			strSql.Append("Money=@Money");
			strSql.Append(" where CID=@CID");
			SqlParameter[] parameters = {
					new SqlParameter("@ProjectID", SqlDbType.Int,4),
					new SqlParameter("@EnterpriseName", SqlDbType.VarChar,255),
					new SqlParameter("@ContractName", SqlDbType.VarChar,255),
					new SqlParameter("@CInformation", SqlDbType.VarChar,255),
					new SqlParameter("@Note", SqlDbType.VarChar,255),
					new SqlParameter("@ConsigneeA", SqlDbType.VarChar,255),
					new SqlParameter("@ConsigneeB", SqlDbType.VarChar,255),
					new SqlParameter("@LastTime", SqlDbType.VarChar,255),
					new SqlParameter("@Money", SqlDbType.VarChar,255),
					new SqlParameter("@CID", SqlDbType.Int,4)};
			parameters[0].Value = model.ProjectID;
			parameters[1].Value = model.EnterpriseName;
			parameters[2].Value = model.ContractName;
			parameters[3].Value = model.CInformation;
			parameters[4].Value = model.Note;
			parameters[5].Value = model.ConsigneeA;
			parameters[6].Value = model.ConsigneeB;
			parameters[7].Value = model.LastTime;
			parameters[8].Value = model.Money;
			parameters[9].Value = model.CID;

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
		public bool Delete(int CID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Contract ");
			strSql.Append(" where CID=@CID");
			SqlParameter[] parameters = {
					new SqlParameter("@CID", SqlDbType.Int,4)
			};
			parameters[0].Value = CID;

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
		public bool DeleteList(string CIDlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Contract ");
			strSql.Append(" where CID in ("+CIDlist + ")  ");
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
		public Haikan.SchoolProjectsCore.MDB.Model.Contract GetModel(int CID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 CID,ProjectID,EnterpriseName,ContractName,CInformation,Note,ConsigneeA,ConsigneeB,LastTime,Money from Contract ");
			strSql.Append(" where CID=@CID");
			SqlParameter[] parameters = {
					new SqlParameter("@CID", SqlDbType.Int,4)
			};
			parameters[0].Value = CID;

			Haikan.SchoolProjectsCore.MDB.Model.Contract model=new Haikan.SchoolProjectsCore.MDB.Model.Contract();
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
		public Haikan.SchoolProjectsCore.MDB.Model.Contract DataRowToModel(DataRow row)
		{
			Haikan.SchoolProjectsCore.MDB.Model.Contract model=new Haikan.SchoolProjectsCore.MDB.Model.Contract();
			if (row != null)
			{
				if(row["CID"]!=null && row["CID"].ToString()!="")
				{
					model.CID=int.Parse(row["CID"].ToString());
				}
				if(row["ProjectID"]!=null && row["ProjectID"].ToString()!="")
				{
					model.ProjectID=int.Parse(row["ProjectID"].ToString());
				}
				if(row["EnterpriseName"]!=null)
				{
					model.EnterpriseName=row["EnterpriseName"].ToString();
				}
				if(row["ContractName"]!=null)
				{
					model.ContractName=row["ContractName"].ToString();
				}
				if(row["CInformation"]!=null)
				{
					model.CInformation=row["CInformation"].ToString();
				}
				if(row["Note"]!=null)
				{
					model.Note=row["Note"].ToString();
				}
				if(row["ConsigneeA"]!=null)
				{
					model.ConsigneeA=row["ConsigneeA"].ToString();
				}
				if(row["ConsigneeB"]!=null)
				{
					model.ConsigneeB=row["ConsigneeB"].ToString();
				}
				if(row["LastTime"]!=null)
				{
					model.LastTime=row["LastTime"].ToString();
				}
				if(row["Money"]!=null)
				{
					model.Money=row["Money"].ToString();
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
			strSql.Append("select CID,ProjectID,EnterpriseName,ContractName,CInformation,Note,ConsigneeA,ConsigneeB,LastTime,Money ");
			strSql.Append(" FROM Contract ");
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
			strSql.Append(" CID,ProjectID,EnterpriseName,ContractName,CInformation,Note,ConsigneeA,ConsigneeB,LastTime,Money ");
			strSql.Append(" FROM Contract ");
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
			strSql.Append("select count(1) FROM Contract ");
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
				strSql.Append("order by T.CID desc");
			}
			strSql.Append(")AS Row, T.*  from Contract T ");
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
			parameters[0].Value = "Contract";
			parameters[1].Value = "CID";
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

