using System;
using System.Collections.Generic;
using System.Text;

namespace DtCms.BLL
{
    public class JoinActivity
    {
        private readonly DtCms.DAL.JoinActivity dal = new DtCms.DAL.JoinActivity();
        public JoinActivity()
        { }
        public int GetCount(string ActivityID)
        {
            return dal.GetCount(ActivityID);
        }
        public bool AcExists(string ActivityID, string UserName)
        {
            return dal.AcExists(ActivityID, UserName);
        }
       
            public int Add(DtCms.Model.JoinActivity model)
        {
            return dal.Add(model);
        }
    }
}
