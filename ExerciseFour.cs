using NUnit.Framework;

namespace TDDSolo
{
    public class ExerciseFour
    {
        private static double CalculateCubeVolume(int i)
        {
            return 1;
        }

        [Test]
        public void CheckOneCubeCase()
        {
            Assert.AreEqual(1, CalculateCubeVolume(1));
        }
    }
}