using System;
namespace Haikan.SchoolProjectsCore.MDB.Model
{
	/// <summary>
	/// 发票信息
	/// </summary>
	[Serializable]
	public partial class Invoice
	{
		public Invoice()
		{}
		#region Model
		private string _projectname;
		private string _enterprisename;
		private int _invoiceid;
		private string _invoicename;
		private string _invoicetime;
		private string _note;
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
		/// 发票ID
		/// </summary>
		public int InvoiceID
		{
			set{ _invoiceid=value;}
			get{return _invoiceid;}
		}
		/// <summary>
		/// 发票名称
		/// </summary>
		public string InvoiceName
		{
			set{ _invoicename=value;}
			get{return _invoicename;}
		}
		/// <summary>
		/// 发票录入时间
		/// </summary>
		public string InvoiceTime
		{
			set{ _invoicetime=value;}
			get{return _invoicetime;}
		}
		/// <summary>
		/// 备注
		/// </summary>
		public string Note
		{
			set{ _note=value;}
			get{return _note;}
		}
		#endregion Model

	}
}

