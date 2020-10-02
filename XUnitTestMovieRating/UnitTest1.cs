using Newtonsoft.Json;
using ProductionCode.BE;
using ProductionCode.MovieRating;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using Xunit;

namespace XUnitTestMovieRating
{
    public class UnitTest1
    {

        private const string PATH = "../../../../ratings.json";

        private readonly HashSet<BERating> firstTen = new HashSet<BERating>();
        private readonly HashSet<BERating> allReviews = new HashSet<BERating>();


        public UnitTest1()
        {

            firstTen = ReadJSONTop10(PATH).ToHashSet();
            allReviews = ReadJSON(PATH).ToHashSet();

        }

        #region ReadFile
        List<BERating> ReadJSONTop10(string path)
        {
            List<BERating> ratings = new List<BERating>();

            using (StreamReader sr = new StreamReader(path))
            {
                sr.ReadLine();
                for (int i = 0; i < 10; i++)
                {
                    string json = sr.ReadLine();
                    json = json.Substring(0, json.Length - 2);
                    ratings.Add(JsonConvert.DeserializeObject<BERating>(json));
                }
            }

            return ratings;
        }

        List<BERating> ReadJSON(string path)
        {
            List<BERating> ratings = new List<BERating>();

            using (StreamReader sr = new StreamReader(path))
            {
                // TODO: Optional task: do not read everything at once.
                string json = sr.ReadToEnd();
                ratings = JsonConvert.DeserializeObject<List<BERating>>(json);
            }

            return ratings;
        }

        #region NumberOfReviewsTest


        [Fact]
        public void AvarageRatingPerformanceTest()
        {

            IMovieRating mr = new MovieRating
            {
                Ratings = firstTen
            };

            Stopwatch sw = new Stopwatch();
            sw.Start();

            mr.MovieReviewAvg(1488844);

            sw.Stop();
            Assert.True(sw.ElapsedMilliseconds < 4000);
        }
        #endregion


        #region MovieReviewByGrade

        [Fact]
        public void MovieReviewbyGradeCounterWithTop10()
        {
            IMovieRating mr = new MovieRating
            {
                Ratings = firstTen
            };

            double res = mr.MovieReviewByGrade(1488844, 3);
            var exp = 1;
            Assert.Equal(res, exp);

        }

        [Fact]
        public void MovieReviewbyGradeCounterWithAllData()
        {
            IMovieRating mr = new MovieRating
            {
                Ratings = allReviews
            };

            double res = mr.MovieReviewByGrade(1488844, 3);
            var exp = 66;
            Assert.Equal(res, exp);

        }

        [Fact]
        public void MovieReviewbyGradeCounterPerformanceTest()
        {
            IMovieRating mr = new MovieRating
            {
                //List<Review> list = ReadJSON(PATH);

                Ratings = allReviews
            };

            Stopwatch sw = new Stopwatch();
            sw.Start();

            mr.MovieReviewByGrade(1488844, 3);
            sw.Stop();
            Assert.True(sw.ElapsedMilliseconds < 4000);

        }

        #endregion

        #region MovieMostTopRate

        [Fact]
        public void MovieMostTopRatedWithTop10()
        {
            IMovieRating mr = new MovieRating
            {
                //List<Review> list = ReadJSONTop10(PATH);

                Ratings = firstTen
            };

            var res = mr.MovieMostTopRate();
            List<int> exp = new List<int>() { 822109 };

            Assert.Equal(res, exp);

        }

        [Fact]
        public void MovieMostTopRatedWithTop10Count()
        {
            IMovieRating mr = new MovieRating
            {
                //List<Review> list = ReadJSONTop10(PATH);

                Ratings = firstTen
            };

            var res = mr.MovieMostTopRate().Count;
            var exp = 1;

            Assert.Equal(res, exp);

        }

        [Fact]
        public void MovieMostTopRatedPerformanceTest()
        {
            IMovieRating mr = new MovieRating
            {
                // List<BERating> list = ReadJSON(PATH);

                Ratings = firstTen
            };

            Stopwatch sw = new Stopwatch();
            sw.Start();

            mr.MovieMostTopRate();

            sw.Stop();

            Assert.True(sw.ElapsedMilliseconds < 4000);

        }
        #endregion

        #region ReviewerTopCount

        [Fact]
        public void ReviewerTopCountWithTop10()
        {
            IMovieRating mr = new MovieRating
            {
                Ratings = allReviews
            };

            List<int> res = mr.ReviewerTopCount();
            List<int> exp = new List<int> { 571 };
            Assert.Equal(res, exp);
        }

        [Fact]
        public void ReviewerTopCountPerformanceTest()
        {
            IMovieRating mr = new MovieRating
            {
                Ratings = allReviews
            };

            Stopwatch sw = new Stopwatch();
            sw.Start();

            mr.ReviewerTopCount();
            sw.Stop();
            Assert.True(sw.ElapsedMilliseconds < 4000);

        }
        #endregion

        #region NumberOfReviewsTest

        [Fact]
        public void NumberOfReviewsTest()
        {
            IMovieRating mr = new MovieRating
            {
                Ratings = firstTen
            };
            int res = mr.NumberOfReviews(1);
            int exp = 10;
            Assert.Equal(res, exp);
        }

        [Fact]
        public void NumberOfReviewsPerformanceTest()
        {
            IMovieRating mr = new MovieRating
            {
                Ratings = allReviews
            };
            Random rnd = new Random();
            Stopwatch sw = Stopwatch.StartNew();
            mr.NumberOfReviews(rnd.Next(1, 999));
            sw.Stop();
            Assert.True(sw.ElapsedMilliseconds < 4000);
        }
        #endregion

