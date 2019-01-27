using System;
using Microsoft.EntityFrameworkCore;
using Movies.Api.Contracts.Entities;

namespace Movies.Api.DAL
{
    public static class SeedData
    {
        #region Genres

        public static readonly GenreEntity AdventureGenre = new GenreEntity { Id = new Guid("E3CB0FE5-BA1F-4BA4-B807-5EC9C4413BBF"), Name = "Adventure" };
        public static readonly GenreEntity ComedyGenre = new GenreEntity { Id = new Guid("2758F711-CFDA-4CB9-B4D3-E798954EA723"), Name = "Comedy" };
        public static readonly GenreEntity ActionGenre = new GenreEntity { Id = new Guid("5819E42C-786F-4781-B152-32127EED18F9"), Name = "Action" };
        public static readonly GenreEntity RomanceGenre = new GenreEntity { Id = new Guid("682FF1BE-E949-4BC4-A921-90EB970BEDC1"), Name = "Romance" };
        public static readonly GenreEntity FantasyGenre = new GenreEntity { Id = new Guid("D640F2A3-4AB3-4A6B-9F81-02A4D6DB130A"), Name = "Fantasy" };
        public static readonly GenreEntity HorrorGenre = new GenreEntity { Id = new Guid("34640828-5E98-4360-9E4D-BA94496A83A1"), Name = "Horror" };
        public static readonly GenreEntity DramaGenre = new GenreEntity { Id = new Guid("A55DF7FC-7EE8-478C-8956-B8DC0A51DC9D"), Name = "Drama" };
        public static readonly GenreEntity SciFiGenre = new GenreEntity { Id = new Guid("96CB4A96-524E-4CF1-A73B-44C40F6D9740"), Name = "Sci-Fi" };
        public static readonly GenreEntity CrimeGenre = new GenreEntity { Id = new Guid("662C3AA4-B716-4F62-9332-32E37C84A657"), Name = "Crime" };

        #endregion

        #region Users

        public static readonly UserEntity TestUser = new UserEntity()
        {
            Id = new Guid("A8DDDDC7-CEA9-4901-A32E-D82E8A9A518D"),
            UserName = "Test"
        };

        public static readonly UserEntity Test1User = new UserEntity()
        {
            Id = new Guid("66701AD7-9B72-494E-B98E-E3231A47BB6E"),
            UserName = "Test1"
        };

        public static readonly UserEntity Test2User = new UserEntity()
        {
            Id = new Guid("8696AAFA-3FE9-457C-A82A-F1C929E9CBBD"),
            UserName = "Test2"
        };

        public static readonly UserEntity UserNotInUse = new UserEntity
        {
            Id = new Guid("E16C0541-57B9-4824-92E9-B5DE5A4E6125"),
            UserName = "UserNotInUse"
        };

        #endregion

        #region Movies

        public static MovieEntity AquamanMovie
        {
            get
            {
                var movie = new MovieEntity
                {
                    Id = new Guid("2C397E2B-619F-4AA6-91E7-89E4D890B170"),
                    Title = "Aquaman",
                    YearOfRelease = 2018,
                    RunningTime = 143
                };

                movie.GenreMovies.Add(new GenreMovieEntity() { Genre = ActionGenre });
                movie.GenreMovies.Add(new GenreMovieEntity() { Genre = AdventureGenre});
                movie.GenreMovies.Add(new GenreMovieEntity() { Genre = FantasyGenre});

                movie.Ratings.Add(new RatingEntity()
                {
                    Id = new Guid("0666151B-3BB0-4BF2-91A6-D48B959C1919"), Movie = movie, User = TestUser, Rating = 5
                });
                movie.Ratings.Add(new RatingEntity()
                {
                    Id = new Guid("92B392C1-D33D-438A-9170-9908455421C8"), Movie = movie, User = Test1User, Rating = 4
                });
                movie.Ratings.Add(new RatingEntity()
                {
                    Id = new Guid("04020521-7C22-4AA3-93B4-7EF233BB28B2"), Movie = movie, User = Test2User, Rating = 5
                });
                return movie;
            }
        }

