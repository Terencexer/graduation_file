using System;
using System.Collections.Generic;
namespace DtCms.Model
{
	/// <summary>
	/// 图文实体类
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
		/// 图文标题
		/// </summary>
		public string Title
		{
			set{ _title=value;}
			get{return _title;}
		}
		/// <summary>
		/// 所属类别
		/// </summary>
		public int ClassId
		{
			set{ _classid=value;}
			get{return _classid;}
		}
		/// <summary>
		/// 价格
		/// </summary>
		public decimal Price
		{
			set{ _price=value;}
			get{return _price;}
		}
		/// <summary>
		/// 图片路径
		/// </summary>
		public string ImgUrl
		{
			set{ _imgurl=value;}
			get{return _imgurl;}
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
		/// 点击次数
		/// </summary>
		public int Click
		{
			set{ _click=value;}
			get{return _click;}
		}
		/// <summary>
		/// 是否允许评论
		/// </summary>
		public int IsMsg
		{
			set{ _ismsg=value;}
			get{return _ismsg;}
		}
		/// <summary>
		/// 是否置顶
		/// </summary>
		public int IsTop
		{
			set{ _istop=value;}
			get{return _istop;}
		}
		/// <summary>
		/// 是否推荐
		/// </summary>
		public int IsRed
		{
			set{ _isred=value;}
			get{return _isred;}
		}
		/// <summary>
		/// 是否热门
		/// </summary>
		public int IsHot
		{
			set{ _ishot=value;}
			get{return _ishot;}
		}
		/// <summary>
		/// 是否幻灯片
		/// </summary>
		public int IsSlide
		{
			set{ _isslide=value;}
			get{return _isslide;}
		}
		/// <summary>
		/// 是否锁定
		/// </summary>
		public int IsLock
		{
			set{ _islock=value;}
			get{return _islock;}
		}
		/// <summary>
		/// 排序数字
		/// </summary>
		public int SortId
		{
			set{ _sortid=value;}
			get{return _sortid;}
		}
		/// <summary>
		/// 发布时间
		/// </summary>
		public DateTime AddTime
		{
			set{ _addtime=value;}
			get{return _addtime;}
		}
		#endregion Model

        private List<PicturesExtension> _picturesextensions;
        /// <summary>
        /// 扩展字段子类 
        /// </summary>
        public List<PicturesExtension> PicturesExtensions
        {
            set { _picturesextensions = value; }
            get { return _picturesextensions; }
        }

        private List<PicturesAlbum> _picturesalbums;
        /// <summary>
        /// 图文相册
        /// </summary>
        public List<PicturesAlbum> PicturesAlbums
        {
            get { return _picturesalbums; }
            set { _picturesalbums = value; }
        }


	}
}

