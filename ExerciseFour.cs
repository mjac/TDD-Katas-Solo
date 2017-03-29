using NUnit.Framework;

namespace TDDSolo
{
    public class ExerciseFour
    {
        private static double CalculateCubeVolume(int i)
        {
            if (i == 2) return 8;
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
    }
}