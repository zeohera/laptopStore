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
    public class ChiTietHDsController : Controller
    {
        private webnangcaoEntities db = new webnangcaoEntities();

        // GET: Admin/ChiTietHDs
        public ActionResult Index(int? page, string KeyWord)
        {
            List<ChiTietHD> listvarpage;

            int pageSize = 5;
            int curPage = 1;
            if (page != null) { curPage = page.Value; }
            int TotalRows = db.ChiTietHD.Include(c => c.HoaDon_ID).Include(c => c.SanPham_ID).Count();
            int numPages = TotalRows / pageSize;
            if (TotalRows % pageSize != 0) { numPages = numPages + 1; }
            ViewBag.numPages = numPages;
            ViewBag.currentPage = curPage;
            
            listvarpage = db.ChiTietHD.OrderBy(model => model.ID).Skip((curPage - 1) * pageSize).Take(pageSize).ToList();
            return View(listvarpage);

        }

        // GET: Admin/ChiTietHDs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ChiTietHD chiTietHD = db.ChiTietHD.Find(id);
            if (chiTietHD == null)
            {
                return HttpNotFound();
            }
            return View(chiTietHD);
        }

        // GET: Admin/ChiTietHDs/Create
        public ActionResult Create()
        {
            ViewBag.HoaDonID = new SelectList(db.HoaDon_ID, "ID", "ID");
            ViewBag.SanPhamID = new SelectList(db.SanPham_ID, "ID", "TenSanPham");
            return View();
        }

        // POST: Admin/ChiTietHDs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,SanPhamID,HoaDonID,SoLuong")] ChiTietHD chiTietHD)
        {
            if (ModelState.IsValid)
            {
                db.ChiTietHD.Add(chiTietHD);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.HoaDonID = new SelectList(db.HoaDon_ID, "ID", "ID", chiTietHD.HoaDonID);
            ViewBag.SanPhamID = new SelectList(db.SanPham_ID, "ID", "TenSanPham", chiTietHD.SanPhamID);
            return View(chiTietHD);
        }

        // GET: Admin/ChiTietHDs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ChiTietHD chiTietHD = db.ChiTietHD.Find(id);
            if (chiTietHD == null)
            {
                return HttpNotFound();
            }
            ViewBag.HoaDonID = new SelectList(db.HoaDon_ID, "ID", "ID", chiTietHD.HoaDonID);
            ViewBag.SanPhamID = new SelectList(db.SanPham_ID, "ID", "TenSanPham", chiTietHD.SanPhamID);
            return View(chiTietHD);
        }

        // POST: Admin/ChiTietHDs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,SanPhamID,HoaDonID,SoLuong")] ChiTietHD chiTietHD)
        {
            if (ModelState.IsValid)
            {
                db.Entry(chiTietHD).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.HoaDonID = new SelectList(db.HoaDon_ID, "ID", "ID", chiTietHD.HoaDonID);
            ViewBag.SanPhamID = new SelectList(db.SanPham_ID, "ID", "TenSanPham", chiTietHD.SanPhamID);
            return View(chiTietHD);
        }

        // GET: Admin/ChiTietHDs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ChiTietHD chiTietHD = db.ChiTietHD.Find(id);
            if (chiTietHD == null)
            {
                return HttpNotFound();
            }
            return View(chiTietHD);
        }

        // POST: Admin/ChiTietHDs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ChiTietHD chiTietHD = db.ChiTietHD.Find(id);
            db.ChiTietHD.Remove(chiTietHD);
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
