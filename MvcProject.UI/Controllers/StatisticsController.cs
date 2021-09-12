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
    public class StatisticsController : Controller
    {
        CategoryManager cm = new CategoryManager(new EfCategoryDal());
        HeadingManager hm = new HeadingManager(new EfHeadingDal());
        WriterManager wm = new WriterManager(new EfWriterDal());
        public ActionResult Index()
        {
            List<Category> categoryList = cm.GetCategoryListBL();
            List<Heading> headingList = hm.GetHeadingListBL();
            List<Writer> writerList = wm.GetWriterListBL();

            ViewBag.CountOfTotalCategory = categoryList.Count();
            ViewBag.CountHeadingOfSoftwareCategory = headingList.Where(x => x.CategoryId == cm.GetCategoryByNameBL("Yazılım").CategoryId).Count();
            ViewBag.NumberOfAuthorsStartingWithTheLetterA = writerList.Where(x => x.WriterName.ToLower().StartsWith("a")).ToList().Count();

            var results = headingList.
                GroupBy( p => p.CategoryId,p => p.HeadingName,(key, g) => new { CategoryId = key, HeadingCount = g.ToList().Count()}).
                OrderByDescending(x => x.HeadingCount).FirstOrDefault();

            ViewBag.CategoryWithTheMostTitles = categoryList.Where(x => x.CategoryId == results.CategoryId).FirstOrDefault().CategoryName;
            ViewBag.CountOfActiveCategory = categoryList.Where(x => x.CategoryStatus == true).Count();
            ViewBag.CountOfNonActiveCategory = categoryList.Where(x => x.CategoryStatus == false).Count();

            return View();
        }
    }
}