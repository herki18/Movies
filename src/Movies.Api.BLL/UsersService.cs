using System;
using System.Threading.Tasks;
using Movies.Api.Contracts.Interfaces.Repositories;
using Movies.Api.Contracts.Interfaces.Services;

namespace Movies.Api.BLL
{
    public class UsersService : IUsersService
    {
        private readonly IUsersRepository _usersRepository;

        public UsersService(IUsersRepository usersRepository)
        {
            _usersRepository = usersRepository;
        }

        public async Task<bool> CheckIfUserExists(Guid userId)
        {
            return await _usersRepository.CheckIfUserExists(userId);
        }
    }
}