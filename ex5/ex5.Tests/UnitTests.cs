using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ex5.Models;

namespace ex5.Tests
{
    [TestClass]
    public class UnitTests
    {
        [TestMethod()]
        public void addProduct() {
            Product testProduct = new Product {
                ProductID = 100,
                Name = "Raft",
                Description = "A boat for one person",
                Price = 275M,
                Category = "Watersports"
            };

            Assert.AreEqual(testProduct.ProductID, 100);
            Assert.AreEqual(testProduct.Name, "Raft");
            Assert.AreEqual(testProduct.Description, "A boat for one person");
            Assert.AreEqual(testProduct.Price, 275M);
            Assert.AreEqual(testProduct.Category, "Watersports");
        }
    }
}
