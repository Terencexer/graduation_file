using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using DtCms.DBUtility;
using System.Data.SqlClient;

namespace DtCms.DAL
{
    public class JoinAT
    {
        
        public int Add(DtCms.Model.JoinAT model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into dt_JoinAT(");
            strSql.Append("UserName,SelfIntro,Reward,TLCheckMode,TLAdvice,AdminCheckMode,AdminAdvice,Team,JoinReason)");
            strSql.Append(" values (");
            strSql.Append("@UserName,@SelfIntro,@Reward,@TLCheckMode,@TLAdvice,@AdminCheckMode,@AdminAdvice,@Team,@JoinReason)");

            SqlParameter[] parameters = {
					new SqlParameter("@UserName", SqlDbType.NVarChar,50),
					new SqlParameter("@SelfIntro", SqlDbType.NText),
					new SqlParameter("@Reward", SqlDbType.NText),
					new SqlParameter("@TLCheckMode", SqlDbType.NVarChar,50),
					new SqlParameter("@TLAdvice", SqlDbType.NText),
                    new SqlParameter("@AdminCheckMode", SqlDbType.NVarChar,50),
					new SqlParameter("@AdminAdvice", SqlDbType.NText),
                    new SqlParameter("@Team", SqlDbType.NVarChar,50),
                    new SqlParameter("@JoinReason", SqlDbType.NText)
           };
            parameters[0].Value = model.UserName;
            parameters[1].Value = model.SelfIntro;
            parameters[2].Value = model.Reward;

            parameters[3].Value = model.TLCheckMode;
            parameters[4].Value = model.TLAdvice;
            parameters[5].Value = model.AdminCheckMode;
            parameters[6].Value = model.AdminAdvice;
             parameters[7].Value = model.Team;
             parameters[8].Value = model.JoinReason;

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
        public bool Update(DtCms.Model.JoinAT model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update dt_JoinAT set ");
            
            strSql.Append("SelfIntro=@SelfIntro,");
            strSql.Append("Reward=@Reward,");
            strSql.Append("TLCheckMode=@TLCheckMode,");
            strSql.Append("TLAdvice=@TLAdvice,");
            strSql.Append("AdminCheckMode=@AdminCheckMode,");
            strSql.Append("AdminAdvice=@AdminAdvice,");
            strSql.Append("Team=@Team,");
            strSql.Append("JoinReason=@JoinReason,");
            strSql.Append(" where UserName=@UserName");
             SqlParameter[] parameters = {
					new SqlParameter("@UserName", SqlDbType.NVarChar,50),
					new SqlParameter("@SelfIntro", SqlDbType.NText),
					new SqlParameter("@Reward", SqlDbType.NText),
					new SqlParameter("@TLCheckMode", SqlDbType.NVarChar,50),
					new SqlParameter("@TLAdvice", SqlDbType.NText),
                    new SqlParameter("@AdminCheckMode", SqlDbType.NVarChar,50),
					new SqlParameter("@AdminAdvice", SqlDbType.NText),
                    new SqlParameter("@Team", SqlDbType.NVarChar,50),
                    new SqlParameter("@JoinReason", SqlDbType.NText)
                    
           };
            parameters[0].Value = model.UserName;
            parameters[1].Value = model.SelfIntro;
            parameters[2].Value = model.Reward;

            parameters[3].Value = model.TLCheckMode;
            parameters[4].Value = model.TLAdvice;
            parameters[5].Value = model.AdminCheckMode;
            parameters[6].Value = model.AdminAdvice;
             parameters[7].Value = model.Team;
             parameters[8].Value = model.JoinReason;
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
        public void UpdateFieldTL(string username, string team, string strValue)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update dt_JoinAT set TLAdvice='" + strValue+"'");
            strSql.Append(" where UserName='" + username + "' AND Team" + team + "'");
            DbHelperSQL.ExecuteSql(strSql.ToString());
        }
        public void UpdateFieldTLMode(string username, string team, string strValue)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update dt_JoinAT set TLCheckMode='" + strValue + "'");
            strSql.Append(" where UserName='" + username + "' AND Team" + team + "'");
            DbHelperSQL.ExecuteSql(strSql.ToString());
        }

        public DtCms.Model.JoinAT QueryOneRecord(string username,string team)
        {
            DtCms.Model.JoinAT joinAT;


            string cmdstr = "Select * From dt_JoinAT Where UserName='" + username + "' AND Team='" + team + "'";
            SqlParameter[] SqlParam = new SqlParameter[1];
            SqlParam[0] = new SqlParameter("@UserName", username);

            //获取SqlDataReader对象
            SqlDataReader dataReader = DbHelperSQL.ExecuteReader(cmdstr, SqlParam);

            if (dataReader.Read())
            {
                joinAT = new DtCms.Model.JoinAT();

                joinAT.UserName = dataReader["UserName"].ToString();
                joinAT.SelfIntro = dataReader["SelfIntro"].ToString();
                joinAT.Reward = dataReader["Reward"].ToString();
                joinAT.TLCheckMode = dataReader["TLCheckMode"].ToString();
                joinAT.TLAdvice = dataReader["TLAdvice"].ToString();
                joinAT.AdminCheckMode = dataReader["AdminCheckMode"].ToString();
                joinAT.AdminAdvice = dataReader["AdminAdvice"].ToString();
                joinAT.Team = dataReader["Team"].ToString();
                joinAT.JoinReason = dataReader["JoinReason"].ToString();
            }
            else
                joinAT = null;
            dataReader.Close();


            return joinAT;
        }
       
    }
}
