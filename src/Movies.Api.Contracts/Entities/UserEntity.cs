using System;

namespace Movies.Api.Contracts.Entities
{
    public class UserEntity
    {
        public Guid Id { get; set; }
        public string UserName { get; set; }
    }
}
