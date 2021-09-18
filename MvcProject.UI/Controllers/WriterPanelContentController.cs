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
    public class WriterPanelContentController : Controller
    {
        ContentManager cm = new ContentManager(new EfContentDal());
        WriterManager wm = new WriterManager(new EfWriterDal());
        public ActionResult MyContent()
        {
            string param = (string)Session["WriterMail"];
            int writerId = wm.GetWriterByEmailBL(param).WriterId;
            var contentListValue = cm.GetContentListByWriterIdBL(writerId);
            return View(contentListValue);
        }
    }
}