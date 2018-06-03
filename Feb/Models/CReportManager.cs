using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Feb.Models
{
    public class CReportManager
    {
        LUserDataContext theUserContext;

        public CReportManager()
        {
            theUserContext = new LUserDataContext();
        }


    }
}