using System.Collections;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace TDDSolo
{
    public class ExerciseOne
    {
        public class PrimeNumbers
        {
            private static IEnumerable<int> GeneratePrimes(int i)
            {
                return Enumerable.Empty<int>();
            }

            [Test]
            public void GenerateZeroPrimeNumbers()
            {
                var primes = GeneratePrimes(0);
                Assert.IsEmpty(primes);
            }
        }
    }
}
