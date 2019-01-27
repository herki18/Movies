using System;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using Movies.Api.Contracts.Queries;
using Movies.Api.DAL;
using Newtonsoft.Json;
using Xunit;

namespace Movies.Api.Tests.Integration
{
    public class RatingsTests
    {
        [Fact]
        public async Task Should_Return_404_If_No_Movies_Are_Found()
        {
            using (var client = new TestClientProvider().Client)
            {
                var json = JsonConvert.SerializeObject(new RatingBody
                {
                    UserId = SeedData.TestUser.Id,
                    Rating = 5
                });

                var content = new StringContent(json, Encoding.UTF8, "application/json");

                var response = await client.PostAsync("/api/Movies/A1E6A1B0-64BD-4A82-9765-F3CAD6F9D0A1/ratings", content);
                response.StatusCode.Should().Be(HttpStatusCode.NotFound);
            }
        }

        [Fact]
        public async Task Should_Return_404_If_User_Is_Not_Found()
        {
            using (var client = new TestClientProvider().Client)
            {
                var json = JsonConvert.SerializeObject(new RatingBody
                {
                    UserId = new Guid("9DE5C4E1-9E4E-44D5-AEAF-745E140B8C37"),
                    Rating = 5
                });

                var content = new StringContent(json, Encoding.UTF8, "application/json");

                var response = await client.PostAsync($"/api/Movies/{SeedData.AquamanMovie.Id}/ratings", content);
                response.StatusCode.Should().Be(HttpStatusCode.NotFound);
            }
        }

        [Fact]
        public async Task Should_Return_400_When_Rating_Is_Over_Five()
        {
            using (var client = new TestClientProvider().Client)
            {
                var json = JsonConvert.SerializeObject(new RatingBody
                {
                    UserId = SeedData.TestUser.Id,
                    Rating = 6
                });

                var content = new StringContent(json, Encoding.UTF8, "application/json");

                var response = await client.PostAsync($"/api/movies/{SeedData.AquamanMovie.Id}/ratings", content);
                response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
            }
        }

        [Fact]
        public async Task Should_Return_400_When_Rating_Is_Less_Than_One()
        {
            using (var client = new TestClientProvider().Client)
            {
                var json = JsonConvert.SerializeObject(new RatingBody
                {
                    UserId = SeedData.TestUser.Id,
                    Rating = 0
                });

                var content = new StringContent(json, Encoding.UTF8, "application/json");

                var response = await client.PostAsync($"/api/movies/{SeedData.AquamanMovie.Id}/ratings", content);
                response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
            }
        }

        [Fact]
        public async Task Should_Update_User_Rating()
        {
            using (var client = new TestClientProvider().Client)
            {
                var json = JsonConvert.SerializeObject(new RatingBody
                {
                    UserId = SeedData.TestUser.Id,
                    Rating = 1
                });

                var content = new StringContent(json, Encoding.UTF8, "application/json");

                var response = await client.PostAsync($"/api/movies/{SeedData.AquamanMovie.Id}/ratings", content);
                response.StatusCode.Should().Be(HttpStatusCode.OK);
            }
        }

        [Fact]
        public async Task Should_Add_New_Rating()
        {
            using (var client = new TestClientProvider().Client)
            {
                var json = JsonConvert.SerializeObject(new RatingBody
                {
                    UserId = SeedData.UserNotInUse.Id,
                    Rating = 1
                });

                var content = new StringContent(json, Encoding.UTF8, "application/json");

                var response = await client.PostAsync($"/api/movies/{SeedData.AquamanMovie.Id}/ratings", content);
                response.StatusCode.Should().Be(HttpStatusCode.OK);
            }
        }
    }
}