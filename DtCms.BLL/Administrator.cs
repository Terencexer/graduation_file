using System;
using System.Data;
using System.Collections.Generic;
using DtCms.Common;
namespace DtCms.BLL
{
	/// <summary>
	/// ����Ա
	/// </summary>
	public partial class Administrator
	{
		private readonly DtCms.DAL.Administrator dal=new DtCms.DAL.Administrator();
		public Administrator()
		{}
		#region  Method

		/// <summary>
		/// �õ����ID
		/// </summary>
		public int GetMaxId()
		{
			return dal.GetMaxId();
		}

		/// <summary>
		/// �Ƿ���ڸü�¼
		/// </summary>
		public bool Exists(int Id)
		{
			return dal.Exists(Id);
		}

        /// <summary>
        /// ����û����Ƿ��ظ�
        /// </summary>
        public bool Exists(string UserName)
        {
            return dal.Exists(UserName);
        }

        /// <summary>
        /// ����¼�û�
        /// </summary>
        public bool chkAdminLogin(string UserName, string UserPwd)
        {
            return dal.chkAdminLogin(UserName, UserPwd);
        }

        /// <summary>
        /// ������������(��ҳ�õ�)
        /// </summary>
        public int GetCount(string strWhere)
        {
            return dal.GetCount(strWhere);
        }

		/// <summary>
		/// ����һ������
		/// </summary>
		public int  Add(DtCms.Model.Administrator model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// ����һ������
		/// </summary>
		public bool Update(DtCms.Model.Administrator model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// ɾ��һ������
		/// </summary>
		public bool Delete(int Id)
		{
			
			return dal.Delete(Id);
		}

		/// <summary>
		/// �õ�һ������ʵ��
		/// </summary>
		public DtCms.Model.Administrator GetModel(int Id)
		{
			
			return dal.GetModel(Id);
		}

		/// <summary>
        /// �����û���ȡ��һ�����ݸ�MODEL
        /// </summary>
        public DtCms.Model.Administrator GetModel(string UserName)
        {
            return dal.GetModel(UserName);
        }

		/// <summary>
		/// ��������б�
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			return dal.GetList(strWhere);
		}
		/// <summary>
		/// ���ǰ��������
		/// </summary>
		public DataSet GetList(int Top,string strWhere,string filedOrder)
		{
			return dal.GetList(Top,strWhere,filedOrder);
		}
		
        /// <summary>
        /// ��ò�ѯ��ҳ����
        /// </summary>
        public DataSet GetPageList(int pageSize, int currentPage, string strWhere, string filedOrder)
        {
            return dal.GetPageList(pageSize, currentPage, strWhere, filedOrder);
        }

		#endregion  Method
	}
}

