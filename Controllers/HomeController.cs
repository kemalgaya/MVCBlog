using BusinessLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCBlog.Controllers
{
    [AllowAnonymous]
    public class HomeController : Controller
    {
        BlogManager bm = new BlogManager();
        public ActionResult Index()
        {
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
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}