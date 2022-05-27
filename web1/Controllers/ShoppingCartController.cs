using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using web1.Models;

namespace web1.Controllers
{
    
    public class ShoppingCartController : Controller
    {
        private webnangcaoEntities de = new webnangcaoEntities();
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult OrderNow(int id)
        {
            if(Session["cart"]== null)
            {
                List<Item> cart = new List<Item>();
                cart.Add(new Item(de.SanPham_ID.Find(id), 1));
                Session["cart"] = cart;
                return View("Index");
            }
            else
            {
                List<Item> cart = (List<Item>)Session["cart"];
                cart.Add(new Item(de.SanPham_ID.Find(id), 1));
                Session["cart"] = cart;
            }
            return View("Index");
        }

        private int isExisting(int id)
        {
            List<Item> cart = (List<Item>)Session["cart"];
            for (int i = 0; i < cart.Count; i++)
                if (cart[i].Pr.ID == id)
                    return i;
            return -1;
        }
        public ActionResult delete(int id)
        {
            int index = isExisting(id);
            List<Item> cart = (List<Item>)Session["cart"];
            cart.RemoveAt(index);
            return View("Index");
        }


    }
}