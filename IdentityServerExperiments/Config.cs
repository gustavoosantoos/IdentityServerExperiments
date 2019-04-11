using System;
using System.Collections.Generic;
using IdentityServer4;
using IdentityServer4.Models;
using IdentityServer4.Test;

namespace IdentityServerExperiments
{
    public class Config
    {
        public static IEnumerable<IdentityResource> GetIdentityResources()
        {
            return new List<IdentityResource>
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile()
            };
        }

        public static List<TestUser> GetUsers()
        {
            return new List<TestUser>
            {
                new TestUser
                {
                    SubjectId = "1",
                    Username = "gustavo",
                    Password = "gustavo"
                },
                new TestUser
                {
                    SubjectId = "2",
                    Username = "carolina",
                    Password = "carolina"
                }
            };
        }

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
                //Client credentials is more indicated for machine-to-machine communications
                new Client
                {
                    ClientId = "test",
                    AllowedGrantTypes = GrantTypes.ClientCredentials,
                    ClientSecrets = { new Secret("test".Sha256()) },
                    AllowedScopes = { "ResourceApi" }
                },

                //Resource Owner grant-type is more indicated for WebApps, SPAs and apps user-to-machine
                new Client
                {
                    ClientId = "test1",
                    AllowedGrantTypes = GrantTypes.ResourceOwnerPassword,
                    ClientSecrets = { new Secret("test1".Sha256()) },
                    AllowedScopes = { "ResourceApi"}
                },

                //Implicit flow grant-type is indicated as well to WebApps with User interaction
                new Client
                {
                    ClientId = "mvc-client",
                    ClientName = "MVC Client",
                    AllowedGrantTypes = GrantTypes.Implicit,
                    RedirectUris = { "http://localhost:8000/signin-oidc" },
                    PostLogoutRedirectUris = { "http://localhost:8000/signout-callback-oidc" },
                    AllowedScopes =
                    {
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile
                    }
                }
            };
        }
    }
}