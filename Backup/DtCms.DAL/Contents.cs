using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using DtCms.DBUtility;
namespace DtCms.DAL
{
	/// <summary>
	/// 数据访问类:单页
	/// </summary>
	public partial class Contents
	{
		public Contents()
		{}
		#region  Method

		/// <summary>
		/// 得到最前的内容页
		/// </summary>
        public string GetCallIndex()
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select top 1 CallIndex from dt_Contents");
            strSql.Append(" order by SortId asc,Id desc");
            object obj = DbHelperSQL.GetSingle(strSql.ToString());
            if (obj != null)
            {
                return obj.ToString();
            }
            return null;
        }

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int Id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(0) from dt_Contents");
			strSql.Append(" where Id=@Id ");
			SqlParameter[] parameters = {
					new SqlParameter("@Id", SqlDbType.Int,4)};
			parameters[0].Value = Id;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string callIndex)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(0) from dt_Contents");
            strSql.Append(" where CallIndex=@CallIndex ");
            SqlParameter[] parameters = {
					new SqlParameter("@CallIndex", SqlDbType.NVarChar,50)};
            parameters[0].Value = callIndex;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 返回数据总数(分页用到)
        /// </summary>
        public int GetCount(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(*) as H ");
            strSql.Append(" from dt_Contents ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return Convert.ToInt32(DbHelperSQL.GetSingle(strSql.ToString()));
        }

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(DtCms.Model.Contents model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into dt_Contents(");
            strSql.Append("CallIndex,Title,ClassId,Content,SortId)");
			strSql.Append(" values (");
            strSql.Append("@CallIndex,@Title,@ClassId,@Content,@SortId)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
                    new SqlParameter("@CallIndex", SqlDbType.NVarChar,50),
					new SqlParameter("@Title", SqlDbType.NVarChar,100),
					new SqlParameter("@ClassId", SqlDbType.Int,4),
					new SqlParameter("@Content", SqlDbType.NText),
					new SqlParameter("@SortId", SqlDbType.Int,4)};
            parameters[0].Value = model.CallIndex;
			parameters[1].Value = model.Title;
			parameters[2].Value = model.ClassId;
			parameters[3].Value = model.Content;
			parameters[4].Value = model.SortId;

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
		public bool Update(DtCms.Model.Contents model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update dt_Contents set ");
            strSql.Append("CallIndex=@CallIndex,");
			strSql.Append("Title=@Title,");
			strSql.Append("ClassId=@ClassId,");
			strSql.Append("Content=@Content,");
			strSql.Append("SortId=@SortId");
			strSql.Append(" where Id=@Id");
			SqlParameter[] parameters = {
					new SqlParameter("@Id", SqlDbType.Int,4),
                    new SqlParameter("@CallIndex", SqlDbType.NVarChar,50),
					new SqlParameter("@Title", SqlDbType.NVarChar,100),
					new SqlParameter("@ClassId", SqlDbType.Int,4),
					new SqlParameter("@Content", SqlDbType.NText),
					new SqlParameter("@SortId", SqlDbType.Int,4)};
			parameters[0].Value = model.Id;
            parameters[1].Value = model.CallIndex;
			parameters[2].Value = model.Title;
			parameters[3].Value = model.ClassId;
			parameters[4].Value = model.Content;
			parameters[5].Value = model.SortId;

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
		public bool Delete(int Id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from dt_Contents ");
			strSql.Append(" where Id=@Id");
			SqlParameter[] parameters = {
					new SqlParameter("@Id", SqlDbType.Int,4)
        };
			parameters[0].Value = Id;

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
		/// 得到一个对象实体
		/// </summary>
		public DtCms.Model.Contents GetModel(int Id)
		{
			
			StringBuilder strSql=new StringBuilder();
            strSql.Append("select  top 1 Id,CallIndex,Title,ClassId,Content,SortId from dt_Contents ");
			strSql.Append(" where Id=@Id");
			SqlParameter[] parameters = {
					new SqlParameter("@Id", SqlDbType.Int,4)
            };
			parameters[0].Value = Id;

			DtCms.Model.Contents model=new DtCms.Model.Contents();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["Id"].ToString() != "")
                {
                    model.Id = int.Parse(ds.Tables[0].Rows[0]["Id"].ToString());
                }
                model.CallIndex = ds.Tables[0].Rows[0]["CallIndex"].ToString();
                model.Title = ds.Tables[0].Rows[0]["Title"].ToString();
                if (ds.Tables[0].Rows[0]["ClassId"].ToString() != "")
                {
                    model.ClassId = int.Parse(ds.Tables[0].Rows[0]["ClassId"].ToString());
                }
                model.Content = ds.Tables[0].Rows[0]["Content"].ToString();
                if (ds.Tables[0].Rows[0]["SortId"].ToString() != "")
                {
                    model.SortId = int.Parse(ds.Tables[0].Rows[0]["SortId"].ToString());
                }
                return model;
            }
            else
            {
                return null;
            }
		}

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public DtCms.Model.Contents GetModel(string callIndex)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 Id,CallIndex,Title,ClassId,Content,SortId from dt_Contents ");
            strSql.Append(" where CallIndex=@CallIndex");
            SqlParameter[] parameters = {
					new SqlParameter("@CallIndex", SqlDbType.NVarChar,50)
            };
            parameters[0].Value = callIndex;

            DtCms.Model.Contents model = new DtCms.Model.Contents();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["Id"].ToString() != "")
                {
                    model.Id = int.Parse(ds.Tables[0].Rows[0]["Id"].ToString());
                }
                model.CallIndex = ds.Tables[0].Rows[0]["CallIndex"].ToString();
                model.Title = ds.Tables[0].Rows[0]["Title"].ToString();
                if (ds.Tables[0].Rows[0]["ClassId"].ToString() != "")
                {
                    model.ClassId = int.Parse(ds.Tables[0].Rows[0]["ClassId"].ToString());
                }
                model.Content = ds.Tables[0].Rows[0]["Content"].ToString();
                if (ds.Tables[0].Rows[0]["SortId"].ToString() != "")
                {
                    model.SortId = int.Parse(ds.Tables[0].Rows[0]["SortId"].ToString());
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
            strSql.Append("select Id,CallIndex,Title,ClassId,Content,SortId ");
			strSql.Append(" FROM dt_Contents ");
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
            strSql.Append(" Id,CallIndex,Title,ClassId,Content,SortId ");
			strSql.Append(" FROM dt_Contents ");
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
            strSql.Append("select top " + pageSize + " Id,CallIndex,Title,ClassId,Content,SortId from dt_Contents");
            strSql.Append(" where Id not in(select top " + topSize + " Id from dt_Contents");
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

