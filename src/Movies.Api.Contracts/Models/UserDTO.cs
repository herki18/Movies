using System;

namespace Movies.Api.Contracts.Models
{
    public class UserDTO
    {
        public Guid Id { get; set; }
        public string UserName { get; set; }
    }
}