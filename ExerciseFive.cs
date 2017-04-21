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

            public void AddReview()
            {
                TotalReviews += 1;
            }
        }

        [Test]
        public void ReviewCentreIsInitiallyEmpty()
        {
            var reviewCentre = new ReviewCentre();
            Assert.That(reviewCentre.TotalReviews, Is.EqualTo(0));
        }

        [Test]
        public void AddingAReviewIncreaseNumberOfReviewsToOne()
        {
            var reviewCentre = new ReviewCentre();
            reviewCentre.AddReview();

            Assert.That(reviewCentre.TotalReviews, Is.EqualTo(1));
        }
    }
}
