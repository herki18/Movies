using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Movies.Api.Contracts.Entities
{
    [Table("GenreMovies")]
    public class GenreMovieEntity
    {
        public Guid Id { get; set; }
        public Guid MovieId { get; set; }
        [Required]
        public MovieEntity Movie { get; set; }
        public Guid GenreId { get; set; }
        [Required]
        public GenreEntity Genre { get; set; }
    }
}
