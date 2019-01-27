using Microsoft.EntityFrameworkCore;
using Movies.Api.Contracts.Entities;

namespace Movies.Api.DAL
{
    public class ApiContext : DbContext
    {
        public DbSet<MovieEntity> Movies { get; set; }
        public DbSet<RatingEntity> Ratings { get; set; }
        public DbSet<UserEntity> Users { get; set; }
        public DbSet<GenreEntity> Genres { get; set; }
        public DbSet<GenreMovieEntity> GenreMovies { get; set; }

        public ApiContext(DbContextOptions<ApiContext> options)
            : base(options)
        {
        }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<GenreMovieEntity>()
                .HasKey(bc => new { bc.GenreId, bc.MovieId});

            modelBuilder.Entity<GenreMovieEntity>()
                .HasOne(bc => bc.Movie)
                .WithMany(wm => wm.GenreMovies)
                .HasForeignKey(bc => bc.MovieId);

            modelBuilder.Entity<GenreMovieEntity>()
                .HasOne(bc => bc.Genre)
                .WithMany(wm => wm.GenreMovies)
                .HasForeignKey(bc => bc.GenreId);

            modelBuilder.Entity<RatingEntity>()
                .HasIndex(p => new { p.UserId, p.MovieId })
                .IsUnique();

            // Seed Data
            SeedData.SeedInitialData(modelBuilder);
        }
    }
}