using System;
namespace Haikan.SchoolProjectsCore.MDB.Model
{
	/// <summary>
	/// ϵͳ�û�
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
		/// �Զ����
		/// </summary>
		public int ID
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// �û���
		/// </summary>
		public string UserName
		{
			set{ _username=value;}
			get{return _username;}
		}
		/// <summary>
		/// �û�����
		/// </summary>
		public string UserPwd
		{
			set{ _userpwd=value;}
			get{return _userpwd;}
		}
		/// <summary>
		/// ��ʵ����
		/// </summary>
		public string TrueName
		{
			set{ _truename=value;}
			get{return _truename;}
		}
		/// <summary>
		/// ��ɫID
		/// </summary>
		public string RoleID
		{
			set{ _roleid=value;}
			get{return _roleid;}
		}
		/// <summary>
		/// �����ַ
		/// </summary>
		public string EmailStr
		{
			set{ _emailstr=value;}
			get{return _emailstr;}
		}
		/// <summary>
		/// �Ա�
		/// </summary>
		public string Sex
		{
			set{ _sex=value;}
			get{return _sex;}
		}
		/// <summary>
		/// ����
		/// </summary>
		public string BirthDay
		{
			set{ _birthday=value;}
			get{return _birthday;}
		}
		/// <summary>
		/// ����
		/// </summary>
		public string MingZu
		{
			set{ _mingzu=value;}
			get{return _mingzu;}
		}
		/// <summary>
		/// ���֤��
		/// </summary>
		public string SFZSerils
		{
			set{ _sfzserils=value;}
			get{return _sfzserils;}
		}
		/// <summary>
		/// ѧ��
		/// </summary>
		public string XueLi
		{
			set{ _xueli=value;}
			get{return _xueli;}
		}
		/// <summary>
		/// ְ��
		/// </summary>
		public string ZhiCheng
		{
			set{ _zhicheng=value;}
			get{return _zhicheng;}
		}
		/// <summary>
		/// ��ҵԺУ
		/// </summary>
		public string BiYeYuanXiao
		{
			set{ _biyeyuanxiao=value;}
			get{return _biyeyuanxiao;}
		}
		/// <summary>
		/// רҵ
		/// </summary>
		public string ZhuanYe
		{
			set{ _zhuanye=value;}
			get{return _zhuanye;}
		}
		/// <summary>
		/// �μӹ���ʱ��
		/// </summary>
		public string CanJiaGongZuoTime
		{
			set{ _canjiagongzuotime=value;}
			get{return _canjiagongzuotime;}
		}
		/// <summary>
		/// ���뱾��λʱ��
		/// </summary>
		public string JiaRuBenDanWeiTime
		{
			set{ _jiarubendanweitime=value;}
			get{return _jiarubendanweitime;}
		}
		/// <summary>
		/// ��Ƭ
		/// </summary>
		public string photo
		{
			set{ _photo=value;}
			get{return _photo;}
		}
		/// <summary>
		/// ���ɾ��
		/// </summary>
		public int? IsDelete
		{
			set{ _isdelete=value;}
			get{return _isdelete;}
		}
		/// <summary>
		/// ����ID
		/// </summary>
		public int DepartmentID
		{
			set{ _departmentid=value;}
			get{return _departmentid;}
		}
		/// <summary>
		/// �Ƿ������¼��0����1������
		/// </summary>
		public int IsEnter
		{
			set{ _isenter=value;}
			get{return _isenter;}
		}
		/// <summary>
		/// �绰����
		/// </summary>
		public string TelphoneNumber
		{
			set{ _telphonenumber=value;}
			get{return _telphonenumber;}
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
		/// <summary>
		/// ��¼����
		/// </summary>
		public int loginCount
		{
			set{ _logincount=value;}
			get{return _logincount;}
		}
		/// <summary>
		/// ����¼ʱ��
		/// </summary>
		public DateTime loginTime
		{
			set{ _logintime=value;}
			get{return _logintime;}
		}
		#endregion Model

	}
}

