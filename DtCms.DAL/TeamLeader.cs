using System;
using System.Collections.Generic;
using System.Text;
using DtCms.DBUtility;
using System.Data.SqlClient;
using System.Data;

namespace DtCms.DAL
{
    public class TeamLeader
    {
        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            return DbHelperSQL.GetMaxID("Id", "dt_TeamLeader");
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int Id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from dt_TeamLeader");
            strSql.Append(" where Id=@Id ");
            SqlParameter[] parameters = {
					new SqlParameter("@Id", SqlDbType.Int,4)};
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
            strSql.Append(" from dt_TeamLeader ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return Convert.ToInt32(DbHelperSQL.GetSingle(strSql.ToString()));
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(DtCms.Model.TeamLeader model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into dt_TeamLeader(");
            strSql.Append("UserName,Pwd,TureName,Team,LeaderTel,SartTime,EndTime)");
            strSql.Append(" values (");
            strSql.Append("@UserName,@Pwd,@TureName,@Team,@LeaderTel,@StartTime,@EndTime)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@UserName", SqlDbType.VarChar,20),
                    new SqlParameter("@TureName", SqlDbType.VarChar,20),
                    new SqlParameter("@Team", SqlDbType.VarChar,20),
                    new SqlParameter("@Pwd", SqlDbType.VarChar,20),
					new SqlParameter("@LeaderTel", SqlDbType.NVarChar,50),
                    new SqlParameter("@StartTime", SqlDbType.DateTime),
					new SqlParameter("@EndTime", SqlDbType.DateTime)};
            parameters[0].Value = model.Username;
            parameters[1].Value = model.Turename;
            parameters[2].Value = model.Team;
            parameters[3].Value = model.Pwd;
            parameters[4].Value = model.LeaderTel;
            parameters[5].Value = model.StartTime;
            parameters[6].Value = model.EndTime;

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
        public void UpdateField(int Id, string strValue)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update dt_LeaderTeam set " + strValue);
            strSql.Append(" where Id=" + Id);
            DbHelperSQL.ExecuteSql(strSql.ToString());
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(DtCms.Model.TeamLeader model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update dt_LeaderTeam set ");
            strSql.Append("UserName=@UserName,");
            strSql.Append("TureName=@TureName,");
            strSql.Append("Team=@Team,");
            strSql.Append("Pwd=@Pwd,");
            strSql.Append("LeaderTel=@LeaderTel,");
            strSql.Append("StartTime=@StartTime,");
            strSql.Append("EndTime=@EndTime,");
            strSql.Append(" where Id=@Id");
            SqlParameter[] parameters = {
					new SqlParameter("@Id", SqlDbType.Int),
					new SqlParameter("@UserName", SqlDbType.VarChar,20),
                    new SqlParameter("@TureName", SqlDbType.VarChar,20),
                    new SqlParameter("@Team", SqlDbType.VarChar,20),
                    new SqlParameter("@Pwd", SqlDbType.VarChar,20),
					new SqlParameter("@LeaderTel", SqlDbType.NVarChar,50),
                    new SqlParameter("@StartTime", SqlDbType.DateTime),
					new SqlParameter("@EndTime", SqlDbType.DateTime)};
            parameters[0].Value = model.Id;
            parameters[1].Value = model.Username;
            parameters[2].Value = model.Turename;
            parameters[3].Value = model.Team;
            parameters[4].Value = model.Pwd;
            parameters[5].Value = model.LeaderTel;
            parameters[6].Value = model.StartTime;
            parameters[7].Value = model.EndTime;

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
        public bool Delete(int Id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from dt_TeamLeader ");
            strSql.Append(" where Id=@Id");
            SqlParameter[] parameters = {
					new SqlParameter("@Id", SqlDbType.Int,4)
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
            strSql.Append("delete from dt_TeamLeader ");
            strSql.Append(" where Id in (" + Idlist + ")  ");
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
        /// 得到一个对象实体
        /// </summary>
        public DtCms.Model.TeamLeader GetModel(int Id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 Id,UserName,TureName,Team,Pwd,LeaderTel,StartTime,EndTime from dt_TeamLeader ");
            strSql.Append(" where Id=@Id");
            SqlParameter[] parameters = {
					new SqlParameter("@Id", SqlDbType.Int,4)
            };
            parameters[0].Value = Id;

            DtCms.Model.TeamLeader model = new DtCms.Model.TeamLeader();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["Id"].ToString() != "")
                {
                    model.Id = int.Parse(ds.Tables[0].Rows[0]["Id"].ToString());
                }
                model.Username = ds.Tables[0].Rows[0]["UserName"].ToString();
                model.Turename = ds.Tables[0].Rows[0]["TureName"].ToString();
                model.Team = ds.Tables[0].Rows[0]["Team"].ToString();
                model.Pwd = ds.Tables[0].Rows[0]["Pwd"].ToString();
                model.StartTime = DateTime.Parse(ds.Tables[0].Rows[0]["StartTime"].ToString());
                model.EndTime = DateTime.Parse(ds.Tables[0].Rows[0]["EndTime"].ToString());
                return model;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select Id,UserName,TureName,Team,Pwd,LeaderTel,StartTime,EndTime from dt_TeamLeader ");
            strSql.Append(" FROM dt_TeamLeader ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public DataSet GetList(int Top, string strWhere, string filedOrder)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");
            if (Top > 0)
            {
                strSql.Append(" top " + Top.ToString());
            }
            strSql.Append(" Id,UserName,TureName,Team,Pwd,LeaderTel,StartTime,EndTime from dt_TeamLeader ");
            strSql.Append(" FROM dt_TeamLeader ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by " + filedOrder);
            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 获得查询分页数据
        /// </summary>
        public DataSet GetPageList(int pageSize, int currentPage, string strWhere, string filedOrder)
        {
            int topSize = pageSize * currentPage;
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select top " + pageSize + " Id,UserName,Pwd,TureName,UserTel,UserQQ,AddTime from dt_TeamLeader ");
            strSql.Append(" where Id not in(select top " + topSize + " Id from dt_TeamLeader");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by " + filedOrder + ")");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" and " + strWhere);
            }
            strSql.Append(" order by " + filedOrder);

            return DbHelperSQL.Query(strSql.ToString());
        }
    }
}
