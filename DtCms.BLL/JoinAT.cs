using System;
using System.Collections.Generic;
using System.Text;

namespace DtCms.BLL
{
    public class JoinAT
    { 
        private readonly DtCms.DAL.JoinAT dal = new DtCms.DAL.JoinAT();
        public JoinAT()
        { }
        public int Add(DtCms.Model.JoinAT model)
        {
            return dal.Add(model);
        }
        public bool Update(DtCms.Model.JoinAT model)
        {
            return dal.Update(model);
        }
        public DtCms.Model.JoinAT QueryOneRecord(string username, string team)
        {
            return dal.QueryOneRecord(username,team);
        }
        public void UpdateFieldTL(string username, string team, string strValue)
        {
            dal.UpdateFieldTL(username, team, strValue);

        }
        public void UpdateFieldTLMode(string username, string team, string strValue)
        {
            dal.UpdateFieldTLMode(username, team, strValue);

        }
    }
}
