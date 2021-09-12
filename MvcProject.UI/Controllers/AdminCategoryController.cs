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
    public class AdminCategoryController : Controller
    {
        CategoryManager cm = new CategoryManager(new EfCategoryDal());

        [Authorize(Roles="B")]   // B rolüne sahip kişiler bu sayfayı görecek
        public ActionResult Index()
        {
            var categoryValues = cm.GetCategoryListBL();
            return View(categoryValues);
        }

        [HttpGet]
        public ActionResult AddCategory()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddCategory(Category item)
        {
            CategoryValidator categoryValidator = new CategoryValidator();
            ValidationResult result = categoryValidator.Validate(item);

            if (result.IsValid)
            {
                cm.CategoryAddBL(item);
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
        public ActionResult DeleteCategory(int id)
        {
            var categoryValue = cm.GetCategoryByIdBL(id);
            cm.CategoryDeleteBL(categoryValue);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult UpdateCategory(int id)
        {
            var categoryValue = cm.GetCategoryByIdBL(id);
            return View(categoryValue);
        }

        [HttpPost]
        public ActionResult UpdateCategory(Category item)
        {
            cm.CategoryUpdateBL(item);
            return RedirectToAction("Index");
        }
    }
}