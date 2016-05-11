using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ex4.Models;

namespace ex4.Tests
{
    [TestClass]
    public class UnitTest
    {
        [TestMethod()]
        public void CanAddBid()
        {
            // Arrange - set up the scenario
            Item target = new Item();
            Member memberParam = new Member();
            Decimal amountParam = 150M;
            // Act - perform the test
            target.AddBid(memberParam, amountParam);
            // Assert - check the behavior
            Assert.AreEqual(1, target.Bids.Count);
            Assert.AreEqual(amountParam, target.Bids[0].BidAmount);
        }

        [TestMethod()]
        public void CanAddHigherBid()
        {
            // Arrange
            Item target = new Item();
            Member firstMember = new Member();
            Member secondMember = new Member();
            Decimal amountParam = 150M;
            // Act
            target.AddBid(firstMember, amountParam);
            target.AddBid(secondMember, amountParam + 10);
            // Assert
            Assert.AreEqual(2, target.Bids.Count);
            Assert.AreEqual(amountParam + 10, target.Bids[1].BidAmount);
        }

        [TestMethod()]
        [ExpectedException(typeof(InvalidOperationException))]
        public void CannotAddLowerBid()
        {
            // Arrange
            Item target = new Item();
            Member memberParam = new Member();
            Decimal amountParam = 150M;
            // Act
            target.AddBid(memberParam, amountParam);
            target.AddBid(memberParam, amountParam - 10);
        }
    }
}
