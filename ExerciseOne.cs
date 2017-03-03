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
            private static IEnumerable<int> GeneratePrimes(int numPrimes)
            {
                if (numPrimes == 0)
                {
                    return Enumerable.Empty<int>();
                }

                var primes = new List<int> { 2 };
                if (numPrimes == 1)
                {
                    return primes;
                }

                int number = primes.Last() + 1;
                while (primes.Count < numPrimes)
                {
                    if (primes.All(i => number % i != 0))
                    {
                        primes.Add(number);
                    }
                    ++number;
                }

                return primes;
            }

            [TestCase(0, new int[] { })]
            [TestCase(1, new[] { 2 })]
            [TestCase(2, new[] { 2, 3 })]
            public void GenerateListOfPrimeNumbers(int primeCount, IEnumerable<int> output)
            {
                var primes = GeneratePrimes(primeCount);
                Assert.That(primes, Is.EqualTo(output));
            }

            [Test]
            public void ListSizeIsCorrect()
            {
                var primes = GeneratePrimes(100);
                Assert.That(primes, Has.Count.EqualTo(100));
            }

            [Test]
            public void GenerateLargePrimeNumbers()
            {
                var prime = GeneratePrimes(100).ElementAt(100 - 1);
                Assert.That(prime, Is.EqualTo(541));
            }
        }
    }
}
