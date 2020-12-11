using System;
namespace Haikan.SchoolProjectsCore.MDB.Model
{
	/// <summary>
	/// 全局设置
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
		/// 标识主键ID
		/// </summary>
		public int ID
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 系统名称
		/// </summary>
		public string SystemName
		{
			set{ _systemname=value;}
			get{return _systemname;}
		}
		/// <summary>
		/// 图片
		/// </summary>
		public string SystemPicture
		{
			set{ _systempicture=value;}
			get{return _systempicture;}
		}
		/// <summary>
		/// 邮箱
		/// </summary>
		public string Email
		{
			set{ _email=value;}
			get{return _email;}
		}
		/// <summary>
		/// smtp服务器名称
		/// </summary>
		public string smtpSeverName
		{
			set{ _smtpsevername=value;}
			get{return _smtpsevername;}
		}
		/// <summary>
		/// 邮箱登录名
		/// </summary>
		public string EmailName
		{
			set{ _emailname=value;}
			get{return _emailname;}
		}
		/// <summary>
		/// 邮箱密码（授权码）
		/// </summary>
		public string Emailpwd
		{
			set{ _emailpwd=value;}
			get{return _emailpwd;}
		}
		/// <summary>
		/// 上传文件类型
		/// </summary>
		public string FileType
		{
			set{ _filetype=value;}
			get{return _filetype;}
		}
		/// <summary>
		/// 是否显示验证码，如果不为0就隐藏
		/// </summary>
		public int IsIdentifyingCode
		{
			set{ _isidentifyingcode=value;}
			get{return _isidentifyingcode;}
		}
		#endregion Model

	}
}

