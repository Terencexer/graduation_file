using System;
namespace DtCms.Model
{
	/// <summary>
    /// ͼ����չ�ֶ�ʵ����
	/// </summary>
	[Serializable]
	public partial class PicturesField
	{
		public PicturesField()
		{}
		#region Model
		private int _id;
		private string _title;
		private string _fieldremark;
		private string _fieldtype;
		private bool _isnull= false;
		private int _sortid=0;
		/// <summary>
		/// 
		/// </summary>
		public int Id
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// �ֶα���
		/// </summary>
		public string Title
		{
			set{ _title=value;}
			get{return _title;}
		}
		/// <summary>
		/// �ֶ�˵��
		/// </summary>
		public string FieldRemark
		{
			set{ _fieldremark=value;}
			get{return _fieldremark;}
		}
		/// <summary>
		/// �ֶ�����
		/// </summary>
		public string FieldType
		{
			set{ _fieldtype=value;}
			get{return _fieldtype;}
		}
		/// <summary>
		/// �Ƿ����Ϊ��
		/// </summary>
		public bool IsNull
		{
			set{ _isnull=value;}
			get{return _isnull;}
		}
		/// <summary>
		/// ��������
		/// </summary>
		public int SortId
		{
			set{ _sortid=value;}
			get{return _sortid;}
		}
		#endregion Model

	}
}

