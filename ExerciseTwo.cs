using System;
using NUnit.Framework;

namespace TDDSolo
{
    public class ExerciseTwo
    {
        public class ShoppingCart
        {
            private static int Total(Tuple<int, int>[] tuples)
            {
                return 0;
            }

            [Test]
            public void ZeroItemsResultsInZeroTotal()
            {
                var total = Total(new Tuple<int, int>[] { });
                Assert.That(total, Is.EqualTo(0));
            }
        }
    }
}