using FluentValidation.Results;
using MvcProject.Business.Concrete;
using MvcProject.Business.ValidationRules;
using MvcProject.DataAccess.EntityFramework;
using MvcProject.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProject.UI.Controllers
{
    public class WriterController : Controller
    {
        WriterManager wm = new WriterManager(new EfWriterDal());

        public ActionResult Index()
        {
            var writerValues = wm.GetWriterListBL();
            return View(writerValues);
        }

        [HttpGet]
        public ActionResult AddWriter()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddWriter(Writer item)
        {
            WriterValidator writerValidator = new WriterValidator();
            ValidationResult result = writerValidator.Validate(item);

            if (result.IsValid)
            {
                wm.WriterAddBL(item);
                return RedirectToAction("Index");
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
        public ActionResult EditWriter(int id)
        {
            var writeValue = wm.GetWriterByIdBL(id);
            return View(writeValue);
        }

        [HttpPost]
        public ActionResult EditWriter(Writer item)
        {
            WriterValidator writerValidator = new WriterValidator();
            ValidationResult result = writerValidator.Validate(item);

            if (result.IsValid)
            {
                wm.WriterUpdateBL(item);
                return RedirectToAction("Index");
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
    }
}