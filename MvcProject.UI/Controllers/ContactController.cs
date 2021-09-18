using MvcProject.Business.Concrete;
using MvcProject.Business.ValidationRules;
using MvcProject.DataAccess.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProject.UI.Controllers
{
    public class ContactController : Controller
    {
        ContactManager cm = new ContactManager(new EfContactDal());
        MessageManager mm = new MessageManager(new EfMessageDal());
        ContactValidator cv = new ContactValidator();
        public ActionResult Index()
        {
            var inboxValues = mm.GetMessageInboxListBL();
            return View(inboxValues);
        }

        public ActionResult GetContactDetails(int id)
        {

            var contactValue = cm.GetContactByIdBL(id);
            return View(contactValue);
        }
    }
}