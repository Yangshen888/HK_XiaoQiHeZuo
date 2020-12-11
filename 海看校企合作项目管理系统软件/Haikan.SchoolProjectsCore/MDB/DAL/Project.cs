using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Haikan2.DBHelper;
namespace Haikan.SchoolProjectsCore.MDB.DAL
{
	/// <summary>
	/// ���ݷ�����:Project
	/// </summary>
	public partial class Project
	{
		public Project()
		{}
		#region  BasicMethod

		/// <summary>
		/// �õ����ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSql.GetMaxId("ProjectID", "Project"); 
		}

		/// <summary>
		/// �Ƿ���ڸü�¼
		/// </summary>
		public bool Exists(int ProjectID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from Project");
			strSql.Append(" where ProjectID=@ProjectID");
			SqlParameter[] parameters = {
					new SqlParameter("@ProjectID", SqlDbType.Int,4)
			};
			parameters[0].Value = ProjectID;

			return DbHelperSql.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// ����һ������
		/// </summary>
		public int Add(Haikan.SchoolProjectsCore.MDB.Model.Project model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into Project(");
			strSql.Append("EnterpriseName,ProjectName,Projectstatus,DName,PersonInCharge,ProjectData,Note,addTime)");
			strSql.Append(" values (");
			strSql.Append("@EnterpriseName,@ProjectName,@Projectstatus,@DName,@PersonInCharge,@ProjectData,@Note,@addTime)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@EnterpriseName", SqlDbType.VarChar,255),
					new SqlParameter("@ProjectName", SqlDbType.VarChar,255),
					new SqlParameter("@Projectstatus", SqlDbType.VarChar,255),
					new SqlParameter("@DName", SqlDbType.VarChar,255),
					new SqlParameter("@PersonInCharge", SqlDbType.VarChar,255),
					new SqlParameter("@ProjectData", SqlDbType.VarChar,255),
					new SqlParameter("@Note", SqlDbType.VarChar,255),
					new SqlParameter("@addTime", SqlDbType.VarChar,255)};
			parameters[0].Value = model.EnterpriseName;
			parameters[1].Value = model.ProjectName;
			parameters[2].Value = model.Projectstatus;
			parameters[3].Value = model.DName;
			parameters[4].Value = model.PersonInCharge;
			parameters[5].Value = model.ProjectData;
			parameters[6].Value = model.Note;
			parameters[7].Value = model.addTime;

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
		public bool Update(Haikan.SchoolProjectsCore.MDB.Model.Project model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update Project set ");
			strSql.Append("EnterpriseName=@EnterpriseName,");
			strSql.Append("ProjectName=@ProjectName,");
			strSql.Append("Projectstatus=@Projectstatus,");
			strSql.Append("DName=@DName,");
			strSql.Append("PersonInCharge=@PersonInCharge,");
			strSql.Append("ProjectData=@ProjectData,");
			strSql.Append("Note=@Note,");
			strSql.Append("addTime=@addTime");
			strSql.Append(" where ProjectID=@ProjectID");
			SqlParameter[] parameters = {
					new SqlParameter("@EnterpriseName", SqlDbType.VarChar,255),
					new SqlParameter("@ProjectName", SqlDbType.VarChar,255),
					new SqlParameter("@Projectstatus", SqlDbType.VarChar,255),
					new SqlParameter("@DName", SqlDbType.VarChar,255),
					new SqlParameter("@PersonInCharge", SqlDbType.VarChar,255),
					new SqlParameter("@ProjectData", SqlDbType.VarChar,255),
					new SqlParameter("@Note", SqlDbType.VarChar,255),
					new SqlParameter("@addTime", SqlDbType.VarChar,255),
					new SqlParameter("@ProjectID", SqlDbType.Int,4)};
			parameters[0].Value = model.EnterpriseName;
			parameters[1].Value = model.ProjectName;
			parameters[2].Value = model.Projectstatus;
			parameters[3].Value = model.DName;
			parameters[4].Value = model.PersonInCharge;
			parameters[5].Value = model.ProjectData;
			parameters[6].Value = model.Note;
			parameters[7].Value = model.addTime;
			parameters[8].Value = model.ProjectID;

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
		public bool Delete(int ProjectID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Project ");
			strSql.Append(" where ProjectID=@ProjectID");
			SqlParameter[] parameters = {
					new SqlParameter("@ProjectID", SqlDbType.Int,4)
			};
			parameters[0].Value = ProjectID;

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
		public bool DeleteList(string ProjectIDlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Project ");
			strSql.Append(" where ProjectID in ("+ProjectIDlist + ")  ");
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
		public Haikan.SchoolProjectsCore.MDB.Model.Project GetModel(int ProjectID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 EnterpriseName,ProjectID,ProjectName,Projectstatus,DName,PersonInCharge,ProjectData,Note,addTime from Project ");
			strSql.Append(" where ProjectID=@ProjectID");
			SqlParameter[] parameters = {
					new SqlParameter("@ProjectID", SqlDbType.Int,4)
			};
			parameters[0].Value = ProjectID;

			Haikan.SchoolProjectsCore.MDB.Model.Project model=new Haikan.SchoolProjectsCore.MDB.Model.Project();
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
		public Haikan.SchoolProjectsCore.MDB.Model.Project DataRowToModel(DataRow row)
		{
			Haikan.SchoolProjectsCore.MDB.Model.Project model=new Haikan.SchoolProjectsCore.MDB.Model.Project();
			if (row != null)
			{
				if(row["EnterpriseName"]!=null)
				{
					model.EnterpriseName=row["EnterpriseName"].ToString();
				}
				if(row["ProjectID"]!=null && row["ProjectID"].ToString()!="")
				{
					model.ProjectID=int.Parse(row["ProjectID"].ToString());
				}
				if(row["ProjectName"]!=null)
				{
					model.ProjectName=row["ProjectName"].ToString();
				}
				if(row["Projectstatus"]!=null)
				{
					model.Projectstatus=row["Projectstatus"].ToString();
				}
				if(row["DName"]!=null)
				{
					model.DName=row["DName"].ToString();
				}
				if(row["PersonInCharge"]!=null)
				{
					model.PersonInCharge=row["PersonInCharge"].ToString();
				}
				if(row["ProjectData"]!=null)
				{
					model.ProjectData=row["ProjectData"].ToString();
				}
				if(row["Note"]!=null)
				{
					model.Note=row["Note"].ToString();
				}
				if(row["addTime"]!=null)
				{
					model.addTime=row["addTime"].ToString();
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
			strSql.Append("select EnterpriseName,ProjectID,ProjectName,Projectstatus,DName,PersonInCharge,ProjectData,Note,addTime ");
			strSql.Append(" FROM Project ");
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
			strSql.Append(" EnterpriseName,ProjectID,ProjectName,Projectstatus,DName,PersonInCharge,ProjectData,Note,addTime ");
			strSql.Append(" FROM Project ");
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
			strSql.Append("select count(1) FROM Project ");
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
				strSql.Append("order by T.ProjectID desc");
			}
			strSql.Append(")AS Row, T.*  from Project T ");
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
			parameters[0].Value = "Project";
			parameters[1].Value = "ProjectID";
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

