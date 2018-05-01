using System;
namespace DtCms.Model
{
	/// <summary>
	/// ����ʵ����
	/// </summary>
	[Serializable]
	public partial class Downloads
	{
		public Downloads()
		{}
		#region Model
		private int _id;
		private string _title;
		private int _classid;
		private string _imgurl;
		private string _filetype;
		private int _filesize=0;
		private string _filepath;
		private int _click=0;
		private int _downnum=0;
		private string _content;
		private int _ismsg;
		private int _isred=0;
		private int _islock=0;
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
		/// �ļ�����
		/// </summary>
		public string Title
		{
			set{ _title=value;}
			get{return _title;}
		}
		/// <summary>
		/// �������
		/// </summary>
		public int ClassId
		{
			set{ _classid=value;}
			get{return _classid;}
		}
		/// <summary>
		/// Ԥ��ͼƬ
		/// </summary>
		public string ImgUrl
		{
			set{ _imgurl=value;}
			get{return _imgurl;}
		}
		/// <summary>
		/// �ļ�����
		/// </summary>
		public string FileType
		{
			set{ _filetype=value;}
			get{return _filetype;}
		}
		/// <summary>
		/// �ļ���С
		/// </summary>
		public int FileSize
		{
			set{ _filesize=value;}
			get{return _filesize;}
		}
		/// <summary>
		/// �ļ�·��
		/// </summary>
		public string FilePath
		{
			set{ _filepath=value;}
			get{return _filepath;}
		}
		/// <summary>
		/// �������
		/// </summary>
		public int Click
		{
			set{ _click=value;}
			get{return _click;}
		}
		/// <summary>
		/// ���ش���
		/// </summary>
		public int DownNum
		{
			set{ _downnum=value;}
			get{return _downnum;}
		}
		/// <summary>
		/// ��ϸ˵��
		/// </summary>
		public string Content
		{
			set{ _content=value;}
			get{return _content;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int IsMsg
		{
			set{ _ismsg=value;}
			get{return _ismsg;}
		}
		/// <summary>
		/// �Ƿ��Ƽ�
		/// </summary>
		public int IsRed
		{
			set{ _isred=value;}
			get{return _isred;}
		}
		/// <summary>
		/// �Ƿ�����
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
			set{ _addtime=value;}
			get{return _addtime;}
		}
		#endregion Model

	}
}

