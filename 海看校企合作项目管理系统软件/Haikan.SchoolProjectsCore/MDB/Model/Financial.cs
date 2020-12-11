using System;
namespace Haikan.SchoolProjectsCore.MDB.Model
{
	/// <summary>
	/// 财务信息
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
		/// 财务ID
		/// </summary>
		public int FID
		{
			set{ _fid=value;}
			get{return _fid;}
		}
		/// <summary>
		/// 项目名称
		/// </summary>
		public string ProjectName
		{
			set{ _projectname=value;}
			get{return _projectname;}
		}
		/// <summary>
		/// 企业名称
		/// </summary>
		public string EnterpriseName
		{
			set{ _enterprisename=value;}
			get{return _enterprisename;}
		}
		/// <summary>
		/// 收款还是付款
		/// </summary>
		public string IsPay
		{
			set{ _ispay=value;}
			get{return _ispay;}
		}
		/// <summary>
		/// 成交时间
		/// </summary>
		public string SuccessfulTime
		{
			set{ _successfultime=value;}
			get{return _successfultime;}
		}
		/// <summary>
		/// 收款/付款人
		/// </summary>
		public string Person
		{
			set{ _person=value;}
			get{return _person;}
		}
		/// <summary>
		/// 付款/收款金额
		/// </summary>
		public string PayMoney
		{
			set{ _paymoney=value;}
			get{return _paymoney;}
		}
		/// <summary>
		/// 操作管理员名称
		/// </summary>
		public string SystemUser
		{
			set{ _systemuser=value;}
			get{return _systemuser;}
		}
		/// <summary>
		/// 记录时间
		/// </summary>
		public string TimeStr
		{
			set{ _timestr=value;}
			get{return _timestr;}
		}
		/// <summary>
		/// 备注【付清/未付清】
		/// </summary>
		public string Note
		{
			set{ _note=value;}
			get{return _note;}
		}
		#endregion Model

	}
}

