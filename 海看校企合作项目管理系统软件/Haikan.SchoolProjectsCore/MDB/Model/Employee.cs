using System;
namespace Haikan.SchoolProjectsCore.MDB.Model
{
	/// <summary>
	/// Ա����Ϣ
	/// </summary>
	[Serializable]
	public partial class Employee
	{
		public Employee()
		{}
		#region Model
		private int _eid;
		private string _projectname;
		private string _enterprisename;
		private string _employeename;
		private string _employeetime;
		private string _note;
		/// <summary>
		/// ��ԱID
		/// </summary>
		public int EID
		{
			set{ _eid=value;}
			get{return _eid;}
		}
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
		/// Ա������
		/// </summary>
		public string EmployeeName
		{
			set{ _employeename=value;}
			get{return _employeename;}
		}
		/// <summary>
		/// ����ʱ��
		/// </summary>
		public string EmployeeTime
		{
			set{ _employeetime=value;}
			get{return _employeetime;}
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

