using BusinessLayer.Concrete;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCBlog.Controllers
{
    public class AdminController : Controller
    {
        AdminManager adm = new AdminManager();
        // GET: Admin
        public ActionResult AdminList()
        {
            var adminlist = adm.GetAll();
            return View(adminlist);
        }
        [HttpGet]
        public ActionResult AdminEdit(int id)
        {
            Admin admin = adm.FindAdmin(id);
            return View(admin);
        }
        [HttpPost]
        public ActionResult AdminEdit(Admin p)
        {
            adm.UpdateAdmin(p);
            return RedirectToAction("AdminList");
        }
        public ActionResult DeleteAdmin(int id)
        {
            adm.DeleteAdmin(id);
            return RedirectToAction("AdminList");
        }
        public ActionResult AdminAdd(Admin p)
        {
            adm.AdminAdd(p);
            return RedirectToAction("AdminList");
        }
    }
}