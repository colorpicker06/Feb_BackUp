using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Feb.Models
{
    public class CSuggestManager
    {
        LUserDataContext theUserContext;

        public CSuggestManager()
        {
            theUserContext = new LUserDataContext();
        }

        //worry db에 추가하기
        public int AddSuggest(ref CSuggest aSuggest)
        {

            Feb_suggest tmp_Suggest = new Feb_suggest();

            tmp_Suggest.title = aSuggest.title;
            tmp_Suggest.content = aSuggest.content;
            tmp_Suggest.reg_date = aSuggest.reg_date;
            tmp_Suggest.writer = aSuggest.writer;
            theUserContext.Feb_suggest.InsertOnSubmit(tmp_Suggest);
            theUserContext.SubmitChanges();

            return 1;

        } //Addsuggest
    }
}