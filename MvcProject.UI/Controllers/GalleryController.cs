using MvcProject.Business.Concrete;
using MvcProject.DataAccess.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProject.UI.Controllers
{
    public class GalleryController : Controller
    {
        ImageFileManager cm = new ImageFileManager(new EfImageFileDal());

        public ActionResult Index()
        {
            var imageValues = cm.GetImageFileListBL();
            return View(imageValues);
        }
    }
}