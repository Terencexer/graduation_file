using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using DtCms.DBUtility;
namespace DtCms.DAL
{
	/// <summary>
	/// 数据访问类:管理员
	/// </summary>
	public partial class Administrator
	{
		public Administrator()
		{}
		#region  Method

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("Id", "dt_Administrator"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int Id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from dt_Administrator");
			strSql.Append(" where Id=@Id ");
			SqlParameter[] parameters = {
					new SqlParameter("@Id", SqlDbType.Int,4)};
			parameters[0].Value = Id;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}

        /// <summary>
        /// 检查用户名是否重复
        /// </summary>
        /// <param name="UserName"></param>
        /// <returns></returns>
        public bool Exists(string UserName)
        {
            string strSql = "select count(*) from dt_Administrator where UserName=@UserName";
            SqlParameter[] parameters = {
                new SqlParameter("@UserName",SqlDbType.NVarChar,30)};
            parameters[0].Value = UserName;
            return DbHelperSQL.Exists(strSql, parameters);
        }

        /// <summary>
        /// 检查登录用户
        /// </summary>
        /// <param name="UserName"></param>
        /// <param name="UserPwd"></param>
        /// <returns></returns>
        public bool chkAdminLogin(string UserName, string UserPwd)
        {
            string strSql = "select count(*) from dt_Administrator where UserName=@UserName and UserPwd=@UserPwd and isLock=0";
            SqlParameter[] parameters = {
                new SqlParameter("@UserName",SqlDbType.NVarChar,30),
                new SqlParameter("@UserPwd", SqlDbType.NVarChar,50)};
            parameters[0].Value = UserName;
            parameters[1].Value = UserPwd;
            return DbHelperSQL.Exists(strSql, parameters);
        }

