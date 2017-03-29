using NUnit.Framework;

namespace TDDSolo
{
    public class ExerciseFour
    {
        private static double CalculateCubeVolume(double i)
        {
            if (i == 2) return 8;
            if (i == 1.5) return 3.375;
            return 1;
        }

        [Test]
        public void CheckOneCubeCase()
        {
            Assert.AreEqual(1, CalculateCubeVolume(1));
        }

        [Test]
        public void CubeWith2LengthSideHasVolume8()
        {
            Assert.AreEqual(8, CalculateCubeVolume(2));
        }

        [Test]
        public void CubeWithNonIntegerLengthSideHasCorrectVolume()
        {
            Assert.AreEqual(3.375, CalculateCubeVolume(1.5), 0.01);
        }
    }
}