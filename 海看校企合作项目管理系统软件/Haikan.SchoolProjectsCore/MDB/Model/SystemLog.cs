using System;
namespace Haikan.SchoolProjectsCore.MDB.Model
{
	/// <summary>
	/// 系统日志表
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
		/// 操作用户
		/// </summary>
		public string UserName
		{
			set{ _username=value;}
			get{return _username;}
		}
		/// <summary>
		/// 操作时间
		/// </summary>
		public DateTime TimeStr
		{
			set{ _timestr=value;}
			get{return _timestr;}
		}
		/// <summary>
		/// 操作内容
		/// </summary>
		public string ActionStr
		{
			set{ _actionstr=value;}
			get{return _actionstr;}
		}
		/// <summary>
		/// IP地址
		/// </summary>
		public string IPAddress
		{
			set{ _ipaddress=value;}
			get{return _ipaddress;}
		}
		/// <summary>
		/// 操作类型（增删改查）
		/// </summary>
		public string Type
		{
			set{ _type=value;}
			get{return _type;}
		}
		/// <summary>
		/// 添加时间
		/// </summary>
		public DateTime AddTime
		{
			set{ _addtime=value;}
			get{return _addtime;}
		}
		/// <summary>
		/// 添加人
		/// </summary>
		public string AddPeople
		{
			set{ _addpeople=value;}
			get{return _addpeople;}
		}
		#endregion Model

	}
}

