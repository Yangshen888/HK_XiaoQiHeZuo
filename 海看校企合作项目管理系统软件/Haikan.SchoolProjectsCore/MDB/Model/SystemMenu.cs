using System;
namespace Haikan.SchoolProjectsCore.MDB.Model
{
	/// <summary>
	/// ϵͳ�˵���
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
		/// ģ��id








		/// </summary>
		public int ModuleID
		{
			set{ _moduleid=value;}
			get{return _moduleid;}
		}
		/// <summary>
		/// ģ������
		/// </summary>
		public string FullName
		{
			set{ _fullname=value;}
			get{return _fullname;}
		}
		/// <summary>
		/// �����˵�id
		/// </summary>
		public int? ParentID
		{
			set{ _parentid=value;}
			get{return _parentid;}
		}
		/// <summary>
		/// ����(ҳ�����Ŀ¼)
		/// </summary>
		public string Category
		{
			set{ _category=value;}
			get{return _category;}
		}
		/// <summary>
		/// ͼ��
		/// </summary>
		public string Icon
		{
			set{ _icon=value;}
			get{return _icon;}
		}
		/// <summary>
		/// ����Ŀ��
		/// </summary>
		public string Target
		{
			set{ _target=value;}
			get{return _target;}
		}
		/// <summary>
		/// ������

		/// </summary>
		public string Level
		{
			set{ _level=value;}
			get{return _level;}
		}
		/// <summary>
		/// ��ʾ˳��
		/// </summary>
		public string SortCode
		{
			set{ _sortcode=value;}
			get{return _sortcode;}
		}
		/// <summary>
		/// ��ַ
		/// </summary>
		public string Location
		{
			set{ _location=value;}
			get{return _location;}
		}
		/// <summary>
		/// ��ע˵��
		/// </summary>
		public string Remark
		{
			set{ _remark=value;}
			get{return _remark;}
		}
		/// <summary>
		/// Ȩ���ַ���
		/// </summary>
		public string MenuRole
		{
			set{ _menurole=value;}
			get{return _menurole;}
		}
		#endregion Model

	}
}

