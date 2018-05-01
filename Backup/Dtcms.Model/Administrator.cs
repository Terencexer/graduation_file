using System;
namespace DtCms.Model
{
	/// <summary>
	/// ����Աʵ����
	/// </summary>
	[Serializable]
	public partial class Administrator
	{
		public Administrator()
		{}
		#region Model
		private int _id;
		private string _username;
		private string _userpwd;
		private string _readname;
		private string _useremail;
		private int _usertype= 1;
		private string _userlevel;
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
		/// ��¼�û���
		/// </summary>
		public string UserName
		{
			set{ _username=value;}
			get{return _username;}
		}
		/// <summary>
		/// ��¼����
		/// </summary>
		public string UserPwd
		{
			set{ _userpwd=value;}
			get{return _userpwd;}
		}
		/// <summary>
		/// �û��ǳ�
		/// </summary>
		public string ReadName
		{
			set{ _readname=value;}
			get{return _readname;}
		}
		/// <summary>
		/// ��ϵ����
		/// </summary>
		public string UserEmail
		{
			set{ _useremail=value;}
			get{return _useremail;}
		}
		/// <summary>
		/// ����Ա����
		/// </summary>
		public int UserType
		{
			set{ _usertype=value;}
			get{return _usertype;}
		}
		/// <summary>
		/// Ȩ���б�
		/// </summary>
		public string UserLevel
		{
			set{ _userlevel=value;}
			get{return _userlevel;}
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
		/// 
		/// </summary>
		public DateTime AddTime
		{
			set{ _addtime=value;}
			get{return _addtime;}
		}
		#endregion Model

	}
}

