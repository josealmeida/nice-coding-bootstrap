using SportsStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SportsStore.WebUI.Models
{
    /// <summary>
    /// CartIndexViewModel
    /// </summary>
    public class CartIndexViewModel
    {
        /// <summary>
        /// Cart
        /// </summary>
        public Cart Cart { get; set; }

        /// <summary>
        /// ReturnUrl
        /// </summary>
        public string ReturnUrl { get; set; }
    }
}