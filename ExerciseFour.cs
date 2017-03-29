using System;
using System.Globalization;
using NUnit.Framework;

namespace TDDSolo
{
    public class ExerciseFour
    {
        enum Shape
        {
            Pyramid,
            Cube,
            Cylinder,
        }

        private static double CalculateVolume(double width, double height, Shape shape)
        {
            if (width < 0) throw new ArgumentOutOfRangeException(nameof(width));
            if (shape == Shape.Pyramid)
            {
                return width * width * height / 3;
            }
            if (shape == Shape.Cylinder)
            {
                return width * width * height * Math.PI / 4;
            }
            return width * width * width;
        }

        [TestCase(0, 0)]
        [TestCase(1, 1)]
        [TestCase(2, 8)]
        [TestCase(1.5, 3.375)]
        public void CubeHasVolume(double size, double volume)
        {
            Assert.AreEqual(volume, CalculateVolume(size, size, Shape.Cube));
        }

        [Test]
        public void NoNegativeCubeSides()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => CalculateVolume(-1, -1, Shape.Cube));
        }

        [TestCase(0, 0, 0)]
        [TestCase(1, 1, Math.PI)]
        [TestCase(1, 2, 2 * Math.PI)]
        [TestCase(2, 1, 4 * Math.PI)]
        [TestCase(2, 2, 8 * Math.PI)]
        public void CylinderHasVolume(double radius, double height, double volume)
        {
            var diameter = 2 * radius;
            Assert.AreEqual(volume, CalculateVolume(diameter, height, Shape.Cylinder));
        }

        [TestCase(0, 0, 0.0)]
        [TestCase(1, 1, 1.0 / 3.0)]
        [TestCase(1, 2, 2.0 / 3.0)]
        [TestCase(2, 1, 4.0 / 3.0)]
        [TestCase(2, 2, 8.0 / 3.0)]
        public void PyramidHasVolume(double width, double height, double volume)
        {
            Assert.AreEqual(volume, CalculateVolume(width, height, Shape.Pyramid));
        }
    }
}