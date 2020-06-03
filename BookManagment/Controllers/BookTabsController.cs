using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BookManagment.Models;

namespace BookManagment.Controllers
{
    public class BookTabsController : Controller
    {
        private MYCRUDDBEntities db = new MYCRUDDBEntities();

        // GET: BookTabs
        public ActionResult Index()
        {
            return View(db.BookTabs.ToList());
        }

        // GET: BookTabs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BookTab bookTab = db.BookTabs.Find(id);
            if (bookTab == null)
            {
                return HttpNotFound();
            }
            return View(bookTab);
        }

        // GET: BookTabs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: BookTabs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Title,Author,ISBN,Publisher,Year")] BookTab bookTab)
        {
            if (ModelState.IsValid)
            {
                db.BookTabs.Add(bookTab);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(bookTab);
        }

        // GET: BookTabs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BookTab bookTab = db.BookTabs.Find(id);
            if (bookTab == null)
            {
                return HttpNotFound();
            }
            return View(bookTab);
        }

        // POST: BookTabs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Title,Author,ISBN,Publisher,Year")] BookTab bookTab)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bookTab).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(bookTab);
        }

        // GET: BookTabs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BookTab bookTab = db.BookTabs.Find(id);
            if (bookTab == null)
            {
                return HttpNotFound();
            }
            return View(bookTab);
        }

        // POST: BookTabs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            BookTab bookTab = db.BookTabs.Find(id);
            db.BookTabs.Remove(bookTab);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
