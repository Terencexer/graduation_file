using System;
namespace DtCms.Model
{
	/// <summary>
	/// ��Ŀʵ����
	/// </summary>
	[Serializable]
	public partial class Channel
	{
		public Channel()
		{}
		#region Model
		private int _id;
		private string _title;
		private int _parentid;
		private string _classlist;
		private int _classlayer;
		private int _sortid=0;
		private string _pageurl;
		private int _kindid;
		/// <summary>
		/// 
		/// </summary>
		public int Id
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// ��Ŀ����
		/// </summary>
		public string Title
		{
			set{ _title=value;}
			get{return _title;}
		}
		/// <summary>
		/// ����ĿID
		/// </summary>
		public int ParentId
		{
			set{ _parentid=value;}
			get{return _parentid;}
		}
		/// <summary>
		/// ����ĿID�б�
		/// </summary>
		public string ClassList
		{
			set{ _classlist=value;}
			get{return _classlist;}
		}
		/// <summary>
		/// ��Ŀ���
		/// </summary>
		public int ClassLayer
		{
			set{ _classlayer=value;}
			get{return _classlayer;}
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
		/// ��Ŀ�����ַ
		/// </summary>
		public string PageUrl
		{
			set{ _pageurl=value;}
			get{return _pageurl;}
		}
		/// <summary>
		/// ��Ŀ�Զ�������
		/// </summary>
		public int KindId
		{
			set{ _kindid=value;}
			get{return _kindid;}
		}
		#endregion Model

	}
}

