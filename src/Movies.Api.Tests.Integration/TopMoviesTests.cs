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
    public class TopMoviesTests
    {
        [Fact]
        public async Task Should_Get_Top_Five_Movies_Based_Average_Rating()
        {
            using (var client = new TestClientProvider().Client)
            {
                var response = await client.GetAsync("/api/movies/top");
                response.StatusCode.Should().Be(HttpStatusCode.OK);

                var movies = JsonConvert.DeserializeObject<List<MovieDTO>>(response.Content.ReadAsStringAsync().Result);

                Assert.Equal(5, movies.Count);
            }
        }

        [Fact]
        public async Task Should_Return_404_If_No_Users_Are_Found()
        {
            using (var client = new TestClientProvider().Client)
            {
                var response = await client.GetAsync("/api/Movies/top/FC9557F6-AE08-4867-BB26-766B107CEBAA");
                response.StatusCode.Should().Be(HttpStatusCode.NotFound);
            }
        }

        [Fact]
        public async Task Should_Return_404_If_No_Movies_Are_Found()
        {
            using (var client = new TestClientProvider().Client)
            {
                var response = await client.GetAsync($"/api/Movies/top/{SeedData.UserNotInUse.Id}");
                response.StatusCode.Should().Be(HttpStatusCode.NotFound);
            }
        }

        [Fact]
        public async Task Should_Return_400_If_User_Id_Is_Not_Valid()
        {
            using (var client = new TestClientProvider().Client)
            {
                var response = await client.GetAsync("/api/movies/top/" + "invalid");
                response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
            }
        }

        [Fact]
        public async Task Should_Get_Top_Five_Movies_Based_Average_Rating_For_Specific_User()
        {
            using (var client = new TestClientProvider().Client)
            {
                var response = await client.GetAsync($"/api/Movies/top/{SeedData.TestUser.Id}");
                response.StatusCode.Should().Be(HttpStatusCode.OK);

                var movies = JsonConvert.DeserializeObject<List<MovieDTO>>(response.Content.ReadAsStringAsync().Result);

                Assert.Equal(5, movies.Count);
            }
        }
    }
}
