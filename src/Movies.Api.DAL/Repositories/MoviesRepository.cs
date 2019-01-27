using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Movies.Api.Contracts.Entities;
using Movies.Api.Contracts.Interfaces.Repositories;
using Movies.Api.Contracts.Queries;

namespace Movies.Api.DAL.Repositories
{
    public class MoviesRepository : IMoviesRepository
    {
        private readonly ApiContext _context;

        public MoviesRepository(ApiContext context)
        {
            _context = context;
        }

        public async Task<IList<MovieEntity>> GetMovies(MoviesQuery query)
        {
            var queryable = _context.Movies.AsQueryable();
            
            if (query.Title != null && !string.IsNullOrWhiteSpace(query.Title))
            {
                queryable = queryable.Where(t => EF.Functions.Like(t.Title, $"%{query.Title}%")).AsQueryable();
            }

            if (query.YearOfRelease.HasValue)
            {
                queryable = queryable.Where(t => t.YearOfRelease == query.YearOfRelease).AsQueryable();
            }
            
            if (query.Genres != null && query.Genres.Count != 0)
            {
                foreach (var genre in query.Genres)
                {
                    queryable = queryable.Where(movie => movie.GenreMovies.Any(t => t.Genre.Name == genre));
                }
            }

            var movies = queryable.Select(movie => new MovieEntity
            {
                Id = movie.Id,
                Title = movie.Title,
                RunningTime = movie.RunningTime,
                YearOfRelease = movie.YearOfRelease,
                AverageRating = movie.Ratings.Select(r => (int?)r.Rating).Average()
            }).ToListAsync();

            return await movies;
        }
        public async Task<IList<MovieEntity>> GetMoviesByAverageRating()
        {
            var movies = _context.Movies
                .Select(movie => new MovieEntity()
                {
                    Id = movie.Id,
                    RunningTime = movie.RunningTime,
                    AverageRating = movie.Ratings.Select(r => (int?)r.Rating).Average(),
                    Title = movie.Title,
                    YearOfRelease = movie.YearOfRelease
                })
                .OrderByDescending(x => x.AverageRating)
                .ThenBy(x => x.Title).Take(5).ToListAsync();

            return await movies;
        }

        public async Task<IList<MovieEntity>> GetMoviesByAverageRatingForUser(Guid userId)
        {
            var movies = _context.Movies
                .Where(x => x.Ratings.Any(u => u.UserId == userId))
                .Select(movie => new MovieEntity()
                {
                    Id = movie.Id,
                    RunningTime = movie.RunningTime,
                    AverageRating = movie.Ratings.Where(u => u.UserId == userId).Select(r => (int?)r.Rating).Average(),
                    Title = movie.Title,
                    YearOfRelease = movie.YearOfRelease
                })
                .OrderByDescending(x => x.AverageRating)
                .ThenBy(x => x.Title).Take(5).ToListAsync();

            return await movies;
        }
        
        public async Task<bool> CheckIfMovieExists(Guid guid)
        {
            var doesExist = await _context.Movies.FindAsync(guid);
            return doesExist != null;
        }
    }
}
