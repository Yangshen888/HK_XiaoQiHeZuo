using Haikan2.DataTools;
using System;
using System.Data;
using System.Collections.Generic;
using Haikan.SchoolProjectsCore.MDB.Model;
namespace Haikan.SchoolProjectsCore.MDB.BLL
{
	/// <summary>
	/// ��Ŀ��Ϣ
	/// </summary>
	public partial class Project
	{
		private readonly Haikan.SchoolProjectsCore.MDB.DAL.Project dal=new Haikan.SchoolProjectsCore.MDB.DAL.Project();
		public Project()
		{}
		#region  BasicMethod

		/// <summary>
		/// �õ����ID
		/// </summary>
		public int GetMaxId()
		{
			return dal.GetMaxId();
		}

		/// <summary>
		/// �Ƿ���ڸü�¼
		/// </summary>
		public bool Exists(int ProjectID)
		{
			return dal.Exists(ProjectID);
		}

		/// <summary>
		/// ����һ������
		/// </summary>
		public int  Add(Haikan.SchoolProjectsCore.MDB.Model.Project model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// ����һ������
		/// </summary>
		public bool Update(Haikan.SchoolProjectsCore.MDB.Model.Project model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// ɾ��һ������
		/// </summary>
		public bool Delete(int ProjectID)
		{
			
			return dal.Delete(ProjectID);
		}
		/// <summary>
		/// ɾ��һ������
		/// </summary>
		public bool DeleteList(string ProjectIDlist )
		{
			return dal.DeleteList(PageValidate.SafeLongFilter(ProjectIDlist,0) );
		}

		/// <summary>
		/// �õ�һ������ʵ��
		/// </summary>
		public Haikan.SchoolProjectsCore.MDB.Model.Project GetModel(int ProjectID)
		{
			
			return dal.GetModel(ProjectID);
		}

		/// <summary>
		/// �õ�һ������ʵ�壬�ӻ�����
		/// </summary>
		public Haikan.SchoolProjectsCore.MDB.Model.Project GetModelByCache(int ProjectID)
		{
			
			string CacheKey = "ProjectModel-" + ProjectID;
			object objModel = DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.GetModel(ProjectID);
					if (objModel != null)
					{
						int ModelCache = ConfigHelper.GetConfigInt("ModelCache");
						DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (Haikan.SchoolProjectsCore.MDB.Model.Project)objModel;
		}

		/// <summary>
		/// ��������б�
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			return dal.GetList(strWhere);
		}
		/// <summary>
		/// ���ǰ��������
		/// </summary>
		public DataSet GetList(int Top,string strWhere,string filedOrder)
		{
			return dal.GetList(Top,strWhere,filedOrder);
		}
		/// <summary>
		/// ��������б�
		/// </summary>
		public List<Haikan.SchoolProjectsCore.MDB.Model.Project> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// ��������б�
		/// </summary>
		public List<Haikan.SchoolProjectsCore.MDB.Model.Project> DataTableToList(DataTable dt)
		{
			List<Haikan.SchoolProjectsCore.MDB.Model.Project> modelList = new List<Haikan.SchoolProjectsCore.MDB.Model.Project>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				Haikan.SchoolProjectsCore.MDB.Model.Project model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = dal.DataRowToModel(dt.Rows[n]);
					if (model != null)
					{
						modelList.Add(model);
					}
				}
			}
			return modelList;
		}

		/// <summary>
		/// ��������б�
		/// </summary>
		public DataSet GetAllList()
		{
			return GetList("");
		}

		/// <summary>
		/// ��ҳ��ȡ�����б�
		/// </summary>
		public int GetRecordCount(string strWhere)
		{
			return dal.GetRecordCount(strWhere);
		}
		/// <summary>
		/// ��ҳ��ȡ�����б�
		/// </summary>
		public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
		{
			return dal.GetListByPage( strWhere,  orderby,  startIndex,  endIndex);
		}
		/// <summary>
		/// ��ҳ��ȡ�����б�
		/// </summary>
		//public DataSet GetList(int PageSize,int PageIndex,string strWhere)
		//{
			//return dal.GetList(PageSize,PageIndex,strWhere);
		//}

		#endregion  BasicMethod
		#region  ExtensionMethod

		#endregion  ExtensionMethod
	}
}

