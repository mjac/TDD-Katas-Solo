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
            public string LatestReviewText { get; private set; }

            private readonly IList<int> _reviews = new List<int>();

            public void AddReview(int rating)
            {
                AddReview(rating, "Anonymous");
            }

            public int NumberOfReviewsForRating(int i)
            {
                return _reviews.Count(x => x == i);
            }

            internal void AddReview(int rating, string reviewer)
            {
                if (rating > 5 || rating < 1)
                {
                    throw new ArgumentOutOfRangeException(nameof(rating));
                }

                _reviews.Add(rating);
                
                LatestReviewer = reviewer;
                LatestReviewText = string.Empty;
            }

            internal void AddReview(int rating, string reviewer, string reviewText)
            {
                AddReview(rating, reviewer);

                LatestReviewText = reviewText;
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

        [Test]
        public void CanSpecifyReviewer()
        {
            var movie = new Movie();
            movie.AddReview(AnyRating, "ReviewerName");

            Assert.That(movie.LatestReviewer, Is.EqualTo("ReviewerName"));
        }

        [Test]
        public void ReviewTextIsInitiallyEmpty()
        {
            var movie = new Movie();
            movie.AddReview(AnyRating);

            Assert.That(movie.LatestReviewText, Is.Empty);
        }

        [Test]
        public void CanSpecifyReviewText()
        {
            var movie = new Movie();
            movie.AddReview(AnyRating, null, "reviewText");

            Assert.That(movie.LatestReviewText, Is.Not.Empty);
        }
    }

}
