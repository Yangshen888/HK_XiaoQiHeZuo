using System;
namespace Haikan.SchoolProjectsCore.MDB.Model
{
	/// <summary>
	/// 系统菜单表
	/// </summary>
	[Serializable]
	public partial class SystemMenu
	{
		public SystemMenu()
		{}
		#region Model
		private int _moduleid;
		private string _fullname;
		private int? _parentid;
		private string _category;
		private string _icon;
		private string _target;
		private string _level;
		private string _sortcode;
		private string _location;
		private string _remark;
		private string _menurole;
		/// <summary>
		/// 模块id








		/// </summary>
		public int ModuleID
		{
			set{ _moduleid=value;}
			get{return _moduleid;}
		}
		/// <summary>
		/// 模块名称
		/// </summary>
		public string FullName
		{
			set{ _fullname=value;}
			get{return _fullname;}
		}
		/// <summary>
		/// 父级菜单id
		/// </summary>
		public int? ParentID
		{
			set{ _parentid=value;}
			get{return _parentid;}
		}
		/// <summary>
		/// 分类(页面或者目录)
		/// </summary>
		public string Category
		{
			set{ _category=value;}
			get{return _category;}
		}
		/// <summary>
		/// 图标
		/// </summary>
		public string Icon
		{
			set{ _icon=value;}
			get{return _icon;}
		}
		/// <summary>
		/// 连接目标
		/// </summary>
		public string Target
		{
			set{ _target=value;}
			get{return _target;}
		}
		/// <summary>
		/// 级别层次

		/// </summary>
		public string Level
		{
			set{ _level=value;}
			get{return _level;}
		}
		/// <summary>
		/// 显示顺序
		/// </summary>
		public string SortCode
		{
			set{ _sortcode=value;}
			get{return _sortcode;}
		}
		/// <summary>
		/// 地址
		/// </summary>
		public string Location
		{
			set{ _location=value;}
			get{return _location;}
		}
		/// <summary>
		/// 备注说明
		/// </summary>
		public string Remark
		{
			set{ _remark=value;}
			get{return _remark;}
		}
		/// <summary>
		/// 权限字符串
		/// </summary>
		public string MenuRole
		{
			set{ _menurole=value;}
			get{return _menurole;}
		}
		#endregion Model

	}
}

