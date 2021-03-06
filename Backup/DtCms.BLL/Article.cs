using System;
using System.Data;
using System.Collections.Generic;
using DtCms.Common;
namespace DtCms.BLL
{
	/// <summary>
	/// 文章
	/// </summary>
	public partial class Article
	{
        private readonly DtCms.DAL.Article dal = new DtCms.DAL.Article();
		public Article()
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
        /// 返回该类别下的所有记录总数(分页用到)
        /// </summary>
        public int GetCount(string strWhere, int classId, int kindId)
        {
            return dal.GetCount(strWhere, classId, kindId);
        }

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int  Add(DtCms.Model.Article model)
		{
			return dal.Add(model);
		}

        /// <summary>
        /// 修改一列数据
        /// </summary>
        public void UpdateField(int Id, string strValue)
        {
            dal.UpdateField(Id, strValue);
        }

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(DtCms.Model.Article model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
        public bool Delete(int kindId, int Id)
        {

            return dal.Delete(kindId, Id);
        }

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public DtCms.Model.Article GetModel(int Id)
		{
			
			return dal.GetModel(Id);
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

