using System;
using System.Collections.Generic;
using System.Text;

namespace DtCms.Model
{
    public class Societies
    {
        private int _id;
        private string _societiesName;
        private string _societiesRemark;
        private DateTime _addtime = DateTime.Now;

        public int Id
        {
            set { _id = value; }
            get { return _id; }
        }
        public string SocietiesName
        {
            set { _societiesName = value; }
            get { return _societiesName; }
        }
        public string SocietiesRemark
        {
            set { _societiesRemark = value; }
            get { return _societiesRemark; }
        }
        public DateTime AddTime
        {
            set { _addtime = value; }
            get { return _addtime; }
        }
    }
}
