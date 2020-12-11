using System;
namespace Haikan.SchoolProjectsCore.MDB.Model
{
	/// <summary>
	/// 合同信息
	/// </summary>
	[Serializable]
	public partial class Contract
	{
		public Contract()
		{}
		#region Model
		private int _cid;
		private int _projectid;
		private string _enterprisename;
		private string _contractname;
		private string _cinformation;
		private string _note;
		private string _consigneea;
		private string _consigneeb;
		private string _lasttime;
		private string _money;
		/// <summary>
		/// 合同ID
		/// </summary>
		public int CID
		{
			set{ _cid=value;}
			get{return _cid;}
		}
		/// <summary>
		/// 项目ID
		/// </summary>
		public int ProjectID
		{
			set{ _projectid=value;}
			get{return _projectid;}
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
		/// 合同名称
		/// </summary>
		public string ContractName
		{
			set{ _contractname=value;}
			get{return _contractname;}
		}
		/// <summary>
		/// 签订日期
		/// </summary>
		public string CInformation
		{
			set{ _cinformation=value;}
			get{return _cinformation;}
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
		/// 签订人【甲方】
		/// </summary>
		public string ConsigneeA
		{
			set{ _consigneea=value;}
			get{return _consigneea;}
		}
		/// <summary>
		/// 签订人【乙方】
		/// </summary>
		public string ConsigneeB
		{
			set{ _consigneeb=value;}
			get{return _consigneeb;}
		}
		/// <summary>
		/// 合同到期时间
		/// </summary>
		public string LastTime
		{
			set{ _lasttime=value;}
			get{return _lasttime;}
		}
		/// <summary>
		/// 合同金额
		/// </summary>
		public string Money
		{
			set{ _money=value;}
			get{return _money;}
		}
		#endregion Model

	}
}

