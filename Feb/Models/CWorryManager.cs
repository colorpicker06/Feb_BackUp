using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Feb.Models
{
    public class CWorryManager
    {
        LUserDataContext theUserContext;
        
        public CWorryManager()
        {
            theUserContext = new LUserDataContext();
        }

        //worry 리스트 불러오기
        public List<CWorry> GetWorrys() //DB의 정보를
        {
            IQueryable<Feb_Worry> tmpR = theUserContext.Feb_Worry.OrderByDescending(x => x.id);  //the id를 기준으로 내림차순으로 select해온다는 것

            List<Feb_Worry> tmpL = tmpR.ToList<Feb_Worry>();
            List<CWorry> resUsers = new List<CWorry>();
            foreach (Feb_Worry iter in tmpL)
            {
                CWorry tmpUser = new CWorry();
                tmpUser.id = iter.id;
                tmpUser.category_fk = iter.category_fk;
                tmpUser.l_category_fk = iter.l_category_fk;
                tmpUser.title = iter.title;
                tmpUser.content = iter.content;
                tmpUser.writer = iter.writer;
                tmpUser.reg_date = iter.reg_date;
                resUsers.Add(tmpUser);
            }
            return resUsers;  //외부에서 이 정보를 출력할거니까 리스트 채로 넘기는 함수
        }

        //worry db에 추가하기
        public int AddWorry(ref CWorry aWorry)
        {

            Feb_Worry tmp_worry = new Feb_Worry();

            tmp_worry.title = aWorry.title;
            tmp_worry.content = aWorry.content;
            tmp_worry.writer = aWorry.writer;
            tmp_worry.reg_date = DateTime.Now;
            tmp_worry.report_chk = 0;

            theUserContext.Feb_Worry.InsertOnSubmit(tmp_worry);
            theUserContext.SubmitChanges();

            return 1;

        } //AddWorry
    }
}