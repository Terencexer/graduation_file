using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using DtCms.DBUtility;
namespace DtCms.DAL
{
	/// <summary>
	/// ���ݷ�����:��Ŀ����
	/// </summary>
	public partial class Channel
	{
		public Channel()
		{}
		#region  Method

		/// <summary>
		/// �õ����ID
		/// </summary>
        public int GetMaxId()
        {
            return DbHelperSQL.GetMaxID("Id", "dt_Channel");
        }

		/// <summary>
		/// �Ƿ���ڸü�¼
		/// </summary>
		public bool Exists(int Id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from dt_Channel");
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
            strSql.Append(" from dt_Channel ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return Convert.ToInt32(DbHelperSQL.GetSingle(strSql.ToString()));
        }

        /// <summary>
        /// ������Ŀ����
        /// </summary>
        public string GetChannelTitle(int classId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select top 1 Title from dt_Channel");
            strSql.Append(" where Id=" + classId);
            string title = Convert.ToString(DbHelperSQL.GetSingle(strSql.ToString()));
            if (string.IsNullOrEmpty(title))
            {
                return "";
            }
            return title;
        }

        /// <summary>
        /// ������Ŀ�ĸ�ID
        /// </summary>
        public int GetChannelParentId(int classId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select top 1 ParentId from dt_Channel");
            strSql.Append(" where Id=" + classId);
            return Convert.ToInt32(DbHelperSQL.GetSingle(strSql.ToString()));
        }

		/// <summary>
		/// ����һ������
		/// </summary>
		public int Add(DtCms.Model.Channel model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into dt_Channel(");
			strSql.Append("Title,ParentId,ClassList,ClassLayer,SortId,PageUrl,KindId)");
			strSql.Append(" values (");
			strSql.Append("@Title,@ParentId,@ClassList,@ClassLayer,@SortId,@PageUrl,@KindId)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@Title", SqlDbType.NVarChar,50),
					new SqlParameter("@ParentId", SqlDbType.Int,4),
					new SqlParameter("@ClassList", SqlDbType.NVarChar,500),
					new SqlParameter("@ClassLayer", SqlDbType.Int,4),
					new SqlParameter("@SortId", SqlDbType.Int,4),
					new SqlParameter("@PageUrl", SqlDbType.NVarChar,250),
					new SqlParameter("@KindId", SqlDbType.Int,4)};
			parameters[0].Value = model.Title;
			parameters[1].Value = model.ParentId;
			parameters[2].Value = model.ClassList;
			parameters[3].Value = model.ClassLayer;
			parameters[4].Value = model.SortId;
			parameters[5].Value = model.PageUrl;
			parameters[6].Value = model.KindId;

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
		/// ����һ������
		/// </summary>
		public bool Update(DtCms.Model.Channel model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update dt_Channel set ");
			strSql.Append("Title=@Title,");
			strSql.Append("ParentId=@ParentId,");
			strSql.Append("ClassList=@ClassList,");
			strSql.Append("ClassLayer=@ClassLayer,");
			strSql.Append("SortId=@SortId,");
			strSql.Append("PageUrl=@PageUrl,");
			strSql.Append("KindId=@KindId");
			strSql.Append(" where Id=@Id");
			SqlParameter[] parameters = {
					new SqlParameter("@Id", SqlDbType.Int,4),
					new SqlParameter("@Title", SqlDbType.NVarChar,50),
					new SqlParameter("@ParentId", SqlDbType.Int,4),
					new SqlParameter("@ClassList", SqlDbType.NVarChar,500),
					new SqlParameter("@ClassLayer", SqlDbType.Int,4),
					new SqlParameter("@SortId", SqlDbType.Int,4),
					new SqlParameter("@PageUrl", SqlDbType.NVarChar,250),
					new SqlParameter("@KindId", SqlDbType.Int,4)};
			parameters[0].Value = model.Id;
			parameters[1].Value = model.Title;
			parameters[2].Value = model.ParentId;
			parameters[3].Value = model.ClassList;
			parameters[4].Value = model.ClassLayer;
			parameters[5].Value = model.SortId;
			parameters[6].Value = model.PageUrl;
			parameters[7].Value = model.KindId;

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
        /// ɾ������Ŀ���༰�������·�������
        /// </summary>
        public void Delete(int Id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from dt_Channel ");
            strSql.Append(" where ClassList like '%," + Id + ",%' ");

            DbHelperSQL.Query(strSql.ToString());
        }


		/// <summary>
		/// �õ�һ������ʵ��
		/// </summary>
		public DtCms.Model.Channel GetModel(int Id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 Id,Title,ParentId,ClassList,ClassLayer,SortId,PageUrl,KindId from dt_Channel ");
			strSql.Append(" where Id=@Id");
			SqlParameter[] parameters = {
					new SqlParameter("@Id", SqlDbType.Int,4)
            };
			parameters[0].Value = Id;

			DtCms.Model.Channel model=new DtCms.Model.Channel();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["Id"].ToString()!="")
				{
					model.Id=int.Parse(ds.Tables[0].Rows[0]["Id"].ToString());
				}
				model.Title=ds.Tables[0].Rows[0]["Title"].ToString();
				if(ds.Tables[0].Rows[0]["ParentId"].ToString()!="")
				{
					model.ParentId=int.Parse(ds.Tables[0].Rows[0]["ParentId"].ToString());
				}
				model.ClassList=ds.Tables[0].Rows[0]["ClassList"].ToString();
				if(ds.Tables[0].Rows[0]["ClassLayer"].ToString()!="")
				{
					model.ClassLayer=int.Parse(ds.Tables[0].Rows[0]["ClassLayer"].ToString());
				}
				if(ds.Tables[0].Rows[0]["SortId"].ToString()!="")
				{
					model.SortId=int.Parse(ds.Tables[0].Rows[0]["SortId"].ToString());
				}
				model.PageUrl=ds.Tables[0].Rows[0]["PageUrl"].ToString();
				if(ds.Tables[0].Rows[0]["KindId"].ToString()!="")
				{
					model.KindId=int.Parse(ds.Tables[0].Rows[0]["KindId"].ToString());
				}
				return model;
			}
			else
			{
				return null;
			}
		}

        /// <summary>
        /// ȡ��������Ŀ�б�
        /// </summary>
        /// <param name="PId">��ID</param>
        /// <param name="KId">����ID</param>
        /// <returns></returns>
        public DataTable GetList(int PId, int KId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select Id,Title,ParentId,ClassList,ClassLayer,SortId,PageUrl,KindId from dt_Channel");
            strSql.Append(" where KindId=" + KId + " order by SortId asc,Id desc");
            DataSet ds = DbHelperSQL.Query(strSql.ToString());
            DataTable oldData = ds.Tables[0] as DataTable;
            if (oldData == null)
            {
                return null;
            }

            //���ƽṹ
            DataTable newData = oldData.Clone();
            //���õ�����ϳ�DAGATABLE
            GetChannelChild(oldData, newData, PId, KId);
            return newData;
        }

        /// <summary>
        /// ���ڴ���ȡ�������¼���Ŀ�б����������
        /// </summary>
        private void GetChannelChild(DataTable oldData, DataTable newData, int PId, int KId)
        {
            DataRow[] dr = oldData.Select("ParentId=" + PId);
            for (int i = 0; i < dr.Length; i++)
            {
                //���һ������
                DataRow row = newData.NewRow();
                row["Id"] = int.Parse(dr[i]["Id"].ToString());
                row["Title"] = dr[i]["Title"].ToString();
                row["ParentId"] = int.Parse(dr[i]["ParentId"].ToString());
                row["ClassList"] = dr[i]["ClassList"].ToString();
                row["ClassLayer"] = int.Parse(dr[i]["ClassLayer"].ToString());
                row["SortId"] = int.Parse(dr[i]["SortId"].ToString());
                row["PageUrl"] = dr[i]["PageUrl"].ToString();
                row["KindId"] = int.Parse(dr[i]["KindId"].ToString());
                newData.Rows.Add(row);
                //�����������
                this.GetChannelChild(oldData, newData, int.Parse(dr[i]["Id"].ToString()), KId);
            }
        }

        /// <summary>
        /// ȡ�ø���Ŀ�µ���������Ŀ��ID
        /// </summary>
        /// <param name="classId"></param>
        /// <returns></returns>
        public DataSet GetChannelListByClassId(int classId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select top 1 ClassList,ClassLayer from dt_Channel");
            strSql.Append(" where Id=" + classId + " ");
            return DbHelperSQL.Query(strSql.ToString());
        }

		#endregion  Method
	}
}

