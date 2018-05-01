using System;
using System.Data;
using System.Collections.Generic;
using DtCms.Common;
namespace DtCms.BLL
{
	/// <summary>
    /// ͼ��
	/// </summary>
	public partial class Pictures
	{
        private readonly DtCms.DAL.Pictures dal = new DtCms.DAL.Pictures();
		public Pictures()
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
        /// ������������(��ҳ�õ�)
        /// </summary>
        public int GetCount(string strWhere)
        {
            return dal.GetCount(strWhere);
        }

        /// <summary>
        /// ���ظ�����µ����м�¼����(��ҳ�õ�)
        /// </summary>
        public int GetCount(string strWhere, int classId, int kindId)
        {
            return dal.GetCount(strWhere, classId, kindId);
        }

		/// <summary>
        /// ����һ������,�����ӱ�����
		/// </summary>
		public int  Add(DtCms.Model.Pictures model)
		{
			return dal.Add(model);
		}

        /// <summary>
        /// �޸�һ������
        /// </summary>
        public void UpdateField(int Id, string strValue)
        {
            dal.UpdateField(Id, strValue);
        }

		/// <summary>
        /// ����һ������,�����ӱ�����
		/// </summary>
		public bool Update(DtCms.Model.Pictures model)
		{
			return dal.Update(model);
		}

		/// <summary>
        /// ɾ��һ�����ݣ����ӱ������������
		/// </summary>
		public bool Delete(int Id)
		{
			return dal.Delete(Id);
		}

		/// <summary>
		/// �õ�һ������ʵ��
		/// </summary>
		public DtCms.Model.Pictures GetModel(int Id)
		{
			
			return dal.GetModel(Id);
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

