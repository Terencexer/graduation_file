using System;
namespace DtCms.Model
{
	/// <summary>
	/// ���λʵ����
	/// </summary>
	[Serializable]
	public partial class Advertising
	{
		public Advertising()
		{}
		#region Model
		private int _id;
		private string _title;
		private int _adtype;
		private string _adremark;
		private int _adnum;
		private decimal _adprice=0M;
		private int _adwidth=0;
		private int _adheight=0;
		private string _adtarget;
		/// <summary>
		/// ����ID PK
		/// </summary>
		public int Id
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// ���λ����
		/// </summary>
		public string Title
		{
			set{ _title=value;}
			get{return _title;}
		}
		/// <summary>
		/// ���λ����
		/// </summary>
		public int AdType
		{
			set{ _adtype=value;}
			get{return _adtype;}
		}
		/// <summary>
		/// ���λ˵��
		/// </summary>
		public string AdRemark
		{
			set{ _adremark=value;}
			get{return _adremark;}
		}
		/// <summary>
		/// ��ʾ�����
		/// </summary>
		public int AdNum
		{
			set{ _adnum=value;}
			get{return _adnum;}
		}
		/// <summary>
		/// ���λ�۸�
		/// </summary>
		public decimal AdPrice
		{
			set{ _adprice=value;}
			get{return _adprice;}
		}
		/// <summary>
		/// ���λ���
		/// </summary>
		public int AdWidth
		{
			set{ _adwidth=value;}
			get{return _adwidth;}
		}
		/// <summary>
		/// ���λ�߶�
		/// </summary>
		public int AdHeight
		{
			set{ _adheight=value;}
			get{return _adheight;}
		}
		/// <summary>
		/// ����Ŀ�꣬�´��ڡ�ԭ����
		/// </summary>
		public string AdTarget
		{
			set{ _adtarget=value;}
			get{return _adtarget;}
		}
		#endregion Model

	}
}

