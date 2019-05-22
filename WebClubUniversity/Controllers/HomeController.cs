using Model;
using PagedList;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.IO;
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
        [AuthorizeUser(Order = 1)]
        public ActionResult NewsIndex(int page = 1, int pageSize = 10)
        {
            var GetAllNews = dbcontext.News.OrderByDescending(x => x.CreateDate).Where(x => x.status == 1).ToPagedList(page, pageSize);
            return View(GetAllNews);
        }

        public ActionResult CreateNews()
        {
            return View();
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult CreateNews(News news, HttpPostedFileBase ImageUrl)
        {
            news.CreateDate = DateTime.Now.ToString("MM/dd/yyyy");
            news.status = 1;
            news.prioritize = 1;
            var addNews = dbcontext.News.Add(news);
            NewsImage newsImage = new NewsImage();
            string fileName = "";
            try
            {
                if (ImageUrl != null && ImageUrl.ContentLength > 0)

                {
                    fileName = Path.GetFileName(ImageUrl.FileName);
                    string path = Path.Combine(Server.MapPath("/Assets/images"), Path.GetFileName(ImageUrl.FileName));
                    ImageUrl.SaveAs(path);
                    addNews.UrlRepresent = fileName;

                }
            }

            catch (Exception ex)
            {

            }
            dbcontext.SaveChanges();
            return RedirectToAction("NewsIndex");
        }
        public ActionResult UpdateNews(int id)
        {


            var Update = dbcontext.News.Find(id);
            return View(Update);
        }
        [HttpPost, ValidateInput(false)]

        public ActionResult UpdateNews(News news, HttpPostedFileBase ImageUrl, int id)
        {
            var update = dbcontext.News.Find(id);
            news.CreateDate = update.CreateDate;
            string fileName = "";
            if (ImageUrl == null)
            {
                news.UrlRepresent = update.UrlRepresent;
            }
            try
            {

                if (ImageUrl != null && ImageUrl.ContentLength > 0)

                {
                    fileName = Path.GetFileName(ImageUrl.FileName);
                    string path = Path.Combine(Server.MapPath("/Assets/images"), Path.GetFileName(ImageUrl.FileName));
                    ImageUrl.SaveAs(path);
                    news.UrlRepresent = fileName;
                }
            }
            catch (Exception ex)
            {

            }
            news.NewsId = id;
            news.UpdateDate = DateTime.Now.ToString("MM/dd/yyyy");
            dbcontext.News.AddOrUpdate(news);
            dbcontext.SaveChanges();
            return RedirectToAction("NewsIndex");
        }



        public ActionResult UserLogin()
        {
            return View();
        }
        [HttpPost]
        public ActionResult UserLogin(string userName, string password)
        {
            try
            {
                var hashcode = Crypto.Hash(password, "MD5");
                var login = dbcontext.Logins.SingleOrDefault(x => x.UserName == userName && x.PassWord == hashcode);
                
               
                if (login == null)
                {
                    ViewBag.error = "Bạn nhập tài khoản hoặc mật khẩu không chính xác";
                    return View("UserLogin");
                }
                Session["username"] = login.UserName;
                AuthorizeUser.User_Session = login.Roles;
                return RedirectToAction("NewsIndex");
            }
            catch (Exception e)
            {
             
                return View(e);
            }
        }

        public ActionResult CreateUser()
        {
            return View();
        }

        [HttpPost]
      
        public ActionResult CreateUser(FormCollection collection)
        {
            var listUser = dbcontext.Logins.ToList();
            Login user = new Login();
            user.Roles = 1;
            user.UserName = collection["UserName"];
            foreach (var item in listUser)
            {
                if(item.UserName == user.UserName)
                {
                    ViewBag.ErrorUserName = "Tài khoản đã tồn tại";
                    return View("CreateUser");
                }
            }
            var password = Crypto.Hash(collection["PassWord"], "MD5");
            var checkpass = Crypto.Hash(collection["checkPassword"], "MD5");
            if (password != checkpass)
            {
                ViewBag.check = "Mật khẩu và mật khẩu nhập lại không giống nhau!!!";
                return View("CreateUser");
            }
            else
            user.PassWord = password;
            dbcontext.Logins.Add(user);
            dbcontext.SaveChanges();
            return RedirectToAction("NewsIndex");
        }

        public ActionResult DeleteNews(int id)
        {
            var delete = dbcontext.News.SingleOrDefault(x => x.NewsId == id);
            delete.status = 3;
            dbcontext.SaveChanges();
            return RedirectToAction("NewsIndex");
        }
        public ActionResult LoginError()
        {


            return View();
        }

        public ActionResult Change()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Change(FormCollection frm)
        {
            var username = Session["username"].ToString();


            Login login = new Login();
            var user = dbcontext.Logins.SingleOrDefault(x => x.UserName == username);
            var OldPassWord = Crypto.Hash(frm["PassWord"], "MD5");
            if(user.PassWord == OldPassWord)
            {
                ViewBag.checkPassOld = "Mật khẩu cũ nhập vào chưa đúng!!!!";
                return View("Change");
            }
            var newPassWord = Crypto.Hash(frm["NewPassWord"] ,"MD5");
            var checkPassWord = Crypto.Hash(frm["CheckPassWord"], "MD5");
            if(user.PassWord != newPassWord && newPassWord == checkPassWord)
            {
                login.UserName = user.UserName;
                login.Roles = user.Roles;
                login.PassWord = newPassWord;
                dbcontext.Logins.AddOrUpdate(login);
                dbcontext.SaveChanges();
                return RedirectToAction("UserLogin");
            }
            ViewBag.check = "Mật khẩu mới và mật khẩu nhập lại không giống nhau!!!";
            return View("Change");
        }

        public ActionResult LogOut()
        {
            Session["username"] = null;
            return RedirectToAction("UserLogin");
        }


    }
}