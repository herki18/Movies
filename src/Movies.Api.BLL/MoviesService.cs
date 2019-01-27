using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Movies.Api.Contracts.Interfaces.Repositories;
using Movies.Api.Contracts.Interfaces.Services;
using Movies.Api.Contracts.Models;
using Movies.Api.Contracts.Queries;

namespace Movies.Api.BLL
{
    public class MoviesService : IMovieService
    {
        private readonly IMoviesRepository _movieRepository;
        private readonly IMapper _mapper;

        public MoviesService(IMoviesRepository movieRepository,
            IMapper mapper
            )
        {
            _movieRepository = movieRepository;
            _mapper = mapper;
        }

        public async Task<IList<MovieDTO>> GetMovies(MoviesQuery query)
        {
            var eMovies = await _movieRepository.GetMovies(query);

            foreach (var entity in eMovies)
            {
                if (entity.AverageRating != null) entity.AverageRating = NormalizeAverageRating(entity.AverageRating.Value);
            }

            return _mapper.Map<IList<MovieDTO>>(eMovies);
        }

        public async Task<IList<MovieDTO>> GetMoviesByAverageRating()
        {
            var eMovies = await _movieRepository.GetMoviesByAverageRating();

            foreach (var entity in eMovies)
            {
                if (entity.AverageRating != null) entity.AverageRating = NormalizeAverageRating(entity.AverageRating.Value);
            }

            return _mapper.Map<IList<MovieDTO>>(eMovies);
        }

        public async Task<IList<MovieDTO>> GetMoviesByAverageRatingForUser(Guid userId)
        {
            var eMovies = await _movieRepository.GetMoviesByAverageRatingForUser(userId);

            foreach (var entity in eMovies)
            {
                if (entity.AverageRating != null) entity.AverageRating = NormalizeAverageRating(entity.AverageRating.Value);
            }

            return _mapper.Map<IList<MovieDTO>>(eMovies);
        }

        public async Task<bool> CheckIfMovieExists(Guid movieId)
        {
            return await _movieRepository.CheckIfMovieExists(movieId);
        }

        private double NormalizeAverageRating(double rating)
        {
            var normalizedRating = Math.Round(rating * 2, MidpointRounding.AwayFromZero) / 2;
            
            return normalizedRating;
        }
    }
}
