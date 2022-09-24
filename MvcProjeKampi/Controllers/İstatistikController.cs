using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKampi.Controllers
{
    public class İstatistikController : Controller
    {
        CategoryManager cm = new CategoryManager(new EfCategoryDal());
        HeadingManager hm = new HeadingManager(new EfHeadingDal());
        WriterManager wm = new WriterManager(new EfWriterDal());
     
        public ActionResult Index()
        {

            ViewBag.CategoryTotal = cm.GetList().Count(); //category count

            ViewBag.HeadingByCategoryTitle = hm.GetList()
                .Where(x =>
                x.CategoryID == 13).Count(); //title of yazılım

            ViewBag.WriterOfA = wm.GetList().Where(x =>
            x.WriterName.Contains("a") || x.WriterName.Contains("A")).Count(); // writer of "a"

            ViewBag.CategoryWithMostTitles = cm.GetList().Where(x => x.CategoryID == (hm.GetList()
            .GroupBy(h => h.CategoryID).OrderByDescending(z => z.Count()).Select(y => y.Key)
            .FirstOrDefault())).Select(k => k.CategoryName).FirstOrDefault(); //category with the most titles

           int catgoryOfTrue = cm.GetList().Where(x => x.CategoryStatus == true).Count();
           int catgoryOfFalse = cm.GetList().Where(x => x.CategoryStatus == false).Count();

            int categoryTrueNegativeFalse = catgoryOfTrue - catgoryOfFalse;

            ViewBag.CategoryTrueAndFalse = categoryTrueNegativeFalse;

            return View();
        }

    }
}