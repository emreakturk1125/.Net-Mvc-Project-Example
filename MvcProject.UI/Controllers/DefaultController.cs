using MvcProject.Business.Concrete;
using MvcProject.DataAccess.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProject.UI.Controllers
{
    [AllowAnonymous]
    public class DefaultController : Controller
    {
        HeadingManager hm = new HeadingManager(new EfHeadingDal());
        ContentManager cm = new ContentManager(new EfContentDal());
        public PartialViewResult Index(int id = 0)
        {
            var contentList = cm.GetContentListByHeadingIdBL(id);
            return PartialView(contentList);
        }

        public ActionResult Headings()
        {
            var headingList = hm.GetHeadingListBL();
            return View(headingList);
        }
    }
}