using IdentityServerExperiments.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityServerExperiments.Repositories
{
    public class UsersRepository
    {
        public async Task<Usuario> FindByIdAsync(Guid id)
        {
            return await Task.FromResult<Usuario>(null);
        }
    }
}
