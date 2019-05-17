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


        [HttpPost, ValidateInput(false)]
        public ActionResult CreateNews(News news, HttpPostedFileBase ImageUrl)
        {
            news.CreateDate = DateTime.Now;
            news.UpdateDate = DateTime.Now;
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
                    dbcontext.SaveChanges();
                }
            }

            catch (Exception ex)
            {

            }
            return View("Index");
        }
        public ActionResult UpdateNews(int id)
        {
         var Update =  dbcontext.News.Find(id);
            return View(Update);
        } 
        [HttpPost, ValidateInput(false)]
      
        public ActionResult UpdateNews(News news, HttpPostedFileBase ImageUrl,int id)
        {
            string fileName = "";
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
            dbcontext.News.AddOrUpdate(news);
            dbcontext.SaveChanges();
            return RedirectToAction("Index");
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