using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using DtCms.DBUtility;
namespace DtCms.DAL
{
	/// <summary>
	/// 数据访问类:文章
	/// </summary>
	public partial class Article
	{
		public Article()
		{}
		#region  Method

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("Id", "dt_Article"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int Id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from dt_Article");
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
            strSql.Append(" from dt_Article ");
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
            strSql.Append(" from dt_Article ");
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
		public int Add(DtCms.Model.Article model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into dt_Article(");
			strSql.Append("ClassId,Title,Author,Form,Keyword,Zhaiyao,Daodu,ImgUrl,Content,Click,IsMsg,IsTop,IsRed,IsHot,IsSlide,IsLock,AddTime)");
			strSql.Append(" values (");
			strSql.Append("@ClassId,@Title,@Author,@Form,@Keyword,@Zhaiyao,@Daodu,@ImgUrl,@Content,@Click,@IsMsg,@IsTop,@IsRed,@IsHot,@IsSlide,@IsLock,@AddTime)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@ClassId", SqlDbType.Int,4),
					new SqlParameter("@Title", SqlDbType.NVarChar,100),
					new SqlParameter("@Author", SqlDbType.NVarChar,50),
					new SqlParameter("@Form", SqlDbType.NVarChar,50),
					new SqlParameter("@Keyword", SqlDbType.NVarChar,100),
					new SqlParameter("@Zhaiyao", SqlDbType.NVarChar,250),
					new SqlParameter("@Daodu", SqlDbType.NVarChar,250),
					new SqlParameter("@ImgUrl", SqlDbType.NVarChar,250),
					new SqlParameter("@Content", SqlDbType.NText),
					new SqlParameter("@Click", SqlDbType.Int,4),
					new SqlParameter("@IsMsg", SqlDbType.Int,4),
					new SqlParameter("@IsTop", SqlDbType.Int,4),
					new SqlParameter("@IsRed", SqlDbType.Int,4),
					new SqlParameter("@IsHot", SqlDbType.Int,4),
					new SqlParameter("@IsSlide", SqlDbType.Int,4),
					new SqlParameter("@IsLock", SqlDbType.Int,4),
					new SqlParameter("@AddTime", SqlDbType.DateTime)};
			parameters[0].Value = model.ClassId;
			parameters[1].Value = model.Title;
			parameters[2].Value = model.Author;
			parameters[3].Value = model.Form;
			parameters[4].Value = model.Keyword;
			parameters[5].Value = model.Zhaiyao;
			parameters[6].Value = model.Daodu;
			parameters[7].Value = model.ImgUrl;
			parameters[8].Value = model.Content;
			parameters[9].Value = model.Click;
			parameters[10].Value = model.IsMsg;
			parameters[11].Value = model.IsTop;
			parameters[12].Value = model.IsRed;
			parameters[13].Value = model.IsHot;
			parameters[14].Value = model.IsSlide;
			parameters[15].Value = model.IsLock;
			parameters[16].Value = model.AddTime;

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
            strSql.Append("update dt_Article set " + strValue);
            strSql.Append(" where Id=" + Id);
            DbHelperSQL.ExecuteSql(strSql.ToString());
        }

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(DtCms.Model.Article model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update dt_Article set ");
			strSql.Append("ClassId=@ClassId,");
			strSql.Append("Title=@Title,");
			strSql.Append("Author=@Author,");
			strSql.Append("Form=@Form,");
			strSql.Append("Keyword=@Keyword,");
			strSql.Append("Zhaiyao=@Zhaiyao,");
			strSql.Append("Daodu=@Daodu,");
			strSql.Append("ImgUrl=@ImgUrl,");
			strSql.Append("Content=@Content,");
			strSql.Append("Click=@Click,");
			strSql.Append("IsMsg=@IsMsg,");
			strSql.Append("IsTop=@IsTop,");
			strSql.Append("IsRed=@IsRed,");
			strSql.Append("IsHot=@IsHot,");
			strSql.Append("IsSlide=@IsSlide,");
			strSql.Append("IsLock=@IsLock");
			strSql.Append(" where Id=@Id");
			SqlParameter[] parameters = {
					new SqlParameter("@Id", SqlDbType.Int,4),
					new SqlParameter("@ClassId", SqlDbType.Int,4),
					new SqlParameter("@Title", SqlDbType.NVarChar,100),
					new SqlParameter("@Author", SqlDbType.NVarChar,50),
					new SqlParameter("@Form", SqlDbType.NVarChar,50),
					new SqlParameter("@Keyword", SqlDbType.NVarChar,100),
					new SqlParameter("@Zhaiyao", SqlDbType.NVarChar,250),
					new SqlParameter("@Daodu", SqlDbType.NVarChar,250),
					new SqlParameter("@ImgUrl", SqlDbType.NVarChar,250),
					new SqlParameter("@Content", SqlDbType.NText),
					new SqlParameter("@Click", SqlDbType.Int,4),
					new SqlParameter("@IsMsg", SqlDbType.Int,4),
					new SqlParameter("@IsTop", SqlDbType.Int,4),
					new SqlParameter("@IsRed", SqlDbType.Int,4),
					new SqlParameter("@IsHot", SqlDbType.Int,4),
					new SqlParameter("@IsSlide", SqlDbType.Int,4),
					new SqlParameter("@IsLock", SqlDbType.Int,4)};
			parameters[0].Value = model.Id;
			parameters[1].Value = model.ClassId;
			parameters[2].Value = model.Title;
			parameters[3].Value = model.Author;
			parameters[4].Value = model.Form;
			parameters[5].Value = model.Keyword;
			parameters[6].Value = model.Zhaiyao;
			parameters[7].Value = model.Daodu;
			parameters[8].Value = model.ImgUrl;
			parameters[9].Value = model.Content;
			parameters[10].Value = model.Click;
			parameters[11].Value = model.IsMsg;
			parameters[12].Value = model.IsTop;
			parameters[13].Value = model.IsRed;
			parameters[14].Value = model.IsHot;
			parameters[15].Value = model.IsSlide;
			parameters[16].Value = model.IsLock;

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
        /// 删除一条数据，及子表所有相关评论数据
        /// </summary>
        public bool Delete(int kindId, int Id)
        {
            List<CommandInfo> sqllist = new List<CommandInfo>();
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete dt_Article ");
            strSql.Append(" where Id=@Id ");
            SqlParameter[] parameters = {
					new SqlParameter("@Id", SqlDbType.Int,4)};
            parameters[0].Value = Id;

            CommandInfo cmd = new CommandInfo(strSql.ToString(), parameters);
            sqllist.Add(cmd);
            StringBuilder strSql2 = new StringBuilder();
            strSql2.Append("delete dt_AllReviews ");
            strSql2.Append(" where KindId=@KindId and ParentId=@ParentId ");
            SqlParameter[] parameters2 = {
                    new SqlParameter("@KindId", SqlDbType.Int,4),
                    new SqlParameter("@ParentId", SqlDbType.Int,4)
                    };
            parameters2[0].Value = kindId;
            parameters2[1].Value = Id;

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
		public DtCms.Model.Article GetModel(int Id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 Id,ClassId,Title,Author,Form,Keyword,Zhaiyao,Daodu,ImgUrl,Content,Click,IsMsg,IsTop,IsRed,IsHot,IsSlide,IsLock,AddTime from dt_Article ");
			strSql.Append(" where Id=@Id");
			SqlParameter[] parameters = {
					new SqlParameter("@Id", SqlDbType.Int,4)
};
			parameters[0].Value = Id;

			DtCms.Model.Article model=new DtCms.Model.Article();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["Id"].ToString()!="")
				{
					model.Id=int.Parse(ds.Tables[0].Rows[0]["Id"].ToString());
				}
				if(ds.Tables[0].Rows[0]["ClassId"].ToString()!="")
				{
					model.ClassId=int.Parse(ds.Tables[0].Rows[0]["ClassId"].ToString());
				}
				model.Title=ds.Tables[0].Rows[0]["Title"].ToString();
				model.Author=ds.Tables[0].Rows[0]["Author"].ToString();
				model.Form=ds.Tables[0].Rows[0]["Form"].ToString();
				model.Keyword=ds.Tables[0].Rows[0]["Keyword"].ToString();
				model.Zhaiyao=ds.Tables[0].Rows[0]["Zhaiyao"].ToString();
				model.Daodu=ds.Tables[0].Rows[0]["Daodu"].ToString();
				model.ImgUrl=ds.Tables[0].Rows[0]["ImgUrl"].ToString();
				model.Content=ds.Tables[0].Rows[0]["Content"].ToString();
				if(ds.Tables[0].Rows[0]["Click"].ToString()!="")
				{
					model.Click=int.Parse(ds.Tables[0].Rows[0]["Click"].ToString());
				}
				if(ds.Tables[0].Rows[0]["IsMsg"].ToString()!="")
				{
					model.IsMsg=int.Parse(ds.Tables[0].Rows[0]["IsMsg"].ToString());
				}
				if(ds.Tables[0].Rows[0]["IsTop"].ToString()!="")
				{
					model.IsTop=int.Parse(ds.Tables[0].Rows[0]["IsTop"].ToString());
				}
				if(ds.Tables[0].Rows[0]["IsRed"].ToString()!="")
				{
					model.IsRed=int.Parse(ds.Tables[0].Rows[0]["IsRed"].ToString());
				}
				if(ds.Tables[0].Rows[0]["IsHot"].ToString()!="")
				{
					model.IsHot=int.Parse(ds.Tables[0].Rows[0]["IsHot"].ToString());
				}
				if(ds.Tables[0].Rows[0]["IsSlide"].ToString()!="")
				{
					model.IsSlide=int.Parse(ds.Tables[0].Rows[0]["IsSlide"].ToString());
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
			strSql.Append("select Id,ClassId,Title,Author,Form,Keyword,Zhaiyao,Daodu,ImgUrl,Content,Click,IsMsg,IsTop,IsRed,IsHot,IsSlide,IsLock,AddTime ");
			strSql.Append(" FROM dt_Article ");
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
			strSql.Append(" Id,ClassId,Title,Author,Form,Keyword,Zhaiyao,Daodu,ImgUrl,Content,Click,IsMsg,IsTop,IsRed,IsHot,IsSlide,IsLock,AddTime ");
			strSql.Append(" FROM dt_Article ");
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
            strSql.Append("select top " + pageSize + " Id,ClassId,Title,Author,Form,Keyword,Zhaiyao,Daodu,ImgUrl,Content,Click,IsMsg,IsTop,IsRed,IsHot,IsSlide,IsLock,AddTime from dt_Article");
            strSql.Append(" where Id not in(select top " + topSize + " Id from dt_Article");
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

