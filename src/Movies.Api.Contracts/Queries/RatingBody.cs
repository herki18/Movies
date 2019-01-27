using System;

namespace Movies.Api.Contracts.Queries
{
    public class RatingBody
    {
        public Guid UserId { get; set; }
        public int Rating { get; set; }
    }
}