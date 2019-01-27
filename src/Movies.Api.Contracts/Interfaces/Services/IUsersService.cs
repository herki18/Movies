using System;
using System.Threading.Tasks;

namespace Movies.Api.Contracts.Interfaces.Services
{
    public interface IUsersService
    {
        Task<bool> CheckIfUserExists(Guid userId);
    }
}
