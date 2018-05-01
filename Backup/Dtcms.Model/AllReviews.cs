using System;
namespace DtCms.Model
{
	/// <summary>
	/// 评论实体类
	/// </summary>
	[Serializable]
	public partial class AllReviews
	{
		public AllReviews()
		{}
		#region Model
		private int _id;
		private int _kindid;
		private int _parentid;
		private string _username;
		private int _grade;
		private string _content;
        private int _islock = 0;
		private DateTime _addtime= DateTime.Now;
		/// <summary>
		/// 
		/// </summary>
		public int Id
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 所属评论频道栏目
		/// </summary>
		public int KindId
		{
			set{ _kindid=value;}
			get{return _kindid;}
		}
		/// <summary>
		/// 所属评论信息ID
		/// </summary>
		public int ParentId
		{
			set{ _parentid=value;}
			get{return _parentid;}
		}
		/// <summary>
		/// 评论用户
		/// </summary>
		public string UserName
		{
			set{ _username=value;}
			get{return _username;}
		}
		/// <summary>
		/// 星级
		/// </summary>
		public int Grade
		{
			set{ _grade=value;}
			get{return _grade;}
		}
		/// <summary>
		/// 评论内容
		/// </summary>
		public string Content
		{
			set{ _content=value;}
			get{return _content;}
		}
        /// <summary>
        /// 状态，0正常，1隐藏
        /// </summary>
        public int IsLock
        {
            set { _islock = value; }
            get { return _islock; }
        }
		/// <summary>
		/// 评论时间
		/// </summary>
		public DateTime AddTime
		{
			set{ _addtime=value;}
			get{return _addtime;}
		}
		#endregion Model

	}
}

