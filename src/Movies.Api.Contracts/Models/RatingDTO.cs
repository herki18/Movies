using System;
using System.ComponentModel.DataAnnotations;

namespace Movies.Api.Contracts.Models
{
    public class RatingDTO
    {
        public Guid Id { get; set; }
        [Range(1, 5)]
        public int Rating { get; set; }
        public Guid UserId { get; set; }
    }
}