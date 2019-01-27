using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Movies.Api.Contracts.Queries;

namespace Movies.Api.Contracts.Interfaces.Services
{
    public interface IMovieService
    {
        Task<IList<Models.MovieDTO>> GetMovies(MoviesQuery query);
        Task<IList<Models.MovieDTO>> GetMoviesByAverageRating();
        Task<IList<Models.MovieDTO>> GetMoviesByAverageRatingForUser(Guid userId);
        Task<bool> CheckIfMovieExists(Guid movieId);
    }
}