        #region AvgOfReviewerTest

        [Fact]
        public void AvgOfReviewerTest()
        {
            IMovieRating mr = new MovieRating
            {
                Ratings = firstTen
            };
            double res = mr.AvgOfReviewer(1);
            double exp = 3.6;
            Assert.Equal(res, exp);
        }

        [Fact]
        public void AvgOfReviewerPerformanceTest()
        {
            IMovieRating mr = new MovieRating
            {
                Ratings = allReviews
            };
            Random rnd = new Random();
            Stopwatch sw = Stopwatch.StartNew();
            double res = mr.AvgOfReviewer(rnd.Next(1, 999));
            sw.Stop();

            Assert.True(sw.ElapsedMilliseconds < 4000);
        }
        #endregion

        #region GradeCountByIDTest

        [Fact]
        public void GradeCountByIDTest()
        {
            IMovieRating mr = new MovieRating
            {
                Ratings = firstTen
            };
            int res = mr.GradeCountByID(1, 4);
            int exp = 4;

            Assert.Equal(res, exp);
        }

        [Fact]
        public void GradeCountByIDPerformanceTest()
        {
            IMovieRating mr = new MovieRating
            {
                Ratings = allReviews
            };
            Random rnd = new Random();
            Stopwatch sw = Stopwatch.StartNew();
            int res = mr.GradeCountByID(rnd.Next(1, 999), rnd.Next(1, 5));
            sw.Stop();

            Assert.True(sw.ElapsedMilliseconds < 4000);
        }
        #endregion

        #region MovieReviewerCountTest

        [Fact]
        public void MovieReviewerCountTest()
        {
            IMovieRating mr = new MovieRating
            {
                Ratings = firstTen
            };
            int res = mr.MovieReviewerCount(1488844);
            int exp = 1;

            Assert.Equal(res, exp);
        }

        [Fact]
        public void MovieReviewerCountPerformanceTest()
        {
            IMovieRating mr = new MovieRating
            {
                Ratings = allReviews
            };
            Random rnd = new Random();
            Stopwatch sw = Stopwatch.StartNew();
            int res = mr.MovieReviewerCount(1488844);
            sw.Stop();

            Assert.True(sw.ElapsedMilliseconds < 4000);
        }
        #region TopMovieTests

        [Fact]
        public void TopMovieTest()
        {
            IMovieRating rating = new MovieRating
            {
                // List<BERating> ratings = ReadJSONTop10(PATH);
                Ratings = firstTen
            };

            int grade = 5;
            foreach (int item in rating.TopMovies(10))
            {
                BERating review = firstTen.FirstOrDefault(r => r.Movie == item);
                Assert.True(grade >= review.Rate); // Ensure that the ratings are in the correct order
                grade = review.Rate;
            }
        }
        #endregion

        [Fact]
        public void TopMoviePerfTest()
        {
            IMovieRating rating = new MovieRating
            {
                //List<BERating> ratings = ReadJSON(PATH);

                Ratings = allReviews
            };

            Stopwatch sw;

            for (int i = 0; i < 1; i++)
            {
                sw = Stopwatch.StartNew();
                rating.TopMovies(10);
                sw.Stop();
                Assert.True(sw.ElapsedMilliseconds <= 4000);
            }
        }

        #endregion

        #region ReviewerMovies

        [Fact]
        public void ReviewerMoviesTest()
        {
            IMovieRating rating = new MovieRating();
            // List<BERating> ratings = ReadJSONTop10(PATH);

            // The first ten movies are all reviewed by reviewer #1.
            List<int> expected = firstTen.OrderByDescending(m => m.Rate).ThenByDescending(m => m.Date).Select(m => m.Movie).ToList();

            rating.Ratings = firstTen;

            Assert.Equal(expected, rating.RevieverMovies(1));
        }

        [Fact]
        public void ReviewerMoviePerfTest()
        {
            IMovieRating rating = new MovieRating
            {

                //List<BERating> ratings = ReadJSON(PATH);
                Ratings = allReviews
            };

            Stopwatch sw;

            for (int i = 0; i < 100; i++)
            {
                sw = Stopwatch.StartNew();
                rating.RevieverMovies(i);
                sw.Stop();
                Assert.True(sw.ElapsedMilliseconds <= 4000);
            }
        }

        #endregion

        #region MovieReviewers

        [Fact]
        public void MovieReviewersTest()
        {
            IMovieRating rating = new MovieRating();
            //List<BERating> ratings = ReadJSONTop10(PATH);

            List<int> expected = new List<int> { 1 }; // The first ten movies are all reviewed by reviewer #1.
            rating.Ratings = firstTen;

            Assert.Equal(expected, rating.MovieReviewers(1488844));
            Assert.Equal(expected, rating.MovieReviewers(822109));
            Assert.Equal(expected, rating.MovieReviewers(885013));
        }

        [Fact]
        public void MovieReviewersPerfTest()
        {
            IMovieRating rating = new MovieRating
            {
                //List<Review> reviews = ReadJSON(PATH);
                Ratings = allReviews
            };

            int[] ids = allReviews.Select(r => r.Movie).Take(200).ToArray(); // Select a bunch of movie ids

            Stopwatch sw;
            for (int i = 0; i < 200; i++)
            {
                sw = Stopwatch.StartNew();
                rating.MovieReviewers(ids[i]);
                sw.Stop();
                Assert.True(sw.ElapsedMilliseconds <= 4000);
            }
        }

        #endregion
    }
}
#endregion