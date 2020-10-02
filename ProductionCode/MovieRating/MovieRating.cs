using ProductionCode.BE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProductionCode.MovieRating
{
    public class MovieRating
    {

        public HashSet<BERating> Ratings { get; set; }

        public double AvgOfReviewer(int rID)
        {
            double avg = Ratings.Where(x => x.Reviewer == rID).Average(x => x.Rate);
            return avg;
        }

        public int GradeCountByID(int rID, int grade)
        {
            int count = Ratings.Where(x => x.Reviewer == rID && x.Rate == grade).Count();
            return count;
        }

        public List<int> MovieMostTopRate()
        {
            var topRatedMoviesGrade = Ratings.Where(r => r.Rate == 5).Select(r => r.Movie).ToList();

            return topRatedMoviesGrade;
        }

        public double MovieReviewAvg(int mID)
        {
            var averageRate = Ratings.Where(BERating => mID == BERating.Movie).Average(r => r.Rate);

            return averageRate;

        }

        public int MovieReviewByGrade(int mID, int grade)
        {
            var gradeCounter = Ratings.Where(BERating => mID == BERating.Movie && BERating.Rate == grade).Count();

            return gradeCounter;
        }

    }
}
