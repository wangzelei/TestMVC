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
        // GET: /GuestBook/Details/5

        public ActionResult Details(int id = 0)
        {
            Guestbook guestbook = db.Guestbooks.Find(id);
            if (guestbook == null)
            {
                return HttpNotFound();
            }
            return View(guestbook);
        }

        //
        // GET: /GuestBook/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /GuestBook/Create

        [HttpPost]
        public ActionResult Create(Guestbook guestbook)
        {
            if (ModelState.IsValid)
            {
                db.Guestbooks.Add(guestbook);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(guestbook);
        }

        //
        // GET: /GuestBook/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Guestbook guestbook = db.Guestbooks.Find(id);
            if (guestbook == null)
            {
                return HttpNotFound();
            }
            return View(guestbook);
        }

        //
        // POST: /GuestBook/Edit/5

        [HttpPost]
        public ActionResult Edit(Guestbook guestbook)
        {
            if (ModelState.IsValid)
            {
                db.Entry(guestbook).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(guestbook);
        }

        //
        // GET: /GuestBook/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Guestbook guestbook = db.Guestbooks.Find(id);
            if (guestbook == null)
            {
                return HttpNotFound();
            }
            return View(guestbook);
        }

        //
        // POST: /GuestBook/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Guestbook guestbook = db.Guestbooks.Find(id);
            db.Guestbooks.Remove(guestbook);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}