using IdentityModel;
using IdentityServer4.Models;
using IdentityServer4.Services;
using IdentityServerExperiments.Repositories;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityServerExperiments.ApplicationServices
{
    public class ProfileService : IProfileService
    {
        private readonly UsersRepository _repository;

        public ProfileService(UsersRepository repository)
        {
            _repository = repository;
        }

        public async Task GetProfileDataAsync(ProfileDataRequestContext context)
        {
            var userId = context.Subject.Claims.FirstOrDefault(x => x.Type == JwtClaimTypes.Subject);
            if (userId != null && Guid.TryParse(userId.Value, out var parsedId))
            {
                var user = await _repository.FindByIdAsync(parsedId);
                if (user != null)
                    context.IssuedClaims = user.Claims;
            }
        }

        public async Task IsActiveAsync(IsActiveContext context)
        {
            var userId = context.Subject.Claims.FirstOrDefault(x => x.Type == JwtClaimTypes.Subject);
            if (userId != null && Guid.TryParse(userId.Value, out var parsedId))
                context.IsActive = (await _repository.FindByIdAsync(parsedId)) != null;
        }
    }
}
