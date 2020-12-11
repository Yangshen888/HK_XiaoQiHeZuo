using System;
namespace Haikan.SchoolProjectsCore.MDB.Model
{
	/// <summary>
	/// 企业信息
	/// </summary>
	[Serializable]
	public partial class Eenterprises
	{
		public Eenterprises()
		{}
		#region Model
		private int _enterpriseid;
		private string _enterprisename;
		private string _contact;
		private string _einformation;
		private string _note;
		private string _audit;
		/// <summary>
		/// 企业ID
		/// </summary>
		public int EnterpriseID
		{
			set{ _enterpriseid=value;}
			get{return _enterpriseid;}
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
		/// 联系方式
		/// </summary>
		public string Contact
		{
			set{ _contact=value;}
			get{return _contact;}
		}
		/// <summary>
		/// 企业资料信息【停用】
		/// </summary>
		public string EInformation
		{
			set{ _einformation=value;}
			get{return _einformation;}
		}
		/// <summary>
		/// 备注
		/// </summary>
		public string Note
		{
			set{ _note=value;}
			get{return _note;}
		}
		/// <summary>
		/// 审核状态【只有院系领导及以上可以审核】
		/// </summary>
		public string Audit
		{
			set{ _audit=value;}
			get{return _audit;}
		}
		#endregion Model

	}
}

