using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Movies.Api.Contracts.Queries;

namespace Movies.Api.Contracts.Interfaces.Repositories
{
    public interface IMoviesRepository
    {
        Task<IList<Entities.MovieEntity>> GetMovies(MoviesQuery query);
        Task<IList<Entities.MovieEntity>> GetMoviesByAverageRating();
        Task<IList<Entities.MovieEntity>> GetMoviesByAverageRatingForUser(Guid userId);
        Task<bool> CheckIfMovieExists(Guid guid);
    }
}
