using System;
using System.Collections.Generic;
using System.Text;

namespace DtCms.Model
{
    public class Member
    {
        private int _id;
        private string _username;
        private string _pwd;
        private string _turename;
        private string _usertel;
        private string _userqq;
        private DateTime _addtime = DateTime.Now;
        private string _team;
        private string _isATMember;
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
        public string Usertel
        {
            set { _usertel = value; }
            get { return _usertel; }
        }
        public string Userqq
        {
            set { _userqq = value; }
            get { return _userqq; }
        }

        public DateTime AddTime
        {
            set { _addtime = value; }
            get { return _addtime; }
        }
        public string Team
        {
            set { _team = value; }
            get { return _team; }
        }
        public string IsATMember
        {
            set { _isATMember = value; }
            get { return _isATMember; }
        }
    }
}
