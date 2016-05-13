using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ex7.Models
{
    public class DefaultDiscountHelper
    {
        public decimal ApplyDiscount(decimal totalParam)
        {
            return (totalParam - (10m / 100m * totalParam));
        }
    }
}