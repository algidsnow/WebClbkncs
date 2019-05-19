using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebClubUniversity.Controllers
{
    public class MembersController : Controller
    {
        WebClubDbContext dbcontext = new WebClubDbContext();
        // GET: Members
        public ActionResult Index()
        {
            return View();
        }
        public JsonResult ListMember()
        {
            var listMembers = dbcontext.Members.ToList().OrderByDescending(x => x.prioritize).Where(x => x.status == 1).Select(x => new { x.name, x.age, x.position, x.UrlPresentMember });
            return Json(listMembers, JsonRequestBehavior.AllowGet);
        }
    }
    
}