using System;
using System.ComponentModel.DataAnnotations;

namespace Movies.Api.Contracts.Entities
{
    public class RatingEntity
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        [Required]
        public UserEntity User { get; set; }
        public Guid MovieId { get; set; }
        [Required]
        public MovieEntity Movie { get; set; }
        [Range(1, 5)]
        public int Rating { get; set; }
    }
}
