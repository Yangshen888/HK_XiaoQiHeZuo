using System;
namespace Haikan.SchoolProjectsCore.MDB.Model
{
	/// <summary>
	/// 系统用户
	/// </summary>
	[Serializable]
	public partial class SystemUser
	{
		public SystemUser()
		{}
		#region Model
		private int _id;
		private string _username;
		private string _userpwd;
		private string _truename;
		private string _roleid;
		private string _emailstr;
		private string _sex;
		private string _birthday;
		private string _mingzu;
		private string _sfzserils;
		private string _xueli;
		private string _zhicheng;
		private string _biyeyuanxiao;
		private string _zhuanye;
		private string _canjiagongzuotime;
		private string _jiarubendanweitime;
		private string _photo;
		private int? _isdelete;
		private int _departmentid;
		private int _isenter;
		private string _telphonenumber;
		private DateTime _addtime;
		private string _addpeople;
		private int _logincount=0;
		private DateTime _logintime= DateTime.Now;
		/// <summary>
		/// 自动编号
		/// </summary>
		public int ID
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 用户名
		/// </summary>
		public string UserName
		{
			set{ _username=value;}
			get{return _username;}
		}
		/// <summary>
		/// 用户密码
		/// </summary>
		public string UserPwd
		{
			set{ _userpwd=value;}
			get{return _userpwd;}
		}
		/// <summary>
		/// 真实姓名
		/// </summary>
		public string TrueName
		{
			set{ _truename=value;}
			get{return _truename;}
		}
		/// <summary>
		/// 角色ID
		/// </summary>
		public string RoleID
		{
			set{ _roleid=value;}
			get{return _roleid;}
		}
		/// <summary>
		/// 邮箱地址
		/// </summary>
		public string EmailStr
		{
			set{ _emailstr=value;}
			get{return _emailstr;}
		}
		/// <summary>
		/// 性别
		/// </summary>
		public string Sex
		{
			set{ _sex=value;}
			get{return _sex;}
		}
		/// <summary>
		/// 生日
		/// </summary>
		public string BirthDay
		{
			set{ _birthday=value;}
			get{return _birthday;}
		}
		/// <summary>
		/// 民族
		/// </summary>
		public string MingZu
		{
			set{ _mingzu=value;}
			get{return _mingzu;}
		}
		/// <summary>
		/// 身份证号
		/// </summary>
		public string SFZSerils
		{
			set{ _sfzserils=value;}
			get{return _sfzserils;}
		}
		/// <summary>
		/// 学历
		/// </summary>
		public string XueLi
		{
			set{ _xueli=value;}
			get{return _xueli;}
		}
		/// <summary>
		/// 职称
		/// </summary>
		public string ZhiCheng
		{
			set{ _zhicheng=value;}
			get{return _zhicheng;}
		}
		/// <summary>
		/// 毕业院校
		/// </summary>
		public string BiYeYuanXiao
		{
			set{ _biyeyuanxiao=value;}
			get{return _biyeyuanxiao;}
		}
		/// <summary>
		/// 专业
		/// </summary>
		public string ZhuanYe
		{
			set{ _zhuanye=value;}
			get{return _zhuanye;}
		}
		/// <summary>
		/// 参加工作时间
		/// </summary>
		public string CanJiaGongZuoTime
		{
			set{ _canjiagongzuotime=value;}
			get{return _canjiagongzuotime;}
		}
		/// <summary>
		/// 加入本单位时间
		/// </summary>
		public string JiaRuBenDanWeiTime
		{
			set{ _jiarubendanweitime=value;}
			get{return _jiarubendanweitime;}
		}
		/// <summary>
		/// 照片
		/// </summary>
		public string photo
		{
			set{ _photo=value;}
			get{return _photo;}
		}
		/// <summary>
		/// 标记删除
		/// </summary>
		public int? IsDelete
		{
			set{ _isdelete=value;}
			get{return _isdelete;}
		}
		/// <summary>
		/// 部门ID
		/// </summary>
		public int DepartmentID
		{
			set{ _departmentid=value;}
			get{return _departmentid;}
		}
		/// <summary>
		/// 是否允许登录：0允许：1不允许
		/// </summary>
		public int IsEnter
		{
			set{ _isenter=value;}
			get{return _isenter;}
		}
		/// <summary>
		/// 电话号码
		/// </summary>
		public string TelphoneNumber
		{
			set{ _telphonenumber=value;}
			get{return _telphonenumber;}
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
		/// <summary>
		/// 登录次数
		/// </summary>
		public int loginCount
		{
			set{ _logincount=value;}
			get{return _logincount;}
		}
		/// <summary>
		/// 最后登录时间
		/// </summary>
		public DateTime loginTime
		{
			set{ _logintime=value;}
			get{return _logintime;}
		}
		#endregion Model

	}
}

