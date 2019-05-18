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

            var ListDetails = dbcontext.News.Select(x => new { x.Title, x.Content, x.CreateBy, x.CreateDate }).ToList();
            return Json(ListDetails, JsonRequestBehavior.AllowGet);
        }
        public JsonResult ListNews()
        {
            var ListNews = dbcontext.News.OrderByDescending(x => x.CreateBy).Where(x=>x.status==1).Select(x => new { x.Title, x.shortContent, x.CreateBy, x.CreateDate,x.UrlRepresent }).ToList();
            return Json(ListNews, JsonRequestBehavior.AllowGet);
        }
    }
}