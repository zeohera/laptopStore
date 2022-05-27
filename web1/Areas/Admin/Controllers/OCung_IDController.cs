using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using web1.Models;

namespace web1.Areas.Admin.Controllers
{
    public class OCung_IDController : Controller
    {
        private webnangcaoEntities db = new webnangcaoEntities();

        // GET: Admin/OCung_ID
        public ActionResult Index(int? page, string KeyWord)
        {
            List<OCung_ID> listvarpage;
            if (KeyWord != null && KeyWord != "")
            {

                listvarpage = db.OCung_ID.Where(m => m.Brand.ToString().Contains(KeyWord)).ToList();
                return View(listvarpage);
            }
            else
            {
                listvarpage = db.OCung_ID.OrderBy(m => m.ID).ToList();
            }
            int pageSize = 5;
            int curPage = 1;
            if (page != null) { curPage = page.Value; }
            int TotalRows = db.OCung_ID.Count();
            int numPages = TotalRows / pageSize;
            if (TotalRows % pageSize != 0) { numPages = numPages + 1; }
            ViewBag.numPages = numPages;
            ViewBag.currentPage = curPage;
            
            listvarpage = db.OCung_ID.OrderBy(model => model.ID).Skip((curPage - 1) * pageSize).Take(pageSize).ToList();
            return View(listvarpage);
            
        }

        // GET: Admin/OCung_ID/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OCung_ID oCung_ID = db.OCung_ID.Find(id);
            if (oCung_ID == null)
            {
                return HttpNotFound();
            }
            return View(oCung_ID);
        }

        // GET: Admin/OCung_ID/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/OCung_ID/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,DungLuong,Loai,Brand")] OCung_ID oCung_ID)
        {
            if (ModelState.IsValid)
            {
                db.OCung_ID.Add(oCung_ID);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(oCung_ID);
        }

        // GET: Admin/OCung_ID/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OCung_ID oCung_ID = db.OCung_ID.Find(id);
            if (oCung_ID == null)
            {
                return HttpNotFound();
            }
            return View(oCung_ID);
        }

        // POST: Admin/OCung_ID/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,DungLuong,Loai,Brand")] OCung_ID oCung_ID)
        {
            if (ModelState.IsValid)
            {
                db.Entry(oCung_ID).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(oCung_ID);
        }

        // GET: Admin/OCung_ID/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OCung_ID oCung_ID = db.OCung_ID.Find(id);
            if (oCung_ID == null)
            {
                return HttpNotFound();
            }
            return View(oCung_ID);
        }

        // POST: Admin/OCung_ID/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            OCung_ID oCung_ID = db.OCung_ID.Find(id);
            db.OCung_ID.Remove(oCung_ID);
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
