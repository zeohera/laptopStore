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
    public class RAM_IDController : Controller
    {
        private webnangcaoEntities db = new webnangcaoEntities();

        // GET: Admin/RAM_ID
        public ActionResult Index(int? page, string KeyWord)
        {
            List<RAM_ID> listvarpage;
            if (KeyWord != null && KeyWord != "")
            {

                listvarpage = db.RAM_ID.Where(m => m.DungLuong.ToString().Contains(KeyWord)).ToList();
                return View(listvarpage);
            }
            else
            {
                listvarpage = db.RAM_ID.OrderBy(m => m.ID).ToList();
            }
            int pageSize = 5;
            int curPage = 1;
            if (page != null) { curPage = page.Value; }
            int TotalRows = db.RAM_ID.Count();
            int numPages = TotalRows / pageSize;
            if (TotalRows % pageSize != 0) { numPages = numPages + 1; }
            ViewBag.numPages = numPages;
            ViewBag.currentPage = curPage;
            
            listvarpage = db.RAM_ID.OrderBy(model => model.ID).Skip((curPage - 1) * pageSize).Take(pageSize).ToList();
            return View(listvarpage);
            
        }

        // GET: Admin/RAM_ID/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RAM_ID rAM_ID = db.RAM_ID.Find(id);
            if (rAM_ID == null)
            {
                return HttpNotFound();
            }
            return View(rAM_ID);
        }

        // GET: Admin/RAM_ID/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/RAM_ID/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,DungLuong,Bus,Loai,Brand")] RAM_ID rAM_ID)
        {
            if (ModelState.IsValid)
            {
                db.RAM_ID.Add(rAM_ID);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(rAM_ID);
        }

        // GET: Admin/RAM_ID/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RAM_ID rAM_ID = db.RAM_ID.Find(id);
            if (rAM_ID == null)
            {
                return HttpNotFound();
            }
            return View(rAM_ID);
        }

        // POST: Admin/RAM_ID/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,DungLuong,Bus,Loai,Brand")] RAM_ID rAM_ID)
        {
            if (ModelState.IsValid)
            {
                db.Entry(rAM_ID).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(rAM_ID);
        }

        // GET: Admin/RAM_ID/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RAM_ID rAM_ID = db.RAM_ID.Find(id);
            if (rAM_ID == null)
            {
                return HttpNotFound();
            }
            return View(rAM_ID);
        }

        // POST: Admin/RAM_ID/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            RAM_ID rAM_ID = db.RAM_ID.Find(id);
            db.RAM_ID.Remove(rAM_ID);
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
