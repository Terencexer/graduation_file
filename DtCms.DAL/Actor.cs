using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using DtCms.DBUtility;
using System.Data.SqlClient;

namespace DtCms.DAL
{
    public class Actor
    {
        public bool AcExists(string ProgrammeId, string UserName)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from dt_Actor");
            strSql.Append(" where ProgrammeId= '" + ProgrammeId + "'" + "AND UserName='" + UserName + "'");
            SqlParameter[] parameters = {
					new SqlParameter("@ProgrammeId",SqlDbType.VarChar,100)};
            parameters[0].Value = ProgrammeId;
            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }
        public int GetCount(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(*) as H ");
            strSql.Append(" from dt_Actor ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return Convert.ToInt32(DbHelperSQL.GetSingle(strSql.ToString()));
        }
        public int Add(DtCms.Model.Actor model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into dt_Actor(");
            strSql.Append("ActivityId,ProgrammeId,UserName,TureName,UserTel)");
            strSql.Append(" values (");
            strSql.Append("@ActivityId,@ProgrammeId,@UserName,@TureName,@UserTel)");

            SqlParameter[] parameters = {
					new SqlParameter("@ActivityId", SqlDbType.VarChar,100),
					new SqlParameter("@ProgrammeId", SqlDbType.VarChar,100),
					new SqlParameter("@UserName", SqlDbType.NVarChar,100),
					new SqlParameter("@TureName", SqlDbType.NVarChar,50),
					new SqlParameter("@UserTel", SqlDbType.NVarChar,50)};
					
            parameters[0].Value = model.ActivityId;
            parameters[1].Value = model.ProgrammeId;
            parameters[2].Value = model.UserName;
            parameters[3].Value = model.TureName;
            parameters[4].Value = model.UserTel;
           
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
        public void UpdateField(string Id, string strValue)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update dt_Actor set " + strValue);
            strSql.Append(" where ProgrammeId='" + Id + "'");
            DbHelperSQL.ExecuteSql(strSql.ToString());
        }
        public bool Update(DtCms.Model.Actor model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update dt_Actor set ");
            strSql.Append("ActivityId=@ActivityId,");
            strSql.Append("UserName=@UserName,");
            strSql.Append("TureName=@TureName,");
            strSql.Append("UserTel=@UserTel,");

            strSql.Append(" where ProgrammeId=@ProgrammeId");

            SqlParameter[] parameters = {
					new SqlParameter("@ActivityId", SqlDbType.VarChar,100),
					new SqlParameter("@ProgrammeId", SqlDbType.VarChar,100),
					new SqlParameter("@UserName", SqlDbType.NVarChar,100),
					new SqlParameter("@TureName", SqlDbType.NVarChar,50),
					new SqlParameter("@UserTel", SqlDbType.NVarChar,50)};
            parameters[0].Value = model.ActivityId;
            parameters[1].Value = model.ProgrammeId;
            parameters[2].Value = model.UserName;
            parameters[3].Value = model.TureName;
            parameters[4].Value = model.UserTel;
            int rows = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool Delete(string PId)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from dt_Actor ");
            strSql.Append(" where ProgrammeId='" + PId + "'");
            SqlParameter[] parameters = {
					new SqlParameter("@ProgrammeId", SqlDbType.VarChar,100)
            };
            parameters[0].Value = PId;

            int rows = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
