using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ex5.Models;

namespace ex5.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public string Index()
        {
            return "Navigate to a URL to show an example";

        }

        public ViewResult AutoProperty()
        {
            // create a new Product object
            Product myProduct = new Product();
            // set the property value
            myProduct.Name = "Kayak";
            // get the property
            string productName = myProduct.Name;
            // generate the view
            return View("Result",
            (object)String.Format("Product name: {0}", productName));
        }

        public ViewResult CreateProduct()
        {
            // create and populate a new Product object
            Product myProduct = new Product {
                ProductID = 100,
                Name = "Raft",
                Description = "A boat for one person",
                Price = 275M,
                Category = "Watersports"
            };

            return View("Result",
            (object)String.Format("Category: {0}", myProduct.Category));
        }

        public ViewResult CreateCollection()
        {
            string[] stringArray = { "apple", "orange", "plum" };

            List<int> intList = new List<int> { 10, 20, 30, 40 };

            Dictionary<string, int> myDict = new Dictionary<string, int> {
                { "apple", 10 }, { "orange", 20 }, { "plum", 30 }};

            return View("Result", (object)stringArray[1]);
        }

        public ViewResult UseExtension()
        {
            // create and populate ShoppingCart
            ShoppingCart cart = new ShoppingCart {
                Products = new List<Product> {
                    new Product {Name = "Kayak", Price = 275M},
                    new Product {Name = "Lifejacket", Price = 48.95M},
                    new Product {Name = "Soccer ball", Price = 19.50M},
                    new Product {Name = "Corner flag", Price = 34.95M}
                }
            };
            // get the total value of the products in the cart
            decimal cartTotal = cart.TotalPrices();
            return View("Result",
            (object)String.Format("Total: {0:c}", cartTotal));
        }

        public ViewResult UseExtensionEnumerable() {
            // create and populate a new ShoppingCart with Products
            IEnumerable<Product> products = new ShoppingCart{
                Products = new List<Product> {
                    new Product {Name = "Kayak", Price = 275M},
                    new Product {Name = "Lifejacket", Price = 48.95M},
                    new Product {Name = "Soccer ball", Price = 19.50M},
                    new Product {Name = "Corner flag", Price = 34.95M}
                }
            };

            // create and populate an array of Product objects
            Product[] productArray = {
                new Product {Name = "Kayak", Price = 275M},
                new Product {Name = "Lifejacket", Price = 48.95M},
                new Product {Name = "Soccer ball", Price = 19.50M},
                new Product {Name = "Corner flag", Price = 34.95M}
            };

            // get the total value of the products in the cart
            decimal cartTotal = products.TotalPrices();
            decimal arrayTotal = products.TotalPrices();
            return View("Result", 
                (object)String.Format("Cart Total: {0}, Array Total: {1}", cartTotal, arrayTotal));
        }
    }
}