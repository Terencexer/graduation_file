using System;
namespace DtCms.Model
{
	/// <summary>
	/// �������ʵ����
	/// </summary>
	[Serializable]
	public partial class Adbanner
	{
		public Adbanner()
		{}
		#region Model
		private int _id;
		private int _aid;
		private string _title;
		private DateTime _starttime;
		private DateTime _endtime;
		private string _adurl;
		private string _linkurl;
		private string _adremark;
        private int _sortid = 0;
		private int _islock;
		private DateTime _addtime;
		/// <summary>
		/// ����ID PK
		/// </summary>
		public int id
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// ���λID
		/// </summary>
		public int Aid
		{
			set{ _aid=value;}
			get{return _aid;}
		}
		/// <summary>
		/// ���������
		/// </summary>
		public string Title
		{
			set{ _title=value;}
			get{return _title;}
		}
		/// <summary>
		/// ��ʼʱ��
		/// </summary>
		public DateTime StartTime
		{
			set{ _starttime=value;}
			get{return _starttime;}
		}
		/// <summary>
		/// ����ʱ��
		/// </summary>
		public DateTime EndTime
		{
			set{ _endtime=value;}
			get{return _endtime;}
		}
		/// <summary>
		/// ����ַ
		/// </summary>
		public string AdUrl
		{
			set{ _adurl=value;}
			get{return _adurl;}
		}
		/// <summary>
		/// ���ӵ�ַ
		/// </summary>
		public string LinkUrl
		{
			set{ _linkurl=value;}
			get{return _linkurl;}
		}
		/// <summary>
		/// ��ע˵��
		/// </summary>
		public string AdRemark
		{
			set{ _adremark=value;}
			get{return _adremark;}
		}
		/// <summary>
		/// �������֣�ԽСԽ��ǰ
		/// </summary>
		public int SortId
		{
			set{ _sortid=value;}
			get{return _sortid;}
		}
		/// <summary>
		/// ״̬��0������1��ͣ
		/// </summary>
		public int IsLock
		{
			set{ _islock=value;}
			get{return _islock;}
		}
		/// <summary>
		/// ����ʱ��
		/// </summary>
        public DateTime AddTime
        {
            set { _addtime = value; }
            get { return _addtime; }
        }
		#endregion Model

	}
}

