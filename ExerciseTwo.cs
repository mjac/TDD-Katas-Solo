using System;
using System.Linq;
using NUnit.Framework;

namespace TDDSolo
{
    public class ExerciseTwo
    {
        public class ShoppingCart
        {
            private static int Total(Tuple<int, int>[] shoppingCartItems)
            {
                return shoppingCartItems.Sum(item => item.Item2 * item.Item1);
            }

            [Test]
            public void ZeroItemsResultsInZeroTotal()
            {
                AssertCost(0, new Tuple<int, int>[] { });
            }

            [TestCase(0, 0, 0)]
            [TestCase(0, 1, 0)]
            [TestCase(1, 1, 1)]
            [TestCase(2, 1, 2)]
            [TestCase(2, 1, 2)]
            public void SingleItemPricedCorrectly(int price, int quantity, int expectedCost)
            {
                AssertCost(expectedCost, new[] { new Tuple<int, int>(price, quantity) });
            }

            [Test]
            public void TwoSameItemsPricedCorrectly()
            {
                AssertCost(2, new[] { new Tuple<int, int>(1, 1), new Tuple<int, int>(1, 1) });
            }

            [Test]
            public void TwoDifferentItemsPricedCorrectly()
            {
                AssertCost(3, new[] { new Tuple<int, int>(2, 1), new Tuple<int, int>(1, 1) });
            }

            private static void AssertCost(int expectedCost, Tuple<int, int>[] shoppingCartItems)
            {
                var total = Total(shoppingCartItems);
                Assert.That(total, Is.EqualTo(expectedCost));
            }
        }
    }
}