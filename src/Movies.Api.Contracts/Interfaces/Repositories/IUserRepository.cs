using System;
using System.Threading.Tasks;

namespace Movies.Api.Contracts.Interfaces.Repositories
{
    public interface IUsersRepository
    {
        Task<bool> CheckIfUserExists(Guid userId);
    }
}
