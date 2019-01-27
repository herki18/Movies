using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Movies.Api.Contracts.Entities;

namespace Movies.Api.Contracts.Interfaces.Repositories
{
    public interface IRatingsRepository
    {
        Task<IList<RatingEntity>> GetRatingsByMovieId(Guid id);
        Task<bool> AddOrUpdateRatingForMovie(Guid movieId, RatingEntity rating);
    }
}
