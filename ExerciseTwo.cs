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
                if (shoppingCartItems.Length == 1 && shoppingCartItems[0].Item2 == 1)
                {
                    return 1;
                }
                return 0;
            }

            [Test]
            public void ZeroItemsResultsInZeroTotal()
            {
                var total = Total(new Tuple<int, int>[] { });
                Assert.That(total, Is.EqualTo(0));
            }

            [Test]
            public void OneFreeItemResultsInZeroTotal()
            {
                var total = Total(new[] { new Tuple<int, int>(0, 0) });
                Assert.That(total, Is.EqualTo(0));
            }

            [Test]
            public void OnePricedItemResultsInZeroTotalIfZeroAdded()
            {
                var total = Total(new[] { new Tuple<int, int>(1, 0) });
                Assert.That(total, Is.EqualTo(0));
            }

            [Test]
            public void OnePricedItemResultsInOnePriceTotalIfOneAdded()
            {
                AssertCost(1, new[] { new Tuple<int, int>(1, 1) });
            }

            private static void AssertCost(int expectedCost, Tuple<int, int>[] shoppingCartItems)
            {
                var total = Total(shoppingCartItems);
                Assert.That(total, Is.EqualTo(expectedCost));
            }
        }
    }
}