using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using DtCms.DBUtility;

namespace DtCms.DAL
{
    public class Activity
    {
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string Id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from dt_TacvitityApply");
            strSql.Append(" where ActivityId= '" + Id + "'");
            SqlParameter[] parameters = {
					new SqlParameter("@ActivityId", SqlDbType.VarChar,20)};
            parameters[0].Value = Id;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 返回数据总数(分页用到)
        /// </summary>
        public int GetCount(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(*) as H ");
            strSql.Append(" from dt_TacvitityApply ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return Convert.ToInt32(DbHelperSQL.GetSingle(strSql.ToString()));
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(DtCms.Model.Activity model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into dt_TacvitityApply(");
            strSql.Append("ActivityId,Applicant,Title,Budget,ATime,AConten,Place,AddTime,CheckStatus,Preparation,Middle,LastPre,TicketNum,TicketType)");
            strSql.Append(" values (");
            strSql.Append("@ActivityId,@Applicant,@Title,@Budget,@ATime,@AConten,@Place,@AddTime,@CheckStatus,@Preparation,@Middle,@LastPre,@TicketNum,@TicketType)");

            SqlParameter[] parameters = {
					new SqlParameter("@ActivityId", SqlDbType.VarChar,20),
					new SqlParameter("@Applicant", SqlDbType.NVarChar,20),
					new SqlParameter("@Title", SqlDbType.NVarChar,50),
					new SqlParameter("@Budget", SqlDbType.Int),
					new SqlParameter("@ATime", SqlDbType.DateTime),
					new SqlParameter("@AConten", SqlDbType.NText),
					new SqlParameter("@Place", SqlDbType.NVarChar,50),
				
					new SqlParameter("@AddTime", SqlDbType.DateTime),
                   new SqlParameter("@CheckStatus", SqlDbType.NVarChar,100),
                    new SqlParameter("@Preparation", SqlDbType.NText),
                    new SqlParameter("@Middle", SqlDbType.NText),
                    new SqlParameter("@LastPre", SqlDbType.NText),
                    new SqlParameter("@TicketNum", SqlDbType.Int),
                    new SqlParameter("@TicketType", SqlDbType.NVarChar,50)};
            parameters[0].Value = model.ActivityId;
            parameters[1].Value = model.Applicant;
            parameters[2].Value = model.Title;
            parameters[3].Value = model.Budget;
            parameters[4].Value = model.ATime;
            parameters[5].Value = model.AConten;
            parameters[6].Value = model.Place;
            parameters[7].Value = model.AddTime;
            parameters[8].Value = model.CheckStatus;
            parameters[9].Value = model.Preparation;
            parameters[10].Value = model.Middle;
            parameters[11].Value = model.LastPre;
            parameters[12].Value = model.TicketNum;
            parameters[13].Value = model.TicketType;


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

        /// <summary>
        /// 更新一列数据
        /// </summary>
        public void UpdateField(string Id, string strValue)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update dt_TacvitityApply set " + strValue);
            strSql.Append(" where ActivityId='" + Id + "'");
            DbHelperSQL.ExecuteSql(strSql.ToString());
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(DtCms.Model.Activity model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into dt_TacvitityApply(");
            strSql.Append("ActivityId,Applicant,Title,Budget,ATime,AConten,Place,AddTime,CheckStatus,Preparation,Middle,LastPre,TicketNum,TicketType)");
            strSql.Append(" values (");
            strSql.Append("@ActivityId,@Applicant,@Title,@Budget,@ATime,@AConten,@Place,@AddTime,@CheckStatus,@Preparation,@Middle,@LastPre,@TicketNum,@TicketType)");

            SqlParameter[] parameters = {
					new SqlParameter("@ActivityId", SqlDbType.NVarChar,20),
					new SqlParameter("@Applicant", SqlDbType.NVarChar,20),
					new SqlParameter("@Title", SqlDbType.NVarChar,50),
					new SqlParameter("@Budget", SqlDbType.Int),
					new SqlParameter("@ATime", SqlDbType.DateTime),
					new SqlParameter("@AConten", SqlDbType.NText),
					new SqlParameter("@Place", SqlDbType.NVarChar,50),
					
					new SqlParameter("@AddTime", SqlDbType.DateTime),
                   new SqlParameter("@CheckStatus", SqlDbType.NVarChar,100),
                    new SqlParameter("@Preparation", SqlDbType.NText),
                    new SqlParameter("@Middle", SqlDbType.NText),
                    new SqlParameter("@LastPre", SqlDbType.NText),
                    new SqlParameter("@TicketNum", SqlDbType.Int),
                    new SqlParameter("@TicketType", SqlDbType.NVarChar,50)};
            parameters[0].Value = model.ActivityId;
            parameters[1].Value = model.Applicant;
            parameters[2].Value = model.Title;
            parameters[3].Value = model.Budget;
            parameters[4].Value = model.ATime;
            parameters[5].Value = model.AConten;
            parameters[6].Value = model.Place;

            parameters[7].Value = model.AddTime;
            parameters[8].Value = model.CheckStatus;
            parameters[9].Value = model.Preparation;
            parameters[10].Value = model.Middle;
            parameters[11].Value = model.LastPre;
            parameters[12].Value = model.TicketNum;
            parameters[13].Value = model.TicketType;

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

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(string Id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from dt_TacvitityApply ");
            strSql.Append(" where ActivityId='" + Id + "'");
            SqlParameter[] parameters = {
					new SqlParameter("@Id", SqlDbType.VarChar,20)
            };
            parameters[0].Value = Id;

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

        /// <summary>
        /// 删除多条数据
        /// </summary>
        public bool DeleteList(string Idlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from dt_TacvitityApply ");
            strSql.Append(" where ActivityId in (" + Idlist + ")  ");
            int rows = DbHelperSQL.ExecuteSql(strSql.ToString());
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ActivityId,Applicant,Title,Budget,ATime,AConten,Place,AddTime,CheckStatus,Preparation,Middle,LastPre,TicketNum,TicketType ");
            strSql.Append(" FROM dt_TacvitityApply ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }
        public void UpdateOneRecordAuditStatus(string ActivityId, string strValue)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update dt_TacvitityApply set CheckStatus='" + strValue + "'");
            strSql.Append(" where ActivityId='" + ActivityId + "'");
            DbHelperSQL.ExecuteSql(strSql.ToString());
        }
        public DtCms.Model.Activity QueryOneRecord(string activityId)
        {
            DtCms.Model.Activity activity;


            string cmdstr = "Select * From dt_TacvitityApply Where ActivityId='" + activityId + "'";
            SqlParameter[] SqlParam = new SqlParameter[1];
            SqlParam[0] = new SqlParameter("@ActivityId", activityId);

            //获取SqlDataReader对象
            SqlDataReader dataReader = DbHelperSQL.ExecuteReader(cmdstr, SqlParam);

            if (dataReader.Read())
            {
                activity = new DtCms.Model.Activity();

                activity.ActivityId = dataReader["ActivityId"].ToString();
                activity.Applicant = dataReader["Applicant"].ToString();
                activity.Title = dataReader["Title"].ToString();
                activity.Budget = Convert.ToInt32(dataReader["Budget"]);

                activity.ATime = Convert.ToDateTime(dataReader["ATime"].ToString());
                activity.AddTime = Convert.ToDateTime(dataReader["AddTime"].ToString());
                activity.AConten = dataReader["AConten"].ToString();
                activity.Place = dataReader["Place"].ToString();
                activity.CheckStatus = dataReader["CheckStatus"].ToString();
                activity.Preparation = dataReader["Preparation"].ToString();
                activity.Middle = dataReader["Middle"].ToString();
                activity.LastPre = dataReader["LastPre"].ToString();
                activity.TicketNum = Convert.ToInt32(dataReader["TicketNum"]);

                activity.TicketType = dataReader["TicketType"].ToString();
            }
            else
                activity = null;
            dataReader.Close();


            return activity;
        }
    }
}
