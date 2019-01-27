using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using Movies.Api.Contracts.Interfaces.Services;
using Movies.Api.Contracts.Models;
using Movies.Api.Controllers;
using Xunit;

namespace Movies.Api.Tests.Unit
{
    public class TopMoviesControllerTests
    {
        [Fact]
        public async Task Should_Return_404_If_No_Movies_Are_Found()
        {
            var mockService = new Mock<IMovieService>();
            var userService = new Mock<IUsersService>();
            var logger = new Mock<ILogger<TopMoviesController>>();

            mockService
                .Setup(x => x.GetMoviesByAverageRating())
                .ReturnsAsync(new List<MovieDTO>());

            userService
                .Setup(x => x.CheckIfUserExists(new Guid("FE59C9AC-A950-4F1F-AD87-2492D070E8C9")))
                .ReturnsAsync(true);
            
            var top = new TopMoviesController(mockService.Object, userService.Object, logger.Object);

            var response = await top.GetTopFiveMovies();

            mockService.Verify(x => x.GetMoviesByAverageRating(), Times.Once);
            Assert.IsType<NotFoundResult>(response);
        }
    }
}
