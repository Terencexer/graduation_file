using System;
using System.Collections.Generic;
using System.Text;

namespace DtCms.Model
{
    public class Score
    {
        private int _id;
        private int _quality;
        private int _number;
        private int _atmosphere;
        private int _activities;
        private string _societiesName;
        private DateTime _addtime = DateTime.Now;
        public int Id
        {
            set { _id = value; }
            get { return _id; }
        }
        public int Quality
        {
            set { _quality = value; }
            get { return _quality; }
        }
        public int Number
        {
            set { _number = value; }
            get { return _number; }
        }
        public int Atmosphere
        {
            set { _atmosphere = value; }
            get { return _atmosphere; }
        }
        public int Activities
        {
            set { _activities = value; }
            get { return _activities; }
        }
        public string SocietiesName
        {
            set { _societiesName = value; }
            get { return _societiesName; }
        }
        public DateTime AddTime
        {
            set { _addtime = value; }
            get { return _addtime; }
        }
    }
}
