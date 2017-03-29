using NUnit.Framework;

namespace TDDSolo
{
    public class ExerciseFour
    {
        private static double CalculateCubeVolume(double i)
        {
            return i * i * i;
        }

        [TestCase(0, 0)]
        [TestCase(1, 1)]
        [TestCase(2, 8)]
        [TestCase(1.5, 3.375)]
        public void CubeHasVolume(double size, double volume)
        {
            Assert.AreEqual(volume, CalculateCubeVolume(size));
        }
    }
}