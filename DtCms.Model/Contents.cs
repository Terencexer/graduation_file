using System;
namespace DtCms.Model
{
	/// <summary>
	/// ��ҳʵ����
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
        /// ���ñ�ʶ
        /// </summary>
        public string CallIndex
        {
            get { return _callindex; }
            set { _callindex = value; }
        }
		/// <summary>
		/// ���ݱ���
		/// </summary>
		public string Title
		{
			set{ _title=value;}
			get{return _title;}
		}
		/// <summary>
		/// ��ĿID
		/// </summary>
		public int ClassId
		{
			set{ _classid=value;}
			get{return _classid;}
		}
		/// <summary>
		/// ��ϸ����
		/// </summary>
		public string Content
		{
			set{ _content=value;}
			get{return _content;}
		}
		/// <summary>
		/// �������֣�ԽСԽ��ǰ
		/// </summary>
		public int SortId
		{
			set{ _sortid=value;}
			get{return _sortid;}
		}
		#endregion Model

	}
}

