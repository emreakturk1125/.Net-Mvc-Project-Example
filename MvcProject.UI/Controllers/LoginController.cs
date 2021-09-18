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
using System.Web.Security;

namespace MvcProject.UI.Controllers
{
    [AllowAnonymous] // Uygulama bazındaki kontrollerden muaf etmek için kullanılır
    public class LoginController : Controller
    {
        AdminManager am = new AdminManager(new EfAdminDal());
        WriterManager wm = new WriterManager(new EfWriterDal());

        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(Admin item)
        {

            AdminValidator adminValidator = new AdminValidator();
            ValidationResult result = adminValidator.Validate(item);

            if (result.IsValid)
            {
                var adminUserInfo = am.GetAdminBL(item);
                if (adminUserInfo != null)
                {
                    FormsAuthentication.SetAuthCookie(adminUserInfo.AdminUsername, false);
                    Session["AdminUsername"] = adminUserInfo.AdminUsername;
                    return RedirectToAction("Index", "AdminCategory");

                }
                else
                {
                    return RedirectToAction("Index");
                }
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
        public ActionResult WriterLogin()
        {
            return View();
        }

        [HttpPost]
        public ActionResult WriterLogin(Writer item)
        {

            var writerInfo = wm.GetWriterBL(item);
            if (writerInfo != null)
            {
                FormsAuthentication.SetAuthCookie(writerInfo.WriterMail, false);
                Session["WriterMail"] = writerInfo.WriterMail;
                return RedirectToAction("MyContent", "WriterPanelContent");

            }
            else
            {
                return RedirectToAction("WriterLogin");
            }
             
        }
    }
}