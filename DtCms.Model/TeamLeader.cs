using System;
using System.Collections.Generic;
using System.Text;

namespace DtCms.Model
{
    public class TeamLeader
    {
        private int _id;
        private string _username;
        private string _turename;
        private string _team;
        private string _pwd;
        private string _leadertel;
        private DateTime _starttime;
        private DateTime _endtime;

        public int Id
        {
            set { _id = value; }
            get { return _id; }
        }
        public string Username
        {
            set { _username = value; }
            get { return _username; }
        }
        public string Team
        {
            set { _team = value; }
            get { return _team; }
        }
        public string Pwd
        {
            set { _pwd = value; }
            get { return _pwd; }
        }
        public string Turename
        {
            set { _turename = value; }
            get { return _turename; }
        }
        public string LeaderTel
        {
            set { _leadertel = value; }
            get { return _leadertel; }
        }

       
        public DateTime StartTime
        {
            set { _starttime = value; }
            get { return _starttime; }
        }
        public DateTime EndTime
        {
            set { _endtime = value; }
            get { return _endtime; }
        }
    }
}
