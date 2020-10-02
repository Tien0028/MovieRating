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


        public double AvgOfReviewer(int rID) //  GetAverageRateFromReviewer
        {
            double avg = Ratings.Where(x => x.Reviewer == rID).Average(x => x.Rate);
            return avg;
        }

        public int GradeCountByID(int rID, int grade) // GetNumberOfRatesByReviewer
        {
            int count = Ratings.Where(x => x.Reviewer == rID && x.Rate == grade).Count();
            return count;
        }

        public List<int> MovieMostTopRate() //  GetMoviesWithHighestNumberOfTopRates
        {
            var topRatedMoviesGrade = Ratings.Where(r => r.Rate == 5).Select(r => r.Movie).ToList();

            return topRatedMoviesGrade;
        }

        public double MovieReviewAvg(int mID) // GetAverageRateOfMovie
        {
            var averageRate = Ratings.Where(BERating => mID == BERating.Movie).Average(r => r.Rate);

            return averageRate;

        }

        public int MovieReviewByGrade(int mID, int grade) //  GetNumberOfRates
        {
            var gradeCounter = Ratings.Where(BERating => mID == BERating.Movie && BERating.Rate == grade).Count();

            return gradeCounter;
        }

        public int MovieReviewerCount(int mID)
        {
            int count = Ratings.Where(x => x.Movie == mID).Count();
            return count;
        }

        public int NumberOfReviews(int rID)
        {
            int count = Ratings.Where(x => x.Reviewer == rID).Count();
            return count;
        }

        public List<int> RevieverMovies(int rID)
        {
            List<int> reviewerMovies = Ratings.Where(m => m.Reviewer == rID)
                .OrderByDescending(m => m.Rate).ThenByDescending(m => m.Date)
                .Select(m => m.Movie).ToList();

            return reviewerMovies;
        }

        public List<int> ReviewerTopCount()
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

        public List<int> TopMovies(int num)
        {
            var res = Ratings.AsParallel().GroupBy(r => r.Movie).Select(result => new { mov = result.Key, avg = result.Average(m => m.Rate) });

            var ordered = res.OrderByDescending(m => m.avg).Take(num).Select(m => m.mov).ToList();
            return ordered;
        }

        public List<int> MovieReviewers(int mID)
        {
            List<int> reviewers = Ratings.Where(r => r.Movie == mID)
                .OrderByDescending(m => m.Rate).ThenByDescending(m => m.Date)
                .Select(m => m.Reviewer).ToList();
            return reviewers;
        }
    }
}
