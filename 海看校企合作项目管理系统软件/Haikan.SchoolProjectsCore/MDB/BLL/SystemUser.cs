using Haikan2.DataTools;
using System;
using System.Data;
using System.Collections.Generic;
using Haikan.SchoolProjectsCore.MDB.Model;
namespace Haikan.SchoolProjectsCore.MDB.BLL
{
	/// <summary>
	/// 系统用户
	/// </summary>
	public partial class SystemUser
	{
		private readonly Haikan.SchoolProjectsCore.MDB.DAL.SystemUser dal=new Haikan.SchoolProjectsCore.MDB.DAL.SystemUser();
		public SystemUser()
		{}
		#region  BasicMethod

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int  Add(Haikan.SchoolProjectsCore.MDB.Model.SystemUser model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(Haikan.SchoolProjectsCore.MDB.Model.SystemUser model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(int ID)
		{
			
			return dal.Delete(ID);
		}
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool DeleteList(string IDlist )
		{
			return dal.DeleteList(PageValidate.SafeLongFilter(IDlist,0) );
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Haikan.SchoolProjectsCore.MDB.Model.SystemUser GetModel(int ID)
		{
			
			return dal.GetModel(ID);
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
		public Haikan.SchoolProjectsCore.MDB.Model.SystemUser GetModelByCache(int ID)
		{
			
			string CacheKey = "SystemUserModel-" + ID;
			object objModel = DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.GetModel(ID);
					if (objModel != null)
					{
						int ModelCache = ConfigHelper.GetConfigInt("ModelCache");
						DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (Haikan.SchoolProjectsCore.MDB.Model.SystemUser)objModel;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			return dal.GetList(strWhere);
		}
		/// <summary>
		/// 获得前几行数据
		/// </summary>
		public DataSet GetList(int Top,string strWhere,string filedOrder)
		{
			return dal.GetList(Top,strWhere,filedOrder);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<Haikan.SchoolProjectsCore.MDB.Model.SystemUser> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<Haikan.SchoolProjectsCore.MDB.Model.SystemUser> DataTableToList(DataTable dt)
		{
			List<Haikan.SchoolProjectsCore.MDB.Model.SystemUser> modelList = new List<Haikan.SchoolProjectsCore.MDB.Model.SystemUser>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				Haikan.SchoolProjectsCore.MDB.Model.SystemUser model;
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
		/// 获得数据列表
		/// </summary>
		public DataSet GetAllList()
		{
			return GetList("");
		}

		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public int GetRecordCount(string strWhere)
		{
			return dal.GetRecordCount(strWhere);
		}
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
		{
			return dal.GetListByPage( strWhere,  orderby,  startIndex,  endIndex);
		}
		/// <summary>
		/// 分页获取数据列表
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

