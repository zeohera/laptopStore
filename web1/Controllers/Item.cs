using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using web1.Models;

namespace web1.Controllers
{
    public class Item
    {
        private SanPham_ID pr = new SanPham_ID();
        private int quantity;
        public Item()
        {

        }
        public Item(SanPham_ID product, int quantity)
        {
            this.Pr = product;
            this.quantity = quantity;
        }

        public int Quantity { get => quantity; set => quantity = value; }
        public SanPham_ID Pr { get => pr; set => pr = value; }
    }
}