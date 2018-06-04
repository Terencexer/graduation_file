using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using DtCms.DBUtility;
using System.Data.SqlClient;

namespace DtCms.DAL
{
    public class Programme
    {
        public bool Exists(string Id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from dt_Programme");
            strSql.Append(" where ProgrammeId= '" + Id + "'");
            SqlParameter[] parameters = {
					new SqlParameter("@ProgrammeId", SqlDbType.VarChar,100)};
            parameters[0].Value = Id;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }
        public bool PExists(string activityId, string pId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from dt_Programme");
            strSql.Append(" Where ActivityId='" + activityId + "' AND ProgrammeId='" + pId + "'");
            SqlParameter[] parameters = {
					new SqlParameter("@ProgrammeId", SqlDbType.VarChar,100)};
            parameters[0].Value = activityId;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }
        public int GetCount(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(*) as H ");
            strSql.Append(" from dt_Programme ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return Convert.ToInt32(DbHelperSQL.GetSingle(strSql.ToString()));
        }
        public int Add(DtCms.Model.Programme model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into dt_Programme(");
            strSql.Append("ActivityId,ProgrammeId,ProgrammeName)");
            strSql.Append(" values (");
            strSql.Append("@ActivityId,@ProgrammeId,@ProgrammeName)");

            SqlParameter[] parameters = {
					new SqlParameter("@ActivityId", SqlDbType.VarChar,100),
					new SqlParameter("@ProgrammeId", SqlDbType.VarChar,100),
					new SqlParameter("@ProgrammeName", SqlDbType.VarChar,100)};
					

            parameters[0].Value = model.ActivityId;
            parameters[1].Value = model.ProgrammeId;
            parameters[2].Value = model.ProgrammeName;
            

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
            strSql.Append("update dt_Programme set " + strValue);
            strSql.Append(" where ProgrammeId='" + Id + "'");
            DbHelperSQL.ExecuteSql(strSql.ToString());
        }
        public bool Update(DtCms.Model.Programme model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update dt_Programme set ");
            
            strSql.Append("ProgrammeName=@ProgrammeName");


            strSql.Append(" where ProgrammeId=@ProgrammeId");

            SqlParameter[] parameters = {
					new SqlParameter("@ActivityId", SqlDbType.VarChar,100),
					new SqlParameter("@ProgrammeId", SqlDbType.VarChar,100),
					new SqlParameter("@ProgrammeName", SqlDbType.VarChar,100),
					};
            parameters[0].Value = model.ActivityId;
            parameters[1].Value = model.ProgrammeId;
            parameters[2].Value = model.ProgrammeName;
           
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
            strSql.Append("delete from dt_Programme ");
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
        public DtCms.Model.Programme QueryOneRecord(string activityId,string pId)
        {
            DtCms.Model.Programme programme;


            string cmdstr = "Select * From dt_Programme Where ActivityId='" + activityId + "' AND ProgrammeId='" + pId+"'";
            SqlParameter[] SqlParam = new SqlParameter[1];
            SqlParam[0] = new SqlParameter("@ActivityId", activityId);

            //获取SqlDataReader对象
            SqlDataReader dataReader = DbHelperSQL.ExecuteReader(cmdstr, SqlParam);

            if (dataReader.Read())
            {

                programme = new DtCms.Model.Programme();

                programme.ActivityId = dataReader["ActivityId"].ToString();
                programme.ProgrammeId = dataReader["ProgrammeId"].ToString();
                programme.ProgrammeName = dataReader["ProgrammeName"].ToString();
            }
            else
                programme = null;
            dataReader.Close();


            return programme;
        }
    }

}
