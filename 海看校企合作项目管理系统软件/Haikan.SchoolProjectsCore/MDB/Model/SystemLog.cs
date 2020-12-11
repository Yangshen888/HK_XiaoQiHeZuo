using System;
namespace Haikan.SchoolProjectsCore.MDB.Model
{
	/// <summary>
	/// ϵͳ��־��
	/// </summary>
	[Serializable]
	public partial class SystemLog
	{
		public SystemLog()
		{}
		#region Model
		private int _id;
		private string _username;
		private DateTime _timestr;
		private string _actionstr;
		private string _ipaddress;
		private string _type;
		private DateTime _addtime;
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
		/// �����û�
		/// </summary>
		public string UserName
		{
			set{ _username=value;}
			get{return _username;}
		}
		/// <summary>
		/// ����ʱ��
		/// </summary>
		public DateTime TimeStr
		{
			set{ _timestr=value;}
			get{return _timestr;}
		}
		/// <summary>
		/// ��������
		/// </summary>
		public string ActionStr
		{
			set{ _actionstr=value;}
			get{return _actionstr;}
		}
		/// <summary>
		/// IP��ַ
		/// </summary>
		public string IPAddress
		{
			set{ _ipaddress=value;}
			get{return _ipaddress;}
		}
		/// <summary>
		/// �������ͣ���ɾ�Ĳ飩
		/// </summary>
		public string Type
		{
			set{ _type=value;}
			get{return _type;}
		}
		/// <summary>
		/// ���ʱ��
		/// </summary>
		public DateTime AddTime
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

