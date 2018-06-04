using System;
using System.Collections.Generic;
using System.Text;

namespace DtCms.BLL
{
    public class Programme
    {
        private readonly DtCms.DAL.Programme dal = new DtCms.DAL.Programme();
        public Programme()
        { }

        public bool Exists(string Id)
         {
             return dal.Exists(Id);
         }
        public bool PExists(string activityId, string pId)
        {
            return dal.PExists(activityId, pId);
        }
         public int GetCount(string strWhere)
         {
             return dal.GetCount(strWhere);
         }
         public int Add(DtCms.Model.Programme model)
         {
             return dal.Add(model);
         }
         public void UpdateField(String Id, string strValue)
         {
             dal.UpdateField(Id, strValue);
         }
         public bool Update(DtCms.Model.Programme model)
         {
             return dal.Update(model);
         }
         public bool Delete(string Id)
         {

             return dal.Delete(Id);
         }
         public DtCms.Model.Programme QueryOneRecord(string activityId, string pId)
         {
             return dal.QueryOneRecord(activityId, pId);
         }
    }
}
