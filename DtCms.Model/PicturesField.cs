using System;
namespace DtCms.Model
{
	/// <summary>
    /// 图文扩展字段实体类
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
		/// 字段标题
		/// </summary>
		public string Title
		{
			set{ _title=value;}
			get{return _title;}
		}
		/// <summary>
		/// 字段说明
		/// </summary>
		public string FieldRemark
		{
			set{ _fieldremark=value;}
			get{return _fieldremark;}
		}
		/// <summary>
		/// 字段类型
		/// </summary>
		public string FieldType
		{
			set{ _fieldtype=value;}
			get{return _fieldtype;}
		}
		/// <summary>
		/// 是否可以为空
		/// </summary>
		public bool IsNull
		{
			set{ _isnull=value;}
			get{return _isnull;}
		}
		/// <summary>
		/// 排序数字
		/// </summary>
		public int SortId
		{
			set{ _sortid=value;}
			get{return _sortid;}
		}
		#endregion Model

	}
}

