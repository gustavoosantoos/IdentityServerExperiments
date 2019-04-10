using System;
using System.Collections.Generic;
using IdentityServer4.Models;

namespace IdentityServerExperiments
{
    public class Config
    {
        public static IEnumerable<ApiResource> GetApiResources()
        {
            return new List<ApiResource>
            {
                new ApiResource("ResourceApi", "Resources api with no data.")
            };
        }

        public static IEnumerable<Client> GetClients()
        {
            return new List<Client>
            {
                new Client
                {
                    ClientId = "test",
                    AllowedGrantTypes = GrantTypes.ClientCredentials,
                    ClientSecrets = 
                    {
                        new Secret("test".Sha256())
                    },
                    AllowedScopes = { "ResourceApi" }
                }
            };
        }
    }
}