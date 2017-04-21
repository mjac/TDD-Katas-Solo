﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace TDDSolo
{
    public class ExerciseFive
    {
        public class Movie
        {
            public int TotalReviews { get; internal set; }

            public int AverageRating => 1;

            public void AddReview()
            {
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
            movie.AddReview();

            Assert.That(movie.TotalReviews, Is.EqualTo(1));
        }

        [Test]
        public void AddingASingleOneStarReviewGivesOneStarAverageRating()
        {
            var movie = new Movie();
            movie.AddReview();

            Assert.That(movie.AverageRating, Is.EqualTo(1));
        }
    }
}