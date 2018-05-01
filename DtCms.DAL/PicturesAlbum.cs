using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using DtCms.DBUtility;
namespace DtCms.DAL
{
	/// <summary>
	/// ���ݷ�����:ͼ�����
	/// </summary>
	public partial class PicturesAlbum
	{
		public PicturesAlbum()
		{}
		#region  Method

		/// <summary>
		/// �õ����ID
		/// </summary>
        public int GetMaxId()
        {
            return DbHelperSQL.GetMaxID("Id", "dt_PicturesAlbum");
        }

        /// <summary>
        /// ������������(��ҳ�õ�)
        /// </summary>
        public int GetCount(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(*) as H ");
            strSql.Append(" from dt_PicturesAlbum ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return Convert.ToInt32(DbHelperSQL.GetSingle(strSql.ToString()));
        }

		/// <summary>
		/// �Ƿ���ڸü�¼
		/// </summary>
		public bool Exists(int Id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from dt_PicturesAlbum");
			strSql.Append(" where Id=@Id ");
			SqlParameter[] parameters = {
					new SqlParameter("@Id", SqlDbType.Int,4)};
			parameters[0].Value = Id;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// ����һ������
		/// </summary>
		public int Add(DtCms.Model.PicturesAlbum model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into dt_PicturesAlbum(");
			strSql.Append("PictureId,ImgUrl)");
			strSql.Append(" values (");
			strSql.Append("@PictureId,@ImgUrl)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@PictureId", SqlDbType.Int,4),
					new SqlParameter("@ImgUrl", SqlDbType.NVarChar,250)};
			parameters[0].Value = model.PictureId;
			parameters[1].Value = model.ImgUrl;

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
		public bool Update(DtCms.Model.PicturesAlbum model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update dt_PicturesAlbum set ");
			strSql.Append("PictureId=@PictureId,");
			strSql.Append("ImgUrl=@ImgUrl");
			strSql.Append(" where Id=@Id");
			SqlParameter[] parameters = {
					new SqlParameter("@Id", SqlDbType.Int,4),
					new SqlParameter("@PictureId", SqlDbType.Int,4),
					new SqlParameter("@ImgUrl", SqlDbType.NVarChar,250)};
			parameters[0].Value = model.Id;
			parameters[1].Value = model.PictureId;
			parameters[2].Value = model.ImgUrl;

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
		/// ɾ��һ������
		/// </summary>
		public bool Delete(int Id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from dt_PicturesAlbum ");
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
		public DtCms.Model.PicturesAlbum GetModel(int Id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 Id,PictureId,ImgUrl from dt_PicturesAlbum ");
			strSql.Append(" where Id=@Id");
			SqlParameter[] parameters = {
					new SqlParameter("@Id", SqlDbType.Int,4)
            };
			parameters[0].Value = Id;

			DtCms.Model.PicturesAlbum model=new DtCms.Model.PicturesAlbum();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["Id"].ToString()!="")
				{
					model.Id=int.Parse(ds.Tables[0].Rows[0]["Id"].ToString());
				}
				if(ds.Tables[0].Rows[0]["PictureId"].ToString()!="")
				{
					model.PictureId=int.Parse(ds.Tables[0].Rows[0]["PictureId"].ToString());
				}
				model.ImgUrl=ds.Tables[0].Rows[0]["ImgUrl"].ToString();
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
			strSql.Append("select Id,PictureId,ImgUrl ");
			strSql.Append(" FROM dt_PicturesAlbum ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
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
			strSql.Append(" Id,PictureId,ImgUrl ");
			strSql.Append(" FROM dt_PicturesAlbum ");
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

