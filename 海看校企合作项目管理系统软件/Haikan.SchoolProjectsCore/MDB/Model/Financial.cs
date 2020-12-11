using System;
namespace Haikan.SchoolProjectsCore.MDB.Model
{
	/// <summary>
	/// ������Ϣ
	/// </summary>
	[Serializable]
	public partial class Financial
	{
		public Financial()
		{}
		#region Model
		private int _fid;
		private string _projectname;
		private string _enterprisename;
		private string _ispay;
		private string _successfultime;
		private string _person;
		private string _paymoney;
		private string _systemuser;
		private string _timestr;
		private string _note;
		/// <summary>
		/// ����ID
		/// </summary>
		public int FID
		{
			set{ _fid=value;}
			get{return _fid;}
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
		/// ��ҵ����
		/// </summary>
		public string EnterpriseName
		{
			set{ _enterprisename=value;}
			get{return _enterprisename;}
		}
		/// <summary>
		/// �տ�Ǹ���
		/// </summary>
		public string IsPay
		{
			set{ _ispay=value;}
			get{return _ispay;}
		}
		/// <summary>
		/// �ɽ�ʱ��
		/// </summary>
		public string SuccessfulTime
		{
			set{ _successfultime=value;}
			get{return _successfultime;}
		}
		/// <summary>
		/// �տ�/������
		/// </summary>
		public string Person
		{
			set{ _person=value;}
			get{return _person;}
		}
		/// <summary>
		/// ����/�տ���
		/// </summary>
		public string PayMoney
		{
			set{ _paymoney=value;}
			get{return _paymoney;}
		}
		/// <summary>
		/// ��������Ա����
		/// </summary>
		public string SystemUser
		{
			set{ _systemuser=value;}
			get{return _systemuser;}
		}
		/// <summary>
		/// ��¼ʱ��
		/// </summary>
		public string TimeStr
		{
			set{ _timestr=value;}
			get{return _timestr;}
		}
		/// <summary>
		/// ��ע������/δ���塿
		/// </summary>
		public string Note
		{
			set{ _note=value;}
			get{return _note;}
		}
		#endregion Model

	}
}

