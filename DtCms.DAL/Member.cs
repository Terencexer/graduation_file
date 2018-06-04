using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using DtCms.DBUtility;

namespace DtCms.DAL
{
    public partial class Member
    {
        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            return DbHelperSQL.GetMaxID("Id", "dt_Member");
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int Id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from dt_Member");
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
            strSql.Append(" from dt_Member ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return Convert.ToInt32(DbHelperSQL.GetSingle(strSql.ToString()));
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(DtCms.Model.Member model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into dt_Member(");
            strSql.Append("UserName,Pwd,TureName,UserTel,UserQQ,AddTime,Team,IsATMember)");
            strSql.Append(" values (");
            strSql.Append("@UserName,@Pwd,@TureName,@UserTel,@UserQQ,@AddTime,@Team,@IsATMember)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@UserName", SqlDbType.NVarChar,20),
                    new SqlParameter("@Pwd", SqlDbType.NVarChar,20),
                    new SqlParameter("@TureName", SqlDbType.NVarChar,20),
					new SqlParameter("@UserTel", SqlDbType.NVarChar,30),
					new SqlParameter("@UserQQ", SqlDbType.NVarChar,50),
					new SqlParameter("@AddTime", SqlDbType.DateTime),
                                        new SqlParameter("@Team", SqlDbType.NVarChar,50),
                                        new SqlParameter("@IsATMember", SqlDbType.NVarChar,10)};
            parameters[0].Value = model.Username;
            parameters[1].Value = model.Pwd;
            parameters[2].Value = model.Turename;
            parameters[3].Value = model.Usertel;
            parameters[4].Value = model.Userqq;
            parameters[5].Value = model.AddTime;
            parameters[6].Value = model.Team;
            parameters[7].Value = model.IsATMember;
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
            strSql.Append("update dt_Member set " + strValue);
            strSql.Append(" where Id=" + Id);
            DbHelperSQL.ExecuteSql(strSql.ToString());
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(DtCms.Model.Member model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update dt_Member set ");
            strSql.Append("UserName=@UserName,");
            strSql.Append("Pwd=@Pwd,");
            strSql.Append("TureName=@TureName,");
            strSql.Append("UserTel=@UserTel,");
            strSql.Append("UserQQ=@UserQQ,");
            strSql.Append("AddTime=@AddTime,");
            strSql.Append("Team=@Team,");
            strSql.Append("IsATMember=@IsATMember,");
            strSql.Append(" where Id=@Id");
            SqlParameter[] parameters = {
					new SqlParameter("@Id", SqlDbType.Int,4),
					new SqlParameter("@UserName", SqlDbType.NVarChar,20),
                    new SqlParameter("@Pwd", SqlDbType.NVarChar,20),
                    new SqlParameter("@TureName", SqlDbType.NVarChar,20),
					new SqlParameter("@UserTel", SqlDbType.NVarChar,30),
					new SqlParameter("@UserQQ", SqlDbType.NVarChar,50),
					new SqlParameter("@AddTime", SqlDbType.DateTime),
                                         new SqlParameter("@Team", SqlDbType.NVarChar,50),
                                        new SqlParameter("@IsATMember", SqlDbType.NVarChar,10)};
            parameters[0].Value = model.Id;
            parameters[1].Value = model.Username;
            parameters[2].Value = model.Pwd;
            parameters[3].Value = model.Turename;
            parameters[4].Value = model.Usertel;
            parameters[5].Value = model.Userqq;
            parameters[6].Value = model.AddTime;
            parameters[7].Value = model.Team;
            parameters[8].Value = model.IsATMember;

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
            strSql.Append("delete from dt_Member ");
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
            strSql.Append("delete from dt_Member ");
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
        public DtCms.Model.Member GetModel(int Id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 Id,UserName,Pwd,TureName,UserTel,UserQQ,AddTime,Team,IsATMember from dt_Member ");
            strSql.Append(" where Id=@Id");
            SqlParameter[] parameters = {
					new SqlParameter("@Id", SqlDbType.Int,4)
            };
            parameters[0].Value = Id;

            DtCms.Model.Member model = new DtCms.Model.Member();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["Id"].ToString() != "")
                {
                    model.Id = int.Parse(ds.Tables[0].Rows[0]["Id"].ToString());
                }
                model.Username = ds.Tables[0].Rows[0]["UserName"].ToString();
                model.Pwd = ds.Tables[0].Rows[0]["Pwd"].ToString();
                model.Turename = ds.Tables[0].Rows[0]["TureName"].ToString();
                model.Usertel = ds.Tables[0].Rows[0]["UserTel"].ToString();
                model.Userqq = ds.Tables[0].Rows[0]["UserQQ"].ToString();
                model.Team = ds.Tables[0].Rows[0]["Team"].ToString();
                model.IsATMember = ds.Tables[0].Rows[0]["IsATMember"].ToString();
                if (ds.Tables[0].Rows[0]["AddTime"].ToString() != "")
                {
                    model.AddTime = DateTime.Parse(ds.Tables[0].Rows[0]["AddTime"].ToString());
                }
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
            strSql.Append("select Id,UserName,Pwd,TureName,UserTel,UserQQ,AddTime,Team,IsATMember ");
            strSql.Append(" FROM dt_Member ");
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
            strSql.Append(" Id,UserName,Pwd,TureName,UserTel,UserQQ,AddTime,Team,IsATMember ");
            strSql.Append(" FROM dt_Member ");
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
            strSql.Append("select top " + pageSize + " Id,UserName,Pwd,TureName,UserTel,UserQQ,AddTime,Team,IsATMember from dt_Member ");
            strSql.Append(" where Id not in(select top " + topSize + " Id from dt_Member");
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
        public DtCms.Model.Member QueryOneRecord(string UserName)
        {
            DtCms.Model.Member member;


            string cmdstr = "Select * From dt_Member Where UserName='" + UserName + "'";
            SqlParameter[] SqlParam = new SqlParameter[1];
            SqlParam[0] = new SqlParameter("@UserName", UserName);

            //获取SqlDataReader对象
            SqlDataReader dataReader = DbHelperSQL.ExecuteReader(cmdstr, SqlParam);

            if (dataReader.Read())
            {

                member = new DtCms.Model.Member();

                member.Id = Convert.ToInt32(dataReader["Id"]);
                member.Username = dataReader["Username"].ToString();
                member.Turename = dataReader["Turename"].ToString();
                member.Team = dataReader["Team"].ToString();
                member.Usertel = dataReader["Usertel"].ToString(); ;
                member.IsATMember = dataReader["IsATMember"].ToString();
               
            }
            else
                member = null;
            dataReader.Close();


            return member;
        }
    
    }
}
