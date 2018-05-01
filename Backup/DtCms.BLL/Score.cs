using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace DtCms.BLL
{
    public class Score
    {
        private readonly DtCms.DAL.Score dal = new DtCms.DAL.Score();

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(DtCms.Model.Score model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 获得查询分页数据
        /// </summary>
        public DataSet GetPageList(int pageSize, int currentPage, string strWhere, string filedOrder)
        {
            return dal.GetPageList(pageSize, currentPage, strWhere, filedOrder);
        }

        /// <summary>
        /// 返回数据总数(分页用到)
        /// </summary>
        public int GetCount(string strWhere)
        {
            return dal.GetCount(strWhere);
        }
    }
}
