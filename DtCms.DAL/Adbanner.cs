using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using DtCms.DBUtility;
namespace DtCms.DAL
{
	/// <summary>
	/// 数据访问类:Adbanner
	/// </summary>
	public partial class Adbanner
	{
		public Adbanner()
		{}
		#region  Method

		/// <summary>
		/// 得到最大ID
		/// </summary>
        public int GetMaxId()
        {
            return DbHelperSQL.GetMaxID("id", "dt_Adbanner");
        }

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from dt_Adbanner");
			strSql.Append(" where id=@id ");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)};
			parameters[0].Value = id;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}

        /// <summary>
        /// 返回数据总数(分页用到)
        /// </summary>
        public int GetCount(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(*) as H ");
            strSql.Append(" from dt_Adbanner ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return Convert.ToInt32(DbHelperSQL.GetSingle(strSql.ToString()));
        }

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(DtCms.Model.Adbanner model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into dt_Adbanner(");
			strSql.Append("Aid,Title,StartTime,EndTime,AdUrl,LinkUrl,AdRemark,SortId,IsLock,AddTime)");
			strSql.Append(" values (");
			strSql.Append("@Aid,@Title,@StartTime,@EndTime,@AdUrl,@LinkUrl,@AdRemark,@SortId,@IsLock,@AddTime)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@Aid", SqlDbType.Int,4),
					new SqlParameter("@Title", SqlDbType.NVarChar,100),
					new SqlParameter("@StartTime", SqlDbType.DateTime),
					new SqlParameter("@EndTime", SqlDbType.DateTime),
					new SqlParameter("@AdUrl", SqlDbType.NVarChar,250),
					new SqlParameter("@LinkUrl", SqlDbType.NVarChar,250),
					new SqlParameter("@AdRemark", SqlDbType.NText),
					new SqlParameter("@SortId", SqlDbType.Int,4),
					new SqlParameter("@IsLock", SqlDbType.Int,4),
					new SqlParameter("@AddTime", SqlDbType.DateTime)};
			parameters[0].Value = model.Aid;
			parameters[1].Value = model.Title;
			parameters[2].Value = model.StartTime;
			parameters[3].Value = model.EndTime;
			parameters[4].Value = model.AdUrl;
			parameters[5].Value = model.LinkUrl;
			parameters[6].Value = model.AdRemark;
			parameters[7].Value = model.SortId;
			parameters[8].Value = model.IsLock;
			parameters[9].Value = model.AddTime;

			object obj = DbHelperSQL.GetSingle(strSql.ToString(),parameters);
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
		/// 更新一条数据
		/// </summary>
		public bool Update(DtCms.Model.Adbanner model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update dt_Adbanner set ");
			strSql.Append("Aid=@Aid,");
			strSql.Append("Title=@Title,");
			strSql.Append("StartTime=@StartTime,");
			strSql.Append("EndTime=@EndTime,");
			strSql.Append("AdUrl=@AdUrl,");
			strSql.Append("LinkUrl=@LinkUrl,");
			strSql.Append("AdRemark=@AdRemark,");
			strSql.Append("SortId=@SortId,");
			strSql.Append("IsLock=@IsLock");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4),
					new SqlParameter("@Aid", SqlDbType.Int,4),
					new SqlParameter("@Title", SqlDbType.NVarChar,100),
					new SqlParameter("@StartTime", SqlDbType.DateTime),
					new SqlParameter("@EndTime", SqlDbType.DateTime),
					new SqlParameter("@AdUrl", SqlDbType.NVarChar,250),
					new SqlParameter("@LinkUrl", SqlDbType.NVarChar,250),
					new SqlParameter("@AdRemark", SqlDbType.NText),
					new SqlParameter("@SortId", SqlDbType.Int,4),
					new SqlParameter("@IsLock", SqlDbType.Int,4)};
			parameters[0].Value = model.id;
			parameters[1].Value = model.Aid;
			parameters[2].Value = model.Title;
			parameters[3].Value = model.StartTime;
			parameters[4].Value = model.EndTime;
			parameters[5].Value = model.AdUrl;
			parameters[6].Value = model.LinkUrl;
			parameters[7].Value = model.AdRemark;
			parameters[8].Value = model.SortId;
			parameters[9].Value = model.IsLock;

			int rows=DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
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
		public bool Delete(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from dt_Adbanner ");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)
            };
			parameters[0].Value = id;

			int rows=DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
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
		public bool DeleteList(string idlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from dt_Adbanner ");
			strSql.Append(" where id in ("+idlist + ")  ");
			int rows=DbHelperSQL.ExecuteSql(strSql.ToString());
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
		public DtCms.Model.Adbanner GetModel(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select top 1 id,Aid,Title,StartTime,EndTime,AdUrl,LinkUrl,AdRemark,SortId,IsLock,AddTime from dt_Adbanner ");
			strSql.Append(" where id=@id");
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)
            };
			parameters[0].Value = id;

			DtCms.Model.Adbanner model=new DtCms.Model.Adbanner();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["id"].ToString()!="")
				{
					model.id=int.Parse(ds.Tables[0].Rows[0]["id"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Aid"].ToString()!="")
				{
					model.Aid=int.Parse(ds.Tables[0].Rows[0]["Aid"].ToString());
				}
				model.Title=ds.Tables[0].Rows[0]["Title"].ToString();
				if(ds.Tables[0].Rows[0]["StartTime"].ToString()!="")
				{
					model.StartTime=DateTime.Parse(ds.Tables[0].Rows[0]["StartTime"].ToString());
				}
				if(ds.Tables[0].Rows[0]["EndTime"].ToString()!="")
				{
					model.EndTime=DateTime.Parse(ds.Tables[0].Rows[0]["EndTime"].ToString());
				}
				model.AdUrl=ds.Tables[0].Rows[0]["AdUrl"].ToString();
				model.LinkUrl=ds.Tables[0].Rows[0]["LinkUrl"].ToString();
				model.AdRemark=ds.Tables[0].Rows[0]["AdRemark"].ToString();
				if(ds.Tables[0].Rows[0]["SortId"].ToString()!="")
				{
					model.SortId=int.Parse(ds.Tables[0].Rows[0]["SortId"].ToString());
				}
				if(ds.Tables[0].Rows[0]["IsLock"].ToString()!="")
				{
					model.IsLock=int.Parse(ds.Tables[0].Rows[0]["IsLock"].ToString());
				}
				if(ds.Tables[0].Rows[0]["AddTime"].ToString()!="")
				{
					model.AddTime=DateTime.Parse(ds.Tables[0].Rows[0]["AddTime"].ToString());
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
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select id,Aid,Title,StartTime,EndTime,AdUrl,LinkUrl,AdRemark,SortId,IsLock,AddTime ");
			strSql.Append(" FROM dt_Adbanner ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
            strSql.Append(" order by SortId asc,Id desc");
			return DbHelperSQL.Query(strSql.ToString());
		}

		/// <summary>
		/// 获得前几行数据
		/// </summary>
		public DataSet GetList(int Top,string strWhere,string filedOrder)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ");
			if(Top>0)
			{
				strSql.Append(" top "+Top.ToString());
			}
			strSql.Append(" Id,Aid,Title,StartTime,EndTime,AdUrl,LinkUrl,AdRemark,SortId,IsLock,AddTime ");
			strSql.Append(" FROM dt_Adbanner ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
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
            strSql.Append("select top " + pageSize + " Id,Aid,Title,StartTime,EndTime,AdUrl,LinkUrl,AdRemark,SortId,IsLock,AddTime from dt_Adbanner");
            strSql.Append(" where Id not in(select top " + topSize + " Id from dt_Adbanner");
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

		#endregion  Method
	}
}

