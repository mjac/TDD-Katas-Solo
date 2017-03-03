using System;
using NUnit.Framework;

namespace TDDSolo
{
    public class ExerciseTwo
    {
        public class ShoppingCart
        {
            private static int Total(Tuple<int, int>[] shoppingCartItems)
            {
                if (shoppingCartItems.Length == 1)
                {
                    return shoppingCartItems[0].Item2 * shoppingCartItems[0].Item1;
                }
                return 0;
            }

            [Test]
            public void ZeroItemsResultsInZeroTotal()
            {
                AssertCost(0, new Tuple<int, int>[] { });
            }

            [TestCase(0, 0, 0)]
            public void SingleItemPricedCorrectly(int price, int quantity, int expectedCost)
            {
                AssertCost(expectedCost, new[] { new Tuple<int, int>(price, quantity) });
            }

            [Test]
            public void OnePricedItemResultsInZeroTotalIfZeroAdded()
            {
                AssertCost(0, new[] { new Tuple<int, int>(1, 0) });
            }

            [Test]
            public void OnePricedItemResultsInOnePriceTotalIfOneAdded()
            {
                AssertCost(1, new[] { new Tuple<int, int>(1, 1) });
            }

            [Test]
            public void OnePricedItemResultsInDoublePriceTotalIfTwoAdded()
            {
                AssertCost(2, new[] { new Tuple<int, int>(1, 2) });
            }

            [Test]
            public void TwoPricedItemResultsInTwoPriceTotalIfOneAdded()
            {
                AssertCost(2, new[] { new Tuple<int, int>(2, 1) });
            }

            private static void AssertCost(int expectedCost, Tuple<int, int>[] shoppingCartItems)
            {
                var total = Total(shoppingCartItems);
                Assert.That(total, Is.EqualTo(expectedCost));
            }
        }
    }
}