using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Diagnostics;
using System.Linq;
using System.Web;

namespace Feb.Models
{
    public class CUserManager
    {
        LUserDataContext theUserContext;

        public CUserManager()
        {
            theUserContext = new LUserDataContext(); //생성자에서 생성
        } //생성자

        public int AddUser(ref CUser aUser)    //근데 여기서 ref안써도 되지 않나?
        {
            string tmp_email = aUser.email;
            int tmpCount = theUserContext.Feb_member.Where(x => x.email == tmp_email).Count();
            if (tmpCount > 0)
            {
                //같은 이메일 사용자가 있음
                return 0;
            }
            Feb_member tmp_user = new Feb_member();

            tmp_user.email = aUser.email;
            tmp_user.pw = aUser.pw;
            tmp_user.nickname = aUser.nickname;
            tmp_user.leave_chk = aUser.leave_chk ? 1 : 0;
            tmp_user.report_chk = aUser.report_chk ? 1 : 0;

            theUserContext.Feb_member.InsertOnSubmit(tmp_user);
            theUserContext.SubmitChanges();

            return 1;

        } //AddUser



        public int CheckUser(string email, string pw, out CUser aUser)
        {
            Table<Feb_member> users = theUserContext.GetTable<Feb_member>();

            IQueryable<Feb_member> tmpQ = from iter in users
                                          where iter.email == email && iter.pw == pw
                                          select iter;

            if (tmpQ.Count() > 0)
            {
                List<Feb_member> tmpUser = tmpQ.Take(1).ToList();
                aUser = new CUser();

                aUser.id = tmpUser[0].id;
                aUser.email = tmpUser[0].email;
                aUser.pw = tmpUser[0].pw;
                aUser.nickname = tmpUser[0].nickname;
                aUser.leave_chk = tmpUser[0].leave_chk == 1 ? true : false;
                aUser.report_chk = tmpUser[0].report_chk == 1 ? true : false;

                return 1;
            }
            aUser = new CUser();
            return 0;
        }//checkUser

        public List<CUser> GetUsers() //DB의 정보를
        {
            IQueryable<Feb_member> tmpR = theUserContext.Feb_member.OrderByDescending(x => x.id);  //the id를 기준으로 내림차순으로 select해온다는 것

            List<Feb_member> tmpL = tmpR.ToList<Feb_member>();
            List<CUser> resUsers = new List<CUser>();
            foreach (Feb_member iter in tmpL)
            {
                CUser tmpUser = new CUser();
                tmpUser.id = iter.id;
                tmpUser.email = iter.email;
                tmpUser.pw = iter.pw;
                tmpUser.nickname = iter.nickname;
                tmpUser.leave_chk = iter.leave_chk == 1 ? true : false;
                tmpUser.report_chk= iter.report_chk == 1 ? true : false;  //1로저장되어있는건 true로 아닌 것은 false(0)

                resUsers.Add(tmpUser);
            }
            return resUsers;  //외부에서 이 정보를 출력할거니까 리스트 채로 넘기는 함수
        }
    }
}

//private List<CUser> theUsers;  //가입한 유저(CUser)들을 담을 리스트 선언


/*
public List<CUser> GetUsers() //DB의 정보를
{
IQueryable<TUser3109> tmpR = theUserContext.TUser3109.OrderByDescending(x => x.theID);  //the id를 기준으로 내림차순으로 select해온다는 것

List<TUser3109> tmpL = tmpR.ToList<TUser3109>();
List<CUser> resUsers = new List<CUser>();
foreach (TUser3109 iter in tmpL)
{
    CUser tmpUser = new CUser();
    tmpUser.theUniqueID = iter.theUniqueID;
    tmpUser.theID = iter.theID;
    tmpUser.thePW = iter.thePW;
    tmpUser.theName = iter.theName;
    tmpUser.theEmail = iter.theEMail;
    tmpUser.bSubscription = iter.bSubscription == 1 ? true : false;  //1로저장되어있는건 true로 아닌 것은 false(0)
    tmpUser.theDate = iter.theDate;
    resUsers.Add(tmpUser);
}
return resUsers;  //외부에서 이 정보를 출력할거니까 리스트 채로 넘기는 함수
}
public int AddUser(ref CUser aUser)    //근데 여기서 ref안써도 되지 않나?
{
string tmpID = aUser.theID;
int tmpCount = theUserContext.TUser3109.Where(x => x.theID == tmpID).Count();
if (tmpCount > 0)
{
    //같은 아이디가 이미 있음
    return 0;
}
TUser3109 tmpUser = new TUser3109();



tmpUser.theID = aUser.theID;
tmpUser.thePW = aUser.thePW;
tmpUser.theName = aUser.theName;
tmpUser.theEMail = aUser.theEmail;
tmpUser.bSubscription = aUser.bSubscription ? 1 : 0;
tmpUser.theDate = DateTime.Now;

theUserContext.TUser3109.InsertOnSubmit(tmpUser);
theUserContext.SubmitChanges();

aUser.theDate = tmpUser.theDate; //이게 있어야 

//aUser.theDate = tmpUser.theDate;  //시간이 다를 수 있기 때문에 이렇게 복사

return 1;

}

public int CheckUser(string aID, string aPW, out CUser aUser)
{
Table<TUser3109> users = theUserContext.GetTable<TUser3109>();
IQueryable<TUser3109> tmpQ = from iter in users
                             where iter.theID == aID && iter.thePW == aPW
                             select iter;

if (tmpQ.Count() > 0)
{
    List<TUser3109> tmpUser = tmpQ.Take(1).ToList();
    aUser = new CUser();

    aUser.theID = tmpUser[0].theID;
    aUser.thePW = tmpUser[0].thePW;
    aUser.theName = tmpUser[0].theName;
    aUser.theEmail = tmpUser[0].theEMail;
    aUser.bSubscription = tmpUser[0].bSubscription == 1 ? true : false;
    aUser.theDate = tmpUser[0].theDate;

    return 1;
}
/*
foreach(CUser iter in theUsers)
{
    if(iter.theID.Equals(aID) && iter.thePW.Equals(aPW))
    {
        return 1;
    }
}

aUser = new CUser();
return 0;
}
}
} */
