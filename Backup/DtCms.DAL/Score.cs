using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using DtCms.DBUtility;
using System.Data.SqlClient;

namespace DtCms.DAL
{
    public class Score
    {
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(DtCms.Model.Score model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into dt_Score(");
            strSql.Append("Quality,Number,Atmosphere,Activities,SocietiesName,AddTime)");
            strSql.Append(" values (");
            strSql.Append("@Quality,@Number,@Atmosphere,@Activities,@SocietiesName,@AddTime)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@Quality", SqlDbType.Int),
                    new SqlParameter("@Number", SqlDbType.Int),
                    new SqlParameter("@Atmosphere", SqlDbType.Int),
                    new SqlParameter("@Activities", SqlDbType.Int),
                    new SqlParameter("@SocietiesName", SqlDbType.VarChar),
					new SqlParameter("@AddTime", SqlDbType.DateTime)};
            parameters[0].Value = model.Quality;
            parameters[1].Value = model.Number;
            parameters[2].Value = model.Atmosphere;
            parameters[3].Value = model.Activities;
            parameters[4].Value = model.SocietiesName;
            parameters[5].Value = model.AddTime;

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
        /// 返回数据总数(分页用到)
        /// </summary>
        public int GetCount(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(DISTINCT SocietiesName) as H ");
            strSql.Append(" from dt_Score ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return Convert.ToInt32(DbHelperSQL.GetSingle(strSql.ToString()));
        }

        /// <summary>
        /// 获得查询分页数据
        /// </summary>
        public DataSet GetPageList(int pageSize, int currentPage, string strWhere, string filedOrder)
        {
            int topSize = pageSize * currentPage;
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select top " + pageSize + " sum(Quality) Quality,sum(Number) Number,sum(Atmosphere) Atmosphere,sum(Activities) Activities,SocietiesName from dt_Score ");
            strSql.Append(" where Id not in(select top " + topSize + " Id from dt_Score");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by " + filedOrder + ")");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" and " + strWhere);
            }
            strSql.Append(" group by SocietiesName order by sum(Quality)*2+sum(Number)+sum(Atmosphere)+sum(Activities) desc ");

            return DbHelperSQL.Query(strSql.ToString());
        }
    }
}
