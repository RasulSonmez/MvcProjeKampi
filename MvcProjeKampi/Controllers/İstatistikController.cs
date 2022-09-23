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
     
        public ActionResult Index()
        {

            ViewBag.CategoryTotal = cm.GetList().Count(); //category count
            ViewBag.HeadingByCategoryTitle = hm.GetList()
                .Where(x =>
                x.CategoryID == 13).Count(); //title of yazılım
            
            return View();
        }

    }
}