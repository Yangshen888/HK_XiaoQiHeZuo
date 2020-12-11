using System;
namespace Haikan.SchoolProjectsCore.MDB.Model
{
	/// <summary>
	/// ��Ʊ��Ϣ
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
		/// ��Ŀ����
		/// </summary>
		public string ProjectName
		{
			set{ _projectname=value;}
			get{return _projectname;}
		}
		/// <summary>
		/// ��ҵ����
		/// </summary>
		public string EnterpriseName
		{
			set{ _enterprisename=value;}
			get{return _enterprisename;}
		}
		/// <summary>
		/// ��ƱID
		/// </summary>
		public int InvoiceID
		{
			set{ _invoiceid=value;}
			get{return _invoiceid;}
		}
		/// <summary>
		/// ��Ʊ����
		/// </summary>
		public string InvoiceName
		{
			set{ _invoicename=value;}
			get{return _invoicename;}
		}
		/// <summary>
		/// ��Ʊ¼��ʱ��
		/// </summary>
		public string InvoiceTime
		{
			set{ _invoicetime=value;}
			get{return _invoicetime;}
		}
		/// <summary>
		/// ��ע
		/// </summary>
		public string Note
		{
			set{ _note=value;}
			get{return _note;}
		}
		#endregion Model

	}
}

