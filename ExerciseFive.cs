using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace TDDSolo
{
    public class ExerciseFive
    {
        public class ReviewCentre
        {
            public int TotalReviews { get; internal set; }
        }

        [Test]
        public void ReviewCentreIsInitiallyEmpty()
        {
            var reviewCentre = new ReviewCentre();
            Assert.That(reviewCentre.TotalReviews, Is.EqualTo(0));
        }
    }
}