        /// <summary>
        /// 返回数据总数(分页用到)
        /// </summary>
        public int GetCount(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(*) as H ");
            strSql.Append(" from dt_Administrator ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return Convert.ToInt32(DbHelperSQL.GetSingle(strSql.ToString()));
        }

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(DtCms.Model.Administrator model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into dt_Administrator(");
			strSql.Append("UserName,UserPwd,ReadName,UserEmail,UserType,UserLevel,IsLock,AddTime)");
			strSql.Append(" values (");
			strSql.Append("@UserName,@UserPwd,@ReadName,@UserEmail,@UserType,@UserLevel,@IsLock,@AddTime)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@UserName", SqlDbType.NVarChar,30),
					new SqlParameter("@UserPwd", SqlDbType.NVarChar,50),
					new SqlParameter("@ReadName", SqlDbType.NVarChar,30),
					new SqlParameter("@UserEmail", SqlDbType.NVarChar,30),
					new SqlParameter("@UserType", SqlDbType.Int,4),
					new SqlParameter("@UserLevel", SqlDbType.NText),
					new SqlParameter("@IsLock", SqlDbType.Int,4),
					new SqlParameter("@AddTime", SqlDbType.DateTime)};
			parameters[0].Value = model.UserName;
			parameters[1].Value = model.UserPwd;
			parameters[2].Value = model.ReadName;
			parameters[3].Value = model.UserEmail;
			parameters[4].Value = model.UserType;
			parameters[5].Value = model.UserLevel;
			parameters[6].Value = model.IsLock;
			parameters[7].Value = model.AddTime;

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
		public bool Update(DtCms.Model.Administrator model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update dt_Administrator set ");
			strSql.Append("UserName=@UserName,");
			strSql.Append("UserPwd=@UserPwd,");
			strSql.Append("ReadName=@ReadName,");
			strSql.Append("UserEmail=@UserEmail,");
			strSql.Append("UserType=@UserType,");
			strSql.Append("UserLevel=@UserLevel,");
			strSql.Append("IsLock=@IsLock");
			strSql.Append(" where Id=@Id");
			SqlParameter[] parameters = {
					new SqlParameter("@Id", SqlDbType.Int,4),
					new SqlParameter("@UserName", SqlDbType.NVarChar,20),
					new SqlParameter("@UserPwd", SqlDbType.NVarChar,50),
					new SqlParameter("@ReadName", SqlDbType.NVarChar,30),
					new SqlParameter("@UserEmail", SqlDbType.NVarChar,30),
					new SqlParameter("@UserType", SqlDbType.Int,4),
					new SqlParameter("@UserLevel", SqlDbType.NText),
					new SqlParameter("@IsLock", SqlDbType.Int,4)};
			parameters[0].Value = model.Id;
			parameters[1].Value = model.UserName;
			parameters[2].Value = model.UserPwd;
			parameters[3].Value = model.ReadName;
			parameters[4].Value = model.UserEmail;
			parameters[5].Value = model.UserType;
			parameters[6].Value = model.UserLevel;
			parameters[7].Value = model.IsLock;

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
			strSql.Append("delete from dt_Administrator ");
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
        /// 根据用户名取得一行数据给MODEL
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        public DtCms.Model.Administrator GetModel(string UserName)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select top 1 * from dt_Administrator");
            strSql.Append(" where UserName=@UserName ");
            SqlParameter[] parameters = {
					new SqlParameter("@UserName", SqlDbType.NVarChar,30)};
            parameters[0].Value = UserName;

            DtCms.Model.Administrator model = new DtCms.Model.Administrator();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["Id"].ToString() != "")
                {
                    model.Id = int.Parse(ds.Tables[0].Rows[0]["Id"].ToString());
                }
                model.UserName = ds.Tables[0].Rows[0]["UserName"].ToString();
                model.UserPwd = ds.Tables[0].Rows[0]["UserPwd"].ToString();
                model.ReadName = ds.Tables[0].Rows[0]["ReadName"].ToString();
                model.UserEmail = ds.Tables[0].Rows[0]["UserEmail"].ToString();
                if (ds.Tables[0].Rows[0]["UserType"].ToString() != "")
                {
                    model.UserType = int.Parse(ds.Tables[0].Rows[0]["UserType"].ToString());
                }
                model.UserLevel = ds.Tables[0].Rows[0]["UserLevel"].ToString();
                if (ds.Tables[0].Rows[0]["IsLock"].ToString() != "")
                {
                    model.IsLock = int.Parse(ds.Tables[0].Rows[0]["IsLock"].ToString());
                }
                if (ds.Tables[0].Rows[0]["AddTime"].ToString() != "")
                {
                    model.AddTime = DateTime.Parse(ds.Tables[0].Rows[0]["AddTime"].ToString());
                }
                return model;
            }
            return model;
        }

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public DtCms.Model.Administrator GetModel(int Id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 Id,UserName,UserPwd,ReadName,UserEmail,UserType,UserLevel,IsLock,AddTime from dt_Administrator ");
			strSql.Append(" where Id=@Id");
			SqlParameter[] parameters = {
					new SqlParameter("@Id", SqlDbType.Int,4)
            };
			parameters[0].Value = Id;

			DtCms.Model.Administrator model=new DtCms.Model.Administrator();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["Id"].ToString()!="")
				{
					model.Id=int.Parse(ds.Tables[0].Rows[0]["Id"].ToString());
				}
				model.UserName=ds.Tables[0].Rows[0]["UserName"].ToString();
				model.UserPwd=ds.Tables[0].Rows[0]["UserPwd"].ToString();
				model.ReadName=ds.Tables[0].Rows[0]["ReadName"].ToString();
				model.UserEmail=ds.Tables[0].Rows[0]["UserEmail"].ToString();
                if (ds.Tables[0].Rows[0]["UserType"].ToString() != "")
                {
                    model.UserType = int.Parse(ds.Tables[0].Rows[0]["UserType"].ToString());
                }
				model.UserLevel=ds.Tables[0].Rows[0]["UserLevel"].ToString();
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
			strSql.Append("select Id,UserName,UserPwd,ReadName,UserEmail,UserType,UserLevel,IsLock,AddTime ");
			strSql.Append(" FROM dt_Administrator ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
            strSql.Append(" order by AddTime desc");
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
			strSql.Append(" Id,UserName,UserPwd,ReadName,UserEmail,UserType,UserLevel,IsLock,AddTime ");
			strSql.Append(" FROM dt_Administrator ");
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
            strSql.Append("select top " + pageSize + " Id,UserName,UserPwd,ReadName,UserEmail,UserType,UserLevel,IsLock,AddTime from dt_Administrator");
            strSql.Append(" where Id not in(select top " + topSize + " Id from dt_Administrator");
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

