using MvcProject.Business.Concrete;
using MvcProject.DataAccess.EntityFramework;
using MvcProject.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using PagedList.Mvc;
using FluentValidation.Results;
using MvcProject.Business.ValidationRules;

namespace MvcProject.UI.Controllers
{
    public class WriterPanelController : Controller
    {
        HeadingManager hm = new HeadingManager(new EfHeadingDal());
        CategoryManager cm = new CategoryManager(new EfCategoryDal());
        WriterManager wm = new WriterManager(new EfWriterDal());

        [HttpGet]
        public ActionResult WriterProfile()
        {
            string param = (string)Session["WriterMail"];
            int writerId = wm.GetWriterByEmailBL(param).WriterId;
            var writerValue = wm.GetWriterByIdBL(writerId);
            return View(writerValue);
        }
         
        [HttpPost]
        public ActionResult WriterProfile(Writer item)
        {
            WriterValidator writerValidator = new WriterValidator();
            ValidationResult result = writerValidator.Validate(item);

            if (result.IsValid)
            {
                wm.WriterUpdateBL(item);
                return RedirectToAction("AllHeading","WriterPanel");
            }
            else
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(error.PropertyName, error.ErrorMessage);
                }
            }
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

        /// <summary>
        /// Paging İşlemi için NuGet den PagedList ve PagedList.Mvc kütüphaneleri proje referanslarına eklenir. View sayfasında da işlemler var
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        public ActionResult AllHeading(int param = 1)
        {
            var headingList = hm.GetHeadingListBL().ToPagedList(param,2);
            return View(headingList);

        }

    }
}