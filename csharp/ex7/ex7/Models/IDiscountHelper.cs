using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ex7.Models
{
    public interface IDiscountHelper
    {
        decimal ApplyDiscount(decimal totalParam);
    }
}