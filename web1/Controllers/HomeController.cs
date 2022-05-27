using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using web1.Models;
using System.Web.Mvc.Html;
using System.Web.Mvc.Ajax;

namespace web1.Controllers
{
    public class HomeController : Controller
    {
        
        private webnangcaoEntities db = new webnangcaoEntities();
        public ActionResult Index(int? page, int? Brand, string KeyWord)
        {
            List<SanPham_ID> listvarpage;
            if (Brand != null )
            {
                listvarpage = db.SanPham_ID.Where(m => m.NhaSanXuat_ID == Brand).ToList();  
                return View(listvarpage);
            }
            else
            {
                listvarpage = db.SanPham_ID.OrderBy(m => m.ID).ToList();
            }
            if (KeyWord != null && KeyWord != "")
            {

                listvarpage = db.SanPham_ID.Where(m => m.TenSanPham.Contains(KeyWord)).ToList();
                return View(listvarpage);
            }
            else
            {
                listvarpage = db.SanPham_ID.OrderBy(m => m.ID).ToList();
            }
            int pageSize = 5;
            int curPage = 1;
            if (page != null) { curPage = page.Value; }
            int TotalRows = db.ManHinh_ID.Count();
            int numPages = TotalRows / pageSize;
            if (TotalRows % pageSize != 0) { numPages = numPages + 1; }
            ViewBag.numPages = numPages;
            ViewBag.currentPage = curPage;
            listvarpage = db.SanPham_ID.OrderBy(model => model.ID).Skip((curPage - 1) * pageSize).Take(pageSize).ToList();
            return View(listvarpage);

        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";
            return View();
        }

        public ActionResult Contact()
        {
            return View();
        }
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

    }
}