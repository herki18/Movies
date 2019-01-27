using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Movies.Api.DAL.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Genres",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genres", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Movies",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Title = table.Column<string>(nullable: true),
                    YearOfRelease = table.Column<int>(nullable: false),
                    RunningTime = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    UserName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GenreMovies",
                columns: table => new
                {
                    MovieId = table.Column<Guid>(nullable: false),
                    GenreId = table.Column<Guid>(nullable: false),
                    Id = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GenreMovies", x => new { x.GenreId, x.MovieId });
                    table.ForeignKey(
                        name: "FK_GenreMovies_Genres_GenreId",
                        column: x => x.GenreId,
                        principalTable: "Genres",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GenreMovies_Movies_MovieId",
                        column: x => x.MovieId,
                        principalTable: "Movies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Ratings",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    UserId = table.Column<Guid>(nullable: false),
                    MovieId = table.Column<Guid>(nullable: false),
                    Rating = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ratings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Ratings_Movies_MovieId",
                        column: x => x.MovieId,
                        principalTable: "Movies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Ratings_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Genres",
                columns: new[] { "Id", "Name" },
                values: new object[] { new Guid("e3cb0fe5-ba1f-4ba4-b807-5ec9c4413bbf"), "Adventure" });

            migrationBuilder.InsertData(
                table: "Genres",
                columns: new[] { "Id", "Name" },
                values: new object[] { new Guid("2758f711-cfda-4cb9-b4d3-e798954ea723"), "Comedy" });

            migrationBuilder.InsertData(
                table: "Genres",
                columns: new[] { "Id", "Name" },
                values: new object[] { new Guid("5819e42c-786f-4781-b152-32127eed18f9"), "Action" });

            migrationBuilder.InsertData(
                table: "Genres",
                columns: new[] { "Id", "Name" },
                values: new object[] { new Guid("682ff1be-e949-4bc4-a921-90eb970bedc1"), "Romance" });

            migrationBuilder.InsertData(
                table: "Genres",
                columns: new[] { "Id", "Name" },
                values: new object[] { new Guid("d640f2a3-4ab3-4a6b-9f81-02a4d6db130a"), "Fantasy" });

            migrationBuilder.InsertData(
                table: "Genres",
                columns: new[] { "Id", "Name" },
                values: new object[] { new Guid("34640828-5e98-4360-9e4d-ba94496a83a1"), "Horror" });

            migrationBuilder.InsertData(
                table: "Genres",
                columns: new[] { "Id", "Name" },
                values: new object[] { new Guid("a55df7fc-7ee8-478c-8956-b8dc0a51dc9d"), "Drama" });

            migrationBuilder.InsertData(
                table: "Genres",
                columns: new[] { "Id", "Name" },
                values: new object[] { new Guid("96cb4a96-524e-4cf1-a73b-44c40f6d9740"), "Sci-Fi" });

            migrationBuilder.InsertData(
                table: "Genres",
                columns: new[] { "Id", "Name" },
                values: new object[] { new Guid("662c3aa4-b716-4f62-9332-32e37c84a657"), "Crime" });

            migrationBuilder.InsertData(
                table: "Movies",
                columns: new[] { "Id", "RunningTime", "Title", "YearOfRelease" },
                values: new object[] { new Guid("77741192-186a-4c9c-96e0-964ab14c6c8d"), 96, "12 Angry Man", 1957 });

            migrationBuilder.InsertData(
                table: "Movies",
                columns: new[] { "Id", "RunningTime", "Title", "YearOfRelease" },
                values: new object[] { new Guid("1b1f6f61-5993-4cbd-8596-1f83bd0d4547"), 144, "Forrest Gump", 1994 });

            migrationBuilder.InsertData(
                table: "Movies",
                columns: new[] { "Id", "RunningTime", "Title", "YearOfRelease" },
                values: new object[] { new Guid("13bef656-1570-4bdd-9fed-2cbdf1087b29"), 102, "The Wizard Of Oz", 1939 });

            migrationBuilder.InsertData(
                table: "Movies",
                columns: new[] { "Id", "RunningTime", "Title", "YearOfRelease" },
                values: new object[] { new Guid("2c397e2b-619f-4aa6-91e7-89e4d890b170"), 143, "Aquaman", 2018 });

            migrationBuilder.InsertData(
                table: "Movies",
                columns: new[] { "Id", "RunningTime", "Title", "YearOfRelease" },
                values: new object[] { new Guid("b793166f-83f3-405c-aed4-b013ca2b60cc"), 124, "Bird Box", 2018 });

            migrationBuilder.InsertData(
                table: "Movies",
                columns: new[] { "Id", "RunningTime", "Title", "YearOfRelease" },
                values: new object[] { new Guid("943a6006-1b79-48f3-8261-aa9d217ff9b8"), 175, "The God Father", 1972 });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "UserName" },
                values: new object[] { new Guid("8696aafa-3fe9-457c-a82a-f1c929e9cbbd"), "Test2" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "UserName" },
                values: new object[] { new Guid("a8ddddc7-cea9-4901-a32e-d82e8a9a518d"), "Test" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "UserName" },
                values: new object[] { new Guid("66701ad7-9b72-494e-b98e-e3231a47bb6e"), "Test1" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "UserName" },
                values: new object[] { new Guid("e16c0541-57b9-4824-92e9-b5de5a4e6125"), "UserNotInUse" });

            migrationBuilder.InsertData(
                table: "GenreMovies",
                columns: new[] { "GenreId", "MovieId", "Id" },
                values: new object[] { new Guid("5819e42c-786f-4781-b152-32127eed18f9"), new Guid("2c397e2b-619f-4aa6-91e7-89e4d890b170"), new Guid("73e30de4-0579-4233-a76b-d1bd89c6cc00") });

            migrationBuilder.InsertData(
                table: "GenreMovies",
                columns: new[] { "GenreId", "MovieId", "Id" },
                values: new object[] { new Guid("a55df7fc-7ee8-478c-8956-b8dc0a51dc9d"), new Guid("77741192-186a-4c9c-96e0-964ab14c6c8d"), new Guid("666c96eb-eff3-4624-b2ca-8f479dc1bd88") });

            migrationBuilder.InsertData(
                table: "GenreMovies",
                columns: new[] { "GenreId", "MovieId", "Id" },
                values: new object[] { new Guid("682ff1be-e949-4bc4-a921-90eb970bedc1"), new Guid("1b1f6f61-5993-4cbd-8596-1f83bd0d4547"), new Guid("58d4693b-471f-4638-a9be-63a08f71df0d") });

            migrationBuilder.InsertData(
                table: "GenreMovies",
                columns: new[] { "GenreId", "MovieId", "Id" },
                values: new object[] { new Guid("d640f2a3-4ab3-4a6b-9f81-02a4d6db130a"), new Guid("13bef656-1570-4bdd-9fed-2cbdf1087b29"), new Guid("50c6f8d5-9a20-4bf3-88fa-3d2817b18c7c") });

            migrationBuilder.InsertData(
                table: "GenreMovies",
                columns: new[] { "GenreId", "MovieId", "Id" },
                values: new object[] { new Guid("e3cb0fe5-ba1f-4ba4-b807-5ec9c4413bbf"), new Guid("13bef656-1570-4bdd-9fed-2cbdf1087b29"), new Guid("2cf342a4-7bec-43bb-8a06-467206707217") });

            migrationBuilder.InsertData(
                table: "GenreMovies",
                columns: new[] { "GenreId", "MovieId", "Id" },
                values: new object[] { new Guid("662c3aa4-b716-4f62-9332-32e37c84a657"), new Guid("943a6006-1b79-48f3-8261-aa9d217ff9b8"), new Guid("18c44e1f-c8d5-4cfd-a950-d3f45e83bb38") });

            migrationBuilder.InsertData(
                table: "GenreMovies",
                columns: new[] { "GenreId", "MovieId", "Id" },
                values: new object[] { new Guid("a55df7fc-7ee8-478c-8956-b8dc0a51dc9d"), new Guid("1b1f6f61-5993-4cbd-8596-1f83bd0d4547"), new Guid("98bda21c-d019-46c4-9c6f-372bc67466f6") });

            migrationBuilder.InsertData(
                table: "GenreMovies",
                columns: new[] { "GenreId", "MovieId", "Id" },
                values: new object[] { new Guid("96cb4a96-524e-4cf1-a73b-44c40f6d9740"), new Guid("b793166f-83f3-405c-aed4-b013ca2b60cc"), new Guid("ecb69abc-1311-461a-ae31-8952d3ff2a3f") });

            migrationBuilder.InsertData(
                table: "GenreMovies",
                columns: new[] { "GenreId", "MovieId", "Id" },
                values: new object[] { new Guid("34640828-5e98-4360-9e4d-ba94496a83a1"), new Guid("b793166f-83f3-405c-aed4-b013ca2b60cc"), new Guid("ad965515-4ccf-4ef4-843b-966baba524ed") });

            migrationBuilder.InsertData(
                table: "GenreMovies",
                columns: new[] { "GenreId", "MovieId", "Id" },
                values: new object[] { new Guid("a55df7fc-7ee8-478c-8956-b8dc0a51dc9d"), new Guid("b793166f-83f3-405c-aed4-b013ca2b60cc"), new Guid("2b0bbeb4-9aed-4d7b-b520-8d379a5a6ab2") });

            migrationBuilder.InsertData(
                table: "GenreMovies",
                columns: new[] { "GenreId", "MovieId", "Id" },
                values: new object[] { new Guid("d640f2a3-4ab3-4a6b-9f81-02a4d6db130a"), new Guid("2c397e2b-619f-4aa6-91e7-89e4d890b170"), new Guid("6ce88d71-a2ab-4704-b01b-1e753c2c6e30") });

            migrationBuilder.InsertData(
                table: "GenreMovies",
                columns: new[] { "GenreId", "MovieId", "Id" },
                values: new object[] { new Guid("e3cb0fe5-ba1f-4ba4-b807-5ec9c4413bbf"), new Guid("2c397e2b-619f-4aa6-91e7-89e4d890b170"), new Guid("9e9e6385-de2e-43c5-a6c1-0e5a7b77e775") });

            migrationBuilder.InsertData(
                table: "GenreMovies",
                columns: new[] { "GenreId", "MovieId", "Id" },
                values: new object[] { new Guid("a55df7fc-7ee8-478c-8956-b8dc0a51dc9d"), new Guid("943a6006-1b79-48f3-8261-aa9d217ff9b8"), new Guid("3fa78843-53ae-4fa1-873f-0040d99f9d72") });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "MovieId", "Rating", "UserId" },
                values: new object[] { new Guid("450f1828-9f7b-4994-9928-ded0f0c2fb33"), new Guid("13bef656-1570-4bdd-9fed-2cbdf1087b29"), 2, new Guid("66701ad7-9b72-494e-b98e-e3231a47bb6e") });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "MovieId", "Rating", "UserId" },
                values: new object[] { new Guid("44699fc5-8d3a-4c4d-b3bc-3af8fa9a0a1b"), new Guid("13bef656-1570-4bdd-9fed-2cbdf1087b29"), 4, new Guid("8696aafa-3fe9-457c-a82a-f1c929e9cbbd") });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "MovieId", "Rating", "UserId" },
                values: new object[] { new Guid("9616e321-a16e-403a-92ed-be0b5dad8ef3"), new Guid("943a6006-1b79-48f3-8261-aa9d217ff9b8"), 4, new Guid("8696aafa-3fe9-457c-a82a-f1c929e9cbbd") });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "MovieId", "Rating", "UserId" },
                values: new object[] { new Guid("b8179f4e-7dc9-40d4-b0a5-0f5ebf3414be"), new Guid("b793166f-83f3-405c-aed4-b013ca2b60cc"), 5, new Guid("8696aafa-3fe9-457c-a82a-f1c929e9cbbd") });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "MovieId", "Rating", "UserId" },
                values: new object[] { new Guid("04020521-7c22-4aa3-93b4-7ef233bb28b2"), new Guid("2c397e2b-619f-4aa6-91e7-89e4d890b170"), 5, new Guid("8696aafa-3fe9-457c-a82a-f1c929e9cbbd") });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "MovieId", "Rating", "UserId" },
                values: new object[] { new Guid("cf139bea-ee27-4a44-a9dd-756b1a40cb48"), new Guid("77741192-186a-4c9c-96e0-964ab14c6c8d"), 3, new Guid("66701ad7-9b72-494e-b98e-e3231a47bb6e") });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "MovieId", "Rating", "UserId" },
                values: new object[] { new Guid("f9d9ade6-13bd-4be6-baf5-855604cfdc98"), new Guid("1b1f6f61-5993-4cbd-8596-1f83bd0d4547"), 3, new Guid("66701ad7-9b72-494e-b98e-e3231a47bb6e") });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "MovieId", "Rating", "UserId" },
                values: new object[] { new Guid("8de3e732-b704-4c92-8fe6-2565c191da8b"), new Guid("943a6006-1b79-48f3-8261-aa9d217ff9b8"), 3, new Guid("66701ad7-9b72-494e-b98e-e3231a47bb6e") });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "MovieId", "Rating", "UserId" },
                values: new object[] { new Guid("c9c4d46c-d33e-4a50-9b4d-92008ea20e8d"), new Guid("943a6006-1b79-48f3-8261-aa9d217ff9b8"), 3, new Guid("a8ddddc7-cea9-4901-a32e-d82e8a9a518d") });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "MovieId", "Rating", "UserId" },
                values: new object[] { new Guid("92b392c1-d33d-438a-9170-9908455421c8"), new Guid("2c397e2b-619f-4aa6-91e7-89e4d890b170"), 4, new Guid("66701ad7-9b72-494e-b98e-e3231a47bb6e") });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "MovieId", "Rating", "UserId" },
                values: new object[] { new Guid("9e7ce884-2772-4acb-a3dc-86f53cb9f284"), new Guid("77741192-186a-4c9c-96e0-964ab14c6c8d"), 1, new Guid("a8ddddc7-cea9-4901-a32e-d82e8a9a518d") });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "MovieId", "Rating", "UserId" },
                values: new object[] { new Guid("b751f8d6-99ea-4bf8-8420-4dff214ae362"), new Guid("1b1f6f61-5993-4cbd-8596-1f83bd0d4547"), 1, new Guid("a8ddddc7-cea9-4901-a32e-d82e8a9a518d") });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "MovieId", "Rating", "UserId" },
                values: new object[] { new Guid("d3546cef-2d35-4bd0-9bd5-cf51480213b8"), new Guid("13bef656-1570-4bdd-9fed-2cbdf1087b29"), 2, new Guid("a8ddddc7-cea9-4901-a32e-d82e8a9a518d") });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "MovieId", "Rating", "UserId" },
                values: new object[] { new Guid("e011f5d1-8091-4644-83f4-705f23290e11"), new Guid("1b1f6f61-5993-4cbd-8596-1f83bd0d4547"), 4, new Guid("8696aafa-3fe9-457c-a82a-f1c929e9cbbd") });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "MovieId", "Rating", "UserId" },
                values: new object[] { new Guid("8a231499-97cc-41fc-bd50-f8fbd4cc3ceb"), new Guid("b793166f-83f3-405c-aed4-b013ca2b60cc"), 4, new Guid("a8ddddc7-cea9-4901-a32e-d82e8a9a518d") });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "MovieId", "Rating", "UserId" },
                values: new object[] { new Guid("0666151b-3bb0-4bf2-91a6-d48b959c1919"), new Guid("2c397e2b-619f-4aa6-91e7-89e4d890b170"), 5, new Guid("a8ddddc7-cea9-4901-a32e-d82e8a9a518d") });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "MovieId", "Rating", "UserId" },
                values: new object[] { new Guid("6a916307-479f-4a69-bd26-68a0b2fc584d"), new Guid("b793166f-83f3-405c-aed4-b013ca2b60cc"), 4, new Guid("66701ad7-9b72-494e-b98e-e3231a47bb6e") });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "MovieId", "Rating", "UserId" },
                values: new object[] { new Guid("f257e06a-5b7c-40b0-a261-dcb27eb62eb2"), new Guid("77741192-186a-4c9c-96e0-964ab14c6c8d"), 4, new Guid("8696aafa-3fe9-457c-a82a-f1c929e9cbbd") });

            migrationBuilder.CreateIndex(
                name: "IX_GenreMovies_MovieId",
                table: "GenreMovies",
                column: "MovieId");

            migrationBuilder.CreateIndex(
                name: "IX_Ratings_MovieId",
                table: "Ratings",
                column: "MovieId");

            migrationBuilder.CreateIndex(
                name: "IX_Ratings_UserId_MovieId",
                table: "Ratings",
                columns: new[] { "UserId", "MovieId" },
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GenreMovies");

            migrationBuilder.DropTable(
                name: "Ratings");

            migrationBuilder.DropTable(
                name: "Genres");

            migrationBuilder.DropTable(
                name: "Movies");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
