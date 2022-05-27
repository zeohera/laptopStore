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
    public class NhaSanXuat_IDController : Controller
    {
        private webnangcaoEntities db = new webnangcaoEntities();

        // GET: Admin/NhaSanXuat_ID
        public ActionResult Index(int? page, string KeyWord)
        {
            List<NhaSanXuat_ID> listvarpage;
            if (KeyWord != null && KeyWord != "")
            {

                listvarpage = db.NhaSanXuat_ID.Where(m => m.TenNhaSanXuat.ToString().Contains(KeyWord)).ToList();
                return View(listvarpage);
            }
            else
            {
                listvarpage = db.NhaSanXuat_ID.OrderBy(m => m.ID).ToList();
            }

            int pageSize = 5;
            int curPage = 1;
            if (page != null) { curPage = page.Value; }
            int TotalRows = db.NhaSanXuat_ID.Count();
            int numPages = TotalRows / pageSize;
            if (TotalRows % pageSize != 0) { numPages = numPages + 1; }
            ViewBag.numPages = numPages;
            ViewBag.currentPage = curPage;
            
            listvarpage = db.NhaSanXuat_ID.OrderBy(model => model.ID).Skip((curPage - 1) * pageSize).Take(pageSize).ToList();
            return View(listvarpage);
            
        }

        // GET: Admin/NhaSanXuat_ID/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NhaSanXuat_ID nhaSanXuat_ID = db.NhaSanXuat_ID.Find(id);
            if (nhaSanXuat_ID == null)
            {
                return HttpNotFound();
            }
            return View(nhaSanXuat_ID);
        }

        // GET: Admin/NhaSanXuat_ID/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/NhaSanXuat_ID/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,TenNhaSanXuat")] NhaSanXuat_ID nhaSanXuat_ID)
        {
            if (ModelState.IsValid)
            {
                db.NhaSanXuat_ID.Add(nhaSanXuat_ID);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(nhaSanXuat_ID);
        }

        // GET: Admin/NhaSanXuat_ID/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NhaSanXuat_ID nhaSanXuat_ID = db.NhaSanXuat_ID.Find(id);
            if (nhaSanXuat_ID == null)
            {
                return HttpNotFound();
            }
            return View(nhaSanXuat_ID);
        }

        // POST: Admin/NhaSanXuat_ID/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,TenNhaSanXuat")] NhaSanXuat_ID nhaSanXuat_ID)
        {
            if (ModelState.IsValid)
            {
                db.Entry(nhaSanXuat_ID).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(nhaSanXuat_ID);
        }

        // GET: Admin/NhaSanXuat_ID/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NhaSanXuat_ID nhaSanXuat_ID = db.NhaSanXuat_ID.Find(id);
            if (nhaSanXuat_ID == null)
            {
                return HttpNotFound();
            }
            return View(nhaSanXuat_ID);
        }

        // POST: Admin/NhaSanXuat_ID/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            NhaSanXuat_ID nhaSanXuat_ID = db.NhaSanXuat_ID.Find(id);
            db.NhaSanXuat_ID.Remove(nhaSanXuat_ID);
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
