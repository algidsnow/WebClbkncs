using Model;
using PagedList;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebClubUniversity.Controllers
{
    public class ManageMemberController : Controller
    {
        // GET: ManageMember
        WebClubDbContext dbcontext = new WebClubDbContext();
        public ActionResult Index(int page = 1, int pageSize = 10)
        {
            var ListMember = dbcontext.Members.OrderByDescending(x => x.prioritize).Where(x=>x.status==1).ToPagedList(page, pageSize);
            return View(ListMember);
        }

        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Member member, HttpPostedFileBase Url)
        { 
            string fileName = "";
            try
            {
                if (Url != null && Url.ContentLength > 0)

                {
                    fileName = Path.GetFileName(Url.FileName);
                    string path = Path.Combine(Server.MapPath("/Assets/images"), Path.GetFileName(Url.FileName));
                    Url.SaveAs(path);
                    member.UrlPresentMember = fileName;

                }
            }
            catch (Exception ex)
            {

            }
            dbcontext.Members.Add(member);
            dbcontext.SaveChanges();
            return RedirectToAction("Index");

        }

        public ActionResult Update(int id)
        {
            var update = dbcontext.Members.Find(id);
            return View("Create", update);
        }
        [HttpPost]
        public ActionResult Update(Member member, HttpPostedFileBase ImageUrl, int id)
        {

            var update = dbcontext.Members.Find(id);
            string fileName = "";
            if (ImageUrl == null)
            {
                member.UrlPresentMember = update.UrlPresentMember;
            }
            try
            {

                if (ImageUrl != null && ImageUrl.ContentLength > 0)

                {
                    fileName = Path.GetFileName(ImageUrl.FileName);
                    string path = Path.Combine(Server.MapPath("/Assets/images"), Path.GetFileName(ImageUrl.FileName));
                    ImageUrl.SaveAs(path);
                    member.UrlPresentMember = fileName;
                }
            }
            catch (Exception ex)
            {

            }
            member.idMember = id;
           
            dbcontext.Members.AddOrUpdate(member);
            dbcontext.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            var delete = dbcontext.Members.SingleOrDefault(x => x.idMember == id);
            delete.status = 3;
            dbcontext.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}