using System;
namespace DtCms.Model
{
	/// <summary>
	/// ͼ����չ�ֶ�����ʵ����
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
        /// ����ͼ��ID
        /// </summary>
        public int PictureId
        {
            set { _pictureid = value; }
            get { return _pictureid; }
        }
		/// <summary>
		/// ��չ�ֶ�ID
		/// </summary>
		public int FieldId
		{
			set{ _fieldid=value;}
			get{return _fieldid;}
		}
        /// <summary>
        /// �ֶα���
        /// </summary>
        public string FieldName
        {
            set { _fieldname = value; }
            get { return _fieldname; }
        }
		/// <summary>
		/// ��д����
		/// </summary>
		public string Content
		{
			set{ _content=value;}
			get{return _content;}
		}
		#endregion Model

	}
}