        public static MovieEntity BirdBoxMovie
        {
            get
            {
                var movie = new MovieEntity
                {
                    Id = new Guid("B793166F-83F3-405C-AED4-B013CA2B60CC"),
                    Title = "Bird Box",
                    YearOfRelease = 2018,
                    RunningTime = 124
                };

                movie.GenreMovies.Add(new GenreMovieEntity() {Genre = DramaGenre});
                movie.GenreMovies.Add(new GenreMovieEntity() {Genre = HorrorGenre});
                movie.GenreMovies.Add(new GenreMovieEntity() { Genre = SciFiGenre});

            movie.Ratings.Add(new RatingEntity() { Id = new Guid("8A231499-97CC-41FC-BD50-F8FBD4CC3CEB"), Movie = movie, User = TestUser, Rating = 4 });
                movie.Ratings.Add(new RatingEntity() { Id = new Guid("6A916307-479F-4A69-BD26-68A0B2FC584D"), Movie = movie, User = Test1User, Rating = 4 });
                movie.Ratings.Add(new RatingEntity() { Id = new Guid("B8179F4E-7DC9-40D4-B0A5-0F5EBF3414BE"), Movie = movie, User = Test2User, Rating = 5 });
                return movie;
            }
        }

        public static MovieEntity TheGodFatherMovie
        {
            get
            {
                var movie = new MovieEntity
                {
                    Id = new Guid("943A6006-1B79-48F3-8261-AA9D217FF9B8"),
                    Title = "The God Father",
                    YearOfRelease = 1972,
                    RunningTime = 175
                };

                movie.GenreMovies.Add(new GenreMovieEntity() { Genre = DramaGenre});
                movie.GenreMovies.Add(new GenreMovieEntity() { Genre = CrimeGenre});

                movie.Ratings.Add(new RatingEntity() { Id = new Guid("C9C4D46C-D33E-4A50-9B4D-92008EA20E8D"), Movie = movie, User = TestUser, Rating = 3 });
                movie.Ratings.Add(new RatingEntity() { Id = new Guid("8DE3E732-B704-4C92-8FE6-2565C191DA8B"), Movie = movie, User = Test1User, Rating = 3 });
                movie.Ratings.Add(new RatingEntity() { Id = new Guid("9616E321-A16E-403A-92ED-BE0B5DAD8EF3"), Movie = movie, User = Test2User, Rating = 4 });
                return movie;
            }
        }

        public static MovieEntity TheWizardOfOzMovie
        {
            get
            {
                var movie = new MovieEntity
                {
                    Id = new Guid("13BEF656-1570-4BDD-9FED-2CBDF1087B29"),
                    Title = "The Wizard Of Oz",
                    YearOfRelease = 1939,
                    RunningTime = 102
                };

                movie.GenreMovies.Add(new GenreMovieEntity() { Genre = AdventureGenre});
                movie.GenreMovies.Add(new GenreMovieEntity() { Genre = FantasyGenre});

                movie.Ratings.Add(new RatingEntity() { Id = new Guid("D3546CEF-2D35-4BD0-9BD5-CF51480213B8"), Movie = movie, User = TestUser, Rating = 2 });
                movie.Ratings.Add(new RatingEntity() { Id = new Guid("450F1828-9F7B-4994-9928-DED0F0C2FB33"), Movie = movie, User = Test1User, Rating = 2 });
                movie.Ratings.Add(new RatingEntity() { Id = new Guid("44699FC5-8D3A-4C4D-B3BC-3AF8FA9A0A1B"), Movie = movie, User = Test2User, Rating = 4 });
                return movie;
            }
        }

        public static MovieEntity ForrestGumpMovie
        {
            get
            {
                var movie = new MovieEntity
                {
                    Id = new Guid("1B1F6F61-5993-4CBD-8596-1F83BD0D4547"),
                    Title = "Forrest Gump",
                    YearOfRelease = 1994,
                    RunningTime = 144
                };

                movie.GenreMovies.Add(new GenreMovieEntity() { Genre = DramaGenre});
                movie.GenreMovies.Add(new GenreMovieEntity() { Genre = RomanceGenre});

                movie.Ratings.Add(new RatingEntity() { Id = new Guid("B751F8D6-99EA-4BF8-8420-4DFF214AE362"), Movie = movie, User = TestUser, Rating = 1 });
                movie.Ratings.Add(new RatingEntity() { Id = new Guid("F9D9ADE6-13BD-4BE6-BAF5-855604CFDC98"), Movie = movie, User = Test1User, Rating = 3 });
                movie.Ratings.Add(new RatingEntity() { Id = new Guid("E011F5D1-8091-4644-83F4-705F23290E11"), Movie = movie, User = Test2User, Rating = 4 });
                return movie;
            }
        }

