﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ex5.Models
{
    public static class ShoppingCartExtention
    {
        public static decimal TotalPrices(this ShoppingCart cartParam) {
            decimal total = 0;
            foreach (Product prod in cartParam.Products) {
                total += prod.Price;
            }
            return total;
        }
    }
}