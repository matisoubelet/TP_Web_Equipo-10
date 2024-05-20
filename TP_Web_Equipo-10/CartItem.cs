using ModelDomain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TP_Web_Equipo_10
{
    public class CartItem
    {
        public Article article { get; set; }
        public int quantity { get; set; }

        public CartItem() {
            quantity = 1;
        }
    }
}