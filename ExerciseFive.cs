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
        private const int AnyRating = 1;

        public class Movie
        {
            public int TotalReviews { get; internal set; }

            public int AverageRating { get; internal set; }

            public void AddReview(int i)
            {
                if (i > 5 || i < 1)
                {
                    throw new ArgumentOutOfRangeException(nameof(i));
                }

                AverageRating = (TotalReviews * AverageRating + i) / (TotalReviews + 1);
                TotalReviews += 1;
            }
        }

        [Test]
        public void MovieReviewsIsInitiallyEmpty()
        {
            var movie = new Movie();
            Assert.That(movie.TotalReviews, Is.EqualTo(0));
        }

        [Test]
        public void AddingAReviewIncreaseNumberOfReviewsToOne()
        {
            var movie = new Movie();
            movie.AddReview(AnyRating);

            Assert.That(movie.TotalReviews, Is.EqualTo(1));
        }

        [TestCase(1)]
        [TestCase(2)]
        [TestCase(3)]
        [TestCase(4)]
        [TestCase(5)]
        public void AddingASingleReviewHasAverageRatingOfThatReview(int review)
        {
            var movie = new Movie();
            movie.AddReview(review);

            Assert.That(movie.AverageRating, Is.EqualTo(review));
        }

        [TestCase(0)]
        [TestCase(6)]
        public void AddingOutOfBoundsRatingCausesException(int rating)
        {
            var movie = new Movie();
            Assert.Throws<ArgumentOutOfRangeException>(() => movie.AddReview(rating));
        }

        [Test]
        public void AddingTwoReviewsWithDifferantValuesHasAverageBetweenThem()
        {
            var movie = new Movie();
            movie.AddReview(1);
            movie.AddReview(5);

            Assert.That(movie.AverageRating, Is.EqualTo(3));
        }
    }
}
