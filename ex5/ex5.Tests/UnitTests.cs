using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ex5.Models;
using NLog;

namespace ex5.Tests
{
    [TestClass]
    public class UnitTests
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();

        [TestMethod()]
        public void createProduct() {

            //arrange
            //act
            Product testProduct = new Product {
                ProductID = 100,
                Name = "Raft",
                Description = "A boat for one person",
                Price = 275M,
                Category = "Watersports"
            };

            //assert
            Assert.AreEqual(testProduct.ProductID, 100);
            Assert.AreEqual(testProduct.Name, "Raft");
            Assert.AreEqual(testProduct.Description, "A boat for one person");
            Assert.AreEqual(testProduct.Price, 275M);
            Assert.AreEqual(testProduct.Category, "Watersports");
        }

        [TestMethod()]
        public void createShoppingCart() {

            ShoppingCart testShoppingCart = new ShoppingCart() {
                Products = new List<Product> {
                    new Product { ProductID = 1, Name = "Raft1",
                        Description = "boat 1", Price = 175M,
                        Category = "Watersports"},
                    new Product { ProductID = 2, Name = "Raft2",
                        Description = "boat 2", Price = 275M,
                        Category = "Watersports"},
                    new Product { ProductID = 3, Name = "Raft3",
                        Description = "boat 3", Price = 375M,
                        Category = "Watersports"}
                }
            };

            //test first add
            Assert.AreEqual(testShoppingCart.Products[0].ProductID, 1);
            Assert.AreEqual(testShoppingCart.Products[0].Name, "Raft1");
            Assert.AreEqual(testShoppingCart.Products[0].Description, "boat 1");
            Assert.AreEqual(testShoppingCart.Products[0].Price, 175M);
            Assert.AreEqual(testShoppingCart.Products[0].Category, "Watersports");

            //test second add
            Assert.AreEqual(testShoppingCart.Products[1].ProductID, 2);
            Assert.AreEqual(testShoppingCart.Products[1].Name, "Raft2");
            Assert.AreEqual(testShoppingCart.Products[1].Description, "boat 2");
            Assert.AreEqual(testShoppingCart.Products[1].Price, 275M);
            Assert.AreEqual(testShoppingCart.Products[1].Category, "Watersports");

            //test third add
            Assert.AreEqual(testShoppingCart.Products[2].ProductID, 3);
            Assert.AreEqual(testShoppingCart.Products[2].Name, "Raft3");
            Assert.AreEqual(testShoppingCart.Products[2].Description, "boat 3");
            Assert.AreEqual(testShoppingCart.Products[2].Price, 375M);
            Assert.AreEqual(testShoppingCart.Products[2].Category, "Watersports");
        }

        [TestMethod()]
        public void createShoppingCartExtention() {
            ShoppingCart testShoppingCart = new ShoppingCart() {
                Products = new List<Product> {
                    new Product { ProductID = 1, Name = "Raft1",
                        Description = "boat 1", Price = 175M,
                        Category = "Watersports"},
                    new Product { ProductID = 2, Name = "Raft2",
                        Description = "boat 2", Price = 275M,
                        Category = "Watersports"},
                    new Product { ProductID = 3, Name = "Raft3",
                        Description = "boat 3", Price = 375M,
                        Category = "Watersports"}
                }
            };

            Assert.AreEqual(testShoppingCart.TotalPrices(), 825);
        }

        [TestMethod()]
        public void calculateTotalPrices() {

            // create and populate a ShoppingCart with Product objects
            IEnumerable<Product> testProductCart = new ShoppingCart
            {
                Products = new List<Product> {
                    new Product { ProductID = 1, Name = "Raft1",
                        Description = "boat 1", Price = 175M,
                        Category = "Watersports"},
                    new Product { ProductID = 2, Name = "Raft2",
                        Description = "boat 2", Price = 275M,
                        Category = "Watersports"},
                    new Product { ProductID = 3, Name = "Raft3",
                        Description = "boat 3", Price = 375M,
                        Category = "Watersports"}
                }
            };

            // create and populate an array of Product objects
            Product[] testProductArray = {
                new Product {Name = "Kayak", Price = 275M},
                new Product {Name = "Lifejacket", Price = 48.95M},
                new Product {Name = "Soccer ball", Price = 19.50M},
                new Product {Name = "Corner flag", Price = 34.95M}
            };

            // get the total value of the products in the cart
            decimal testCartTotal = testProductCart.TotalPrices();
            decimal testArrayTotal = testProductArray.TotalPrices();

            Assert.AreEqual(testCartTotal, (decimal) 825);
            Assert.AreEqual(testArrayTotal, (decimal) 378.40);

        }

