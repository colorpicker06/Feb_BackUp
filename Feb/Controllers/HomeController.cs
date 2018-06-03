using Feb.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Feb.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index() 
        {
            //ViewBag.theUsers = CInstance.theUserManager.GetUsers();
            //ViewBag.bFail = 0;
            return View();
        }

        //인덱스에서 가입
        [HttpPost]
        public ActionResult Index(CUser aUser, string mode)
        {
            Debug.Write("홈컨트롤에서 찍습니다");
            Debug.Write(aUser.email + "," + aUser.pw);
            if (mode.Equals("regist")) // 회원가입일 경우.
            {
                if (!ModelState.IsValid)
                {
                    return (View(aUser));
                }

                int tmp_bool;
                tmp_bool = CInstance.theUserManager.AddUser(ref aUser);
                if (tmp_bool == 1)
                {
                    return RedirectToAction("JoinOK", aUser);
                }
                return View(aUser);
            }

            else//로그인일 경우
            {

                CUser resUser;
                int tmp = CInstance.theUserManager.CheckUser(aUser.email, aUser.pw, out resUser);
                if (tmp == 1) //로그인 성공
                {
                    Session["id"] = resUser.id;
                    return RedirectToAction("List");
                }
                else //로그인 실패
                {
                    return View();
                }

            }
        }

        public ActionResult JoinOK()
        {
            return View();
        }


        public ActionResult Masnager()
        {
            return View();
        }

        public ActionResult Member()
        {
            return View();
        }

        public ActionResult Suggest()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Suggest(CSuggest aSuggest)
        {
            CSuggest tmpSuggest = new CSuggest();
            tmpSuggest.title = aSuggest.title;
            tmpSuggest.content = aSuggest.content;
             tmpSuggest.writer = Int32.Parse(Session["id"].ToString());
           //tmpSuggest.writer = aSuggest.writer;
            tmpSuggest.reg_date = DateTime.Now;
            tmpSuggest.action_chk = 0;

            ViewBag.theUsers = CInstance.theSuggestManager.AddSuggest(ref tmpSuggest);
            return RedirectToAction("Index");
        }

        public ActionResult Category()
        {
            return View();
        }

        public ActionResult Report()
        {
            return View();
        }

        public ActionResult AdminSuggest()
        {
            return View();
        }

        public ActionResult Member_1()
        {
            return View();
        }

        public ActionResult Suggest_1()
        {
            return View();
        }

        public ActionResult Report_1()
        {
            return View();
        }

        public ActionResult List()
        {
            Debug.Write("세션갑니당" + Session["id"]);
            List<CWorry> tmpWorryList = CInstance.theWorryManager.GetWorrys();
            List<CUser> tmpUserList = CInstance.theUserManager.GetUsers();
            
            ViewBag.worryList = tmpWorryList;
            ViewBag.userList = tmpUserList;
            return View();
        }

        public ActionResult WorryDetail()
        {
            return View();
        }

        public ActionResult Write()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Write(CWorry aWorry)
        {//입력값들로 객체생성 CWorry타입
            //tmpWorry 
            CWorry tmpWorry = new CWorry();
            tmpWorry.category_fk = 1;
            tmpWorry.l_category_fk = 1;
            tmpWorry.title = aWorry.title;
            tmpWorry.content = aWorry.content;
            
            tmpWorry.writer = Int32.Parse(Session["id"].ToString());  //이부분을 세션id값으로 받아와야함 근데 index페이지 건드리면 망할까봐
            tmpWorry.reg_date = aWorry.reg_date;
            tmpWorry.report_chk = 1;

            ViewBag.theUsers = CInstance.theWorryManager.AddWorry(ref tmpWorry);
            return RedirectToAction("List");
        }

    }
}