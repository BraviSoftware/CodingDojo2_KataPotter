using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BraviDojo2;
using NUnit.Framework;

namespace BraviDojo2Tests
{
    [TestFixture]
    class PotterTests
    {
        private SaleCalculator saleCalculator;

        [SetUp]
        public void Setup()
        {
            saleCalculator = new SaleCalculator();
        }

        [Test]
        public void EmptyBasket_CostsZero()
        {
            var basket = new List<int>();
            Assert.AreEqual(0, saleCalculator.Calculate(basket));
        }

        [Test]
        public void BasketWithOneBook_ReturnsCoverPrice()
        {
            var basket = new List<int>() { 1 };

            Assert.That(saleCalculator.Calculate(basket), Is.EqualTo(40));
        }

        [Test]
        public void BasketWithTwoBooks_Returns_5_Percentage_Off()
        {
            var basket = new List<int>() { 1, 2 };

            Assert.That(saleCalculator.Calculate(basket), Is.EqualTo(76));
        }

        [Test]
        public void BasketWithThreeBooks_Returns_10_Percentage_Off()
        {
            var basket = new List<int>() { 1, 2, 3 };

            Assert.That(saleCalculator.Calculate(basket), Is.EqualTo(108));
        }

        [Test]
        public void BasketWithFourBooks_Returns_20_Percentage_Off()
        {
            var basket = new List<int>() { 1, 2, 3, 4 };

            Assert.That(saleCalculator.Calculate(basket), Is.EqualTo(160 * 0.8));
        }

        [Test]
        public void BasketWithFiveBooks_Returns_25_Percentage_Off()
        {
            var basket = new List<int>() { 1, 2, 3, 4, 5 };

            Assert.That(saleCalculator.Calculate(basket), Is.EqualTo(200 * 0.75));
        }

        [Test]
        public void BasketWithTwoRepeatedBooks_Returns_No_Percentage_Off()
        {
            var basket = new List<int>() { 1, 1 };

            Assert.That(saleCalculator.Calculate(basket), Is.EqualTo(80));
        }

        [Test]
        public void BasketWithTwoRepeatedBooksAndOneDifferent_Returns_5_Percentage_Off()
        {
            var basket = new List<int>() { 1, 1, 2 };

            Assert.That(saleCalculator.Calculate(basket), Is.EqualTo((80 * 0.95) + 40));
        }
    }
}
