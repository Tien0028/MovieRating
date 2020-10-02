using ProductionCode.BE;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProductionCode.MovieRating
{
    public interface IMovieRating
    {

        HashSet<BERating> Ratings { get; set; }

        int GetNumberOfReviewsFromReviewer(int rID); // GetNumberOfReviewsFromReviewer

        double AGetAverageRateFromReviewervgOfReviewer(int rID); //  GetAverageRateFromReviewer

        int GetNumberOfRatesByReviewer(int rID, int grade); // GetNumberOfRatesByReviewer

        int GetNumberOfReviews(int mID); //  GetNumberOfReviews

        double GetAverageRateOfMovie(int mID); // GetAverageRateOfMovie

        int GetNumberOfRates(int mID, int grade);  //  GetNumberOfRates

        List<int> GetMoviesWithHighestNumberOfTopRates(); //  GetMoviesWithHighestNumberOfTopRates

        List<int> GetMostProductiveReviewers(); // GetMostProductiveReviewers

        List<int> GetTopRatedMovies(int num); // GetTopRatedMovies

        List<int> GetTopMoviesByReviewer(int rID);  //  GetTopMoviesByReviewer

        List<int> GetReviewersByMovie(int mID); // GetReviewersByMovie


    }
}
