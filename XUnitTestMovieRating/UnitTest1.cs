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

        private const string PATH = "C://Users//chris//OneDrive//Dokumente//GitHub//MovieRating//XUnitTestMovieRating//bin//Debug//netcoreapp3.1//ratings.json";

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

        #region GetAverageRateOfMovieTest


        [Fact]
        public void GetAverageRateOfMoviePerformanceTest()
        {

            IMovieRating mr = new MovieRating
            {
                Ratings = firstTen
            };

            Stopwatch sw = new Stopwatch();
            sw.Start();

            mr.GetAverageRateOfMovie(1488844);

            sw.Stop();
            Assert.True(sw.ElapsedMilliseconds < 4000);
        }
        #endregion


        #region GetNumberOfRates

        [Fact]
        public void GetNumberOfRates()
        {
            IMovieRating mr = new MovieRating
            {
                Ratings = firstTen
            };

            double res = mr.GetNumberOfRates(1488844, 3);
            var exp = 1;
            Assert.Equal(res, exp);

        }

        [Fact]
        public void GetNumberOfRatesCounterWithAllData()
        {
            IMovieRating mr = new MovieRating
            {
                Ratings = allReviews
            };

            double res = mr.GetNumberOfRates(1488844, 3);
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

            mr.GetNumberOfRates(1488844, 3);
            sw.Stop();
            Assert.True(sw.ElapsedMilliseconds < 4000);

        }

        #endregion

        #region GetMoviesWithHighestNumberOfTopRates

        [Fact]
        public void GetMoviesWithHighestNumberOfTopRates()
        {
            IMovieRating mr = new MovieRating
            {
                //List<Review> list = ReadJSONTop10(PATH);

                Ratings = firstTen
            };

            var res = mr.GetMoviesWithHighestNumberOfTopRates();
            List<int> exp = new List<int>() { 822109 };

            Assert.Equal(res, exp);

        }

        [Fact]
        public void GetMoviesWithHighestNumberOfTopRatesWithTop10Count()
        {
            IMovieRating mr = new MovieRating
            {
                //List<Review> list = ReadJSONTop10(PATH);

                Ratings = firstTen
            };

            var res = mr.GetMoviesWithHighestNumberOfTopRates().Count;
            var exp = 1;

            Assert.Equal(res, exp);

        }

        [Fact]
        public void GetMoviesWithHighestNumberOfTopRatesPerformanceTest()
        {
            IMovieRating mr = new MovieRating
            {
                // List<BERating> list = ReadJSON(PATH);

                Ratings = firstTen
            };

            Stopwatch sw = new Stopwatch();
            sw.Start();

            mr.GetMoviesWithHighestNumberOfTopRates();

            sw.Stop();

            Assert.True(sw.ElapsedMilliseconds < 4000);

        }
        #endregion

        #region GetMostProductiveReviewers

        [Fact]
        public void GetMostProductiveReviewersTest()
        {
            IMovieRating mr = new MovieRating
            {
                Ratings = allReviews
            };

            List<int> res = mr.GetMostProductiveReviewers();
            List<int> exp = new List<int> { 571 };
            Assert.Equal(res, exp);
        }

        [Fact]
        public void GetMostProductiveReviewersPerformanceTest()
        {
            IMovieRating mr = new MovieRating
            {
                Ratings = allReviews
            };

            Stopwatch sw = new Stopwatch();
            sw.Start();

            mr.GetMostProductiveReviewers();
            sw.Stop();
            Assert.True(sw.ElapsedMilliseconds < 4000);

        }
        #endregion

        #region GetNumberOfReviewsFromReviewer

        [Fact]
        public void GetNumberOfReviewsFromReviewerTest()
        {
            IMovieRating mr = new MovieRating
            {
                Ratings = firstTen
            };
            int res = mr.GetNumberOfReviewsFromReviewer(1);
            int exp = 10;
            Assert.Equal(res, exp);
        }

        [Fact]
        public void GetNumberOfReviewsFromReviewerPerformanceTest()
        {
            IMovieRating mr = new MovieRating
            {
                Ratings = allReviews
            };
            Random rnd = new Random();
            Stopwatch sw = Stopwatch.StartNew();
            mr.GetNumberOfReviewsFromReviewer(rnd.Next(1, 999));
            sw.Stop();
            Assert.True(sw.ElapsedMilliseconds < 4000);
        }
        #endregion

        #region GetAverageRateFromReviewerTest

        [Fact]
        public void GetAverageRateFromReviewerTest()
        {
            IMovieRating mr = new MovieRating
            {
                Ratings = firstTen
            };
            double res = mr.GetAverageRateFromReviewer(1);
            double exp = 3.6;
            Assert.Equal(res, exp);
        }

        [Fact]
        public void GetAverageRateFromReviewerPerformanceTest()
        {
            IMovieRating mr = new MovieRating
            {
                Ratings = allReviews
            };
            Random rnd = new Random();
            Stopwatch sw = Stopwatch.StartNew();
            double res = mr.GetAverageRateFromReviewer(rnd.Next(1, 999));
            sw.Stop();

            Assert.True(sw.ElapsedMilliseconds < 4000);
        }
        #endregion

        #region GetNumberOfRatesByReviewerTest

        [Fact]
        public void GetNumberOfRatesByReviewerTest()
        {
            IMovieRating mr = new MovieRating
            {
                Ratings = firstTen
            };
            int res = mr.GetNumberOfRatesByReviewer(1, 4);
            int exp = 4;

            Assert.Equal(res, exp);
        }

        [Fact]
        public void GetNumberOfRatesByReviewerPerformanceTest()
        {
            IMovieRating mr = new MovieRating
            {
                Ratings = allReviews
            };
            Random rnd = new Random();
            Stopwatch sw = Stopwatch.StartNew();
            int res = mr.GetNumberOfRatesByReviewer(rnd.Next(1, 999), rnd.Next(1, 5));
            sw.Stop();

            Assert.True(sw.ElapsedMilliseconds < 4000);
        }
        #endregion

        #region GetNumberOfReviewsTest

        [Fact]
        public void GetNumberOfReviewsTest()
        {
            IMovieRating mr = new MovieRating
            {
                Ratings = firstTen
            };
            int res = mr.GetNumberOfReviews(1488844);
            int exp = 1;

            Assert.Equal(res, exp);
        }

        [Fact]
        public void GetNumberOfReviewsPerformanceTest()
        {
            IMovieRating mr = new MovieRating
            {
                Ratings = allReviews
            };
            Random rnd = new Random();
            Stopwatch sw = Stopwatch.StartNew();
            int res = mr.GetNumberOfReviews(1488844);
            sw.Stop();

            Assert.True(sw.ElapsedMilliseconds < 4000);
        }
        #region GetTopRatedMoviesTests

        [Fact]
        public void GetTopRatedMoviesTest()
        {
            IMovieRating rating = new MovieRating
            {
                // List<BERating> ratings = ReadJSONTop10(PATH);
                Ratings = firstTen
            };

            int grade = 5;
            foreach (int item in rating.GetTopRatedMovies(10))
            {
                BERating review = firstTen.FirstOrDefault(r => r.Movie == item);
                Assert.True(grade >= review.Grade); // Ensure that the ratings are in the correct order
                grade = review.Grade;
            }
        }
        #endregion

        [Fact]
        public void GetTopRatedMoviesPerformanceTest()
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
                rating.GetTopRatedMovies(10);
                sw.Stop();
                Assert.True(sw.ElapsedMilliseconds <= 4000);
            }
        }

        #endregion

        #region GetTopMoviesByReviewer

        [Fact]
        public void GetTopMoviesByReviewerTest()
        {
            IMovieRating rating = new MovieRating();
            // List<BERating> ratings = ReadJSONTop10(PATH);

            // The first ten movies are all reviewed by reviewer #1.
            List<int> expected = firstTen.OrderByDescending(m => m.Grade).ThenByDescending(m => m.Date).Select(m => m.Movie).ToList();

            rating.Ratings = firstTen;

            Assert.Equal(expected, rating.GetTopMoviesByReviewer(1));
        }

        [Fact]
        public void GetTopMoviesByReviewerPerformanceTest()
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
                rating.GetTopMoviesByReviewer(i);
                sw.Stop();
                Assert.True(sw.ElapsedMilliseconds <= 4000);
            }
        }

        #endregion

        #region GetReviewersByMovie

        [Fact]
        public void GetReviewersByMovieTest()
        {
            IMovieRating rating = new MovieRating();
            //List<BERating> ratings = ReadJSONTop10(PATH);

            List<int> expected = new List<int> { 1 }; // The first ten movies are all reviewed by reviewer #1.
            rating.Ratings = firstTen;

            Assert.Equal(expected, rating.GetReviewersByMovie(1488844));
            Assert.Equal(expected, rating.GetReviewersByMovie(822109));
            Assert.Equal(expected, rating.GetReviewersByMovie(885013));
        }

        [Fact]
        public void GetReviewersByMoviePerformanceTest()
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
                rating.GetReviewersByMovie(ids[i]);
                sw.Stop();
                Assert.True(sw.ElapsedMilliseconds <= 4000);
            }
        }

        #endregion
    }
}
#endregion