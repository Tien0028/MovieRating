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
        private readonly List<BEReviewer> _beReviewer = new List<BEReviewer>();
        private readonly List<BEMovie> _beMovie = new List<BEMovie>();
        public DataAccess()
        {   

        }

        public int GetNumberOfReviewsFromReviewer(int reviewer)
        {

            return _beReviewer.Where(mr => mr.Reviewer == reviewer).Count();
            
        }

        public double GetAverageRateFromReviewer(int reviewer)
        {

        }
        public int GetNumberOfRatesByReviewer(int reviewer, int rate)
        {

        }
        public int GetNumberOfReviews(int movie)
        {

        }
        public double GetAverageRateOfMovie(int movie)
        {

        }
        public List<int> GetMoviesWithHighestNumberOfTopRates()
        {

        }
        public List<int> GetMostProductiveReviewers()
        {

        }
        public List<int> GetTopRatedMovies(int amount)
        {

        }
        public List<int> GetTopMoviesByReviewer(int reviewer)
        {

        }
        public List<int> GetReviewersByMovie(int movie)
        {

        }



    }
}
