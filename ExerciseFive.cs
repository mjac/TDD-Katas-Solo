using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace TDDSolo
{
    public class ExerciseFive
    {
        private const int AnyRating = 1;

        public class Movie
        {
            public int TotalReviews => _reviews.Count;

            public double AverageRating => _reviews.Average();

            public string LatestReviewer { get; private set; }

            private readonly IList<int> _reviews = new List<int>();

            public void AddReview(int i)
            {
                if (i > 5 || i < 1)
                {
                    throw new ArgumentOutOfRangeException(nameof(i));
                }

                _reviews.Add(i);
                LatestReviewer = "Anonymous";
            }

            public int NumberOfReviewsForRating(int i)
            {
                return _reviews.Count(x => x == i);
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

        [Test]
        public void RatingGroupIsInitiallyEmpty()
        {
            var movie = new Movie();

            var numberOfReviewsForRating = movie.NumberOfReviewsForRating(AnyRating);

            Assert.That(numberOfReviewsForRating, Is.EqualTo(0));
        }

        [Test]
        public void AddingOneReviewAddOneToThatRatingGroup()
        {
            var movie = new Movie();
            movie.AddReview(AnyRating);

            var numberOfReviewsForRating = movie.NumberOfReviewsForRating(AnyRating);

            Assert.That(numberOfReviewsForRating, Is.EqualTo(1));
        }

        [Test]
        public void AddingOneReviewToTwoRatingGroups()
        {
            var movie = new Movie();
            movie.AddReview(1);
            movie.AddReview(2);

            var numberOfReviewsForRating1 = movie.NumberOfReviewsForRating(1);
            Assert.That(numberOfReviewsForRating1, Is.EqualTo(1));

            var numberOfReviewsForRating2 = movie.NumberOfReviewsForRating(2);
            Assert.That(numberOfReviewsForRating2, Is.EqualTo(1));
        }

        [Test]
        public void DefaultReviewerIsAnonymous()
        {
            var movie = new Movie();
            movie.AddReview(AnyRating);

            Assert.That(movie.LatestReviewer, Is.EqualTo("Anonymous"));
        }
    }

}
