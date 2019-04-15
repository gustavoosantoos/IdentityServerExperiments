using IdentityServer4.Validation;
using System;
using System.Threading.Tasks;

namespace IdentityServerExperiments.ApplicationServices
{
    public class ResourceOwnerValidator : IResourceOwnerPasswordValidator
    {
        public Task ValidateAsync(ResourceOwnerPasswordValidationContext context)
        {
            throw new NotImplementedException();
        }
    }
}
