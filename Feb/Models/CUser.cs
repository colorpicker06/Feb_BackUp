using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Feb.Models
{
    public class CUser
    {
        public int id { get; set; }
        public string email { get; set; }
        public string pw { get; set; }
        public string nickname { get; set; }
        public bool leave_chk { get; set; }
        public bool report_chk { get; set; }
    }
}



