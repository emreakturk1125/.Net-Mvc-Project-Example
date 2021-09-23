using MvcProject.UI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProject.UI.Controllers
{
    [AllowAnonymous]
    public class ChartController : Controller
    {
        // GET: Chart
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult CategoryChart()
        {
            return Json(CategoryBlockList(),JsonRequestBehavior.AllowGet);
        }
         
        public ActionResult ProductChart()
        {
            return Json(ProductBlockList(), JsonRequestBehavior.AllowGet);
        }

        public List<ProductClass> ProductBlockList()
        {
              
            List<ProductClass> pc = new List<ProductClass>()
            {
                new ProductClass(){
                ProductName = "Elektronik",
                ProductCount = 8
                },
                 new ProductClass(){
                ProductName = "Giyim",
                ProductCount = 5
                },
                  new ProductClass(){
                ProductName = "Mutfak",
                ProductCount = 7
                },
                   new ProductClass(){
                ProductName = "Aksesuar",
                ProductCount = 4
                }
            };
            return pc;
        }

        public List<CategoryClass> CategoryBlockList()
        {
            List<CategoryClass> ct = new List<CategoryClass>()
            {
                new CategoryClass(){ 
                CategoryName = "Yazılım",
                CategoryCount = 5
                },
                 new CategoryClass(){
                CategoryName = "Seyahat",
                CategoryCount = 5
                },
                  new CategoryClass(){
                CategoryName = "Teknoloji",
                CategoryCount = 5
                },
                   new CategoryClass(){
                CategoryName = "Spo",
                CategoryCount = 5
                }
            };
            return ct;
        }
    }
}