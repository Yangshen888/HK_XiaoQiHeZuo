using System;
namespace Haikan.SchoolProjectsCore.MDB.Model
{
	/// <summary>
	/// ��ͬ��Ϣ
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
		/// ��ͬID
		/// </summary>
		public int CID
		{
			set{ _cid=value;}
			get{return _cid;}
		}
		/// <summary>
		/// ��ĿID
		/// </summary>
		public int ProjectID
		{
			set{ _projectid=value;}
			get{return _projectid;}
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
		/// ��ͬ����
		/// </summary>
		public string ContractName
		{
			set{ _contractname=value;}
			get{return _contractname;}
		}
		/// <summary>
		/// ǩ������
		/// </summary>
		public string CInformation
		{
			set{ _cinformation=value;}
			get{return _cinformation;}
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
		/// ǩ���ˡ��׷���
		/// </summary>
		public string ConsigneeA
		{
			set{ _consigneea=value;}
			get{return _consigneea;}
		}
		/// <summary>
		/// ǩ���ˡ��ҷ���
		/// </summary>
		public string ConsigneeB
		{
			set{ _consigneeb=value;}
			get{return _consigneeb;}
		}
		/// <summary>
		/// ��ͬ����ʱ��
		/// </summary>
		public string LastTime
		{
			set{ _lasttime=value;}
			get{return _lasttime;}
		}
		/// <summary>
		/// ��ͬ���
		/// </summary>
		public string Money
		{
			set{ _money=value;}
			get{return _money;}
		}
		#endregion Model

	}
}

