using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Feb.Models
{
    public class CSuggest
    {
        public int id { get; set; }
        public int writer { get; set; }
        public DateTime reg_date { get; set; }
        public string title { get; set; }
        public string content { get; set; }
        public int action_chk { get; set; }
    }
}