using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKampi.Controllers
{
    public class HeadingController : Controller
    {
        HeadingManager hm = new HeadingManager(new EfHeadingDal());
        CategoryManager cm = new CategoryManager(new EfCategoryDal());
        WriterManager wm = new WriterManager(new EfWriterDal());
        HeadingValidator headingValidator = new HeadingValidator();
        // GET: Heading
        public ActionResult Index()
        {
            var headingvalues = hm.GetList();
            return View(headingvalues);
        }


        [HttpGet]
        public ActionResult AddHeading()
        {
            List<SelectListItem> valuecategory = (
                from x in cm.GetList()
                select new SelectListItem
                {
                    Text = x.CategoryName,
                    Value = x.CategoryID.ToString()
                }).ToList();
            List<SelectListItem> valuewriter = (
                from x in wm.GetList()
                select new SelectListItem
                {
                    Text = x.WriterName + " "+ x.WriterSurName,
                    Value = x.WriterID.ToString()
                }
                ).ToList();
            ViewBag.vlc = valuecategory;
            ViewBag.vlw = valuewriter;
            return View();
        }

        [HttpPost]
        public ActionResult AddHeading(Heading p)
        {

            ValidationResult results = headingValidator.Validate(p);

            if (results.IsValid)
            {
                p.HeadingDate = DateTime.Parse(DateTime.Now.ToShortDateString());
                hm.HeadingAdd(p);
                return RedirectToAction("Index");
            }
            else
            {
                foreach (var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();
        }

        [HttpGet]
        public ActionResult EditHeading(int id)
        {
            List<SelectListItem> valuecategory = (
              from x in cm.GetList()
              select new SelectListItem
              {
                  Text = x.CategoryName,
                  Value = x.CategoryID.ToString()
              }).ToList();
            List<SelectListItem> valuewriter = (
                from x in wm.GetList()
                select new SelectListItem
                {
                    Text = x.WriterName + " " + x.WriterSurName,
                    Value = x.WriterID.ToString()
                }
                ).ToList();
            ViewBag.vlc = valuecategory;
            var headingvalue = hm.GetByID(id);
            return View(headingvalue);
        }

        [HttpPost]
        public ActionResult EditHeading(Heading p)
        {

            ValidationResult results = headingValidator.Validate(p);

            if (results.IsValid)
            {
                hm.HeadingUpdate(p);
                return RedirectToAction("Index");
            }
            else
            {
                foreach (var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();

        }

        public ActionResult DeleteHeading (int id)
        {
            var HeadingValue = hm.GetByID(id);
            HeadingValue.HeadingStatus = false;
            hm.HeadingDelete(HeadingValue);
            return RedirectToAction("index");
        }

       
    }
}