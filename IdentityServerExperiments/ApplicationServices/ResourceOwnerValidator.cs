using System.Threading.Tasks;
using IdentityServer4.Validation;

namespace IdentityServerExperiments
{
    public class ResourceOwnerValidator : IResourceOwnerPasswordValidator
    {
        public Task ValidateAsync(ResourceOwnerPasswordValidationContext context)
        {
            throw new System.NotImplementedException();
        }
    }
}