using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebClubUniversity.Controllers
{
    public class IndexController : Controller
    {
        WebClubDbContext dbcontext = new WebClubDbContext();
        // GET: Index
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult Detail(int id)
        {

            var info = dbcontext.News.Find(id);
            return Json(info, JsonRequestBehavior.AllowGet);
        }
        public JsonResult ListNews()
        {
            //var ListNews = dbcontext.News.OrderByDescending(x => x.CreateBy).Select(x => new { x.Title, x.shortContent, x.CreateBy, x.CreateDate,x.UrlRepresent }).ToList();
            var listNews = dbcontext.News.OrderByDescending(x => x.CreateBy).ToList();
            return Json(listNews, JsonRequestBehavior.AllowGet);
        }
    }
}