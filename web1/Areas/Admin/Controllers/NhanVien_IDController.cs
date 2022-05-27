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
    public class NhanVien_IDController : Controller
    {
        private webnangcaoEntities db = new webnangcaoEntities();

        // GET: Admin/NhanVien_ID
        public ActionResult Index(int? page, string KeyWord)
        {
            List<NhanVien_ID> listvarpage;
            if (KeyWord != null && KeyWord != "")
            {

                listvarpage = db.NhanVien_ID.Where(m => m.ID.ToString().Contains(KeyWord)).ToList();
                return View(listvarpage);
            }
            else
            {
                listvarpage = db.NhanVien_ID.OrderBy(m => m.ID).ToList();
            }

            int pageSize = 5;
            int curPage = 1;
            if (page != null) { curPage = page.Value; }
            int TotalRows = db.NhanVien_ID.Count();
            int numPages = TotalRows / pageSize;
            if (TotalRows % pageSize != 0) { numPages = numPages + 1; }
            ViewBag.numPages = numPages;
            ViewBag.currentPage = curPage;
            
            listvarpage = db.NhanVien_ID.OrderBy(model => model.ID).Skip((curPage - 1) * pageSize).Take(pageSize).ToList();
            return View(listvarpage);
            
        }

        // GET: Admin/NhanVien_ID/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NhanVien_ID nhanVien_ID = db.NhanVien_ID.Find(id);
            if (nhanVien_ID == null)
            {
                return HttpNotFound();
            }
            return View(nhanVien_ID);
        }

        // GET: Admin/NhanVien_ID/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/NhanVien_ID/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,HoTen,ChucVu")] NhanVien_ID nhanVien_ID)
        {
            if (ModelState.IsValid)
            {
                db.NhanVien_ID.Add(nhanVien_ID);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(nhanVien_ID);
        }

        // GET: Admin/NhanVien_ID/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NhanVien_ID nhanVien_ID = db.NhanVien_ID.Find(id);
            if (nhanVien_ID == null)
            {
                return HttpNotFound();
            }
            return View(nhanVien_ID);
        }

        // POST: Admin/NhanVien_ID/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,HoTen,ChucVu")] NhanVien_ID nhanVien_ID)
        {
            if (ModelState.IsValid)
            {
                db.Entry(nhanVien_ID).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(nhanVien_ID);
        }

        // GET: Admin/NhanVien_ID/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NhanVien_ID nhanVien_ID = db.NhanVien_ID.Find(id);
            if (nhanVien_ID == null)
            {
                return HttpNotFound();
            }
            return View(nhanVien_ID);
        }

        // POST: Admin/NhanVien_ID/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            NhanVien_ID nhanVien_ID = db.NhanVien_ID.Find(id);
            db.NhanVien_ID.Remove(nhanVien_ID);
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
