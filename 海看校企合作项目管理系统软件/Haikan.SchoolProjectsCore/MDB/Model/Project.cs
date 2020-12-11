using System;
namespace Haikan.SchoolProjectsCore.MDB.Model
{
	/// <summary>
	/// 项目信息
	/// </summary>
	[Serializable]
	public partial class Project
	{
		public Project()
		{}
		#region Model
		private string _enterprisename;
		private int _projectid;
		private string _projectname;
		private string _projectstatus;
		private string _dname;
		private string _personincharge;
		private string _projectdata;
		private string _note;
		private string _addtime;
		/// <summary>
		/// 企业名称
		/// </summary>
		public string EnterpriseName
		{
			set{ _enterprisename=value;}
			get{return _enterprisename;}
		}
		/// <summary>
		/// ID
		/// </summary>
		public int ProjectID
		{
			set{ _projectid=value;}
			get{return _projectid;}
		}
		/// <summary>
		/// 项目名称
		/// </summary>
		public string ProjectName
		{
			set{ _projectname=value;}
			get{return _projectname;}
		}
		/// <summary>
		/// 项目状态【开发中，维护中】
		/// </summary>
		public string Projectstatus
		{
			set{ _projectstatus=value;}
			get{return _projectstatus;}
		}
		/// <summary>
		/// 用户引进【那个用户角色引进来的项目】
		/// </summary>
		public string DName
		{
			set{ _dname=value;}
			get{return _dname;}
		}
		/// <summary>
		/// 主要负责人
		/// </summary>
		public string PersonInCharge
		{
			set{ _personincharge=value;}
			get{return _personincharge;}
		}
		/// <summary>
		/// 项目资料（存放文件地址）【停用】
		/// </summary>
		public string ProjectData
		{
			set{ _projectdata=value;}
			get{return _projectdata;}
		}
		/// <summary>
		/// 备注
		/// </summary>
		public string Note
		{
			set{ _note=value;}
			get{return _note;}
		}
		/// <summary>
		/// 项目添加时间
		/// </summary>
		public string addTime
		{
			set{ _addtime=value;}
			get{return _addtime;}
		}
		#endregion Model

	}
}

