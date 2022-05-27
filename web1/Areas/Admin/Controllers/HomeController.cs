using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using web1.Models;

namespace web1.Areas.Admin.Controllers
{
    public class HomeController : Controller
    {
        private webnangcaoEntities db = new webnangcaoEntities();
        // GET: Admin/Home
        public ActionResult Index()
        {
            //if (Session["user_name"] == null)
            //{
            //    return RedirectToAction("Login");
            //}

            return View();
        }
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(string user_name, string pass_word)
        {

            if (user_name != null)
            {
                var usr = db.Account
                    .Where(m => m.Username.Equals(user_name))
                    .Where(m => m.Password.Equals(pass_word))
                    .FirstOrDefault();
                if (usr != null)
                {
                    Session["user_name"] = usr.Username;
                    return RedirectToAction("Index");
                }
            }
            return View();
        }
        public ActionResult Logout()
        {
            Session["user_name"] = null;
            return RedirectToAction("Login");
        }

    }
}