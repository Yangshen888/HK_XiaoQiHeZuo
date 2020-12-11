using System;
namespace Haikan.SchoolProjectsCore.MDB.Model
{
	/// <summary>
	/// ȫ������
	/// </summary>
	[Serializable]
	public partial class SystemSetting
	{
		public SystemSetting()
		{}
		#region Model
		private int _id;
		private string _systemname;
		private string _systempicture;
		private string _email;
		private string _smtpsevername;
		private string _emailname;
		private string _emailpwd;
		private string _filetype;
		private int _isidentifyingcode;
		/// <summary>
		/// ��ʶ����ID
		/// </summary>
		public int ID
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// ϵͳ����
		/// </summary>
		public string SystemName
		{
			set{ _systemname=value;}
			get{return _systemname;}
		}
		/// <summary>
		/// ͼƬ
		/// </summary>
		public string SystemPicture
		{
			set{ _systempicture=value;}
			get{return _systempicture;}
		}
		/// <summary>
		/// ����
		/// </summary>
		public string Email
		{
			set{ _email=value;}
			get{return _email;}
		}
		/// <summary>
		/// smtp����������
		/// </summary>
		public string smtpSeverName
		{
			set{ _smtpsevername=value;}
			get{return _smtpsevername;}
		}
		/// <summary>
		/// �����¼��
		/// </summary>
		public string EmailName
		{
			set{ _emailname=value;}
			get{return _emailname;}
		}
		/// <summary>
		/// �������루��Ȩ�룩
		/// </summary>
		public string Emailpwd
		{
			set{ _emailpwd=value;}
			get{return _emailpwd;}
		}
		/// <summary>
		/// �ϴ��ļ�����
		/// </summary>
		public string FileType
		{
			set{ _filetype=value;}
			get{return _filetype;}
		}
		/// <summary>
		/// �Ƿ���ʾ��֤�룬�����Ϊ0������
		/// </summary>
		public int IsIdentifyingCode
		{
			set{ _isidentifyingcode=value;}
			get{return _isidentifyingcode;}
		}
		#endregion Model

	}
}

