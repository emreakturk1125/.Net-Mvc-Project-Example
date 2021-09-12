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
    public class MessageController : Controller
    {
        MessageManager mm = new MessageManager(new EfMessageDal());

        public ActionResult Inbox()
        {
            var messageList = mm.GetMessageInboxListBL();
            return View(messageList);
        }

        public ActionResult Sendbox()
        {
            var messageList = mm.GetMessageSendListBL();
            return View(messageList);
        }

        public ActionResult Draftbox()
        {
            var messageList = mm.GetMessageDraftListBL();
            return View(messageList);
        }

        public ActionResult GetInboxMessageDetails(int id)
        {
            var messageValue = mm.GetMessageByIdBL(id);
            return View(messageValue);
        }

        public ActionResult GetSendboxMessageDetails(int id)
        {
            var messageValue = mm.GetMessageByIdBL(id);
            return View(messageValue);
        }


        [HttpGet]
        public ActionResult NewMessage()
        {
            return View();
        }

        [HttpPost]
        public ActionResult NewMessage(Message item)
        {
            MessageValidator messageValidator = new MessageValidator();
            ValidationResult result = messageValidator.Validate(item);

            if (result.IsValid)
            {
                item.MessageDate = Convert.ToDateTime(DateTime.Now.ToShortDateString());
                mm.MessageAddBL(item);
                return RedirectToAction("Sendbox");
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

        public int InboxCount()
        {
            return  mm.GetMessageInboxListBL().Count;
        }

        public int SendboxCount()
        {
            return mm.GetMessageSendListBL().Count;
        }

        public int DraftCount()
        {
            return mm.GetMessageDraftListBL().Count;
        }

    }
}