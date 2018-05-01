using System;
using System.Data;
using System.Collections.Generic;
using DtCms.Common;
namespace DtCms.BLL
{
	/// <summary>
	/// ��ҳ
	/// </summary>
	public partial class Contents
	{
        private readonly DtCms.DAL.Contents dal = new DtCms.DAL.Contents();
		public Contents()
		{}
		#region  Method

        /// <summary>
        /// �õ���ǰ������ҳ
        /// </summary>
        public string GetCallIndex()
		{
            return dal.GetCallIndex();
		}

		/// <summary>
		/// �Ƿ���ڸü�¼
		/// </summary>
		public bool Exists(int Id)
		{
			return dal.Exists(Id);
		}

        /// <summary>
        /// �Ƿ���ڸü�¼
        /// </summary>
        public bool Exists(string callIndex)
        {
            if (string.IsNullOrEmpty(callIndex))
                return false;
            return dal.Exists(callIndex);
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
		public int  Add(DtCms.Model.Contents model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// ����һ������
		/// </summary>
		public bool Update(DtCms.Model.Contents model)
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
		public DtCms.Model.Contents GetModel(int Id)
		{
			return dal.GetModel(Id);
		}

        /// <summary>
        /// �õ�һ������ʵ��
        /// </summary>
        public DtCms.Model.Contents GetModel(string callIndex)
        {
            return dal.GetModel(callIndex);
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

