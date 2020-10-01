using ProductionCode.BE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Schema;

namespace ProductionCode.Core.Service
{

    public class DataAccess
    {
        private readonly List<BERating> _beRatings = new List<BERating>();
        private IFakeRepository movieRep;
        private IFakeRepository mRep;

        public DataAccess(IFakeRepository @object)
        {

            mRep = movieRep;

        }


            public int GetNumberOfReviewsFromReviewer(int reviewer)
            {

                return _beRatings
                    .Where(mr => mr.Reviewer == reviewer)
                    .Count();

            }

            public double GetAverageRateFromReviewer(int reviewer)
            {
                return _beRatings
                    .Where(mr => mr.Reviewer == reviewer)
                    .Select(mr => mr.Rate)
                    .DefaultIfEmpty(0)
                    .Average();
            }
            public int GetNumberOfRatesByReviewer(int reviewer, int rate)
            {
                return _beRatings.Where(mr => mr.Reviewer == reviewer).Where(mr => mr.Rate == rate).Count();
            }
            public int GetNumberOfReviews(int movie)
            {
                return _beRatings.Where(mr => mr.Movie == movie).Count();
            }
            public double GetAverageRateOfMovie(int movie)
            {
                return _beRatings.Where(mr => mr.Movie == movie)
                    .Select(mr => mr.Rate)
                    .DefaultIfEmpty(0)
                    .Average();
            }
            public List<int> GetMoviesWithHighestNumberOfTopRates()
            {
                return _beRatings.OrderByDescending(mr => mr.Rate).Select(mr => mr.Movie).Distinct().ToList();
            }
            public List<int> GetMostProductiveReviewers()
            {
                return _beRatings.GroupBy(mr => mr.Reviewer).OrderByDescending(mr => mr.Count()).Select(mr => mr.Key).ToList();
            }
        public List<int> GetTopRatedMovies(int amount)
        {
            return _beRatings
              .OrderByDescending(mr => mr.Rate)
              .Select(mr => mr.Movie)
              .Distinct()
              .Take(amount)
              .ToList();
        }
        public List<int> GetTopMoviesByReviewer(int reviewer)
        {
            return _beRatings.OrderByDescending(mr => mr.Reviewer == reviewer).Select(mr => mr.Movie).Distinct().ToList();
        }
        public List<BERating> GetReviewersByMovie(int movie)
        {
            return _beRatings.Where(mr => mr.Movie == movie).OrderByDescending(mr => mr.Rate).ThenByDescending(mr => mr.Date).ToList();

        }




    }
}
