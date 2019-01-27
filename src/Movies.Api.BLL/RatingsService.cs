using System;
using System.Threading.Tasks;
using AutoMapper;
using Movies.Api.Contracts.Entities;
using Movies.Api.Contracts.Interfaces.Repositories;
using Movies.Api.Contracts.Interfaces.Services;
using Movies.Api.Contracts.Models;

namespace Movies.Api.BLL
{
    public class RatingsService : IRatingsService
    {
        private readonly IMapper _mapper;
        private readonly IRatingsRepository _ratingsRepository;

        public RatingsService(IMapper mapper, IRatingsRepository ratingsRepository)
        {
            _mapper = mapper;
            _ratingsRepository = ratingsRepository;
        }

        public async Task<bool> AddOrUpdateRatingForMovie(Guid movieId, RatingDTO rating)
        {
            var ratingEntity = _mapper.Map<RatingEntity>(rating);
            
            return await _ratingsRepository.AddOrUpdateRatingForMovie(movieId, ratingEntity);
        }
    }
}