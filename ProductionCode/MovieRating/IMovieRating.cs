using ProductionCode.BE;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProductionCode.MovieRating
{
    public interface IMovieRating
    {

        HashSet<BERating> Ratings { get; set; }

        int NumberOfReviews(int rID); // GetNumberOfReviewsFromReviewer

        double AvgOfReviewer(int rID); //  GetAverageRateFromReviewer

        int GradeCountByID(int rID, int grade); // GetNumberOfRatesByReviewer

        int MovieReviewerCount(int mID); //  GetNumberOfReviews

        double MovieReviewAvg(int mID); // GetAverageRateOfMovie

        int MovieReviewByGrade(int mID, int grade);  //  GetNumberOfRates

        List<int> MovieMostTopRate(); //  GetMoviesWithHighestNumberOfTopRates

        List<int> ReviewerTopCount(); // GetMostProductiveReviewers

        List<int> TopMovies(int num); // GetTopRatedMovies

        List<int> RevieverMovies(int rID);  //  GetTopMoviesByReviewer

        List<int> MovieReviewers(int mID); // GetReviewersByMovie


    }
}
