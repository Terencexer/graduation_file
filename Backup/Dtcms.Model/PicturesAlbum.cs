using System;
namespace DtCms.Model
{
	/// <summary>
	/// Õº∆¨ µÃÂ¿‡
	/// </summary>
	[Serializable]
	public partial class PicturesAlbum
	{
		public PicturesAlbum()
		{}
		#region Model
		private int _id;
		private int _pictureid;
		private string _imgurl;
		/// <summary>
		/// 
		/// </summary>
		public int Id
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int PictureId
		{
			set{ _pictureid=value;}
			get{return _pictureid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string ImgUrl
		{
			set{ _imgurl=value;}
			get{return _imgurl;}
		}
		#endregion Model

	}
}

