using System;
using System.Collections.Generic;

namespace Movies.Api.Contracts.Entities
{
    public class GenreEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public ICollection<GenreMovieEntity> GenreMovies { get; set; } = new List<GenreMovieEntity>();
    }
}