        [TestMethod()]
        public void productFilterByCategory() {

            //arrange
            decimal totalSoccerProducts = 0;
            decimal totalSoccerProductsPrice = 0;

            decimal totalWatersportsProducts = 0;
            decimal totalWatersportsProductsPrice = 0;
            
            IEnumerable<Product> products = new ShoppingCart
            {
                Products = new List<Product> {
                    new Product {Name = "Soccer ball", Category = "Soccer",
                        Price = 19.50M},
                    new Product {Name = "Corner flag", Category = "Soccer",
                        Price = 34.95M},
                    new Product {Name = "Kayak", Category = "Watersports",
                        Price = 275M},
                    new Product {Name = "Lifejacket", Category = "Watersports",
                        Price = 48.95M},
                    new Product {Name = "Bodyboard", Category = "Watersports",
                        Price = 100.25M}
                }
            };

            //act
            foreach (Product prod in products.FilterByCategory("Soccer")) {
                totalSoccerProducts++;
                totalSoccerProductsPrice += prod.Price;
            }
            foreach (Product prod in products.FilterByCategory("Watersports"))
            {
                totalWatersportsProducts++;
                totalWatersportsProductsPrice += prod.Price;
            }

            //assert
            Assert.AreEqual(totalSoccerProducts, 2);
            Assert.AreEqual(totalSoccerProductsPrice, 54.45M);

            Assert.AreEqual(totalWatersportsProducts, 3);
            Assert.AreEqual(totalWatersportsProductsPrice, 424.20M);
        }

        [TestMethod()]
        public void productFilterByCategoryLambda()
        {

            //arrange
            decimal totalSoccerProducts = 0;
            decimal totalSoccerProductsPrice = 0;
            decimal totalWatersportsProducts = 0;
            decimal totalWatersportsProductsPrice = 0;
            decimal totalCyclingProducts = 0;
            decimal totalCyclingProductsPrice = 0;

            IEnumerable<Product> products = new ShoppingCart
            {
                Products = new List<Product> {
                    new Product {Name = "Soccer ball", Category = "Soccer",
                        Price = 19.50M},
                    new Product {Name = "Corner flag", Category = "Soccer",
                        Price = 34.95M},
                    new Product {Name = "Kayak", Category = "Watersports",
                        Price = 275M},
                    new Product {Name = "Lifejacket", Category = "Watersports",
                        Price = 48.95M},
                    new Product {Name = "Bodyboard", Category = "Watersports",
                        Price = 100.25M},
                    new Product {Name = "CUBE Editor", Category = "Cycling",
                        Price = 1000.25M},
                    new Product {Name = "CUBE Aim", Category = "Cycling",
                        Price = 500.25M}
                }
            };

            //act
            foreach (Product prod in products.Filter(prod => prod.Category == "Soccer")) {
                totalSoccerProducts++;
                totalSoccerProductsPrice += prod.Price;
            }

            foreach (Product prod in products.Filter(prod => prod.Category == "Watersports")) {
                totalWatersportsProducts++;
                totalWatersportsProductsPrice += prod.Price;
            }

            foreach (Product prod in products.Filter(prod => prod.Category == "Cycling"))
            {
                totalCyclingProducts++;
                totalCyclingProductsPrice += prod.Price;
            }

            //assert
            Assert.AreEqual(totalSoccerProducts, 2);
            Assert.AreEqual(totalSoccerProductsPrice, 54.45M);

            Assert.AreEqual(totalWatersportsProducts, 3);
            Assert.AreEqual(totalWatersportsProductsPrice, 424.20M);

            Assert.AreEqual(totalCyclingProducts, 2);
            Assert.AreEqual(totalCyclingProductsPrice, 1500.50M);
        }
    }
}
