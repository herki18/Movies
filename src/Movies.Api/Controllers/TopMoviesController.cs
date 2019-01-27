using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Movies.Api.Contracts.Interfaces.Services;

namespace Movies.Api.Controllers
{
    [Route("api/movies/top")]
    [ApiController]
    public class TopMoviesController : ControllerBase
    {
        private readonly IMovieService _movieService;
        private readonly IUsersService _usersService;
        private readonly ILogger<TopMoviesController> _logger;

        public TopMoviesController(IMovieService movieService, IUsersService usersService, ILogger<TopMoviesController> logger)
        {
            _movieService = movieService;
            _usersService = usersService;
            _logger = logger;
        }

        [HttpGet()]
        public async Task<IActionResult> GetTopFiveMovies()
        {
            var movies = await _movieService.GetMoviesByAverageRating();

            if (movies == null || movies.Count == 0)
            {
                _logger.LogInformation($"No movies where found");
                return NotFound();
            }

            return Ok(movies);
        }

        [HttpGet("{userId}")]
        public async Task<IActionResult> GetTopFiveMovies(Guid userId)
        {
            var userExist = await _usersService.CheckIfUserExists(userId);
            if (!userExist)
            {
                _logger.LogInformation($"User doesn't exist: {userId}");
                return NotFound();
            }

            var movies = await _movieService.GetMoviesByAverageRatingForUser(userId);

            if (movies == null || movies.Count == 0)
            {
                _logger.LogInformation($"No movies where found for given User: {userId}");
                return NotFound();
            }

            return Ok(movies);
        }
    }
}