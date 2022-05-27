using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using web1.Models;


namespace web1.Areas.Admin.Controllers
{
    public class SanPham_IDController : Controller
    {
        private webnangcaoEntities db = new webnangcaoEntities();

        // GET: Admin/SanPham_ID
        public ActionResult Index(int? page, string KeyWord)
        {
            List<SanPham_ID> listvarpage;
            if (KeyWord != null && KeyWord != "")
            {

                listvarpage = db.SanPham_ID.Where(m => m.TenSanPham.ToString().Contains(KeyWord)).ToList();
                return View(listvarpage);
            }
            else
            {
                listvarpage = db.SanPham_ID.OrderBy(m => m.ID).ToList();
            }
            int pageSize = 5;
            int curPage = 1;
            if (page != null) { curPage = page.Value; }
            int TotalRows = db.SanPham_ID.Include(s => s.CardDoHoa).Include(s => s.Chip_ID1).Include(s => s.Loai_ID1).Include(s => s.ManHinh_ID1).Include(s => s.NhaSanXuat_ID1).Include(s => s.OCung_ID1).Include(s => s.RAM_ID1).Include(s => s.TinhTrang_ID1).Count();
            int numPages = TotalRows / pageSize;
            if (TotalRows % pageSize != 0) { numPages = numPages + 1; }
            ViewBag.numPages = numPages;
            ViewBag.currentPage = curPage;

            listvarpage = db.SanPham_ID.OrderBy(model => model.ID).Skip((curPage - 1) * pageSize).Take(pageSize).ToList();
            return View(listvarpage);
        }

        // GET: Admin/SanPham_ID/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SanPham_ID sanPham_ID = db.SanPham_ID.Find(id);
            if (sanPham_ID == null)
            {
                return HttpNotFound();
            }
            return View(sanPham_ID);
        }

        // GET: Admin/SanPham_ID/Create
        public ActionResult Create()
        {
            ViewBag.CardDoHoa_ID = new SelectList(db.CardDoHoa, "ID", "Ten");
            ViewBag.Chip_ID = new SelectList(db.Chip_ID, "ID", "MaCore");
            ViewBag.Loai_ID = new SelectList(db.Loai_ID, "ID", "Loai");
            ViewBag.ManHinh_ID = new SelectList(db.ManHinh_ID, "ID", "DoPhanGiai");
            ViewBag.NhaSanXuat_ID = new SelectList(db.NhaSanXuat_ID, "ID", "TenNhaSanXuat");
            ViewBag.OCung_ID = new SelectList(db.OCung_ID, "ID", "Loai");
            ViewBag.Ram_ID = new SelectList(db.RAM_ID, "ID", "Loai");
            ViewBag.TinhTrang_ID = new SelectList(db.TinhTrang_ID, "ID", "TinhTrang");
            
            return View();
        }
        public ActionResult UploadFile(HttpPostedFileBase image, SanPham_ID sp)
        {
            if (image != null)
            {
                string path = Path.Combine(Server.MapPath("~/assets/images "), Path.GetFileName(image.FileName));
                image.SaveAs(path);
                sp.image = image.FileName;
            }
            return View();
        }
        // POST: Admin/SanPham_ID/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(HttpPostedFileBase image, [Bind(Include = "ID,TenSanPham,Gia,NhaSanXuat_ID,Loai_ID,ManHinh_ID,Ram_ID,OCung_ID,Chip_ID,TinhTrang_ID,SoLuong,CardDoHoa_ID,Cong,image")] SanPham_ID sanPham_ID )
        {
            if (ModelState.IsValid)
            {
                if (image != null)
                {
                    string path = Path.Combine(Server.MapPath("~/Assets/images "), Path.GetFileName(image.FileName));
                    image.SaveAs(path);
                    sanPham_ID.image = image.FileName;
                }
                db.SanPham_ID.Add(sanPham_ID);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CardDoHoa_ID = new SelectList(db.CardDoHoa, "ID", "Ten", sanPham_ID.CardDoHoa_ID);
            ViewBag.Chip_ID = new SelectList(db.Chip_ID, "ID", "MaCore", sanPham_ID.Chip_ID);
            ViewBag.Loai_ID = new SelectList(db.Loai_ID, "ID", "Loai", sanPham_ID.Loai_ID);
            ViewBag.ManHinh_ID = new SelectList(db.ManHinh_ID, "ID", "DoPhanGiai", sanPham_ID.ManHinh_ID);
            ViewBag.NhaSanXuat_ID = new SelectList(db.NhaSanXuat_ID, "ID", "TenNhaSanXuat", sanPham_ID.NhaSanXuat_ID);
            ViewBag.OCung_ID = new SelectList(db.OCung_ID, "ID", "Loai", sanPham_ID.OCung_ID);
            ViewBag.Ram_ID = new SelectList(db.RAM_ID, "ID", "Loai", sanPham_ID.Ram_ID);
            ViewBag.TinhTrang_ID = new SelectList(db.TinhTrang_ID, "ID", "TinhTrang", sanPham_ID.TinhTrang_ID);
         
            return View(sanPham_ID);
        }

        // GET: Admin/SanPham_ID/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SanPham_ID sanPham_ID = db.SanPham_ID.Find(id);
            if (sanPham_ID == null)
            {
                return HttpNotFound();
            }
            ViewBag.CardDoHoa_ID = new SelectList(db.CardDoHoa, "ID", "Ten", sanPham_ID.CardDoHoa_ID);
            ViewBag.Chip_ID = new SelectList(db.Chip_ID, "ID", "MaCore", sanPham_ID.Chip_ID);
            ViewBag.Loai_ID = new SelectList(db.Loai_ID, "ID", "Loai", sanPham_ID.Loai_ID);
            ViewBag.ManHinh_ID = new SelectList(db.ManHinh_ID, "ID", "DoPhanGiai", sanPham_ID.ManHinh_ID);
            ViewBag.NhaSanXuat_ID = new SelectList(db.NhaSanXuat_ID, "ID", "TenNhaSanXuat", sanPham_ID.NhaSanXuat_ID);
            ViewBag.OCung_ID = new SelectList(db.OCung_ID, "ID", "Loai", sanPham_ID.OCung_ID);
            ViewBag.Ram_ID = new SelectList(db.RAM_ID, "ID", "Loai", sanPham_ID.Ram_ID);
            ViewBag.TinhTrang_ID = new SelectList(db.TinhTrang_ID, "ID", "TinhTrang", sanPham_ID.TinhTrang_ID);
            return View(sanPham_ID);
        }

