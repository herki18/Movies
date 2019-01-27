using System;
using System.Collections.Generic;
using AutoMapper;
using Moq;
using Movies.Api.Contracts;
using Movies.Api.Contracts.Entities;
using Movies.Api.Contracts.Interfaces.Repositories;
using Xunit;

namespace Movies.Api.BLL.Tests.Unit
{
    public class MoviesServiceTests
    {
        private readonly IMapper _mapper;
        public MoviesServiceTests()
        {
            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MappingProfiles());
            });

            _mapper = mappingConfig.CreateMapper();
        }

        [Fact]
        public void Should_Round_Average_Rating_291_To_30()
        {
            var moviesRepository = new Mock<IMoviesRepository>();
            moviesRepository
                .Setup(x => x.GetMoviesByAverageRating())
                .ReturnsAsync(new List<MovieEntity>() { new MovieEntity()
                {
                    Id = Guid.NewGuid(),
                    AverageRating = 2.91
                }});

            var movieService = new MoviesService(moviesRepository.Object, _mapper);
            
            var moviesDTO = movieService.GetMoviesByAverageRating();

            Assert.Equal(3.0, moviesDTO.Result[0].AverageRating);
        }

        [Fact]
        public void Should_Round_Average_Rating_3249_To_30()
        {
            var moviesRepository = new Mock<IMoviesRepository>();
            moviesRepository
                .Setup(x => x.GetMoviesByAverageRating())
                .ReturnsAsync(new List<MovieEntity>() { new MovieEntity()
                {
                    Id = Guid.NewGuid(),
                    AverageRating = 3.249
                }});

            var movieService = new MoviesService(moviesRepository.Object, _mapper);

            var moviesDTO = movieService.GetMoviesByAverageRating();

            Assert.Equal(3.0, moviesDTO.Result[0].AverageRating);
        }

        [Fact]
        public void Should_Round_Average_Rating_325_To_35()
        {
            var moviesRepository = new Mock<IMoviesRepository>();
            moviesRepository
                .Setup(x => x.GetMoviesByAverageRating())
                .ReturnsAsync(new List<MovieEntity>() { new MovieEntity()
                {
                    Id = Guid.NewGuid(),
                    AverageRating = 3.25
                }});

            var movieService = new MoviesService(moviesRepository.Object, _mapper);

            var moviesDTO = movieService.GetMoviesByAverageRating();

            Assert.Equal(3.5, moviesDTO.Result[0].AverageRating);
        }

        [Fact]
        public void Should_Round_Average_Rating_36_To_35()
        {
            var moviesRepository = new Mock<IMoviesRepository>();
            moviesRepository
                .Setup(x => x.GetMoviesByAverageRating())
                .ReturnsAsync(new List<MovieEntity>() { new MovieEntity()
                {
                    Id = Guid.NewGuid(),
                    AverageRating = 3.6
                }});

            var movieService = new MoviesService(moviesRepository.Object, _mapper);

            var moviesDTO = movieService.GetMoviesByAverageRating();

            Assert.Equal(3.5, moviesDTO.Result[0].AverageRating);
        }

        [Fact]
        public void Should_Round_Average_Rating_375_To_40()
        {
            var moviesRepository = new Mock<IMoviesRepository>();
            moviesRepository
                .Setup(x => x.GetMoviesByAverageRating())
                .ReturnsAsync(new List<MovieEntity>() { new MovieEntity()
                {
                    Id = Guid.NewGuid(),
                    AverageRating = 3.75
                }});

            var movieService = new MoviesService(moviesRepository.Object, _mapper);

            var moviesDTO = movieService.GetMoviesByAverageRating();

            Assert.Equal(4.0, moviesDTO.Result[0].AverageRating);
        }
    }
}
