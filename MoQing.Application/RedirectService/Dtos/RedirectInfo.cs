using System;
using System.Collections.Generic;
using System.Text;

namespace MoQing.Application
{
    public class RedirectInfo
    {
        public int ID { get; set; }
        public string LongLinks { get; set; }
        public string ShortLinks { get; set; }
        public int CreateUserID { get; set; }
        public DateTime CreateTime { get; set; }
        public int IsDelete { get; set; }
        public int IsEnable { get; set; }
    }
}
