﻿using MvcProject.Business.Concrete;
using MvcProject.DataAccess.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProject.UI.Controllers
{
    public class ContentController : Controller
    {
        ContentManager cm = new ContentManager(new EfContentDal()); 
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult ContentByHeading(int id)
        {
            var contentListValue = cm.GetContentListByHeadingIdBL(id);
            return View(contentListValue);
        }
    }
}