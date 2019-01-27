using System.Collections.Generic;

namespace Movies.Api.Contracts.Queries
{
    public class MoviesQuery
    {
        public string Title { get; set; }
        public List<string> Genres { get; set; }
        public int? YearOfRelease { get; set; }
    }
}