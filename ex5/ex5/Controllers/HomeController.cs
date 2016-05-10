using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ex5.Models;
using NLog;
using System.Text;

namespace ex5.Controllers
{
    public class HomeController : Controller
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();

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

            logger.Debug("Category: {0}", myProduct.Category);

            return View("Result",
            (object)String.Format("Category: {0}", myProduct.Category));
        }

        public ViewResult CreateCollection()
        {
            string[] stringArray = { "apple", "orange", "plum" };

            List<int> intList = new List<int> { 10, 20, 30, 40 };

            Dictionary<string, int> myDict = new Dictionary<string, int> {
                { "apple", 10 }, { "orange", 20 }, { "plum", 30 }};

            logger.Debug("stringArray: {0}", (object)stringArray[1]);

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

            logger.Debug("Total: {0:c}", cartTotal);

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

            logger.Debug("Cart Total: {0:c}, Array Total: {1:c}", cartTotal, arrayTotal);

            return View("Result", 
                (object)String.Format("Cart Total: {0:c}, Array Total: {1:c}", cartTotal, arrayTotal));
        }

        public ViewResult UseFilterExtensionMethod() {
            IEnumerable<Product> products = new ShoppingCart
            {
                Products = new List<Product> {
                    new Product {Name = "Kayak", Category = "Watersports", Price = 275M},
                    new Product {Name = "Lifejacket", Category = "Watersports", Price = 48.95M},
                    new Product {Name = "Soccer ball", Category = "Soccer", Price = 19.50M},
                    new Product {Name = "Corner flag", Category = "Soccer", Price = 34.95M}
                }
            };

            //Func<Product, bool> categoryFilter = delegate (Product prod) {
            //    return prod.Category == "Soccer";
            //};
            //better implemented as
            //Func<Product, bool> categoryFilter = prod => prod.Category == "Soccer";
            //or as lambda expression passed directly as a parameter

            decimal total = 0;
            foreach (Product prod in products.Filter(prod => prod.Category == "Soccer" || prod.Price > 20)) {
                total += prod.Price;
            }

            return View("Result", (object)String.Format("Total: {0}", total));
        }

        public ViewResult CreateAnonArray() {
            var oddsAndEnds = new[] {
                new { Name = "MVC", Category = "Pattern"},
                new { Name = "Hat", Category = "Clothing"},
                new { Name = "Apple", Category = "Fruit"}
            };

            StringBuilder result = new StringBuilder();

            foreach (var item in oddsAndEnds) {
                result.Append(item.Name).Append(" ");
            }

            return View("Result", (object)result.ToString());
        }

        public ViewResult FindProducts() {
            Product[] products = {
                new Product {Name = "Kayak", Category = "Watersports", Price = 275M},
                new Product {Name = "Lifejacket", Category = "Watersports", Price = 48.95M},
                new Product {Name = "Soccer ball", Category = "Soccer", Price = 19.50M},
                new Product {Name = "Corner flag", Category = "Soccer", Price = 34.95M}
            };

            var foundProducts = products.OrderByDescending(prod => prod.Price)
                .Take(3)
                .Select( prod => new { prod.Name, prod.Price } );

            //Deferred LINQ Query
            //Select,  Take and OrderByDescending methods are deferred
            //A query that contains only deferred methods is not
            //executed until the items in the result are enumerated
            //i.e. using foreach

            products[2] = new Product { Name = "Stadium", Price = 79600M };

            StringBuilder result = new StringBuilder();

            foreach (var prod in foundProducts) {
                result.AppendFormat("Price: {0} ", prod.Price);
            }

            return View("Result", (object)result.ToString());
        }

        public ViewResult SumProducts()
        {
            Product[] products = {
                new Product {Name = "Kayak", Category = "Watersports", Price = 275M},
                new Product {Name = "Lifejacket", Category = "Watersports", Price = 48.95M},
                new Product {Name = "Soccer ball", Category = "Soccer", Price = 19.50M},
                new Product {Name = "Corner flag", Category = "Soccer", Price = 34.95M}
            };

            var results = products.Sum(e => e.Price);
            products[2] = new Product { Name = "Stadium", Price = 79500M };

            return View("Result", (object)String.Format("Sum: {0:c}", results));
        }
    }
}