using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using DtCms.DBUtility;
namespace DtCms.DAL
{
	/// <summary>
	/// 数据访问类:Downloads
	/// </summary>
	public partial class Downloads
	{
		public Downloads()
		{}
		#region  Method

		/// <summary>
		/// 得到最大ID
		/// </summary>
        public int GetMaxId()
        {
            return DbHelperSQL.GetMaxID("Id", "dt_Downloads");
        }

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int Id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from dt_Downloads");
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
            strSql.Append(" from dt_Downloads ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return Convert.ToInt32(DbHelperSQL.GetSingle(strSql.ToString()));
        }

        /// <summary>
        /// 返回该类别下的所有记录总数(分页用到)
        /// </summary>
        public int GetCount(string strWhere, int classId, int kindId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(*) as H ");
            strSql.Append(" from dt_Downloads ");
            strSql.Append(" where ClassId in(select Id from dt_Channel where KindId=" + kindId + " and ClassList like '%," + classId + ",%')");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" and " + strWhere);
            }
            return Convert.ToInt32(DbHelperSQL.GetSingle(strSql.ToString()));
        }

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(DtCms.Model.Downloads model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into dt_Downloads(");
			strSql.Append("Title,ClassId,ImgUrl,FileType,FileSize,FilePath,Click,DownNum,Content,IsMsg,IsRed,IsLock,AddTime)");
			strSql.Append(" values (");
			strSql.Append("@Title,@ClassId,@ImgUrl,@FileType,@FileSize,@FilePath,@Click,@DownNum,@Content,@IsMsg,@IsRed,@IsLock,@AddTime)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@Title", SqlDbType.NVarChar,100),
					new SqlParameter("@ClassId", SqlDbType.Int,4),
					new SqlParameter("@ImgUrl", SqlDbType.NVarChar,250),
					new SqlParameter("@FileType", SqlDbType.NVarChar,30),
					new SqlParameter("@FileSize", SqlDbType.Int,4),
					new SqlParameter("@FilePath", SqlDbType.NVarChar,250),
					new SqlParameter("@Click", SqlDbType.Int,4),
					new SqlParameter("@DownNum", SqlDbType.Int,4),
					new SqlParameter("@Content", SqlDbType.NText),
					new SqlParameter("@IsMsg", SqlDbType.Int,4),
					new SqlParameter("@IsRed", SqlDbType.Int,4),
					new SqlParameter("@IsLock", SqlDbType.Int,4),
					new SqlParameter("@AddTime", SqlDbType.DateTime)};
			parameters[0].Value = model.Title;
			parameters[1].Value = model.ClassId;
			parameters[2].Value = model.ImgUrl;
			parameters[3].Value = model.FileType;
			parameters[4].Value = model.FileSize;
			parameters[5].Value = model.FilePath;
			parameters[6].Value = model.Click;
			parameters[7].Value = model.DownNum;
			parameters[8].Value = model.Content;
			parameters[9].Value = model.IsMsg;
			parameters[10].Value = model.IsRed;
			parameters[11].Value = model.IsLock;
			parameters[12].Value = model.AddTime;

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
            strSql.Append("update dt_Downloads set " + strValue);
            strSql.Append(" where Id=" + Id);
            DbHelperSQL.ExecuteSql(strSql.ToString());
        }

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(DtCms.Model.Downloads model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update dt_Downloads set ");
			strSql.Append("Title=@Title,");
			strSql.Append("ClassId=@ClassId,");
			strSql.Append("ImgUrl=@ImgUrl,");
			strSql.Append("FileType=@FileType,");
			strSql.Append("FileSize=@FileSize,");
			strSql.Append("FilePath=@FilePath,");
			strSql.Append("Click=@Click,");
			strSql.Append("DownNum=@DownNum,");
			strSql.Append("Content=@Content,");
			strSql.Append("IsMsg=@IsMsg,");
			strSql.Append("IsRed=@IsRed,");
			strSql.Append("IsLock=@IsLock,");
			strSql.Append("AddTime=@AddTime");
			strSql.Append(" where Id=@Id");
			SqlParameter[] parameters = {
					new SqlParameter("@Id", SqlDbType.Int,4),
					new SqlParameter("@Title", SqlDbType.NVarChar,100),
					new SqlParameter("@ClassId", SqlDbType.Int,4),
					new SqlParameter("@ImgUrl", SqlDbType.NVarChar,250),
					new SqlParameter("@FileType", SqlDbType.NVarChar,30),
					new SqlParameter("@FileSize", SqlDbType.Int,4),
					new SqlParameter("@FilePath", SqlDbType.NVarChar,250),
					new SqlParameter("@Click", SqlDbType.Int,4),
					new SqlParameter("@DownNum", SqlDbType.Int,4),
					new SqlParameter("@Content", SqlDbType.NText),
					new SqlParameter("@IsMsg", SqlDbType.Int,4),
					new SqlParameter("@IsRed", SqlDbType.Int,4),
					new SqlParameter("@IsLock", SqlDbType.Int,4),
					new SqlParameter("@AddTime", SqlDbType.DateTime)};
			parameters[0].Value = model.Id;
			parameters[1].Value = model.Title;
			parameters[2].Value = model.ClassId;
			parameters[3].Value = model.ImgUrl;
			parameters[4].Value = model.FileType;
			parameters[5].Value = model.FileSize;
			parameters[6].Value = model.FilePath;
			parameters[7].Value = model.Click;
			parameters[8].Value = model.DownNum;
			parameters[9].Value = model.Content;
			parameters[10].Value = model.IsMsg;
			parameters[11].Value = model.IsRed;
			parameters[12].Value = model.IsLock;
			parameters[13].Value = model.AddTime;

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
        /// 删除一条数据，及子表所有相关数据
        /// </summary>
        public bool Delete(int kindId, int Id)
        {
            List<CommandInfo> sqllist = new List<CommandInfo>();

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete dt_AllReviews ");
            strSql.Append(" where KindId=@KindId and ParentId=@ParentId ");
            SqlParameter[] parameters = {
					new SqlParameter("@KindId", SqlDbType.Int,4),
                    new SqlParameter("@ParentId", SqlDbType.Int,4)
            };
            parameters[0].Value = kindId;
            parameters[1].Value = Id;

            CommandInfo cmd = new CommandInfo(strSql.ToString(), parameters);
            sqllist.Add(cmd);

            StringBuilder strSql2 = new StringBuilder();
            strSql2.Append("delete dt_Downloads ");
            strSql2.Append(" where Id=@Id ");
            SqlParameter[] parameters2 = {
					new SqlParameter("@Id", SqlDbType.Int,4)};
            parameters2[0].Value = Id;

            cmd = new CommandInfo(strSql2.ToString(), parameters2);
            sqllist.Add(cmd);

            int rowsAffected = DbHelperSQL.ExecuteSqlTran(sqllist);
            if (rowsAffected > 0)
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
		public DtCms.Model.Downloads GetModel(int Id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 Id,Title,ClassId,ImgUrl,FileType,FileSize,FilePath,Click,DownNum,Content,IsMsg,IsRed,IsLock,AddTime from dt_Downloads ");
			strSql.Append(" where Id=@Id");
			SqlParameter[] parameters = {
					new SqlParameter("@Id", SqlDbType.Int,4)
            };
			parameters[0].Value = Id;

			DtCms.Model.Downloads model=new DtCms.Model.Downloads();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["Id"].ToString()!="")
				{
					model.Id=int.Parse(ds.Tables[0].Rows[0]["Id"].ToString());
				}
				model.Title=ds.Tables[0].Rows[0]["Title"].ToString();
				if(ds.Tables[0].Rows[0]["ClassId"].ToString()!="")
				{
					model.ClassId=int.Parse(ds.Tables[0].Rows[0]["ClassId"].ToString());
				}
				model.ImgUrl=ds.Tables[0].Rows[0]["ImgUrl"].ToString();
				model.FileType=ds.Tables[0].Rows[0]["FileType"].ToString();
				if(ds.Tables[0].Rows[0]["FileSize"].ToString()!="")
				{
					model.FileSize=int.Parse(ds.Tables[0].Rows[0]["FileSize"].ToString());
				}
				model.FilePath=ds.Tables[0].Rows[0]["FilePath"].ToString();
				if(ds.Tables[0].Rows[0]["Click"].ToString()!="")
				{
					model.Click=int.Parse(ds.Tables[0].Rows[0]["Click"].ToString());
				}
				if(ds.Tables[0].Rows[0]["DownNum"].ToString()!="")
				{
					model.DownNum=int.Parse(ds.Tables[0].Rows[0]["DownNum"].ToString());
				}
				model.Content=ds.Tables[0].Rows[0]["Content"].ToString();
				if(ds.Tables[0].Rows[0]["IsMsg"].ToString()!="")
				{
					model.IsMsg=int.Parse(ds.Tables[0].Rows[0]["IsMsg"].ToString());
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
			strSql.Append("select Id,Title,ClassId,ImgUrl,FileType,FileSize,FilePath,Click,DownNum,Content,IsMsg,IsRed,IsLock,AddTime ");
			strSql.Append(" FROM dt_Downloads ");
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
			strSql.Append(" Id,Title,ClassId,ImgUrl,FileType,FileSize,FilePath,Click,DownNum,Content,IsMsg,IsRed,IsLock,AddTime ");
			strSql.Append(" FROM dt_Downloads ");
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
            strSql.Append("select top " + pageSize + " Id,Title,ClassId,ImgUrl,FileType,FileSize,FilePath,Click,DownNum,Content,IsMsg,IsRed,IsLock,AddTime from dt_Downloads");
            strSql.Append(" where Id not in(select top " + topSize + " Id from dt_Downloads");
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

