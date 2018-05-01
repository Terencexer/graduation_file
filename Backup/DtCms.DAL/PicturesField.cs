using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using DtCms.DBUtility;
namespace DtCms.DAL
{
	/// <summary>
	/// 数据访问类:图文扩展字段
	/// </summary>
	public partial class PicturesField
	{
		public PicturesField()
		{}
		#region  Method

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("Id", "dt_PicturesField"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int Id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from dt_PicturesField");
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
            strSql.Append(" from dt_PicturesField ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return Convert.ToInt32(DbHelperSQL.GetSingle(strSql.ToString()));
        }

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(DtCms.Model.PicturesField model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into dt_PicturesField(");
			strSql.Append("Title,FieldRemark,FieldType,IsNull,SortId)");
			strSql.Append(" values (");
			strSql.Append("@Title,@FieldRemark,@FieldType,@IsNull,@SortId)");
            strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@Title", SqlDbType.NVarChar,50),
					new SqlParameter("@FieldRemark", SqlDbType.NVarChar,250),
					new SqlParameter("@FieldType", SqlDbType.NVarChar,20),
					new SqlParameter("@IsNull", SqlDbType.Bit,1),
					new SqlParameter("@SortId", SqlDbType.Int,4)};
			parameters[0].Value = model.Title;
			parameters[1].Value = model.FieldRemark;
			parameters[2].Value = model.FieldType;
			parameters[3].Value = model.IsNull;
			parameters[4].Value = model.SortId;

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
		/// 更新一条数据
		/// </summary>
		public bool Update(DtCms.Model.PicturesField model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update dt_PicturesField set ");
			strSql.Append("Title=@Title,");
			strSql.Append("FieldRemark=@FieldRemark,");
			strSql.Append("FieldType=@FieldType,");
			strSql.Append("IsNull=@IsNull,");
			strSql.Append("SortId=@SortId");
			strSql.Append(" where Id=@Id ");
			SqlParameter[] parameters = {
					new SqlParameter("@Id", SqlDbType.Int,4),
					new SqlParameter("@Title", SqlDbType.NVarChar,50),
					new SqlParameter("@FieldRemark", SqlDbType.NVarChar,250),
					new SqlParameter("@FieldType", SqlDbType.NVarChar,20),
					new SqlParameter("@IsNull", SqlDbType.Bit,1),
					new SqlParameter("@SortId", SqlDbType.Int,4)};
			parameters[0].Value = model.Id;
			parameters[1].Value = model.Title;
			parameters[2].Value = model.FieldRemark;
			parameters[3].Value = model.FieldType;
			parameters[4].Value = model.IsNull;
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
        /// 删除一条数据，及子表所有相关数据
        /// </summary>
        public bool Delete(int Id)
        {
            List<CommandInfo> sqllist = new List<CommandInfo>();

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete dt_PicturesExtension ");
            strSql.Append(" where FieldId=@FieldId ");
            SqlParameter[] parameters = {
					new SqlParameter("@FieldId", SqlDbType.Int,4)};
            parameters[0].Value = Id;

            CommandInfo cmd = new CommandInfo(strSql.ToString(), parameters);
            sqllist.Add(cmd);
            
            StringBuilder strSql2 = new StringBuilder();
            strSql2.Append("delete dt_PicturesField ");
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
		public DtCms.Model.PicturesField GetModel(int Id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 Id,Title,FieldRemark,FieldType,IsNull,SortId from dt_PicturesField ");
			strSql.Append(" where Id=@Id ");
			SqlParameter[] parameters = {
					new SqlParameter("@Id", SqlDbType.Int,4)};
			parameters[0].Value = Id;

			DtCms.Model.PicturesField model=new DtCms.Model.PicturesField();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["Id"].ToString()!="")
				{
					model.Id=int.Parse(ds.Tables[0].Rows[0]["Id"].ToString());
				}
				model.Title=ds.Tables[0].Rows[0]["Title"].ToString();
				model.FieldRemark=ds.Tables[0].Rows[0]["FieldRemark"].ToString();
				model.FieldType=ds.Tables[0].Rows[0]["FieldType"].ToString();
				if(ds.Tables[0].Rows[0]["IsNull"].ToString()!="")
				{
					if((ds.Tables[0].Rows[0]["IsNull"].ToString()=="1")||(ds.Tables[0].Rows[0]["IsNull"].ToString().ToLower()=="true"))
					{
						model.IsNull=true;
					}
					else
					{
						model.IsNull=false;
					}
				}
				if(ds.Tables[0].Rows[0]["SortId"].ToString()!="")
				{
					model.SortId=int.Parse(ds.Tables[0].Rows[0]["SortId"].ToString());
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
			strSql.Append("select Id,Title,FieldRemark,FieldType,IsNull,SortId ");
			strSql.Append(" FROM dt_PicturesField ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
            strSql.Append(" order by SortId asc");
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
			strSql.Append(" Id,Title,FieldRemark,FieldType,IsNull,SortId ");
			strSql.Append(" FROM dt_PicturesField ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			strSql.Append(" order by " + filedOrder);
			return DbHelperSQL.Query(strSql.ToString());
		}

		#endregion  Method
	}
}

