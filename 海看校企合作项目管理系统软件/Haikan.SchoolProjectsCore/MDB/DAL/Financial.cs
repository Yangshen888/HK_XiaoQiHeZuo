using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Haikan2.DBHelper;
namespace Haikan.SchoolProjectsCore.MDB.DAL
{
	/// <summary>
	/// ���ݷ�����:Financial
	/// </summary>
	public partial class Financial
	{
		public Financial()
		{}
		#region  BasicMethod

		/// <summary>
		/// �õ����ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSql.GetMaxId("FID", "Financial"); 
		}

		/// <summary>
		/// �Ƿ���ڸü�¼
		/// </summary>
		public bool Exists(int FID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from Financial");
			strSql.Append(" where FID=@FID");
			SqlParameter[] parameters = {
					new SqlParameter("@FID", SqlDbType.Int,4)
			};
			parameters[0].Value = FID;

			return DbHelperSql.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// ����һ������
		/// </summary>
		public int Add(Haikan.SchoolProjectsCore.MDB.Model.Financial model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into Financial(");
			strSql.Append("ProjectName,EnterpriseName,IsPay,SuccessfulTime,Person,PayMoney,SystemUser,TimeStr,Note)");
			strSql.Append(" values (");
			strSql.Append("@ProjectName,@EnterpriseName,@IsPay,@SuccessfulTime,@Person,@PayMoney,@SystemUser,@TimeStr,@Note)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@ProjectName", SqlDbType.VarChar,255),
					new SqlParameter("@EnterpriseName", SqlDbType.VarChar,255),
					new SqlParameter("@IsPay", SqlDbType.VarChar,255),
					new SqlParameter("@SuccessfulTime", SqlDbType.VarChar,255),
					new SqlParameter("@Person", SqlDbType.VarChar,255),
					new SqlParameter("@PayMoney", SqlDbType.VarChar,255),
					new SqlParameter("@SystemUser", SqlDbType.VarChar,255),
					new SqlParameter("@TimeStr", SqlDbType.VarChar,255),
					new SqlParameter("@Note", SqlDbType.VarChar,255)};
			parameters[0].Value = model.ProjectName;
			parameters[1].Value = model.EnterpriseName;
			parameters[2].Value = model.IsPay;
			parameters[3].Value = model.SuccessfulTime;
			parameters[4].Value = model.Person;
			parameters[5].Value = model.PayMoney;
			parameters[6].Value = model.SystemUser;
			parameters[7].Value = model.TimeStr;
			parameters[8].Value = model.Note;

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
		/// ����һ������
		/// </summary>
		public bool Update(Haikan.SchoolProjectsCore.MDB.Model.Financial model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update Financial set ");
			strSql.Append("ProjectName=@ProjectName,");
			strSql.Append("EnterpriseName=@EnterpriseName,");
			strSql.Append("IsPay=@IsPay,");
			strSql.Append("SuccessfulTime=@SuccessfulTime,");
			strSql.Append("Person=@Person,");
			strSql.Append("PayMoney=@PayMoney,");
			strSql.Append("SystemUser=@SystemUser,");
			strSql.Append("TimeStr=@TimeStr,");
			strSql.Append("Note=@Note");
			strSql.Append(" where FID=@FID");
			SqlParameter[] parameters = {
					new SqlParameter("@ProjectName", SqlDbType.VarChar,255),
					new SqlParameter("@EnterpriseName", SqlDbType.VarChar,255),
					new SqlParameter("@IsPay", SqlDbType.VarChar,255),
					new SqlParameter("@SuccessfulTime", SqlDbType.VarChar,255),
					new SqlParameter("@Person", SqlDbType.VarChar,255),
					new SqlParameter("@PayMoney", SqlDbType.VarChar,255),
					new SqlParameter("@SystemUser", SqlDbType.VarChar,255),
					new SqlParameter("@TimeStr", SqlDbType.VarChar,255),
					new SqlParameter("@Note", SqlDbType.VarChar,255),
					new SqlParameter("@FID", SqlDbType.Int,4)};
			parameters[0].Value = model.ProjectName;
			parameters[1].Value = model.EnterpriseName;
			parameters[2].Value = model.IsPay;
			parameters[3].Value = model.SuccessfulTime;
			parameters[4].Value = model.Person;
			parameters[5].Value = model.PayMoney;
			parameters[6].Value = model.SystemUser;
			parameters[7].Value = model.TimeStr;
			parameters[8].Value = model.Note;
			parameters[9].Value = model.FID;

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
		/// ɾ��һ������
		/// </summary>
		public bool Delete(int FID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Financial ");
			strSql.Append(" where FID=@FID");
			SqlParameter[] parameters = {
					new SqlParameter("@FID", SqlDbType.Int,4)
			};
			parameters[0].Value = FID;

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
		/// ����ɾ������
		/// </summary>
		public bool DeleteList(string FIDlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Financial ");
			strSql.Append(" where FID in ("+FIDlist + ")  ");
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
		/// �õ�һ������ʵ��
		/// </summary>
		public Haikan.SchoolProjectsCore.MDB.Model.Financial GetModel(int FID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 FID,ProjectName,EnterpriseName,IsPay,SuccessfulTime,Person,PayMoney,SystemUser,TimeStr,Note from Financial ");
			strSql.Append(" where FID=@FID");
			SqlParameter[] parameters = {
					new SqlParameter("@FID", SqlDbType.Int,4)
			};
			parameters[0].Value = FID;

			Haikan.SchoolProjectsCore.MDB.Model.Financial model=new Haikan.SchoolProjectsCore.MDB.Model.Financial();
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
		/// �õ�һ������ʵ��
		/// </summary>
		public Haikan.SchoolProjectsCore.MDB.Model.Financial DataRowToModel(DataRow row)
		{
			Haikan.SchoolProjectsCore.MDB.Model.Financial model=new Haikan.SchoolProjectsCore.MDB.Model.Financial();
			if (row != null)
			{
				if(row["FID"]!=null && row["FID"].ToString()!="")
				{
					model.FID=int.Parse(row["FID"].ToString());
				}
				if(row["ProjectName"]!=null)
				{
					model.ProjectName=row["ProjectName"].ToString();
				}
				if(row["EnterpriseName"]!=null)
				{
					model.EnterpriseName=row["EnterpriseName"].ToString();
				}
				if(row["IsPay"]!=null)
				{
					model.IsPay=row["IsPay"].ToString();
				}
				if(row["SuccessfulTime"]!=null)
				{
					model.SuccessfulTime=row["SuccessfulTime"].ToString();
				}
				if(row["Person"]!=null)
				{
					model.Person=row["Person"].ToString();
				}
				if(row["PayMoney"]!=null)
				{
					model.PayMoney=row["PayMoney"].ToString();
				}
				if(row["SystemUser"]!=null)
				{
					model.SystemUser=row["SystemUser"].ToString();
				}
				if(row["TimeStr"]!=null)
				{
					model.TimeStr=row["TimeStr"].ToString();
				}
				if(row["Note"]!=null)
				{
					model.Note=row["Note"].ToString();
				}
			}
			return model;
		}

		/// <summary>
		/// ��������б�
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select FID,ProjectName,EnterpriseName,IsPay,SuccessfulTime,Person,PayMoney,SystemUser,TimeStr,Note ");
			strSql.Append(" FROM Financial ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			return DbHelperSql.Query(strSql.ToString());
		}

		/// <summary>
		/// ���ǰ��������
		/// </summary>
		public DataSet GetList(int Top,string strWhere,string filedOrder)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ");
			if(Top>0)
			{
				strSql.Append(" top "+Top.ToString());
			}
			strSql.Append(" FID,ProjectName,EnterpriseName,IsPay,SuccessfulTime,Person,PayMoney,SystemUser,TimeStr,Note ");
			strSql.Append(" FROM Financial ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			strSql.Append(" order by " + filedOrder);
			return DbHelperSql.Query(strSql.ToString());
		}

		/// <summary>
		/// ��ȡ��¼����
		/// </summary>
		public int GetRecordCount(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) FROM Financial ");
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
		/// ��ҳ��ȡ�����б�
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
				strSql.Append("order by T.FID desc");
			}
			strSql.Append(")AS Row, T.*  from Financial T ");
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
		/// ��ҳ��ȡ�����б�
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
			parameters[0].Value = "Financial";
			parameters[1].Value = "FID";
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

