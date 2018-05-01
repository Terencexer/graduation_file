using System;
namespace DtCms.Model
{
	/// <summary>
	/// ����ʵ����
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
		/// ��������Ƶ����Ŀ
		/// </summary>
		public int KindId
		{
			set{ _kindid=value;}
			get{return _kindid;}
		}
		/// <summary>
		/// ����������ϢID
		/// </summary>
		public int ParentId
		{
			set{ _parentid=value;}
			get{return _parentid;}
		}
		/// <summary>
		/// �����û�
		/// </summary>
		public string UserName
		{
			set{ _username=value;}
			get{return _username;}
		}
		/// <summary>
		/// �Ǽ�
		/// </summary>
		public int Grade
		{
			set{ _grade=value;}
			get{return _grade;}
		}
		/// <summary>
		/// ��������
		/// </summary>
		public string Content
		{
			set{ _content=value;}
			get{return _content;}
		}
        /// <summary>
        /// ״̬��0������1����
        /// </summary>
        public int IsLock
        {
            set { _islock = value; }
            get { return _islock; }
        }
		/// <summary>
		/// ����ʱ��
		/// </summary>
		public DateTime AddTime
		{
			set{ _addtime=value;}
			get{return _addtime;}
		}
		#endregion Model

	}
}

