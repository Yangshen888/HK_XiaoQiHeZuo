using System;
namespace Haikan.SchoolProjectsCore.MDB.Model
{
	/// <summary>
	/// ��ҵ��Ϣ
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
		/// ��ҵID
		/// </summary>
		public int EnterpriseID
		{
			set{ _enterpriseid=value;}
			get{return _enterpriseid;}
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
		/// ��ϵ��ʽ
		/// </summary>
		public string Contact
		{
			set{ _contact=value;}
			get{return _contact;}
		}
		/// <summary>
		/// ��ҵ������Ϣ��ͣ�á�
		/// </summary>
		public string EInformation
		{
			set{ _einformation=value;}
			get{return _einformation;}
		}
		/// <summary>
		/// ��ע
		/// </summary>
		public string Note
		{
			set{ _note=value;}
			get{return _note;}
		}
		/// <summary>
		/// ���״̬��ֻ��Ժϵ�쵼�����Ͽ�����ˡ�
		/// </summary>
		public string Audit
		{
			set{ _audit=value;}
			get{return _audit;}
		}
		#endregion Model

	}
}

