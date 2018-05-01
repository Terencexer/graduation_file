using System;
using System.Collections.Generic;
namespace DtCms.Model
{
	/// <summary>
	/// ͼ��ʵ����
	/// </summary>
	[Serializable]
	public partial class Pictures
	{
		public Pictures()
		{}
		#region Model
		private int _id;
		private string _title;
		private int _classid;
		private decimal _price=0M;
		private string _imgurl;
		private string _content;
		private int _click=0;
		private int _ismsg=0;
		private int _istop=0;
		private int _isred=0;
		private int _ishot=0;
		private int _isslide=0;
		private int _islock=0;
		private int _sortid=0;
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
		/// ͼ�ı���
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
		/// �۸�
		/// </summary>
		public decimal Price
		{
			set{ _price=value;}
			get{return _price;}
		}
		/// <summary>
		/// ͼƬ·��
		/// </summary>
		public string ImgUrl
		{
			set{ _imgurl=value;}
			get{return _imgurl;}
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
		/// �������
		/// </summary>
		public int Click
		{
			set{ _click=value;}
			get{return _click;}
		}
		/// <summary>
		/// �Ƿ���������
		/// </summary>
		public int IsMsg
		{
			set{ _ismsg=value;}
			get{return _ismsg;}
		}
		/// <summary>
		/// �Ƿ��ö�
		/// </summary>
		public int IsTop
		{
			set{ _istop=value;}
			get{return _istop;}
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
		public int IsHot
		{
			set{ _ishot=value;}
			get{return _ishot;}
		}
		/// <summary>
		/// �Ƿ�õ�Ƭ
		/// </summary>
		public int IsSlide
		{
			set{ _isslide=value;}
			get{return _isslide;}
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
		/// ��������
		/// </summary>
		public int SortId
		{
			set{ _sortid=value;}
			get{return _sortid;}
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

        private List<PicturesExtension> _picturesextensions;
        /// <summary>
        /// ��չ�ֶ����� 
        /// </summary>
        public List<PicturesExtension> PicturesExtensions
        {
            set { _picturesextensions = value; }
            get { return _picturesextensions; }
        }

        private List<PicturesAlbum> _picturesalbums;
        /// <summary>
        /// ͼ�����
        /// </summary>
        public List<PicturesAlbum> PicturesAlbums
        {
            get { return _picturesalbums; }
            set { _picturesalbums = value; }
        }


	}
}

