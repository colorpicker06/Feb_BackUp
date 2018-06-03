using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Feb.Models
{
    public class CWorry
    {
        public int id { get; set; }
        public int category_fk { get; set; }
        public int l_category_fk { get; set; }
        public string title { get; set; }
        public string content { get; set; }
        public int writer { get; set; }
        public DateTime reg_date { get; set; }
        public int report_chk { get; set; }
    }
}