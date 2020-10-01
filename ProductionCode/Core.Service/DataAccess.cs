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
        //private readonly List<BEReviewer> _beReviewer = new List<BEReviewer>();
        //private readonly List<BEMovie> _beMovie = new List<BEMovie>();
        public DataAccess(IFakeRepository @object)
        {   

        }

        public int GetNumberOfReviewsFromReviewer(int reviewer)
        {

            return _beRatings
                .Where(mr => mr.Reviewer == reviewer)
                .Count();
            
        }

        //public Tuple<List<BERating>, List<BEReviewer>> MultiValue(List<BERating> _beRatings, List<BEReviewer> _beReviewer)
        //{
        //    return Tuple.Create(_beRatings, _beReviewer);
        //}

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
            throw new Exception;
        }
        public int GetNumberOfReviews(int movie)
        {
            throw new Exception;
        }
        public double GetAverageRateOfMovie(int movie)
        {
            throw new Exception;
        }
        public List<int> GetMoviesWithHighestNumberOfTopRates()
        {
            throw new Exception;
        }
        public List<int> GetMostProductiveReviewers()
        {
            throw new Exception;
        }
        public List<int> GetTopRatedMovies(int amount)
        {
            throw new Exception;
        }
        public List<int> GetTopMoviesByReviewer(int reviewer)
        {

        }
        public List<int> GetReviewersByMovie(int movie)
        {

        }



    }
}
