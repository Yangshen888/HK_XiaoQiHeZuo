using System;
namespace Haikan.SchoolProjectsCore.MDB.Model
{
	/// <summary>
	/// �ļ�����
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
		/// �ļ�ID
		/// </summary>
		public int FileID
		{
			set{ _fileid=value;}
			get{return _fileid;}
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
		/// ��ҵ�ļ�
		/// </summary>
		public string EnterpriseFile
		{
			set{ _enterprisefile=value;}
			get{return _enterprisefile;}
		}
		/// <summary>
		/// ��ͬ�ļ�
		/// </summary>
		public string ContractFile
		{
			set{ _contractfile=value;}
			get{return _contractfile;}
		}
		/// <summary>
		/// ��Ʊ�ļ�
		/// </summary>
		public string InvoiceFile
		{
			set{ _invoicefile=value;}
			get{return _invoicefile;}
		}
		/// <summary>
		/// ��Ŀ����
		/// </summary>
		public string ProjectFile
		{
			set{ _projectfile=value;}
			get{return _projectfile;}
		}
		/// <summary>
		/// ɾ����¼
		/// </summary>
		public string IsDele
		{
			set{ _isdele=value;}
			get{return _isdele;}
		}
		#endregion Model

	}
}

