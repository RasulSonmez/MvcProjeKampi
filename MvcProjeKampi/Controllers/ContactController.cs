using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKampi.Controllers
{
    public class ContactController : Controller
    {
        ContactManager cm = new ContactManager(new EfContactDal());
        MessageManager mm = new MessageManager(new EfMessageDal());
        ContactValidator cv = new ContactValidator();
        // GET: Contact
        public ActionResult Index()
        {
            var contactvalues = cm.GetList();
            return View(contactvalues);
        }

        public ActionResult GetContactDetails (int id)
        {
            var contactvlues = cm.GetByID(id);
            return View(contactvlues);
        }

        public PartialViewResult MessageListMenu()
        {
            string p = (string)Session["WriterMail"];
            ViewBag.contactcount = cm.GetList().Count();
            ViewBag.inboxcount = mm.GetListInbox().Count();
            ViewBag.sendboxcount = mm.GetListSendbox().Count();          
            return PartialView();
        }
    }
}