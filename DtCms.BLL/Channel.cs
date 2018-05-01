using System;
using System.Data;
using System.Collections.Generic;
using DtCms.Common;
namespace DtCms.BLL
{
	/// <summary>
	/// ��Ŀ���
	/// </summary>
	public partial class Channel
	{
        private readonly DtCms.DAL.Channel dal = new DtCms.DAL.Channel();
		public Channel()
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
        /// ������Ŀ����
        /// </summary>
        public string GetChannelTitle(int classId)
        {
            return dal.GetChannelTitle(classId);
        }

        /// <summary>
        /// ������Ŀ�ĸ�ID
        /// </summary>
        public int GetChannelParentId(int classId)
        {
            return dal.GetChannelParentId(classId);
        }

		/// <summary>
		/// ����һ������
		/// </summary>
		public int  Add(DtCms.Model.Channel model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// ����һ������
		/// </summary>
		public bool Update(DtCms.Model.Channel model)
		{
			return dal.Update(model);
		}

		/// <summary>
        /// ɾ������Ŀ���༰�������·�������
		/// </summary>
		public void Delete(int Id)
		{

            dal.Delete(Id);
		}

		/// <summary>
		/// �õ�һ������ʵ��
		/// </summary>
		public DtCms.Model.Channel GetModel(int Id)
		{
			
			return dal.GetModel(Id);
		}

		/// <summary>
        /// ȡ��������Ŀ�б�
        /// </summary>
        public DataTable GetList(int PId, int KId)
        {
            return dal.GetList(PId, KId);
        }

		/// <summary>
        /// ȡ�ø���Ŀ�µ���������Ŀ��ID
        /// </summary>
        public DataSet GetChannelListByClassId(int classId)
        {
            return dal.GetChannelListByClassId(classId);
        }

		#endregion  Method
	}
}

