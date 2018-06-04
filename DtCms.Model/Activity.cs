using System;
using System.Collections.Generic;
using System.Text;

namespace DtCms.Model
{
    public class Activity
    {
        public string ActivityId { get; set; }
        public string Applicant { get; set; }
        public string Title { get; set; }
        public string Place { get; set; }
        public string CheckStatus { get; set; }
        public string ASuggestion { get; set; }
        public string AConten { get; set; }
        public string AInTrodatction { get; set; }
        public string Preparation { get; set; }
        public string Middle { get; set; }
        public string LastPre { get; set; }
        public int Budget { get; set; }

        public int SuperVIPNum { get; set; }
        public int VIPNum { get; set; }
        public int CommonNum { get; set; }
        public int StandingNum { get; set; }
        public DateTime ATime { get; set; }
        private DateTime _addtime = DateTime.Now;
        public string TicketStatus  { get; set; }

        public DateTime AddTime
        {
            set { _addtime = value; }
            get { return _addtime; }
        }

   
    }
}
