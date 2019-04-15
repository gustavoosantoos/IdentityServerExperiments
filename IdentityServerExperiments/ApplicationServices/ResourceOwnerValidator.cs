using IdentityModel;
using IdentityServer4.Validation;
using IdentityServerExperiments.Repositories;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityServerExperiments.ApplicationServices
{
    public class ResourceOwnerValidator : IResourceOwnerPasswordValidator
    {
        private readonly UsersRepository _repository;

        public ResourceOwnerValidator(UsersRepository repository)
        {
            _repository = repository;
        }

        public async Task ValidateAsync(ResourceOwnerPasswordValidationContext context)
        {
            try
            {
                var userId = context.Request.Subject.Claims.FirstOrDefault(c => c.Type == JwtClaimTypes.Subject);
                if (userId != null && Guid.TryParse(userId.Value, out var parsedId))
                {
                    var user = await _repository.FindByIdAsync(parsedId);
                    if (user != null)
                    {
                        if (context.Password == user.Password)
                        {
                            context.Result = new GrantValidationResult(
                                subject: user.Id.ToString(),
                                authenticationMethod: "custom",
                                claims: user.Claims
                            );
                        }
                    }
                    else
                    {
                        context.Result = new GrantValidationResult
                        {
                            IsError = true,
                            Error = "Usuário e/ou senha inválidos"
                        };
                    }
                }
            }
            catch (Exception ex)
            {
                context.Result = new GrantValidationResult
                {
                    IsError = true,
                    Error = "Usuário e/ou senha inválidos"
                };
            }
        }
    }
}
