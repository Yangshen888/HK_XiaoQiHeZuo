using System;
namespace Haikan.SchoolProjectsCore.MDB.Model
{
	/// <summary>
	/// ��Ŀ��Ϣ
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
		/// ��ҵ����
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
		/// ��Ŀ����
		/// </summary>
		public string ProjectName
		{
			set{ _projectname=value;}
			get{return _projectname;}
		}
		/// <summary>
		/// ��Ŀ״̬�������У�ά���С�
		/// </summary>
		public string Projectstatus
		{
			set{ _projectstatus=value;}
			get{return _projectstatus;}
		}
		/// <summary>
		/// �û��������Ǹ��û���ɫ����������Ŀ��
		/// </summary>
		public string DName
		{
			set{ _dname=value;}
			get{return _dname;}
		}
		/// <summary>
		/// ��Ҫ������
		/// </summary>
		public string PersonInCharge
		{
			set{ _personincharge=value;}
			get{return _personincharge;}
		}
		/// <summary>
		/// ��Ŀ���ϣ�����ļ���ַ����ͣ�á�
		/// </summary>
		public string ProjectData
		{
			set{ _projectdata=value;}
			get{return _projectdata;}
		}
		/// <summary>
		/// ��ע
		/// </summary>
		public string Note
		{
			set{ _note=value;}
			get{return _note;}
		}
		/// <summary>
		/// ��Ŀ���ʱ��
		/// </summary>
		public string addTime
		{
			set{ _addtime=value;}
			get{return _addtime;}
		}
		#endregion Model

	}
}

