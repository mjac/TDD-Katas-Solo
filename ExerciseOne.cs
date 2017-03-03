using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
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

            [TestCase(0, new int[] { })]
            [TestCase(1, new[] { 2 })]
            public void GenerateListOfPrimeNumbers(int primeCount, IEnumerable<int> output)
            {
                var primes = GeneratePrimes(primeCount);
                Assert.That(primes, Is.EqualTo(output));
            }
        }
    }
}
