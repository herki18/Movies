using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Movies.Api.Contracts.Interfaces.Services;
using Movies.Api.Contracts.Models;
using Movies.Api.Contracts.Queries;

namespace Movies.Api.Controllers
{
    [Route("api/movies/{movieId}/ratings")]
    [ApiController]
    public class RatingsController : ControllerBase
    {
        private readonly IRatingsService _ratingsService;
        private readonly IUsersService _usersService;
        private readonly IMovieService _moviesService;
        private readonly ILogger<RatingsController> _logger;

        public RatingsController(IRatingsService ratingsService, 
            IUsersService usersService, 
            IMovieService moviesService, 
            ILogger<RatingsController> logger)
        {
            _ratingsService = ratingsService;
            _usersService = usersService;
            _moviesService = moviesService;
            _logger = logger;
        }

        [HttpPost]
        public async Task<IActionResult> UpdateRating(Guid movieId, [FromBody]RatingBody rating)
        {
            if (rating == null)
            {
                return BadRequest();
            }

            var movieExist = await _moviesService.CheckIfMovieExists(movieId);
            if (!movieExist)
            {
                _logger.LogInformation($"Movie does not exist with id: {movieId}");
                return NotFound();
            }

            var userExist = _usersService.CheckIfUserExists(rating.UserId);
            if (!userExist.Result)
            {
                _logger.LogInformation($"Movie does not exist with id: {rating?.UserId}");
                return NotFound();
            }

            var ratingDTO = new RatingDTO
            {
                UserId = rating.UserId,
                Rating = rating.Rating
            };
            try
            {
                if (await _ratingsService.AddOrUpdateRatingForMovie(movieId, ratingDTO))
                {
                    return Ok();
                }
            }
            catch (Exception e)
            {
                _logger.LogError(e.ToString());
                return BadRequest();
            }

            return BadRequest();
        }
    }
}
