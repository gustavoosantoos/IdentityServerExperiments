using IdentityServer4.Models;
using IdentityServer4.Stores;
using IdentityServerExperiments.Repositories;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IdentityServerExperiments.ApplicationServices
{
    public class ResourceStore : IResourceStore
    {
        private readonly ResourcesRepository _repository;

        public ResourceStore(ResourcesRepository repository)
        {
            _repository = repository;
        }

        public async Task<ApiResource> FindApiResourceAsync(string name) 
            => await _repository.GetApiResourceByNameAsync(name);

        public async Task<IEnumerable<ApiResource>> FindApiResourcesByScopeAsync(IEnumerable<string> scopeNames)
            => await _repository.GetApiResourcesByNameAsync(scopeNames);

        public async Task<IEnumerable<IdentityResource>> FindIdentityResourcesByScopeAsync(IEnumerable<string> scopeNames)
            => await _repository.GetIdentityResourcesAsync();

        public async Task<Resources> GetAllResourcesAsync()
            => await _repository.GetallResourcesAsync();
    }
}
