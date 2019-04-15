using IdentityServer4.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityServerExperiments.Repositories
{
    public class ResourcesRepository
    {
        public async Task<Client> GetClientByIdAsync(string clientId) 
            => await Task.FromResult(GetClients().FirstOrDefault(c => c.ClientId == clientId));

        public async Task<List<ApiResource>> GetApiResourcesAsync()
            => await Task.FromResult(GetApiResources());

        public async Task<ApiResource> GetApiResourceByNameAsync(string name) 
            => await Task.FromResult(GetApiResources().FirstOrDefault(c => c.Name == name));

        public async Task<List<ApiResource>> GetApiResourcesByNameAsync(IEnumerable<string> names)
            => await Task.FromResult(GetApiResources().Where(c => names.Contains(c.Name)).ToList());

        public async Task<List<IdentityResource>> GetIdentityResourcesAsync() 
            => await Task.FromResult(GetIdentityResources());

        public async Task<Resources> GetAllResourcesAsync()
            => await Task.FromResult(new Resources(GetIdentityResources(), GetApiResources()));


        private List<IdentityResource> GetIdentityResources()
        {
            return new List<IdentityResource>
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile()
            };
        }

        private List<ApiResource> GetApiResources()
        {
            return new List<ApiResource>
            {
                new ApiResource("jurify.api", "Jurify back-end api, application's core")
            };
        }

        private List<Client> GetClients()
        {
            return new List<Client>
            {
                new Client
                {
                    ClientId = "jurify.web",
                    ClientSecrets = { new Secret("p84wXuaXCWuCHnny".Sha256()) },
                    AllowedGrantTypes = GrantTypes.Implicit,
                    AllowedScopes = { "jurify.api" },
                    AccessTokenType = AccessTokenType.Reference
                }
            };
        }
    }
}
