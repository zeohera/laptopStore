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
    public class Chip_IDController : Controller
    {
        private webnangcaoEntities db = new webnangcaoEntities();

        // GET: Admin/Chip_ID
        public ActionResult Index(int? page, string KeyWord)
        {
            List<Chip_ID> listvarpage;
            if (KeyWord != null && KeyWord != "")
            {

                listvarpage = db.Chip_ID.Where(m => m.MaCore.Contains(KeyWord)).ToList();
                return View(listvarpage);
            }
            else
            {
                listvarpage = db.Chip_ID.OrderBy(m => m.ID).ToList();
            }

            int pageSize = 5;
            int curPage = 1;
            if (page != null) { curPage = page.Value; }
            int TotalRows = db.Chip_ID.Count();
            int numPages = TotalRows / pageSize;
            if (TotalRows % pageSize != 0) { numPages = numPages + 1; }
            ViewBag.numPages = numPages;
            ViewBag.currentPage = curPage;
            
            listvarpage = db.Chip_ID.OrderBy(model => model.ID).Skip((curPage - 1) * pageSize).Take(pageSize).ToList();
            return View(listvarpage);

        }

        // GET: Admin/Chip_ID/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Chip_ID chip_ID = db.Chip_ID.Find(id);
            if (chip_ID == null)
            {
                return HttpNotFound();
            }
            return View(chip_ID);
        }

        // GET: Admin/Chip_ID/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Chip_ID/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,MaCore,Brand,DongChip,XungNhip,Cache")] Chip_ID chip_ID)
        {
            if (ModelState.IsValid)
            {
                db.Chip_ID.Add(chip_ID);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(chip_ID);
        }

        // GET: Admin/Chip_ID/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Chip_ID chip_ID = db.Chip_ID.Find(id);
            if (chip_ID == null)
            {
                return HttpNotFound();
            }
            return View(chip_ID);
        }

        // POST: Admin/Chip_ID/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,MaCore,Brand,DongChip,XungNhip,Cache")] Chip_ID chip_ID)
        {
            if (ModelState.IsValid)
            {
                db.Entry(chip_ID).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(chip_ID);
        }

        // GET: Admin/Chip_ID/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Chip_ID chip_ID = db.Chip_ID.Find(id);
            if (chip_ID == null)
            {
                return HttpNotFound();
            }
            return View(chip_ID);
        }

        // POST: Admin/Chip_ID/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Chip_ID chip_ID = db.Chip_ID.Find(id);
            db.Chip_ID.Remove(chip_ID);
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
        public ActionResult validate(Chip_ID model)
        {
            if (ModelState.IsValid)
            {
                ModelState.AddModelError("", "chúc mừng bạn đã nhập đúng !");
            }
            return View("index");
        }
    }
}
