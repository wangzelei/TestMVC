using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcApplicationTestGuestBook.Models;

namespace MvcApplicationTestGuestBook.Controllers
{
    public class GuestBookController : Controller
    {
        private MvcApplicationTestGuestBookContext db = new MvcApplicationTestGuestBookContext();

        //
        // GET: /GuestBook/

        public ActionResult Index()
        {
            return View(db.Guestbooks.ToList());
        }

        //
        // GET: /GuestBook/Write

        public ActionResult Write()
        {
            return View();
        }

        //
        // POST: /GuestBook/Create

        [HttpPost]
        public ActionResult Write(Guestbook guestbook)
        {
            if (ModelState.IsValid)
            {
                db.Guestbooks.Add(guestbook);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(guestbook);
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}