using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Feb.Models
{
    public class CInstance
    {
        public static CUserManager theUserManager;
        public static CWorryManager theWorryManager;
        public static CSuggestManager theSuggestManager;

        private static int bInit;

        public static void Initialize()
        {
            theSuggestManager = new CSuggestManager();
            theWorryManager = new CWorryManager();
            if (bInit == 0)
            {
                theUserManager = new CUserManager();
            }
            bInit = 1;  //딱 한번만 실행하게 해둠
        } 
    }
}