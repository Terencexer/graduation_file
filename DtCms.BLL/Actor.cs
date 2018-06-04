using System;
using System.Collections.Generic;
using System.Text;

namespace DtCms.BLL
{
    public class Actor
    {
         private readonly DtCms.DAL.Actor dal = new DtCms.DAL.Actor();
         public Actor()
        { }

         public bool AcExists(string ProgrammeId, string UserName)
         {
             return dal.AcExists(ProgrammeId, UserName);
         }
         public int GetCount(string strWhere)
         {
             return dal.GetCount(strWhere);
         }
         public int Add(DtCms.Model.Actor model)
         {
             return dal.Add(model);
         }
         public void UpdateField(String Id, string strValue)
         {
             dal.UpdateField(Id, strValue);
         }
         public bool Update(DtCms.Model.Actor model)
         {
             return dal.Update(model);
         }
         public bool Delete(string Id)
         {

             return dal.Delete(Id);
         }
    }
}
