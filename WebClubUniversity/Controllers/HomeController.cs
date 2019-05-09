using Model;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using WebClubUniversity.Authorize;

namespace WebClubUniversity.Controllers
{
    public class HomeController : Controller
    {
        WebClubDbContext dbcontext = new WebClubDbContext();
       [AuthorizeUser(Order =1)]
        public ActionResult Index()
        {
            Session["Authorize"] = 1;
            return View();
        }

        public ActionResult NewsIndex(int page = 1, int pageSize = 10)
        {
            var GetAllNews = dbcontext.News.OrderByDescending(x => x.CreateDate).ToPagedList(page, pageSize);
            return View(GetAllNews);
        }
       
        public ActionResult CreateNews()
        {       
            return View();
        }
        public ActionResult UserLogin()
        {
           
            return View();
        }
        
        [HttpPost]
            public ActionResult UserLogin(string userName,string password)
        {
            try
            {
                Login login1 = new Login();
                login1.UserName = "admin123";
                login1.PassWord = "admin123";
                login1.Roles = 1;
                var hashcodename = Crypto.Hash(login1.PassWord, "MD5");
                dbcontext.Logins.Add(login1);
               
                var hashcode = Crypto.Hash(password, "MD5");
                var login = dbcontext.Logins.SingleOrDefault(x => x.UserName == userName && x.PassWord == password);
                if (login == null )
                {
                    return RedirectToAction("UserLogin");
                }
               
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                return View(e);
            }
            


        }

    }
}