using System;
namespace Haikan.SchoolProjectsCore.MDB.Model
{
	/// <summary>
	/// 文件资料
	/// </summary>
	[Serializable]
	public partial class HFile
	{
		public HFile()
		{}
		#region Model
		private int _fileid;
		private string _enterprisename;
		private string _enterprisefile;
		private string _contractfile;
		private string _invoicefile;
		private string _projectfile;
		private string _isdele;
		/// <summary>
		/// 文件ID
		/// </summary>
		public int FileID
		{
			set{ _fileid=value;}
			get{return _fileid;}
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
		/// 企业文件
		/// </summary>
		public string EnterpriseFile
		{
			set{ _enterprisefile=value;}
			get{return _enterprisefile;}
		}
		/// <summary>
		/// 合同文件
		/// </summary>
		public string ContractFile
		{
			set{ _contractfile=value;}
			get{return _contractfile;}
		}
		/// <summary>
		/// 发票文件
		/// </summary>
		public string InvoiceFile
		{
			set{ _invoicefile=value;}
			get{return _invoicefile;}
		}
		/// <summary>
		/// 项目资料
		/// </summary>
		public string ProjectFile
		{
			set{ _projectfile=value;}
			get{return _projectfile;}
		}
		/// <summary>
		/// 删除记录
		/// </summary>
		public string IsDele
		{
			set{ _isdele=value;}
			get{return _isdele;}
		}
		#endregion Model

	}
}

