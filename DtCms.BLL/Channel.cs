using System;
using System.Data;
using System.Collections.Generic;
using DtCms.Common;
namespace DtCms.BLL
{
	/// <summary>
	/// 栏目类别
	/// </summary>
	public partial class Channel
	{
        private readonly DtCms.DAL.Channel dal = new DtCms.DAL.Channel();
		public Channel()
		{}
		#region  Method

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
			return dal.GetMaxId();
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int Id)
		{
			return dal.Exists(Id);
		}

        /// <summary>
        /// 返回数据总数(分页用到)
        /// </summary>
        public int GetCount(string strWhere)
        {
            return dal.GetCount(strWhere);
        }

        /// <summary>
        /// 返回栏目名称
        /// </summary>
        public string GetChannelTitle(int classId)
        {
            return dal.GetChannelTitle(classId);
        }

        /// <summary>
        /// 返回栏目的父ID
        /// </summary>
        public int GetChannelParentId(int classId)
        {
            return dal.GetChannelParentId(classId);
        }

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int  Add(DtCms.Model.Channel model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(DtCms.Model.Channel model)
		{
			return dal.Update(model);
		}

		/// <summary>
        /// 删除该栏目分类及所有属下分类数据
		/// </summary>
		public void Delete(int Id)
		{

            dal.Delete(Id);
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public DtCms.Model.Channel GetModel(int Id)
		{
			
			return dal.GetModel(Id);
		}

		/// <summary>
        /// 取得所有栏目列表
        /// </summary>
        public DataTable GetList(int PId, int KId)
        {
            return dal.GetList(PId, KId);
        }

		/// <summary>
        /// 取得该栏目下的所有子栏目的ID
        /// </summary>
        public DataSet GetChannelListByClassId(int classId)
        {
            return dal.GetChannelListByClassId(classId);
        }

		#endregion  Method
	}
}

