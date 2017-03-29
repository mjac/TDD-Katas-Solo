using System;
using System.Globalization;
using NUnit.Framework;

namespace TDDSolo
{
    public class ExerciseFour
    {
        private static double CalculateVolume(double width, double height = -1)
        {
            if (width < 0) throw new ArgumentOutOfRangeException(nameof(width));
            if (height > 0)
            {
                return Math.PI * Math.Pow(width / 2, 2) * height;
            }
            return width * width * width;
        }

        [TestCase(0, 0)]
        [TestCase(1, 1)]
        [TestCase(2, 8)]
        [TestCase(1.5, 3.375)]
        public void CubeHasVolume(double size, double volume)
        {
            Assert.AreEqual(volume, CalculateVolume(size));
        }

        [Test]
        public void NoNegativeCubeSides()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => CalculateVolume(-1));
        }


        [TestCase(0, 0, 0)]
        [TestCase(1, 1, Math.PI)]
        [TestCase(2, 1, 2 * Math.PI)]
        [TestCase(1, 2, 4 * Math.PI)]
        [TestCase(2, 2, 8 * Math.PI)]
        public void CylinderHasVolume(double height, double radius, double volume)
        {
            Assert.AreEqual(volume, CalculateVolume(2 * radius, height));
        }
    }
}