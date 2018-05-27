using System;
using System.Data;
using System.Collections.Generic;
using DtCms.Common;

namespace DtCms.BLL
{
    public class Activity
    {
        private readonly DtCms.DAL.Activity dal = new DtCms.DAL.Activity();
        public Activity()
        { }
        #region  Method

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string Id)
        {
            return dal.Exists(Id);
        }
        public bool AcExists(DateTime Atime, string Aplace)
        {
            return dal.AcExists(Atime, Aplace);
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
        public int Add(DtCms.Model.Activity model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 修改一列数据
        /// </summary>
        public void UpdateField(String Id, string strValue)
        {
            dal.UpdateField(Id, strValue);
        }
        public void UpdateFieldPreparation(String Id, string strValue)
        {
            dal.UpdateFieldPreparation(Id, strValue);
        }
        public void UpdateFieldMid(String Id, string strValue)
        {
            dal.UpdateFieldMid(Id, strValue);
        }
        public void UpdateFieldLastPre(String Id, string strValue)
        {
            dal.UpdateFieldLastPre(Id, strValue);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(DtCms.Model.Activity model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(string Id)
        {

            return dal.Delete(Id);
        }
        /// <summary>
        /// 删除多条数据
        /// </summary>
        public bool DeleteList(string Idlist)
        {
            return dal.DeleteList(Idlist);
        }



        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            return dal.GetList(strWhere);
        }

        public void UpdateOneRecordAuditStatus(string ActivityId)
        {
            dal.UpdateOneRecordAuditStatus(ActivityId, "审核通过");
        }
        public void UpdateOneRecordAuditStatusBack(string ActivityId)
        {
            dal.UpdateOneRecordAuditStatus(ActivityId, "退回修改");
        }
        public void UpdateOneRecordAuditStatusUncheck(string ActivityId)
        {
            dal.UpdateOneRecordAuditStatus(ActivityId, "不批准");
        }
        public void ReupdateOneRecordAuditStatus(string ActivityId)
        {
            dal.UpdateOneRecordAuditStatus(ActivityId, "未审核");
        }
        public void UpdateOneRecordTicketStatus(string ActivityId)
        {
            dal.UpdateOneRecordTicketStatus(ActivityId, "发布中");
        }
        public void UpdateOneRecordTicketStatusCancel(string ActivityId)
        {
            dal.UpdateOneRecordTicketStatus(ActivityId, "未发布");
        }
        public DtCms.Model.Activity QueryActivity(string ActivityId)
        {
            return dal.QueryOneRecord(ActivityId);
        }

        #endregion  Method

    }
}