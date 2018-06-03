using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Feb.Models
{
    public class CReport
    {
        public int id { get; set; }
        public int defender { get; set; }
        public int attacker { get; set; }
        public string content { get; set; }
        public int action_chk { get; set; }
        public int action_content { get; set; }
        public int report_type { get; set; }
    }
}