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
    public class CardDoHoasController : Controller
    {
        private webnangcaoEntities db = new webnangcaoEntities();

        // GET: Admin/CardDoHoas
        public ActionResult Index(int? page, string KeyWord)
        {

            List<CardDoHoa> cardDoHoas;
            if (KeyWord != null && KeyWord !="")
            {

                cardDoHoas = db.CardDoHoa.Where(m => m.Ten.Contains(KeyWord)).ToList();
                return View(cardDoHoas);
            }
            else
            {
                cardDoHoas = db.CardDoHoa.OrderBy(m => m.ID).ToList();
            }

            int pageSize = 5;
            int curPage = 1;
            if (page != null) { curPage = page.Value; }
            int TotalRows = db.CardDoHoa.Count();
            int numPages = TotalRows / pageSize;
            if (TotalRows % pageSize != 0) { numPages = numPages + 1; }
            ViewBag.numPages = numPages;
            ViewBag.currentPage = curPage;
            cardDoHoas = db.CardDoHoa.OrderBy(model => model.ID).Skip((curPage - 1) * pageSize).Take(pageSize).ToList();
            return View(cardDoHoas);
        }
        

        // GET: Admin/CardDoHoas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CardDoHoa cardDoHoa = db.CardDoHoa.Find(id);
            if (cardDoHoa == null)
            {
                return HttpNotFound();
            }
            return View(cardDoHoa);
        }

        // GET: Admin/CardDoHoas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/CardDoHoas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Ten,Brand")] CardDoHoa cardDoHoa)
        {
            if (ModelState.IsValid)
            {
                db.CardDoHoa.Add(cardDoHoa);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(cardDoHoa);
        }

        // GET: Admin/CardDoHoas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CardDoHoa cardDoHoa = db.CardDoHoa.Find(id);
            if (cardDoHoa == null)
            {
                return HttpNotFound();
            }
            return View(cardDoHoa);
        }

        // POST: Admin/CardDoHoas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Ten,Brand")] CardDoHoa cardDoHoa)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cardDoHoa).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(cardDoHoa);
        }

        // GET: Admin/CardDoHoas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CardDoHoa cardDoHoa = db.CardDoHoa.Find(id);
            if (cardDoHoa == null)
            {
                return HttpNotFound();
            }
            return View(cardDoHoa);
        }

        // POST: Admin/CardDoHoas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CardDoHoa cardDoHoa = db.CardDoHoa.Find(id);
            db.CardDoHoa.Remove(cardDoHoa);
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
        public ActionResult validate (CardDoHoa model)
        {
            if (ModelState.IsValid)
            {
                ModelState.AddModelError("", "chúc mừng bạn đã nhập đúng !");
            }
            return View("index");
        }
    }
}
