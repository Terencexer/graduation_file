﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using DtCms.BLL;
using DtCms.DAL;
using DtCms.Model;

namespace DtCms.BLL
{
    public class TeamLeader
    {
        private readonly DtCms.DAL.TeamLeader dal = new DtCms.DAL.TeamLeader();

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            return dal.GetMaxId();
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int Id)
        {
            return dal.Exists(Id);
        }

        /// <summary>
        /// 返回数据总数(分页用到)
        /// </summary>
        public int GetCount(string strWhere)
        {
            return dal.GetCount(strWhere);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(DtCms.Model.TeamLeader model)
        {

            return dal.Add(model);

        }

        /// <summary>
        /// 更新一列数据
        /// </summary>
        public void UpdateField(int Id, string strValue)
        {
            dal.UpdateField(Id, strValue);
        }


        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(DtCms.Model.TeamLeader model)
        {

            return dal.Update(model);
        }


        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int Id)
        {

            return dal.Delete(Id);

        }

        /// <summary>
        /// 删除多条数据
        /// </summary>
        public bool DeleteList(string Idlist)
        {
            return dal.DeleteList(Idlist);
        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public DtCms.Model.TeamLeader GetModel(int Id)
        {


            return dal.GetModel(Id);
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            return dal.GetList(strWhere);
        }

        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public DataSet GetList(int Top, string strWhere, string filedOrder)
        {

            return dal.GetList(Top, strWhere, filedOrder);
        }

        /// <summary>
        /// 获得查询分页数据
        /// </summary>
        public DataSet GetPageList(int pageSize, int currentPage, string strWhere, string filedOrder)
        {
            return dal.GetPageList(pageSize, currentPage, strWhere, filedOrder);
        }

        public DtCms.Model.TeamLeader QueryTeacher(string Username)
        {
            return dal.QueryOneRecord(Username);
        }

        public string GetAppName(string Username)
        {
            DtCms.Model.TeamLeader teacher = dal.QueryOneRecord(Username);
            if (teacher != null)
                return teacher.Turename;
            return null;
            //return (dal.QueryOneRecord(Username)).Turename;


        }


    }
}
