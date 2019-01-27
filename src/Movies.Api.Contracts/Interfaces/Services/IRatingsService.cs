using System;
using System.Threading.Tasks;
using Movies.Api.Contracts.Models;

namespace Movies.Api.Contracts.Interfaces.Services
{
    public interface IRatingsService
    {
        Task<bool> AddOrUpdateRatingForMovie(Guid movieId, RatingDTO rating);
    }
}