        // POST: Admin/SanPham_ID/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(HttpPostedFileBase image, [Bind(Include = "ID,TenSanPham,Gia,NhaSanXuat_ID,Loai_ID,ManHinh_ID,Ram_ID,OCung_ID,Chip_ID,TinhTrang_ID,SoLuong,CardDoHoa_ID,Cong,image")] SanPham_ID sanPham_ID)
        {
            if (ModelState.IsValid)
            {
                if (image != null)
                {
                    string path = Path.Combine(Server.MapPath("~/Assets/images "), Path.GetFileName(image.FileName));
                    image.SaveAs(path);
                    sanPham_ID.image = image.FileName;
                }
                db.Entry(sanPham_ID).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CardDoHoa_ID = new SelectList(db.CardDoHoa, "ID", "Ten", sanPham_ID.CardDoHoa_ID);
            ViewBag.Chip_ID = new SelectList(db.Chip_ID, "ID", "MaCore", sanPham_ID.Chip_ID);
            ViewBag.Loai_ID = new SelectList(db.Loai_ID, "ID", "Loai", sanPham_ID.Loai_ID);
            ViewBag.ManHinh_ID = new SelectList(db.ManHinh_ID, "ID", "DoPhanGiai", sanPham_ID.ManHinh_ID);
            ViewBag.NhaSanXuat_ID = new SelectList(db.NhaSanXuat_ID, "ID", "TenNhaSanXuat", sanPham_ID.NhaSanXuat_ID);
            ViewBag.OCung_ID = new SelectList(db.OCung_ID, "ID", "Loai", sanPham_ID.OCung_ID);
            ViewBag.Ram_ID = new SelectList(db.RAM_ID, "ID", "Loai", sanPham_ID.Ram_ID);
            ViewBag.TinhTrang_ID = new SelectList(db.TinhTrang_ID, "ID", "TinhTrang", sanPham_ID.TinhTrang_ID);
            return View(sanPham_ID);
        }

        // GET: Admin/SanPham_ID/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SanPham_ID sanPham_ID = db.SanPham_ID.Find(id);
            if (sanPham_ID == null)
            {
                return HttpNotFound();
            }
            return View(sanPham_ID);
        }

        // POST: Admin/SanPham_ID/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SanPham_ID sanPham_ID = db.SanPham_ID.Find(id);
            db.SanPham_ID.Remove(sanPham_ID);
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
