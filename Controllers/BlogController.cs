using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using PagedList;
using PagedList.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCBlog.Controllers
{

    public class BlogController : Controller
    {
        // GET: Blog
        BlogManager bm = new BlogManager();
        [AllowAnonymous]
        public ActionResult Index()
        {
            return View();
        }
        [AllowAnonymous]
        public PartialViewResult BlogList(int page = 1)
        {
            var bloglist = bm.GetAll().ToPagedList(page,6);

            return PartialView(bloglist);
        }
        [AllowAnonymous]
        public PartialViewResult FeaturedPosts()
        {
            //1. post
           
            var title1 = bm.GetAll().OrderByDescending(z => z.BlogID).Where(x => x.CategoryID == 6).Select(y => y.BlogTitle).FirstOrDefault();
            var image1 = bm.GetAll().OrderByDescending(z => z.BlogID).Where(x => x.CategoryID == 6).Select(y => y.BlogImage).FirstOrDefault();
            var date1 = bm.GetAll().OrderByDescending(z => z.BlogID).Where(x => x.CategoryID == 6).Select(y => y.BlogDate).FirstOrDefault();
            var blogpostid1 = bm.GetAll().OrderByDescending(z => z.BlogID).Where(x => x.CategoryID == 6).Select(y => y.BlogID).FirstOrDefault();

            ViewBag.blogpostid1 = blogpostid1;
            ViewBag.title1 = title1;
            ViewBag.image1 = image1;
            ViewBag.date1 = date1;
            

            //2. post
            var title2 = bm.GetAll().OrderByDescending(z => z.BlogID).Where(x => x.CategoryID == 5).Select(y => y.BlogTitle).FirstOrDefault();
            var image2 = bm.GetAll().OrderByDescending(z => z.BlogID).Where(x => x.CategoryID == 5).Select(y => y.BlogImage).FirstOrDefault();
            var date2 = bm.GetAll().OrderByDescending(z => z.BlogID).Where(x => x.CategoryID == 5).Select(y => y.BlogDate).FirstOrDefault();
            var blogpostid2 = bm.GetAll().OrderByDescending(z => z.BlogID).Where(x => x.CategoryID == 5).Select(y => y.BlogID).FirstOrDefault();

            ViewBag.blogpostid2 = blogpostid2;
            ViewBag.title2 = title2;
            ViewBag.image2 = image2;
            ViewBag.date2 = date2;

            //3. post
            var title3 = bm.GetAll().OrderByDescending(z => z.BlogID).Where(x => x.CategoryID == 4).Select(y => y.BlogTitle).FirstOrDefault();
            var image3 = bm.GetAll().OrderByDescending(z => z.BlogID).Where(x => x.CategoryID == 4).Select(y => y.BlogImage).FirstOrDefault();
            var date3 = bm.GetAll().OrderByDescending(z => z.BlogID).Where(x => x.CategoryID == 4).Select(y => y.BlogDate).FirstOrDefault();
            var blogpostid3 = bm.GetAll().OrderByDescending(z => z.BlogID).Where(x => x.CategoryID == 4).Select(y => y.BlogID).FirstOrDefault();

            ViewBag.blogpostid3 = blogpostid3;
            ViewBag.title3 = title3;
            ViewBag.image3 = image3;
            ViewBag.date3 = date3;

            //4. post
            var title4 = bm.GetAll().OrderByDescending(z => z.BlogID).Where(x => x.CategoryID == 7).Select(y => y.BlogTitle).FirstOrDefault();
            var image4 = bm.GetAll().OrderByDescending(z => z.BlogID).Where(x => x.CategoryID == 7).Select(y => y.BlogImage).FirstOrDefault();
            var date4 = bm.GetAll().OrderByDescending(z => z.BlogID).Where(x => x.CategoryID == 7).Select(y => y.BlogDate).FirstOrDefault();
            var blogpostid4 = bm.GetAll().OrderByDescending(z => z.BlogID).Where(x => x.CategoryID == 7).Select(y => y.BlogID).FirstOrDefault();

            ViewBag.blogpostid4 = blogpostid4;
            ViewBag.title4 = title4;
            ViewBag.image4 = image4;
            ViewBag.date4 = date4;

            //5. post
            var title5 = bm.GetAll().OrderByDescending(z => z.BlogID).Where(x => x.CategoryID == 8).Select(y => y.BlogTitle).FirstOrDefault();
            var image5 = bm.GetAll().OrderByDescending(z => z.BlogID).Where(x => x.CategoryID == 8).Select(y => y.BlogImage).FirstOrDefault();
            var date5 = bm.GetAll().OrderByDescending(z => z.BlogID).Where(x => x.CategoryID == 8).Select(y => y.BlogDate).FirstOrDefault();
            var blogpostid5 = bm.GetAll().OrderByDescending(z => z.BlogID).Where(x => x.CategoryID == 8).Select(y => y.BlogID).FirstOrDefault();

            ViewBag.blogpostid5 = blogpostid5;
            ViewBag.title5 = title5;
            ViewBag.image5 = image5;
            ViewBag.date5 = date5;

            return PartialView();
        }
        [AllowAnonymous]
        public PartialViewResult OtherFeaturedPosts()
        {
            return PartialView();
        }
        //public PartialViewResult MailSubscribe()
        //{
        //    return PartialView();
        //}
        [AllowAnonymous]
        public ActionResult BlogDetails()
        {
            return View();
        }
        [AllowAnonymous]
        public PartialViewResult BlogCover(int id)
        {
            var BlogDetailsList = bm.GetBlogByID(id);
            return PartialView(BlogDetailsList);
           
        }
        [AllowAnonymous]
        public PartialViewResult BlogReadAll(int id)
        {
            var BlogDetailsList = bm.GetBlogByID(id);
            return PartialView(BlogDetailsList);
        }
        [AllowAnonymous]
        public ActionResult BlogByCategory(int id)
        {
            var BlogListByCategory = bm.GetBlogByCategory(id);

            var CategoryName = bm.GetBlogByCategory(id).Select(y => y.Category.CategoryName).FirstOrDefault();
            ViewBag.CategoryName = CategoryName;

            var CategoryDesc = bm.GetBlogByCategory(id).Select(y => y.Category.CategoryDescription).FirstOrDefault();
            ViewBag.CategoryDesc = CategoryDesc;
            return View(BlogListByCategory);
        }
        public ActionResult AdminBlogList()
        {
            var bloglist = bm.GetAll();
            return View(bloglist);
        }
        public ActionResult AdminBlogList2()
        {
            var bloglist = bm.GetAll();
            return View(bloglist);
        }
        [Authorize(Roles ="A")]
        [HttpGet]
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
            return RedirectToAction("AdminBlogList");
        }
        public ActionResult DeleteBlog(int id)
        {
            bm.DeleteBlog(id);
            return RedirectToAction("AdminBlogList");
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
            return RedirectToAction("AdminBlogList");
        }
        public ActionResult GetCommentByBlog(int id)
        {
            CommentManager cm = new CommentManager();
            var commentlist = cm.CommentByBlog(id);
            return View(commentlist);
        }
        public ActionResult AuthorBlogList(int id)
        {

            var blogs = bm.GetBlogByAuthor(id);
            return View(blogs);
        }
    }
}