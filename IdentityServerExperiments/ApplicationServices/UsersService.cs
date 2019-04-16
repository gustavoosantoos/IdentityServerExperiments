using IdentityServer4.Models;
using IdentityServerExperiments.Entities;
using IdentityServerExperiments.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityServerExperiments.ApplicationServices
{
    public class UsersService
    {
        private readonly UsersRepository _repository;

        public UsersService(UsersRepository repository)
        {
            _repository = repository;
        }

        public async Task<bool> ValidateCredentials(string username, string password)
        {
            var user = await FindByUsername(username);
            return user != null && user.Password == password.Sha256();
        }

        public async Task<Usuario> FindByUsername(string username)
        {
            return await _repository.FindByUsernameAsync(username);
        }
    }
}
