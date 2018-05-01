using System;
namespace DtCms.Model
{
	/// <summary>
	/// 单页实体类
	/// </summary>
	[Serializable]
	public partial class Contents
	{
		public Contents()
		{}
		#region Model
		private int _id;
        private string _callindex;
		private string _title;
		private int _classid;
		private string _content;
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
        /// 调用标识
        /// </summary>
        public string CallIndex
        {
            get { return _callindex; }
            set { _callindex = value; }
        }
		/// <summary>
		/// 内容标题
		/// </summary>
		public string Title
		{
			set{ _title=value;}
			get{return _title;}
		}
		/// <summary>
		/// 栏目ID
		/// </summary>
		public int ClassId
		{
			set{ _classid=value;}
			get{return _classid;}
		}
		/// <summary>
		/// 详细介绍
		/// </summary>
		public string Content
		{
			set{ _content=value;}
			get{return _content;}
		}
		/// <summary>
		/// 排序数字，越小越向前
		/// </summary>
		public int SortId
		{
			set{ _sortid=value;}
			get{return _sortid;}
		}
		#endregion Model

	}
}

