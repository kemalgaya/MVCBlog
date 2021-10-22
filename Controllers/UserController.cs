using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace MVCBlog.Controllers
{
    [Authorize]
    public class UserController : Controller
    {
        // GET: UserController
        BlogManager bm = new BlogManager();
        UserProfileManager userprofile = new UserProfileManager();
        public ActionResult Index()
        {


            return View();
        }
        public PartialViewResult Partial1(string p)
        {
            p = (string)Session["Mail"];

            var profilevalues = userprofile.GetAuthorByMail(p);
            return PartialView(profilevalues);
        }

        public ActionResult UpdateUserProfile(Author p)
        {
            userprofile.EditAuthor(p);
            return RedirectToAction("Index");
        }

        public ActionResult BlogList(string p)
        {
            p = (string)Session["Mail"];
            Context c = new Context();
            int id = c.Author.Where(x => x.MailAdress == p).Select(y => y.AuthorID).FirstOrDefault();
            var blogs = userprofile.GetBlogByAuthor(id);
            return View(blogs);
        }
        [HttpGet]
        public ActionResult UpdateBlog(int id)
        {
            Context c = new Context();
            
            List<SelectListItem> category = (from x in c.Categories.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = x.CategoryName,
                                                 Value = x.CategoryID.ToString()
                                             }).ToList();
            List<SelectListItem> author = (from x in c.Author.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.AuthorName,
                                               Value = x.AuthorID.ToString()
                                           }).ToList();

            ViewBag.values1 = category;

            ViewBag.values2 = author;
            Blog blogs = bm.FindBlog(id);
            return View(blogs);
        }
        [HttpPost]
        public ActionResult UpdateBlog(Blog p)
        {
            bm.UpdateBlog(p);
            return RedirectToAction("BlogList");
        }

        public ActionResult AddNewBlog()
        {
            Context c = new Context();
            //Author a = new Author();
            List<SelectListItem> category = (from x in c.Categories.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = x.CategoryName,
                                                 Value = x.CategoryID.ToString()
                                             }).ToList();
            List<SelectListItem> author = (from x in c.Author.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.AuthorName,
                                               Value = x.AuthorID.ToString()
                                           }).ToList();

            ViewBag.values1 = category;

            ViewBag.values2 = author;
            return View();
        }
        [HttpPost]
        public ActionResult AddNewBlog(Blog b)
        {
            bm.BlogAddBL(b);
            return RedirectToAction("BlogList");
        }

        public ActionResult DeleteBlog(int id)
        {
            bm.DeleteBlog(id);
            return RedirectToAction("BlogList");
        }

        public ActionResult GetCommentByBlog(int id)
        {
            CommentManager cm = new CommentManager();
            var commentlist = cm.CommentByBlog(id);
            return View(commentlist);
        }
        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction("AuthorLogin", "Login");
        }


    }
}