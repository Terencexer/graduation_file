using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using DtCms.DBUtility;
namespace DtCms.DAL
{
	/// <summary>
	/// 数据访问类:图文
	/// </summary>
	public partial class Pictures
	{
		public Pictures()
		{}
		#region  Method

		/// <summary>
		/// 得到最大ID
		/// </summary>
        public int GetMaxId()
        {
            return DbHelperSQL.GetMaxID("Id", "dt_Pictures");
        }

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int Id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from dt_Pictures");
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
            strSql.Append(" from dt_Pictures ");
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
            strSql.Append(" from dt_Pictures ");
            strSql.Append(" where ClassId in(select Id from dt_Channel where KindId=" + kindId + " and ClassList like '%," + classId + ",%')");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" and " + strWhere);
            }
            return Convert.ToInt32(DbHelperSQL.GetSingle(strSql.ToString()));
        }

        /// <summary>
        /// 增加一条数据,及其子表数据
        /// </summary>
        public int Add(DtCms.Model.Pictures model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into dt_Pictures(");
            strSql.Append("IsRed,IsHot,IsSlide,IsLock,SortId,AddTime,Title,ClassId,Price,ImgUrl,Content,Click,IsMsg,IsTop)");
            strSql.Append(" values (");
            strSql.Append("@IsRed,@IsHot,@IsSlide,@IsLock,@SortId,@AddTime,@Title,@ClassId,@Price,@ImgUrl,@Content,@Click,@IsMsg,@IsTop)");
            strSql.Append(";set @ReturnValue= @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@IsRed", SqlDbType.Int,4),
					new SqlParameter("@IsHot", SqlDbType.Int,4),
					new SqlParameter("@IsSlide", SqlDbType.Int,4),
					new SqlParameter("@IsLock", SqlDbType.Int,4),
					new SqlParameter("@SortId", SqlDbType.Int,4),
					new SqlParameter("@AddTime", SqlDbType.DateTime),
					new SqlParameter("@Title", SqlDbType.NVarChar,100),
					new SqlParameter("@ClassId", SqlDbType.Int,4),
					new SqlParameter("@Price", SqlDbType.Decimal,9),
					new SqlParameter("@ImgUrl", SqlDbType.NVarChar,250),
					new SqlParameter("@Content", SqlDbType.NText),
					new SqlParameter("@Click", SqlDbType.Int,4),
					new SqlParameter("@IsMsg", SqlDbType.Int,4),
					new SqlParameter("@IsTop", SqlDbType.Int,4),
					new SqlParameter("@ReturnValue",SqlDbType.Int)};
            parameters[0].Value = model.IsRed;
            parameters[1].Value = model.IsHot;
            parameters[2].Value = model.IsSlide;
            parameters[3].Value = model.IsLock;
            parameters[4].Value = model.SortId;
            parameters[5].Value = model.AddTime;
            parameters[6].Value = model.Title;
            parameters[7].Value = model.ClassId;
            parameters[8].Value = model.Price;
            parameters[9].Value = model.ImgUrl;
            parameters[10].Value = model.Content;
            parameters[11].Value = model.Click;
            parameters[12].Value = model.IsMsg;
            parameters[13].Value = model.IsTop;
            parameters[14].Direction = ParameterDirection.Output;

            List<CommandInfo> sqllist = new List<CommandInfo>();
            CommandInfo cmd = new CommandInfo(strSql.ToString(), parameters);
            sqllist.Add(cmd);

            if (model.PicturesExtensions != null)
            {
                StringBuilder strSql2;
                foreach (DtCms.Model.PicturesExtension models in model.PicturesExtensions)
                {
                    strSql2 = new StringBuilder();
                    strSql2.Append("insert into dt_PicturesExtension(");
                    strSql2.Append("PictureId,FieldId,FieldName,Content)");
                    strSql2.Append(" values (");
                    strSql2.Append("@PictureId,@FieldId,@FieldName,@Content)");
                    SqlParameter[] parameters2 = {
						new SqlParameter("@PictureId", SqlDbType.Int,4),
						new SqlParameter("@FieldId", SqlDbType.Int,4),
						new SqlParameter("@FieldName", SqlDbType.NVarChar,100),
						new SqlParameter("@Content", SqlDbType.NVarChar,250)};
                    parameters2[0].Direction = ParameterDirection.InputOutput;
                    parameters2[1].Value = models.FieldId;
                    parameters2[2].Value = models.FieldName;
                    parameters2[3].Value = models.Content;

                    cmd = new CommandInfo(strSql2.ToString(), parameters2);
                    sqllist.Add(cmd);
                }
            }

            if (model.PicturesAlbums != null)
            {
                StringBuilder strSql3;
                foreach (DtCms.Model.PicturesAlbum models in model.PicturesAlbums)
                {
                    strSql3 = new StringBuilder();
                    strSql3.Append("insert into dt_PicturesAlbum(");
                    strSql3.Append("PictureId,ImgUrl)");
                    strSql3.Append(" values (");
                    strSql3.Append("@PictureId,@ImgUrl)");
                    SqlParameter[] parameters3 = {
						new SqlParameter("@PictureId", SqlDbType.Int,4),
						new SqlParameter("@ImgUrl", SqlDbType.NVarChar,250)};
                    parameters3[0].Direction = ParameterDirection.InputOutput;
                    parameters3[1].Value = models.ImgUrl;

                    cmd = new CommandInfo(strSql3.ToString(), parameters3);
                    sqllist.Add(cmd);
                }
            }

            DbHelperSQL.ExecuteSqlTranWithIndentity(sqllist);
            return (int)parameters[14].Value;
        }

        /// <summary>
        /// 修改一列数据
        /// </summary>
        public void UpdateField(int Id, string strValue)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update dt_Pictures set " + strValue);
            strSql.Append(" where Id=" + Id);
            DbHelperSQL.ExecuteSql(strSql.ToString());
        }

        /// <summary>
        /// 更新一条数据,及其子表数据
        /// </summary>
        public bool Update(DtCms.Model.Pictures model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update dt_Pictures set ");
            strSql.Append("IsRed=@IsRed,");
            strSql.Append("IsHot=@IsHot,");
            strSql.Append("IsSlide=@IsSlide,");
            strSql.Append("IsLock=@IsLock,");
            strSql.Append("SortId=@SortId,");
            strSql.Append("Title=@Title,");
            strSql.Append("ClassId=@ClassId,");
            strSql.Append("Price=@Price,");
            strSql.Append("ImgUrl=@ImgUrl,");
            strSql.Append("Content=@Content,");
            strSql.Append("Click=@Click,");
            strSql.Append("IsMsg=@IsMsg,");
            strSql.Append("IsTop=@IsTop");
            strSql.Append(" where Id=@Id ");
            SqlParameter[] parameters = {
					new SqlParameter("@Id", SqlDbType.Int,4),
					new SqlParameter("@IsRed", SqlDbType.Int,4),
					new SqlParameter("@IsHot", SqlDbType.Int,4),
					new SqlParameter("@IsSlide", SqlDbType.Int,4),
					new SqlParameter("@IsLock", SqlDbType.Int,4),
					new SqlParameter("@SortId", SqlDbType.Int,4),
					new SqlParameter("@Title", SqlDbType.NVarChar,100),
					new SqlParameter("@ClassId", SqlDbType.Int,4),
					new SqlParameter("@Price", SqlDbType.Decimal,9),
					new SqlParameter("@ImgUrl", SqlDbType.NVarChar,250),
					new SqlParameter("@Content", SqlDbType.NText),
					new SqlParameter("@Click", SqlDbType.Int,4),
					new SqlParameter("@IsMsg", SqlDbType.Int,4),
					new SqlParameter("@IsTop", SqlDbType.Int,4)};
            parameters[0].Value = model.Id;
            parameters[1].Value = model.IsRed;
            parameters[2].Value = model.IsHot;
            parameters[3].Value = model.IsSlide;
            parameters[4].Value = model.IsLock;
            parameters[5].Value = model.SortId;
            parameters[6].Value = model.Title;
            parameters[7].Value = model.ClassId;
            parameters[8].Value = model.Price;
            parameters[9].Value = model.ImgUrl;
            parameters[10].Value = model.Content;
            parameters[11].Value = model.Click;
            parameters[12].Value = model.IsMsg;
            parameters[13].Value = model.IsTop;

            List<CommandInfo> sqllist = new List<CommandInfo>();
            CommandInfo cmd = new CommandInfo(strSql.ToString(), parameters);
            sqllist.Add(cmd);

            if (model.PicturesExtensions != null)
            {
                StringBuilder strSql2;
                foreach (DtCms.Model.PicturesExtension models in model.PicturesExtensions)
                {
                    strSql2 = new StringBuilder();
                    if (models.Id > 0)
                    {
                        strSql2.Append("update dt_PicturesExtension set ");
                        strSql2.Append("FieldName=@FieldName,");
                        strSql2.Append("Content=@Content");
                        strSql2.Append(" where Id=@Id ");
                        SqlParameter[] parameters2 = {
						new SqlParameter("@Id", SqlDbType.Int,4),
						new SqlParameter("@FieldName", SqlDbType.NVarChar,100),
						new SqlParameter("@Content", SqlDbType.NVarChar,250)};
                        parameters2[0].Value = models.Id;
                        parameters2[1].Value = models.FieldName;
                        parameters2[2].Value = models.Content;
                        cmd = new CommandInfo(strSql2.ToString(), parameters2);
                        sqllist.Add(cmd);
                    }
                    else
                    {
                        strSql2.Append("insert into dt_PicturesExtension(");
                        strSql2.Append("PictureId,FieldId,FieldName,Content)");
                        strSql2.Append(" values (");
                        strSql2.Append("@PictureId,@FieldId,@FieldName,@Content)");
                        SqlParameter[] parameters2 = {
						new SqlParameter("@PictureId", SqlDbType.Int,4),
						new SqlParameter("@FieldId", SqlDbType.Int,4),
						new SqlParameter("@FieldName", SqlDbType.NVarChar,100),
						new SqlParameter("@Content", SqlDbType.NVarChar,250)};
                        parameters2[0].Value = models.PictureId;
                        parameters2[1].Value = models.FieldId;
                        parameters2[2].Value = models.FieldName;
                        parameters2[3].Value = models.Content;
                        cmd = new CommandInfo(strSql2.ToString(), parameters2);
                        sqllist.Add(cmd);
                    }
                }
            }

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
        /// 删除一条数据，及子表所有相关数据
        /// </summary>
        public bool Delete(int Id)
        {
            List<CommandInfo> sqllist = new List<CommandInfo>();

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete dt_PicturesExtension ");
            strSql.Append(" where PictureId=@PictureId ");
            SqlParameter[] parameters = {
					new SqlParameter("@PictureId", SqlDbType.Int,4)};
            parameters[0].Value = Id;

            CommandInfo cmd = new CommandInfo(strSql.ToString(), parameters);
            sqllist.Add(cmd);

            StringBuilder strSql2 = new StringBuilder();
            strSql2.Append("delete dt_PicturesAlbum ");
            strSql2.Append(" where PictureId=@PictureId ");
            SqlParameter[] parameters2 = {
					new SqlParameter("@PictureId", SqlDbType.Int,4)};
            parameters2[0].Value = Id;

            cmd = new CommandInfo(strSql2.ToString(), parameters2);
            sqllist.Add(cmd);

            StringBuilder strSql3 = new StringBuilder();
            strSql3.Append("delete dt_AllReviews ");
            strSql3.Append(" where ParentId=@ParentId ");
            SqlParameter[] parameters3 = {
					new SqlParameter("@ParentId", SqlDbType.Int,4)};
            parameters3[0].Value = Id;

            cmd = new CommandInfo(strSql3.ToString(), parameters3);
            sqllist.Add(cmd);


            StringBuilder strSql4 = new StringBuilder();
            strSql4.Append("delete dt_Pictures ");
            strSql4.Append(" where Id=@Id ");
            SqlParameter[] parameters4 = {
					new SqlParameter("@Id", SqlDbType.Int,4)};
            parameters4[0].Value = Id;

            cmd = new CommandInfo(strSql4.ToString(), parameters4);
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
        public DtCms.Model.Pictures GetModel(int Id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select Id,IsRed,IsHot,IsSlide,IsLock,SortId,AddTime,Title,ClassId,Price,ImgUrl,Content,Click,IsMsg,IsTop from dt_Pictures ");
            strSql.Append(" where Id=@Id ");
            SqlParameter[] parameters = {
					new SqlParameter("@Id", SqlDbType.Int,4)};
            parameters[0].Value = Id;

            DtCms.Model.Pictures model = new DtCms.Model.Pictures();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                #region  父表信息
                if (ds.Tables[0].Rows[0]["Id"].ToString() != "")
                {
                    model.Id = int.Parse(ds.Tables[0].Rows[0]["Id"].ToString());
                }
                if (ds.Tables[0].Rows[0]["IsRed"].ToString() != "")
                {
                    model.IsRed = int.Parse(ds.Tables[0].Rows[0]["IsRed"].ToString());
                }
                if (ds.Tables[0].Rows[0]["IsHot"].ToString() != "")
                {
                    model.IsHot = int.Parse(ds.Tables[0].Rows[0]["IsHot"].ToString());
                }
                if (ds.Tables[0].Rows[0]["IsSlide"].ToString() != "")
                {
                    model.IsSlide = int.Parse(ds.Tables[0].Rows[0]["IsSlide"].ToString());
                }
                if (ds.Tables[0].Rows[0]["IsLock"].ToString() != "")
                {
                    model.IsLock = int.Parse(ds.Tables[0].Rows[0]["IsLock"].ToString());
                }
                if (ds.Tables[0].Rows[0]["SortId"].ToString() != "")
                {
                    model.SortId = int.Parse(ds.Tables[0].Rows[0]["SortId"].ToString());
                }
                if (ds.Tables[0].Rows[0]["AddTime"].ToString() != "")
                {
                    model.AddTime = DateTime.Parse(ds.Tables[0].Rows[0]["AddTime"].ToString());
                }
                model.Title = ds.Tables[0].Rows[0]["Title"].ToString();
                if (ds.Tables[0].Rows[0]["ClassId"].ToString() != "")
                {
                    model.ClassId = int.Parse(ds.Tables[0].Rows[0]["ClassId"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Price"].ToString() != "")
                {
                    model.Price = decimal.Parse(ds.Tables[0].Rows[0]["Price"].ToString());
                }
                model.ImgUrl = ds.Tables[0].Rows[0]["ImgUrl"].ToString();
                model.Content = ds.Tables[0].Rows[0]["Content"].ToString();
                if (ds.Tables[0].Rows[0]["Click"].ToString() != "")
                {
                    model.Click = int.Parse(ds.Tables[0].Rows[0]["Click"].ToString());
                }
                if (ds.Tables[0].Rows[0]["IsMsg"].ToString() != "")
                {
                    model.IsMsg = int.Parse(ds.Tables[0].Rows[0]["IsMsg"].ToString());
                }
                if (ds.Tables[0].Rows[0]["IsTop"].ToString() != "")
                {
                    model.IsTop = int.Parse(ds.Tables[0].Rows[0]["IsTop"].ToString());
                }
                #endregion  父表信息end

                #region  扩展字段信息
                StringBuilder strSql2 = new StringBuilder();
                strSql2.Append("select Id,PictureId,FieldId,FieldName,Content from dt_PicturesExtension ");
                strSql2.Append(" where PictureId=@PictureId ");
                SqlParameter[] parameters2 = {
					new SqlParameter("@PictureId", SqlDbType.Int,4)};
                parameters2[0].Value = Id;

                DataSet ds2 = DbHelperSQL.Query(strSql2.ToString(), parameters2);
                if (ds2.Tables[0].Rows.Count > 0)
                {
                    #region  子表字段信息
                    int i = ds2.Tables[0].Rows.Count;
                    List<DtCms.Model.PicturesExtension> models = new List<DtCms.Model.PicturesExtension>();
                    DtCms.Model.PicturesExtension modelt;
                    for (int n = 0; n < i; n++)
                    {
                        modelt = new DtCms.Model.PicturesExtension();
                        if (ds2.Tables[0].Rows[n]["Id"].ToString() != "")
                        {
                            modelt.Id = int.Parse(ds2.Tables[0].Rows[n]["Id"].ToString());
                        }
                        if (ds2.Tables[0].Rows[n]["PictureId"].ToString() != "")
                        {
                            modelt.PictureId = int.Parse(ds2.Tables[0].Rows[n]["PictureId"].ToString());
                        }
                        if (ds2.Tables[0].Rows[n]["FieldId"].ToString() != "")
                        {
                            modelt.FieldId = int.Parse(ds2.Tables[0].Rows[n]["FieldId"].ToString());
                        }
                        modelt.FieldName = ds2.Tables[0].Rows[n]["FieldName"].ToString();
                        modelt.Content = ds2.Tables[0].Rows[n]["Content"].ToString();
                        models.Add(modelt);
                    }
                    model.PicturesExtensions = models;
                    #endregion  子表字段信息end
                }
                #endregion  子表信息end

                #region  相册信息
                StringBuilder strSql3 = new StringBuilder();
                strSql3.Append("select Id,PictureId,ImgUrl from dt_PicturesAlbum ");
                strSql3.Append(" where PictureId=@PictureId ");
                SqlParameter[] parameters3 = {
					new SqlParameter("@PictureId", SqlDbType.Int,4)};
                parameters3[0].Value = Id;

                DataSet ds3 = DbHelperSQL.Query(strSql3.ToString(), parameters3);
                if (ds3.Tables[0].Rows.Count > 0)
                {
                    #region  子表字段信息
                    int i = ds3.Tables[0].Rows.Count;
                    List<DtCms.Model.PicturesAlbum> models = new List<DtCms.Model.PicturesAlbum>();
                    DtCms.Model.PicturesAlbum modelt;
                    for (int n = 0; n < i; n++)
                    {
                        modelt = new DtCms.Model.PicturesAlbum();
                        if (ds3.Tables[0].Rows[n]["Id"].ToString() != "")
                        {
                            modelt.Id = int.Parse(ds3.Tables[0].Rows[n]["Id"].ToString());
                        }
                        if (ds3.Tables[0].Rows[n]["PictureId"].ToString() != "")
                        {
                            modelt.PictureId = int.Parse(ds3.Tables[0].Rows[n]["PictureId"].ToString());
                        }
                        modelt.ImgUrl = ds3.Tables[0].Rows[n]["ImgUrl"].ToString();
                        models.Add(modelt);
                    }
                    model.PicturesAlbums = models;
                    #endregion  子表字段信息end
                }
                #endregion  子表信息end

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
			strSql.Append("select Id,Title,ClassId,Price,ImgUrl,Content,Click,IsMsg,IsTop,IsRed,IsHot,IsSlide,IsLock,SortId,AddTime ");
			strSql.Append(" FROM dt_Pictures ");
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
			strSql.Append(" Id,Title,ClassId,Price,ImgUrl,Content,Click,IsMsg,IsTop,IsRed,IsHot,IsSlide,IsLock,SortId,AddTime ");
			strSql.Append(" FROM dt_Pictures ");
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
            strSql.Append("select top " + pageSize + " Id,Title,ClassId,Price,ImgUrl,Content,Click,IsMsg,IsTop,IsRed,IsHot,IsSlide,IsLock,SortId,AddTime from dt_Pictures");
            strSql.Append(" where Id not in(select top " + topSize + " Id from dt_Pictures");
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

