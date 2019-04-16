using IdentityModel;
using IdentityServer4.Models;
using IdentityServerExperiments.Entities;
using Raven.Client.Documents;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace IdentityServerExperiments.Repositories
{
    public class UsersRepository
    {
        public async Task<Usuario> FindByIdAsync(string id)
        {
            await InsertData();

            using (var session = DocumentStoreHolder.Store.OpenAsyncSession()) 
            {
                return await session
                    .Query<Usuario>()
                    .FirstOrDefaultAsync(c => c.SubjectId == id);
            }
        }

        public async Task<Usuario> FindByUsernameAsync(string username)
        {
            await InsertData();

            using (var session = DocumentStoreHolder.Store.OpenAsyncSession())
            {
                return await session
                    .Query<Usuario>()
                    .FirstOrDefaultAsync(c => c.Username == username);
            }
        }

        private async Task InsertData()
        {
            using (var session = DocumentStoreHolder.Store.OpenAsyncSession())
            {
                if ((await session.Query<Usuario>().FirstOrDefaultAsync(c => c.Username == "gustavo")) != null)
                    return;

                await session.StoreAsync(new Usuario(
                    Guid.NewGuid().ToString(), 
                    "gustavo", 
                    "gustavo".Sha256(), 
                    new List<JurifyClaim> {
                        new JurifyClaim(JwtClaimTypes.Name, "Gustavo dos Santos Oliveira", ClaimValueTypes.String),
                        new JurifyClaim(JwtClaimTypes.BirthDate, new DateTime(1995, 12, 05).ToString(), ClaimValueTypes.DateTime),
                        new JurifyClaim(JwtClaimTypes.Email, "gustavo.dev@outlook.com.br", ClaimValueTypes.Email),
                        new JurifyClaim("IsLawyer", true.ToString(), ClaimValueTypes.Boolean)
                    }));

                await session.SaveChangesAsync();
            }
        }
    }
}
