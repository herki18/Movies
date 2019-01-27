using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using FluentAssertions;
using Movies.Api.Contracts.Models;
using Movies.Api.DAL;
using Newtonsoft.Json;
using Xunit;

namespace Movies.Api.Tests.Integration
{
    public class MoviesTests
    {
        [Fact]
        public async Task Should_Return_404_If_No_Movies_Are_Found()
        {
            using (var client = new TestClientProvider().Client)
            {
                var response = await client.GetAsync("/api/Movies?Title=Smoke&YearOfRelease=200&Genre=Fantasy");
                response.StatusCode.Should().Be(HttpStatusCode.NotFound);
            }
        }

        [Fact]
        public async Task Should_Return_400_If_Filter_Is_Not_Valid()
        {
            using (var client = new TestClientProvider().Client)
            {
                var response = await client.GetAsync("/api/Movies");
                response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
            }
        }

        [Fact]
        public async Task Should_Get_Movie_By_Title_And_Year_Of_Release_And_Genre()
        {
            using (var client = new TestClientProvider().Client)
            {
                var response = await client.GetAsync($"/api/Movies?Title={SeedData.BirdBoxMovie.Title}&YearOfRelease={SeedData.BirdBoxMovie.YearOfRelease}&Genre=Fantasy");
                response.StatusCode.Should().Be(HttpStatusCode.OK);

                var movies = JsonConvert.DeserializeObject<List<MovieDTO>>(response.Content.ReadAsStringAsync().Result);
                Assert.Single(movies);
                Assert.Equal(SeedData.BirdBoxMovie.Id, movies[0].Id);
                Assert.Equal(SeedData.BirdBoxMovie.Title, movies[0].Title);
                Assert.Equal(SeedData.BirdBoxMovie.YearOfRelease, movies[0].YearOfRelease);
            }
        }

        [Fact]
        public async Task Should_Get_Movie_By_Title()
        {
            using (var client = new TestClientProvider().Client)
            {
                var response = await client.GetAsync($"/api/Movies?Title={SeedData.AquamanMovie.Title}");
                response.StatusCode.Should().Be(HttpStatusCode.OK);

                var movies = JsonConvert.DeserializeObject<List<MovieDTO>>(response.Content.ReadAsStringAsync().Result);

                Assert.Single(movies);
                Assert.Equal(SeedData.AquamanMovie.Id, movies[0].Id);
                Assert.Equal(SeedData.AquamanMovie.Title, movies[0].Title);
                Assert.Equal(SeedData.AquamanMovie.YearOfRelease, movies[0].YearOfRelease);
            }
        }

        [Theory]
        [InlineData("Angry")]
        [InlineData("12")]
        public async Task Should_Get_Movie_By_Partial_Title(string partialTitle)
        {
            using (var client = new TestClientProvider().Client)
            {
                var response = await client.GetAsync($"/api/Movies?Title={partialTitle}");
                response.StatusCode.Should().Be(HttpStatusCode.OK);

                var movies = JsonConvert.DeserializeObject<List<MovieDTO>>(response.Content.ReadAsStringAsync().Result);

                Assert.Single(movies);
                Assert.Equal(SeedData.AngryManMovie.Id, movies[0].Id);
                Assert.Equal(SeedData.AngryManMovie.Title, movies[0].Title);
                Assert.Equal(SeedData.AngryManMovie.YearOfRelease, movies[0].YearOfRelease);
            }
        }

        [Fact]
        public async Task Should_Get_Movie_By_Genres()
        {
            using (var client = new TestClientProvider().Client)
            {
                var response = await client.GetAsync("/api/Movies?Genres=Fantasy");
                response.StatusCode.Should().Be(HttpStatusCode.OK);

                var movies = JsonConvert.DeserializeObject<List<MovieDTO>>(response.Content.ReadAsStringAsync().Result);

                Assert.Equal(2, movies.Count);
            }
        }

        [Fact]
        public async Task Should_Get_Movies_By_Multiple_Genres()
        {
            using (var client = new TestClientProvider().Client)
            {
                var response = await client.GetAsync("/api/Movies?Genres=Fantasy&Genres=Action");
                response.StatusCode.Should().Be(HttpStatusCode.OK);

                var movies = JsonConvert.DeserializeObject<List<MovieDTO>>(response.Content.ReadAsStringAsync().Result);

                Assert.Single(movies);
            }
        }

        [Fact]
        public async Task Should_Get_Two_Movies_By_Year_Of_Release_2018()
        {
            using (var client = new TestClientProvider().Client)
            {
                var response = await client.GetAsync("/api/Movies?YearOfRelease=2018");
                response.StatusCode.Should().Be(HttpStatusCode.OK);

                var movies = JsonConvert.DeserializeObject<List<MovieDTO>>(response.Content.ReadAsStringAsync().Result);

                Assert.Equal(2, movies.Count);
                Assert.Equal(SeedData.AquamanMovie.Id, movies[0].Id);
                Assert.Equal(SeedData.AquamanMovie.Title, movies[0].Title);
                Assert.Equal(SeedData.AquamanMovie.YearOfRelease, movies[0].YearOfRelease);

                Assert.Equal(SeedData.BirdBoxMovie.Id, movies[1].Id);
                Assert.Equal(SeedData.BirdBoxMovie.Title, movies[1].Title);
                Assert.Equal(SeedData.BirdBoxMovie.YearOfRelease, movies[1].YearOfRelease);
            }
        }
    }
}
