using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Movies.Api.Contracts.Entities;
using Movies.Api.Contracts.Interfaces.Repositories;

namespace Movies.Api.DAL.Repositories
{
    public class RatingsRepository : IRatingsRepository
    {
        private readonly ApiContext _apiContext;

        public RatingsRepository(ApiContext apiContext)
        {
            _apiContext = apiContext;
        }

        public async Task<IList<RatingEntity>> GetRatingsByMovieId(Guid id)
        {
            return await _apiContext.Ratings.Where(rating => rating.MovieId == id).ToListAsync();
        }

        public async Task<bool> AddOrUpdateRatingForMovie(Guid movieId, RatingEntity rating)
        {
            if (rating != null)
            {
                var ratingTemp = _apiContext.Ratings.SingleOrDefault(r => r.MovieId == movieId && r.UserId == rating.UserId);
                if (ratingTemp != null)
                {
                    ratingTemp.Rating = rating.Rating;
                    _apiContext.Ratings.Update(ratingTemp);
                }
                else
                {
                    _apiContext.Ratings.Add(rating);
                }

                if (!(await _apiContext.SaveChangesAsync() >= 0))
                {
                    throw new Exception($"Creating/Updating a rating for movie {movieId} with user {rating.UserId} failed on save.");
                }

                return true;
            }

            return false;
        }
    }
}
