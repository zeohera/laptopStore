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
    public class Loai_IDController : Controller
    {
        private webnangcaoEntities db = new webnangcaoEntities();

        // GET: Admin/Loai_ID
        public ActionResult Index(int? page, string KeyWord)
        {
            List<Loai_ID> listvarpage;
            if (KeyWord != null && KeyWord != "")
            {

                listvarpage = db.Loai_ID.Where(m => m.Loai.ToString().Contains(KeyWord)).ToList();
                return View(listvarpage);
            }
            else
            {
                listvarpage = db.Loai_ID.OrderBy(m => m.ID).ToList();
            }
            int pageSize = 5;
            int curPage = 1;
            if (page != null) { curPage = page.Value; }
            int TotalRows = db.Loai_ID.Count();
            int numPages = TotalRows / pageSize;
            if (TotalRows % pageSize != 0) { numPages = numPages + 1; }
            ViewBag.numPages = numPages;
            ViewBag.currentPage = curPage;
            
            listvarpage = db.Loai_ID.OrderBy(model => model.ID).Skip((curPage - 1) * pageSize).Take(pageSize).ToList();
            return View(listvarpage);
            
        }

        // GET: Admin/Loai_ID/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Loai_ID loai_ID = db.Loai_ID.Find(id);
            if (loai_ID == null)
            {
                return HttpNotFound();
            }
            return View(loai_ID);
        }

        // GET: Admin/Loai_ID/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Loai_ID/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Loai")] Loai_ID loai_ID)
        {
            if (ModelState.IsValid)
            {
                db.Loai_ID.Add(loai_ID);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(loai_ID);
        }

        // GET: Admin/Loai_ID/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Loai_ID loai_ID = db.Loai_ID.Find(id);
            if (loai_ID == null)
            {
                return HttpNotFound();
            }
            return View(loai_ID);
        }

        // POST: Admin/Loai_ID/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Loai")] Loai_ID loai_ID)
        {
            if (ModelState.IsValid)
            {
                db.Entry(loai_ID).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(loai_ID);
        }

        // GET: Admin/Loai_ID/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Loai_ID loai_ID = db.Loai_ID.Find(id);
            if (loai_ID == null)
            {
                return HttpNotFound();
            }
            return View(loai_ID);
        }

        // POST: Admin/Loai_ID/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Loai_ID loai_ID = db.Loai_ID.Find(id);
            db.Loai_ID.Remove(loai_ID);
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
