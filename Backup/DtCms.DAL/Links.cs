using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using DtCms.DBUtility;
namespace DtCms.DAL
{
	/// <summary>
	/// 数据访问类:链接
	/// </summary>
	public partial class Links
	{
		public Links()
		{}
		#region  Method

		/// <summary>
		/// 得到最大ID
		/// </summary>
        public int GetMaxId()
        {
            return DbHelperSQL.GetMaxID("Id", "dt_Links");
        }

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int Id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from dt_Links");
			strSql.Append(" where Id=@Id ");
			SqlParameter[] parameters = {
					new SqlParameter("@Id", SqlDbType.Int,4)};
			parameters[0].Value = Id;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}

        /// <summary>
        /// 返回数据总数(分页用到)
        /// </summary>
        public int GetCount(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(*) as H ");
            strSql.Append(" from dt_Links ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return Convert.ToInt32(DbHelperSQL.GetSingle(strSql.ToString()));
        }

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(DtCms.Model.Links model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into dt_Links(");
			strSql.Append("Title,UserName,UserTel,UserMail,WebUrl,ImgUrl,IsImage,SortId,IsRed,IsLock,AddTime)");
			strSql.Append(" values (");
			strSql.Append("@Title,@UserName,@UserTel,@UserMail,@WebUrl,@ImgUrl,@IsImage,@SortId,@IsRed,@IsLock,@AddTime)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@Title", SqlDbType.NVarChar,50),
					new SqlParameter("@UserName", SqlDbType.NVarChar,20),
					new SqlParameter("@UserTel", SqlDbType.NVarChar,30),
					new SqlParameter("@UserMail", SqlDbType.NVarChar,50),
					new SqlParameter("@WebUrl", SqlDbType.NVarChar,250),
					new SqlParameter("@ImgUrl", SqlDbType.NVarChar,250),
					new SqlParameter("@IsImage", SqlDbType.Int,4),
					new SqlParameter("@SortId", SqlDbType.Int,4),
					new SqlParameter("@IsRed", SqlDbType.Int,4),
					new SqlParameter("@IsLock", SqlDbType.Int,4),
					new SqlParameter("@AddTime", SqlDbType.DateTime)};
			parameters[0].Value = model.Title;
			parameters[1].Value = model.UserName;
			parameters[2].Value = model.UserTel;
			parameters[3].Value = model.UserMail;
			parameters[4].Value = model.WebUrl;
			parameters[5].Value = model.ImgUrl;
			parameters[6].Value = model.IsImage;
			parameters[7].Value = model.SortId;
			parameters[8].Value = model.IsRed;
			parameters[9].Value = model.IsLock;
			parameters[10].Value = model.AddTime;

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
        /// 修改一列数据
        /// </summary>
        public void UpdateField(int Id, string strValue)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update dt_Links set " + strValue);
            strSql.Append(" where Id=" + Id);
            DbHelperSQL.ExecuteSql(strSql.ToString());
        }

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(DtCms.Model.Links model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update dt_Links set ");
			strSql.Append("Title=@Title,");
			strSql.Append("UserName=@UserName,");
			strSql.Append("UserTel=@UserTel,");
			strSql.Append("UserMail=@UserMail,");
			strSql.Append("WebUrl=@WebUrl,");
			strSql.Append("ImgUrl=@ImgUrl,");
			strSql.Append("IsImage=@IsImage,");
			strSql.Append("SortId=@SortId,");
			strSql.Append("IsRed=@IsRed,");
			strSql.Append("IsLock=@IsLock,");
			strSql.Append("AddTime=@AddTime");
			strSql.Append(" where Id=@Id");
			SqlParameter[] parameters = {
					new SqlParameter("@Id", SqlDbType.Int,4),
					new SqlParameter("@Title", SqlDbType.NVarChar,50),
					new SqlParameter("@UserName", SqlDbType.NVarChar,20),
					new SqlParameter("@UserTel", SqlDbType.NVarChar,30),
					new SqlParameter("@UserMail", SqlDbType.NVarChar,50),
					new SqlParameter("@WebUrl", SqlDbType.NVarChar,250),
					new SqlParameter("@ImgUrl", SqlDbType.NVarChar,250),
					new SqlParameter("@IsImage", SqlDbType.Int,4),
					new SqlParameter("@SortId", SqlDbType.Int,4),
					new SqlParameter("@IsRed", SqlDbType.Int,4),
					new SqlParameter("@IsLock", SqlDbType.Int,4),
					new SqlParameter("@AddTime", SqlDbType.DateTime)};
			parameters[0].Value = model.Id;
			parameters[1].Value = model.Title;
			parameters[2].Value = model.UserName;
			parameters[3].Value = model.UserTel;
			parameters[4].Value = model.UserMail;
			parameters[5].Value = model.WebUrl;
			parameters[6].Value = model.ImgUrl;
			parameters[7].Value = model.IsImage;
			parameters[8].Value = model.SortId;
			parameters[9].Value = model.IsRed;
			parameters[10].Value = model.IsLock;
			parameters[11].Value = model.AddTime;

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
			strSql.Append("delete from dt_Links ");
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
		public DtCms.Model.Links GetModel(int Id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 Id,Title,UserName,UserTel,UserMail,WebUrl,ImgUrl,IsImage,SortId,IsRed,IsLock,AddTime from dt_Links ");
			strSql.Append(" where Id=@Id");
			SqlParameter[] parameters = {
					new SqlParameter("@Id", SqlDbType.Int,4)
};
			parameters[0].Value = Id;

			DtCms.Model.Links model=new DtCms.Model.Links();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["Id"].ToString()!="")
				{
					model.Id=int.Parse(ds.Tables[0].Rows[0]["Id"].ToString());
				}
				model.Title=ds.Tables[0].Rows[0]["Title"].ToString();
				model.UserName=ds.Tables[0].Rows[0]["UserName"].ToString();
				model.UserTel=ds.Tables[0].Rows[0]["UserTel"].ToString();
				model.UserMail=ds.Tables[0].Rows[0]["UserMail"].ToString();
				model.WebUrl=ds.Tables[0].Rows[0]["WebUrl"].ToString();
				model.ImgUrl=ds.Tables[0].Rows[0]["ImgUrl"].ToString();
				if(ds.Tables[0].Rows[0]["IsImage"].ToString()!="")
				{
					model.IsImage=int.Parse(ds.Tables[0].Rows[0]["IsImage"].ToString());
				}
				if(ds.Tables[0].Rows[0]["SortId"].ToString()!="")
				{
					model.SortId=int.Parse(ds.Tables[0].Rows[0]["SortId"].ToString());
				}
				if(ds.Tables[0].Rows[0]["IsRed"].ToString()!="")
				{
					model.IsRed=int.Parse(ds.Tables[0].Rows[0]["IsRed"].ToString());
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
			strSql.Append("select Id,Title,UserName,UserTel,UserMail,WebUrl,ImgUrl,IsImage,SortId,IsRed,IsLock,AddTime ");
			strSql.Append(" FROM dt_Links ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
            strSql.Append(" order by SortId asc,AddTime desc");
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
			strSql.Append(" Id,Title,UserName,UserTel,UserMail,WebUrl,ImgUrl,IsImage,SortId,IsRed,IsLock,AddTime ");
			strSql.Append(" FROM dt_Links ");
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
            strSql.Append("select top " + pageSize + " Id,Title,UserName,UserTel,UserMail,WebUrl,ImgUrl,IsImage,SortId,IsRed,IsLock,AddTime from dt_Links");
            strSql.Append(" where Id not in(select top " + topSize + " Id from dt_Links");
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

