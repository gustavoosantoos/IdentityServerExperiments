using IdentityServerExperiments.Entities;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace IdentityServerExperiments.ApplicationServices
{
    public interface IUserStore
    {
        Task<bool> ValidateCredentials(string username, string password);
        Task<ApplicationUser> FindBySubjectId(string subjectId);
        Task<ApplicationUser> FindByUsername(string username);
        Task<ApplicationUser> FindByExternalProvider(string provider, string subjectId);
        Task<ApplicationUser> AutoProvisionUser(string provider, string subjectId, List<Claim> claims);
        Task<bool> SaveUser(ApplicationUser user, string newPasswordToHash = null);
    }
}
