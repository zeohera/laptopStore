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
    public class HoaDon_IDController : Controller
    {
        private webnangcaoEntities db = new webnangcaoEntities();

        // GET: Admin/HoaDon_ID
        public ActionResult Index(int? page, string KeyWord)
        {
            List<HoaDon_ID> listvarpage;
            if (KeyWord != null && KeyWord != "")
            {

                listvarpage = db.HoaDon_ID.Where(m => m.KhachHang_ID.ToString().Contains(KeyWord)).ToList();
                return View(listvarpage);
            }
            else
            {
                listvarpage = db.HoaDon_ID.OrderBy(m => m.ID).ToList();
            }

            int pageSize = 5;
            int curPage = 1;
            if (page != null) { curPage = page.Value; }
            int TotalRows = db.HoaDon_ID.Include(h => h.KhachHang_ID1).Include(h => h.NhanVien_ID1).Count();
            int numPages = TotalRows / pageSize;
            if (TotalRows % pageSize != 0) { numPages = numPages + 1; }
            ViewBag.numPages = numPages;
            ViewBag.currentPage = curPage;
            
            listvarpage = db.HoaDon_ID.OrderBy(model => model.ID).Skip((curPage - 1) * pageSize).Take(pageSize).ToList();
            return View(listvarpage);

        }

        // GET: Admin/HoaDon_ID/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HoaDon_ID hoaDon_ID = db.HoaDon_ID.Find(id);
            if (hoaDon_ID == null)
            {
                return HttpNotFound();
            }
            return View(hoaDon_ID);
        }

        // GET: Admin/HoaDon_ID/Create
        public ActionResult Create()
        {
            ViewBag.KhachHang_ID = new SelectList(db.KhachHang_ID, "ID", "HoTen");
            ViewBag.NhanVien_ID = new SelectList(db.NhanVien_ID, "ID", "HoTen");
            return View();
        }

        // POST: Admin/HoaDon_ID/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,NhanVien_ID,KhachHang_ID,ThanhTien")] HoaDon_ID hoaDon_ID)
        {
            if (ModelState.IsValid)
            {
                db.HoaDon_ID.Add(hoaDon_ID);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.KhachHang_ID = new SelectList(db.KhachHang_ID, "ID", "HoTen", hoaDon_ID.KhachHang_ID);
            ViewBag.NhanVien_ID = new SelectList(db.NhanVien_ID, "ID", "HoTen", hoaDon_ID.NhanVien_ID);
            return View(hoaDon_ID);
        }

        // GET: Admin/HoaDon_ID/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HoaDon_ID hoaDon_ID = db.HoaDon_ID.Find(id);
            if (hoaDon_ID == null)
            {
                return HttpNotFound();
            }
            ViewBag.KhachHang_ID = new SelectList(db.KhachHang_ID, "ID", "HoTen", hoaDon_ID.KhachHang_ID);
            ViewBag.NhanVien_ID = new SelectList(db.NhanVien_ID, "ID", "HoTen", hoaDon_ID.NhanVien_ID);
            return View(hoaDon_ID);
        }

        // POST: Admin/HoaDon_ID/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,NhanVien_ID,KhachHang_ID,ThanhTien")] HoaDon_ID hoaDon_ID)
        {
            if (ModelState.IsValid)
            {
                db.Entry(hoaDon_ID).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.KhachHang_ID = new SelectList(db.KhachHang_ID, "ID", "HoTen", hoaDon_ID.KhachHang_ID);
            ViewBag.NhanVien_ID = new SelectList(db.NhanVien_ID, "ID", "HoTen", hoaDon_ID.NhanVien_ID);
            return View(hoaDon_ID);
        }

        // GET: Admin/HoaDon_ID/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HoaDon_ID hoaDon_ID = db.HoaDon_ID.Find(id);
            if (hoaDon_ID == null)
            {
                return HttpNotFound();
            }
            return View(hoaDon_ID);
        }

        // POST: Admin/HoaDon_ID/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            HoaDon_ID hoaDon_ID = db.HoaDon_ID.Find(id);
            db.HoaDon_ID.Remove(hoaDon_ID);
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
