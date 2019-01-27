using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Movies.Api.Contracts.Entities
{
    public class MovieEntity
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public int YearOfRelease { get; set; }
        public int RunningTime { get; set; }
        public ICollection<GenreMovieEntity> GenreMovies { get; set; } = new List<GenreMovieEntity>();
        [NotMapped]
        public double? AverageRating { get; set; }
        public ICollection<RatingEntity> Ratings { get; set; } = new List<RatingEntity>();
    }
}
