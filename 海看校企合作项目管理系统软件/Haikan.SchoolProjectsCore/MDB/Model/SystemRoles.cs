using System;
namespace Haikan.SchoolProjectsCore.MDB.Model
{
	/// <summary>
	/// ϵͳ��ɫ��
	/// </summary>
	[Serializable]
	public partial class SystemRoles
	{
		public SystemRoles()
		{}
		#region Model
		private int _id;
		private string _rolename;
		private string _remarks;
		private string _actionstr;
		private int _isdelete;
		private string _addtime;
		private string _addpeople;
		/// <summary>
		/// 
		/// </summary>
		public int ID
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// ��ɫ����
		/// </summary>
		public string RoleName
		{
			set{ _rolename=value;}
			get{return _rolename;}
		}
		/// <summary>
		/// ��ע��Ϣ
		/// </summary>
		public string Remarks
		{
			set{ _remarks=value;}
			get{return _remarks;}
		}
		/// <summary>
		/// Ȩ���ַ���
		/// </summary>
		public string Actionstr
		{
			set{ _actionstr=value;}
			get{return _actionstr;}
		}
		/// <summary>
		/// �Ƿ�ɾ��0����1����
		/// </summary>
		public int IsDelete
		{
			set{ _isdelete=value;}
			get{return _isdelete;}
		}
		/// <summary>
		/// ���ʱ��
		/// </summary>
		public string AddTime
		{
			set{ _addtime=value;}
			get{return _addtime;}
		}
		/// <summary>
		/// �����
		/// </summary>
		public string AddPeople
		{
			set{ _addpeople=value;}
			get{return _addpeople;}
		}
		#endregion Model

	}
}

