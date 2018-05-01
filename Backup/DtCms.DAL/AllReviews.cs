using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using DtCms.DBUtility;
namespace DtCms.DAL
{
	/// <summary>
	/// ���ݷ�����:AllReviews
	/// </summary>
	public partial class AllReviews
	{
		public AllReviews()
		{}
		#region  Method

		/// <summary>
		/// �õ����ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("Id", "dt_AllReviews"); 
		}

		/// <summary>
		/// �Ƿ���ڸü�¼
		/// </summary>
		public bool Exists(int Id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from dt_AllReviews");
			strSql.Append(" where Id=@Id ");
			SqlParameter[] parameters = {
					new SqlParameter("@Id", SqlDbType.Int,4)};
			parameters[0].Value = Id;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}

        /// <summary>
        /// ������������(��ҳ�õ�)
        /// </summary>
        public int GetCount(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(*) as H ");
            strSql.Append(" from dt_AllReviews ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return Convert.ToInt32(DbHelperSQL.GetSingle(strSql.ToString()));
        }

		/// <summary>
		/// ����һ������
		/// </summary>
		public int Add(DtCms.Model.AllReviews model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into dt_AllReviews(");
			strSql.Append("KindId,ParentId,UserName,Grade,Content,IsLock,AddTime)");
			strSql.Append(" values (");
            strSql.Append("@KindId,@ParentId,@UserName,@Grade,@Content,@IsLock,@AddTime)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@KindId", SqlDbType.Int,4),
					new SqlParameter("@ParentId", SqlDbType.Int,4),
					new SqlParameter("@UserName", SqlDbType.NVarChar,30),
					new SqlParameter("@Grade", SqlDbType.Int,4),
					new SqlParameter("@Content", SqlDbType.NVarChar,3000),
                    new SqlParameter("@IsLock", SqlDbType.Int,4),
					new SqlParameter("@AddTime", SqlDbType.DateTime)};
			parameters[0].Value = model.KindId;
			parameters[1].Value = model.ParentId;
			parameters[2].Value = model.UserName;
			parameters[3].Value = model.Grade;
			parameters[4].Value = model.Content;
            parameters[5].Value = model.IsLock;
			parameters[6].Value = model.AddTime;

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
        /// �޸�һ������
        /// </summary>
        public void UpdateField(int Id, string strValue)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update dt_AllReviews set " + strValue);
            strSql.Append(" where Id=" + Id);
            DbHelperSQL.ExecuteSql(strSql.ToString());
        }

		/// <summary>
		/// ɾ��һ������
		/// </summary>
		public bool Delete(int Id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from dt_AllReviews ");
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
		/// �õ�һ������ʵ��
		/// </summary>
		public DtCms.Model.AllReviews GetModel(int Id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 Id,KindId,ParentId,UserName,Grade,Content,IsLock,AddTime from dt_AllReviews ");
			strSql.Append(" where Id=@Id");
			SqlParameter[] parameters = {
					new SqlParameter("@Id", SqlDbType.Int,4)
            };
			parameters[0].Value = Id;

			DtCms.Model.AllReviews model=new DtCms.Model.AllReviews();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["Id"].ToString()!="")
				{
					model.Id=int.Parse(ds.Tables[0].Rows[0]["Id"].ToString());
				}
				if(ds.Tables[0].Rows[0]["KindId"].ToString()!="")
				{
					model.KindId=int.Parse(ds.Tables[0].Rows[0]["KindId"].ToString());
				}
				if(ds.Tables[0].Rows[0]["ParentId"].ToString()!="")
				{
					model.ParentId=int.Parse(ds.Tables[0].Rows[0]["ParentId"].ToString());
				}
				model.UserName=ds.Tables[0].Rows[0]["UserName"].ToString();
				if(ds.Tables[0].Rows[0]["Grade"].ToString()!="")
				{
                    model.Grade = int.Parse(ds.Tables[0].Rows[0]["Grade"].ToString());
				}
				model.Content=ds.Tables[0].Rows[0]["Content"].ToString();
                if (ds.Tables[0].Rows[0]["IsLock"].ToString() != "")
                {
                    model.IsLock = int.Parse(ds.Tables[0].Rows[0]["IsLock"].ToString());
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
		/// ��������б�
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select Id,KindId,ParentId,UserName,Grade,Content,IsLock,AddTime ");
			strSql.Append(" FROM dt_AllReviews ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
            strSql.Append(" order by AddTime desc");
			return DbHelperSQL.Query(strSql.ToString());
		}

		/// <summary>
		/// ���ǰ��������
		/// </summary>
		public DataSet GetList(int Top,string strWhere,string filedOrder)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ");
			if(Top>0)
			{
				strSql.Append(" top "+Top.ToString());
			}
            strSql.Append(" Id,KindId,ParentId,UserName,Grade,Content,IsLock,AddTime ");
			strSql.Append(" FROM dt_AllReviews ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			strSql.Append(" order by " + filedOrder);
			return DbHelperSQL.Query(strSql.ToString());
		}

        /// <summary>
        /// ��ò�ѯ��ҳ����
        /// </summary>
        public DataSet GetPageList(int pageSize, int currentPage, string strWhere, string filedOrder)
        {
            int topSize = pageSize * currentPage;
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select top " + pageSize + " Id,KindId,ParentId,UserName,Grade,Content,IsLock,AddTime from dt_AllReviews");
            strSql.Append(" where Id not in(select top " + topSize + " Id from dt_AllReviews");
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

