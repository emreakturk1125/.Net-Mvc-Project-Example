using MvcProject.Business.Concrete;
using MvcProject.DataAccess.EntityFramework;
using MvcProject.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProject.UI.Controllers
{
    public class WriterPanelController : Controller
    {
        HeadingManager hm = new HeadingManager(new EfHeadingDal());
        CategoryManager cm = new CategoryManager(new EfCategoryDal());
        WriterManager wm = new WriterManager(new EfWriterDal());

        // GET: WriterPanel
        public ActionResult WriterProfile()
        {
            return View();
        }

        [HttpGet]
        public ActionResult MyHeading()
        {
            string param = (string)Session["WriterMail"];
            int writerId = wm.GetWriterByEmailBL(param).WriterId;
            var values = hm.GetHeadingListByWriterIdBL(writerId);
            return View(values);
        }

        [HttpGet]
        public ActionResult NewHeading()
        {
            List<SelectListItem> valueCategory = (from x in cm.GetCategoryListBL()
                                                  select new SelectListItem
                                                  {
                                                      Text = x.CategoryName,
                                                      Value = x.CategoryId.ToString()
                                                  }).ToList();
            ViewBag.vlc = valueCategory;
            return View();
        }

        [HttpPost]
        public ActionResult NewHeading(Heading item)
        {
            string param = (string)Session["WriterMail"];
            int writerId = wm.GetWriterByEmailBL(param).WriterId;

            item.HeadingDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            item.HeadingStatus = true;
            if (String.IsNullOrEmpty(writerId.ToString()))
                item.WriterId = writerId;

            hm.HeadingAddBL(item);
            return RedirectToAction("MyHeading");
        }

        [HttpGet]
        public ActionResult EditHeading(int id)
        {

            List<SelectListItem> valueCategory = (from x in cm.GetCategoryListBL()
                                                  select new SelectListItem
                                                  {
                                                      Text = x.CategoryName,
                                                      Value = x.CategoryId.ToString()
                                                  }).ToList();
            ViewBag.vlc = valueCategory;

            var headingValue = hm.GetHeadingByIdBL(id);
            return View(headingValue);
        }

        [HttpPost]
        public ActionResult EditHeading(Heading item)
        {
            item.HeadingStatus = true;
            hm.HeadingUpdate(item);
            return RedirectToAction("MyHeading");
        }

        public ActionResult DeleteHeading(int id)
        {
            var headingValue = hm.GetHeadingByIdBL(id);
            headingValue.HeadingStatus = false;
            hm.HeadingDelete(headingValue);
            return RedirectToAction("MyHeading");
        }
    }
}