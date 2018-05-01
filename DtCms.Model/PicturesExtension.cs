using System;
namespace DtCms.Model
{
	/// <summary>
	/// 图文扩展字段内容实体类
	/// </summary>
	[Serializable]
	public partial class PicturesExtension
	{
		public PicturesExtension()
		{}
		#region Model
		private int _id;
        private int _pictureid;
		private int _fieldid;
        private string _fieldname;
		private string _content;
		/// <summary>
		/// 
		/// </summary>
		public int Id
		{
			set{ _id=value;}
			get{return _id;}
		}
        /// <summary>
        /// 所属图文ID
        /// </summary>
        public int PictureId
        {
            set { _pictureid = value; }
            get { return _pictureid; }
        }
		/// <summary>
		/// 扩展字段ID
		/// </summary>
		public int FieldId
		{
			set{ _fieldid=value;}
			get{return _fieldid;}
		}
        /// <summary>
        /// 字段标题
        /// </summary>
        public string FieldName
        {
            set { _fieldname = value; }
            get { return _fieldname; }
        }
		/// <summary>
		/// 填写内容
		/// </summary>
		public string Content
		{
			set{ _content=value;}
			get{return _content;}
		}
		#endregion Model

	}
}

