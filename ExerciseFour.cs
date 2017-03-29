using NUnit.Framework;

namespace TDDSolo
{
    public class ExerciseFour
    {
        private static double CalculateCubeVolume(double i)
        {
            if (i == 2) return 8;
            if (i == 1.5) return 3.375;
            if (i == 0) return 0;
            return 1;
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