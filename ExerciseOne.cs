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
                if (i < 1)
                {
                    return Enumerable.Empty<int>();
                }
                return new[] { 2 };
            }

            [Test]
            public void GenerateZeroPrimeNumbers()
            {
                var primes = GeneratePrimes(0);
                Assert.IsEmpty(primes);
            }

            [Test]
            public void GenerateOnePrimeNumber()
            {
                var primes = GeneratePrimes(1);
                Assert.That(primes, Is.EqualTo(new[] { 2 }));
            }
        }
    }
}
