using IdentityServer4.Models;
using IdentityServer4.Stores;
using IdentityServerExperiments.Repositories;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityServerExperiments.ApplicationServices
{
    public class ClientStore : IClientStore
    {
        private readonly ResourcesRepository _repository;

        public ClientStore(ResourcesRepository repository)
        {
            _repository = repository;
        }

        public async Task<Client> FindClientByIdAsync(string clientId) => await _repository.GetClientByIdAsync(clientId);
    }
}
