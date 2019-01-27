using System;
using AutoMapper;
using Movies.Api.Contracts.Entities;
using Movies.Api.Contracts.Models;
using Xunit;

namespace Movies.Api.Contracts.Tests.Unit
{
    public class MappingTests
    {
        private readonly IMapper _mapper;

        public MappingTests()
        {
            _mapper = new MapperConfiguration(mappings =>
            {
                mappings.CreateMissingTypeMaps = false;
                mappings.AddProfile<MappingProfiles>();
            }).CreateMapper();
        }

        [Fact]
        public void Should_Map_MovieDTO_To_MovieEntity()
        {
            var movieDTO = new MovieDTO
            {
                Id = new Guid("C6B2F33F-C249-49BD-8830-0EC88F8F4B0F"),
                Title = "MovieTest",
                YearOfRelease = 2018,
            };
            
            var movieEntity = _mapper.Map<MovieEntity>(movieDTO);

            Assert.Equal(movieDTO.Id, movieEntity.Id);
            Assert.Equal(movieDTO.Title, movieEntity.Title);
            Assert.Equal(movieDTO.YearOfRelease, movieEntity.YearOfRelease);
        }

        [Fact]
        public void Should_Map_MovieEntity_To_MovieDTO()
        {
            var movieEntity = new MovieEntity()
            {
                Id = new Guid("C6B2F33F-C249-49BD-8830-0EC88F8F4B0F"),
                Title = "MovieTest",
                YearOfRelease = 2018,
            };

            var userEntity = new UserEntity {Id = Guid.NewGuid(), UserName = "TestUser"};

            var genreEntity = new GenreEntity { Id = Guid.NewGuid(), Name = "Fantasy" };

            var ratingEntity = new RatingEntity
            {
                Id = Guid.NewGuid(),
                Movie = movieEntity,
                MovieId = movieEntity.Id,
                Rating = 5,
                User = userEntity,
                UserId = userEntity.Id
            };

            movieEntity.GenreMovies.Add(new GenreMovieEntity() { Genre = genreEntity });
            movieEntity.Ratings.Add(ratingEntity);

            var movieDTO = _mapper.Map<MovieDTO>(movieEntity);

            Assert.Equal(movieEntity.Id, movieDTO.Id);
            Assert.Equal(movieEntity.Title, movieDTO.Title);
            Assert.Equal(movieEntity.YearOfRelease, movieDTO.YearOfRelease);
            Assert.Equal(movieEntity.RunningTime, movieDTO.RunningTime);
        }

        [Fact]
        public void Should_Map_RatingEntity_To_RatingDTO()
        {
            var ratingEntity = new RatingEntity()
            {
                Id = new Guid("C6B2F33F-C249-49BD-8830-0EC88F8F4B0F"),
                Rating = 4
            };

            var ratingDTO = _mapper.Map<RatingDTO>(ratingEntity);

            Assert.Equal(ratingEntity.Id, ratingDTO.Id);
            Assert.Equal(ratingEntity.Rating, ratingDTO.Rating);
        }

        [Fact]
        public void Should_Map_RatingDTO_To_RatingEntity()
        {
            var ratingDTO = new RatingDTO()
            {
                Id = new Guid("C6B2F33F-C249-49BD-8830-0EC88F8F4B0F"),
                Rating = 4,
                UserId = new Guid("3EF9B898-BCF7-41AC-82B0-D4B23C87243F")
            };

            var ratingEntity = _mapper.Map<RatingEntity>(ratingDTO);

            Assert.Equal(ratingDTO.Id, ratingEntity.Id);
            Assert.Equal(ratingDTO.Rating, ratingEntity.Rating);
        }

        [Fact]
        public void Should_Map_UserDTO_To_UserEntity()
        {
            var userDTO = new UserDTO()
            {
                Id = new Guid("C6B2F33F-C249-49BD-8830-0EC88F8F4B0F"),
                UserName = "Test"
            };

            var userEntity = _mapper.Map<UserEntity>(userDTO);

            Assert.Equal(userDTO.Id, userEntity.Id);
            Assert.Equal(userDTO.UserName, userEntity.UserName);
        }

        [Fact]
        public void Should_Map_UserEntity_To_UserDTO()
        {
            var userEntity = new UserEntity()
            {
                Id = new Guid("C6B2F33F-C249-49BD-8830-0EC88F8F4B0F"),
                UserName = "Test"
            };

            var userDTO = _mapper.Map<UserDTO>(userEntity);

            Assert.Equal(userEntity.Id, userDTO.Id);
            Assert.Equal(userEntity.UserName, userDTO.UserName);
        }

        [Fact]
        public void Should_Map_GenreEntity_To_GenreDTO()
        {
            var genreEntity = new GenreEntity()
            {
                Id = new Guid("C6B2F33F-C249-49BD-8830-0EC88F8F4B0F"),
                Name = "Fantasy"
            };

            var genreDTO = _mapper.Map<GenreDTO>(genreEntity);

            Assert.Equal(genreEntity.Id, genreDTO.Id);
            Assert.Equal(genreEntity.Name, genreDTO.Name);
        }

        [Fact]
        public void Should_Map_GenreDTO_To_GenreEntity()
        {
            var genreDTO = new GenreDTO()
            {
                Id = new Guid("C6B2F33F-C249-49BD-8830-0EC88F8F4B0F"),
                Name = "Fantasy"
            };

            var genreEntity = _mapper.Map<GenreEntity>(genreDTO);

            Assert.Equal(genreDTO.Id, genreEntity.Id);
            Assert.Equal(genreDTO.Name, genreEntity.Name);
        }
    }
}
