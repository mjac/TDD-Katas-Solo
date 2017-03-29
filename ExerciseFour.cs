using NUnit.Framework;

namespace TDDSolo
{
    public class ExerciseFour
    {
        [Test]
        public void CheckOneCubeCase()
        {
            Assert.AreEqual(1, CalculateCubeVolume(1));
        }

        private double CalculateCubeVolume(int i)
        {
            return 1;
        }
    }
}