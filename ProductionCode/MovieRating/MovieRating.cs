using ProductionCode.BE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProductionCode.MovieRating
{
    public class MovieRating: IMovieRating
    {

        public HashSet<BERating> Ratings { get; set; }


        public double GetAverageRateFromReviewer(int rID)
        {
            double avg = Ratings.Where(x => x.Reviewer == rID).Average(x => x.Grade);
            return avg;
        }

        public int GetNumberOfRatesByReviewer(int rID, int grade) 
        {
            int count = Ratings.Where(x => x.Reviewer == rID && x.Grade == grade).Count();
            return count;
        }

        public List<int> GetMoviesWithHighestNumberOfTopRates() 
        {
            var topRatedMoviesGrade = Ratings.Where(r => r.Grade == 5).Select(r => r.Movie).ToList();

            return topRatedMoviesGrade;
        }

        public double GetAverageRateOfMovie(int mID) 
        {
            var averageRate = Ratings.Where(BERating => mID == BERating.Movie).Average(r => r.Grade);

            return averageRate;

        }

        public int GetNumberOfRates(int mID, int grade) 
        {
            var gradeCounter = Ratings.Where(BERating => mID == BERating.Movie && BERating.Grade == grade).Count();

            return gradeCounter;
        }

        public int GetNumberOfReviews(int mID)
        {
            int count = Ratings.Where(x => x.Movie == mID).Count();
            return count;
        }

        public int GetNumberOfReviewsFromReviewer(int rID)
        {
            int count = Ratings.Where(x => x.Reviewer == rID).Count();
            return count;
        }

        public List<int> GetTopMoviesByReviewer(int rID)
        {
            List<int> reviewerMovies = Ratings.Where(m => m.Reviewer == rID)
                .OrderByDescending(m => m.Grade).ThenByDescending(m => m.Date)
                .Select(m => m.Movie).ToList();

            return reviewerMovies;
        }

        public List<int> GetMostProductiveReviewers()
        {
            var reviewerCounted = Ratings.GroupBy(r => r.Reviewer).Select(g => g.Count()).ToList();
            List<int> list = new List<int>();
            int max = -1;
            for (int i = 0; i < reviewerCounted.Count(); i++)
            {
                if (reviewerCounted[i] == max)
                {
                    list.Add(i + 1);
                }

                if (reviewerCounted[i] > max)
                {
                    list.Clear();
                    max = reviewerCounted[i];
                    list.Add(i + 1);
                }
            }
            return list;
        }

        public List<int> GetTopRatedMovies(int num)
        {
            var res = Ratings.AsParallel().GroupBy(r => r.Movie).Select(result => new { mov = result.Key, avg = result.Average(m => m.Grade) });

            var ordered = res.OrderByDescending(m => m.avg).Take(num).Select(m => m.mov).ToList();
            return ordered;
        }

        public List<int> GetReviewersByMovie(int mID)
        {
            List<int> reviewers = Ratings.Where(r => r.Movie == mID)
                .OrderByDescending(m => m.Grade).ThenByDescending(m => m.Date)
                .Select(m => m.Reviewer).ToList();
            return reviewers;
        }
    }
}
