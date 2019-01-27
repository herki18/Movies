using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Movies.Api.Contracts.Interfaces.Services;
using Movies.Api.Contracts.Queries;

namespace Movies.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private readonly IMovieService _movieService;
        private readonly ILogger<MoviesController> _logger;

        public MoviesController(IMovieService movieService, ILogger<MoviesController> logger)
        {
            _movieService = movieService;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery]MoviesQuery query)
        {
            var movies = await _movieService.GetMovies(query);

            if (movies == null || movies.Count == 0)
            {
                _logger.LogInformation($"Movies by those queries cannot be found. Title: " +
                                       $"{query?.Title}, Year Of Release: " +
                                       $"{query?.YearOfRelease}, " +
                                       $"{query?.Genres?.Aggregate((a, b) => a + "," + b)}");
                return NotFound();
            }
            _logger.LogInformation($"Return Movies with Titles: {string.Join(',', movies.Select(x=> x.Title))}");
            return Ok(movies);
        }
    }
}