        public static MovieEntity AngryManMovie
        {
            get
            {
                var movie = new MovieEntity
                {
                    Id = new Guid("77741192-186A-4C9C-96E0-964AB14C6C8D"),
                    Title = "12 Angry Man",
                    YearOfRelease = 1957,
                    RunningTime = 96
                };

                movie.GenreMovies.Add(new GenreMovieEntity() { Genre = DramaGenre});

                movie.Ratings.Add(new RatingEntity() { Id = new Guid("9E7CE884-2772-4ACB-A3DC-86F53CB9F284"), Movie = movie, User = TestUser, Rating = 1 });
                movie.Ratings.Add(new RatingEntity() { Id = new Guid("CF139BEA-EE27-4A44-A9DD-756B1A40CB48"), Movie = movie, User = Test1User, Rating = 3 });
                movie.Ratings.Add(new RatingEntity() { Id = new Guid("F257E06A-5B7C-40B0-A261-DCB27EB62EB2"), Movie = movie, User = Test2User, Rating = 4 });
                return movie;
            }
        }

        #endregion

        public static void SeedInitialData(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<GenreEntity>().HasData(AdventureGenre);
            modelBuilder.Entity<GenreEntity>().HasData(ComedyGenre);
            modelBuilder.Entity<GenreEntity>().HasData(ActionGenre);
            modelBuilder.Entity<GenreEntity>().HasData(RomanceGenre);
            modelBuilder.Entity<GenreEntity>().HasData(FantasyGenre);
            modelBuilder.Entity<GenreEntity>().HasData(HorrorGenre);
            modelBuilder.Entity<GenreEntity>().HasData(DramaGenre);
            modelBuilder.Entity<GenreEntity>().HasData(SciFiGenre);
            modelBuilder.Entity<GenreEntity>().HasData(CrimeGenre);

            modelBuilder.Entity<UserEntity>().HasData(TestUser);
            modelBuilder.Entity<UserEntity>().HasData(Test1User);
            modelBuilder.Entity<UserEntity>().HasData(Test2User);
            modelBuilder.Entity<UserEntity>().HasData(UserNotInUse);

            AddMovieEntity(modelBuilder, AquamanMovie);
            AddMovieEntity(modelBuilder, BirdBoxMovie);
            AddMovieEntity(modelBuilder, TheGodFatherMovie);
            AddMovieEntity(modelBuilder, TheWizardOfOzMovie);
            AddMovieEntity(modelBuilder, ForrestGumpMovie);
            AddMovieEntity(modelBuilder, AngryManMovie);
        }

        private static void AddMovieEntity(ModelBuilder modelBuilder, MovieEntity movie)
        {
            modelBuilder.Entity<MovieEntity>().HasData(new MovieEntity
            {
                Id = movie.Id,
                Title = movie.Title,
                RunningTime = movie.RunningTime,
                YearOfRelease = movie.YearOfRelease
            });
            AddGenreEntities(modelBuilder, movie);
            AddRatingsEntities(modelBuilder, movie);
        }

        private static void AddRatingsEntities(ModelBuilder modelBuilder, MovieEntity movie)
        {
            foreach (var rating in movie.Ratings)
            {
                modelBuilder.Entity<RatingEntity>().HasData(new
                {
                    Id = rating.Id,
                    Rating = rating.Rating,
                    MovieId = rating.Movie.Id,
                    UserId = rating.User.Id
                });
            }
        }

        private static void AddGenreEntities(ModelBuilder modelBuilder, MovieEntity movie)
        {
            foreach (var genre in movie.GenreMovies)
            {
                var genreMovie = new GenreMovieEntity()
                {
                    Id = Guid.NewGuid(),
                    MovieId = movie.Id,
                    GenreId = genre.Genre.Id
                };
                modelBuilder.Entity<GenreMovieEntity>().HasData(genreMovie);
            }
        }
    }
}