using System;
namespace DtCms.Model
{
    /// <summary>
    /// 系统日志实体类
    /// </summary>
    [Serializable]
    public partial class SystemLog
    {
        public SystemLog()
        { }
        #region Model
        private int _id;
        private string _username;
        private string _title;
        private DateTime _addtime = DateTime.Now;
        /// <summary>
        /// 
        /// </summary>
        public int Id
        {
            set { _id = value; }
            get { return _id; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string UserName
        {
            set { _username = value; }
            get { return _username; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Title
        {
            set { _title = value; }
            get { return _title; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime AddTime
        {
            set { _addtime = value; }
            get { return _addtime; }
        }
        #endregion Model

    }
}