using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using DtCms.DBUtility;
using System.Data.SqlClient;

namespace DtCms.DAL
{
    public class JoinActivity
    {
        public int GetCount(string ActivityID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(*) as H ");
            strSql.Append(" from dt_JoinActivity ");
            if (ActivityID.Trim() != "")
            {
                strSql.Append(" where ActivityID='" + ActivityID+"'");
            }
            return Convert.ToInt32(DbHelperSQL.GetSingle(strSql.ToString()));
        }
         public bool AcExists(string ActivityID,string UserName)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from dt_JoinActivity");
            strSql.Append(" where ActivityID= '" + ActivityID + "'" + "AND UserName='" + UserName+"'");
            SqlParameter[] parameters = {
					new SqlParameter("@ActivityID", SqlDbType.VarChar,50)};
            parameters[0].Value = ActivityID;
           

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }
         public int Add(DtCms.Model.JoinActivity model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into dt_JoinActivity(");
            strSql.Append("ActivityId,UserName,UserTel,TicketType)");
            strSql.Append(" values (");
            strSql.Append("@ActivityId,@UserName,@UserTel,@TicketType)");

            SqlParameter[] parameters = {
					new SqlParameter("@ActivityId", SqlDbType.VarChar,50),
					new SqlParameter("@UserName", SqlDbType.NVarChar,50),
					new SqlParameter("@UserTel", SqlDbType.NVarChar,50),
					
					
					new SqlParameter("@TicketType", SqlDbType.NVarChar,50)
                    
           };
                   parameters[0].Value = model.ActivityId;
                   parameters[1].Value = model.UserName;
            parameters[2].Value = model.UserTel;
            
            parameters[3].Value = model.TicketType;
           
            object obj = DbHelperSQL.GetSingle(strSql.ToString(), parameters);
            if (obj == null)
            {
                return 0;
            }
            else
            {
                return Convert.ToInt32(obj);
            }
        }
    }
}
