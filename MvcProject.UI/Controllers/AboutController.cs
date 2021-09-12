using MvcProject.Business.Concrete;
using MvcProject.DataAccess.Abstract;
using MvcProject.DataAccess.EntityFramework;
using MvcProject.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProject.UI.Controllers
{
    public class AboutController : Controller
    {
        AboutManager am = new AboutManager(new EfAboutDal());
        public ActionResult Index()
        {
            var aboutValues = am.GetAboutListBL();
            return View(aboutValues);
        }

        [HttpGet]
        public ActionResult AddAbout()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddAbout(About item)
        {
            am.AboutAddBL(item);
            return RedirectToAction("Index");
        }

        public PartialViewResult AboutPartial(About item)
        {
            return PartialView();
        }
    }
}