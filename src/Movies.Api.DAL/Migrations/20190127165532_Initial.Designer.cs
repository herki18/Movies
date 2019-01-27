﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Movies.Api.DAL;

namespace Movies.Api.DAL.Migrations
{
    [DbContext(typeof(ApiContext))]
    [Migration("20190127165532_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.1-servicing-10028");

            modelBuilder.Entity("Movies.Api.Contracts.Entities.GenreEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Genres");

                    b.HasData(
                        new
                        {
                            Id = new Guid("e3cb0fe5-ba1f-4ba4-b807-5ec9c4413bbf"),
                            Name = "Adventure"
                        },
                        new
                        {
                            Id = new Guid("2758f711-cfda-4cb9-b4d3-e798954ea723"),
                            Name = "Comedy"
                        },
                        new
                        {
                            Id = new Guid("5819e42c-786f-4781-b152-32127eed18f9"),
                            Name = "Action"
                        },
                        new
                        {
                            Id = new Guid("682ff1be-e949-4bc4-a921-90eb970bedc1"),
                            Name = "Romance"
                        },
                        new
                        {
                            Id = new Guid("d640f2a3-4ab3-4a6b-9f81-02a4d6db130a"),
                            Name = "Fantasy"
                        },
                        new
                        {
                            Id = new Guid("34640828-5e98-4360-9e4d-ba94496a83a1"),
                            Name = "Horror"
                        },
                        new
                        {
                            Id = new Guid("a55df7fc-7ee8-478c-8956-b8dc0a51dc9d"),
                            Name = "Drama"
                        },
                        new
                        {
                            Id = new Guid("96cb4a96-524e-4cf1-a73b-44c40f6d9740"),
                            Name = "Sci-Fi"
                        },
                        new
                        {
                            Id = new Guid("662c3aa4-b716-4f62-9332-32e37c84a657"),
                            Name = "Crime"
                        });
                });

            modelBuilder.Entity("Movies.Api.Contracts.Entities.GenreMovieEntity", b =>
                {
                    b.Property<Guid>("GenreId");

                    b.Property<Guid>("MovieId");

                    b.Property<Guid>("Id");

                    b.HasKey("GenreId", "MovieId");

                    b.HasIndex("MovieId");

                    b.ToTable("GenreMovies");

                    b.HasData(
                        new
                        {
                            GenreId = new Guid("5819e42c-786f-4781-b152-32127eed18f9"),
                            MovieId = new Guid("2c397e2b-619f-4aa6-91e7-89e4d890b170"),
                            Id = new Guid("73e30de4-0579-4233-a76b-d1bd89c6cc00")
                        },
                        new
                        {
                            GenreId = new Guid("e3cb0fe5-ba1f-4ba4-b807-5ec9c4413bbf"),
                            MovieId = new Guid("2c397e2b-619f-4aa6-91e7-89e4d890b170"),
                            Id = new Guid("9e9e6385-de2e-43c5-a6c1-0e5a7b77e775")
                        },
                        new
                        {
                            GenreId = new Guid("d640f2a3-4ab3-4a6b-9f81-02a4d6db130a"),
                            MovieId = new Guid("2c397e2b-619f-4aa6-91e7-89e4d890b170"),
                            Id = new Guid("6ce88d71-a2ab-4704-b01b-1e753c2c6e30")
                        },
                        new
                        {
                            GenreId = new Guid("a55df7fc-7ee8-478c-8956-b8dc0a51dc9d"),
                            MovieId = new Guid("b793166f-83f3-405c-aed4-b013ca2b60cc"),
                            Id = new Guid("2b0bbeb4-9aed-4d7b-b520-8d379a5a6ab2")
                        },
                        new
                        {
                            GenreId = new Guid("34640828-5e98-4360-9e4d-ba94496a83a1"),
                            MovieId = new Guid("b793166f-83f3-405c-aed4-b013ca2b60cc"),
                            Id = new Guid("ad965515-4ccf-4ef4-843b-966baba524ed")
                        },
                        new
                        {
                            GenreId = new Guid("96cb4a96-524e-4cf1-a73b-44c40f6d9740"),
                            MovieId = new Guid("b793166f-83f3-405c-aed4-b013ca2b60cc"),
                            Id = new Guid("ecb69abc-1311-461a-ae31-8952d3ff2a3f")
                        },
                        new
                        {
                            GenreId = new Guid("a55df7fc-7ee8-478c-8956-b8dc0a51dc9d"),
                            MovieId = new Guid("943a6006-1b79-48f3-8261-aa9d217ff9b8"),
                            Id = new Guid("3fa78843-53ae-4fa1-873f-0040d99f9d72")
                        },
                        new
                        {
                            GenreId = new Guid("662c3aa4-b716-4f62-9332-32e37c84a657"),
                            MovieId = new Guid("943a6006-1b79-48f3-8261-aa9d217ff9b8"),
                            Id = new Guid("18c44e1f-c8d5-4cfd-a950-d3f45e83bb38")
                        },
                        new
                        {
                            GenreId = new Guid("e3cb0fe5-ba1f-4ba4-b807-5ec9c4413bbf"),
                            MovieId = new Guid("13bef656-1570-4bdd-9fed-2cbdf1087b29"),
                            Id = new Guid("2cf342a4-7bec-43bb-8a06-467206707217")
                        },
                        new
                        {
                            GenreId = new Guid("d640f2a3-4ab3-4a6b-9f81-02a4d6db130a"),
                            MovieId = new Guid("13bef656-1570-4bdd-9fed-2cbdf1087b29"),
                            Id = new Guid("50c6f8d5-9a20-4bf3-88fa-3d2817b18c7c")
                        },
                        new
                        {
                            GenreId = new Guid("a55df7fc-7ee8-478c-8956-b8dc0a51dc9d"),
                            MovieId = new Guid("1b1f6f61-5993-4cbd-8596-1f83bd0d4547"),
                            Id = new Guid("98bda21c-d019-46c4-9c6f-372bc67466f6")
                        },
                        new
                        {
                            GenreId = new Guid("682ff1be-e949-4bc4-a921-90eb970bedc1"),
                            MovieId = new Guid("1b1f6f61-5993-4cbd-8596-1f83bd0d4547"),
                            Id = new Guid("58d4693b-471f-4638-a9be-63a08f71df0d")
                        },
                        new
                        {
                            GenreId = new Guid("a55df7fc-7ee8-478c-8956-b8dc0a51dc9d"),
                            MovieId = new Guid("77741192-186a-4c9c-96e0-964ab14c6c8d"),
                            Id = new Guid("666c96eb-eff3-4624-b2ca-8f479dc1bd88")
                        });
                });

            modelBuilder.Entity("Movies.Api.Contracts.Entities.MovieEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("RunningTime");

                    b.Property<string>("Title");

                    b.Property<int>("YearOfRelease");

                    b.HasKey("Id");

                    b.ToTable("Movies");

                    b.HasData(
                        new
                        {
                            Id = new Guid("2c397e2b-619f-4aa6-91e7-89e4d890b170"),
                            RunningTime = 143,
                            Title = "Aquaman",
                            YearOfRelease = 2018
                        },
                        new
                        {
                            Id = new Guid("b793166f-83f3-405c-aed4-b013ca2b60cc"),
                            RunningTime = 124,
                            Title = "Bird Box",
                            YearOfRelease = 2018
                        },
                        new
                        {
                            Id = new Guid("943a6006-1b79-48f3-8261-aa9d217ff9b8"),
                            RunningTime = 175,
                            Title = "The God Father",
                            YearOfRelease = 1972
                        },
                        new
                        {
                            Id = new Guid("13bef656-1570-4bdd-9fed-2cbdf1087b29"),
                            RunningTime = 102,
                            Title = "The Wizard Of Oz",
                            YearOfRelease = 1939
                        },
                        new
                        {
                            Id = new Guid("1b1f6f61-5993-4cbd-8596-1f83bd0d4547"),
                            RunningTime = 144,
                            Title = "Forrest Gump",
                            YearOfRelease = 1994
                        },
                        new
                        {
                            Id = new Guid("77741192-186a-4c9c-96e0-964ab14c6c8d"),
                            RunningTime = 96,
                            Title = "12 Angry Man",
                            YearOfRelease = 1957
                        });
                });

            modelBuilder.Entity("Movies.Api.Contracts.Entities.RatingEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid>("MovieId");

                    b.Property<int>("Rating");

                    b.Property<Guid>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("MovieId");

                    b.HasIndex("UserId", "MovieId")
                        .IsUnique();

                    b.ToTable("Ratings");

                    b.HasData(
                        new
                        {
                            Id = new Guid("0666151b-3bb0-4bf2-91a6-d48b959c1919"),
                            MovieId = new Guid("2c397e2b-619f-4aa6-91e7-89e4d890b170"),
                            Rating = 5,
                            UserId = new Guid("a8ddddc7-cea9-4901-a32e-d82e8a9a518d")
                        },
                        new
                        {
                            Id = new Guid("92b392c1-d33d-438a-9170-9908455421c8"),
                            MovieId = new Guid("2c397e2b-619f-4aa6-91e7-89e4d890b170"),
                            Rating = 4,
                            UserId = new Guid("66701ad7-9b72-494e-b98e-e3231a47bb6e")
                        },
                        new
                        {
                            Id = new Guid("04020521-7c22-4aa3-93b4-7ef233bb28b2"),
                            MovieId = new Guid("2c397e2b-619f-4aa6-91e7-89e4d890b170"),
                            Rating = 5,
                            UserId = new Guid("8696aafa-3fe9-457c-a82a-f1c929e9cbbd")
                        },
                        new
                        {
                            Id = new Guid("8a231499-97cc-41fc-bd50-f8fbd4cc3ceb"),
                            MovieId = new Guid("b793166f-83f3-405c-aed4-b013ca2b60cc"),
                            Rating = 4,
                            UserId = new Guid("a8ddddc7-cea9-4901-a32e-d82e8a9a518d")
                        },
                        new
                        {
                            Id = new Guid("6a916307-479f-4a69-bd26-68a0b2fc584d"),
                            MovieId = new Guid("b793166f-83f3-405c-aed4-b013ca2b60cc"),
                            Rating = 4,
                            UserId = new Guid("66701ad7-9b72-494e-b98e-e3231a47bb6e")
                        },
                        new
                        {
                            Id = new Guid("b8179f4e-7dc9-40d4-b0a5-0f5ebf3414be"),
                            MovieId = new Guid("b793166f-83f3-405c-aed4-b013ca2b60cc"),
                            Rating = 5,
                            UserId = new Guid("8696aafa-3fe9-457c-a82a-f1c929e9cbbd")
                        },
                        new
                        {
                            Id = new Guid("c9c4d46c-d33e-4a50-9b4d-92008ea20e8d"),
                            MovieId = new Guid("943a6006-1b79-48f3-8261-aa9d217ff9b8"),
                            Rating = 3,
                            UserId = new Guid("a8ddddc7-cea9-4901-a32e-d82e8a9a518d")
                        },
                        new
                        {
                            Id = new Guid("8de3e732-b704-4c92-8fe6-2565c191da8b"),
                            MovieId = new Guid("943a6006-1b79-48f3-8261-aa9d217ff9b8"),
                            Rating = 3,
                            UserId = new Guid("66701ad7-9b72-494e-b98e-e3231a47bb6e")
                        },
                        new
                        {
                            Id = new Guid("9616e321-a16e-403a-92ed-be0b5dad8ef3"),
                            MovieId = new Guid("943a6006-1b79-48f3-8261-aa9d217ff9b8"),
                            Rating = 4,
                            UserId = new Guid("8696aafa-3fe9-457c-a82a-f1c929e9cbbd")
                        },
                        new
                        {
                            Id = new Guid("d3546cef-2d35-4bd0-9bd5-cf51480213b8"),
                            MovieId = new Guid("13bef656-1570-4bdd-9fed-2cbdf1087b29"),
                            Rating = 2,
                            UserId = new Guid("a8ddddc7-cea9-4901-a32e-d82e8a9a518d")
                        },
                        new
                        {
                            Id = new Guid("450f1828-9f7b-4994-9928-ded0f0c2fb33"),
                            MovieId = new Guid("13bef656-1570-4bdd-9fed-2cbdf1087b29"),
                            Rating = 2,
                            UserId = new Guid("66701ad7-9b72-494e-b98e-e3231a47bb6e")
                        },
                        new
                        {
                            Id = new Guid("44699fc5-8d3a-4c4d-b3bc-3af8fa9a0a1b"),
                            MovieId = new Guid("13bef656-1570-4bdd-9fed-2cbdf1087b29"),
                            Rating = 4,
                            UserId = new Guid("8696aafa-3fe9-457c-a82a-f1c929e9cbbd")
                        },
                        new
                        {
                            Id = new Guid("b751f8d6-99ea-4bf8-8420-4dff214ae362"),
                            MovieId = new Guid("1b1f6f61-5993-4cbd-8596-1f83bd0d4547"),
                            Rating = 1,
                            UserId = new Guid("a8ddddc7-cea9-4901-a32e-d82e8a9a518d")
                        },
                        new
                        {
                            Id = new Guid("f9d9ade6-13bd-4be6-baf5-855604cfdc98"),
                            MovieId = new Guid("1b1f6f61-5993-4cbd-8596-1f83bd0d4547"),
                            Rating = 3,
                            UserId = new Guid("66701ad7-9b72-494e-b98e-e3231a47bb6e")
                        },
                        new
                        {
                            Id = new Guid("e011f5d1-8091-4644-83f4-705f23290e11"),
                            MovieId = new Guid("1b1f6f61-5993-4cbd-8596-1f83bd0d4547"),
                            Rating = 4,
                            UserId = new Guid("8696aafa-3fe9-457c-a82a-f1c929e9cbbd")
                        },
                        new
                        {
                            Id = new Guid("9e7ce884-2772-4acb-a3dc-86f53cb9f284"),
                            MovieId = new Guid("77741192-186a-4c9c-96e0-964ab14c6c8d"),
                            Rating = 1,
                            UserId = new Guid("a8ddddc7-cea9-4901-a32e-d82e8a9a518d")
                        },
                        new
                        {
                            Id = new Guid("cf139bea-ee27-4a44-a9dd-756b1a40cb48"),
                            MovieId = new Guid("77741192-186a-4c9c-96e0-964ab14c6c8d"),
                            Rating = 3,
                            UserId = new Guid("66701ad7-9b72-494e-b98e-e3231a47bb6e")
                        },
                        new
                        {
                            Id = new Guid("f257e06a-5b7c-40b0-a261-dcb27eb62eb2"),
                            MovieId = new Guid("77741192-186a-4c9c-96e0-964ab14c6c8d"),
                            Rating = 4,
                            UserId = new Guid("8696aafa-3fe9-457c-a82a-f1c929e9cbbd")
                        });
                });

            modelBuilder.Entity("Movies.Api.Contracts.Entities.UserEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("UserName");

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = new Guid("a8ddddc7-cea9-4901-a32e-d82e8a9a518d"),
                            UserName = "Test"
                        },
                        new
                        {
                            Id = new Guid("66701ad7-9b72-494e-b98e-e3231a47bb6e"),
                            UserName = "Test1"
                        },
                        new
                        {
                            Id = new Guid("8696aafa-3fe9-457c-a82a-f1c929e9cbbd"),
                            UserName = "Test2"
                        },
                        new
                        {
                            Id = new Guid("e16c0541-57b9-4824-92e9-b5de5a4e6125"),
                            UserName = "UserNotInUse"
                        });
                });

            modelBuilder.Entity("Movies.Api.Contracts.Entities.GenreMovieEntity", b =>
                {
                    b.HasOne("Movies.Api.Contracts.Entities.GenreEntity", "Genre")
                        .WithMany("GenreMovies")
                        .HasForeignKey("GenreId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Movies.Api.Contracts.Entities.MovieEntity", "Movie")
                        .WithMany("GenreMovies")
                        .HasForeignKey("MovieId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Movies.Api.Contracts.Entities.RatingEntity", b =>
                {
                    b.HasOne("Movies.Api.Contracts.Entities.MovieEntity", "Movie")
                        .WithMany("Ratings")
                        .HasForeignKey("MovieId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Movies.Api.Contracts.Entities.UserEntity", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}