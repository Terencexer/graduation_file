using System;
using System.Data;
using System.Collections.Generic;
using DtCms.Common;
namespace DtCms.BLL
{
	/// <summary>
	/// 单页
	/// </summary>
	public partial class Contents
	{
        private readonly DtCms.DAL.Contents dal = new DtCms.DAL.Contents();
		public Contents()
		{}
		#region  Method

        /// <summary>
        /// 得到最前的内容页
        /// </summary>
        public string GetCallIndex()
		{
            return dal.GetCallIndex();
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int Id)
		{
			return dal.Exists(Id);
		}

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string callIndex)
        {
            if (string.IsNullOrEmpty(callIndex))
                return false;
            return dal.Exists(callIndex);
        }

        /// <summary>
        /// 返回数据总数(分页用到)
        /// </summary>
        public int GetCount(string strWhere)
        {
            return dal.GetCount(strWhere);
        }

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int  Add(DtCms.Model.Contents model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(DtCms.Model.Contents model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(int Id)
		{
			
			return dal.Delete(Id);
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public DtCms.Model.Contents GetModel(int Id)
		{
			return dal.GetModel(Id);
		}

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public DtCms.Model.Contents GetModel(string callIndex)
        {
            return dal.GetModel(callIndex);
        }

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			return dal.GetList(strWhere);
		}
		/// <summary>
		/// 获得前几行数据
		/// </summary>
		public DataSet GetList(int Top,string strWhere,string filedOrder)
		{
			return dal.GetList(Top,strWhere,filedOrder);
		}

        /// <summary>
        /// 获得查询分页数据
        /// </summary>
        public DataSet GetPageList(int pageSize, int currentPage, string strWhere, string filedOrder)
        {
            return dal.GetPageList(pageSize, currentPage, strWhere, filedOrder);
        }

		#endregion  Method
	}
}

