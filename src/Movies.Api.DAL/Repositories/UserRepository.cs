using System;
using System.Threading.Tasks;
using Movies.Api.Contracts.Interfaces.Repositories;

namespace Movies.Api.DAL.Repositories
{
    public class UsersRepository : IUsersRepository
    {
        private readonly ApiContext _apiContext;

        public UsersRepository(ApiContext apiContext)
        {
            _apiContext = apiContext;
        }

        public async Task<bool> CheckIfUserExists(Guid userId)
        {
            var doesExist = await _apiContext.Users.FindAsync(userId);
            return doesExist != null;
        }
    }
}