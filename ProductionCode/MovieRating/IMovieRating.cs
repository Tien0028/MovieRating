using ProductionCode.BE;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProductionCode.MovieRating
{
    public interface IMovieRating
    {

        HashSet<BERating> Ratings { get; set; }

        int GetNumberOfReviewsFromReviewer(int rID); 

        double GetAverageRateFromReviewer(int rID); 

        int GetNumberOfRatesByReviewer(int rID, int grade); 

        int GetNumberOfReviews(int mID); 

        double GetAverageRateOfMovie(int mID); 

        int GetNumberOfRates(int mID, int grade); 

        List<int> GetMoviesWithHighestNumberOfTopRates(); 

        List<int> GetMostProductiveReviewers();

        List<int> GetTopRatedMovies(int num); 

        List<int> GetTopMoviesByReviewer(int rID); 

        List<int> GetReviewersByMovie(int mID); 


    }
}
