using System;
namespace Haikan.SchoolProjectsCore.MDB.Model
{
	/// <summary>
	/// ����ѧԺ
	/// </summary>
	[Serializable]
	public partial class Department
	{
		public Department()
		{}
		#region Model
		private int _id;
		private string _departmentname;
		private string _chargeman;
		private string _tel;
		private string _fax;
		private string _details;
		private string _isdelete;
		/// <summary>
		/// 
		/// </summary>
		public int ID
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// Ժϵ����
		/// </summary>
		public string DepartmentName
		{
			set{ _departmentname=value;}
			get{return _departmentname;}
		}
		/// <summary>
		/// ������
		/// </summary>
		public string ChargeMan
		{
			set{ _chargeman=value;}
			get{return _chargeman;}
		}
		/// <summary>
		/// �绰
		/// </summary>
		public string Tel
		{
			set{ _tel=value;}
			get{return _tel;}
		}
		/// <summary>
		/// ����
		/// </summary>
		public string Fax
		{
			set{ _fax=value;}
			get{return _fax;}
		}
		/// <summary>
		/// Ժϵ����
		/// </summary>
		public string details
		{
			set{ _details=value;}
			get{return _details;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string IsDelete
		{
			set{ _isdelete=value;}
			get{return _isdelete;}
		}
		#endregion Model

	}
}

