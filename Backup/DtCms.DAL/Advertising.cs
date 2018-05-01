using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using DtCms.DBUtility;
namespace DtCms.DAL
{
	/// <summary>
	/// 数据访问类:广告位
	/// </summary>
	public partial class Advertising
	{
		public Advertising()
		{}
		#region  Method

		/// <summary>
		/// 得到最大ID
		/// </summary>
        public int GetMaxId()
        {
            return DbHelperSQL.GetMaxID("Id", "dt_Advertising");
        }

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int Id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from dt_Advertising");
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
            strSql.Append(" from dt_Advertising ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return Convert.ToInt32(DbHelperSQL.GetSingle(strSql.ToString()));
        }

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(DtCms.Model.Advertising model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into dt_Advertising(");
			strSql.Append("Title,AdType,AdRemark,AdNum,AdPrice,AdWidth,AdHeight,AdTarget)");
			strSql.Append(" values (");
			strSql.Append("@Title,@AdType,@AdRemark,@AdNum,@AdPrice,@AdWidth,@AdHeight,@AdTarget)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@Title", SqlDbType.NVarChar,100),
					new SqlParameter("@AdType", SqlDbType.Int,4),
					new SqlParameter("@AdRemark", SqlDbType.NVarChar,250),
					new SqlParameter("@AdNum", SqlDbType.Int,4),
					new SqlParameter("@AdPrice", SqlDbType.Decimal,9),
					new SqlParameter("@AdWidth", SqlDbType.Int,4),
					new SqlParameter("@AdHeight", SqlDbType.Int,4),
					new SqlParameter("@AdTarget", SqlDbType.NVarChar,50)};
			parameters[0].Value = model.Title;
			parameters[1].Value = model.AdType;
			parameters[2].Value = model.AdRemark;
			parameters[3].Value = model.AdNum;
			parameters[4].Value = model.AdPrice;
			parameters[5].Value = model.AdWidth;
			parameters[6].Value = model.AdHeight;
			parameters[7].Value = model.AdTarget;

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
		public bool Update(DtCms.Model.Advertising model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update dt_Advertising set ");
			strSql.Append("Title=@Title,");
			strSql.Append("AdType=@AdType,");
			strSql.Append("AdRemark=@AdRemark,");
			strSql.Append("AdNum=@AdNum,");
			strSql.Append("AdPrice=@AdPrice,");
			strSql.Append("AdWidth=@AdWidth,");
			strSql.Append("AdHeight=@AdHeight,");
			strSql.Append("AdTarget=@AdTarget");
			strSql.Append(" where Id=@Id");
			SqlParameter[] parameters = {
					new SqlParameter("@Id", SqlDbType.Int,4),
					new SqlParameter("@Title", SqlDbType.NVarChar,100),
					new SqlParameter("@AdType", SqlDbType.Int,4),
					new SqlParameter("@AdRemark", SqlDbType.NVarChar,250),
					new SqlParameter("@AdNum", SqlDbType.Int,4),
					new SqlParameter("@AdPrice", SqlDbType.Decimal,9),
					new SqlParameter("@AdWidth", SqlDbType.Int,4),
					new SqlParameter("@AdHeight", SqlDbType.Int,4),
					new SqlParameter("@AdTarget", SqlDbType.NVarChar,50)};
			parameters[0].Value = model.Id;
			parameters[1].Value = model.Title;
			parameters[2].Value = model.AdType;
			parameters[3].Value = model.AdRemark;
			parameters[4].Value = model.AdNum;
			parameters[5].Value = model.AdPrice;
			parameters[6].Value = model.AdWidth;
			parameters[7].Value = model.AdHeight;
			parameters[8].Value = model.AdTarget;

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
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete dt_Advertising ");
			strSql.Append(" where Id=@Id ");
			SqlParameter[] parameters = {
					new SqlParameter("@Id", SqlDbType.Int,4)};
			parameters[0].Value = Id;

			CommandInfo cmd = new CommandInfo(strSql.ToString(), parameters);
			sqllist.Add(cmd);
			StringBuilder strSql2=new StringBuilder();
			strSql2.Append("delete dt_Adbanner ");
			strSql2.Append(" where Aid=@Aid ");
			SqlParameter[] parameters2 = {
					new SqlParameter("@Aid", SqlDbType.Int,4)};
			parameters2[0].Value = Id;

			cmd = new CommandInfo(strSql2.ToString(), parameters2);
			sqllist.Add(cmd);
			int rowsAffected=DbHelperSQL.ExecuteSqlTran(sqllist);
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
		public DtCms.Model.Advertising GetModel(int Id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 Id,Title,AdType,AdRemark,AdNum,AdPrice,AdWidth,AdHeight,AdTarget from dt_Advertising ");
			strSql.Append(" where Id=@Id");
			SqlParameter[] parameters = {
					new SqlParameter("@Id", SqlDbType.Int,4)
            };
			parameters[0].Value = Id;

			DtCms.Model.Advertising model=new DtCms.Model.Advertising();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["Id"].ToString()!="")
				{
					model.Id=int.Parse(ds.Tables[0].Rows[0]["Id"].ToString());
				}
				model.Title=ds.Tables[0].Rows[0]["Title"].ToString();
				if(ds.Tables[0].Rows[0]["AdType"].ToString()!="")
				{
					model.AdType=int.Parse(ds.Tables[0].Rows[0]["AdType"].ToString());
				}
				model.AdRemark=ds.Tables[0].Rows[0]["AdRemark"].ToString();
				if(ds.Tables[0].Rows[0]["AdNum"].ToString()!="")
				{
					model.AdNum=int.Parse(ds.Tables[0].Rows[0]["AdNum"].ToString());
				}
				if(ds.Tables[0].Rows[0]["AdPrice"].ToString()!="")
				{
					model.AdPrice=decimal.Parse(ds.Tables[0].Rows[0]["AdPrice"].ToString());
				}
				if(ds.Tables[0].Rows[0]["AdWidth"].ToString()!="")
				{
					model.AdWidth=int.Parse(ds.Tables[0].Rows[0]["AdWidth"].ToString());
				}
				if(ds.Tables[0].Rows[0]["AdHeight"].ToString()!="")
				{
					model.AdHeight=int.Parse(ds.Tables[0].Rows[0]["AdHeight"].ToString());
				}
				model.AdTarget=ds.Tables[0].Rows[0]["AdTarget"].ToString();
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
			strSql.Append("select Id,Title,AdType,AdRemark,AdNum,AdPrice,AdWidth,AdHeight,AdTarget ");
			strSql.Append(" FROM dt_Advertising ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
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
			strSql.Append(" Id,Title,AdType,AdRemark,AdNum,AdPrice,AdWidth,AdHeight,AdTarget ");
			strSql.Append(" FROM dt_Advertising ");
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
            strSql.Append("select top " + pageSize + " Id,Title,AdType,AdRemark,AdNum,AdPrice,AdWidth,AdHeight,AdTarget from dt_Advertising");
            strSql.Append(" where Id not in(select top " + topSize + " Id from dt_Advertising");
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

